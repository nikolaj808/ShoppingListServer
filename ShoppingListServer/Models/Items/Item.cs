using ShoppingListServer.Models.ShoppingLists;
using System;

namespace ShoppingListServer.Models.Items
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid ShoppingListId { get; set; }
        public ShoppingList ShoppingList { get; set; }
    }
}
