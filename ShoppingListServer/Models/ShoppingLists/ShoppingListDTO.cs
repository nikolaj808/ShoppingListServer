using ShoppingListServer.Models.Authentication;
using ShoppingListServer.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingListServer.Models.ShoppingLists
{
    public class ShoppingListDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<ItemDTO> Items { get; set; }
        public ICollection<UserDTO> Users { get; set; }
    }
}
