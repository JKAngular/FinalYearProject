using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace FYPPharmAssistant.Domain.Models
{
    public class Item
    {
        public int ID { get; set; }

        [Required]
        [Display(Name="Item")]
        public string Name { get; set; }

        [Display(Name="Generic Name")]
        public int? GenericNameID { get; set; }

        [Display(Name = "Manufacturer")]
        public int? ManufacturerID { get; set; }

        [Display(Name = "Categeory")]
        public Categeory? Categeory { get; set; }

        [Display(Name = "Unit Type")]
        public UnitType UnitType { get; set; }

        [Display(Name = "wt.")]
        public decimal? Weight { get; set; }

        [Display(Name = "measurement")]
        public Measurement MeasurementID { get; set; }

        [Display(Name = "Last Update")]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}",ApplyFormatInEditMode=true)]
        public DateTime? LastUpdated { get; set; }


        //reference entity
        public virtual GenericName GenericName { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual ICollection<PurchaseItem> PurchaseItems { get; set; }
        
    }
}


//stock defination



/*using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYPPharmAssistant.Domain.Models
{
    public class Stock
    {
        [Key]
        [ForeignKey("PurchaseItem")]
        [Column(Order = 1)]
        public int ItemID { get; set; }

        [Key]
        [ForeignKey("PurchaseItem")]
        [Column(Order = 2)]
        public string BatchNo { get; set; }
        public int Qty { get; set; }
        public DateTime? ManufacturedDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public decimal SpRate { get; set; }
        public DateTime? LastUpdated { get; set; }

        public virtual ICollection<PurchaseItem> PurchaseItems { get; set; }
    }
}
*/