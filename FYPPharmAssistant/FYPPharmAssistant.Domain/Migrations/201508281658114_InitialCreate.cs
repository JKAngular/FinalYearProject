namespace FYPPharmAssistant.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {/*
            CreateTable(
                "dbo.GenericName",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        GenericNameID = c.Int(),
                        ManufacturerID = c.Int(),
                        Categeory = c.Int(),
                        UnitType = c.Int(nullable: false),
                        Weight = c.Decimal(precision: 18, scale: 2),
                        MeasurementID = c.Int(nullable: false),
                        LastUpdated = c.DateTime(),
                        Supplier_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.GenericName", t => t.GenericNameID)
                .ForeignKey("dbo.Manufacturer", t => t.ManufacturerID)
                .ForeignKey("dbo.Supplier", t => t.Supplier_ID)
                .Index(t => t.GenericNameID)
                .Index(t => t.ManufacturerID)
                .Index(t => t.Supplier_ID);
            
            CreateTable(
                "dbo.Manufacturer",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.PaymentStatus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PurchaseID = c.String(maxLength: 128),
                        AmountPaid = c.Decimal(precision: 18, scale: 2),
                        Due = c.Decimal(precision: 18, scale: 2),
                        IsFullPaid = c.Boolean(nullable: false),
                        LastUpdated = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Purchase", t => t.PurchaseID)
                .Index(t => t.PurchaseID);
            
            CreateTable(
                "dbo.Purchase",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Date = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tax = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LastUpdated = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PurchaseItem",
                c => new
                    {
                        PurchaseID = c.String(nullable: false, maxLength: 128),
                        ItemID = c.Int(nullable: false),
                        BatchNo = c.String(nullable: false, maxLength: 128),
                        Qty = c.Int(nullable: false),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BonusQty = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PurchaseID, t.ItemID, t.BatchNo })
                .ForeignKey("dbo.Purchase", t => t.PurchaseID, cascadeDelete: true)
                .Index(t => t.PurchaseID);
            
            CreateTable(
                "dbo.Supplier",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Name, unique: true);
            */
        }
        
        public override void Down()
        {/*
            DropForeignKey("dbo.Item", "Supplier_ID", "dbo.Supplier");
            DropForeignKey("dbo.PaymentStatus", "PurchaseID", "dbo.Purchase");
            DropForeignKey("dbo.PurchaseItem", "PurchaseID", "dbo.Purchase");
            DropForeignKey("dbo.Item", "ManufacturerID", "dbo.Manufacturer");
            DropForeignKey("dbo.Item", "GenericNameID", "dbo.GenericName");
            DropIndex("dbo.Supplier", new[] { "Name" });
            DropIndex("dbo.PurchaseItem", new[] { "PurchaseID" });
            DropIndex("dbo.PaymentStatus", new[] { "PurchaseID" });
            DropIndex("dbo.Manufacturer", new[] { "Name" });
            DropIndex("dbo.Item", new[] { "Supplier_ID" });
            DropIndex("dbo.Item", new[] { "ManufacturerID" });
            DropIndex("dbo.Item", new[] { "GenericNameID" });
            DropIndex("dbo.GenericName", new[] { "Name" });
            DropTable("dbo.Supplier");
            DropTable("dbo.PurchaseItem");
            DropTable("dbo.Purchase");
            DropTable("dbo.PaymentStatus");
            DropTable("dbo.Manufacturer");
            DropTable("dbo.Item");
            DropTable("dbo.GenericName");*/
        }
    }
}
