using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DungeonCrawler
{
    public static class SaveLoadManager
    {
        public static void SaveGame(GameState gameState, string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(GameState));
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, gameState);
            }
        }

        public static GameState LoadGame(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(GameState));
            using (StreamReader reader = new StreamReader(filePath))
            {
                return (GameState)serializer.Deserialize(reader);
            }
        }
    }
}
