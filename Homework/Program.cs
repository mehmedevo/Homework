using System.Threading.Channels;
using System;
using System.Security.Cryptography.X509Certificates;
using Homework;
using System.ComponentModel;

namespace Homework
{
    public interface ICarnivore
    {
        void Hunt();
    }

    public interface IHerbivore
    {
        void Graze();
    }

    public abstract class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Species { get; set; }

        public abstract void MakeSound();
        public abstract void Move();

        public Animal(string name, int age, string species)
        {
            Name = name;
            Age = age;
            Species = species;
        }
    }

    class Lion : Animal, ICarnivore
    {
        public Lion(string name, int age) : base(name, age, "Lion")
        {
        }

        public void Hunt()
        {
            Console.WriteLine("The lion is hunting.");
        }

        public override void MakeSound()
        {
            Console.WriteLine("The lion is roaring.");
        }

        public override void Move()
        {
            Console.WriteLine("The lion is moving.");
        }
    }

    class Elephant : Animal, IHerbivore
    {
        public Elephant(string name, int age) : base(name, age, "Elephant")
        {
        }

        public void Graze()
        {
            Console.WriteLine("The elephant is grazing.");
        }

        public override void MakeSound()
        {
            Console.WriteLine("The elephant is trumpeting.");
        }

        public override void Move()
        {
            Console.WriteLine("The elephant is moving.");
        }
    }

    class Bird : Animal
    {
        public Bird(string name, int age) : base(name, age, "Bird")
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("The bird is singing.");
        }

        public override void Move()
        {
            Fly();
            Console.WriteLine("The bird is flying.");
        }

        public void Fly()
        {
            Console.WriteLine("Flying.");
        }
    }

    class Bear : Animal, IHerbivore, ICarnivore
    {
        public Bear(string name, int age) : base(name, age, "Bear")
        {
        }

        public void Graze()
        {
            Console.WriteLine("The bear is grazing.");
        }

        public void Hunt()
        {
            Console.WriteLine("The bear is hunting.");
        }

        public override void MakeSound()
        {
            Console.WriteLine("The bear is growling.");
        }

        public override void Move()
        {
            Console.WriteLine("The bear is moving.");
        }
    }

    public class Zoo
    {
        public List<Animal> Animals { get; private set; }

        public Zoo()
        {
            Animals = new List<Animal>();
        }

        public void AddAnimal(Animal animal)
        {
            Animals.Add(animal);
            Console.WriteLine($"{animal.Name} has been added to the zoo.");
        }

        public void MakeAllAnimalSound()
        {
            foreach (Animal animal in Animals)
            {
                animal.MakeSound();
                Console.WriteLine($"{animal.Name} is making a sound.");
            }
        }

        public void ListAllAnimals()
        {
            foreach (Animal animal in Animals)
            {
                Console.WriteLine($"Name: {animal.Name}, Age: {animal.Age}, Species: {animal.Species}");
            }
        }
    }
}

internal class Program

{
    static void Main(string[] args)
    {
        Zoo zoo = new Zoo();
        

        Animal lion = new Lion("Lion", 1);
        Animal elephant = new Elephant("Elephant", 1);
        Animal bird = new Bird("Bird", 1);
        Animal bear = new Bear("Bear", 1);

        zoo.AddAnimal(bear);
        zoo.AddAnimal(bird);
        zoo.AddAnimal(elephant);
        zoo.AddAnimal(lion);

        zoo.MakeAllAnimalSound();

    }

}


