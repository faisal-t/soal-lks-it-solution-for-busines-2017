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
        private String nama;
        public static String role = "Student";
        public static String id;
        

        void TampilNama()
        {
            SqlConnection koneksi = conn.getKoneksi();
            try
            {
                koneksi.Open();
                var username = Form1.SetValueForText1;
                id = Form1.SetValueForText1;
                cmd = new SqlCommand("Select * From [Student] where StudentId='" + username.ToString() + "' ", koneksi);
                //cmd.Parameters.AddWithValue("@StudentId", username);
                sdr = cmd.ExecuteReader();
                sdr.Read();



                if (sdr.HasRows)
                {

                    user.Name = sdr.GetString(1).ToString();
                    nama = sdr.GetString(1).ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            finally
            {
                koneksi.Close();
            }



        }

        public StudentNavigation()
        {
            InitializeComponent();
            Refresh();
            
        }



        public override void Refresh()
        {
            TampilNama();
            studentName.Text = nama;
        }

        

        


       

        private void StudentNavigation_Load(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Close();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frmEdit = new Form2();
            frmEdit.Show();
        }
    }
}
