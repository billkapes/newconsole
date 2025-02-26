class InventoryManagement
{
    static List<Product> inventory = new List<Product>();

    static void Main(string[] args)
    {
        // Adding some example products to the inventory
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
        if (inventory.Count == 0)
        {
            Console.WriteLine("No inventory.");
        }
        else
        {
            Console.WriteLine("Inventory:");
            foreach (var product in inventory)
            {
            Console.WriteLine(product);
            }
        }
    }

    private static void UpdateProduct()
    {
        // Prompt for product name and validate input
        Console.Write("Enter product name to update: ");
        string name = Console.ReadLine();
        var product = inventory.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        // If product is found, prompt for new details
        if (product != null)
        {
            Console.Write("Enter new price (leave blank to keep current price): ");
            string priceInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(priceInput))
            {
                product.Price = double.Parse(priceInput);
            }

            Console.Write("Enter new stock quantity (leave blank to keep current quantity): ");
            string stockInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(stockInput))
            {
                product.StockQuantity = int.Parse(stockInput);
            }

            Console.WriteLine("Product updated successfully.");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }

    private static void RemoveProduct()
    {
        // Prompt for product name and validate input
        Console.Write("Enter product name to remove: ");
        string name = Console.ReadLine();
        var product = inventory.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        // If product is found, confirm removal
        if (product != null)
        {
            Console.Write("Are you sure you want to remove this product? (yes/no): ");
            string confirmation = Console.ReadLine();
            if (confirmation.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                inventory.Remove(product);
                Console.WriteLine("Product removed successfully.");
            }
            else
            {
                Console.WriteLine("Product removal canceled.");
            }
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }

    private static void AddProduct()
    {
        // Prompt for product name and validate input
        string name;
        do
        {
            Console.Write("Enter product name: ");
            name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Product name cannot be empty. Please enter a valid name.");
            }
        } while (string.IsNullOrWhiteSpace(name));

        // Check if the product already exists
        if (inventory.Any(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine("A product with this name already exists in the inventory.");
        }
        else
        {
            Console.Write("Enter product price: ");
            double price = double.Parse(Console.ReadLine());
            Console.Write("Enter stock quantity: ");
            int stockQuantity = int.Parse(Console.ReadLine());
            inventory.Add(new Product(name, price, stockQuantity));
            Console.WriteLine("Product added successfully.");
        }
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
