using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace VendingMachineAPI
{
    public class Settings
    {
        private static string _connectionString;
        private static string _repositoryType;
        HttpResponse response;

        public static string GetConnectionString()
        {
            // If string is null or empty.
            if (string.IsNullOrEmpty(_connectionString))
                // Load the connection string from Web.config file.
                _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            return _connectionString;
        }

        public static string GetRepositoryType()
		{
			if (string.IsNullOrEmpty(_repositoryType))
				_repositoryType = ConfigurationManager.AppSettings["Mode"].ToString();

			return _repositoryType;
		}

        public void Error(string messages)
        {
             response.Write(messages);
        }



    }
}