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
    public partial class frmManageStudent : Form
    {

        private SqlDataAdapter sda;
        private koneksi koneksi = new koneksi();
        private SqlDataReader sdr;
        private SqlCommand cmd;
        private String gender = "";
        private String jenis = "";




        public frmManageStudent()
        {
            InitializeComponent();
            btnSave.Visible = false;
            btnCancel.Visible = false;
            txtId.Enabled = false;
            txtName.Enabled = false;
            txtAddress.Enabled = false;
            txtId.Enabled = false;
            txtId.Enabled = false;
            groupBox1.Enabled = false;
            dateStudent.Enabled = false;
            txtPhone.Enabled = false;
            rdMale.Enabled = false;
            rdFemale.Enabled = false;
            tampilData();


        }

        void tampilData()
        {
            SqlConnection conn = koneksi.getKoneksi();
            conn.Open();
            String query = "Select * From [Student]";
            cmd = koneksi.getData(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlConnection conn = koneksi.getKoneksi();
            conn.Open();
            string query = "Select * From [Student] where StudentId Like '"+textBox1.Text+ "%' or Name Like '" + textBox1.Text + "%' or PhoneNumber Like '" + textBox1.Text + "%'";
            cmd = koneksi.getData(query, conn);
            //cmd.Parameters.AddWithValue("id", textBox1.Text.ToString());
            //cmd.Parameters.AddWithValue("name", textBox1.Text);
            //cmd.Parameters.AddWithValue("phone", textBox1.Text);
           
            sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();


        }

        private void frmManageStudent_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            jenis = "insert";
            btnSave.Visible = true;
            btnCancel.Visible = true;
            txtName.Enabled = true;
            txtAddress.Enabled = true;
            txtId.Enabled = true;
            groupBox1.Enabled = true;
            dateStudent.Enabled = true;
            txtPhone.Enabled = true;
            rdMale.Enabled = true;
            rdFemale.Enabled = true;

            String tahun = DateTime.Now.ToString("yyyy");

            int min = 1000;
            int max = 9999;
            Random rdm = new Random();
            int randomNumber = rdm.Next(min, max);

            txtId.Text = tahun + randomNumber.ToString();
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if(jenis.Equals("insert"))
            {

                //if (txtAddress.Text == "")
                //{
                //    MessageBox.Show("Address Must be Filled");
                //}
                if (rdMale.Checked)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }
                //else if(gender == "")
                //{
                //    MessageBox.Show("Gender Must be Filled");
                //}


                //else if (txtName.Text == "")
                //{
                //    MessageBox.Show("Name Must be filled");
                //}

                ////else if(txtName.TextLength < 3 && txtName.TextLength > 20 )
                ////{
                ////    MessageBox.Show("Name Must be 3 and 20 character");
                ////}



                //else if (!txtPhone.Text.StartsWith("08"))
                //{
                //    MessageBox.Show("Phone must be start with 0 and 8");
                //}

                ////else if (txtPhone.TextLength < 11 && txtPhone.TextLength >= 12)
                ////{
                ////    MessageBox.Show("Phone must be 11-12 digit");
                ////}





                //else
                //{

                SqlConnection conn = koneksi.getKoneksi();
                    conn.Open();
                    try
                    {
                    String password = txtName.Text[0].ToString().ToUpper() + txtName.Text.Length.ToString().ToLower() + dateStudent.Value.ToString("yyyy");
                    cmd = new SqlCommand("Insert into [User] values (@username , @password , '" + "Student" + "')", conn);
                    cmd.Parameters.AddWithValue("username", txtId.Text);
                    cmd.Parameters.AddWithValue("password", password);
                    cmd.ExecuteNonQuery();
                    //cmd.Parameters.AddWithValue("StudentId", txtId.Text);
                    //cmd.Parameters.AddWithValue("Name", txtName.Text);
                    //cmd.Parameters.AddWithValue("Address", txtAddress.Text);
                    //cmd.Parameters.AddWithValue("Gender", gender);
                    //cmd.Parameters.AddWithValue("DateofBirth", dateStudent.Value.ToString("yyyy-MM-dd"));
                    //cmd.Parameters.AddWithValue("PhoneNumber", txtPhone.Text);
                    
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("berhasil input data user");
                }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    conn.Close();
                conn.Open();
                cmd = new SqlCommand("insert into [Student] values ('" + txtId.Text.ToString() + "','" + txtName.Text.ToString() + "','" + txtAddress.Text.ToString() + "','" + gender.ToString() + "','" + dateStudent.Value.ToString("yyyy-MM-dd") + "','" + txtPhone.Text.ToString() + "','" + null + "')", conn);


                MessageBox.Show("berhasil tambah student");
                conn.Close();
            }

            //}
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnSave.Visible = false;
            btnCancel.Visible = false;
        }
    }
}
