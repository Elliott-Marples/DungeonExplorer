using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace DungeonExplorer
{
    public class Player : Creature<Monster>, IDamageable
    {
        // Private properties
        private Inventory _inventory = new Inventory();
        private Room _currentRoom;
        private int[] _currentRoomIndex;
        private static readonly Random random = new Random();

        // Public properties with getters and setters
        public Inventory Inventory { get => _inventory; private set => _inventory = value; }
        public Room CurrentRoom
        {
            get { return _currentRoom; }
            set
            {
                _currentRoom = value;
                _currentRoomIndex = GameMap.GetRoomIndex(value);
            }
        }
        public int[] CurrentRoomIndex { get => _currentRoomIndex; }

        // Constructor
        public Player(string name, int health, int attack, Room startRoom) : base(name, health, attack)
        {
            this.Name = name;
            this.Health = health;
            this.Attack = attack;
            this.CurrentRoom = startRoom;
        }

        // Adds an item to the inventory
        public void PickUpItem(Item item)
        {
            Inventory.Add(item);
        }

        // Removes an item from the inventory when used
        public void UseItem(Item item)
        {
            if (Inventory.Contains(item))
            {
                Inventory.Remove(item);
                item.Use(this);
                Console.WriteLine($"\nYou used the {item.Name}.\n{item.UseMessage}");
            }

            else
            {
                Console.WriteLine("\nYou don't have that item in your inventory.");
            }
        }
       
        // Sets the player's current room
        public void SetRoom(Room moveTo)
        {
            _currentRoom.Visited = true;
            GameMap.visitedRooms.Add(_currentRoom);
            _currentRoom = moveTo;
        }

        // Moves the player to the room in the direction specified
        public void MoveRoom(char direction)
        {
            // Updates currentIndex based on the direction the player has chosen
            if (direction.Equals('n'))
            {
                _currentRoomIndex[0] -= 1;
            }

            else if (direction.Equals('s'))
            {
                _currentRoomIndex[0] += 1;
            }

            else if (direction.Equals('w'))
            {
                _currentRoomIndex[1] -= 1;
            }

            else if (direction.Equals('e'))
            {
                _currentRoomIndex[1] += 1;
            }

            SetRoom(GameMap.roomMatrix[_currentRoomIndex[0], _currentRoomIndex[1]]);
        }

        // Returns the player's inventory
        public string GetInventoryString()
        {
            // A string containing the player's inventory is created
            string inventory_string = $"{Name}'s Inventory: ";

            // If the player has items in their inventory, an appropriate message is returned
            if (Inventory.Count != 0)
            {
                inventory_string += "\nContents: ";
                foreach (Item item in _inventory.Items)
                {
                    inventory_string += item.Name;
                }
            }

            // If the player has no items in their inventory, an appropriate message is returned
            if (Inventory.Count == 0)
            {
                return "There is nothing in your inventory.";
            }

            return inventory_string;
        }

        // Attacks a monster
        public override void AttackTarget(Monster target)
        {
            bool attackHit = true;
            if (target.CanMiss)
            {
                double result = random.NextDouble();
                attackHit = (result >= 0.33);
            }
            if (attackHit && target is IDamageable)
            {
                target.TakeDamage(Attack);
                Console.WriteLine($"You attacked the {target.Name}.\nYou dealt {Attack} damage.\n");
            }
            else
            {
                Console.WriteLine($"The {target.Name} dodged your attack.\n");
            }
        }

        // Returns the player's stats
        public override void DisplayStats()
        {
            base.DisplayStats();
            Console.WriteLine($"# of Items: {Inventory.Count}");
        }

        // Decreases the player's health
        public void TakeDamage(int damage)
        {
            Health -= damage;
        }
    }
}