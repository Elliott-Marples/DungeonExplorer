using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public static class Monsters
    {
        // Creates all the monsters in the game with their stats
        public static Monster shadowed_figure = new Monster("Shadowed Figure", 25, 10);
        public static Bats bats = new Bats("Bats", 25, 10);
        public static Slime king_slime = new Slime("King Slime", 75, 25);
    }
}
