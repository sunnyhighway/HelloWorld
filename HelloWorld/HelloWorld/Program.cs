using System;
using System.Globalization;
using System.Collections.Generic;
using System.Runtime.Serialization;

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

        /// <summary>
        /// Regas implementation of the CultureInfo Class
        /// </summary>
        class RegasCultureInfo : CultureInfo
        {
            private static Dictionary<string, string> UserCulture
                = new Dictionary<string, string> {
                    { "frans", "Fr-fr" },
                    { "duits", "De-de" },
                    { "nederlands", "Nl-nl" },
                    { "engels", "En-en" }
            };

            private enum HandleUnknownlanguageMethod
            {
                Unkonwn,
                ThrowException,
                SetDefaultLanguage
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="language"></param>
            public RegasCultureInfo(string language) : base(GetUserCulture(language), true) { }

            private static string GetUserCulture(string language)
            {
                return GetUserCulture(language, HandleUnknownlanguageMethod.ThrowException);
            }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.String.Format(System.String,System.Object)")]
            private static string GetUserCulture(string language, HandleUnknownlanguageMethod handleUnknownlanguageMethod)
            {
                string culturename;

                if (!UserCulture.TryGetValue(language, out culturename))
                {
                    switch (handleUnknownlanguageMethod)
                    {
                        case HandleUnknownlanguageMethod.ThrowException:
                            //throw new CultureNotFoundException(string.Format(InvariantCulture, "User speaks {0}, we cant cope with that.", language));
                            throw new CultureNotFoundException($"User speaks {language}, we cant cope with that.");

                        case HandleUnknownlanguageMethod.SetDefaultLanguage:
                            culturename = "En-en";
                            break;

                        default:
                            throw new EnumValueNotHandledException(handleUnknownlanguageMethod);
                    }
                }

                return culturename;
            }
        }
    }

    /// <summary>
    /// The exception that can be thrown when a requested enum value is not implemented.
    /// </summary>
    [Serializable()]
    public class EnumValueNotHandledException : NotImplementedException
    {
        /// <summary>
        /// Initializes a new instance of the System.NotImplementedException class with default properties
        /// </summary>
        public EnumValueNotHandledException() : base() { }

        public EnumValueNotHandledException(string message) : base(message) { }

        public EnumValueNotHandledException(string message, Exception innerException) 
         : base (message, innerException) { }
        public EnumValueNotHandledException(object enumValue)
            : this(string.Format(CultureInfo.InvariantCulture, "Unhandled value for enum '{0}' value: '{1}'", enumValue?.GetType().Name, enumValue))
        { }

        public EnumValueNotHandledException(object enumValue, Exception innerException)
         : this(string.Format(CultureInfo.InvariantCulture, "Unhandled value for enum '{0}' value: '{1}'", enumValue?.GetType().Name, enumValue), innerException)
        { }

        protected EnumValueNotHandledException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }

}