namespace Monopoly
{

    public partial class Form1 : Form
    {
        // Description: Monopoly game
        // This is a simple Monopoly game that I created for my final project in my C# class.
        // It is a simple game that allows the user to play Monopoly with up to 4 players.
        // The game is played by rolling dice and moving around the board. The player can buy properties, pay rent, and collect money.
        // The game is won by the player who has the most money at the end of the game.
        // The game is played by clicking on the dice to roll them and then moving the player around the board.

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
        private void InitializePlayers()
        {
            // Initialize the players (By creating new PictureBoxes)
            players[0] = new PictureBox();
            players[1] = new PictureBox();
            players[2] = new PictureBox();
            players[3] = new PictureBox();

            // Change color of the players
            players[0].BackColor = Color.Red;
            players[1].BackColor = Color.Blue;
            players[2].BackColor = Color.Green;
            players[3].BackColor = Color.Yellow;

            // Set the size of the PictureBoxes
            for (int i = 0; i < players.Length; i++)
            {
                players[i].Size = new Size(22, 22);
                players[i].Location = new Point(10 + (i * 40), 10); // Set initial location
                this.Controls.Add(players[i]); // Add PictureBox to the form
            }

            // Initialize the player money
            playerMoney[0] = 30000;
            playerMoney[1] = 30000;
            playerMoney[2] = 30000;
            playerMoney[3] = 30000;

            // Initialize the player position
            playerPosition[0] = 0;
            playerPosition[1] = 0;
            playerPosition[2] = 0;
            playerPosition[3] = 0;

            // Update player money
            lblMoney1.Text = "Money: $" + playerMoney[0];
            lblMoney2.Text = "Money: $" + playerMoney[1];
            lblMoney3.Text = "Money: $" + playerMoney[2];
            lblMoney4.Text = "Money: $" + playerMoney[3];

            // Update player position
            lblPos1.Text = "Position: " + playerPosition[0];
            lblPos2.Text = "Position: " + playerPosition[1];
            lblPos3.Text = "Position: " + playerPosition[2];
            lblPos4.Text = "Position: " + playerPosition[3];
        }

        private void GenerateBoard()
        {
            boardSpaces = new PictureBox[boardSize * 4 - 4]; // Adjusted the array size to account for the corner spaces
            int index = 0;

            // Top row (left to right)
            for (int i = 0; i < boardSize; i++)
            {
                boardSpaces[index] = CreateBoardSpace(i * boxSize, 0);
                index++;
            }

            // Right column (top to bottom)
            for (int i = 1; i < boardSize; i++)
            {
                boardSpaces[index] = CreateBoardSpace((boardSize - 1) * boxSize, i * boxSize);
                index++;
            }

            // Bottom row (right to left)
            for (int i = boardSize - 2; i >= 0; i--)
            {
                boardSpaces[index] = CreateBoardSpace(i * boxSize, (boardSize - 1) * boxSize);
                index++;
            }

            // Left column (bottom to top)
            for (int i = boardSize - 2; i > 0; i--)
            {
                boardSpaces[index] = CreateBoardSpace(0, i * boxSize);
                index++;
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
            properties = new Property[40]; // Adjusted array size to accommodate all properties

            properties[0] = null;
            properties[1] = new Property
            {
                Name = "Västerlång Gatan",
                Price = 1000,
                RentStages = new int[] { 50, 200, 600, 1700, 3000, 4750 },
                IsOwned = false,
                Owner = -1,
                ColorGroup = "Pink"
            };
            properties[2] = null;
            properties[3] = new Property
            {
                Name = "Hornsgatan",
                Price = 1000,
                RentStages = new int[] { 100, 400, 1100, 3400, 6000, 8550 },
                IsOwned = false,
                Owner = -1,
                ColorGroup = "Pink"
            };
            properties[4] = null;
            properties[5] = new Property
            {
                Name = "Södra Station",
                Price = 4000,
                RentStages = new int[] { 0, 0, 0, 0, 0, 0 },
                IsOwned = false,
                Owner = -1
            };
            properties[6] = new Property
            {
                Name = "Folkunga Gatan",
                Price = 2000,
                RentStages = new int[] { 100, 550, 1700, 5150, 7600, 9500 },
                IsOwned = false,
                Owner = -1,
                ColorGroup = "Light Blue"
            };
            properties[7] = null;
            properties[8] = new Property
            {
                Name = "Götagatan",
                Price = 2000,
                RentStages = new int[] { 100, 550, 1700, 5150, 7600, 9500 },
                IsOwned = false,
                Owner = -1,
                ColorGroup = "Light Blue"
            };
            properties[9] = new Property
            {
                Name = "Ringvägen",
                Price = 2200,
                RentStages = new int[] { 150, 750, 2000, 5750, 8500, 11500 },
                IsOwned = false,
                Owner = -1,
                ColorGroup = "Light Blue"
            };
            properties[10] = null;
            properties[11] = new Property
            {
                Name = "S:T Eriksgatan",
                Price = 2500,
                RentStages = new int[] { 200, 1000, 2000, 8500, 12000, 14250 },
                IsOwned = false,
                Owner = -1,
                ColorGroup = "Purple"
            };
            properties[12] = new Property
            {
                Name = "Elverket",
                Price = 3000,
                RentStages = new int[] { 0, 0, 0, 0, 0, 0 },
                IsOwned = false,
                Owner = -1,
            };
            properties[13] = new Property
            {
                Name = "Odengatan",
                Price = 2500,
                RentStages = new int[] { 200, 1000, 2800, 8500, 12000, 14250 },
                IsOwned = false,
                Owner = -1,
                ColorGroup = "Purple"
            };
            properties[14] = new Property
            {
                Name = "Valhallavägen",
                Price = 3000,
                RentStages = new int[] { 250, 1150, 3400, 9500, 13000, 17000 },
                IsOwned = false,
                Owner = -1,
                ColorGroup = "Purple"
            };
            properties[15] = new Property
            {
                Name = "Östra Station",
                Price = 3000,
                RentStages = new int[] { 0, 0, 0, 0, 0, 0 },
                IsOwned = false,
                Owner = -1,
            };
            properties[16] = new Property
            {
                Name = "Sturegatan",
                Price = 3500,
                RentStages = new int[] { 250, 1350, 3800, 10500, 14250, 18000 },
                IsOwned = false,
                Owner = -1,
                ColorGroup = "Orange"
            };
            properties[17] = null;
            properties[18] = new Property
            {
                Name = "Karlavägen",
                Price = 3500,
                RentStages = new int[] { 250, 1350, 3800, 10500, 14250, 18000 },
                IsOwned = false,
                Owner = -1,
                ColorGroup = "Orange"
            };
            properties[19] = new Property
            {
                Name = "Narvavägen",
                Price = 3800,
                RentStages = new int[] { 300, 1500, 4200, 11500, 15000, 19000 },
                IsOwned = false,
                Owner = -1,
                ColorGroup = "Orange"
            };
            properties[20] = null;
            properties[21] = new Property
            {
                Name = "Strandvägen",
                Price = 4200,
                RentStages = new int[] { 350, 1700, 4750, 13000, 16500, 20000 },
                IsOwned = false,
                Owner = -1,
                ColorGroup = "Red"
            };
            properties[22] = null;
            properties[23] = new Property
            {
                Name = "Kungsträdgårdsgatan",
                Price = 4200,
                RentStages = new int[] { 350, 1700, 4750, 13000, 16500, 20000 },
                IsOwned = false,
                Owner = -1,
                ColorGroup = "Red"
            };
            properties[24] = new Property
            {
                Name = "Hamngatan",
                Price = 4500,
                RentStages = new int[] { 400, 2000, 5750, 14000, 17500, 21000 },
                IsOwned = false,
                Owner = -1,
                ColorGroup = "Red"
            };
            properties[25] = new Property
            {
                Name = "Central Station",
                Price = 4000,
                RentStages = new int[] { 0, 0, 0, 0, 0, 0 },
                IsOwned = false,
                Owner = -1
            };
            properties[26] = new Property
            {
                Name = "Vasagatan",
                Price = 5000,
                RentStages = new int[] { 400, 2200, 6300, 15000, 18500, 22000 },
                IsOwned = false,
                Owner = -1,
                ColorGroup = "Yellow"
            };
            properties[27] = new Property
            {
                Name = "Kungsgatan",
                Price = 5000,
                RentStages = new int[] { 400, 2200, 6300, 15000, 18500, 22000 },
                IsOwned = false,
                Owner = -1,
                ColorGroup = "Yellow"
            };
            properties[28] = new Property
            {
                Name = "Vattenledningsverket",
                Price = 3000,
                RentStages = new int[] { 0, 0, 0, 0, 0, 0 },
                IsOwned = false,
                Owner = -1,
            };
            properties[29] = new Property
            {
                Name = "Stureplan",
                Price = 5300,
                RentStages = new int[] { 400, 2300, 6800, 16000, 19500, 23000 },
                IsOwned = false,
                Owner = -1,
                ColorGroup = "Yellow"
            };
            properties[30] = null;
            properties[31] = new Property
            {
                Name = "Gustav Adolfs Torg",
                Price = 6000,
                RentStages = new int[] { 500, 2500, 7500, 17000, 21000, 24200 },
                IsOwned = false,
                Owner = -1,
                ColorGroup = "Green"
            };
            properties[32] = new Property
            {
                Name = "Drottningatan",
                Price = 6000,
                RentStages = new int[] { 500, 2500, 7500, 17000, 21000, 24200 },
                IsOwned = false,
                Owner = -1,
                ColorGroup = "Green"
            };
            properties[33] = null;
            properties[34] = new Property
            {
                Name = "Diplomatstaden",
                Price = 6000,
                RentStages = new int[] { 550, 2850, 8500, 19000, 23000, 27000 },
                IsOwned = false,
                Owner = -1,
                ColorGroup = "Green"
            };
            properties[35] = new Property
            {
                Name = "Norra Station",
                Price = 6000,
                RentStages = new int[] { 0, 0, 0, 0, 0, 0 },
                IsOwned = false,
                Owner = -1
            };
            properties[36] = null;
            properties[37] = new Property
            {
                Name = "Centrum",
                Price = 6500,
                RentStages = new int[] { 650, 3300, 9500, 21000, 25000, 28500 },
                IsOwned = false,
                Owner = -1,
                ColorGroup = "Dark Blue"
            };
            properties[38] = null;
            properties[39] = new Property
            {
                Name = "Norrmalmstorg",
                Price = 8000,
                RentStages = new int[] { 1000, 4000, 12000, 26500, 32500, 40000 },
                IsOwned = false,
                Owner = -1,
                ColorGroup = "Dark Blue"
            };
        }


        // Roll the dice
        private int RollDice()
        {
            Random rnd = new Random();
            int dice1 = rnd.Next(1, 7);
            return dice1;
        }

        // Move the player
        private void MovePlayer(int player, int spaces)
        {
            // Get int of player current position
            int currentPos = playerPosition[player];

            // Update player position
            playerPosition[player] = (playerPosition[player] + spaces) % boardSpaces.Length;
            int newPos = playerPosition[player];

            // Move the player to the new position
            players[player].Location = new Point(boardSpaces[newPos].Location.X + (boxSize / 4), boardSpaces[newPos].Location.Y + (boxSize / 4));

            // Apply effects of landing on the space
            ApplySpaceEffects(player, newPos, currentPos);
        }

        // Function for moving the player to a specific space
        private void MovePlayerToSpace(int player, int space)
        {
            // Update player position
            playerPosition[player] = space;
            int newPos = playerPosition[player];

            // Move the player to the new position
            players[player].Location = new Point(boardSpaces[newPos].Location.X + (boxSize / 4), boardSpaces[newPos].Location.Y + (boxSize / 4));
        }


        // Apply effects of landing on the space
        private void ApplySpaceEffects(int player, int space, int oldSpace)
        {
            // Ensure the player index is valid
            if (player < 0 || player >= players.Length) return;

            // Check what space the player landed on
            if (space == 0)
            {
                if (oldSpace > 0)
                {
                    // Player passed Go
                    playerMoney[player] += 4000;
                    Log("Player " + player + " passed Go and collected $4000");
                }
            }
            else if (space == 10)
            {
                // Player landed on Jail
                Log("Player " + player + " visited Jail");
            }
            else if (space == 20)
            {
                // Player landed on Free Parking
                Log("Player " + player + " landed on Free Parking");
                // Player collects the Free Parking pot
                playerMoney[player] += currentFreeParkingPot;
                // Log
                Log("Player " + player + " collected $" + currentFreeParkingPot + " from Free Parking");
                currentFreeParkingPot = 0;
            }
            else if (space == 30)
            {
                // Player landed on Go to Jail
                Log("Player " + player + " landed on Go to Jail");
            }

            // Chance and Community Chest
            else if (space == 2 || space == 17 || space == 33)
            {
                // Allmänning
                DrawCommunityChestCard(player);
            }
            else if (space == 7 || space == 22 || space == 36)
            {
                // Chans
                DrawChanceCard(player);
            }

            // Utilities
            else if (space == 28 || space == 12)
            {
                // Vattenverk / Elverket
                if (IsPropertyOwned(space))
                {
                    int steps = space - oldSpace;
                    // Pay rent
                    PayRentUtilities(player, space, steps);
                }
                else
                {
                    // Buy property
                    BuyProperty(player, space, properties[space].Price);
                }
            }

            // Järnvägsstationer
            else if (space == 5 || space == 15 || space == 25 || space == 35)
            {
                // Järnvägsstation
                // Check if the property is owned
                if (IsPropertyOwned(space))
                {
                    // Pay rent
                    PayRentJärnväg(player, space);
                }
                else
                {
                    // Buy property
                    BuyProperty(player, space, properties[space].Price);
                }
            }

            // Skatter
            else if (space == 4)
            {
                // Inkomst skatt betala
                playerMoney[player] -= 4000;
                currentFreeParkingPot += 4000;
                // Log
                Log("Player " + player + " paid $4000 income tax");
            }
            else if (space == 38)
            {
                // Lyx skatt betala
                playerMoney[player] -= 2000;
                currentFreeParkingPot += 2000;
                // Log
                Log("Player " + player + " paid $2000 luxury tax");
            }

            // Properties
            else
            {
                // Player landed on a property
                Log("Player " + player + " landed on property " + space);
                // Check if the property is owned
                if (properties[space].IsOwned)
                {
                    PayRent(player, space);
                }
                else
                {
                    // Offer to buy property
                    int price = properties[space].Price;
                    if (playerMoney[player] >= price)
                    {
                        // Ask player if they want to buy the property
                        DialogResult result = MessageBox.Show("Do you want to buy property " + space + " for $" + price + "?", "Buy Property", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            playerMoney[player] -= price;
                            properties[space].IsOwned = true;
                            properties[space].Owner = player;
                            Log("Player " + player + " bought property " + space + " for $" + price);
                        }
                        else
                        {
                            Log("Player " + player + " declined to buy property " + space);
                        }
                    }
                    else
                    {
                        Log("Player " + player + " does not have enough money to buy property " + space);
                    }
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
            // Get the owner of the property
            int owner = properties[property].Owner;
            // Get the rent amount
            int rent = 0;
            // Check how many Järnväg stations the owner has
            int järnvägCount = 0;
            for (int i = 0; i < properties.Length; i++)
            {
                if (properties[i] != null)
                {
                    if (properties[i].Owner == owner)
                    {
                        if (i == 5 || i == 15 || i == 25 || i == 35)
                        {
                            järnvägCount++;
                        }
                    }
                }
            }
            // Calculate rent
            if (järnvägCount == 1)
            {
                rent = 500;
            }
            else if (järnvägCount == 2)
            {
                rent = 1000;
            }
            else if (järnvägCount == 3)
            {
                rent = 2000;
            }
            else if (järnvägCount == 4)
            {
                rent = 4000;
            }
            // Pay the rent
            if (playerMoney[player] - rent < 0)
            {
                // Player does not have enough money to pay rent
                Log("Player " + player + " does not have enough money to pay rent to Player " + owner);
                return;
            }
            playerMoney[player] -= rent;
            playerMoney[owner] += rent;
            Log("Player " + player + " paid $" + rent + " rent to Player " + owner);
        }

        // Function to pay rent for Utilities
        private void PayRentUtilities(int player, int property, int steps)
        {
            // Get the owner of the property
            int owner = properties[property].Owner;
            // Get the rent amount
            int rent = 0;
            int rentPerStep = 0;
            // Check how many Utilities the owner has
            int utilityCount = 0;
            for (int i = 0; i < properties.Length; i++)
            {
                if (properties[i] != null)
                {
                    if (properties[i].Owner == owner)
                    {
                        // Check if the property is a Utility
                        if (i == 12 || i == 28)
                        {
                            utilityCount++;
                        }
                    }
                }
            }
            // Calculate rent
            if (utilityCount == 1)
            {
                rentPerStep = 100;
            }
            else if (utilityCount == 2)
            {
                rentPerStep = 200;
            }
            // Calculate rent
            rent = rentPerStep * steps;
            // Pay the rent
            if (playerMoney[player] - rent < 0)
            {
                // Player does not have enough money to pay rent
                Log("Player " + player + " does not have enough money to pay rent to Player " + owner);
                return;
            }
            playerMoney[player] -= rent;
            playerMoney[owner] += rent;
            Log("Player " + player + " paid $" + rent + " rent to Player " + owner + " (" + rentPerStep + " * " + steps + ")");
        }


        // Function to buy property
        private void BuyProperty(int player, int property, int price)
        {
            // Get property name
            string propertyName = properties[property].Name;
            // Check if the player has enough money
            if (playerMoney[player] >= price)
            {
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

            if (property == null)
            {
                Log("Property at index " + propertyIndex + " does not exist.");
                return;
            }

            if (property.Owner != player || property.Hotel || property.Houses > 4)
            {
                Log("Cannot buy more houses or hotels for this property.");
                return;
            }

            if (property.Houses == 4)
            {
                // Buy a hotel
                BuyHotel(player, propertyIndex);
                return;
            }
            
            int houseCost = property.Price / 2; // Example house cost, adjust as needed
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
            if (property.Owner != player || property.Hotel || property.Houses < 4)
            {
                Log("Cannot buy a hotel for this property.");
                return;
            }

            int hotelCost = property.Price; // Example hotel cost, adjust as needed
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
        private void DrawChanceCard(int player)
        {
            // Draw a random Chance Card
            Random rnd = new Random();
            int card = rnd.Next(1, 17);
            // Check which card was drawn
            if (card == 1)
            {
                // Ta en tripp till Östra Station (Få $4000 om passerar "Gå")
                if (playerPosition[player] >= 15)
                {
                    playerMoney[player] += 4000;
                }
                playerPosition[player] = 15;
                // Log
                Log("Player " + player + " drew a Chance Card and went to Östra Station");
            }
            else if (card == 2)
            {
                // Betala ersättning för Gatuunderhåll (Betala $800 per hus, $2300 per hotell)

            }
            else if (card == 3)
            {
                // Betala böter för fortkörning (Betala $300)
                if (playerMoney[player] < 300)
                {
                    // Player does not have enough money to pay the speeding ticket
                    Log("Player " + player + " does not have enough money to pay the speeding ticket");
                    return;
                }
                playerMoney[player] -= 300;
                // Log
                Log("Player " + player + " drew a Chance Card and paid $300");
            }
            else if (card == 4)
            {
                // Gå till fängelse!
                MovePlayerToSpace(player, 30);
                // Log
                Log("Player " + player + " drew a Chance Card and went to Jail");
            }
            else if (card == 5)
            {
                // Utbetalning på ert nybyggnadslån (Få $3000)
                playerMoney[player] += 3000;
                // Log
                Log("Player " + player + " drew a Chance Card and received $3000");
            }
            else if (card == 6)
            {
                // Gå vidare till S:T Eriksgatan (Få $4000 om passerar "Gå")
                if (playerPosition[player] >= 11)
                {
                    playerMoney[player] += 4000;
                }
                MovePlayerToSpace(player, 11);
                // Log
                Log("Player " + player + " drew a Chance Card and went to S:T Eriksgatan");
            }
            else if (card == 7)
            {
                // Ni har vunnit en korsords tävling (Få $2000)
                playerMoney[player] += 2000;
                // Log
                Log("Player " + player + " drew a Chance Card and received $2000");
            }
            else if (card == 8)
            {
                // Alla era fastigheter måste repareras (Betala $500 per hus, $2000 per hotell)

            }
            else if (card == 9)
            {
                // Betala skolavgift (Betala $3000)
                if (playerMoney[player] < 3000)
                {
                    // Player does not have enough money to pay the school fee
                    Log("Player " + player + " does not have enough money to pay the school fee");
                    return;
                }
                playerMoney[player] -= 3000;
                // Log
                Log("Player " + player + " drew a Chance Card and paid $3000");
            }
            else if (card == 10)
            {
                // Ni lyfter sparkasseränta från banken (Få $1000)
                playerMoney[player] += 1000;
                // Log
                Log("Player " + player + " drew a Chance Card and received $1000");
            }
            else if (card == 11)
            {
                // Ni slipper ut ur fängelset (Få ett Get Out of Jail Free kort)
            }
            else if (card == 12)
            {
                // Gå vidare till Hamngatan (Få $4000 om passerar "Gå")
                if (playerPosition[player] >= 24)
                {
                    playerMoney[player] += 4000;
                }
                playerPosition[player] = 24;
                // Log
                Log("Player " + player + " drew a Chance Card and went to Hamngatan");
            }
            else if (card == 13)
            {
                // Oförstånd i ämbeter (Betala $400)
                if (playerMoney[player] < 400)
                {
                    // Player does not have enough money to pay the fine
                    Log("Player " + player + " does not have enough money to pay the fine");
                    return;
                }
                playerMoney[player] -= 400;
                // Log
                Log("Player " + player + " drew a Chance Card and paid $400");
            }
            else if (card == 14)
            {
                // Gå tre steg tillbaka
                MovePlayerToSpace(player, playerPosition[player] - 3);
                // Log
                Log("Player " + player + " drew a Chance Card and went back 3 spaces");
            }
            else if (card == 15)
            {
                // Gå vidare till "Gå"
                MovePlayerToSpace(player, 0);
                // Log
                Log("Player " + player + " drew a Chance Card and went to Go");
            }
            else if (card == 16)
            {
                // Gå vidare till Norrmalmstorg
                MovePlayerToSpace(player, 39);
                // Log
                Log("Player " + player + " drew a Chance Card and went to Norrmalmstorg");
            }
        }

        // Function to draw a Community Chest Card
        private void DrawCommunityChestCard(int player)
        {
            // Draw a random Community Chest Card
            Random rnd = new Random();
            int card = rnd.Next(1, 17);
            // Check which card was drawn
            if (card == 1)
            {
                // Felräkning i din favör (Få $4000)
                playerMoney[player] += 4000;
                // Log
                Log("Player " + player + " drew a Community Chest Card and received $4000");
            }
            else if (card == 2)
            {
                // Utdelning på 7% preferensaktier (Få $500)
                playerMoney[player] += 500;
                // Log
                Log("Player " + player + " drew a Community Chest Card and received $500");
            }
            else if (card == 3)
            {
                // Återbäring av skatt (Få $400)
                playerMoney[player] += 400;
                // Log
                Log("Player " + player + " drew a Community Chest Card and received $400");
            }
            else if (card == 4)
            {
                // Livförsäkring förfaller (Få $2000)
                playerMoney[player] += 2000;
                // Log
                Log("Player " + player + " drew a Community Chest Card and received $2000");
            }
            else if (card == 5)
            {
                // Det är er födelsedag (Få $200 från varje spelare)
                for (int i = 0; i < players.Length; i++)
                {
                    if (i != player)
                    {
                        if (playerMoney[i] < 200)
                        {
                            playerMoney[player] += playerMoney[i];
                            playerMoney[i] = 0;
                            // Log
                            Log("Player " + player + " drew a Community Chest Card and received $" + playerMoney[i] + " from Player " + i);
                        }
                        else
                        {
                            playerMoney[i] -= 200;
                            playerMoney[player] += 200;
                            // Log
                            Log("Player " + player + " drew a Community Chest Card and received $200 from Player " + i);
                        }
                    }
                }
            }
            else if (card == 6)
            {
                // Betala sjukhusräkning (Betala $2000)
                if (playerMoney[player] < 2000)
                {
                    // Player does not have enough money to pay the hospital bill
                    Log("Player " + player + " does not have enough money to pay the hospital bill");
                    return;
                }
                playerMoney[player] -= 2000;
                // Log
                Log("Player " + player + " drew a Community Chest Card and paid $2000");
            }
            else if (card == 7)
            {
                // Likvid för försålda aktier (Få $1000)
                playerMoney[player] += 1000;
                // Log
                Log("Player " + player + " drew a Community Chest Card and received $1000");
            }
            else if (card == 8)
            {
                // Gå tillbaka till Västerlånggatan
                MovePlayerToSpace(player, 1);
                // Log
                Log("Player " + player + " drew a Community Chest Card and went back to Västerlånggatan");
            }
            else if (card == 9)
            {
                // Betala en försäkringspremie (Betala $1000)
                if (playerMoney[player] < 1000)
                {
                    // Player does not have enough money to pay the insurance premium
                    Log("Player " + player + " does not have enough money to pay the insurance premium");
                    return;
                }
                playerMoney[player] -= 1000;
                // Log
                Log("Player " + player + " drew a Community Chest Card and paid $1000");
            }
            else if (card == 10)
            {
                // Betala böter eller ta ett chanskort (Betala $200)
                if (playerMoney[player] < 200)
                {
                    // Player does not have enough money to pay the fine
                    Log("Player " + player + " does not have enough money to pay the fine");
                    return;
                }
                playerMoney[player] -= 200;
                // Log
                Log("Player " + player + " drew a Community Chest Card and paid $200");
            }
            else if (card == 11)
            {
                // Ni ärver (Få $2000)
                playerMoney[player] += 2000;
                // Log
                Log("Player " + player + " drew a Community Chest Card and received $2000");
            }
            else if (card == 12)
            {
                // Ni slipper ut ur fängelset (Få ett Get Out of Jail Free kort)

            }
            else if (card == 13)
            {
                // Läkararvode (Betala $1000)
                if (playerMoney[player] < 1000)
                {
                    // Player does not have enough money to pay the doctor's fee
                    Log("Player " + player + " does not have enough money to pay the doctor's fee");
                    return;
                }
                playerMoney[player] -= 1000;
                // Log
                Log("Player " + player + " drew a Community Chest Card and paid $1000");
            }
            else if (card == 14)
            {
                // Gå vidare till "Gå"
                MovePlayerToSpace(player, 0);
                // Log
                Log("Player " + player + " drew a Community Chest Card and went to Go");
            }
            else if (card == 15)
            {
                // Gå direkt till fängelset
                MovePlayerToSpace(player, 10);
                // Log
                Log("Player " + player + " drew a Community Chest Card and went to Jail");
            }
            else if (card == 16)
            {
                // Ni har vunnit andra pris i skönhetstävlingen (Få $200)
                playerMoney[player] += 200;
                // Log
                Log("Player " + player + " drew a Community Chest Card and received $200");
            }

        }


        private void btnRoll_Click(object sender, EventArgs e)
        {
            // Roll the dice
            int dice1 = RollDice();
            int dice2 = RollDice();


            // Calculate total dice roll
            int dice = dice1 + dice2;

            // Move the player
            MovePlayer(currentPlayer, dice);

            // If player rolls dubbles player can roll again 
            if (dice1 == dice2)
            {
                // Player rolled a double
                Log("Player " + (currentPlayer + 1) + " rolled a double (" + dice1 + ", " + dice2 + ")");
                // Player can roll again
                return;
            }

            // Switch to next player
            currentPlayer = (currentPlayer + 1) % players.Length;

            // Update player money
            lblMoney1.Text = "Money: $" + playerMoney[0];
            lblMoney2.Text = "Money: $" + playerMoney[1];
            lblMoney3.Text = "Money: $" + playerMoney[2];
            lblMoney4.Text = "Money: $" + playerMoney[3];

            // Update player position
            lblPos1.Text = "Position: " + playerPosition[0];
            lblPos2.Text = "Position: " + playerPosition[1];
            lblPos3.Text = "Position: " + playerPosition[2];
            lblPos4.Text = "Position: " + playerPosition[3];

            // Update player owned properties
            lblOwned1.Text = "Properties: " + GetPlayerProperties(0);
            lblOwned2.Text = "Properties: " + GetPlayerProperties(1);
            lblOwned3.Text = "Properties: " + GetPlayerProperties(2);
            lblOwned4.Text = "Properties: " + GetPlayerProperties(3);
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
            // Find all properties owned by player
            List<int> ownedProperties = new List<int>();
            for (int i = 0; i < properties.Length; i++)
            {
                if (properties[i] != null && properties[i].Owner == player)
                {
                    ownedProperties.Add(i);
                }
            }

            // Find all properties that is complete (like 3 properties in the same color group)
            List<int> completeGroups = new List<int>();
            int pinkCount = 0;
            int lightBlueCount = 0;
            int purpleCount = 0;
            int orangeCount = 0;
            int redCount = 0;
            int yellowCount = 0;
            int greenCount = 0;
            int darkBlueCount = 0;

            bool pinkComplete = false;
            bool lightBlueComplete = false;
            bool purpleComplete = false;
            bool orangeComplete = false;
            bool redComplete = false;
            bool yellowComplete = false;
            bool greenComplete = false;
            bool darkBlueComplete = false;

            for (int i = 0; i < ownedProperties.Count; i++)
            {
                if (properties[ownedProperties[i]].ColorGroup == "Pink")
                {
                    pinkCount++;
                }
                else if (properties[ownedProperties[i]].ColorGroup == "Light Blue")
                {
                    lightBlueCount++;
                }
                else if (properties[ownedProperties[i]].ColorGroup == "Purple")
                {
                    purpleCount++;
                }
                else if (properties[ownedProperties[i]].ColorGroup == "Orange")
                {
                    orangeCount++;
                }
                else if (properties[ownedProperties[i]].ColorGroup == "Red")
                {
                    redCount++;
                }
                else if (properties[ownedProperties[i]].ColorGroup == "Yellow")
                {
                    yellowCount++;
                }
                else if (properties[ownedProperties[i]].ColorGroup == "Green")
                {
                    greenCount++;
                }
                else if (properties[ownedProperties[i]].ColorGroup == "Dark Blue")
                {
                    darkBlueCount++;
                }
            }

            // Check if player has a complete color group
            if (pinkCount == 2)
            {
                pinkComplete = true;
            }
            else if (lightBlueCount == 3)
            {
                lightBlueComplete = true;
            }
            else if (purpleCount == 3)
            {
                purpleComplete = true;
            }
            else if (orangeCount == 3)
            {
                orangeComplete = true;
            }
            else if (redCount == 3)
            {
                redComplete = true;
            }
            else if (yellowCount == 3)
            {
                yellowComplete = true;
            }
            else if (greenCount == 3)
            {
                greenComplete = true;
            }
            else if (darkBlueCount == 2)
            {
                darkBlueComplete = true;
            }

            // If player has a complete color group, add all properties in that group to the complete groups list
            if (pinkComplete)
            {
                foreach (int index in ownedProperties)
                {
                    if (properties[index].ColorGroup == "Pink")
                    {
                        completeGroups.Add(index);
                    }
                }
            }
            if (lightBlueComplete)
            {
                foreach (int index in ownedProperties)
                {
                    if (properties[index].ColorGroup == "Light Blue")
                    {
                        completeGroups.Add(index);
                    }
                }
            }
            if (purpleComplete)
            {
                foreach (int index in ownedProperties)
                {
                    if (properties[index].ColorGroup == "Purple")
                    {
                        completeGroups.Add(index);
                    }
                }
            }
            if (orangeComplete)
            {
                foreach (int index in ownedProperties)
                {
                    if (properties[index].ColorGroup == "Orange")
                    {
                        completeGroups.Add(index);
                    }
                }
            }
            if (redComplete)
            {
                foreach (int index in ownedProperties)
                {
                    if (properties[index].ColorGroup == "Red")
                    {
                        completeGroups.Add(index);
                    }
                }
            }
            if (yellowComplete)
            {
                foreach (int index in ownedProperties)
                {
                    if (properties[index].ColorGroup == "Yellow")
                    {
                        completeGroups.Add(index);
                    }
                }
            }
            if (greenComplete)
            {
                foreach (int index in ownedProperties)
                {
                    if (properties[index].ColorGroup == "Green")
                    {
                        completeGroups.Add(index);
                    }
                }
            }
            if (darkBlueComplete)
            {
                foreach (int index in ownedProperties)
                {
                    if (properties[index].ColorGroup == "Dark Blue")
                    {
                        completeGroups.Add(index);
                    }
                }
            }

            return completeGroups;
        }

        private void btnUpgrade1_Click(object sender, EventArgs e)
        {
            List<int> completeGroups = GetCompleteProperties(0);

            // Log complete groups
            Log("Player 0 complete color groups: " + string.Join(", ", completeGroups.Select(i => properties[i].Name)));

            // If player has a complete color group, offer to buy houses
            if (completeGroups.Count > 0)
            {
                // Offer to buy houses
                DialogResult result = MessageBox.Show("Do you want to buy houses for your complete color groups?", "Buy Houses", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    foreach (int propertyIndex in completeGroups)
                    {
                        BuyHouse(0, propertyIndex);
                    }
                }
            }
        }

        private void btnUpgrade2_Click(object sender, EventArgs e)
        {
            List<int> completeGroups = GetCompleteProperties(1);

            // Log complete groups
            Log("Player 1 complete color groups: " + string.Join(", ", completeGroups.Select(i => properties[i].Name)));

            // If player has a complete color group, offer to buy houses
            if (completeGroups.Count > 0)
            {
                // Offer to buy houses
                DialogResult result = MessageBox.Show("Do you want to buy houses for your complete color groups?", "Buy Houses", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    foreach (int propertyIndex in completeGroups)
                    {
                        BuyHouse(1, propertyIndex);
                    }
                }
            }
        }

        private void btnUpgrade3_Click(object sender, EventArgs e)
        {
            List<int> completeGroups = GetCompleteProperties(2);

            // Log complete groups
            Log("Player 2 complete color groups: " + string.Join(", ", completeGroups.Select(i => properties[i].Name)));

            // If player has a complete color group, offer to buy houses
            if (completeGroups.Count > 0)
            {
                // Offer to buy houses
                DialogResult result = MessageBox.Show("Do you want to buy houses for your complete color groups?", "Buy Houses", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    foreach (int propertyIndex in completeGroups)
                    {
                        BuyHouse(2, propertyIndex);
                    }
                }
            }
        }

        private void btnUpgrade4_Click(object sender, EventArgs e)
        {
            List<int> completeGroups = GetCompleteProperties(3);

            // Log complete groups
            Log("Player 3 complete color groups: " + string.Join(", ", completeGroups.Select(i => properties[i].Name)));

            // If player has a complete color group, offer to buy houses
            if (completeGroups.Count > 0)
            {
                // Offer to buy houses
                DialogResult result = MessageBox.Show("Do you want to buy houses for your complete color groups?", "Buy Houses", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    foreach (int propertyIndex in completeGroups)
                    {
                        BuyHouse(3, propertyIndex);
                    }
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
            if (Hotel)
                return RentStages[5];
            else
                return RentStages[Houses];
        }
    }

}