using InsertStock.Models;
using System.Collections.Generic;

namespace CSVHelperProject.Services
{
    public interface ICsvParserService
    {
        List<Inventory> ReadCsvInventoryFile(string path);
    }
}