using System;
using System.Collections.Generic;
using ShoppingListServer.Models.Items;
using ShoppingListServer.Models.UserShoppingLists;

namespace ShoppingListServer.Models.ShoppingLists
{
    public class ShoppingList
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<Item> Items { get; set; }
        public ICollection<UserShoppingList> UserShoppingLists { get; set; }
    }
}
