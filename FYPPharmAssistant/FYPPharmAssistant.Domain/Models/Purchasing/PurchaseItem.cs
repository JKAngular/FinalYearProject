using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYPPharmAssistant.Domain.Models
{
    public class PurchaseItem
    {
        public PurchaseItem()
        {
            BonusQty =0;
            BatchNo = "-";
            Rate = 0;
        }

        [Key]
        [Column(Order = 1)]
        public string PurchaseID { get; set; }

        [Key]
        [Column(Order = 2)]
        public int ItemID { get; set; }

        [Key]
        [Column(Order = 3)]
        public string BatchNo { get; set; }

        public int Qty { get; set; }
        
        public decimal Rate { get; set; }
        public decimal Amount { 
            set
                {
                    Amount = Qty * Rate;
                }
        }
        public int BonusQty { get; set; }
        public int TotalQty {
            set 
            {                
                TotalQty = Qty+BonusQty;
            }
        }

        public virtual Purchase Purchase { get; set; }
        public virtual Item Item { get; set; }
       // public virtual Stock Stock { get; set; }

    }
}
