using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;
using FYPPharmAssistant.Domain.Models;


namespace FYPPharmAssistant.Domain.DAL
{
    public class MyContext : DbContext
    {
        public MyContext()
            : base("MyConnectionString")
        {

        }
        public DbSet<GenericName> GenericNames { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
      //  public DbSet<Stock> Stocks { get; set; }
        public DbSet<PaymentStatus> PaymentStatus { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<PurchaseItem> PurchaseItems { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        //avoids pluralizing table names
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
