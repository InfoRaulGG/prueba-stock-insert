using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InsertStock.Models
{
    public class Inventory
    {

        public int InventoryId { get; set; }
        public int PointOfSale { get; set; }
        public string ProductCode { get; set; }
        public DateTime CreateDate { get; set; }
        public int Stock { get; set; }
    }
}
