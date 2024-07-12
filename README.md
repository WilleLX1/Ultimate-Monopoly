# Monopoly Game

A simple Monopoly game created in C#. This game allows up to 4 players to play Monopoly locally by rolling dice, moving around the board, buying properties, paying rent, and collecting money. The player with the most money at the end of the game wins.

## Features

- Play with up to 4 players
- Roll dice to move around the board
- Buy properties and build houses/hotels
- Pay rent and collect money
- Chance and Community Chest cards with various effects
- Free Parking with a pot collection
- Go to Jail and Get Out of Jail Free mechanics

## Installation

1. Clone the repository:
    ```sh
    git clone https://github.com/yourusername/monopoly-game.git
    ```

2. Open the project in Visual Studio.

3. Build the project to restore dependencies and compile the code.

## Usage

1. Run the application.
2. Click on the "Roll" button to roll the dice and move your player.
3. Follow the prompts to buy properties, pay rent, or draw cards.
4. Use the "Upgrade" buttons to buy houses or hotels for your properties.

## Game Mechanics

- **Rolling Dice**: Click the "Roll" button to roll two dice and move your player.
- **Buying Properties**: When you land on a property, you can choose to buy it if you have enough money.
- **Paying Rent**: If you land on a property owned by another player, you must pay rent based on the property's development.
- **Chance and Community Chest**: Draw cards that can have various effects like gaining or losing money, moving positions, or going to jail.
- **Free Parking**: Collect the pot of money accumulated from taxes and fines.
- **Jail**: Players can go to jail and must either roll a double to get out, use a Get Out of Jail Free card, or pay a fine after three turns.

## To Do
- **Important implementations**: Complete the implementation of all property-related actions (buying, renting, mortgaging).
- **Better UI**: Add images for all properties and cards. Also improve the overall design of the game so its more user-friendly.
- **Trading System**: Allow players to trade properties and money with each other by sending trade offers.
- **Force Bankruptcy**: Implement a system that forces players to declare bankruptcy if they can't pay their debts. (Also make user morgage properties to pay debts if needed)

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

Feel free to reach out if you have any questions or need further assistance! (Keep in mind that this is a work in progress)
