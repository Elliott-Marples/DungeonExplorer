using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Monster : Creature<Player>, IDamageable
    {
        public Monster(string name, int health, int attack) : base(name, health, attack) { }

        public override void AttackTarget(Player target)
        {
            target.TakeDamage(Attack);
            Console.WriteLine($"\nThe {Name} attacked you.\nIt dealt {Attack} damage.");
        }

        // Decreases the player's health
        public void TakeDamage(int damage)
        {
            Health -= damage;
        }
    }

    public class Slime : Monster
    {
        public Slime(string name, int health, int attack) : base(name, health, attack) { }
        public override void AttackTarget(Player target)
        {
            base.AttackTarget(target);
            int healthAbsorb = Attack / 4;
            Health += healthAbsorb;
            Console.WriteLine($"\nThe {Name} absored {healthAbsorb} health that you lost");
        }
    }

    public class Bats : Monster
    {
        public override bool CanMiss => true;

        public Bats(string name, int health, int attack) : base(name, health, attack) { }

    }
}
