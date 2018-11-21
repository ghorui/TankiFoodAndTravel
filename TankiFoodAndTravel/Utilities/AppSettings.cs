using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace TankiFoodAndTravel.Utilities
{
    public class AppSettings
    {
        public string GetConnectionString()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            if (string.IsNullOrEmpty(connectionString))
                throw new ConfigurationErrorsException("Missing value for Connection string of Redshift ");

            return connectionString;
        }
    }
}