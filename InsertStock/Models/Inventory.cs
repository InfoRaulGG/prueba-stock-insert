using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InsertStock.Models
{
    public class Inventory
    {
        //TODO : Poner longuitudes etc. ¿?Index¿?
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InventoryId { get; set; }
        [Required]
        [MaxLength(50)]
        public string PointOfSale { get; set; }
        [Required]
        [MaxLength(100)]
        public string ProductCode { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public string CreateDate { get; set; }
        [Required]
        [MaxLength(30)]
        public int Stock { get; set; }

    }
}
