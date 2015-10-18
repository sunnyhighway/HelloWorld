using System;
using System.Globalization;
using System.Collections.Generic;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            RegasCultureInfo userCulture = new RegasCultureInfo(args[1]);
            Console.WriteLine(string.Format(userCulture, "hello {0}.", args[0]));

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        class RegasCultureInfo :CultureInfo
        {

            enum WhenLanguageIsUnknown
            {
                ThrowException,
                SetDefaultLanguage
            }

            public RegasCultureInfo(string language) :base(GetUserCulture(language),true) {}

            private static string GetUserCulture(string language)
            {
                return GetUserCulture(language, WhenLanguageIsUnknown.ThrowException);
            }

            private static string GetUserCulture(string language, WhenLanguageIsUnknown whenLanguageIsUnknown)
            {
                Dictionary<string, string> UserCulture = new Dictionary<string, string>(4);
                UserCulture.Add("frans", "Fr-fr");
                UserCulture.Add("duits", "De-de");
                UserCulture.Add("nederlands", "Nl-nl");
                UserCulture.Add("engels", "En-en"); 

                string culturename;
                if (!UserCulture.TryGetValue(language, out culturename))
                {
                    switch (whenLanguageIsUnknown)
                    {
                        case WhenLanguageIsUnknown.ThrowException:
                            throw new CultureNotFoundException(string.Format(CultureInfo.InvariantCulture ,"User speaks {0}, we cant cope with that.", language));

                        case WhenLanguageIsUnknown.SetDefaultLanguage:
                            culturename = "En-en";
                            break;

                        default:
                            throw new NotImplementedException(string.Format(CultureInfo.InvariantCulture, "Undefined value for enum 'WhenLanguageIsUnknown': {0}.", whenLanguageIsUnknown.ToString()));

                    }
                }

                return culturename;
            }
        }
    }
}