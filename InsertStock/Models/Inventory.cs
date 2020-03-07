using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InsertStock.Models
{
    public class Inventory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InventoryId { get; set; }
        public string PointOfSale { get; set; }
        public string ProductCode { get; set; }
        public DateTime CreateDate { get; set; }
        public int Stock { get; set; }

 
    }
}
