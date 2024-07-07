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
        Property[] properties = new Property[20];
        int currentFreeParkingPot = 0;

        public Form1()
        {
            InitializeComponent();
            InitializePlayers();
            GenerateBoard();
            IntizalizeProperties();
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
                players[i].Size = new Size(30, 30);
                players[i].Location = new Point(10 + (i * 40), 10); // Set initial location
                this.Controls.Add(players[i]); // Add PictureBox to the form
            }

            // Initialize the player money
            playerMoney[0] = 1500;
            playerMoney[1] = 1500;
            playerMoney[2] = 1500;
            playerMoney[3] = 1500;

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
            boardSpaces = new PictureBox[(boardSize - 1) * 4];
            int index = 0;

            // Top row (left to right)
            for (int i = 0; i < boardSize - 1; i++)
            {
                boardSpaces[index] = CreateBoardSpace(i * boxSize, 0);
                index++;
            }

            // Right column (top to bottom)
            for (int i = 0; i < boardSize - 1; i++)
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
            for (int i = boardSize - 2; i >= 0; i--)
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
        private void IntizalizeProperties()
        {
            // Create properties
            Property property1 = new Property
            {
                Name = "Västerlång Gatan",
                Price = 1000,
                Rent = 10,
                IsOwned = false,
                Owner = -1
            };
            Property property3 = new Property
            {
                Name = "Hornsgatan",
                Price = 1000,
                Rent = 20,
                IsOwned = false,
                Owner = -1
            };
            Property property5 = new Property
            {
                Name = "Södra Station",
                Price = 4000,
                Rent = 30,
                IsOwned = false,
                Owner = -1
            };
            Property property6 = new Property
            {
                Name = "Folkunga Gatan",
                Price = 2000,
                Rent = 40,
                IsOwned = false,
                Owner = -1
            };
            Property property8 = new Property
            {
                Name = "Götagatan",
                Price = 2000,
                Rent = 50,
                IsOwned = false,
                Owner = -1
            };
            Property property9 = new Property
            {
                Name = "Ringvägen",
                Price = 2200,
                Rent = 60,
                IsOwned = false,
                Owner = -1
            };
            Property property11 = new Property
            {
                Name = "S:T Eriksgatan",
                Price = 2500,
                Rent = 70,
                IsOwned = false,
                Owner = -1
            };
            Property property13 = new Property
            {
                Name = "Odengatan",
                Price = 2500,
                Rent = 80,
                IsOwned = false,
                Owner = -1
            };
            Property property14 = new Property
            {
                Name = "Valhallavägen",
                Price = 3000,
                Rent = 90,
                IsOwned = false,
                Owner = -1
            };
            Property property15 = new Property
            {
                Name = "Östra Station",
                Price = 3000,
                Rent = 90,
                IsOwned = false,
                Owner = -1
            };
            Property property16 = new Property
            {
                Name = "Sturegatan",
                Price = 3500,
                Rent = 100,
                IsOwned = false,
                Owner = -1
            };
            Property property18 = new Property
            {
                Name = "Karlavägen",
                Price = 3500,
                Rent = 110,
                IsOwned = false,
                Owner = -1
            };
            Property property19 = new Property
            {
                Name = "Narvavägen",
                Price = 3800,
                Rent = 120,
                IsOwned = false,
                Owner = -1
            };
            Property property21 = new Property
            {
                Name = "Strandvägen",
                Price = 4200,
                Rent = 130,
                IsOwned = false,
                Owner = -1
            };
            Property property23 = new Property
            {
                Name = "Kungsträdgårdsgatan",
                Price = 4200,
                Rent = 140,
                IsOwned = false,
                Owner = -1
            };
            Property property24 = new Property
            {
                Name = "Hamngatan",
                Price = 4500,
                Rent = 150,
                IsOwned = false,
                Owner = -1
            };
            Property property25 = new Property
            {
                Name = "Central Station",
                Price = 4000,
                Rent = 160,
                IsOwned = false,
                Owner = -1
            };
            Property property26 = new Property
            {
                Name = "Vasagatan",
                Price = 5000,
                Rent = 160,
                IsOwned = false,
                Owner = -1
            };
            Property property27 = new Property
            {
                Name = "Kungsgatan",
                Price = 5000,
                Rent = 170,
                IsOwned = false,
                Owner = -1
            };
            Property property29 = new Property
            {
                Name = "Stureplan",
                Price = 5300,
                Rent = 180,
                IsOwned = false,
                Owner = -1
            };
            Property property31 = new Property
            {
                Name = "Gustav Adolfs Torg",
                Price = 6000,
                Rent = 190,
                IsOwned = false,
                Owner = -1
            };
            Property property32 = new Property
            {
                Name = "Drottningatan",
                Price = 6000,
                Rent = 200,
                IsOwned = false,
                Owner = -1
            };
            Property property34 = new Property
            {
                Name = "Diplomatstaden",
                Price = 6000,
                Rent = 210,
                IsOwned = false,
                Owner = -1
            };
            Property property35 = new Property
            {
                Name = "Norra Station",
                Price = 6000,
                Rent = 210,
                IsOwned = false,
                Owner = -1
            };
            Property property37 = new Property
            {
                Name = "Centrum",
                Price = 6500,
                Rent = 220,
                IsOwned = false,
                Owner = -1
            };
            Property property39 = new Property
            {
                Name = "Norrmalmstorg",
                Price = 8000,
                Rent = 230,
                IsOwned = false,
                Owner = -1
            };

            // Add properties to the array
            properties[0] = property1;
            properties[1] = property3;
            properties[2] = property5;
            properties[3] = property6;
            properties[4] = property8;
            properties[5] = property9;
            properties[6] = property11;
            properties[7] = property13;
            properties[8] = property14;
            properties[9] = property15;
            properties[10] = property16;
            properties[11] = property18;
            properties[12] = property19;
            properties[13] = property21;
            properties[14] = property23;
            properties[15] = property24;
            properties[16] = property25;
            properties[17] = property26;
            properties[18] = property27;
            properties[19] = property29;
            properties[20] = property31;
            properties[21] = property32;
            properties[22] = property34;
            properties[23] = property35;
            properties[24] = property37;
            properties[25] = property39;
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
            // Update player position
            playerPosition[player] = (playerPosition[player] + spaces) % boardSpaces.Length;
            int newPos = playerPosition[player];

            // Move the player to the new position
            players[player].Location = new Point(boardSpaces[newPos].Location.X + (boxSize / 4), boardSpaces[newPos].Location.Y + (boxSize / 4));
        
            // Apply effects of landing on the space
            ApplySpaceEffects(player, newPos);
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
        private void ApplySpaceEffects(int player, int space)
        {
            // Check what space the player landed on
            if (space == 0)
            {
                // Player landed on Go
                playerMoney[player] += 4000;
                Log("Player " + player + " landed on Go and collected $2000");
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
            else if (space == 2)
            {
                // Allmänning
                DrawCommunityChestCard(player);
            }
            else if (space == 7)
            {
                // Chans
                DrawChanceCard(player);
            }
            else if (space == 17)
            {
                // Allmänning
                DrawCommunityChestCard(player);
            }
            else if (space == 22)
            {
                // Chans
                DrawChanceCard(player);
            }
            else if (space == 33)
            {
                // Allmänning
                DrawCommunityChestCard(player);
            }
            
            // Utilities
            else if (space == 28)
            {
                // Vattenverk
            }
            else if (space == 12)
            {
                // Elektricitetsverk
            }

            // Järnvägsstationer
            else if (space == 5)
            {
                // Järnvägsstation
            }
            else if (space == 15)
            {
                // Järnvägsstation
            }
            else if (space == 25)
            {
                // Järnvägsstation
            }
            else if (space == 35)
            {
                // Järnvägsstation
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
                if (IsPropertyOwned(space))
                {
                    // Pay rent
                    PayRent(player, space);
                }
                else
                {
                    // Buy property
                    BuyProperty(player, space, properties[space].Price);
                }
            }
        }

        // Function to pay rent
        private void PayRent(int player, int property)
        {
            // Get the owner of the property
            int owner = properties[property].Owner;
            // Get the rent amount
            int rent = properties[property].Rent;
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

        // Function to buy property
        private void BuyProperty(int player, int property, int price)
        {
            // Check if the player has enough money
            if (playerMoney[player] >= price)
            {
                // Ask player if they want to buy the property
                DialogResult result = MessageBox.Show("Do you want to buy property " + property + " for $" + price + "?", "Buy Property", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    // Player bought the property
                    playerMoney[player] -= price;
                    // Set property as owned
                    properties[property].IsOwned = true;
                    properties[property].Owner = player;
                    Log("Player " + player + " bought property " + property + " for $" + price);
                }
            }
            else
            {
                Log("Player " + player + " does not have enough money to buy property " + property);
            }
        }

        // Function to see if property is owned
        private bool IsPropertyOwned(int property)
        {
            return properties[property].IsOwned;
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
                Log("Player " + currentPlayer + " rolled a double (" + dice1 + ", " + dice2 + ")");
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
        }
    }
    public class Property
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Rent { get; set; }
        public bool IsOwned { get; set; }
        public int Owner { get; set; }
    }
}