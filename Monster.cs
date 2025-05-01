using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    // Derives the monster class from creature (with player generic) and uses the IDamageable interface
    public class Monster : Creature<Player>, IDamageable
    {
        // Constructor
        public Monster(string name, int health, int attack) : base(name, health, attack) { }

        // Abstract Method Override that allows monsters to attack the player
        public override void AttackTarget(Player target)
        {
            target.TakeDamage(Attack);
            Console.WriteLine($"\nThe {Name} attacked you.\nIt dealt {Attack} damage.");
        }

        // Decreases the monster's health (required by IDamageable)
        public void TakeDamage(int damage)
        {
            Health -= damage;
        }
    }

    // Slime subclass of Monster
    public class Slime : Monster
    {
        // Constructor
        public Slime(string name, int health, int attack) : base(name, health, attack) { }

        // Abstract Method Override that performs same actions as Monster AttackTarget as well as letting the slime gain health by attacking the player
        public override void AttackTarget(Player target)
        {
            base.AttackTarget(target);
            int healthAbsorb = Attack / 4;
            Health += healthAbsorb;
            Console.WriteLine($"\nThe {Name} absored {healthAbsorb} health that you lost");
        }
    }

    // Bat subclass of Monster
    public class Bats : Monster
    {
        // Allows the player to miss when attacking the bats
        public override bool CanMiss => true;

        // Constructor
        public Bats(string name, int health, int attack) : base(name, health, attack) { }
    }
}
