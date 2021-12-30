using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Watch.Models;

namespace Watch.DAL
{
    public class WatchShopContext : DbContext
    {
        public WatchShopContext() : base("WatchShopContext")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //}
    }
}