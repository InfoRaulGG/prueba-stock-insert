using CsvHelper.Configuration;
using InsertStock.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace InsertStock.Mappers
{
    public sealed class InventoryMapper : ClassMap<Inventory>
    {
        public InventoryMapper()
        {
            try
            {
                Map(m => m.PointOfSale).Name("PointOfSale");
                Map(m => m.ProductCode).Name("Product");
                Map(m => m.CreateDate).Name("Date")
                    .TypeConverterOption.CultureInfo(CultureInfo.InvariantCulture)
                    .TypeConverterOption.DateTimeStyles(DateTimeStyles.AdjustToUniversal);
                Map(m => m.Stock).Name("Stock");       
            }
            catch (Exception ex)
            {
                throw ex; 
            }
            
        }
    }
}
