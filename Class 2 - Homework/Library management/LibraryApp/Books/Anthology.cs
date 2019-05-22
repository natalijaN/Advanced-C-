using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class Anthology : Book
    {       
        public string Editor { get; set; }
        public string Theme { get; set; }
        public List<StoryCollection> StoriesCollections { get; set; } = new List<StoryCollection>();

        public override long GenerateISBN()
        {
            return ISBN = Convert.ToInt64(this.GenerateRandomISBN(13));
        }

        public Anthology(int id, string title, TypesOfEdition types, int numberOfPages, string editor)
        {
            ID = id;
            Title = title;
            Types = types;
            NumberOfPages = numberOfPages;
            Editor = editor;
            ISBN = GenerateISBN();
        }

        public override string ToString()
        {
            var storyAuthors = StoriesCollections.Select(s => s.Author).ToList();

            int storiesNumber = 0;

            foreach (var story in StoriesCollections)
            {
                storiesNumber += story.Stories.Count();  
            }
            Console.WriteLine($"Type of book: {GetTypeOfBook()}!");
            var result = $"Title: {Title} -> Editor: {Editor} -> Number of stories: {storiesNumber} -> Number of Contribution Authors: {storyAuthors.Distinct().Count()}\n"; ;
            return result;
        }

        public override string GetTypeOfBook()
        {
            return "Anthology";
        }

        public override string ViewAllBooks()
        {
            return $"Type of Book: {GetTypeOfBook()}: Title: {Title} -> Editor: {Editor} -> Type of Edition: {Types}!";            
        }

    }
}
