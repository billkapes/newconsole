using System;
using System.Collections.Generic;

class LibraryManager
{
    static Dictionary<string, int> userBorrowedBookCount = new Dictionary<string, int>();
    static Dictionary<string, List<string>> userBorrowedBookList = new Dictionary<string, List<string>>();

    static void Main()
    {
        List<string> availableBooks = new List<string>(5);
        while (true)
        {
            Console.WriteLine("Would you like to add, remove, search for a book, borrow a book, return a book, or exit? (add/remove/search/borrow/return/exit)");
            string action = Console.ReadLine().ToLower();
            if (action == "add")
            {
                AddBook(availableBooks);
            }
            else if (action == "remove")
            {
                RemoveBook(availableBooks);
            }
            else if (action == "search")
            {
                SearchBook(availableBooks);
            }
            else if (action == "borrow")
            {
                BorrowBook(availableBooks);
            }
            else if (action == "return")
            {
                ReturnBook(availableBooks);
            }
            else if (action == "exit")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid action. Please type 'add', 'remove', 'search', 'borrow', 'return', or 'exit'.");
            }
            // Display the list of books
            Console.WriteLine("Available books:");
            foreach (string book in availableBooks)
            {
                Console.WriteLine(book);
            }
        }
    }

    static void AddBook(List<string> availableBooks)
    {
        if (availableBooks.Count >= 5)
        {
            Console.WriteLine("The library is full. No more books can be added.");
        }
        else
        {
            Console.WriteLine("Enter the title of the book to add:");
            string newBook = Console.ReadLine();
            availableBooks.Add(newBook);
        }
    }

    static void RemoveBook(List<string> availableBooks)
    {
        if (availableBooks.Count == 0)
        {
            Console.WriteLine("The library is empty. No books to remove.");
        }
        else
        {
            Console.WriteLine("Enter the title of the book to remove:");
            string bookToRemove = Console.ReadLine();
            if (availableBooks.Remove(bookToRemove))
            {
                Console.WriteLine("Book removed.");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }
    }

    static void SearchBook(List<string> availableBooks)
    {
        Console.WriteLine("Enter the title of the book to search:");
        string bookToSearch = Console.ReadLine();
        if (availableBooks.Contains(bookToSearch))
        {
            Console.WriteLine("The book is available.");
        }
        else
        {
            Console.WriteLine("The book is not in the collection.");
        }
    }

    static void BorrowBook(List<string> availableBooks)
    {
        Console.WriteLine("Enter your name:");
        string userName = Console.ReadLine();
        if (userBorrowedBookCount.ContainsKey(userName) && userBorrowedBookCount[userName] >= 3)
        {
            Console.WriteLine("You have already borrowed 3 books. Please return a book before borrowing a new one.");
            return;
        }

        Console.WriteLine("Enter the title of the book to borrow:");
        string bookToBorrow = Console.ReadLine();
        if (availableBooks.Contains(bookToBorrow))
        {
            availableBooks.Remove(bookToBorrow);
            if (userBorrowedBookCount.ContainsKey(userName))
            {
                userBorrowedBookCount[userName]++;
                userBorrowedBookList[userName].Add(bookToBorrow);
            }
            else
            {
                userBorrowedBookCount[userName] = 1;
                userBorrowedBookList[userName] = new List<string> { bookToBorrow };
            }
            Console.WriteLine("Book borrowed.");
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }

    static void ReturnBook(List<string> availableBooks)
    {
        Console.WriteLine("Enter your name:");
        string userName = Console.ReadLine();
        if (!userBorrowedBookCount.ContainsKey(userName) || userBorrowedBookCount[userName] == 0)
        {
            Console.WriteLine("You have no borrowed books to return.");
            return;
        }

        Console.WriteLine("Enter the title of the book to return:");
        string bookToReturn = Console.ReadLine();
        if (userBorrowedBookList[userName].Contains(bookToReturn))
        {
            availableBooks.Add(bookToReturn);
            userBorrowedBookCount[userName]--;
            userBorrowedBookList[userName].Remove(bookToReturn);
            Console.WriteLine("Book returned.");
        }
        else
        {
            Console.WriteLine("You did not borrow this book.");
        }
    }
}
