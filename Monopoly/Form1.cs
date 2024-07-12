using Microsoft.VisualBasic.Devices;
using System.IO;
using System.Net.Sockets;
using System.Text;
using static System.Windows.Forms.DataFormats;

namespace Monopoly
{

    public partial class Form1 : Form
    {
        // Description: Monopoly game
        // This is a simple Monopoly game in C#.
        // It is a simple game that allows the user to play Monopoly with up to 4 players.
        // The game is played by rolling dice and moving around the board. The player can buy properties, pay rent, and collect money.
        // The game is won by the player who has the most money at the end of the game.

        // -- Change below: -- //
        int numberOfPlayers = 3; // Default to 4 players


        // Variables
        PictureBox[] players = new PictureBox[4];
        int currentPlayer = 0;
        int[] playerMoney = new int[4];
        int[] playerPosition = new int[4];
        PictureBox[] boardSpaces;
        int boxSize = 50; // Size of each box on the board
        int boardSize = 11; // Size of the board (11x11)
        Property[] properties = new Property[28];
        int currentFreeParkingPot = 0;
        int clientCounter = 1; // Start at 1 since the host is Player 0

        // Networking
        private TcpClient client;
        private NetworkStream stream;
        private List<TcpClient> clients = new List<TcpClient>(); // List to store connected clients

        public Form1()
        {
            InitializeComponent();
            InitializePlayers();
            GenerateBoard();
            InitializeProperties();
        }

        private void Log(string message)
        {
            // Log the message to txtLog
            txtLog.AppendText(message + "\r\n");
        }
        private void Do(string command, bool broadcast = true)
        {
            try
            {
                if (GetPlayerId() == 0) // Only the server should broadcast commands
                {
                    // Log
                    if (broadcast)
                    {
                        Log("Broadcasting: " + command);
                        Broadcast(GetPlayerId() + ": " + command);
                    }
                }
                else
                {
                    // log
                    Log("Processing: " + command);
                }

                if (command.StartsWith("Player"))
                {
                    int player = int.Parse(command.Substring(7, 1));
                    string action = command.Substring(9);

                    switch (action.Split(' ')[0])
                    {
                        case "SetMoney":
                            int money = int.Parse(action.Substring(9));
                            playerMoney[player] = money;
                            Log("Player " + player + " set their money to $" + money);
                            break;
                        case "RollDice":
                            int dice = RollDice();
                            Log("Player " + player + " rolled a " + dice);
                            MovePlayer(player, dice);
                            break;
                        case "BuyHouse":
                            int property = int.Parse(action.Substring(9));
                            BuyHouse(player, property);
                            break;
                        case "BuyHotel":
                            property = int.Parse(action.Substring(9));
                            BuyHotel(player, property);
                            break;
                        case "FreeParking":
                            Log("Player " + player + " landed on Free Parking");
                            playerMoney[player] += currentFreeParkingPot;
                            Log("Player " + player + " collected $" + currentFreeParkingPot + " from Free Parking");
                            currentFreeParkingPot = 0;
                            break;
                        case "GoToJail":
                            Log("Player " + player + " landed on Go to Jail");
                            break;
                        default:
                            Log("Invalid action: " + action);
                            break;
                    }
                }
                else if (command.StartsWith("Roll")) // Handle Roll command from client
                {
                    int player = int.Parse(command.Substring(4, 1));
                    Do("Player " + player + " RollDice");
                }
                else if (command.StartsWith("UpdateLabels"))
                {
                    lblMoney1.Text = "Money: $" + (numberOfPlayers > 0 ? playerMoney[0].ToString() : "");
                    lblMoney2.Text = "Money: $" + (numberOfPlayers > 1 ? playerMoney[1].ToString() : "");
                    lblMoney3.Text = "Money: $" + (numberOfPlayers > 2 ? playerMoney[2].ToString() : "");
                    lblMoney4.Text = "Money: $" + (numberOfPlayers > 3 ? playerMoney[3].ToString() : "");

                    lblPos1.Text = "Position: " + (numberOfPlayers > 0 ? playerPosition[0].ToString() : "");
                    lblPos2.Text = "Position: " + (numberOfPlayers > 1 ? playerPosition[1].ToString() : "");
                    lblPos3.Text = "Position: " + (numberOfPlayers > 2 ? playerPosition[2].ToString() : "");
                    lblPos4.Text = "Position: " + (numberOfPlayers > 3 ? playerPosition[3].ToString() : "");

                    lblOwned1.Text = "Properties: " + (numberOfPlayers > 0 ? GetPlayerProperties(0) : "");
                    lblOwned2.Text = "Properties: " + (numberOfPlayers > 1 ? GetPlayerProperties(1) : "");
                    lblOwned3.Text = "Properties: " + (numberOfPlayers > 2 ? GetPlayerProperties(2) : "");
                    lblOwned4.Text = "Properties: " + (numberOfPlayers > 3 ? GetPlayerProperties(3) : "");

                    Log("Updated player money, position and properties labels");
                }
                else if (command.StartsWith("Move"))
                {
                    int player = int.Parse(command.Substring(4, 1));
                    int spaces = int.Parse(command.Substring(6));
                    MovePlayer(player, spaces);
                    Log("Player " + player + " moved " + spaces + " spaces");
                }
                else if (command.StartsWith("Buy"))
                {
                    // Handle Buy commands here
                }
                else if (command.StartsWith("Pay"))
                {
                    int player = int.Parse(command.Substring(3, 1));
                    int amount = int.Parse(command.Substring(5));
                    playerMoney[player] -= amount;
                    Log("Player " + player + " paid $" + amount);
                }
                else if (command.StartsWith("Give"))
                {
                    int player = int.Parse(command.Substring(4, 1));
                    int amount = int.Parse(command.Substring(6));
                    playerMoney[player] += amount;
                    Log("Player " + player + " received $" + amount);
                }
                else if (command.StartsWith("Draw"))
                {
                    int player = int.Parse(command.Substring(4, 1));
                    string card = command.Substring(6);
                    int cardNumber = int.Parse(card.Substring(card.Length - 1));
                    if (card.StartsWith("Chance"))
                    {
                        DrawChanceCard(player, cardNumber);
                    }
                    else if (card.StartsWith("CommunityChest"))
                    {
                        DrawCommunityChestCard(player, cardNumber);
                    }
                    else
                    {
                        Log("Invalid card type: " + card);
                    }
                }
                else if (command.StartsWith("MoveTo"))
                {
                    int player = int.Parse(command.Substring(7, 1));
                    int space = int.Parse(command.Substring(8));
                    MovePlayerToSpace(player, space);
                }
                else if (command.StartsWith("EndTurn"))
                {
                    btnRoll.Enabled = false;
                    btnEndRound.Enabled = false;
                    Log("Player " + currentPlayer + " ended their turn");

                    if (currentPlayer != GetPlayerId())
                    {
                        Log("Not my turn.");
                    }

                    currentPlayer = (currentPlayer + 1) % numberOfPlayers;
                    Log("It is now Player " + currentPlayer + "'s turn");

                    if (currentPlayer == GetPlayerId())
                    {
                        btnRoll.Enabled = true;
                    }
                    else
                    {
                        Log("It is not your turn (Current is: " + currentPlayer + ", you are: " + GetPlayerId() + ")");
                    }
                }
                else if (command.StartsWith("CreateGame"))
                {
                    Log("Game created");
                }
                else
                {
                    Log("Invalid command: " + command);
                }
            }
            catch (Exception ex)
            {
                Log("Error processing command: " + ex.Message);
            }
        }


        private int GetPlayerId()
        {
            return (int.Parse(lblPlayer.Text.Substring(8, 1)));
        }

        private void InitializePlayers()
        {
            players = new PictureBox[numberOfPlayers];
            playerMoney = new int[numberOfPlayers];
            playerPosition = new int[numberOfPlayers];

            for (int i = 0; i < numberOfPlayers; i++)
            {
                players[i] = new PictureBox();
                players[i].BackColor = i switch
                {
                    0 => Color.Red,
                    1 => Color.Blue,
                    2 => Color.Green,
                    3 => Color.Yellow,
                    _ => Color.Black
                };

                players[i].Size = new Size(22, 22);
                players[i].Location = new Point(10 + (i * 40), 10);
                this.Controls.Add(players[i]);
                playerMoney[i] = 30000;
                Do($"Player {i} SetMoney 30000");
                playerPosition[i] = 0;
            }

            Do("UpdateLabels");
        }

        private void GenerateBoard()
        {
            boardSpaces = new PictureBox[boardSize * 4 - 4];
            int index = 0;

            for (int i = 0; i < boardSize; i++)
            {
                boardSpaces[index++] = CreateBoardSpace(i * boxSize, 0);
            }

            for (int i = 1; i < boardSize; i++)
            {
                boardSpaces[index++] = CreateBoardSpace((boardSize - 1) * boxSize, i * boxSize);
            }

            for (int i = boardSize - 2; i >= 0; i--)
            {
                boardSpaces[index++] = CreateBoardSpace(i * boxSize, (boardSize - 1) * boxSize);
            }

            for (int i = boardSize - 2; i > 0; i--)
            {
                boardSpaces[index++] = CreateBoardSpace(0, i * boxSize);
            }
        }

        private PictureBox CreateBoardSpace(int x, int y)
        {
            PictureBox box = new PictureBox
            {
                Size = new Size(boxSize, boxSize),
                Location = new Point(x, y),
                BorderStyle = BorderStyle.FixedSingle
            };

            this.Controls.Add(box);
            return box;
        }

        // Initialize properties
        private void InitializeProperties()
        {
            properties = new Property[40];

            properties[1] = new Property { Name = "Västerlång Gatan", Price = 1000, RentStages = new int[] { 50, 200, 600, 1700, 3000, 4750 }, ColorGroup = "Pink" };
            properties[3] = new Property { Name = "Hornsgatan", Price = 1000, RentStages = new int[] { 100, 400, 1100, 3400, 6000, 8550 }, ColorGroup = "Pink" };
            properties[5] = new Property { Name = "Södra Station", Price = 4000 };
            properties[6] = new Property { Name = "Folkunga Gatan", Price = 2000, RentStages = new int[] { 100, 550, 1700, 5150, 7600, 9500 }, ColorGroup = "Light Blue" };
            properties[8] = new Property { Name = "Götagatan", Price = 2000, RentStages = new int[] { 100, 550, 1700, 5150, 7600, 9500 }, ColorGroup = "Light Blue" };
            properties[9] = new Property { Name = "Ringvägen", Price = 2200, RentStages = new int[] { 150, 750, 2000, 5750, 8500, 11500 }, ColorGroup = "Light Blue" };
            properties[11] = new Property { Name = "S:T Eriksgatan", Price = 2500, RentStages = new int[] { 200, 1000, 2000, 8500, 12000, 14250 }, ColorGroup = "Purple" };
            properties[12] = new Property { Name = "Elverket", Price = 3000 };
            properties[13] = new Property { Name = "Odengatan", Price = 2500, RentStages = new int[] { 200, 1000, 2800, 8500, 12000, 14250 }, ColorGroup = "Purple" };
            properties[14] = new Property { Name = "Valhallavägen", Price = 3000, RentStages = new int[] { 250, 1150, 3400, 9500, 13000, 17000 }, ColorGroup = "Purple" };
            properties[15] = new Property { Name = "Östra Station", Price = 3000 };
            properties[16] = new Property { Name = "Sturegatan", Price = 3500, RentStages = new int[] { 250, 1350, 3800, 10500, 14250, 18000 }, ColorGroup = "Orange" };
            properties[18] = new Property { Name = "Karlavägen", Price = 3500, RentStages = new int[] { 250, 1350, 3800, 10500, 14250, 18000 }, ColorGroup = "Orange" };
            properties[19] = new Property { Name = "Narvavägen", Price = 3800, RentStages = new int[] { 300, 1500, 4200, 11500, 15000, 19000 }, ColorGroup = "Orange" };
            properties[21] = new Property { Name = "Strandvägen", Price = 4200, RentStages = new int[] { 350, 1700, 4750, 13000, 16500, 20000 }, ColorGroup = "Red" };
            properties[23] = new Property { Name = "Kungsträdgårdsgatan", Price = 4200, RentStages = new int[] { 350, 1700, 4750, 13000, 16500, 20000 }, ColorGroup = "Red" };
            properties[24] = new Property { Name = "Hamngatan", Price = 4500, RentStages = new int[] { 400, 2000, 5750, 14000, 17500, 21000 }, ColorGroup = "Red" };
            properties[25] = new Property { Name = "Central Station", Price = 4000 };
            properties[26] = new Property { Name = "Vasagatan", Price = 5000, RentStages = new int[] { 400, 2200, 6300, 15000, 18500, 22000 }, ColorGroup = "Yellow" };
            properties[27] = new Property { Name = "Kungsgatan", Price = 5000, RentStages = new int[] { 400, 2200, 6300, 15000, 18500, 22000 }, ColorGroup = "Yellow" };
            properties[28] = new Property { Name = "Vattenledningsverket", Price = 3000 };
            properties[29] = new Property { Name = "Stureplan", Price = 5300, RentStages = new int[] { 400, 2300, 6800, 16000, 19500, 23000 }, ColorGroup = "Yellow" };
            properties[31] = new Property { Name = "Gustav Adolfs Torg", Price = 6000, RentStages = new int[] { 500, 2500, 7500, 17000, 21000, 24200 }, ColorGroup = "Green" };
            properties[32] = new Property { Name = "Drottningatan", Price = 6000, RentStages = new int[] { 500, 2500, 7500, 17000, 21000, 24200 }, ColorGroup = "Green" };
            properties[34] = new Property { Name = "Diplomatstaden", Price = 6000, RentStages = new int[] { 550, 2850, 8500, 19000, 23000, 27000 }, ColorGroup = "Green" };
            properties[35] = new Property { Name = "Norra Station", Price = 6000 };
            properties[37] = new Property { Name = "Centrum", Price = 6500, RentStages = new int[] { 650, 3300, 9500, 21000, 25000, 28500 }, ColorGroup = "Dark Blue" };
            properties[39] = new Property { Name = "Norrmalmstorg", Price = 8000, RentStages = new int[] { 1000, 4000, 12000, 26500, 32500, 40000 }, ColorGroup = "Dark Blue" };
        }

        // Roll the dice
        private int RollDice()
        {
            Random rnd = new Random();
            return rnd.Next(1, 7);
        }

        // Move the player
        private void MovePlayer(int player, int spaces)
        {
            int currentPos = playerPosition[player];
            playerPosition[player] = (playerPosition[player] + spaces) % boardSpaces.Length;
            int newPos = playerPosition[player];
            players[player].Location = new Point(boardSpaces[newPos].Location.X + (boxSize / 4), boardSpaces[newPos].Location.Y + (boxSize / 4));
            ApplySpaceEffects(player, newPos, currentPos);
        }

        // Function for moving the player to a specific space
        private void MovePlayerToSpace(int player, int space)
        {
            playerPosition[player] = space;
            int newPos = playerPosition[player];
            players[player].Location = new Point(boardSpaces[newPos].Location.X + (boxSize / 4), boardSpaces[newPos].Location.Y + (boxSize / 4));
        }

        // Apply effects of landing on the space
        private void ApplySpaceEffects(int player, int space, int oldSpace)
        {
            if (player < 0 || player >= players.Length) return;

            if (space == 0 && oldSpace > 0)
            {
                Do("Give" + player + " 4000");
                Log("Player " + player + " passed Go and collected $4000");
            }
            else if (space == 10)
            {
                Log("Player " + player + " visited Jail");
            }
            else if (space == 20)
            {
                Do("Player " + player + " FreeParking");
            }
            else if (space == 30)
            {
                Log("Player " + player + " landed on Go to Jail");
            }
            else if (space == 2 || space == 17 || space == 33)
            {
                Random rnd = new Random();
                int card = rnd.Next(1, 17);
                Do("Draw" + player + " CommunityChest " + card);
            }
            else if (space == 7 || space == 22 || space == 36)
            {
                Random rnd = new Random();
                int card = rnd.Next(1, 17);
                Do("Draw" + player + " Chance " + card);
            }
            else if (space == 28 || space == 12)
            {
                if (IsPropertyOwned(space))
                {
                    int steps = space - oldSpace;
                    PayRentUtilities(player, space, steps);
                }
                else
                {
                    BuyProperty(player, space, properties[space].Price);
                }
            }
            else if (space == 5 || space == 15 || space == 25 || space == 35)
            {
                if (IsPropertyOwned(space))
                {
                    PayRentJärnväg(player, space);
                }
                else
                {
                    BuyProperty(player, space, properties[space].Price);
                }
            }
            else if (space == 4)
            {
                playerMoney[player] -= 4000;
                currentFreeParkingPot += 4000;
                Log("Player " + player + " paid $4000 income tax");
            }
            else if (space == 38)
            {
                playerMoney[player] -= 2000;
                currentFreeParkingPot += 2000;
                Log("Player " + player + " paid $2000 luxury tax");
            }
            else
            {
                Log("Player " + player + " landed on property " + space);
                if (properties[space].IsOwned)
                {
                    PayRent(player, space);
                }
                else
                {
                    BuyProperty(player, space, properties[space].Price);
                }
            }
        }

        // Function to pay rent
        private void PayRent(int player, int propertyIndex)
        {
            Property property = properties[propertyIndex];
            int owner = property.Owner;
            int rent = property.GetRent();

            if (playerMoney[player] >= rent)
            {
                playerMoney[player] -= rent;
                playerMoney[owner] += rent;
                Log("Player " + player + " paid $" + rent + " rent to Player " + owner);
            }
            else
            {
                Log("Player " + player + " does not have enough money to pay rent to Player " + owner);
            }
        }

        // Function to pay rent for Järnväg
        private void PayRentJärnväg(int player, int property)
        {
            int owner = properties[property].Owner;
            int rent = 0;
            int järnvägCount = 0;

            for (int i = 0; i < properties.Length; i++)
            {
                if (properties[i] != null && properties[i].Owner == owner && (i == 5 || i == 15 || i == 25 || i == 35))
                {
                    järnvägCount++;
                }
            }

            switch (järnvägCount)
            {
                case 1: rent = 500; break;
                case 2: rent = 1000; break;
                case 3: rent = 2000; break;
                case 4: rent = 4000; break;
            }

            if (playerMoney[player] >= rent)
            {
                playerMoney[player] -= rent;
                playerMoney[owner] += rent;
                Log("Player " + player + " paid $" + rent + " rent to Player " + owner);
            }
            else
            {
                Log("Player " + player + " does not have enough money to pay rent to Player " + owner);
            }
        }

        // Function to pay rent for Utilities
        private void PayRentUtilities(int player, int property, int steps)
        {
            int owner = properties[property].Owner;
            int rent = 0;
            int rentPerStep = 0;
            int utilityCount = 0;

            for (int i = 0; i < properties.Length; i++)
            {
                if (properties[i] != null && properties[i].Owner == owner && (i == 12 || i == 28))
                {
                    utilityCount++;
                }
            }

            if (utilityCount == 1)
            {
                rentPerStep = 100;
            }
            else if (utilityCount == 2)
            {
                rentPerStep = 200;
            }

            rent = rentPerStep * steps;

            if (playerMoney[player] >= rent)
            {
                playerMoney[player] -= rent;
                playerMoney[owner] += rent;
                Log("Player " + player + " paid $" + rent + " rent to Player " + owner + " (" + rentPerStep + " * " + steps + ")");
            }
            else
            {
                Log("Player " + player + " does not have enough money to pay rent to Player " + owner);
            }
        }


        // Function to buy property
        private void BuyProperty(int player, int property, int price)
        {
            // Get property name
            string propertyName = properties[property].Name;
            // Check if the player has enough money
            if (playerMoney[player] >= price)
            {
                /*
                // Ask player if they want to buy the property
                DialogResult result = MessageBox.Show("Do you want to buy property " + propertyName + " (" + property + ") for $" + price + "?", "Buy Property", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    // Player bought the property
                    playerMoney[player] -= price;
                    // Set property as owned
                    properties[property].IsOwned = true;
                    properties[property].Owner = player;
                    Log("Player " + player + " bought property " + propertyName + " (" + property + ") for $" + price);
                }
                */

                // Player bought the property
                playerMoney[player] -= price;
                // Set property as owned
                properties[property].IsOwned = true;
                properties[property].Owner = player;
                Log("Player " + player + " bought property " + propertyName + " (" + property + ") for $" + price);
            }
            else
            {
                Log("Player " + player + " does not have enough money to buy property " + propertyName + " (" + property + ")");
            }
        }


        // Function to see if property is owned
        private bool IsPropertyOwned(int property)
        {
            return properties[property].IsOwned;
        }


        private void BuyHouse(int player, int propertyIndex)
        {
            Property property = properties[propertyIndex];

            if (property.Owner != player || property.Hotel || property.Houses > 4)
            {
                Log("Cannot buy more houses or hotels for this property.");
                return;
            }

            if (property.Houses == 4)
            {
                BuyHotel(player, propertyIndex);
                return;
            }

            int houseCost = property.Price / 2;
            if (playerMoney[player] >= houseCost)
            {
                playerMoney[player] -= houseCost;
                property.Houses++;
                Log("Player " + player + " bought a house on " + property.Name);
            }
            else
            {
                Log("Player " + player + " does not have enough money to buy a house on " + property.Name);
            }
        }
        private void BuyHotel(int player, int propertyIndex)
        {
            Property property = properties[propertyIndex];
            int hotelCost = property.Price;

            if (property.Owner != player || property.Hotel || property.Houses < 4)
            {
                Log("Cannot buy a hotel for this property.");
                return;
            }

            if (playerMoney[player] >= hotelCost)
            {
                playerMoney[player] -= hotelCost;
                property.Houses = 0;
                property.Hotel = true;
                Log("Player " + player + " bought a hotel on " + property.Name);
            }
            else
            {
                Log("Player " + player + " does not have enough money to buy a hotel on " + property.Name);
            }
        }


        // Function to draw a Chance Card
        private void DrawChanceCard(int player, int card)
        {
            switch (card)
            {
                case 1:
                    if (playerPosition[player] >= 15) Do("Give" + player + " 4000");
                    Do("MoveTo " + player + " 15");
                    Log("Player " + player + " drew a Chance Card and went to Östra Station");
                    break;
                case 2:
                    // Betala ersättning för Gatuunderhåll (Betala $800 per hus, $2300 per hotell)
                    // Add implementation as needed
                    break;
                case 3:
                    if (playerMoney[player] >= 300) Do("Pay" + player + " 300");
                    Log("Player " + player + " drew a Chance Card and paid $300");
                    break;
                case 5:
                    Do("Give" + player + " 3000");
                    Log("Player " + player + " drew a Chance Card and received $3000");
                    break;
                case 6:
                    if (playerPosition[player] >= 11) Do("Give" + player + " 4000");
                    Do("MoveTo " + player + " 11");
                    Log("Player " + player + " drew a Chance Card and went to S:T Eriksgatan");
                    break;
                case 7:
                    Do("Give" + player + " 2000");
                    Log("Player " + player + " drew a Chance Card and received $2000");
                    break;
                case 8:
                    // Alla era fastigheter måste repareras (Betala $500 per hus, $2000 per hotell)
                    // Add implementation as needed
                    break;
                case 9:
                    if (playerMoney[player] >= 3000) Do("Pay" + player + " 3000");
                    Log("Player " + player + " drew a Chance Card and paid $3000");
                    break;
                case 10:
                    Do("Give" + player + " 1000");
                    Log("Player " + player + " drew a Chance Card and received $1000");
                    break;
                case 11:
                    // Ni slipper ut ur fängelset (Få ett Get Out of Jail Free kort)
                    // Add implementation as needed
                    break;
                case 12:
                    if (playerPosition[player] >= 24) Do("Give" + player + " 4000");
                    Do("MoveTo " + player + " 24");
                    Log("Player " + player + " drew a Chance Card and went to Hamngatan");
                    break;
                case 13:
                    if (playerMoney[player] >= 400) Do("Pay" + player + " 400");
                    Log("Player " + player + " drew a Chance Card and paid $400");
                    break;
                case 14:
                    Do("MoveTo " + player + " " + (playerPosition[player] - 3));
                    Log("Player " + player + " drew a Chance Card and went back 3 spaces");
                    break;
                case 15:
                    Do("MoveTo " + player + " 0");
                    Log("Player " + player + " drew a Chance Card and went to Go");
                    break;
                case 16:
                    Do("MoveTo " + player + " 39");
                    Log("Player " + player + " drew a Chance Card and went to Norrmalmstorg");
                    break;
                default:
                    Log("Unknown Chance card: " + card);
                    break;
            }
        }
        // Function to draw a Community Chest Card
        private void DrawCommunityChestCard(int player, int card)
        {
            switch (card)
            {
                case 1:
                    Do("Give" + player + " 4000");
                    Log("Player " + player + " drew a Community Chest Card and received $4000");
                    break;
                case 2:
                    Do("Give" + player + " 500");
                    Log("Player " + player + " drew a Community Chest Card and received $500");
                    break;
                case 3:
                    Do("Give" + player + " 400");
                    Log("Player " + player + " drew a Community Chest Card and received $400");
                    break;
                case 4:
                    Do("Give" + player + " 2000");
                    Log("Player " + player + " drew a Community Chest Card and received $2000");
                    break;
                case 5:
                    for (int i = 0; i < players.Length; i++)
                    {
                        if (i != player)
                        {
                            if (playerMoney[i] < 200)
                            {
                                playerMoney[player] += playerMoney[i];
                                playerMoney[i] = 0;
                                Log("Player " + player + " drew a Community Chest Card and received $" + playerMoney[i] + " from Player " + i);
                            }
                            else
                            {
                                playerMoney[i] -= 200;
                                playerMoney[player] += 200;
                                Log("Player " + player + " drew a Community Chest Card and received $200 from Player " + i);
                            }
                        }
                    }
                    break;
                case 6:
                    if (playerMoney[player] >= 2000) Do("Pay" + player + " 2000");
                    Log("Player " + player + " drew a Community Chest Card and paid $2000");
                    break;
                case 7:
                    Do("Give" + player + " 1000");
                    Log("Player " + player + " drew a Community Chest Card and received $1000");
                    break;
                case 8:
                    MovePlayerToSpace(player, 1);
                    Log("Player " + player + " drew a Community Chest Card and went back to Västerlånggatan");
                    break;
                case 9:
                    if (playerMoney[player] >= 1000) Do("Pay" + player + " 1000");
                    Log("Player " + player + " drew a Community Chest Card and paid $1000");
                    break;
                case 10:
                    if (playerMoney[player] >= 200) Do("Pay" + player + " 200");
                    Log("Player " + player + " drew a Community Chest Card and paid $200");
                    break;
                case 11:
                    Do("Give" + player + " 2000");
                    Log("Player " + player + " drew a Community Chest Card and received $2000");
                    break;
                case 12:
                    // Ni slipper ut ur fängelset (Få ett Get Out of Jail Free kort)
                    // Add implementation as needed
                    break;
                case 13:
                    Do("Give" + player + " 1000");
                    Log("Player " + player + " drew a Community Chest Card and received $1000");
                    break;
                case 14:
                    MovePlayerToSpace(player, 0);
                    Log("Player " + player + " drew a Community Chest Card and went to Go");
                    break;
                case 15:
                    MovePlayerToSpace(player, 10);
                    Log("Player " + player + " drew a Community Chest Card and went to Jail");
                    break;
                case 16:
                    Do("Give" + player + " 200");
                    Log("Player " + player + " drew a Community Chest Card and received $200");
                    break;
                default:
                    Log("Unknown Community Chest card: " + card);
                    break;
            }
        }


        private void btnRoll_Click(object sender, EventArgs e)
        {
            if (GetPlayerId() == 0)
            {
                // If player is host
                int dice1 = RollDice();
                int dice2 = RollDice();
                Log("Player " + currentPlayer + " rolled a " + dice1 + " and a " + dice2);
                int dice = dice1 + dice2;
                Do("Move" + currentPlayer + " " + dice);
                Do("UpdateLabels");
                btnEndRound.Enabled = true;
                btnRoll.Enabled = false;
            }
            else if (GetPlayerId() == currentPlayer)
            {
                // If player is client
                byte[] data = Encoding.ASCII.GetBytes(GetPlayerId() + ": Roll" + GetPlayerId());
                stream.Write(data, 0, data.Length);
                Log("Sent Roll command to host");
                btnEndRound.Enabled = true;
                btnRoll.Enabled = false;
            }
            else
            {
                // Log
                Log("It is not your turn (Current is: " + currentPlayer + ", you are: " + GetPlayerId() + ")");
            }

        }
        private void btnEndRound_Click(object sender, EventArgs e)
        {
            if (GetPlayerId() == 0)
            {
                // If player is host
                Do("EndTurn");
            }
            else if (GetPlayerId() == currentPlayer)
            {
                // If player is client
                byte[] data = Encoding.ASCII.GetBytes(GetPlayerId() + ": EndTurn");
                stream.Write(data, 0, data.Length);
                Log("Sent EndTurn command to host");
            }
        }


        private string GetPlayerProperties(int player)
        {
            int totalProperties = 0;
            string properties = "\r\n";
            for (int i = 0; i < this.properties.Length; i++)
            {
                if (this.properties[i] != null)
                {
                    if (this.properties[i].Owner == player)
                    {
                        totalProperties++;
                        // Get name of property
                        string name = this.properties[i].Name;
                        // Get the number of houses on the property
                        int houses = this.properties[i].Houses;
                        // if the property has a hotel set houses to 5
                        if (this.properties[i].Hotel)
                        {
                            houses = 5;
                        }
                        properties += name + " (" + houses + ")\r\n";
                    }
                }
            }
            string finnished = (totalProperties + properties);
            return finnished;
        }
        private List<int> GetCompleteProperties(int player)
        {
            List<int> ownedProperties = new List<int>();
            for (int i = 0; i < properties.Length; i++)
            {
                if (properties[i] != null && properties[i].Owner == player)
                {
                    ownedProperties.Add(i);
                }
            }

            Dictionary<string, int> colorGroupCounts = new Dictionary<string, int>
            {
                { "Pink", 0 }, { "Light Blue", 0 }, { "Purple", 0 },
                { "Orange", 0 }, { "Red", 0 }, { "Yellow", 0 },
                { "Green", 0 }, { "Dark Blue", 0 }
            };

            foreach (int index in ownedProperties)
            {
                colorGroupCounts[properties[index].ColorGroup]++;
            }

            List<int> completeGroups = new List<int>();

            foreach (var colorGroup in colorGroupCounts)
            {
                int requiredCount = colorGroup.Key == "Dark Blue" || colorGroup.Key == "Pink" ? 2 : 3;
                if (colorGroup.Value == requiredCount)
                {
                    completeGroups.AddRange(ownedProperties.Where(i => properties[i].ColorGroup == colorGroup.Key));
                }
            }

            return completeGroups;
        }


        // New upgrade function

        private void btnUpgrade_Click(object sender, EventArgs e)
        {
            int playerId = GetPlayerId();
            List<int> completeGroups = GetCompleteProperties(playerId);
            Log($"Player {playerId} complete color groups: " + string.Join(", ", completeGroups.Select(i => properties[i].Name)));
            if (completeGroups.Count > 0)
            {
                DialogResult result = MessageBox.Show("Do you want to buy houses for your complete color groups?", "Buy Houses", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    foreach (int propertyIndex in completeGroups)
                    {
                        BuyHouse(playerId, propertyIndex);
                    }
                }
            }
        }


        private void btnCreateGame_Click(object sender, EventArgs e)
        {
            Do("CreateGame");
            try
            {
                int port = int.Parse(txtServerPort.Text);
                TcpListener server = new TcpListener(System.Net.IPAddress.Any, port);
                server.Start();
                Log("Server started on port " + port);
                lblPlayer.Text = "Player: 0";
                btnRoll.Enabled = true;

                Thread acceptClientsThread = new Thread(() =>
                {
                    while (true)
                    {
                        TcpClient client = server.AcceptTcpClient();
                        clients.Add(client);
                        Log("Client connected");

                        // Assign a unique player ID
                        int playerId = clientCounter++;
                        SendPlayerIdToClient(client, playerId);

                        Thread clientThread = new Thread(() => ReceiveClientMessages(client));
                        clientThread.Start();
                    }
                });
                acceptClientsThread.Start();
            }
            catch (Exception ex)
            {
                Log("Error: " + ex.Message);
            }
        }
        private void ReceiveClientMessages(TcpClient client)
        {
            NetworkStream clientStream = client.GetStream();

            while (true)
            {
                try
                {
                    byte[] buffer = new byte[client.ReceiveBufferSize];
                    int bytesRead = clientStream.Read(buffer, 0, buffer.Length);
                    string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);

                    // Split messages by newline characters to handle multiple commands
                    string[] messages = message.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string msg in messages)
                    {
                        if (!string.IsNullOrEmpty(msg))
                        {
                            Log("Received message: " + msg);
                            if (message.Contains("Roll"))
                            {
                                Do(msg.Substring(2).Trim(), false);
                            }
                            else
                            {
                                Do(msg.Substring(2).Trim());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log("Error: " + ex.Message);
                    break;
                }
            }
        }
        private void SendPlayerIdToClient(TcpClient client, int playerId)
        {
            NetworkStream clientStream = client.GetStream();
            byte[] buffer = Encoding.ASCII.GetBytes("AssignPID: " + playerId + "\n");
            clientStream.Write(buffer, 0, buffer.Length);
            Log("Sent Player ID " + playerId + " to client");
        }
        private void Broadcast(string message)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(message + "\n");
            foreach (TcpClient client in clients)
            {
                NetworkStream clientStream = client.GetStream();
                clientStream.Write(buffer, 0, buffer.Length);
                // Log
                Log("Sent message to client: " + message);
            }
        }

        // Client
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                string ip = txtIp.Text;
                int port = int.Parse(txtPort.Text);
                client = new TcpClient(ip, port);
                stream = client.GetStream();
                Log("Connected to server at " + ip + ":" + port);
                lblPlayer.Text = "Player: 1";

                Thread thread = new Thread(Receive);
                thread.Start();
            }
            catch (Exception ex)
            {
                Log("Error: " + ex.Message);
            }
        }
        private void Receive()
        {
            // Receive messages from the server
            while (true)
            {
                try
                {
                    byte[] buffer = new byte[client.ReceiveBufferSize];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);

                    // Split messages by newline characters to handle multiple commands
                    string[] messages = message.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string msg in messages)
                    {
                        if (!string.IsNullOrEmpty(msg))
                        {
                            Log("Received message: " + msg);

                            if (msg.StartsWith("AssignPID:"))
                            {
                                int newPlayerId = int.Parse(msg.Substring(11).Trim());
                                lblPlayer.Text = "Player: " + newPlayerId;
                                Log("Assigned Player ID: " + newPlayerId);
                                continue;
                            }

                            int playerId = int.Parse(msg[0].ToString());
                            string msgContent = msg.Substring(2).Trim();

                            if (playerId == GetPlayerId())
                            {
                                Log("Got message from myself...");
                                continue;
                            }

                            Log("Player ID: " + playerId + " != " + GetPlayerId());
                            Log("Server: " + msgContent);
                            Do(msgContent.Trim());
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log("Error: " + ex.Message);
                    break;
                }
            }
        }

    }
    public class Property
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int[] RentStages { get; set; } = new int[6]; // Rents for [0 houses, 1 house, 2 houses, 3 houses, 4 houses, hotel]
        public bool IsOwned { get; set; }
        public int Owner { get; set; }
        public int Houses { get; set; } = 0;
        public bool Hotel { get; set; } = false;
        public string ColorGroup { get; set; }

        public int GetRent()
        {
            return Hotel ? RentStages[5] : RentStages[Houses];
        }
    }

}