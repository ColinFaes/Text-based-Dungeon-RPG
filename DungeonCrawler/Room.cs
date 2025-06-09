using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DungeonCrawler
{
    [Serializable]
    [XmlInclude(typeof(BossRoom))]
    [XmlInclude(typeof(Boss))]
    public class Room
    {
        public string Description { get; set; }
        public Enemy Enemy { get; set; }
        public Item Item { get; set; }
        public Item HiddenItem { get; set; }
        public Puzzle Puzzle { get; set; }
        public NPC Npc { get; set; }

        public Room() { }

        static Random rand = new Random();

        public Room(string description, Enemy enemy = null, Item item = null, Item hiddenItem = null, Puzzle puzzle = null, NPC npc = null)
        {
            Description = description;
            Enemy = enemy;
            Item = item;
            HiddenItem = hiddenItem;
            Puzzle = puzzle;
            Npc = npc;
        }

        public virtual void Enter(Player player)
        {
            bool inRoom = true;

            while (inRoom)
            {
                Console.WriteLine(Description);

                if (Npc != null)
                {
                    Console.WriteLine($"You meet {Npc.Name}. {Npc.Greeting}");

                    bool interacting = true;

                    while (interacting)
                    {
                        Console.WriteLine("\nWhat do you want to do?");
                        Console.WriteLine("1) Talk");
                        Console.WriteLine("2) Trade");
                        Console.WriteLine("3) Sell");
                        Console.WriteLine("4) Leave");

                        player.DisplayStats();
                        string action = Console.ReadLine();
                        Console.Clear();

                        switch (action)
                        {
                            case "1":
                                Console.WriteLine("The NPC shares some interesting information.");
                                break;
                            case "2":
                                Npc.OpenShop(player);
                                break;
                            case "3":
                                Npc.Sell(player);
                                break;
                            case "4":
                                Console.WriteLine("You decide to leave the NPC.");
                                interacting = false;
                                break;
                            case "help":
                                player.DisplayHelp();
                                Console.WriteLine(Description);
                                Console.WriteLine($"You meet {Npc.Name}. {Npc.Greeting}");
                                continue;
                            default:
                                Console.WriteLine("Invalid input, choose one of the options above by typng the correct number.");
                                break;
                        }
                    }
                }

                if (Enemy != null)
                {
                    Console.WriteLine($"A {Enemy.Name} is here!");
                    while (Enemy.Health > 0 && player.Health > 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("\nChoose an action:");
                        Console.WriteLine("(1) Attack");
                        Console.WriteLine("(2) Use Item");
                        Console.WriteLine("(3) Examine Environment");
                        Console.WriteLine("(4) Flee");

                        player.DisplayStats();
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
                        else if (action == "2")
                        {
                            if (player.Inventory.Count > 0)
                            {
                                Console.WriteLine("Choose an item to use:");
                                for (int i = 0; i < player.Inventory.Count; i++)
                                {
                                    Console.WriteLine($"({i + 1}) {player.Inventory[i].Name}");
                                }
                                player.DisplayStats();
                                int itemIndex = int.Parse(Console.ReadLine()) - 1;
                                Console.Clear();
                                player.UseItem(player.Inventory[itemIndex]);
                            }
                            else
                            {
                                Console.WriteLine("You don't have any items to use...");
                            }
                        }
                        else if (action == "3")
                        {
                            player.ExamineEnvironment(this);
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
                        else if (action == "help")
                        {
                            player.DisplayHelp();
                            Console.WriteLine(Description);
                            Console.WriteLine($"A {Enemy.Name} is here!");
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

                if (Puzzle != null && Enemy == null)
                {
                    player.SolvePuzzle(Puzzle);
                }

                if (Item != null)
                {
                    player.AddItem(Item);
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
