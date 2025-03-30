using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnCombatGame
{
    class Enemy
    {
        static readonly Random random = new Random();
        public static int EnemyHp()
        {
            int enemyHp = 10;
            return enemyHp;
        }
        public static int EnemyAttack()
        {
            int enemyAttack = random.Next(0, 4);
            return enemyAttack;
        }
        public static int EnemyHeal(int enemyHp)
        {
            int enemyHeal = random.Next(1, 4);
            return enemyHp + enemyHeal;
        }
        public static int EnemyChoice()
        {
            int enemyChoice = random.Next(1, 3);
            return enemyChoice;
        }
    }
}
