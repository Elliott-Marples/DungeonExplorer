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
                //if (room != null)
                //{
                //    Console.WriteLine(room.GetDescription());
                //}
                //else
                //{
                //    Console.WriteLine("null");
                //}
                //Console.WriteLine($"{index[0]}, {index[1]}");
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
    }
}
