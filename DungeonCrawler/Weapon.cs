using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    [Serializable]
    public class Weapon : Item
    {
        public int Damage { get; set; }

        public Weapon() { }

        public Weapon(string name, int damage, int value)
        {
            Name = name;
            Type = ItemType.Weapon;
            Damage = damage;
            Value = value;
        }

        public override void Use(Player player)
        {
            player.EquipWeapon(this);
        }
    }
}
