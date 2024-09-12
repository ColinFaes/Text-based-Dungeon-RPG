using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace DungeonCrawler
{
    class Program
    {
        static Random rand = new Random();

        static string GenerateRandomRoomDescription()
        {
            string[] descriptions = {
                "A dark and damp cave.",
                "A narrow corridor with flickering torches.",
                "A grand hall with marble pillars.",
                "A small room filled with cobwebs.",
                "An ancient library with dusty tomes."
            };
            return descriptions[rand.Next(descriptions.Length)];
        }

        static Enemy GenerateRandomEnemy()
        {
            string[] enemyNames = { 
                "Goblin", 
                "Skeleton", 
                "Orc", 
                "Zombie", 
                "Dragon" 
            };
            int health = rand.Next(20, 101);
            int attackPower = rand.Next(5, 21);
            int defensePower = rand.Next(1, 11);

            return new Enemy(
                name: enemyNames[rand.Next(enemyNames.Length)],
                health: health,
                attackPower: attackPower,
                defensePower: defensePower
            );
        }
        }
