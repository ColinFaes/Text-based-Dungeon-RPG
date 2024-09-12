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
        static Random rand = new Random();

        public Room(string description, Enemy enemy = null, Item item = null, Item hiddenItem = null, Puzzle puzzle = null, NPC npc = null)
        {
            Description = description;
            Enemy = enemy;
        public virtual void Enter(Player player)
        {
            bool inRoom = true;

            while (inRoom)
            {
                Console.WriteLine(Description);

                if (Enemy != null)
                {
                    Console.WriteLine($"A {Enemy.Name} is here!");
                    while (Enemy.Health > 0 && player.Health > 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("\nChoose an action:");
                        Console.WriteLine("(1) Attack");
                        Console.WriteLine("(4) Flee");
                        string action = Console.ReadLine();
                        Console.Clear();
                        if (action == "1")
                        {
                            player.Attack(Enemy);
                            if (Enemy.Health > 0)
                            {
                                Enemy.Attack(player);
                            }
                            else
                            {
                                int amount = rand.Next(1, 10);
                                player.Gold += amount;
                                Console.WriteLine($"You defeated the {Enemy.Name}! It dropped {amount} Gold\n");
                            }
                        }
                        else if (action == "4")
                        {
                            Console.WriteLine("You attempt to flee.");
                            Random rand = new Random();
                            if (rand.Next(0, 2) == 0)
                            {
                                Console.WriteLine("You successfully fled the battle!");
                                inRoom = false;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("You failed to flee. The enemy attacks!");
                                Enemy.Attack(player);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input, choose one of the options above by typng the correct number.");
                        }

                        if (player.Health <= 0)
                        {
                            Console.WriteLine("You have died. Game over.");
                            Console.WriteLine("Press any key to exit");
                            Console.ReadKey();
                            Environment.Exit(0);
                        }
                    }
                }
                if (player.Health <= 0)
                {
                    Console.WriteLine("You have died. Game over.");
                    Environment.Exit(0);
                }

                inRoom = false;
            }
        }
    }
}
