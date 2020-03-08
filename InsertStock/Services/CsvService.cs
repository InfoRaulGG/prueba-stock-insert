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
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace InsertStock.Services
{
    public class CsvService : ICsvParserService
    {
        public List<Inventory> ReadCsvInventoryFile(string path)
        {
            List<Inventory> inventory = new List<Inventory>();
            TimeSpan ts;
            try
            {
                Console.WriteLine("DESCARGANDO FICHERO ...");
                DateTime horaInicioDescarga = DateTime.Now;

                var client = new WebClient();
                double megabytes;

                using (TextReader fileReader = new StreamReader(client.OpenRead(path)))
                {
                    megabytes = (Convert.ToDouble(client.ResponseHeaders["Content-Length"]) / 1024) / 1024; 
                    CsvConfiguration configuration = new CsvConfiguration(CultureInfo.InvariantCulture);
                    configuration.BadDataFound = x => { Console.WriteLine(x); };
                    var csv = new CsvReader(fileReader, configuration);
                    csv.Configuration.RegisterClassMap<InventoryMapper>();
                    csv.Configuration.Delimiter = ";";
                    bool headers = false;
                    while (csv.Read())
                    {
                        if (!headers)
                        {
                            csv.ReadHeader();
                            headers = true;
                        }

                         inventory = csv.GetRecords<Inventory>().ToList();
                    }
                    csv.Dispose();
                }
                ts = DateTime.Now - horaInicioDescarga;
                Console.WriteLine("DATOS DESCARGADOS EN " + ts.TotalMinutes + " MINUTOS::: TOTAL DE DATOS DESCARGADOS: " + megabytes + " MBs");

                Console.WriteLine("PROCESANDO DATOS...");
                // Validación de datos introducidos en el fichero.
                DateTime horaInicioValidacion = DateTime.Now;
                List<Inventory> registrosNoValidos = new List<Inventory>();
                foreach (var inv in inventory)
                {
                    ValidationContext validationContext = new ValidationContext(inv, null, null);
                    var resultsValidation = new List<ValidationResult>();

                    if (!Validator.TryValidateObject(inv, validationContext, resultsValidation))
                    {
                        Console.WriteLine("\n********* DETECTADO REGISTRO NO VALIDO ************");
                        Console.WriteLine(JsonConvert.SerializeObject(inv));
                        Console.WriteLine(JsonConvert.SerializeObject(resultsValidation));

                        registrosNoValidos.Add(inv);
                    }
                }
                ts = DateTime.Now - horaInicioValidacion;
                Console.WriteLine("\n:::FIN DE LA VALIDACIÓN:::");
                Console.WriteLine(inventory.Count + " REGISTROS VALIDADOS EN " + ts.TotalMinutes + " MINUTOS \n");
                // Eliminamos de los objetos validos los que no cumplan la condición.
                registrosNoValidos.ForEach(i =>
                {
                    inventory.Remove(i);
                });

                return inventory;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
