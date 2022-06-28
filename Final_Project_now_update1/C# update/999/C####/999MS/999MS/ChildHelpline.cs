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
    public partial class ChildHelpline : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public ChildHelpline()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            More m1 = new More();
            m1.ShowDialog();
        }
        string GENDER;

        public void Reset()
        {
            textBox2.Clear();
            textBox4.Clear();
            textBox3.Clear();
          //  textBox1.Clear();

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton2.Checked = false;



        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*            MessageBox.Show($"We receive your Complain");
                        this.Hide();

                        More m2 = new More();
                        m2.ShowDialog();*/



            if (textBox2.Text != "" && textBox4.Text != "" && textBox3.Text != "" && textBox4.Text != "" && (radioButton1.Checked == true || radioButton2.Checked == true || radioButton3.Checked == true))
            {





                SqlConnection con = new SqlConnection(cs);
                string query = "insert into Child values(@nid,@NAME,@GENDER,@AGE,@PROBLEM,@Time,@Date)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@nid", login.instance.tb1.Text);
                cmd.Parameters.AddWithValue("@NAME", textBox2.Text);
                cmd.Parameters.AddWithValue("@GENDER", GENDER);
                cmd.Parameters.AddWithValue("@AGE", textBox3.Text);
                cmd.Parameters.AddWithValue("@PROBLEM", textBox4.Text);
                string Time = DateTime.Now.ToString("hh:mm:ss.f");
                string Date = DateTime.Now.ToString("dd-MM-yy");
                cmd.Parameters.AddWithValue("@Time", Time);
                cmd.Parameters.AddWithValue("@Date", Date);




                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show($"We receive your Complain", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            GENDER = "Male";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            GENDER = "Female";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            GENDER = "Others";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
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
