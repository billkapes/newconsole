using System.Threading.Tasks;

public class Program { 
   
    public static async Task Main()
    {
        string book1 = "";
        string book2 = "";
        string book3 = "";
        string book4 = "";
        string book5 = "";
        
        while (true)
        {
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Add a book");
            Console.WriteLine("2. Remove a book");
            Console.WriteLine("3. Display all books");
            Console.WriteLine("4. Exit");

            string option;
            int optionNumber;
            do
            {
                Console.WriteLine("Enter 1-4:");
                option = Console.ReadLine();
            } while (!int.TryParse(option, out optionNumber) || optionNumber < 1 || optionNumber > 4);

            switch (option)
            {
                case "1":
                    AddBook(ref book1, ref book2, ref book3, ref book4, ref book5);
                    break;
                case "2":
                    RemoveBook(ref book1, ref book2, ref book3, ref book4, ref book5);
                    break;
                case "3":
                    DisplayBooks(book1, book2, book3, book4, book5);
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }


        static void AddBook(ref string book1, ref string book2, ref string book3, ref string book4, ref string book5)
        {
            Console.WriteLine("Please enter a book title:");
            string newBook = Console.ReadLine();

            if (string.IsNullOrEmpty(book1))
            {
                book1 = newBook;
            }
            else if (string.IsNullOrEmpty(book2))
            {
                book2 = newBook;
            }
            else if (string.IsNullOrEmpty(book3))
            {
                book3 = newBook;
            }
            else if (string.IsNullOrEmpty(book4))
            {
                book4 = newBook;
            }
            else if (string.IsNullOrEmpty(book5))
            {
                book5 = newBook;
            }
            else
            {
                Console.WriteLine("All book slots are full.");
            }
        }


        static void RemoveBook(ref string book1, ref string book2, ref string book3, ref string book4, ref string book5)
        {
            if (string.IsNullOrEmpty(book1) && string.IsNullOrEmpty(book2) && string.IsNullOrEmpty(book3) && string.IsNullOrEmpty(book4) && string.IsNullOrEmpty(book5))
            {
                Console.WriteLine("There are no books to remove.");
                return;
            }
            Console.WriteLine("Please enter the title of the book you want to remove:");
            string bookToRemove = Console.ReadLine();

            if (book1 == bookToRemove)
            {
            book1 = "";
            Console.WriteLine("Book removed.");
            }
            else if (book2 == bookToRemove)
            {
            book2 = "";
            Console.WriteLine("Book removed.");
            }
            else if (book3 == bookToRemove)
            {
            book3 = "";
            Console.WriteLine("Book removed.");
            }
            else if (book4 == bookToRemove)
            {
            book4 = "";
            Console.WriteLine("Book removed.");
            }
            else if (book5 == bookToRemove)
            {
            book5 = "";
            Console.WriteLine("Book removed.");
            }
            else
            {
            Console.WriteLine("Book not found.");
            }
        }

        static void DisplayBooks(string book1, string book2, string book3, string book4, string book5)
        {
            Console.WriteLine("List of books:");
            if (!string.IsNullOrEmpty(book1))
            {
                Console.WriteLine(book1);
            }
            if (!string.IsNullOrEmpty(book2))
            {
                Console.WriteLine(book2);
            }
            if (!string.IsNullOrEmpty(book3))
            {
                Console.WriteLine(book3);
            }
            if (!string.IsNullOrEmpty(book4))
            {
                Console.WriteLine(book4);
            }
            if (!string.IsNullOrEmpty(book5))
            {
                Console.WriteLine(book5);
            }
        }

    }
}
