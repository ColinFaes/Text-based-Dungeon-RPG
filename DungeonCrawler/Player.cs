using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class Player
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackPower { get; set; }
        public int DefensePower { get; set; }
        public string CurrentObjective { get; set; }

        public Player(string name)
        {
            Name = name;
            Health = 100;
            AttackPower = 10;
            DefensePower = 5;
            CurrentObjective = "Explore the dungeon, find the final bossroom and defeat the final boss.";
        }
