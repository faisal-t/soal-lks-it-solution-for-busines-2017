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
        private int Year;





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
            txtId.Enabled = false;
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
            
            

            if (jenis.Equals("insert"))
            {

                Year = DateTime.Now.Year - dateStudent.Value.Year;

                if (rdMale.Checked)
                {
                    gender = "Male";
                }
                else if (rdFemale.Checked)
                {
                    gender = "Female";
                }

                if (txtAddress.Text == "")
                {
                    MessageBox.Show("Address Must be Filled");
                }

                




                else if (gender == "")
                {
                    MessageBox.Show("Gender Must be Filled");
                }


                else if (txtName.Text == "")
                {
                    MessageBox.Show("Name Must be filled");
                }

                else if (txtName.Text.Length < 3 || txtName.Text.Length> 20)
                {
                    MessageBox.Show("Name Must be 3 and 20 character");
                }



                else if (!txtPhone.Text.StartsWith("08"))
                {
                    MessageBox.Show("Phone must be start with 0 and 8");
                }

                else if (txtPhone.Text.Length < 11 || txtPhone.Text.Length >= 12)
                {
                    MessageBox.Show("Phone must be 11-12 digit");
                }


                else if(Year < 15 && Year > 21)
                {
                    MessageBox.Show("the age student must be between 15 and 21 years");
                }



                else
                {

                    SqlConnection conn = koneksi.getKoneksi();
                    conn.Open();
                    try
                    {

                    cmd = new SqlCommand("insert into [Student] values ('" + txtId.Text.ToString() + "','" + txtName.Text.ToString() + "','" + txtAddress.Text.ToString() + "','" + gender.ToString() + "','" + dateStudent.Value.ToString("yyyy-MM-dd") + "','" + txtPhone.Text.ToString() + "','" + null + "')", conn);
                    cmd.ExecuteNonQuery();
                    String password = txtName.Text[0].ToString().ToUpper() + txtName.Text.Length.ToString().ToLower() + dateStudent.Value.ToString("yyyy");
                    cmd = new SqlCommand("Insert into [User](username, password, role) values ('" + txtId.Text + "' , '" + password + "' , '" + "Student" + "') ", conn);

                    //cmd.Parameters.AddWithValue("username", txtId.Text);
                    //cmd.Parameters.AddWithValue("password", password);
                    cmd.ExecuteNonQuery();

                    //cmd.Parameters.AddWithValue("StudentId", txtId.Text);
                    //cmd.Parameters.AddWithValue("Name", txtName.Text);
                    //cmd.Parameters.AddWithValue("Address", txtAddress.Text);
                    //cmd.Parameters.AddWithValue("Gender", gender);
                    //cmd.Parameters.AddWithValue("DateofBirth", dateStudent.Value.ToString("yyyy-MM-dd"));
                    //cmd.Parameters.AddWithValue("PhoneNumber", txtPhone.Text);


                    MessageBox.Show("berhasil input data user");
                }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    MessageBox.Show("berhasil tambah student");
                    conn.Close();
                    tampilData();
            }

            }

            else
            {

                Year = DateTime.Now.Year - dateStudent.Value.Year;
                if (rdMale.Checked)
                {
                    gender = "Male";
                }
                else if (rdFemale.Checked)
                {
                    gender = "Female";
                }

                if (txtAddress.Text == "")
                {
                    MessageBox.Show("Address Must be Filled");
                }






                else if (gender == "")
                {
                    MessageBox.Show("Gender Must be Filled");
                }


                else if (txtName.Text == "")
                {
                    MessageBox.Show("Name Must be filled");
                }

                else if (txtName.Text.Length < 3 || txtName.Text.Length > 20)
                {
                    MessageBox.Show("Name Must be 3 and 20 character");
                }



                else if (!txtPhone.Text.StartsWith("08"))
                {
                    MessageBox.Show("Phone must be start with 0 and 8");
                }

                else if (txtPhone.Text.Length < 11 || txtPhone.Text.Length >= 12)
                {
                    MessageBox.Show("Phone must be 11-12 digit");
                }


                else if (Year < 15 && Year > 21)
                {
                    MessageBox.Show("the age student must be between 15 and 21 years");
                }





                else
                {

                    SqlConnection conn = koneksi.getKoneksi();
                    conn.Open();
                    try
                    {

                        cmd = new SqlCommand("Update [Student] set StudentId = '" + txtId.Text.ToString() + "', Name = '" + txtName.Text.ToString() + "', Address = '" + txtAddress.Text.ToString() + "',Gender = '" + gender.ToString() + "', DateofBirth = '" + dateStudent.Value.ToString("yyyy-MM-dd") + "', PhoneNumber = '" + txtPhone.Text.ToString() + "' where StudentId = '"+txtId.Text+"' ", conn);
                        cmd.ExecuteNonQuery();
                        String password = txtName.Text[0].ToString().ToUpper() + txtName.Text.Length.ToString().ToLower() + dateStudent.Value.ToString("yyyy");
                        cmd = new SqlCommand("Update [User] Set Username = '" + txtId.Text + "' , Password = '" + password + "' , Role = '" + "Student" + "' ", conn);

                        //cmd.Parameters.AddWithValue("username", txtId.Text);
                        //cmd.Parameters.AddWithValue("password", password);
                        cmd.ExecuteNonQuery();

                        //cmd.Parameters.AddWithValue("StudentId", txtId.Text);
                        //cmd.Parameters.AddWithValue("Name", txtName.Text);
                        //cmd.Parameters.AddWithValue("Address", txtAddress.Text);
                        //cmd.Parameters.AddWithValue("Gender", gender);
                        //cmd.Parameters.AddWithValue("DateofBirth", dateStudent.Value.ToString("yyyy-MM-dd"));
                        //cmd.Parameters.AddWithValue("PhoneNumber", txtPhone.Text);


                        MessageBox.Show("berhasil Update data user");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    MessageBox.Show("berhasil tambah student");
                    conn.Close();
                    tampilData();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            jenis = "update";
            btnSave.Visible = true;
            btnCancel.Visible = true;
            txtName.Enabled = true;
            txtAddress.Enabled = true;
            txtId.Enabled = false;
            groupBox1.Enabled = true;
            dateStudent.Enabled = true;
            txtPhone.Enabled = true;
            rdMale.Enabled = true;
            rdFemale.Enabled = true;

          

            
        }

        void clear()
        {
            btnSave.Visible = false;
            btnCancel.Visible = false;
            txtId.Enabled = false;
            txtName.Enabled = false;
            txtAddress.Enabled = false;
            groupBox1.Enabled = false;
            dateStudent.Enabled = false;
            txtPhone.Enabled = false;
            rdMale.Enabled = false;
            rdFemale.Enabled = false;

            txtId.Text = "";
            txtName.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            rdMale.Checked = false;
            rdFemale.Checked = false;
            dateStudent.Value = DateTime.Now;


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                txtId.Text = row.Cells["StudentId"].Value.ToString();
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtPhone.Text = row.Cells["PhoneNumber"].Value.ToString();
                txtAddress.Text = row.Cells["Address"].Value.ToString();
                dateStudent.Text = row.Cells["DateofBirth"].Value.ToString();
                String jenisKelamin = row.Cells["Gender"].Value.ToString();
                if (jenisKelamin == "Male")
                {
                    rdMale.Checked = true;
                }
                else
                {
                    rdFemale.Checked = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Yakin Ingin Menghapus Data ? ", "", MessageBoxButtons.YesNo);
            
                SqlConnection conn = koneksi.getKoneksi();
                conn.Open();
                try
                {
                    cmd = new SqlCommand("Delete From [User] where username=@username", conn);
                    cmd.Parameters.AddWithValue("username",txtId.Text);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("Delete From [Student] where StudentId=@id", conn);
                    cmd.Parameters.AddWithValue("id", txtId.Text);
                    cmd.ExecuteNonQuery();
                    
                    conn.Close();
                    tampilData();
                    clear();


            }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void rdMale_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdFemale_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dateStudent_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
    
}
