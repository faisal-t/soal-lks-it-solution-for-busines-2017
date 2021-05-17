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
    public partial class InputScoreForm : Form
    {
        private koneksi koneksi = new koneksi();
        private SqlCommand cmd;
        private SqlDataAdapter sda;
        private SqlDataReader sdr;
        private String Subject = "";
        private Int16 kelas = 0;


        public InputScoreForm()
        {
            InitializeComponent();
            getSubject();
        }

        private void getSubject()
        {
            SqlConnection conn = koneksi.getKoneksi();
            conn.Open();
            try
            {
                String query = "select [Subject].SubjectId,([Subject].SubjectId + '-' + [Subject].Name) as tampildata from [DetailSchedule] join [Subject] on [DetailSchedule].SubjectId = [Subject].SubjectId where TeacherId = '"+ "T0001" +"';";
                sda = new SqlDataAdapter(query, conn);
               
                DataSet ds = new DataSet();
                sda.Fill(ds, "Subject");

                comboBox1.DisplayMember = "tampildata";
                comboBox1.ValueMember = "SubjectId";
                comboBox1.DataSource = ds.Tables["Subject"];
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
