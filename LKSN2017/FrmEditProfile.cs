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
    public partial class Form2 : Form
    {

        private koneksi koneksi = new koneksi();
        private SqlCommand cmd;
        private SqlDataReader sdr;

        public String FotoNama = "";
        private String role;



        public Form2()
        {
            InitializeComponent();
            edtId.Enabled = false;
            tampilData();
  
        }

        void tampilData()
        {
            SqlConnection conn = koneksi.getKoneksi();
            try
            {
                conn.Open();
                if(StudentNavigation.role == "Student" )
                {
                    cmd = new SqlCommand("Select * From [Student] where StudentId=@id ",conn);
                    cmd.Parameters.AddWithValue("id",StudentNavigation.id);
                    sdr = cmd.ExecuteReader();
                    //sdr.Read();
                    if (sdr.Read())
                    {
                        edtId.Text = sdr.GetString(0);
                        edtName.Text = sdr.GetString(1);
                        edtPhone.Text = sdr.GetString(5);
                        edtAddres.Text = sdr.GetString(2);
                        
                        if(!sdr.IsDBNull(6))
                        {
                            pictureBox1.ImageLocation = sdr.GetString(6);
                            FotoNama = sdr.GetString(6);
                        } 
                        

                    }
                }

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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            PictureBox picture = pictureBox1;
            String name;
            
            
            

            if(picture != null)
            {
                dialog.Filter = "(*.jpg;*.png;) | *.jpg;*.png; ";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    picture.Image = Image.FromFile(dialog.FileName); 
                    String namaFoto = DateTime.Now.ToString("ddMMyyhhmmss");

                    String location = dialog.FileName;
                    String [] part = location.Split(new char[] { '\\' });
                    String [] extension = part.Last().Split(new char[] { '.' });

                    //MessageBox.Show(extension.Last());

                    String path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));

                    System.IO.File.Copy(dialog.FileName, path + "\\images\\" + namaFoto + "." + extension.Last());
                    name = path + "\\images\\" + namaFoto + "." + extension.Last();
                    FotoNama = name;
                }
  
            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = koneksi.getKoneksi();
            String angka1 = edtPhone.Text.Substring(0, 0);
            String angka2 = edtPhone.Text.Substring(1, 1);
            try
            {
                conn.Open();

                if (edtAddres.Text == "" || edtId.Text == "" || edtName.Text == "" || edtPhone.Text == "")
                {
                    MessageBox.Show("Data must be filled");
                }

                else if (edtName.TextLength < 3 || edtName.TextLength > 20)
                {
                    MessageBox.Show("Nama Must be 3 character and maksimal 20 character");
                }

                else if (edtPhone.TextLength < 11 || edtPhone.TextLength > 12)
                {
                    MessageBox.Show("Phone must be 11-12 digit");
                }

                

                else if (angka1.Equals(0) && angka2.Equals(8))
                {
                    MessageBox.Show("Phone number must start with 0 and 8");
                }

                if (StudentNavigation.role == "Student")
                {
                    cmd = new SqlCommand("Update [Student] Set Name=@name, Address=@address, PhoneNumber=@phone, Photo=@photo where StudentId=@id ",conn);
                    cmd.Parameters.AddWithValue("name",edtName.Text.ToString());
                    cmd.Parameters.AddWithValue("address",edtAddres.Text.ToString());
                    cmd.Parameters.AddWithValue("phone",edtPhone.Text.ToString());
                    cmd.Parameters.AddWithValue("photo",FotoNama);
                    cmd.Parameters.AddWithValue("id", StudentNavigation.id);
                }

               

                

                   

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Berhasil Edit Profile");
                    this.Close();
                
                
                
                
                

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
