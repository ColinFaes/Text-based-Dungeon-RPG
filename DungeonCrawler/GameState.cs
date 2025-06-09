using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DungeonCrawler
{
    [Serializable]
    [XmlInclude(typeof(Potion))]
    [XmlInclude(typeof(Weapon))]
    [XmlInclude(typeof(Armor))]
    [XmlInclude(typeof(BossRoom))]
    public class GameState
    {
        public Player Player { get; set; }
        public List<Room> Dungeon { get; set; }
        public int CurrentRoomIndex { get; set; }

        public GameState() { }

        public GameState(Player player, List<Room> dungeon, int currentRoomIndex)
        {
            Player = player;
            Dungeon = dungeon;
            CurrentRoomIndex = currentRoomIndex;
        }
    }
}
