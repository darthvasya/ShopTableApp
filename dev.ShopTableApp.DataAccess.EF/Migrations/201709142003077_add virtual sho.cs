namespace dev.ShopTableApp.DataAccess.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addvirtualsho : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Item", name: "Shop_Id", newName: "ShopId");
            RenameIndex(table: "dbo.Item", name: "IX_Shop_Id", newName: "IX_ShopId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Item", name: "IX_ShopId", newName: "IX_Shop_Id");
            RenameColumn(table: "dbo.Item", name: "ShopId", newName: "Shop_Id");
        }
    }
}
