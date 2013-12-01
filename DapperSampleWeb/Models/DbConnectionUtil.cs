using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DapperSampleWeb.Models
{
    public static class DbConnectionUtil
    {
        public static System.Data.Common.DbConnection GetConnection()
        {
            var connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            // Glimpse.Adoに対応する為に、ファクトリ経由で作る
            var factory = System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient");
            var con = factory.CreateConnection();
            con.ConnectionString = connectionString;

            return con;
        }
    }
}