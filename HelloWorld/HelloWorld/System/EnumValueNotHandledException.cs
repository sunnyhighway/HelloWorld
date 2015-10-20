using System.Globalization;
using System.Runtime.Serialization;

namespace System
{
    /// <summary>
    ///     The exception that can be thrown when a requested enum value is not handled.
    /// </summary>
    [Serializable()]
    public class EnumValueNotHandledException : NotImplementedException
    {
        /// <summary>
        ///     Initializes a new instance of the System.EnumValueNotHandledException class with default properties
        /// </summary>
        public EnumValueNotHandledException() : base() { }

        /// <summary>
        ///     Initializes a new instance of the System.EnumValueNotHandledException class with a
        ///     specified error message.
        /// </summary>
        /// <param name="message"></param>
        public EnumValueNotHandledException(string message) : base(message) { }

        /// <summary>
        ///     Initializes a new instance of the System.EnumValueNotHandledException class with a
        ///     specified error message and a reference to the inner exception that is the cause
        ///     of this exception.
        /// </summary>
        /// <param name="message">
        ///     The error message that explains the reason for the exception.
        /// </param>
        /// <param name="innerException">
        ///     The exception that is the cause of the current exception. If the inner parameter
        ///     is not null, the current exception is raised in a catch block that handles the
        ///     inner exception.
        /// </param>
        public EnumValueNotHandledException(string message, Exception innerException)
         : base(message, innerException)
        { }

        /// <summary>
        ///     Initializes a new instance of the System.EnumValueNotHandledException class with an enum value.
        /// </summary>
        /// <param name="enumValue">
        ///     The enum which was not handled
        /// </param>
        /// <example> 
        /// This sample shows how to call the <see cref="EnumValueNotHandledException"/> method.
        /// <code>
        /// class TestClass 
        ///  switch (handleUnknownlanguageMethod)
        ///     {
        ///         case HandleUnknownlanguageMethod.ThrowException:
        ///             throw new CultureNotFoundException($"User speaks {language:InvarianCulture}, we can't cope with that.");
        /// 
        ///         case HandleUnknownlanguageMethod.SetDefaultLanguage:
        ///             culturename = "En-en";
        ///             break;
        ///
        ///         default:
        ///             throw new EnumValueNotHandledException(handleUnknownlanguageMethod);
        ///     }
        /// </code>
        /// </example>
        public EnumValueNotHandledException(object enumValue)
            : this(string.Format(CultureInfo.InvariantCulture, "Unhandled value for enum '{0}' value: '{1}'", enumValue?.GetType().Name, enumValue))
        { }

        /// <summary>
        ///     Initializes a new instance of the System.EnumValueNotHandledException class with serialized data.
        /// </summary>
        /// <param name="info">
        ///     The System.Runtime.Serialization.SerializationInfo that holds the serialized
        ///     object data about the exception being thrown. 
        /// </param>
        /// <param name="context">
        ///     The System.Runtime.Serialization.StreamingContext that contains contextual information
        ///     about the source or destination.
        /// </param>
        protected EnumValueNotHandledException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}
