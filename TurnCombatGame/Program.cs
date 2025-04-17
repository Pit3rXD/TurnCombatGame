using System;

namespace TurnCombatGame
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                PlayerBase playerBase = new PlayerBase();
                Enemy enemy = new Enemy();

                Console.WriteLine("");
                Console.WriteLine("In a moment, you will engage in an amazing battle with your opponent. Pleas enter your name.");
                string pName = Console.ReadLine();
                Console.WriteLine($"\nWelcome, {pName}!\n");

                while (playerBase.HP > 0 && enemy.HP > 0)
                {
                    Console.WriteLine($"Your HP: {playerBase.HP} | Enemy HP: {enemy.HP}");
                    char pChoice;
                    while (true)
                    {
                        Console.WriteLine($"Are you attacking(a) or healing(h)?");
                        string input = Console.ReadLine();
                        try
                        {
                            if (string.IsNullOrEmpty(input) || input.Length != 1)
                                throw new Exception("Inwalid input. Please enter a single character: 'a' or 'h'.");

                            pChoice = Convert.ToChar(input.ToLower());
                            if (pChoice != 'a' && pChoice != 'h')
                                throw new Exception("Only 'a' (attack) or 'h' (heal) are valid choices.");
                            break;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    int pDamage = playerBase.MoveOnChoice(pChoice, enemy, playerBase);
                    if (pChoice == 'a')
                    {
                        Console.WriteLine($"You attack for {pDamage} points. The opponent now has {enemy.HP} health points.");

                    }
                    if (pChoice == 'h' && playerBase.HP > 10)
                    {
                        Console.WriteLine($"You have reached maximum HP");
                    }

                    if (enemy.HP <= 0)
                    {
                        Console.WriteLine("You win!");
                        break;
                    }

                    int eEffect = enemy.EnemyChoice(playerBase, enemy);
                    if (playerBase.HP <= 0)
                    {
                        Console.WriteLine("You have been defeated!");
                        break;
                    }
                    Console.WriteLine("------------------------------------------------");
                }
                char yesOrNo;
                while (true)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine($"{pName}, would you like to try again? (y/n)");
                    string again = Console.ReadLine();
                    try
                    {
                        if (string.IsNullOrEmpty(again) || again.Length != 1)
                            throw new Exception("Invalid input. Pleas enter a single character: 'y' or 'n'.");

                        yesOrNo = Convert.ToChar(again.ToLower());
                        if (yesOrNo != 'y' && yesOrNo != 'n')
                            throw new Exception("Only 'y' (yes) or 'n' (no) are valid choices.");
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                if (yesOrNo == 'y')
                {
                    continue;
                }
                else if (yesOrNo == 'n')
                {
                    Console.WriteLine("Thanks for playing!");
                    break;
                }
            }
        }
    }
}
