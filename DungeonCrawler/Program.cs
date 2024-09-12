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

        static List<Room> GenerateRandomDungeon()
        {
            List<Room> dungeon = new List<Room>();

            for (int i = 0; i < 5; i++)
            {
                string roomDescription = GenerateRandomRoomDescription();
                Enemy roomEnemy = GenerateRandomEnemy();
                dungeon.Add(new Room(
                    description: roomDescription,
                    enemy: rand.Next(0, 2) == 0 ? roomEnemy : null,
                ));
            }
            return dungeon;
        }

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
        static void Main(string[] args)
        {
            Player player;
            List<Room> dungeon;
            int currentRoomIndex = 0;

                Console.Write("Enter your character's name: ");
                string playerName = Console.ReadLine();
                player = new Player(playerName);
                dungeon = GenerateRandomDungeon();
            for (int i = currentRoomIndex; i < dungeon.Count; i++)
            {
                dungeon[i].Enter(player);
                if (player.Health <= 0)
                {
                    Console.WriteLine("Game over.");
                    break;
                }
            }

            if (player.Health > 0)
            {
                Console.WriteLine($"Congratulations {player.Name}! You have completed the dungeon.");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
            }
        }
    }
}
