namespace FYPPharmAssistant.Domain.Migrations
{
    using FYPPharmAssistant.Domain.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FYPPharmAssistant.Domain.DAL.MyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FYPPharmAssistant.Domain.DAL.MyContext context)
        {
       
            var manufacturer = new List<Manufacturer>() { 
                new Manufacturer{Name = "Cipla"},
                new Manufacturer{Name = "Quest"},
                new Manufacturer{Name = "Bajra"}, 
                new Manufacturer{Name = "Himal"}, 
                new Manufacturer{Name = "Nippon"}, 
            };

            manufacturer.ForEach(m => context.Manufacturers.AddOrUpdate(m));
            context.SaveChanges();
            
            var gname = new List<GenericName>(){
                new GenericName{Name="Paracetamol"},
                new GenericName{Name="Omeprazole"},
                new GenericName{Name="Omeprazole2"},
                new GenericName{Name="Pentajol"},
                new GenericName{Name="Centajol"}
            };

            gname.ForEach(g => context.GenericNames.AddOrUpdate(g));
            context.SaveChanges();

            var suppplier = new List<Supplier>()
            {
                new Supplier{Name = "Supplier1"},
                new Supplier{Name = "Supplier2"},
                new Supplier{Name = "Supplier3"}
            };
            suppplier.ForEach(s => context.Suppliers.AddOrUpdate(s));
            context.SaveChanges();
          
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
        }
    }
}
