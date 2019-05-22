using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public abstract class Book : IBook
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public TypesOfEdition Types { get; set; }
        public int NumberOfPages { get; set; }
        public long ISBN { get; set; }

        public abstract long GenerateISBN();

        public abstract string GetTypeOfBook();

        public abstract string ViewAllBooks();
       
    }
}
