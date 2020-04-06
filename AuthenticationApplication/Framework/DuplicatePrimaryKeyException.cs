namespace AuthenticationApplication.Framework
{
    using System;
    /// <summary>
    /// the custom exception
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class DuplicatePrimaryKeyException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicatePrimaryKeyException"/> class.
        /// </summary>
        public DuplicatePrimaryKeyException():base("Email id already exists")
        {
        }
    }
}
