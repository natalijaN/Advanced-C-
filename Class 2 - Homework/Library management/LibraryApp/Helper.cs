using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public static class Helper
    {
        public static string GenerateRandomISBN(this IBook book,int size)
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            StringBuilder builder = new StringBuilder();
            int number;
            for (int i = 0; i < size; i++)
            {
                number = Convert.ToInt32(Math.Floor(10 * random.NextDouble()));
                builder.Append(number);
            }

            return builder.ToString();
        }
    }
}
