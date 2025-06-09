using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    [Serializable]
    public class Player
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackPower { get; set; }
        public int DefensePower { get; set; }
        public int Gold { get; set; }
        public List<Item> Inventory { get; set; }
        public Weapon CurrentWeapon { get; set; }
        public Armor CurrentArmor { get; set; }
        public string CurrentObjective { get; set; }

        public Player()
        {
            Inventory = new List<Item>();
        }

        public Player(string name)
        {
            Name = name;
            Health = 100;
            AttackPower = 10;
            DefensePower = 5;
            Gold = 0;
            Inventory = new List<Item>();
            CurrentWeapon = null;
            CurrentArmor = null;
            CurrentObjective = "Explore the dungeon, find the final bossroom and defeat the final boss.";
        }

        public void EquipWeapon(Weapon newWeapon)
        {
            if (CurrentWeapon != null)
            {
                AttackPower -= CurrentWeapon.Damage;

                Inventory.Add(CurrentWeapon);
                Console.WriteLine($"You unequip the {CurrentWeapon.Name} and place it back in your inventory.");
            }

            CurrentWeapon = newWeapon;
            AttackPower += newWeapon.Damage;

            Inventory.Remove(newWeapon);
            Console.WriteLine($"You equip the {newWeapon.Name}. Your attack power is now {AttackPower}.");
        }

        public void EquipArmor(Armor newArmor)
        {
            if (CurrentArmor != null)
            {

                DefensePower -= CurrentArmor.Defense;

                Inventory.Add(CurrentArmor);
                Console.WriteLine($"You unequip the {CurrentArmor.Name} and place it back in your inventory.");
            }

            CurrentArmor = newArmor;
            DefensePower += newArmor.Defense;

            Inventory.Remove(newArmor);
            Console.WriteLine($"You equip the {newArmor.Name}. Your defense power is now {DefensePower}.");
        }

        public void DisplayStats()
        {
            Console.WriteLine("===================================================================================");
            Console.WriteLine($"Objective: {CurrentObjective}");
            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.WriteLine($"Name: {Name}  |  Health: {Health}  |  Attack Power: {AttackPower}  |  Defense Power: {DefensePower}  |  Gold: {Gold}");
            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.WriteLine("Inventory:");

            if (Inventory.Count > 0)
            {
                for (int i = 0; i < Inventory.Count; i++)
                {
                    Item item = Inventory[i];
                    string valueDisplay = item.Value > 0 ? $"(+{item.Value})" : "";
                    Console.WriteLine($"  {item.Name} {valueDisplay}");
                }
            }
            else
            {
                Console.WriteLine("  Your inventory is empty.");
            }
            Console.WriteLine("===================================================================================");
        }

        public void DisplayHelp()
        {
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("HELP - Instructions for Playing Forgotten Dungeons");
            Console.WriteLine("====================================");
            Console.WriteLine("\n- Move through the dungeon by entering rooms.");
            Console.WriteLine("- Fight enemies, solve puzzles, and collect items.");
            Console.WriteLine("- You can choose from the following actions during battles:");
            Console.WriteLine("   (1) Attack: Attack the enemy.");
            Console.WriteLine("   (2) Use Item: Use an item from your inventory.");
            Console.WriteLine("   (3) Examine Environment: Check the room for hidden objects.");
            Console.WriteLine("   (4) Flee: Attempt to escape from the enemy.");
            Console.WriteLine("- Don't forget to use your weapons and armor wisely.");
            Console.WriteLine("- The goal of the game is to navigate through the dungeon and defeat the final boss.");
            Console.WriteLine("\n- At any time, you can see the current game objective on the screen.");
            Console.WriteLine("\n- Type 'help' if you want to see these instructions again.");
            Console.WriteLine("====================================");
            Console.WriteLine("\nPress Enter to return to the game...");
            Console.ReadLine();
            Console.Clear();
        }

        public void Attack(Enemy enemy)
        {
            int damageDealt = Math.Max(1, AttackPower - enemy.DefensePower);
            Console.WriteLine($"You attack the {enemy.Name} for {damageDealt} damage.");
            enemy.Health -= damageDealt;
        }

        public void AddItem(Item item)
        {
            Inventory.Add(item);
            Console.WriteLine($"You found a {item.Name} and added it to your inventory.");
        }

        public void UseItem(Item item)
        {
            if (item is Weapon weapon)
            {
                EquipWeapon(weapon);
            }
            else if (item is Armor armor)
            {
                EquipArmor(armor);
            }
            else
            {
                item.Use(this);
                Inventory.Remove(item);
            }
        }

        public void ExamineEnvironment(Room room)
        {
            Console.WriteLine($"You examine the room: {room.Description}");

            if (room.HiddenItem != null)
            {
                Console.WriteLine($"You found a hidden {room.HiddenItem.Name}!");
                AddItem(room.HiddenItem);
                room.HiddenItem = null;
            }
        }

        public void SolvePuzzle(Puzzle puzzle)
        {
            Console.WriteLine($"You encounter a puzzle: {puzzle.Description}");
            Console.WriteLine("Enter the solution:");
            string solution = Console.ReadLine();
            Console.Clear();

            if (puzzle.CheckSolution(solution))
            {
                Console.WriteLine("You solved the puzzle!");
                if (puzzle.Reward != null)
                {
                    AddItem(puzzle.Reward);
                }
            }
            else
            {
                Console.WriteLine("Incorrect solution. You feel a sense of dread.");
                Console.WriteLine("Your HP got reduced by 10.");
                Health -= 10;
            }
        }
    }
}
