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
    public partial class Form1 : Form
    {

        koneksi conn = new koneksi();
        SqlCommand cmd;
        SqlDataReader sdr;
        


        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if(txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Username dan Password Tidak boleh kosong");
            }
            else
            {


                SqlConnection koneksi = conn.getKoneksi();
               
                try
                {
                    koneksi.Open();
                    cmd = new SqlCommand("Select * from [User] where username = @username and password = @password", koneksi);

                    cmd.Parameters.AddWithValue("username", txtUsername.Text.ToString());
                    cmd.Parameters.AddWithValue("password", txtPassword.Text.ToString());

                    //MessageBox.Show(cmd.CommandText.ToString());
                    
                    sdr = cmd.ExecuteReader();
                    sdr.Read();
                    if (sdr.HasRows)
                    {
                        //MessageBox.Show(sdr.GetInt32(0).ToString());
                       if(sdr.GetString(3).ToString() == "Teacher")
                        {
                            User user = new User();
                            user.UserId = (sdr.GetInt32(0));
                            user.Username = (sdr.GetString(1));
                            TeacherNavigation frmTeacher = new TeacherNavigation();
                            frmTeacher.Show();
                            this.Hide();
                        }
                       else if(sdr.GetString(3).ToString() == "Student")
                        {
                            User user = new User();
                            user.UserId = (sdr.GetInt32(0));
                            user.Username = (sdr.GetString(1));
                            StudentNavigation frmStudent = new StudentNavigation();
                            //frmStudent.user = user;
                            frmStudent.Show();
                            this.Hide();
                        }
                        else
                        {
                            User user = new User();
                            user.UserId = (sdr.GetInt32(0));
                            user.Username = (sdr.GetString(1));
                            AdminNavigation frmAdmin = new AdminNavigation();
                            frmAdmin.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Username atau password salah");
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

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
