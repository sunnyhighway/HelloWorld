using System;
using System.Globalization;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            bool option = true;

            if (option == true)
            {
                CultureInfo userCulture = new CultureInfo("Fr-fr", true);
                Console.WriteLine(string.Format(userCulture, "hello {0}.", args[0]));
            }
        }
    }
}