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
    public partial class FrmViewScheduleTeacher : Form
    {

        private koneksi koneksi = new koneksi();
        private SqlDataAdapter sda;
        private SqlCommand cmd;
        private SqlDataReader sdr;
        private String SubjectId;
        

        public FrmViewScheduleTeacher()
        {
            InitializeComponent();
            getSchedule();
        }

        private void FrmViewScheduleTeacher_Load(object sender, EventArgs e)
        {

        }

        private void getSchedule()
        {
            SqlConnection conn = koneksi.getKoneksi();
            conn.Open();
            try
            {
                cmd = new SqlCommand("select [DetailSchedule].SubjectId,[Subject].Name Subject,[HeaderSchedule].ClassName,Day,[Shift].Time From [DetailSchedule] join [Subject] on [DetailSchedule].SubjectId = [Subject].SubjectId join [Shift] on [DetailSchedule].ShiftId = [Shift].ShiftId join [HeaderSchedule] on [DetailSchedule].ScheduleId = [HeaderSchedule].ScheduleId where TeacherId = @teacherId;", conn);
                cmd.Parameters.AddWithValue("teacherId", Form1.SetValueForText1);
                //cmd.Parameters.AddWithValue("teacherId", "T0001");
                cmd.ExecuteNonQuery();
                sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;

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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            SubjectId = row.Cells["ClassName"].Value.ToString();
            
            SqlConnection conn = koneksi.getKoneksi();
            conn.Open();
            try
            {
                cmd = new SqlCommand("select [DetailClass].StudentId,Name as StudentName,Gender from [DetailClass] join [Student] on [DetailClass].StudentId = [Student].StudentId where [DetailClass].ClassName = @className;", conn);
                cmd.Parameters.AddWithValue("className", SubjectId);
                cmd.ExecuteNonQuery();
                sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView2.DataSource = dt;
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
    }
}
