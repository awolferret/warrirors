using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            Warrior warrior = new Warrior("Default", 1,1,1);
            warrior.Finghting();
        }
    }

    class Warrior
    {
        protected string Name;
        protected int Health;
        protected int Damage;
        protected int Armor;
        public int GetHealth { get; private set; }
        public int GetDamage { get; private set; }
        public Warrior(string name, int health, int damage, int armor)
        {
            Name = name;
            Health = health;
            Damage = damage;
            Armor = armor;
        }

        public void Finghting()
        {
            List<Warrior> FirstWarriors = new List<Warrior>();
            AddToList(FirstWarriors);
            List<Warrior> SecondWarriors = new List<Warrior>();
            AddToList(SecondWarriors);

            for (int i = 0; i < FirstWarriors.Count; i++)
            {
                Console.Write(i + 1 + " ");
                FirstWarriors[i].ShowInfo();
            }

            Console.WriteLine("Выберите первого бойца");
            string input = Console.ReadLine();
            int index;
            int.TryParse(input, out index);
            Warrior firstFihter = FirstWarriors[index - 1];
            Console.WriteLine("Выберите второго бойца");
            input = Console.ReadLine();
            int.TryParse(input, out index);
            Warrior secondFihter = SecondWarriors[index - 1];

            while (firstFihter.GetHealth > 0 && secondFihter.GetHealth > 0)
            {
                Console.WriteLine(" ");
                firstFihter.GetRandom();
                firstFihter.UseAbility();
                firstFihter.TakeDamage(secondFihter.GetDamage);
                secondFihter.UseAbility();
                firstFihter.GetRandom();
                secondFihter.TakeDamage(firstFihter.GetDamage);
                firstFihter.ShowInfo();
                secondFihter.ShowInfo();
            }
        }

        private void AddToList(List<Warrior> list)
        {
            list.Add(new Rogue("Rogue", 100, 50, 10));
            list.Add(new Cliric("Cliric", 200, 40, 25));
            list.Add(new Paladin("Paladin", 150, 45, 25));
            list.Add(new Ninja("Ninja", 80, 55, 5));
            list.Add(new Huntsman("Huntsman", 120, 50, 10));
        }

        public virtual void TakeDamage(int damage)
        {
            Health -= damage - Armor;
        }

        public int GetRandom()
        {
            Random random = new Random();
            int minRandomChance = 1;
            int maxRandomChance = 11;
            int randomChance = random.Next(minRandomChance, maxRandomChance);
            return randomChance;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name}, {Health} Здоровья, {Damage} Урона, {Armor} Брони");
        }

        public virtual void UseAbility()
        {
            
        }
    }

    class Rogue : Warrior
    {
        public Rogue(string name, int health, int damage, int armor) : base(name, health, damage, armor) 
        {

        }

        public void DealDoubleDamage()
        {
            int count = 0;
            int strike = 3;
            int multiplayer = 2;
            count++;

            if (count == strike)
            {
                Console.WriteLine("Разбойник нанес двойной урон");
                Damage *= multiplayer;
                count = 0;
            }
        }
    }

    class Cliric : Warrior
    {
        public Cliric(string name, int health, int damage, int armor) : base(name, health, damage, armor)
        {

        }

        public override void UseAbility()
        {
            int maxHealth = 200;
            int firstThird = 3;

            if (Health < maxHealth)
            {
                int randomChance = GetRandom();

                if (randomChance < firstThird)
                {
                    Console.WriteLine("Клирик исцелил себя");
                    Health += 50;
                }
            }
        }
    }

    class Paladin : Warrior
    {
        public Paladin(string name, int health, int damage, int armor) : base(name, health, damage, armor)
        {

        }

        public override void UseAbility() 
        {
            int randomChance = GetRandom();
            int half = 5;

            if (randomChance < half)
            {
                Console.WriteLine("Паладин получил баф ХП");
                Health += 25;
            }
            else if (randomChance == half)
            {
                Console.WriteLine("Паладин получил баф урона и ХП");
                Health += 50;
                Damage += 50;
            }
            else
            {
                Console.WriteLine("Паладин получил баф урона");
                Damage += 50;
            }
        }
    }

    class Ninja : Warrior
    {
        public Ninja(string name, int health, int damage, int armor) : base(name, health, damage, armor)
        {

        }

        public override void TakeDamage(int damage)
        {
            int randomChance = GetRandom();
            int firstThird = 3;

            if (randomChance < firstThird)
            {
                Console.WriteLine("Ниндзя увернулся от урона");
            }
            else
            {
                base.TakeDamage(damage);
            }
        }
    }

    class Huntsman : Warrior
    {
        public Huntsman (string name, int health, int damage, int armor) : base(name, health, damage, armor)
        {

        }

        public override void UseAbility()
        {
            int randomChance = GetRandom();
            int firstThird = 3;
            int dogDamage = 10;

            if (randomChance < firstThird)
            {
                Console.WriteLine("Охотник призвал на помощь собаку");
                Damage += dogDamage;
            }
        }
    }
}