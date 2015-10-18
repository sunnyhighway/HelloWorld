using System.Globalization;
using System.Runtime.Serialization;

namespace System
{
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
         : base(message, innerException)
        { }
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