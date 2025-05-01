using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    abstract public class Item
    {
        private String _name;
        private String _description;
        private String _useMessage;

        public Item(string name, string description, string useMessage)
        {
            _name = name;
            _description = description;
            _useMessage = useMessage;
        }

        public string Name
        {
            get => _name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value));
                }
                _name = value;
            }
        }
        public string Description
        {
            get => _description;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value));
                }
                _description = value;
            }
        }
        public string UseMessage
        {
            get => _useMessage;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value));
                }
                _useMessage = value;
            }
        }

        public abstract void Use(Player player);
    }

    public class AttackItem : Item
    {
        private int _attackDamage;

        public AttackItem(string name, string description, string useMessage, int attackDamage) : base(name, description, useMessage)
        {
            _attackDamage = attackDamage;
        }

        public int AttackDamage
        {
            get => _attackDamage;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                _attackDamage = value;
            }
        }

        public override void Use(Player player)
        {
            player.Attack += _attackDamage;
        }
    }

    public class HealthItem : Item
    {
        private int _healthRestoration;

        public HealthItem(string name, string description, string useMessage, int healthRestoration) : base(name, description, useMessage)
        {
            _healthRestoration = healthRestoration;
        }

        public int HealthRestoration
        {
            get => _healthRestoration;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                _healthRestoration = value;
            }
        }

        public override void Use(Player player)
        {
            player.Health += _healthRestoration;
        }
    }

    public class HappinessItem : Item
    {
        public HappinessItem(string name, string description, string useMessage, int happinessModifier) : base(name, description, useMessage)
        {
            HappinessModifier = happinessModifier;
        }

        public int HappinessModifier { get; set; }

        public override void Use(Player player)
        {
            player.Happiness += HappinessModifier;
        }
    }
}
