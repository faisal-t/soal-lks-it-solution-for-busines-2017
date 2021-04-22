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
    public partial class frmManageClass : Form
    {

        private koneksi koneksi = new koneksi();
        private SqlCommand cmd;
        private SqlDataAdapter sda;
        private SqlDataReader sdr;
        private String participate = "";
        private String StudentId = "";



        public frmManageClass()
        {
            InitializeComponent();
            comboKelas.DropDownStyle = ComboBoxStyle.DropDownList;
            tampilSiswa();

          


        }

       
        void tampilSiswa()
        {
            SqlConnection conn = koneksi.getKoneksi();
            conn.Open();
            try
            {
                cmd = new SqlCommand("select StudentId,Name From[Student] where StudentId NOT IN(Select StudentId From[DetailClass])",conn);
                cmd.ExecuteNonQuery();
                sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch(Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
        }

        void participateStudent(String kelas)
        {
            SqlConnection conn = koneksi.getKoneksi();
            conn.Open();
            try
            {
                cmd = new SqlCommand("SELECT [Student].StudentId,Name  FROM [DetailClass] right Join [Student] on [DetailClass].StudentId = [Student].StudentId where ClassName = @kelas", conn);
                cmd.Parameters.AddWithValue("kelas", kelas);
                cmd.ExecuteNonQuery();
                sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView2.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

       

        private void comboKelas_SelectedIndexChanged(object sender, EventArgs e)
        {
            String kelas = "";
            kelas = comboKelas.SelectedItem.ToString();
           
            participate = kelas;
            participateStudent(participate);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            StudentId = row.Cells["StudentId"].Value.ToString();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
            StudentId = row.Cells["StudentId"].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = koneksi.getKoneksi();
            conn.Open();
            try
            {
                cmd = new SqlCommand("INSERT INTO [DetailClass] values (@class ,@studentid) ", conn);
                cmd.Parameters.AddWithValue("class", participate.ToString());
                cmd.Parameters.AddWithValue("studentid", StudentId).ToString();
                cmd.ExecuteNonQuery();
                tampilSiswa();
                participateStudent(participate);
                MessageBox.Show("Berhasil Insert siswa");
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

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = koneksi.getKoneksi();
            conn.Open();
            try
            {
                cmd = new SqlCommand("Delete From [DetailClass] where StudentId = @studentid", conn);
                cmd.Parameters.AddWithValue("studentid", StudentId).ToString();
                cmd.ExecuteNonQuery();
                tampilSiswa();
                participateStudent(participate);
                MessageBox.Show("Berhasil Hapus siswa");
            }
            catch (Exception ex)
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
