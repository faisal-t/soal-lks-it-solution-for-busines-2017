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
            conn.ConnectionString = "Data Source=HP-PC;initial catalog=LKS-2017;integrated security=true;";
            return conn;
        }

        public SqlCommand getData(String query,SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand(query,conn);
            return cmd;

        }

    }
}
