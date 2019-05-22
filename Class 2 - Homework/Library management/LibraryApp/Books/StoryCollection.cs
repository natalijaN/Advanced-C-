using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class StoryCollection : Book
    {
        public string Author { get; set; }
        public List<Story> Stories = new List<Story>();

        public override long GenerateISBN()
        {
            return ISBN = Convert.ToInt64(this.GenerateRandomISBN(13));
        }

        public StoryCollection(int id, string title, TypesOfEdition types, int numberOfPages, string author)
        {
            ID = id;
            Title = title;
            Types = types;
            NumberOfPages = numberOfPages;
            Author = author;
            ISBN = GenerateISBN();
        }

        public override string ToString()
        {
            Console.WriteLine($"Type of book: {GetTypeOfBook()}");
            var result = $"Title: {Title} -> Author: {Author} -> Number of Stories: {Stories.Count}\n";

            return result;
        }

        public override string GetTypeOfBook()
        {
            return "Story Collection";
        }

        public override string ViewAllBooks()
        {
            return $"Type of Book: {GetTypeOfBook()}: Title: {Title} -> Author: {Author} -> Type of Edition: {Types}!";
        }
    }
}
