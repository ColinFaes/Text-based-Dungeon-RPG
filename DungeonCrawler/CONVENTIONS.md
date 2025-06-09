Strings in camelCase:
> Wel: string camelCase; | niet: string CamelCase;
----------------------------------------------

Functies in PascalCase: 
> Wel: PascalCase() | niet: pascalCase();
----------------------------------------------

Items van arrays of lijsten onder elkaar:
```csharp
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
```
Fout:
```csharp
string[] npcNames = { "Old Merchant", "Mysterious Stranger", "Wandering Sage" };
string[] npcGreetings = { "Welcome traveler! I have rare items for sale.", "Greetings, hero. Do you seek knowledge?", "Ah, a brave soul! I have some advice for you." };
```
----------------------------------------------

Whitespace gebruiken om code overzichtelijk te houden door lege regels te laten tussen stukkken code die bij elkaar horen:
```csharp
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
```
Fout:
```csharp
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
```
Let op! als de if statements if else statements zijn, dan horen ze wel bij elkaar en is het niet nodig om een lege regel tussen de if en else te zetten.
----------------------------------------------
----------------------------------------------
Haakjes van if-statements niet op dezelfde regel als de if-statement:
```csharp
if (player.Health <= 0)
{
	Console.WriteLine("You have died. Game over.");
	Environment.Exit(0);
}
```
Fout:
```csharp
if (player.Health <= 0) {
	Console.WriteLine("You have died. Game over.");
	Environment.Exit(0);
}

if (player.Health <= 0) { Console.WriteLine("You have died. Game over."); Environment.Exit(0); }
```
----------------------------------------------
Als je een nieuwe klasse maakt moet je daar een apart bestand voor maken. Dus niet alles in Program.cs zetten, maar bijvoorbeeld een Player.cs of Enemy.cs aanmaken om de klasses daarin te definiëren.

----------------------------------------------
