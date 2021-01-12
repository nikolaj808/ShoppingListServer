using ShoppingListServer.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingListServer.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string> Login(LoginCredentials loginCredentials);
        Task<string> Register(RegisterCredentials registerCredentials);
    }
}
