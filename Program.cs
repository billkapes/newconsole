public class Person
{
    public string? Name { get; set; }
    public int Age { get; set; }

    public void Greet()
    {
        Console.WriteLine("Hello, my name is " + Name);
    }
}

public class Program
{
    public static void Main()
    {
        Person person1 = new Person();
        Person person2 = new Person();
        Person person3 = new Person();

        person1.Name = "John";
        person1.Age = 30;
        person2.Name = "Jane";
        person2.Age = 25;
        person3.Name = "Jack";
        person3.Age = 40;

        Console.WriteLine("Name: " + person1.Name + ", Age: " + person1.Age);
        Console.WriteLine("Name: " + person2.Name + ", Age: " + person2.Age);
        Console.WriteLine("Name: " + person3.Name + ", Age: " + person3.Age);
        person1.Greet();
        person2.Greet();
        person3.Greet();
    }
}