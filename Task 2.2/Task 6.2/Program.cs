using System;
using System.Text;

namespace FactoryMethodGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("~~~ РІВЕНЬ 1: Зачарований Ліс ~~~");
            EnemySpawner spawner = new ForestLevelSpawner();
            spawner.SpawnAndAttack();

            Console.WriteLine("\n~~~ РІВЕНЬ 2: Вулканічне Пекло ~~~");
            spawner = new LavaLevelSpawner();
            spawner.SpawnAndAttack();

            Console.ReadKey();
        }
    }

    public interface IEnemy
    {
        void Attack();
    }

    public class Goblin : IEnemy
    {
        public void Attack()
        {
            Console.WriteLine("Гоблін стрибає з кущів і кидає іржавий кинджал! Удар: 10 HP.");
        }
    }

    public class FireDragon : IEnemy
    {
        public void Attack()
        {
            Console.WriteLine("Дракон злітає та дихає полум'ям! Удар: 250 HP, Ви згоріли!");
        }
    }

    public abstract class EnemySpawner
    {
        public abstract IEnemy CreateEnemy();

        public void SpawnAndAttack()
        {
            Console.WriteLine("Заспавнено нового ворога на карті");
            IEnemy enemy = CreateEnemy(); 
            enemy.Attack();
        }
    }

    public class ForestLevelSpawner : EnemySpawner
    {
        public override IEnemy CreateEnemy()
        {
            return new Goblin(); 
        }
    }
    public class LavaLevelSpawner : EnemySpawner
    {
        public override IEnemy CreateEnemy()
        {
            return new FireDragon(); 
        }
    }
}