using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using FYPPharmAssistant.Domain.Models;


namespace FYPPharmAssistant.Domain.DAL
{
    public class PharmacyInitializer :DropCreateDatabaseIfModelChanges<MyContext>
    {
        protected override void Seed(MyContext context)
        {
            /*
            var manufacturer = new List<Manufacturer>() { 
                new Manufacturer{Name = "Cipla"},
                new Manufacturer{Name = "Quest"},
                new Manufacturer{Name = "Bajra"}, 
                new Manufacturer{Name = "Himal"}, 
                new Manufacturer{Name = "Nippon"}, 
            };

            manufacturer.ForEach(m=>context.Manufacturers.Add(m));
            context.SaveChanges();

            var generic = new List<GenericName>(){
                new GenericName{Name="Paracetamol"},
                new GenericName{Name="Omeprazole"},
                new GenericName{Name="Omeprazole2"},
                new GenericName{Name="Pentajol"},
                new GenericName{Name="Centajol"}
            };

            generic.ForEach(g => context.GenericNames.Add(g));
            context.SaveChanges();   */

            }
        }
    }

