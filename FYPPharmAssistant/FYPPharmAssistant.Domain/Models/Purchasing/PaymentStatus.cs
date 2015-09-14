using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYPPharmAssistant.Domain.Models
{
    public class PaymentStatus
    {
        public PaymentStatus()
        {
            IsFullPaid = false;
        }
        public int ID { get; set; }
        public string PurchaseID { get; set; }

        [Display(Name="Paid")]
        public decimal? AmountPaid { get; set; }

        [Display(Name = "Due")]
        public decimal? Due { get; set; }

        [Display(Name="Full Paid ?")]
        public bool IsFullPaid { get; set; }

        [Display(Name="Last Updated Date")]
        public DateTime? LastUpdated { get; set; }


        public virtual Purchase Purchase { get; set; }
    }
}
