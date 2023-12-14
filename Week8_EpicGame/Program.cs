

//string folderPath = @"C:\Users\Dell\source\repos\DATA_WEEK_8";
//string heroFile = "heroes.txt";
//string villainsFile = "villains.txt";

//string[] heroes = File.ReadAllLines(Path.Combine(folderPath, heroFile));
//string[] villains = File.ReadAllLines(Path.Combine(folderPath, villainsFile));

internal class Program
{
    private static void Main(string[] args)
    {
        string[] heroes = { "Harry Potter", "Luke Skywalker", "Lara Croft", "Bilbo Baggins", "Scooby-Doo", "Jessie" };
        string[] villains = { "Voldemort", "Darth Vader", "Dracula", "Joker", "Sauron", "Walter White" };
        string[] weapons = { "magic wand", "plastic fork", "banana", "sword", "chemicals", "book" };


        string hero = GetRandomValueFromArray(heroes);
        string heroWeapon = GetRandomValueFromArray(weapons);
        int heroHP = GetCharacterHP(hero);
        int heroStrikeStrenght = heroHP;
        Console.WriteLine($"Today {hero} ({heroHP} HP) with {heroWeapon} saves the day!");

        string villain = GetRandomValueFromArray(villains);
        string villainWeapon = GetRandomValueFromArray(weapons);
        int villainHP = GetCharacterHP(villain);
        int villainStrikeStrenght = villainHP;
        Console.WriteLine($"Today {villain} ({villainHP} HP) with {villainWeapon} tries to take over the world!");

        while(heroHP > 0 && villainHP > 0)
        {
            heroHP = heroHP - Hit(villain, villainStrikeStrenght);
            villainHP = villainHP - Hit(hero, heroStrikeStrenght);
        }

        Console.WriteLine($" Hero {hero} HP: {heroHP}");
        Console.WriteLine($" Villain {villain} HP: {villainHP}");



        if (heroHP > 0)
        {
            Console.WriteLine($"{hero} saves the day!");
        }
        else if (villainHP > 0)
        {
            Console.WriteLine($"{villain} defeats {hero}!");
        }
        else
        {
            Console.WriteLine("Draw!");
        }

        static string GetRandomValueFromArray(string[] someArray)
        {
            Random rnd = new Random();
            int randomIndex = rnd.Next(someArray.Length);
            string randomStringFromArray = someArray[randomIndex];
            return randomStringFromArray;
        }

        static int GetCharacterHP(string characterName)
        {
            if (characterName.Length < 10)
            {
                return 10;
            }
            else
            {
                return characterName.Length;
            }
        }


        static int Hit(string characterName, int characterHP)
        {
            Random rnd = new Random();
            int strike = rnd.Next(0, characterHP);

            if(strike == 0)
            {
                Console.WriteLine($"{characterName} missed the target!");
            }
            else if(strike == characterHP -1)
            {
                Console.WriteLine($"{characterName} made a critical hit!");
            }
            else
            {
                Console.WriteLine($"{characterName} hit {strike}!");
            }
            return strike;
        }
    }
}