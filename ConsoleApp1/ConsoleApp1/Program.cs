using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            List<Warrior> warriors = new List<Warrior>();
            warriors.Add(new Rogue("Rogue", 100, 50, 10));
            warriors.Add(new Cliric("Cliric", 200, 40, 25));
            warriors.Add(new Paladin("Paladin", 150, 45, 25));
            warriors.Add(new Ninja("Minja", 80, 55, 5));
            warriors.Add(new Huntsman("Huntsman", 120, 50, 10));

            for (int i = 0; i < warriors.Count; i++)
            {
                Console.Write(i + 1 + " ");
                warriors[i].ShowInfo();
            }

            Console.WriteLine("Выберите первого бойца");
            string input = Console.ReadLine();
            int index;
            int.TryParse(input, out index);
            Warrior firstFihter = warriors[index - 1];
            Console.WriteLine("Выберите второго бойца");
            input = Console.ReadLine();
            int.TryParse(input, out index);
            Warrior secondFihter = warriors[index - 1];

            while (firstFihter.GetHealth() > 0 && secondFihter.GetHealth() > 0)
            {
                Console.WriteLine(" ");
                firstFihter.GetRandom();
                firstFihter.UseAbility();
                firstFihter.TakeDamage(secondFihter.GetDamage());
                secondFihter.UseAbility();
                firstFihter.GetRandom();
                secondFihter.TakeDamage(firstFihter.GetDamage());
                firstFihter.ShowInfo();
                secondFihter.ShowInfo();
            }
        }
    }

    class Warrior
    {
        protected string Name;
        protected int Health;
        protected int Damage;
        protected int Armor;

        public Warrior(string name, int health, int damage, int armor)
        {
            Name = name;
            Health = health;
            Damage = damage;
            Armor = armor;
        }

        public int GetHealth() 
        {
            return Health;
        }

        public int GetDamage()
        {
            return Damage;
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
            count++;

            if (count == 3)
            {
                Console.WriteLine("Разбойник нанес двойной урон");
                Damage *= 2;
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
            Console.WriteLine("Клирик исцелил себя");
            Health += 50;
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

            if (randomChance < 5)
            {
                Console.WriteLine("Паладин получил баф ХП");
                Health += 50;
            }
            else if (randomChance == 5)
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

            if (randomChance < 3)
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

            if (randomChance < 3)
            {
                Console.WriteLine("Охотник призвал на помощь собаку");
                int dogDamage = 10;
                Damage += dogDamage;
            }
        }
    }
}