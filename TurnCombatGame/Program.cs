using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnCombatGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Player.PlayerName();
            int pHp = Player.PlayerStats();
            int eHp = Enemy.EnemyHp();
           

            while (pHp > 0 && eHp > 0)
            {
                int pHeal = Player.PlayerHeal(pHp);
                int pAtt = Player.PlayerAttack();
                int eHeal = Enemy.EnemyHeal(eHp);
                int eAtt = Enemy.EnemyAttack();
                
                Console.WriteLine("Do you want to attack (a) or healt (h)");
                string choice = Console.ReadLine().ToLower();

                if (choice == "a")
                {
                    eHp -= pAtt;
                    Console.WriteLine($"{name} attacked for {pAtt} points. The opponent now has {eHp} health points.");

                }
                else if (choice == "h")
                {
                    if (pHp < 10)
                    {
                        pHp = Player.PlayerHeal(pHp);
                        Console.WriteLine($"{name} healed, restoring HP. They currently have {pHp} health points.");
                    }
                    else if (pHp > 10)
                    {
                        Console.WriteLine("You have maximum HP value.");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
                if (eHp > 0)
                {
                    int eChoice = Enemy.EnemyChoice();

                    if (eChoice == 1)
                    {
                        pHp -= eAtt;
                        Console.WriteLine($"Enemy attacked for {eAtt} points. {name} now has {pHp} health points.");
                        Console.WriteLine("\n");
                    }
                    else if (eChoice == 2  && eHp < 10)
                    {
                        eHp = Enemy.EnemyHeal(eHp);
                        Console.WriteLine($"Enemy healed, restoring HP. They currently have {eHp} health  points.");
                        Console.WriteLine("\n");
                    }
                }
            }
            if (pHp <= 0)
            {
                Console.WriteLine($"{name} has been defeated!");
            }
            else
            {
                Console.WriteLine($"{name} has won! Congratulations!");
            }
           
        }
    }
}
