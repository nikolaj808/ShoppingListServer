using System;

namespace ShoppingListServer.Models.Authentication.Exceptions
{
    public class WrongEmailOrPasswordException : Exception
    {
        public WrongEmailOrPasswordException()
        {
        }

        public WrongEmailOrPasswordException(string message)
            : base(message)
        {
        }

        public WrongEmailOrPasswordException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
