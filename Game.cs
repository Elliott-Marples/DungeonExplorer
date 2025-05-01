using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Media;
using System.Runtime.InteropServices;

namespace DungeonExplorer
{
    internal class Game
    {
        // Private properties
        private readonly Player player;

        public Game()
        {
            // Loops until the player has a name
            while (player == null || player.Name == null)
            {
                // Asks user for their name and sets player's health
                Console.Write("Enter your name:\n> ");
                string playerName = Console.ReadLine();
                int playerHealth = 100;
                int playerAttack = 10;
                Room startRoom = Rooms.entrance;

                // Creates a new player with the name and health
                player = new Player(playerName, playerHealth, playerAttack, startRoom);
            }

            Testing.AssertPlayerHasName(player);

            // Welcomes the player
            Console.WriteLine($"\nWelcome to the Dungeon, {player.Name}.\nPress any key to start.");
            Console.ReadKey();
        }

        public void Start()
        {
            // Starts the main game loop
            bool playing = true;
            while (playing)
            {
                string action;
                string chosenDirection;
                char chosenDirectionChar;
                bool notMoved = true;
                bool exploredRoom = false;

                //Testing.ChangeRoom(player, Rooms.room2right);
                Testing.PrintPlayersCurrentRoom(player);

                // Clears the console and displays the player's options
                Console.Clear();
                Console.WriteLine("Enter:\n[E] to explore the room\n[S] to view your stats\n[I] to view your inventory\n[P] to pick up any items\n[U] to use/equip an item\n[A] to attack a monster\n[M] to move to another room");

                // If the room has been visited before, an appropriate message is displayed
                if (player.CurrentRoom.Visited)
                {
                    Console.WriteLine("\nYou feel you have been here before.");
                }

                if (player.CurrentRoom.Monster != null)
                {
                    Console.WriteLine("\nYou feel you are not alone.");
                }

                Testing.PrintPlayersCurrentRoom(player);

                // Loops while the player has not moved between rooms
                while (notMoved)
                {

                    // Allows player to input their action
                    Console.Write("> ");
                    action = Console.ReadLine().ToLower();
                    Console.WriteLine();

                    // Checks the player's input and performs the appropriate action
                    // If the player explores the room, the room's description is displayed and exploredRoom is set to true
                    if (action == "e")
                    {
                        Console.WriteLine($"You see {player.CurrentRoom.GetDescription()}");
                        exploredRoom = true;
                    }

                    // If the player views their stats, their name and health are displayed
                    else if (action == "s")
                    {
                        player.DisplayStats();
                    }

                    // If the player views their inventory, their inventory contents and equipped item are displayed
                    else if (action == "i")
                    {
                        Console.WriteLine(player.GetInventoryString());
                    }

                    // If the player picks up an item, the item is added to their inventory and removed from the room
                    else if (action == "p")
                    {
                        // Checks if the player has explored the room
                        if (exploredRoom == false)
                        {
                            Console.WriteLine("You must explore the room to check for items first.");
                        }

                        // Checks if the room has an item
                        else if (player.CurrentRoom.Item == null)
                        {
                            Console.WriteLine("There are no items in this room.");
                        }

                        else
                        {
                            Testing.AssertRoomHasItem(player.CurrentRoom);

                            // Prints an appropriate message depending on the item in the room
                            if (player.CurrentRoom.Item == Items.sabre)
                            {
                                Console.WriteLine("You open the treasure chest and find a Sabre.");
                            }

                            else if (player.CurrentRoom.Item == Items.potion)
                            {
                                Console.WriteLine("You pick up one of the bottles.");
                            }

                            // If the player picks up the stone, the metal gate opens, the room's description is updated and the room to the south becomes accessible
                            else if (player.CurrentRoom.Item == Items.stone)
                            {
                                Console.WriteLine("You pick up the stone.");
                                Console.WriteLine("You watch the metal gate open, allowing you to traverse through it.");
                                GameMap.roomMatrix[player.CurrentRoomIndex[0] + 1, player.CurrentRoomIndex[1]].IsAccessible = true;
                                player.CurrentRoom.Description = "a chamber with doors to the east and west.\nThere's an open metal gate to the south.\nIn front of the gate is a pedestal.";
                                Testing.AssertRoomIsAccessible(Rooms.finalRoom);
                            }

                            // Adds the item to the player's inventory and removes it from the room
                            player.PickUpItem(player.CurrentRoom.Item);
                            
                            Testing.AssertPlayerHasItem(player, player.CurrentRoom.Item);
                            
                            player.CurrentRoom.Item = null;
                        }
                    }

                    // If the player uses an item, they are asked to choose an item from their inventory
                    else if (action == "u")
                    {
                        // Checks if the player has items in their inventory
                        if (player.Inventory.Count != 0)
                        {
                            // Asks the player to input an item to use
                            Console.WriteLine($"You can use:");
                            for (int index = 0; index < player.Inventory.Count; index++)
                            {
                                Console.WriteLine($"{index + 1}. {player.Inventory.Items[index].Name}");
                            }
                            Console.Write("> ");

                            // Gets the correspondent item to the user's input if valid
                            if (int.TryParse(Console.ReadLine(), out int selectedItemIndex) && selectedItemIndex <= player.Inventory.Count && selectedItemIndex > 0)
                            {
                                Item selectedItem = player.Inventory.Items[selectedItemIndex - 1];

                                // Uses the item
                                player.UseItem(selectedItem);
                            }
                            // Prints error if user's input is invalid
                            else
                            {
                                Console.WriteLine("You must enter a number corresponding to an item in your inventory.\n");
                            }
                        }

                        // If the player has no items in their inventory, an appropriate message is displayed
                        else
                        {
                            Console.WriteLine("You have no items in your inventory.\n");
                        }
                    }

                    else if (action == "a")
                    {
                        if (player.CurrentRoom.Monster == null)
                        {
                            Console.WriteLine("There isn't a monster in this room.\n");
                        }
                        else
                        {
                            Testing.PrintPlayerHealth(player, msg: "@ Player Attack");
                            Testing.PrintMonsterHealth(player.CurrentRoom.Monster, msg: "@ Player Attack");
                            player.AttackTarget(player.CurrentRoom.Monster);
                            Testing.PrintPlayerHealth(player, msg: "@ Player Attack");
                            Testing.PrintMonsterHealth(player.CurrentRoom.Monster, msg: "@ Player Attack");
                        }
                    }

                    else if (action == "m")
                    {
                        // Checks if a monster is in the room
                        if (player.CurrentRoom.Monster != null)
                        {
                            Console.WriteLine($"The {player.CurrentRoom.Monster.Name} won't let you through.");
                        }
                        else
                        {
                            // Gets the possible directions the player can move
                            List<string> possibleDirections = Room.CheckDirections(player.CurrentRoomIndex);
                            List<char> possibleDirectionsLetter = new List<char>();

                            bool directionChosen = false;

                            // Loops while the player has not chosen a direction to move
                            while (directionChosen == false)
                            {

                                // Displays the possible directions the player can move and denotes the first letter of the direction
                                Console.WriteLine($"You can move:");
                                foreach (string direction in possibleDirections)
                                {
                                    Console.WriteLine($"[{direction[0]}]{direction.Substring(1)}");
                                    possibleDirectionsLetter.Add(direction.ToLower()[0]);
                                }

                                // Asks the player which direction they would like to move
                                Console.Write("\nEnter the first letter of the direction you would like to move.\n> ");
                                chosenDirection = Console.ReadLine().ToLower().Trim(' ');

                                if (chosenDirection.Length == 0)
                                {
                                    chosenDirectionChar = ' ';
                                }

                                else
                                {
                                    chosenDirectionChar = chosenDirection[0];
                                }

                                // Checks if the player has chosen a valid direction to move
                                if (possibleDirectionsLetter.Contains(chosenDirectionChar))
                                {
                                    Testing.PrintPlayersCurrentRoom(player);
                                    player.MoveRoom(chosenDirectionChar);
                                    Testing.PrintPlayersCurrentRoom(player);

                                    directionChosen = true;
                                    notMoved = false;
                                }

                                else
                                {
                                    Console.WriteLine("Cannot move in this direction.\n");
                                }
                            }
                        }
                    }

                    if (player.CurrentRoom == GameMap.roomMatrix[5, 1])
                    {
                        Console.WriteLine("\nCongratulations!\nYou made it to the exit of the dungeon.\nThanks for playing.");
                        playing = false;
                    }


                    if (player.CurrentRoom.Monster != null && player.CurrentRoom.Monster.Health <= 0)
                    {
                        Console.WriteLine($"You defeated the {player.CurrentRoom.Monster.Name}.");
                        player.CurrentRoom.Monster = null;
                    }

                    Testing.PrintPlayerHealth(player, msg: "@ Monster Attack");
                    Testing.PrintMonsterHealth(player.CurrentRoom.Monster, msg: "@ Monster Attack");
                    if (player.CurrentRoom.Monster != null && notMoved == true)
                    {
                        player.CurrentRoom.Monster.AttackTarget(player);
                    }
                    Testing.PrintPlayerHealth(player, msg: "@ Monster Attack");
                    Testing.PrintMonsterHealth(player.CurrentRoom.Monster, msg: "@ Monster Attack");

                    if (player.Health <= 0)
                    {
                        Console.WriteLine("\nUnlucky!\nYou ran out of health.");
                        playing = false;
                        notMoved = false;
                    }
                }
            }
        }
    }
}