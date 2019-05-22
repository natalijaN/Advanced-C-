using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class BooksCollection
    {
        public List<IBook> books { get; set; } = new List<IBook>();

        public void AddBooks(IBook book)
        {
            books.Add(book);
        }

        public void ShowAllBooks(int userChoise)
        {
            switch (userChoise)
            {
                case 1:
                    Console.WriteLine("All Books");
                    foreach (var book in books)
                    {
                        Console.WriteLine(book.ViewAllBooks());
                    }
                    break;
                case 2:
                    foreach (var book in books)
                    {
                        if (book.GetTypeOfBook() == "Novel")
                        {
                            Console.WriteLine(book.ToString());
                        }
                    }
                    break;
                case 3:
                    foreach (var book in books)
                    {
                        if (book.GetTypeOfBook() == "Story Collection")
                        {
                            Console.WriteLine(book.ToString());
                        }
                    }
                    break;
                case 4:
                    foreach (var book in books)
                    {
                        if (book.GetTypeOfBook() == "Anthology")
                        {
                            Console.WriteLine(book.ToString());
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Wrong input!");
                    break;
            }
        }


        public static BooksCollection InitializeLibrary(string message)
        {

            Console.WriteLine(message);
            Console.WriteLine();

            //Novels

            Novel novel1 = new Novel(1, "The Long Tomorrow", TypesOfEdition.Audiobook, 356, "Leigh Brackett");
            novel1.Series = new Novel.NovelSeries("Hainish Cycle");
            novel1.SeriesNumber = 2;

            Novel novel2 = new Novel(2, "Hard to Be a God", TypesOfEdition.EBook, 125, "Arkady StrugatskyBoris Strugatsky");

            //Story Collection

            StoryCollection collection1 = new StoryCollection(3, "Evensong", TypesOfEdition.Hardcover, 478, "Lester del Rey");

            Story story1 = new Story("Flies", Type.Novella, true);
            collection1.Stories.Add(story1);

            Story story2 = new Story("The Day After the Day the Martians Came", Type.ShortStory, false);
            collection1.Stories.Add(story2);


            StoryCollection collection2 = new StoryCollection(4, "Eutopia", TypesOfEdition.EBook, 145, "Lester del Rey");

            collection2.Stories.Add(new Story("Flies", Type.Novella, true));
            collection2.Stories.Add(new Story("The Day After the Day the Martians Came", Type.ShortStory, false));

            StoryCollection collection3 = new StoryCollection(5, "Incident in Moderan", TypesOfEdition.Paperback, 236, "David R. Bunch");

            collection3.Stories.Add(new Story("The Escaping", Type.Novella, true));
            collection3.Stories.Add(new Story("The Doll-House", Type.ShortStory, false));

            //Anthology

            Anthology anthology1 = new Anthology(4, "Dangerous Visions", TypesOfEdition.Audiobook, 789, "Harlan Ellison");
            anthology1.StoriesCollections.Add(collection1);
            anthology1.StoriesCollections.Add(collection2);
            anthology1.StoriesCollections.Add(collection3);

            //Book Collection

            BooksCollection bookCollection = new BooksCollection();

            bookCollection.AddBooks(novel1);
            bookCollection.AddBooks(novel2);
            bookCollection.AddBooks(collection1);
            bookCollection.AddBooks(collection2);
            bookCollection.AddBooks(collection3);
            bookCollection.AddBooks(anthology1);

            return bookCollection;
        }

    }
}
