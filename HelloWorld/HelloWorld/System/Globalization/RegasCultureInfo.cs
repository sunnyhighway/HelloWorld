﻿using System.Collections.Generic;

namespace System.Globalization
{
    /// <summary>
    ///     Regas implementation of the CultureInfo Class
    ///     Provides information about a specific culture (called a locale for unmanaged
    ///     code development). The information includes the names for the culture, the writing
    ///     system, the calendar used, and formatting for dates and sort strings.
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
        ///     Initializes a new instance of the System.Globalization.RegasCultureInfo class based
        ///     on the culture specified by name.
        /// </summary>
        /// <param name="language">
        /// 
        /// </param>
        public RegasCultureInfo(string language) : base(GetUserCulture(language), true) { }

        private static string GetUserCulture(string language)
        {
            return GetUserCulture(language, HandleUnknownlanguageMethod.ThrowException);
        }

        private static string GetUserCulture(string language, HandleUnknownlanguageMethod handleUnknownlanguageMethod)
        {
            string culturename;

            if (!UserCulture.TryGetValue(language, out culturename))
            {
                switch (handleUnknownlanguageMethod)
                {
                    case HandleUnknownlanguageMethod.ThrowException:
                        throw new CultureNotFoundException(string.Format(InvariantCulture, "User speaks {0}, we cant cope with that.", language));
                        //throw new CultureNotFoundException($"User speaks {language:InvarianCulture}, we can't cope with that.");

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
