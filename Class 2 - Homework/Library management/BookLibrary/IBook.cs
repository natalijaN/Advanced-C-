using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public interface IBook
    {
        long GenerateISBN();

        string GetTypeOfBook();

        string ViewAllBooks();
    }
}
