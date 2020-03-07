using CsvHelper;
using CsvHelper.Configuration;
using CSVHelperProject.Services;
using InsertStock.Mappers;
using InsertStock.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Microsoft.VisualBasic.FileIO;

namespace InsertStock.Services
{
    public class CsvService : ICsvParserService
    {
        public List<Inventory> ReadCsvInventoryFile(string path)
        {
			List<Inventory> inventory = new List<Inventory>();
			try
			{
				var client = new WebClient();			
				using (TextReader fileReader = new StreamReader(client.OpenRead(path)))
				{
					CsvConfiguration configuration = new CsvConfiguration(CultureInfo.InvariantCulture);
					var csv = new CsvReader(fileReader, configuration);
					csv.Configuration.RegisterClassMap<InventoryMapper>();
					csv.Configuration.Delimiter = ";";
					csv.Read();
					csv.ReadHeader();

					return csv.GetRecords<Inventory>().ToList();
				}

			}
			catch (Exception)
			{
				throw;
			}
        }
    }
}
