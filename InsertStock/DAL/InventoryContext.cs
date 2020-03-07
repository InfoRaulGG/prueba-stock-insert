using Autofac;
using InsertStock.Models;
using InsertStock.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace InsertStock.DAL
{
    public class InventoryContext : DbContext
    {
        IContainer container = IoCBuilder.Build();
        ConfigurationService _config = new ConfigurationService();

        public InventoryContext()
        {
            _config = container.Resolve<ConfigurationService>();
        }

        public DbSet<Inventory> Inventory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(_config.GetConnectionString("InventoryDB"));
            
    }
}
