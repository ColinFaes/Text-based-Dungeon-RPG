using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    [Serializable]
    public class Potion : Item
    {
        public int HealAmount { get; set; }

        public Potion() { }

        public Potion(string name, int healAmount)
        {
            Name = name;
            Type = ItemType.Potion;
            HealAmount = healAmount;
            Value = healAmount;
        }

        public override void Use(Player player)
        {
            Console.WriteLine($"You drink the {Name}. You recover {HealAmount} health points.");
            player.Health += HealAmount;
        }
    }
}
