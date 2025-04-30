using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public abstract class Creature
    {
        private string _name;
        private int _health;
        private int _attack;
        private int _happiness;

        public string Name { get => _name; set => _name = value; }
        public int Health { get => _health; set => _health = value; }
        public int Attack { get => _attack; set => _attack = value; }
        public int Happiness { get => _happiness; set => _happiness = value; }

        public Creature(string name, int health, int attack)
        {
            this.Name = name;
            this.Health = health;
            this.Attack = attack;
        }

        public abstract void AttackTarget(Creature target);
        public virtual void DisplayStats()
        {
            // A string containing the creature's stats is created
            string stats_string = $"{Name}'s Stats:\nHealth = {Health}\nAttack = {Attack}";

            // If the creature's happiness is not 0, an appropriate message is returned
            if (Happiness != 0)
            {
                stats_string += $"\nHappiness = {Happiness}";
            }

            Console.WriteLine(stats_string);
        }
    }
}
