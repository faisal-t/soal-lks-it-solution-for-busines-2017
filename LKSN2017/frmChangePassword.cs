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
    public partial class frmChangePassword : Form
    {

        private koneksi koneksi = new koneksi();
        private SqlCommand cmd;
        


        public frmChangePassword()
        {
            InitializeComponent();
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            SqlConnection conn = koneksi.getKoneksi();
            conn.Open();
            try
            {

               if(txtNew.Text != txtConfirm.Text)
                {
                    MessageBox.Show("new password doesnt macth");
                }



                else
                {
                    cmd = new SqlCommand("Update [User] set password = @password where password =@oldpassword", conn);
                    cmd.Parameters.AddWithValue("password", txtConfirm.Text.Trim());
                    cmd.Parameters.AddWithValue("oldpassword", txtOld.Text);
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("berhasil mengganti password user");
                    }

                    else
                    {
                        MessageBox.Show("Password Lama Salah");
                    }
                }
               
            }
            catch(Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }


        }
    }
}
