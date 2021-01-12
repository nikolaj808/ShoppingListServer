using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShoppingListServer.Models.Authentication;
using ShoppingListServer.Models.Items;
using ShoppingListServer.Models.ShoppingLists;
using ShoppingListServer.Models.UserShoppingLists;
using System;

namespace ShoppingListServer.Data
{
    public class ShoppingListContext : IdentityDbContext<User, UserRole, Guid>
    {
        public ShoppingListContext(DbContextOptions<ShoppingListContext> options) : base(options) { }

        public DbSet<Item> Items { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }
        public DbSet<UserShoppingList> UserShoppingLists { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserShoppingList>().HasKey(usl => new { usl.UserId, usl.ShoppingListId });

            builder.Entity<UserShoppingList>()
                .HasOne(usl => usl.ShoppingList)
                .WithMany(sl => sl.UserShoppingLists)
                .HasForeignKey(usl => usl.ShoppingListId);

            builder.Entity<UserShoppingList>()
                .HasOne(usl => usl.User)
                .WithMany(u => u.UserShoppingLists)
                .HasForeignKey(usl => usl.UserId);

            base.OnModelCreating(builder);
        }
    }
}
