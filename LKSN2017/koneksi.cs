using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace LKSN2017
{
    class koneksi
    {
        
        public SqlConnection getKoneksi()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=HP-PC;initial catalog=LKSN2017;integrated security=true;";
            return conn;
        }

    }
}
