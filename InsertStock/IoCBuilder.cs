using Autofac;
using InsertStock.DAL;
using InsertStock.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace InsertStock
{
    public class IoCBuilder
    {
        public static Autofac.IContainer Build()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ConfigurationService>().AsSelf();
            builder.RegisterType<InventoryContext>().AsSelf();
            builder.RegisterType<Logger<string>>().As<ILogger>();


            return builder.Build();
        }
    }
}
