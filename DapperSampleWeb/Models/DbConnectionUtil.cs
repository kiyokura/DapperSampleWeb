using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DapperSampleWeb.Models
{
    public static class DbConnectionUtil
    {
        public static System.Data.SqlClient.SqlConnection GetConnection()
        {
            var connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            return new System.Data.SqlClient.SqlConnection(connectionString);
        }
    }
}