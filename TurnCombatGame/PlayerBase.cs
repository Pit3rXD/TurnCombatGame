using System;

namespace TurnCombatGame
{
    public class PlayerBase
    {
        public int HP { get; set; } = 10;
        public int MoveOnChoice(char choice, Enemy enemy, PlayerBase playerBase)
        {
            switch (choice)
            {
                case 'a':
                    int pDamage = Attack();
                    enemy.HP -= pDamage;
                    return pDamage;
                    
                case 'h':
                    int oldHp = HP;
                    HP = Heal(HP);
                    int heald = HP - oldHp;
                    Console.WriteLine($"You heald for {heald} points. You now have {HP} health points.");
                    return 0;
                    
                default:
                    throw new Exception("Invalid input");
            }
        }

        internal int Attack()
        {
            int playerAttack = Helpers.Random.Next(0, 4);
            return playerAttack;
        }
        internal int Heal(int healthPoints)
        {
            int playerHeal = Helpers.Random.Next(1, 4);
            healthPoints += playerHeal;
            return Math.Min(healthPoints, 10);
        }
    }
}
