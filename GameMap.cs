using DungeonExplorer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public static class GameMap
    {
        // Defines the position of rooms using a 2d array
        public static Room[,] roomMatrix = new Room[6, 3]
        {
            {   null,               Rooms.entrance,     null                },
            {   Rooms.room2left,    Rooms.room1,        Rooms.room2right    },
            {   Rooms.room3left,    null,               Rooms.room3right    },
            {   Rooms.room4left,    Rooms.room5,        Rooms.room4right    },
            {   null,               Rooms.finalRoom,    null                },
            {   null,               Rooms.exit,         null                }
        };

        // Finds the index of a room in roomMatrix
        public static int[] GetRoomIndex(Room queriedRoom)
        {
            int indexX = 0;
            int indexY = 0;
            foreach (Room room in roomMatrix)
            {
                if (room == queriedRoom)
                {
                    int[] index = { indexY, indexX };
                    return index;
                }
                indexX++;
                if (indexX == 3)
                {
                    indexX = 0;
                    indexY++;
                }
            }
            return null;
        }

        // Returns list of rooms
        public static List<Room> GetRoomList()
        {
            List<Room> roomList = new List<Room>();
            foreach (Room room in roomMatrix)
            {
                roomList.Add(room);
            }
            return roomList;
        }

        // List of rooms with items
        public static List<Room> visitedRooms = GetRoomList().Where(room => room != null && room.Visited == true).Select(room => room).ToList();

        // List of rooms with items
        public static List<Room> itemRooms = GetRoomList().Where(room => room != null && room.Item != null).Select(room => room).ToList();

        // List of rooms with monsters
        public static List<Room> monsterRooms = GetRoomList().Where(room => room != null && room.Monster != null).Select(room => room).ToList();
    }
}
