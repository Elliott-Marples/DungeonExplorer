using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Room
    {
        // Private properties
        private string _description;
        private Item _item;
        private bool _isAccessible;
        private bool _visited;
        private int[] _index;

        // Public properties with getters and setters
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public Item Item
        {
            get { return _item; }
            set { _item = value; }
        }

        public bool IsAccessible
        {
            get { return _isAccessible; }
            set { _isAccessible = value; }
        }

        public bool Visited
        {
            get { return _visited; }
            set { _visited = value; }
        }

        public int[] Index { get => _index; set => _index = value; }

        // Constructor
        public Room(string description, Item item = null, bool isAccessible = true, bool visited = false)
        {
            this.Description = description;
            this.Item = item;
            this.IsAccessible = isAccessible;
            this.Visited = visited;
        }

        // Returns the room's description
        public string GetDescription()
        {
            return Description;
        }

        // Checks the possible directions the player can move
        public static List<string> CheckDirections(int[] currentIndex)
        {
            // Creates a list which will contain possible directions the player can move from the current room
            List<string> possibleDirections = new List<string>();

            // Gets the index of the room to the north, south, west and east of the current room
            int northIndex = currentIndex[0] - 1;
            int southIndex = currentIndex[0] + 1;
            int westIndex = currentIndex[1] - 1;
            int eastIndex = currentIndex[1] + 1;

            // Checks if the room to the north, south, west and east of the current room exists (and is accessible) and adds the direction to the list if it does
            if (northIndex >= 0)
            {
                Room northRoom = GameMap.roomMatrix[northIndex, currentIndex[1]];
                if (northRoom != null && northRoom.IsAccessible)
                {
                    possibleDirections.Add("North");
                }
            }

            if (southIndex < GameMap.roomMatrix.GetLength(0))
            {
                Room southRoom = GameMap.roomMatrix[southIndex, currentIndex[1]];

                if (southRoom != null && southRoom.IsAccessible)
                {
                    possibleDirections.Add("South");
                }
            }

            if (westIndex >= 0)
            {
                Room westRoom = GameMap.roomMatrix[currentIndex[0], westIndex];

                if (westRoom != null && westRoom.IsAccessible)
                {
                    possibleDirections.Add("West");
                }
            }

            if (eastIndex < GameMap.roomMatrix.GetLength(1))
            {
                Room eastRoom = GameMap.roomMatrix[currentIndex[0], eastIndex];

                if (eastRoom != null && eastRoom.IsAccessible)
                {
                    possibleDirections.Add("East");
                }
            }

            // Returns the list of possible directions
            return possibleDirections;
        }
    }
}