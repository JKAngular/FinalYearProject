using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYPPharmAssistant.Domain.Models
{
    public class GenericName
    {
        public int ID { get; set; }

        [Display(Name="Generic Name")]
        [Index(IsUnique=true)]
        public string Name { get; set; }


        public virtual ICollection<Item> Items { get; set; }

    }
}
