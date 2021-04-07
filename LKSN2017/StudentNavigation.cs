using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LKSN2017
{
    public partial class StudentNavigation : Form
    {
        private SqlDataReader sdr;
        private SqlCommand cmd;
        private koneksi conn = new koneksi();
        private User user = new User();

        public StudentNavigation()
        {
            InitializeComponent();
        }


        void TampilNama()
        {
            SqlConnection koneksi = conn.getKoneksi();
            koneksi.Open();
            string username = user.Username;
            cmd = new SqlCommand("Select * from [Student] where StudentId = '" + username + "' ", koneksi);
            cmd.Parameters.AddWithValue("@StudentId", username);
            sdr = cmd.ExecuteReader();
           
            
            if (sdr.NextResult())
            {
                MessageBox.Show(sdr["Name"].ToString());
                user.Name = sdr.GetString(1).ToString();

            }

            koneksi.Close();

        }

        private void StudentNavigation_Load(object sender, EventArgs e)
        {
            TampilNama();
            label2.Text = user.Name;
        }
    }
}
