using System;
using System.Globalization;

namespace HelloWorld
{
    class Program
    {
        private const string SayHello = "Hello {0}.";
        private const string PressAnyKeyToContinue = "Press any key to continue.";

        /// <summary>
        /// Main entrypoint of the HelloWorld application
        /// </summary>
        /// <param name="args">
        /// arg[0] name
        /// arg[1] language
        /// </param>
        static void Main(string[] args)
        {
            RegasCultureInfo userCulture = new RegasCultureInfo(args[1]);
            Console.WriteLine(string.Format(userCulture, SayHello, args[0]));

            Console.WriteLine(PressAnyKeyToContinue);
            Console.ReadKey();
        }

    }
}