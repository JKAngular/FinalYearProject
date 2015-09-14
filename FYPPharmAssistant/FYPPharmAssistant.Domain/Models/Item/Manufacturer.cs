using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYPPharmAssistant.Domain.Models
{
    public class Manufacturer
    {
        public int ID { get; set; }

        [Index(IsUnique = true)]
        [Display(Name="Manufacturer")]
        public String Name { get; set; }


        public virtual ICollection<Item> Items { get; set; }

    }
}
