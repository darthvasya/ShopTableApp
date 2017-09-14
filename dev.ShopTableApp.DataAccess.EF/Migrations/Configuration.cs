using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using dev.ShopTableApp.DataAccess.EF.Pub;
using dev.ShopTableApp.DataAccess.EF.Pub.Entity;

namespace dev.ShopTableApp.DataAccess.EF.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ShopTableAppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ShopTableAppDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var items1 = new List<Item>
            {
                new Item {Description = "sûאגפ", Name = "םמדא"},
                new Item {Description = "פûגאפגûאs", Name = "מכוםü"}
            };

            var items2 = new List<Item>
            {
                new Item {Description = "sûאגפ", Name = "ראןךא"},
                new Item {Description = "פûגאפגûאs", Name = "ןמקךא"}
            };

            context.Shops.AddOrUpdate(
                p => p.Name,
                new Shop
                {
                    Address = "Address",
                    StartWorkTime = DateTime.Now,
                    EndWorkTime = DateTime.Now,
                    Name = "Shop",
                    Items = items1
                },
                new Shop
                {
                    Address = "Address2",
                    StartWorkTime = DateTime.Now,
                    EndWorkTime = DateTime.Now,
                    Name = "Shop2",
                    Items = items2
                });
        }
    }
}