using System;

namespace ShoppingListServer.Models.Items
{
    public class ItemDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
