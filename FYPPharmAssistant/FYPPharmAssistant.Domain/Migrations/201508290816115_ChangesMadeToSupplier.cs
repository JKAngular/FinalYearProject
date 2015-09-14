namespace FYPPharmAssistant.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesMadeToSupplier : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Item", "Supplier_ID", "dbo.Supplier");
            DropIndex("dbo.Item", new[] { "Supplier_ID" });
            AddColumn("dbo.Purchase", "Supplier_ID", c => c.Int());
            CreateIndex("dbo.Purchase", "Supplier_ID");
            AddForeignKey("dbo.Purchase", "Supplier_ID", "dbo.Supplier", "ID");
            DropColumn("dbo.Item", "Supplier_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Item", "Supplier_ID", c => c.Int());
            DropForeignKey("dbo.Purchase", "Supplier_ID", "dbo.Supplier");
            DropIndex("dbo.Purchase", new[] { "Supplier_ID" });
            DropColumn("dbo.Purchase", "Supplier_ID");
            CreateIndex("dbo.Item", "Supplier_ID");
            AddForeignKey("dbo.Item", "Supplier_ID", "dbo.Supplier", "ID");
        }
    }
}
