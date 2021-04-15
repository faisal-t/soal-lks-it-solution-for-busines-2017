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
    public partial class AdminNavigation : Form
    {

        private koneksi koneksi = new koneksi();
        private SqlCommand cmd;
        private SqlDataReader sdr;
        String name = "";

        void tampilNama()
        {
            SqlConnection conn = koneksi.getKoneksi();
            try
            {
                conn.Open();
                cmd = new SqlCommand("Select * From [Student] where StudentId = @id");
                cmd.Parameters.AddWithValue("id", Form1.SetValueForText1);
                MessageBox.Show(Form1.SetValueForText1);
                sdr = cmd.ExecuteReader();
                sdr.Read();
                if (sdr.HasRows)
                {
                    name = sdr.GetString(1).ToString();
                    txtAdminName.Text = sdr.GetString(1);
                }




            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }

        }

        public AdminNavigation()
        {
            InitializeComponent();
            tampilNama();
            txtAdminName.Text = name;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 frmLogin = new Form1();
            frmLogin.Show();
        }

        

        private void AdminNavigation_Load(object sender, EventArgs e)
        {

        }
    }
}
