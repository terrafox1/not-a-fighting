using System;
using System.Threading;

namespace CSLight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Fighter[] fighters =
            {
                new Fighter("Варвар", 500, 0, 50),
                new Fighter("Рыцарь", 250, 35, 20),
                new Fighter("Ассасин", 150, 10, 100),
                new Fighter("Олег", 300, 5, 750)
            };

            int fighterNumber;

            for (int i = 0; i < fighters.Length; i++)
            {
                Console.Write(i + 1 + " ");
                fighters[i].ShowStats();
            }

            Console.WriteLine("\n" + new string('-', 42));
            Console.Write("\nВыберите первого бойца, введя его номер: ");
            fighterNumber = Convert.ToInt32(Console.ReadLine()) - 1;
            Fighter firstFighter = fighters[fighterNumber];

            Console.Write("\nВыберите второго бойца, введя его номер: ");
            fighterNumber = Convert.ToInt32(Console.ReadLine()) - 1;
            Fighter secondFighter = fighters[fighterNumber];
            Console.WriteLine("\n" + new string('-', 42));

            while (firstFighter.Health > 0 && secondFighter.Health > 0)
            {
                firstFighter.TakeDamage(secondFighter.Damage);
                secondFighter.TakeDamage(firstFighter.Damage);
                firstFighter.ShowCurrentHealth();
                secondFighter.ShowCurrentHealth();
                Console.WriteLine();
                Thread.Sleep(300);
            }

            if (firstFighter.Health > 0)
            {
                Console.WriteLine($"{firstFighter.Name} победил");
            }
            else
            {
                Console.WriteLine($"{secondFighter.Name} победил");
            }
            Console.ReadKey();
        }

        class Fighter
        {
            private string _name;
            private int _health;
            private int _damage;
            private int _armor;

            public int Health
            {
                get
                {
                    return _health;
                }
            }

            public int Damage
            {
                get
                {
                    return _damage;
                }
            }

            public string Name
            {
                get
                {
                    return _name;
                }
            }

            public Fighter(string name, int health, int armor, int damage)
            {
                _name = name;
                _health = health;
                _armor = armor;
                _damage = damage;
            }

            public void ShowStats()
            {
                Console.WriteLine($"Боец - {_name}, здоровье: {_health}, броня: {_armor}, наносимый урон: {_damage}");
            }

            public void ShowCurrentHealth()
            {
                Console.WriteLine($"{_name} здоровье: {_health}");
            }

            public void TakeDamage(int damage)
            {
                _health -= damage - _armor;
            }
        }
    }
}