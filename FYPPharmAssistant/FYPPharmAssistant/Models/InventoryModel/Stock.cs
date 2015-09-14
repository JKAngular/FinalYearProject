using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FYPPharmAssistant.Models.InventoryModel
{
    public class Stock
    {
        public Stock()
        {
            BatchNo = "--";
        }
        public int ID { get; set; }
        public int ItemID { get; set; }

        [StringLength(20, ErrorMessage="Too long. Plese check again!")]
        public string BatchNo { get; set; }

        [Range(0,9999999)]
        public int InitialQty { get; set; }

        [Range(0,100000)]
        public int Qty { get; set; }

        [Range(0, 1000000,ErrorMessage="Out of range!")]
        public decimal CostPrice { get; set; }

        [Range(0, 1000000, ErrorMessage = "Out of range!")]
        public decimal SellingPrice { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}",ApplyFormatInEditMode=true)]
        public DateTime? ManufacturedDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ExpiryDate { get; set; }

        public virtual Item Item { get; set; }
    }
}