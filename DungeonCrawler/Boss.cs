using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class Boss : Enemy
    {
        public Boss() { }   

        public Boss(string name, int health, int attackPower, int defensePower)
            : base(name, health, attackPower, defensePower)
        {
        }
    }
}
