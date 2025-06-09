using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    [Serializable]
    public class Armor : Item
    {
        public int Defense { get; set; }

        public Armor() { }

        public Armor(string name, int defense)
        {
            Name = name;
            Type = ItemType.Armor;
            Defense = defense;
            Value = defense;
        }

        public override void Use(Player player)
        {
            player.EquipArmor(this);
        }
    }
}
