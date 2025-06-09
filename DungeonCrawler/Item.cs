using DungeonCrawler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DungeonCrawler
{
    public enum ItemType { Weapon, Potion, Armor }

    [Serializable]
    [XmlInclude(typeof(Potion))]
    [XmlInclude(typeof(Weapon))]
    [XmlInclude(typeof(Armor))]
    public abstract class Item
    {
        public string Name { get; set; }
        public ItemType Type { get; set; }
        public int Value { get; set; }

        protected Item() { }

        public abstract void Use(Player player);
    }
}
