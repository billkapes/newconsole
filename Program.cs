class InventoryManagement
{
    static List<Product> inventory = new List<Product>();

    static void Main(string[] args)
    {
        // Adding some products to the inventory
        inventory.Add(new Product("Laptop", 999.99, 10));
        inventory.Add(new Product("Smartphone", 499.99, 25));
        inventory.Add(new Product("Tablet", 299.99, 15));

        while (true)
        {
            Console.WriteLine("Inventory Management System");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Remove Product");
            Console.WriteLine("3. Update Product");
            Console.WriteLine("4. View Products");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                Console.Write("Enter your choice: ");
            }

            switch (choice)
            {
                case 1:
                    AddProduct();
                    break;
                case 2:
                    RemoveProduct();
                    break;
                case 3:
                    UpdateProduct();
                    break;
                case 4:
                    ViewProducts();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private static void ViewProducts()
    {
        // Displaying the inventory
        Console.WriteLine("Inventory:");
        foreach (var product in inventory)
        {
            Console.WriteLine(product);
        }
    }

    private static void UpdateProduct()
    {
        throw new NotImplementedException();
    }

    private static void RemoveProduct()
    {
        throw new NotImplementedException();
    }

    private static void AddProduct()
    {
        Console.Write("Enter product name: ");
        string name = Console.ReadLine();
        Console.Write("Enter product price: ");
        double price = double.Parse(Console.ReadLine());
        Console.Write("Enter stock quantity: ");
        int stockQuantity = int.Parse(Console.ReadLine());

        inventory.Add(new Product(name, price, stockQuantity));
        Console.WriteLine("Product added successfully.");
    }
}

class Product
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int StockQuantity { get; set; }

    public Product(string name, double price, int stockQuantity)
    {
        Name = name;
        Price = price;
        StockQuantity = stockQuantity;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Price: {Price:C}, Stock Quantity: {StockQuantity}";
    }
}
