using CsvHelper.Configuration;
using InsertStock.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsertStock.Mappers
{
    public sealed class InventoryMapper : ClassMap<Inventory>
    {
        public InventoryMapper()
        {
            Map(m => m.PointOfSale).Name("PointOfSale");
            Map(m => m.ProductCode).Name("Product");
            Map(m => m.CreateDate).Name("Date");
            Map(m => m.Stock).Name("Stock");
        }
    }
}
