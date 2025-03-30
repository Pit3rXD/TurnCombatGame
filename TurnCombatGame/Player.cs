using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnCombatGame
{
    class Player
    {
        static readonly Random random = new Random();
        
        public static string PlayerName()
        {
            Console.WriteLine("Hello, what should I call youfor the rest od the game?");
            string playerName = Console.ReadLine();
            Console.WriteLine($"Welcome {playerName}! In a moment, you will engage in an amazing battle.");
            Console.WriteLine("\n");
            return playerName;
        }
        public static int PlayerStats()
        {
            int playerHp = 10;
            return playerHp;
        }
        public static int PlayerAttack()
        {
            int playerAttack = random.Next(0, 4);
            return playerAttack;
        }
        public static int PlayerHeal(int playerHp)
        {
            int playerHeal = random.Next(1, 4);
            return playerHp + playerHeal ;
        }
    }
}
