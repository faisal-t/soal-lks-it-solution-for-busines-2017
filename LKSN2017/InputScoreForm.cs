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
        private String subject = "";
        private String kelas = "XA";
        public String StudentId = "";


        public InputScoreForm()
        {
            InitializeComponent();
            getSubject();
            getScore();
        }

        private void getScore()
        {
            SqlConnection conn = koneksi.getKoneksi();
            conn.Open();
            cmd = new SqlCommand("select [DetailScore].StudentId,[Student].Name,Assignment,MidExam,FinalExam,(Assignment+MidExam+FinalExam)/3 as Final from [DetailScore] join [DetailSchedule] on DetailScore.DetailId = DetailSchedule.DetailId join [DetailClass] on [DetailScore].StudentId = [DetailClass].StudentId join [Student] on [DetailScore].StudentId = [Student].StudentId where TeacherId = 'T0001' and SubjectId = @subjectId and ClassName = @className", conn);
            cmd.Parameters.AddWithValue("subjectId", subject);
            cmd.Parameters.AddWithValue("className", kelas);
            cmd.ExecuteNonQuery();
            sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sda.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void getSubject()
        {
            SqlConnection conn = koneksi.getKoneksi();
            conn.Open();
            try
            {
                String query = "select DISTINCT [Subject].SubjectId,([Subject].SubjectId + '-' + [Subject].Name) as tampildata from [DetailSchedule] join [Subject] on [DetailSchedule].SubjectId = [Subject].SubjectId where TeacherId = '" + "T0001" +"';";
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            subject = comboBox1.SelectedValue.ToString();
            getScore();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            kelas = comboBox2.SelectedItem.ToString();
            getScore();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

            StudentId = row.Cells[0].Value.ToString();
            MessageBox.Show("Siswa dengan ID " + StudentId + " Berhasil Dipilih");
        }
    }
}
