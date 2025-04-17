using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
//Czyść te usingi. Prawy => Remove and sort Usings

namespace TurnCombatGame
{
    //Muszę pisać tak, bo github nie pozwala mi dodawać komentarzy tam gdzie chcę
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                PlayerBase playerBase = new PlayerBase();
                Enemy enemy = new Enemy();

                string pName = StartUpGameAndNamePlayer();

                //Spoko, ale te pętle while są dość długie i robi się spaghetti code, gdzie nie widać poszczególnych części co się po kolei dzieje
                //Ja bym to rozbił na kilka metod w miarę możliwości - nie żeby to jakkolwiek go skróciło, po prostu pozwoli komuś, kto nie zna
                //kodu wejść i zobaczyć, że składa się to z części:
                //-Początek gry i pobranie imienia od gracza
                //-Właściwa gra
                //-Pytamy czy jeszcze raz
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
                            //Bardzo fajnie obsłużone exeptionami, możesz też dopisać własne, albo użyć jakiegoś systemowego
                            //bo domyślnego Exeption nie powinno się używać (zwyczajnie nic nie mówi nikomu)

                            //Oba te ify w sumie mogłyby być jednym ale mnie osobiście podoba się że daje dwa różne komunikaty
                            if (string.IsNullOrEmpty(input) || input.Length != 1)
                                throw new InvalidDataException("Inwalid input. Please enter a single character: 'a' or 'h'.");

                            pChoice = Convert.ToChar(input.ToLower());
                            if (pChoice != 'a' && pChoice != 'h')
                                throw new InvalidDataException("Only 'a' (attack) or 'h' (heal) are valid choices.");
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
                //Oj trochę mi się nie podoba to wyjście z pętli przez break a potem continue - to trochę jak z "goto" - nie powinno się używać 
                //takich komend, które przenoszą cię w inne miejsce kodu - to bardzo mylące
                char yesOrNo = default;
                while (yesOrNo == default)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine($"{pName}, would you like to try again? (y/n)");
                    string again = Console.ReadLine();
                    try
                    {
                        //Odradza się używanie ifów bez klamerek - niektórzy się mylą przez to, nie uważam że to coś złego ale często się omija
                        if (string.IsNullOrEmpty(again) || again.Length != 1)
                        {
                            throw new InvalidDataException("Invalid input. Pleas enter a single character: 'y' or 'n'.");
                        }
                        else
                        {
                            var answer = Convert.ToChar(again.ToLower());
                            if (yesOrNo != 'y' && yesOrNo != 'n')
                            {
                                //Zwracaj uwagę na te podkreślniki zielone - visual studio podpowiada jak poprawić troszkę kod. 
                                // ja przez to przechodzę jak już skończę pisać i wszystko dziala. pojawia się komunikad jak najedziesz na to myszką
                                throw new InvalidDataException("Only 'y' (yes) or 'n' (no) are valid choices.");
                            }
                            yesOrNo = answer;
                        }
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

        private static string StartUpGameAndNamePlayer()
        {
            Console.WriteLine("");
            Console.WriteLine("In a moment, you will engage in an amazing battle with your opponent. Pleas enter your name.");
            string pName = Console.ReadLine();
            Console.WriteLine($"\nWelcome, {pName}!\n");
            return pName;
        }
    }
}
