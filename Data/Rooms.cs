using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public static class Rooms
    {
        // Creates all the rooms in the dungeon with an appropriate description and item
        public static Room entrance = new Room("a stone arch surrounding an entrance into the dungeon facing south.");
        public static Room room1 = new Room("an empty room with passages to the east and west.");
        public static Room room2left = new Room("a room containing a treasure chest and a passage to the south.", item: Items.Sabre);
        public static Room room2right = new Room("a room containing a shadowed figure and a passage to the south.");
        public static Room room3left = new Room("a long passage heading south with unusual symbols carved into the walls.");
        public static Room room3right = new Room("a bridge heading south over an underground ravine.");
        public static Room room4left = new Room("a cave containing bats that won't let you past and a door to the east.");
        public static Room room4right = new Room("a cave with a table of glass bottles filled with a mysterious liquid.", item: Items.Potion);
        public static Room room5 = new Room("a chamber with doors to the east and west.\nThere's a closed metal gate to the south." +
            "\nIn front of the gate is a stone on a pedestal.", item: Items.Stone);
        public static Room finalRoom = new Room("a vast underground arena with a massive slime creature in the centre.", isAccessible: false);
        public static Room exit = new Room("Exit.");
    }
}
