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
    public partial class WomenChild : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public WomenChild()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            More m1 = new More();
            m1.ShowDialog();
        }


        public void Reset()
        {
            textBox1.Clear();
           // textBox3.Clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*            MessageBox.Show($"We receive your objection");
                        this.Hide();

                        More m2 = new More();
                        m2.ShowDialog();*/



            if (textBox1.Text != "")
            {

                SqlConnection con = new SqlConnection(cs);
                string query = "insert into Women_Child values(@nid,@Complain,@Time,@Date)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@nid", login.instance.tb1.Text);
                cmd.Parameters.AddWithValue("@Complain", textBox1.Text);
                string Time = DateTime.Now.ToString("hh:mm:ss.f");
                string Date = DateTime.Now.ToString("dd-MM-yy");
                cmd.Parameters.AddWithValue("@Time", Time);
                cmd.Parameters.AddWithValue("@Date", Date);




                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show($"We Accept your objection", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);


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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Service s1 = new Service();
            s1.ShowDialog();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
