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
            MessageBox.Show(kelas);
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


            cmd = new SqlCommand("Select DetailSchedule.SubjectId,Subject.Name,DetailSchedule.TeacherId,Teacher.Name as TeacherName,shiftId,Day From [DetailSchedule] Join[Subject] ON DetailSchedule.SubjectId = Subject.SubjectId Join[Teacher] ON DetailSchedule.TeacherId = Teacher.TeacherId where Subject.forGrade ='"+Int32.Parse(kelas)+"' And Day =@day ", conn);
            //cmd.Parameters.AddWithValue("kelas", Int32.Parse(kelas));
            cmd.Parameters.AddWithValue("day", comboDay.SelectedItem.ToString());
            cmd.ExecuteNonQuery();
            sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;


        }

       
    }
}
