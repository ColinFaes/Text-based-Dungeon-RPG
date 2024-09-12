using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DungeonCrawler
{
    public class Room
    {
        public string Description { get; set; }
        public Enemy Enemy { get; set; }
        public Room(string description, Enemy enemy = null, Item item = null, Item hiddenItem = null, Puzzle puzzle = null, NPC npc = null)
        {
            Description = description;
            Enemy = enemy;
    }
}
