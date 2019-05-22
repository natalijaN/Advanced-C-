using CSharpAdvanced_Class4.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanced_Class4
{
    public static class Extensions
    {
        public static string WithCurrency(this double value, string currency)
        {
            return $"{value:0,0.00}{currency}";
        }

        public static string PriceWithCurrency(this IPrice priced, string currency)
        {
            return priced.GetTotalPrice().WithCurrency(currency);
        }
    }
}
