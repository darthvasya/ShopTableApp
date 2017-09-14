using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using dev.ShopTableApp.DataAccess.EF.Pub.Entity;

namespace dev.ShopTableApp.DataAccess.EF.Pub
{
    public class ShopTableAppDbContext : DbContext
    {
        public ShopTableAppDbContext()
            : base("DefaultConnection")
        {
            Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer(new CreateDatabaseIfNotExists<ShopTableAppDbContext>());
        }

        public DbSet<Shop> Shops { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
