using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DungeonCrawler
{
    public class Enemy
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackPower { get; set; }
        public int DefensePower { get; set; }

        public Enemy(string name, int health, int attackPower, int defensePower)
        {
            Name = name;
            Health = health;
            AttackPower = attackPower;
            DefensePower = defensePower;
        }

        public void Attack(Player player)
        {
            int damageDealt = Math.Max(1, AttackPower - player.DefensePower);
            Console.WriteLine($"The {Name} attacks you for {damageDealt} damage.");
            player.Health -= damageDealt;
        }
    }
}
