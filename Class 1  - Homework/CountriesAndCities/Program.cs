using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountriesAndCities
{
    class Program
    {
        static void Main(string[] args)
        {
             
            Dictionary<string, string> CountriesAndMainCities= new Dictionary<string, string>() {
                { "Bulgaria", "Sofia" },
                { "Greece", "Athens"},
                { "Serbia", "Belgrade" },
                { "Kosovo", "Pristina"},
                { "Albania", "Tirana" }
            };
            
            while (true)
            {   
                Console.WriteLine("Press 1 -> If you want to find out the capital city of country!");
                Console.WriteLine("Press 2 -> If you want to add country with caapital city to database!");
                Console.WriteLine("Press 3 -> If you want to break!");
            
                try
                {
                    int userChoise = Convert.ToInt32(Console.ReadLine());

                    if(userChoise == 1)
                    {
                        // Find out the capital city
                        Console.WriteLine("Write the country to find out the capital city!");
                        string userInput = Console.ReadLine();

                        if (CountriesAndMainCities.ContainsKey(userInput))
                        {
                            Console.WriteLine($"The capital city of {userInput} is {CountriesAndMainCities[userInput]}!");
                            Console.WriteLine();
                            
                        }
                        else
                        {
                            Console.WriteLine("There is no such country in this database!");
                            Console.WriteLine();
                        }
                        
                    }
                    else if(userChoise == 2)
                    {
                        // Add country and capital city
                        Console.WriteLine("Please write the country that you want to add!");
                        string country = Console.ReadLine();
                        Console.WriteLine();

                        Console.WriteLine("Please write the capital city of the country!");
                        string capitalCity = Console.ReadLine();
                        Console.WriteLine();

                        CountriesAndMainCities.Add(country, capitalCity);
                        Console.Clear();
                    }
                    else if(userChoise == 3)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Wrong input!");
                        // Wrong input
                    }
                    
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }     
            }             
        }
    }
}
