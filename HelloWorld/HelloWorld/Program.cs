using System;
using System.Globalization;
using System.Collections.Generic;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {

            bool option = true;

            if (option == true)
            {
                RegasCultureInfo userCulture = new RegasCultureInfo(args[1]);
                Console.WriteLine(string.Format(userCulture, "hello {0}.", args[0]));
            }
        }

        class RegasCultureInfo :CultureInfo
        {
            
            public RegasCultureInfo() : base("En-en") { }

            public RegasCultureInfo(string name):base(GetUserCulture(name)) {}

            private static string GetUserCulture(string language)
            {
                Dictionary<string, string> UserCulture = new Dictionary<string, string>(4);
                UserCulture.Add("frans", "Fr-fr");
                UserCulture.Add("duits", "De-de");
                UserCulture.Add("nederlands", "Nl-nl");
                UserCulture.Add("engels", "Fr-fr");

                string culturename;
                if (!UserCulture.TryGetValue(language, out culturename))
                {
                    throw new CultureNotFoundException(string.Format("User speaks {0}, we cant cope with that.", language));
                }
                else
                {
                    culturename = "EN-en";
                }

                return culturename;
            }
        }
    }
}