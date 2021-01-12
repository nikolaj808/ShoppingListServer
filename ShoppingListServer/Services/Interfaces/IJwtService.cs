using ShoppingListServer.Models.Authentication;
using System.Collections.Generic;

namespace ShoppingListServer.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateJwtToken(User user, IList<string> roles);
    }
}
