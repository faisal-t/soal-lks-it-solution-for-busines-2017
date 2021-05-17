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
    public partial class TeacherNavigation : Form
    {
        private SqlDataReader sdr;
        private SqlCommand cmd;
        private koneksi conn = new koneksi();
        private User user = new User();
        private String nama;
        public static String role = "";
        public static String id="";

        void tampilNama()
        {
            SqlConnection koneksi = conn.getKoneksi();
            try
            {
                koneksi.Open();
                var username = Form1.SetValueForText1;
                id = Form1.SetValueForText1;
                
                cmd = new SqlCommand("Select * From [Teacher] where TeacherId='" + id.ToString() + "' ", koneksi);
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

        public TeacherNavigation()
        {
            InitializeComponent();
            tampilNama();
            TeacherName.Text = nama;



        }

        private void button1_Click(object sender, EventArgs e)
        {

            role = "Teacher";
            Form2 frmEdit = new Form2();
            frmEdit.Show();
            this.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 frmLogin = new Form1();
            frmLogin.Show();
        }

        private void TeacherNavigation_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmViewScheduleTeacher frmTeaching = new FrmViewScheduleTeacher();
            frmTeaching.Show();
        }

        private void TeacherName_Click(object sender, EventArgs e)
        {

        }
    }
}
