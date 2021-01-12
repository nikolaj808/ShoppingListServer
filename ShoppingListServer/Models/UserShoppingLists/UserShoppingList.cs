using ShoppingListServer.Models.Authentication;
using ShoppingListServer.Models.ShoppingLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingListServer.Models.UserShoppingLists
{
    public class UserShoppingList
    {
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid ShoppingListId { get; set; }
        public ShoppingList ShoppingList { get; set; }
    }
}
