public interface IAnimal
{
    void Eat();
}

public class Program
{
    public static void Main()
    {
        List<Animal> animals = new List<Animal>();
        animals.Add(new Dog());
        animals.Add(new Cat());

        foreach (Animal animal in animals)
        {
            animal.MakeSound();
            animal.Eat();
        }


    }
}

public class Animal : IAnimal
{
    public virtual void MakeSound()
    {
        Console.WriteLine("Animal makes a sound");
    }
    
    public void Eat()
    {
        Console.WriteLine("Animal eats");
    }
}


public class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Dog barks");
    }

    public  void Eat()
    {
        Console.WriteLine("Dog eats");
    }
}

public class Cat : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Cat meows");
    }

    public  void Eat()
    {
        Console.WriteLine("Cat eats");
    }
}