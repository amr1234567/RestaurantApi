

using Microsoft.EntityFrameworkCore;
using RestaurantV2.Contract.Entities;

namespace RestaurantV2.DBContext
{
    public class Context : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Meal> meals { get; set; }
        public DbSet<Sellers> sellers { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Rate> rates { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Cart> Cart { get; set; }


        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
    }
}
