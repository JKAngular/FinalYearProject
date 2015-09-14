using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;
using FYPPharmAssistant.Models.InventoryModel;
using FYPPharmAssistant.Models.PurchaseModel;


namespace FYPPharmAssistant.DAL
{
    public class MyContext : DbContext
    {
        public MyContext()
            : base("MyConnectionString")
        {

        }
        public DbSet<DrugGenericName> DrugGenericNames { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseItem> PurchaseItems { get; set; }


        //avoids pluralizing table names
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
