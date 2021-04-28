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
    public partial class frmManageSchedule : Form
    {

        private koneksi koneksi = new koneksi();
        private SqlCommand cmd;
        private SqlDataReader sdr;
        private SqlDataAdapter sda;
        private String kelas = "";
        private String jenis = "";
        private String detailId = "";


        public frmManageSchedule()
        {
            InitializeComponent();
            comboClassId.DropDownStyle = ComboBoxStyle.DropDownList;
            comboDay.DropDownStyle = ComboBoxStyle.DropDownList;
            comboShift.DropDownStyle = ComboBoxStyle.DropDownList;
            comboSubject.DropDownStyle = ComboBoxStyle.DropDownList;
            comboTeacher.DropDownStyle = ComboBoxStyle.DropDownList;
            kelas = comboClassId.SelectedItem.ToString();
            getTeacher();
            getSubject();
            getData();
           
            comboTeacher.Enabled = false;
            comboSubject.Enabled = false;
            comboShift.Enabled = false;
           
            btnCancel.Visible = false;
            btnSave.Visible = false;




        }

        void getTeacher()
        {
            SqlConnection conn = koneksi.getKoneksi();
            conn.Open();
            String query = "Select Teacherid,(TeacherId + '-' + Name) AS NAME From [Teacher]";
            //cmd = koneksi.getData(query, conn);
            sda = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            sda.Fill(ds,"Teacher");

            comboTeacher.DisplayMember = "NAME";
            comboTeacher.ValueMember = "TeacherId";
            comboTeacher.DataSource = ds.Tables["Teacher"];
        }

        void getSubject()
        {
            SqlConnection conn = koneksi.getKoneksi();
            conn.Open();

            if (kelas == "XA" || kelas == "XB")
            {
                kelas = "1";
            }
            else if (kelas == "XIA" || kelas == "XIB")
            {
                kelas = "2";
            }
            else
            {
                kelas = "3";
            }



            String query = "Select SubjectId,(SubjectId + '-' + Name) AS SUBJ From [Subject] where ForGrade = '"+Int32.Parse(kelas)+"' ";
            
            sda = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            sda.Fill(ds, "Subject");

            comboSubject.DisplayMember = "SUBJ";
            comboSubject.ValueMember = "SubjectId";
            comboSubject.DataSource = ds.Tables["Subject"];
            

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            jenis = "Insert";
            comboClassId.Enabled = true;
            comboDay.Enabled = true;
            comboTeacher.Enabled = true;
            comboSubject.Enabled = true;
            comboShift.Enabled = true;
            btnInsert.Visible = true;
            btnCancel.Visible = true;
            btnSave.Visible = true;
        }

        private void comboClassId_SelectedIndexChanged(object sender, EventArgs e)
        {
            kelas = comboClassId.SelectedItem.ToString();
            getSubject();
            getData();
        }



        private void comboDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            getData();
        }

        private void getData()
        {
            SqlConnection conn = koneksi.getKoneksi();
            conn.Open();

           

            if (comboClassId.SelectedItem == "XA" || comboClassId.SelectedItem == "XB")
            {
                kelas = "1";
            }
            else if (comboClassId.SelectedItem == "XIA" || comboClassId.SelectedItem == "XIB")
            {
                kelas = "2";
            }
            else
            {
                kelas = "3";
            }


            cmd = new SqlCommand("Select DetailId, DetailSchedule.SubjectId,Subject.Name,DetailSchedule.TeacherId,Teacher.Name as TeacherName,shiftId,Day From [DetailSchedule] Join[Subject] ON DetailSchedule.SubjectId = Subject.SubjectId Join[Teacher] ON DetailSchedule.TeacherId = Teacher.TeacherId where Subject.forGrade ='"+Int32.Parse(kelas)+"' And Day =@day ", conn);
            //cmd.Parameters.AddWithValue("kelas", Int32.Parse(kelas));
            cmd.Parameters.AddWithValue("day", comboDay.SelectedItem.ToString());
            cmd.ExecuteNonQuery();
            sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            
            sda.Fill(dt);

            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection conn = koneksi.getKoneksi();
            conn.Open();
            
            cmd = new SqlCommand("Select SubjectId From[Subject] where[Subject].SubjectId NOT IN(Select SubjectId From[DetailSchedule])", conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                MessageBox.Show("data pelajaran yang belum menerima guru " + sdr[0].ToString());
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            jenis = "Update";
            comboClassId.Enabled = true;
            comboDay.Enabled = true;
            comboTeacher.Enabled = true;
            comboSubject.Enabled = true;
            comboShift.Enabled = true;
            btnInsert.Visible = true;
            btnCancel.Visible = true;
            btnSave.Visible = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            comboTeacher.Enabled = false;
            comboSubject.Enabled = false;
            comboShift.Enabled = false;

            btnCancel.Visible = false;
            btnSave.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection conn = koneksi.getKoneksi();
           
            conn.Open();
            cmd = new SqlCommand("select * from [DetailSchedule] where SubjectId = @subject and TeacherId = @teacher and Day=@day and ShiftId=@shift;",conn);
            cmd.Parameters.AddWithValue("subject",comboSubject.SelectedItem);
            cmd.Parameters.AddWithValue("teacher", comboTeacher.SelectedItem);
            cmd.Parameters.AddWithValue("day", comboDay.SelectedItem);
            cmd.Parameters.AddWithValue("shift", comboShift.SelectedItem);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                MessageBox.Show("Data Pelajaran Sudah dipunyai guru lain");
            }
            else
            {
                if(jenis == "Insert")
                {
                    cmd = new SqlCommand("Insert Into [DetailSchedule] Values(@ScheduleId,@SubjectId,@TeacherId,@Day,@ShiftId)",conn);
                    cmd.Parameters.AddWithValue("ScheduleId",kelas);
                    cmd.Parameters.AddWithValue("SubjectId", comboSubject.SelectedItem);
                    cmd.Parameters.AddWithValue("TeacherId", comboTeacher.SelectedItem);
                    cmd.Parameters.AddWithValue("Day", comboDay.SelectedItem);
                    cmd.Parameters.AddWithValue("ShiftId", comboShift.SelectedItem);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Berhasil Input Schedule");
                }

                else
                {
                    cmd = new SqlCommand("Update [DetailSchedule] Set ScheduleId=@schedule , SubjectId=@subject , TeacherId = @teacher , Day = @day , ShiftId = @shift where DetailId = @detail", conn);
                    cmd.Parameters.AddWithValue("schedule", kelas);
                    cmd.Parameters.AddWithValue("subject", comboSubject.SelectedItem);
                    cmd.Parameters.AddWithValue("teacher", comboTeacher.SelectedItem);
                    cmd.Parameters.AddWithValue("day", comboDay.SelectedItem);
                    cmd.Parameters.AddWithValue("shift", comboShift.SelectedItem);
                    cmd.Parameters.AddWithValue("detail",detailId);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Berhasil Edit Schedule");
                }
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

            detailId = row.Cells[0].Value.ToString();
            //comboShift = row.Cells["ShiftId"].Value.ToString();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
