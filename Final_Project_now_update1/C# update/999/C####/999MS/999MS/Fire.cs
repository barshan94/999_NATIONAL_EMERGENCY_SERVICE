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
    public partial class Fire : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public Fire()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Service s1 = new Service();
            s1.ShowDialog();
        }

        string Type;
        private void button2_Click(object sender, EventArgs e)
        {



            if (textBox3.Text != "" && (radioButton1.Checked == true || radioButton2.Checked == true))
            {

                SqlConnection con = new SqlConnection(cs);
                string query = "insert into Fire values(@nid,@LOCATION,@Type,@Time,@Date)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@nid", login.instance.tb1.Text);
               
                cmd.Parameters.AddWithValue("@LOCATION", textBox3.Text);
                cmd.Parameters.AddWithValue("@Type", Type);

                string Time =  DateTime.Now.ToString("hh:mm:ss.f");
                string Date =  DateTime.Now.ToString("dd-MM-yy");
                cmd.Parameters.AddWithValue("@Time", Time);
                cmd.Parameters.AddWithValue("@Date", Date);


                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show($"We are coming", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    Reset();
                }
                else
                {
                    MessageBox.Show("Data not Inserted properly ! ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }



            }
            else
            {
                MessageBox.Show("Please fill the form", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }





        }




        public void Reset()
        {
            textBox3.Clear();
           // textBox2.Clear();
            //textBox1.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }



/*        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text) == true)
            {
                textBox3.Focus();
                errorProvider1.SetError(this.textBox3, "Enter your NID please....");

            }
            else
            {
                errorProvider1.Clear();
            }
        }*/

/*        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider2.SetError(this.textBox1, "Enter your location please....");

            }
            else
            {
                errorProvider2.Clear();
            }
        }*/

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

/*        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) == true)
            {
                textBox2.Focus();
                errorProvider3.SetError(this.textBox2, "Explain please....");

            }
            else
            {
                errorProvider3.Clear();
            }
        }*/

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Type = "Fire";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Type = "Rescue";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Service s1 = new Service();
            s1.ShowDialog();

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
