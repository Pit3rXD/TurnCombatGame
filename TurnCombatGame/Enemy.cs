﻿using System;

namespace TurnCombatGame
{
    public class Enemy : PlayerBase
    {
        //Czyść takie niepotrzebne entery, dziwnie to wygląda
        public int EnemyChoice(PlayerBase playerBase, Enemy enemy)
        {
            int enemyChoice = Helpers.Random.Next(1, 11);
            switch (enemyChoice)
            {
                case int c when c >= 8:
                    int oldHp = HP;
                    HP = Heal(HP);
                    int heald = HP - oldHp;
                    Console.WriteLine($"The opponent heals for {heald} points. They now have {HP} HP.");
                    return 0;

                case int c when c >= 1:
                    int eDamage = Attack();
                    playerBase.HP -= eDamage;
                    Console.WriteLine($"The opponent attack for {eDamage} points. You now have {playerBase.HP} HP.");
                    return eDamage;

                default:
                    Console.WriteLine("The opponent hesitates...");
                    return 0;
            }
        }
    }
}
