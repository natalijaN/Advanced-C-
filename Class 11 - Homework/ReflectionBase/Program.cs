using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionBase
{
    class Program
    {
        static void Main(string[] args)
        {
            var wekoStr = "Име: Wekoslav, Презиме: Stefanovski, Age: 41, Secret: I once killed a man just to watch him die";
            var martianStr = "Author: Andy Weir, Title: The Martian, Year: 2014";
            var rectangleStr = "Width: 10, Height: 20";
            //Secret da ne se deserializira

            var weko = Deserialize<Person>(wekoStr);
            Console.WriteLine(weko);
            Console.WriteLine($"Weko`s secret: {weko.Secret}");

            Console.WriteLine();

            var martian = Deserialize<Book>(martianStr);
            Console.WriteLine(martian);

            Console.WriteLine();

            var rectangle = Deserialize<Rectangle>(rectangleStr);
            Console.WriteLine("The area of the rectangle: {0}",rectangle.GetArea());

            Console.WriteLine();
         
            var andrea = new Person
            {
                FirstName = "Andrea",
                LastName = "Markovski",
                Age = 35,
                Secret = "I like My Little Pony"
            };

            var andreaStr = Serialize(andrea);
            Console.WriteLine(andreaStr);

            Console.WriteLine();

            File.WriteAllText("andrea.txt", andreaStr);

        }
      
        private static string Serialize<T>(T value)
        {
            var props = typeof(T).GetProperties()
                .Where(pi => pi.CanRead && pi.CanWrite)
                .Where(pi => IsIgnored(pi) == false);

            var propValues = props.Select(pi => $"{GetPropertyName(pi)}: {pi.GetValue(value)}");
            var result = string.Join(", ", propValues);
            return result;
        }

        private static object GetPropertyName(PropertyInfo pi)
        {
            var sedcAttribute = pi.GetCustomAttribute<SedcAttribute>();
            if ((sedcAttribute == null) || string.IsNullOrEmpty(sedcAttribute.StringName))
            {
                return pi.Name;
            }
            else
            {
                return sedcAttribute.StringName;
            }
        }

        private static bool IsIgnored(PropertyInfo pi)
        {
            var sedcAttribute = pi.GetCustomAttribute<SedcAttribute>();
            return (sedcAttribute != null) && sedcAttribute.Ignore;
        }

        private static T Deserialize<T>(string objStr) where T : new()
        {
            var propValues = objStr.Split(',');
            var props = propValues.Select(pv => pv.Trim().Split(':').Select(s => s.Trim()).ToArray());
            var propsDict = new Dictionary<string, string>();
            foreach (var item in props)
            {
                propsDict.Add(item[0], item[1]);
            }

            Type type = typeof(T);
            var constructor = type.GetConstructors().Single(cons => cons.GetParameters().Length == 0);
            var result = constructor.Invoke(null);

            foreach (var prop in propsDict)
            {
                var pinfo = GetPropertyInfo(type, prop.Key);
                var pinfoAtt = pinfo.GetCustomAttribute<SedcAttribute>();
                if (pinfoAtt != null && pinfoAtt.Ignore == true)
                {
                    pinfo.SetValue(result, null);
                }
                else if (pinfo.PropertyType == typeof(int))
                {
                    pinfo.SetValue(result, int.Parse(prop.Value));
                }
                else
                {
                    pinfo.SetValue(result, prop.Value);
                }
            }

            return (T)result;
        }

        private static PropertyInfo GetPropertyInfo(Type type, string key)
        {
            var pinfo = type.GetProperty(key);

            if (pinfo != null)
            {
                return pinfo;
            }
            var result = type.GetProperties()
                 .Select(pi => new { Property = pi, Attribute = pi.GetCustomAttribute<SedcAttribute>() })
                 .Where(pa => pa.Attribute != null && pa.Attribute.Ignore == false)
                 .Single(pa => pa.Attribute.StringName == key)
                 .Property;
            return result;

        }
    }
}
