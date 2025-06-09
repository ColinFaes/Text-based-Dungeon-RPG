using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    [Serializable]
    public class BossRoom : Room
    {
        public BossRoom() { }

        public BossRoom(string description, Boss boss)
            : base(description, boss)
        {
        }

        public override void Enter(Player player)
        {
            Console.WriteLine("You enter the final room...");
            base.Enter(player);
        }
    }
}
