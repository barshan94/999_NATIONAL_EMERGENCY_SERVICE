using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _999MS
{
    public partial class Doctor : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public Doctor()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            More m1 = new More();
            m1.ShowDialog();
        }


        string GENDER;

        private void button1_Click(object sender, EventArgs e)
        {

            
            if (textBox4.Text != "" && textBox5.Text != "" && textBox2.Text != "" && textBox5.Text != "" &&(radioButton1.Checked==true||radioButton2.Checked==true||radioButton3.Checked==true))
            {





                SqlConnection con = new SqlConnection(cs);
                string query = "insert into Doctor values(@nid,@P_NAME,@GENDER,@AGE,@PROBLEM,@Time,@Date)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@nid", login.instance.tb1.Text);
                cmd.Parameters.AddWithValue("@P_NAME", textBox2.Text);
                cmd.Parameters.AddWithValue("@GENDER", GENDER);
                cmd.Parameters.AddWithValue("@AGE", textBox4.Text);
                cmd.Parameters.AddWithValue("@PROBLEM", textBox5.Text);
                string Time = DateTime.Now.ToString("hh:mm:ss.f");
                string Date = DateTime.Now.ToString("dd-MM-yy");
                cmd.Parameters.AddWithValue("@Time", Time);
                cmd.Parameters.AddWithValue("@Date", Date);



                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show($"We are prescribing you", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            textBox4.Clear();
            textBox5.Clear();
            textBox2.Clear();
           // textBox1.Clear();
   
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton2.Checked = false;



        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            GENDER = "MALE";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            GENDER = "FEMALE";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            GENDER = "OTHER";
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Service s1 = new Service();
            s1.ShowDialog();

        }
    }
}
