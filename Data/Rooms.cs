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
        public static Room entrance = new Room("entrance", "a stone arch surrounding an entrance into the dungeon facing south.");
        public static Room room1 = new Room("room1", "an empty room with passages to the east and west.");
        public static Room room2left = new Room("room2left", "a room containing a treasure chest and a passage to the south.", item: Items.sabre);
        public static Room room2right = new Room("room2right", "a room containing a shadowed figure and a passage to the south.", monster: Monsters.shadowed_figure);
        public static Room room3left = new Room("room3left", "a long passage heading south with unusual symbols carved into the walls.");
        public static Room room3right = new Room("room3right", "a bridge heading south over an underground ravine.");
        public static Room room4left = new Room("room4left", "a cave containing bats that won't let you past and a door to the east.", monster: Monsters.bats);
        public static Room room4right = new Room("room4right", "a cave with a table of glass bottles filled with a mysterious liquid.", item: Items.potion);
        public static Room room5 = new Room("room5", "a chamber with doors to the east and west.\nThere's a closed metal gate to the south." +
            "\nIn front of the gate is a stone on a pedestal.", item: Items.stone);
        public static Room finalRoom = new Room("finalRoom", "a vast underground arena with a massive slime creature in the centre.", monster: Monsters.king_slime, isAccessible: false);
        public static Room exit = new Room("exit", "Exit.");
    }
}
