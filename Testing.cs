using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public static class Testing
    {
        // Allows for quick access to any room in the game
        public static void ChangeRoom(Player player, Room room)
        {
            player.SetRoom(room);
        }

        // Ensures the player has a name
        public static void AssertPlayerHasName(Player player)
        {
            Debug.Assert(player.Name != null);
        }

        // Prints the player's current room
        public static void PrintPlayersCurrentRoom(Player player)
        {
            Debug.WriteLine($"Room: {player.CurrentRoom.Name} @ {player.CurrentRoomIndex[1]}, {player.CurrentRoomIndex[0]}");
        }

        // Prints the player's input
        public static void PrintPlayersInput(string input)
        {
            Debug.WriteLine($"Input: {input}");
        }

        // Ensures the specified room contains an item
        public static void AssertRoomHasItem(Room room)
        {
            Debug.Assert(room.Item != null);
        }

        // Ensures the specified room contains a specified item
        public static void AssertRoomHasItem(Room room, Item item)
        {
            Debug.Assert(room.Item == item);
        }

        // Ensures the specified room is accessible
        public static void AssertRoomIsAccessible(Room room)
        {
            Debug.Assert(room.IsAccessible);
        }

        // Ensures the player has a specified item
        public static void AssertPlayerHasItem(Player player, Item item)
        {
            Debug.Assert(player.Inventory.Contains(item));
        }

        // Prints the player's health (and a custom message)
        public static void PrintPlayerHealth(Player player, string msg = "")
        {
            Debug.WriteLine($"Player Health: {player.Health} " + msg);
        }

        // Prints the monster's health (and a custom message)
        public static void PrintMonsterHealth(Monster monster, string msg = "")
        {
            if (monster != null)
            {
                Debug.WriteLine($"Monster Health: {monster.Health} " + msg);
            }
        }
    }
}
