using BooksProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowAuthorsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            BooksLoader loader = new BooksLoader();
            var authors = loader.GetAllAuthors();

            // 1.What is the average number of books per autors?        
            Console.WriteLine("1.What is the average number of books per autors?");
            Console.WriteLine();

            var averageNumberOfBooks = authors.Average(author => author.Books.Count());

            Console.WriteLine($"Average number of books per author is {string.Format("{0:0.00}", averageNumberOfBooks)}.");

            Console.WriteLine();
            Console.WriteLine("--------------");
            Console.WriteLine();

            //2.Which book(s) has the longest title, and how long is it ?

            Console.WriteLine("2.Which book(s) has the longest title, and how long is it ?");
            Console.WriteLine();

            var booksTitle = authors.SelectMany(a => a.Books
            .Select(b => new
            {
                b.Title,
                TitleLength = b.Title.Count()
            })).OrderByDescending(t => t.TitleLength).First();

            Console.WriteLine($@"The longest book title is: ""{booksTitle.Title}""with length of {booksTitle.TitleLength} chars.    ");

            Console.WriteLine();
            Console.WriteLine("--------------");
            Console.WriteLine();

            //3. Which author has the shortest average title for a book?

            Console.WriteLine("3. Which author has the shortest average title for a book?");
            Console.WriteLine();

            var shortestAverageTitle = authors.Select(a => new
            {
                a.Name,
                AverageBookLength = a.Books.Average(book => book.Title.Count())
            }).OrderBy(b => b.AverageBookLength);

            Console.WriteLine($"Author that has shortest average title for a book is {shortestAverageTitle.First().Name} with length of the title: {shortestAverageTitle.First().AverageBookLength}");

            Console.WriteLine();
            Console.WriteLine("--------------");
            Console.WriteLine();

            //4. Which author has the shortest average title for a book? (Discount authors with less than three books)

            Console.WriteLine("4. Which author has the shortest average title for a book? (Discount authors with less than three books)");
            Console.WriteLine();

            var shortestAverageTitleWithDiscount = authors.Where(author => author.Books.Count() > 3)
                    .Select(a => new
                    {
                        a.Name,
                        AverageBookLength = a.Books.Average(book => book.Title.Length)
                    }).OrderBy(book => book.AverageBookLength).First();

            Console.WriteLine($"Author that has shortest average title for a book with discount auhors with less than three books is {shortestAverageTitleWithDiscount.Name} \nwith length of the title: {string.Format("{0:0.00}", shortestAverageTitleWithDiscount.AverageBookLength)}.");

            Console.WriteLine();
            Console.WriteLine("--------------");
            Console.WriteLine();

            //5.What series has the most books?

            Console.WriteLine("5.What series has the most books?");
            Console.WriteLine();

            var seriesWithMostBooks = authors.SelectMany(a => a.Books)
                    .GroupBy(b => b.Series)
                    .Select(series => new
                    {
                        series.Key,
                        Count = series.Where(s => !string.IsNullOrEmpty(s.Series)).Count()
                    })
                    .OrderByDescending(s => s.Count).First();

            Console.WriteLine("Series with most books is: {0} with {1} books.", seriesWithMostBooks.Key, seriesWithMostBooks.Count);

            Console.WriteLine();
            Console.WriteLine("--------------");
            Console.WriteLine();

            //6.Which year has the most books published?

            Console.WriteLine("6. Which year has the most books published?");
            Console.WriteLine();

            var booksPerYear = authors.SelectMany(a => a.Books)
                    .GroupBy(b => b.Year)
                    .Select(g => new { g.Key, Count = g.Count() })
                    .OrderByDescending(g => g.Count);

            var yearWithMostPublishing = booksPerYear.First();

            Console.WriteLine($"In {yearWithMostPublishing.Key}, {yearWithMostPublishing.Count} books have been published.");

            Console.WriteLine();
            Console.WriteLine("--------------");
            Console.WriteLine();

            //7. What is the average number of books published for years in the 21st centrury ? (Starting with 2001, not 2000)

            Console.WriteLine("7. What is the average number of books published for years in the 21st centrury ? (Starting with 2001, not 2000)");
            Console.WriteLine();

            var twentyFirstCentrury = booksPerYear
                    .Where(year => year.Key > 2000)
                    .OrderBy(y => y.Key)
                    .Average(y => y.Count);

            Console.WriteLine("The average number of books published for years in the 21st centrury is: {0} books.", twentyFirstCentrury);

            Console.WriteLine();
            Console.WriteLine("--------------");
            Console.WriteLine();

            //8. Which author has the most different series?

            Console.WriteLine("8. Which author has the most different series?");
            Console.WriteLine();

            var seriesAuthors = authors.Select(a => new
            {
                a.Name,
                NumberOfSeries = a.Books.Where(b => !string.IsNullOrEmpty(b.Series)).GroupBy(b => b.Series).Distinct().Count()
            }).OrderByDescending(b => b.NumberOfSeries);

            Console.WriteLine("There is two authors with same number of different series:");
            Console.WriteLine($"Author: {seriesAuthors.First().Name} with {seriesAuthors.First().NumberOfSeries} series.");
            Console.WriteLine($"Author: {seriesAuthors.Skip(1).First().Name} with {seriesAuthors.Skip(1).First().NumberOfSeries} series.");

            Console.WriteLine();
            Console.WriteLine("--------------");
            Console.WriteLine();

            //9. Which author has the most books written that belong to a series?

            Console.WriteLine("9. Which author has the most books written that belong to a series?");
            Console.WriteLine();

            var booksWithSeries = authors.Select(author => new
            {
                author.Name,
                Series = author.Books.Where(book => !string.IsNullOrEmpty(book.Series)).Count()
            }).OrderByDescending(b => b.Series).First();

            Console.WriteLine($"Author that has the most books written that belong to a series is: {booksWithSeries.Name} with {booksWithSeries.Series} series.");

            Console.WriteLine();
            Console.WriteLine("--------------");
            Console.WriteLine();

            //10. Which author has the longest career?

            Console.WriteLine("10. Which author has the longest career?");
            Console.WriteLine();

            var longestCarreer = authors.Select(a => new
            {
                a.Name,
                YearOfCarrer = a.Books.Max(b => b.Year) - a.Books.Min(b => b.Year)
            }).OrderByDescending(y => y.YearOfCarrer).First();

            Console.WriteLine($"The author {longestCarreer.Name} has the longest carrer of {longestCarreer.YearOfCarrer} years!");

            Console.WriteLine();
            Console.WriteLine("--------------");
            Console.WriteLine();

            //Bonus
            //1. What series has the most authors?
            /*
            Console.WriteLine("1. What series has the most authors?");
            Console.WriteLine();

            var seriesWithMostAuthors = authors.SelectMany(author => author.Books)
                .Where(b => !string.IsNullOrEmpty(b.Series) && b.SeriesIndex != null)
                .Select(book => new
                {
                    book.Title,
                    NameOfAuthor = authors.Where(a => a.Books.Contains(book)).First().Name
                }).GroupBy(t => t.Title).OrderByDescending(s => s.Count()).First();
        

            Console.WriteLine($@"The series ""{seriesWithMostAuthors.Key}"" has {seriesWithMostAuthors.Count()} authors.");

            Console.WriteLine();
            Console.WriteLine("--------------");
            Console.WriteLine();

            //2. In Which year most authors published a book?

            Console.WriteLine("2. In Which year most authors published a book?");
            Console.WriteLine();

            var authorsPerYear = authors.SelectMany(a => a.Books)
                 .GroupBy(b => b.Year)
                 .Select(year => year.Key)
                 .Select(year => new
                 {
                     Year = year,
                     AuthorNumber = authors.Select(a => new
                     {
                         Years = a.Books.Select(b => b.Year).Distinct()
                     }).Where(a => a.Years.Contains(year))
                 }).OrderByDescending(y => y.AuthorNumber.Count()).First();

            Console.WriteLine($"In {authorsPerYear.Year} total {authorsPerYear.AuthorNumber.Count()} authors have published book.");

            Console.WriteLine();
            Console.WriteLine("--------------");
            Console.WriteLine();
            */
            // 3. Which author has the highest average books per year?

            Console.WriteLine("3. Which author has the highest average books per year?");
            Console.WriteLine();

            var highestBooksPerYear = authors.Select(author => new
            {
                author.Name,
                HighestAverage = author.Books
                .GroupBy(b => b.Year)
                .Average(book => book.Count())
            }).OrderByDescending(b => b.HighestAverage).First();

            Console.WriteLine($"Author with the highest average books per year is: {highestBooksPerYear.Name} with {highestBooksPerYear.HighestAverage} books.");

            Console.WriteLine();
            Console.WriteLine("--------------");
            Console.WriteLine();

            // 4. How long is the longest hiatus between two books for an author, and by whom?

            #region Books with two authors
            //5. books with two authors


            var booksWithTwoAuthors = authors
                .SelectMany(a => a.Books)
                .GroupBy(b => b.Title)
                .Where(g => g.Count() ==2)
                .Select(g => new {
                    booktitle = g.Key       
                }).Distinct();

            Console.WriteLine(booksWithTwoAuthors);

            var nameOFBOOK = "So Vile a Sin";

            var nesto = authors.Select(a => new
            {
                a.Name,
                BooksTitles = a.Books.Select(b => b.Title)
            });

           
            var authorsNames = nesto.Select(n => new
            {               
                Authors = nesto.Where(w => w.BooksTitles.Contains(nameOFBOOK)).Select(a => new { a.Name })
            }).First().Authors;

            string authorInitials = ""; 

            foreach (var item in authorsNames)
            {
                authorInitials += string.Join("", item.Name.Split(' ').Select(p => p[0])).ToString();
            }

            Console.WriteLine(authorInitials.ToLower());

            Console.ReadLine();
            #endregion
        }

        static void PrintGroups<TKey, TItem>(IEnumerable<IGrouping<TKey, TItem>> groups)
        {
            foreach (var group in groups)
            {
                Console.WriteLine("Title:" + group.Key);
                foreach (var item in group)
                {
                    Console.WriteLine($"Other:  {item}");
                }
            }
        }

        static void PrintAuthors<T>(IEnumerable<T> authors)
        {
            foreach (var author in authors)
            {
                Console.WriteLine(author);
            }
            Console.WriteLine("---------------");
        }

    }
}
