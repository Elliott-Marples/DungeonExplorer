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
        public static void ChangeRoom(Player player, Room room)
        {
            player.SetRoom(room);
        }

        public static void AssertPlayerHasName(Player player)
        {
            Debug.Assert(player.Name != null);
        }

        public static void PrintPlayersCurrentRoom(Player player)
        {
            Debug.WriteLine(player.CurrentRoom.Name);
            Debug.WriteLine($"X: {player.CurrentRoomIndex[1]}, Y: {player.CurrentRoomIndex[0]}");
        }

        public static void PrintPlayersInput(string input)
        {
            Debug.WriteLine(input);
        }

        public static void AssertRoomHasItem(Room room)
        {
            Debug.Assert(room.Item != null);
        }

        public static void AssertRoomHasItem(Room room, Item item)
        {
            Debug.Assert(room.Item == item);
        }

        public static void AssertRoomIsAccessible(Room room)
        {
            Debug.Assert(room.IsAccessible);
        }

        public static void AssertPlayerHasItem(Player player, Item item)
        {
            Debug.Assert(player.Inventory.Contains(item));
        }
    }
}
