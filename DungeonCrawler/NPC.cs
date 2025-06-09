using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    [Serializable]
    public class NPC
    {
        public string Name { get; set; }
        public string Greeting { get; set; }

        private List<Item> shopItems;

        public NPC() { }

        public NPC(string name, string greeting)
        {
            Name = name;
            Greeting = greeting;
            shopItems = GenerateShopItems();
        }

        public void OpenShop(Player player)
        {
            bool shopping = true;

            while (shopping)
            {
                Console.WriteLine("The NPC offers you some items for trade.");
                Console.WriteLine("You can trade your items here.");

                for (int i = 0; i < shopItems.Count; i++)
                {
                    Item item = shopItems[i];
                    Console.WriteLine($"{i + 1}) {item.Name} - Price: {item.Value} gold");
                }
                Console.WriteLine("4) Back");


                Console.WriteLine("Enter the number of the item you want to buy.");
                player.DisplayStats();
                string choice = Console.ReadLine();
                Console.Clear();

                if (int.TryParse(choice, out int itemNumber) && itemNumber >= 1 && itemNumber <= shopItems.Count)
                {
                    Item selectedItem = shopItems[itemNumber - 1];
                    if (player.Gold >= selectedItem.Value)
                    {
                        player.Gold -= selectedItem.Value;
                        player.AddItem(selectedItem);
                        Console.WriteLine($"You bought the {selectedItem.Name} for {selectedItem.Value} gold.");
                    }
                    else
                    {
                        Console.WriteLine("You don't have enough gold to buy that item.");
                    }
                }
                else
                {
                    Console.WriteLine("You decide not to buy anything.");
                }

                if (choice == "4")
                {
                    shopping = false;
                }

                if (choice == "help")
                {
                    player.DisplayHelp();
                    continue;
                }
            }
        }

        private List<Item> GenerateShopItems()
        {
            List<Item> items = new List<Item>();

            for (int i = 0; i < 3; i++)
            {
                items.Add(Program.GenerateRandomItem());
            }

            return items;
        }

        public void Sell(Player player)
        {
            if (player.Inventory.Count > 0)
            {
                Console.WriteLine("What do you want to sell?");
                for (int i = 0; i < player.Inventory.Count; i++)
                {
                    Console.WriteLine($"({i + 1}) {player.Inventory[i].Name} (+{player.Inventory[i].Value} Gold)");
                }

                int itemIndex = int.Parse(Console.ReadLine()) - 1;

                if (itemIndex >= 0 && itemIndex < player.Inventory.Count)
                {
                    Item itemToSell = player.Inventory[itemIndex];
                    player.Gold += itemToSell.Value;
                    Console.WriteLine($"You've sold {itemToSell.Name} for {itemToSell.Value} Gold.");
                    player.Inventory.RemoveAt(itemIndex);
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            }
            else
            {
                Console.WriteLine("You don't have any items to sell.");
            }
        }
    }
}
