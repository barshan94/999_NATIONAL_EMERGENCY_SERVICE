using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _999MS
{
    public partial class Update : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public Update()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            choose a1 = new choose();
            a1.ShowDialog();
        }
        public void Reset()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            pictureBox2.Image = null;
        }

        byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox2.Image.Save(ms, pictureBox2.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && pictureBox2.Image != null)
            {

                SqlConnection con = new SqlConnection(cs);
                string query = "update  REG set nid=@nid,FIRST_NAME=@fname,LAST_NAME=@lname,PHONE=@phone,USERNAME=@user,PASS=@pass,PIC=@img,Time=@Time,Date=@Date where nid=@nid";


                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@nid", textBox3.Text);
                cmd.Parameters.AddWithValue("@fname", textBox1.Text);
                cmd.Parameters.AddWithValue("@lname", textBox2.Text);
                cmd.Parameters.AddWithValue("@phone", textBox4.Text);
                cmd.Parameters.AddWithValue("@user", textBox5.Text);
                cmd.Parameters.AddWithValue("@pass", textBox6.Text);
                cmd.Parameters.AddWithValue("@img", SavePhoto());
                string Time = DateTime.Now.ToString("hh:mm:ss.f");
                string Date = DateTime.Now.ToString("dd-MM-yy");
                cmd.Parameters.AddWithValue("@Time", Time);
                cmd.Parameters.AddWithValue("@Date", Date);

                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Data updated Successfully ......... ", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //  BindGridView();
                    Reset();
                }
                else
                {
                    MessageBox.Show("Data not updated !!! ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }



            }
            else
            {
                MessageBox.Show("Please fill the form", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Title = "Select Image";
            ofd.Filter = "Image File (All files) *.* | *.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = new Bitmap(ofd.FileName);
            }
        }
    }
}
