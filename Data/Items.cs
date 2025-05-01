using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public static class Items
    {
        public static AttackItem    sabre  = new AttackItem("Sabre", "A sword that makes you feel prepared for battle.", "The Sabre makes you prepared for battle (+10 attack).", 10);
        public static HealthItem    potion = new HealthItem("Potion", "A mysterious liquid in the bottle.", "The Potion heals your wounds (+25 health).", 25);
        public static HappinessItem stone  = new HappinessItem("Stone", "It's just a stone...", "The stone is life, the stone is laughter, the stone is love...", 1000);
    }
}
