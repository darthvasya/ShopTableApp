namespace dev.ShopTableApp.DataAccess.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Shop_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Shop", t => t.Shop_Id)
                .Index(t => t.Shop_Id);
            
            CreateTable(
                "dbo.Shop",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        StartWorkTime = c.DateTime(nullable: false),
                        EndWorkTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Item", "Shop_Id", "dbo.Shop");
            DropIndex("dbo.Item", new[] { "Shop_Id" });
            DropTable("dbo.Shop");
            DropTable("dbo.Item");
        }
    }
}
