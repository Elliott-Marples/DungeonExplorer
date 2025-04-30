using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Monster : Creature
    {
        public Monster(string name, int health, int attack) : base(name, health, attack) { }

        public override void AttackTarget(Creature target)
        {
            target.Health -= Attack;
            Console.WriteLine($"\nThe {Name} attacked you.\nIt dealt {Attack} damage.");
        }
    }
}
