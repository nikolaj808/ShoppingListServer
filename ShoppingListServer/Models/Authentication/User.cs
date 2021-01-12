using Microsoft.AspNetCore.Identity;
using ShoppingListServer.Models.UserShoppingLists;
using System;
using System.Collections.Generic;

namespace ShoppingListServer.Models.Authentication
{
    public class User : IdentityUser<Guid>
    {
        public ICollection<UserShoppingList> UserShoppingLists { get; set; }
    }
}
