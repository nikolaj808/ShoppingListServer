using System;

namespace ShoppingListServer.Models.Authentication.Exceptions
{
    public class UnexpectedException : Exception
    {
        public UnexpectedException()
        {
        }

        public UnexpectedException(string message)
            : base(message)
        {
        }

        public UnexpectedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
