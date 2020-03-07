using Autofac;
using InsertStock.DAL;
using InsertStock.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace InsertStock
{
    class Program
    {
        public static void Main(string[] args)
        {
            IContainer container = IoCBuilder.Build();
            var db = container.Resolve<InventoryContext>();
            var config = container.Resolve<ConfigurationService>();

            try
            {
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
