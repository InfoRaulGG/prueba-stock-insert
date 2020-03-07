﻿using Autofac;
using EFCore.BulkExtensions;
using InsertStock.DAL;
using InsertStock.Models;
using InsertStock.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace InsertStock
{
    class Program
    {
        public static void Main(string[] args)
        {
            IContainer container = IoCBuilder.Build();
            var db = container.Resolve<InventoryContext>();
            var config = container.Resolve<ConfigurationService>();
            var csvRead = container.Resolve<CsvService>();

            try
            {
                Console.WriteLine("CARGANDO EL PROGRAMA... ");
                db.Database.Migrate();
                Console.Clear();
                DateTime Fechainicio = DateTime.Now;
                TimeSpan ts = new TimeSpan();

                Console.WriteLine("INICIO ::: HORA DE EJECUCION " + Fechainicio);
                string path = config.GetConfigurationSetting("UrlDescargaStock");

                Console.WriteLine("Descargar información de fichero remoto; " + path);
                Console.WriteLine("\n- LEYENDO DATOS");
                var inventario = csvRead.ReadCsvInventoryFile(path);

                if(inventario != null && inventario.Count > 0)
                {
                    ts = DateTime.Now - Fechainicio;
                    Console.WriteLine("- DATOS CARGADOS :: Tiempo de ejecución del programa: " + ts.Minutes + " minutos");

                    if(db.Inventory.Any())
                    {
                        db.BulkDelete(inventario);
                        ts = DateTime.Now - Fechainicio;
                        Console.WriteLine("- DATOS BORRADOS :: Tiempo de ejecución del programa: " + ts.Minutes + " minutos");
                    }

                    Console.WriteLine("- INSERTANDO DATOS, TOTAL DE REGISTROS::: " + inventario.Count);
                    db.BulkInsert(inventario);
                    ts = DateTime.Now - Fechainicio;
                    Console.WriteLine("##############################################################################################################");
                    Console.WriteLine("\n PROCESO TERMINADO CON EXITO DATOS INSERTADOS :: Tiempo de ejecución del programa: " + ts.Minutes + " minutos");
                }
                else
                {
                    Console.WriteLine("No existen los datos buscados en el fichero");
                }

            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.Write(ex);
            }
        }
    }
}
