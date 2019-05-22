using BookLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    class Program
    {
      
        static void Main(string[] args)
        {
            string welcome = "Welcome in Book Library!";
            var bookCollection = BooksCollection.InitializeLibrary(welcome);

            Console.WriteLine("If you want to view all Books -> Press 1");
            Console.WriteLine("If you want to view all Novels -> Press 2");
            Console.WriteLine("If you want to view all Story collection -> Press 3");
            Console.WriteLine("If you want to view all Anthologies -> Press 4");

            int userChoise = Convert.ToInt32(Console.ReadLine());

            bookCollection.ShowAllBooks(userChoise);
            Console.ReadLine();
        }       
    }
}
