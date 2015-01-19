using System;
using System.Configuration;

namespace Exercise2.Infrastructure
{
    public class ConfigurationManagerProvider : IConfigurationManagerProvider
    {
        public string GetConnectionString()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Exercise2ConnectionString"].ConnectionString;

            if (connectionString == null)
                throw new ArgumentException("\"Exercise2ConnectionString\" connection string is missing in the .config file (under connectionStrings section)");

            return connectionString;
        }
    }
}
