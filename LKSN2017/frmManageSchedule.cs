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

            //if (kelas == "XA" || "X")
            //{

            //}

            String query = "Select SubjectId,(SubjectId + '-' + Name) AS SUBJ From [Subject] where ForGrade = '"+kelas+"' ";
            
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
        }
    }
}
