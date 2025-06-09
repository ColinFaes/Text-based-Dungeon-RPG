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

        static void GameIntroduction(Player player)
        {
            Console.Clear();
            Console.WriteLine("===================================================================================");
            Console.WriteLine($"Welcome, {player.Name}, to the world of Forgotten Dungeons!");
            Console.WriteLine("This is a dark and dangerous world filled with monsters, traps, and mysteries.");
            Console.WriteLine("Your goal is to explore the dungeon, find valuable treasures, and defeat the evil lurking in the depths.");
            Console.WriteLine("\nThere are many rooms, and at the end of this journey awaits the final boss, the strongest enemy in the dungeon.");
            Console.WriteLine("Defeat the final boss to complete the dungeon and prove yourself as a true hero!");
            Console.WriteLine("\nKeep a close eye on your health and use your weapons and equipment wisely.");
            Console.WriteLine("Don't forget to decipher the puzzles and riddles you will encounter along the way.");
            Console.WriteLine("\nIf you don't know what to do you can type 'help' and instruction will be shown on the screen.");
            Console.WriteLine("\nGood luck, and may fate be on your side!");
            Console.WriteLine("===================================================================================");
            Console.WriteLine("\nPress Enter to begin...");
            Console.ReadLine();
            Console.Clear();
        }

        static List<Room> GenerateRandomDungeon()
        {
            List<Room> dungeon = new List<Room>();

            for (int i = 0; i < 5; i++)
            {
                string roomDescription = GenerateRandomRoomDescription();
                Enemy roomEnemy = GenerateRandomEnemy();
                Item roomItem = GenerateRandomItem();
                Puzzle roomPuzzle = GenerateRandomPuzzle();
                NPC roomNPC = GenerateRandomNPC();

                dungeon.Add(new Room(
                    description: roomDescription,
                    enemy: rand.Next(0, 2) == 0 ? roomEnemy : null,
                    item: rand.Next(0, 2) == 0 ? roomItem : null,
                    hiddenItem: rand.Next(0, 3) == 0 ? GenerateRandomItem() : null,
                    puzzle: rand.Next(0, 2) == 0 ? roomPuzzle : null,
                    npc: rand.Next(0, 2) == 0 ? roomNPC : null
                ));
            }

            Boss finalBoss = new Boss(
                "Dragon King", 
                200, 
                30, 
                15
            );

            dungeon.Add(new BossRoom(
                "You see a massive chamber, with a terrifying presence looming in the shadows.", 
                finalBoss
            ));

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

        public static Item GenerateRandomItem()
        {
            string[] weaponNames = { 
                "Rusty Sword", 
                "Battle Axe", 
                "Magic Staff" 
            };
            string[] potionNames = { 
                "Health Potion", 
                "Mana Potion" 
            };
            string[] armorNames = { 
                "Leather Armor", 
                "Chainmail", 
                "Steel Armor" 
            };

            int itemType = rand.Next(3);

            switch (itemType)
            {
                case 0:
                    return new Weapon(
                        name: weaponNames[rand.Next(weaponNames.Length)], 
                        damage: rand.Next(5, 16), 
                        value: rand.Next(5,16)
                    );
                case 1:
                    return new Potion(
                        name: potionNames[rand.Next(potionNames.Length)], 
                        healAmount: rand.Next(10, 26)
                    );
                case 2:
                    return new Armor(
                        name: armorNames[rand.Next(armorNames.Length)], 
                        defense: rand.Next(5, 16)
                    );
                default:
                    return null;
            }
        }

        static Puzzle GenerateRandomPuzzle()
        {
            string[] puzzleDescriptions = {
                "Solve the riddle: What has keys but can't open locks?",
                "Arrange the symbols to unlock the door: X, O, X",
                "Answer the question: What comes once in a minute, twice in a moment, but never in a thousand years?"
            };
            string[] puzzleSolutions = { 
                "Piano", 
                "XOX", 
                "M" 
            };
            int index = rand.Next(puzzleDescriptions.Length);

            return new Puzzle(
                description: puzzleDescriptions[index],
                solution: puzzleSolutions[index],
                reward: GenerateRandomItem()
            );
        }

        static NPC GenerateRandomNPC()
        {
            string[] npcNames = { 
                "Old Merchant", 
                "Mysterious Stranger", 
                "Wandering Sage" 
            };
            string[] npcGreetings = { 
                "Welcome traveler! I have rare items for sale.", 
                "Greetings, hero. Do you seek knowledge?", 
                "Ah, a brave soul! I have some advice for you." 
            };

            return new NPC(
                name: npcNames[rand.Next(npcNames.Length)],
                greeting: npcGreetings[rand.Next(npcGreetings.Length)]
            );
        }

        static void Main(string[] args)
        {
            Console.WriteLine("====================================");
            Console.WriteLine("Welcome to Forgotten Dungeons");
            Console.WriteLine("====================================");
            Console.WriteLine("\n(1) New Game");
            Console.WriteLine("(2) Load Game");
            Console.WriteLine("(3) Exit");
            string choice = Console.ReadLine();

            Player player;
            List<Room> dungeon;
            int currentRoomIndex = 0;

            if (choice == "1")
            {
                Console.Write("Enter your character's name: ");
                string playerName = Console.ReadLine();

                player = new Player(playerName);
                GameIntroduction(player);

                dungeon = GenerateRandomDungeon();
            }
            else if (choice == "2")
            {
                GameState loadedGame = LoadGame();
                if (loadedGame != null)
                {
                    player = loadedGame.Player;
                    dungeon = loadedGame.Dungeon;
                    currentRoomIndex = loadedGame.CurrentRoomIndex;
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }

            for (int i = currentRoomIndex; i < dungeon.Count; i++)
            {
                dungeon[i].Enter(player);

                SaveGame(player, dungeon, i);

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

        static void SaveGame(Player player, List<Room> dungeon, int currentRoomIndex)
        {
            GameState gameState = new GameState(player, dungeon, currentRoomIndex);
            SaveLoadManager.SaveGame(gameState, "savegame.xml");
        }

        static GameState LoadGame()
        {
            try
            {
                return SaveLoadManager.LoadGame("savegame.xml");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("No save file found. Starting a new game.");
                return null;
            }
        }
    }
}
