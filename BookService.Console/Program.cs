using System;
using System.Collections.Generic;
using System.Linq;
using Book.Services;

namespace BookServiceConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var myBooks = new BookService();
            var books = new List<int>{1,3,5,2,3};

            Console.Write("Books ");
            books.ForEach(b => Console.Write($"{b} "));
            Console.WriteLine($"Total cost {myBooks.GetPrice(books.ToArray()).ToString("N")} €");
        }
    }
}
