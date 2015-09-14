using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYPPharmAssistant.Domain.Models
{
    public class Purchase
    {

        public Purchase()
        {
            Amount = 0;
            Tax = 0;
            Discount = 0;          

        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name="Invoice.No")]
        public string ID { get; set; }

        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        public DateTime Date { get; set; }

        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        [DataType(DataType.Currency)]
        public decimal Discount { get; set; }

        [DataType(DataType.Currency)]
        public decimal Tax { get; set; }

        [DataType(DataType.Currency)]
        public decimal Total
        {            
            set
            {
                Total = Amount - Discount + Tax;
            }
        }
        public DateTime? LastUpdated { get; set; }


        public virtual ICollection<PurchaseItem> PurchaseItems { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<PaymentStatus> PaymentStatus { get; set; }

    }
}
