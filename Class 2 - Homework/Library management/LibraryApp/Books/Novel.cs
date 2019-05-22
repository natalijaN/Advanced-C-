using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class Novel : Book
    {
        public class NovelSeries
        {
            public string Title { get; set; }

            public NovelSeries(string title)
            {
                Title = title;
            }

            public NovelSeries()
            {

            }

            public override string ToString()
            {
                return Title;
            }
        }

        public string Author { get; set; }
        public NovelSeries Series { get; set; } = new NovelSeries();
        public int SeriesNumber { get; set; }

        public Novel(int id, string title, TypesOfEdition types, int numberOfPages, string author)
        {
            ID = id;
            Title = title;
            Types = types;
            NumberOfPages = numberOfPages;
            Author = author;
            ISBN = GenerateISBN();
        }

        public override long GenerateISBN()
        {
            return ISBN = Convert.ToInt64(this.GenerateRandomISBN(13));
        }

        public override string ToString()
        {
            if (Series == null)
            {
                Series.Title = "";
                SeriesNumber = 0;
            }

            Console.WriteLine($"Type of book: {GetTypeOfBook()}!");

            var result = $"Title: {Title} -> Author: {Author} -> Series Title: {Series.Title} -> Series Number:{SeriesNumber}\n";
            return result;
        }

        public override string GetTypeOfBook()
        {
            return "Novel";
        }

        public override string ViewAllBooks()
        {
            return $"Type of Book: {GetTypeOfBook()}: Title: {Title} -> Author: {Author} -> Type of Edition: {Types}!";
        }
    }
}
