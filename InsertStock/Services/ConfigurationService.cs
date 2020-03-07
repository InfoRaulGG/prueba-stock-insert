using System.IO;
using Microsoft.Extensions.Configuration;

namespace InsertStock.Services
{
    public class ConfigurationService
    {
         private IConfigurationBuilder builder { get; set; }
        private IConfigurationRoot configuration { get; set; }
        public ConfigurationService()
        {
            this.builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            this.configuration = builder.Build();
        }

        public string GetConnectionString(string ConnectionString)
        {
            return this.configuration.GetValue<string>("ConnectionString:" + ConnectionString);
        }

        public string GetConfigurationSetting(string key)
        {
            return this.configuration.GetValue<string>("Configuration:" + key);
        }
    }
}