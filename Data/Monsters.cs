using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public static class Monsters
    {
        public static Monster shadowed_figure = new Monster("Shadowed Figure", 25, 10);
        public static Monster bats = new Bats("Bats", 25, 10);
        public static Monster king_slime = new Slime("King Slime", 75, 25);
    }
}
