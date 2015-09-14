using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYPPharmAssistant.Domain.Models
{
    public class Supplier
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage="Maximum length is only 50 !")]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
