using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYPPharmAssistant.Models.InventoryModel
{
    public class Manufacturer
    {
        public int ID { get; set; }
        public String ManufacturerName { get; set; }
        public string Description { get; set; }


        public virtual ICollection<Item> Items { get; set; }

    }
}
