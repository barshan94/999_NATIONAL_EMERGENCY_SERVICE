using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;


namespace _999MS
{
    public partial class Police : Form
    {
      //  public static Police instance;


        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public Police()
        {
            InitializeComponent();
         //   instance = this;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Service s1 = new Service();
            s1.ShowDialog();
        }

     //     public int count ;
        
        public void button1_Click(object sender, EventArgs e)
        {
            string Time = DateTime.Now.ToString("hh:mm:ss.f");
            string Date = DateTime.Now.ToString("dd-MM-yy");
            /*
                        if (count < 100)
                        {*/

            if (textBox3.Text != "" /*&& textBox1.Text != ""*/ && textBox2.Text != "")
                {

                    SqlConnection con = new SqlConnection(cs);
                    string query = "insert into Police values(@nid,@problem,@LOCATION,@Time,@Date )";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@nid", login.instance.tb1.Text);
                    cmd.Parameters.AddWithValue("@problem", textBox3.Text);
                    cmd.Parameters.AddWithValue("@LOCATION", textBox2.Text);
                cmd.Parameters.AddWithValue("@Time", Time);
                cmd.Parameters.AddWithValue("@Date", Date);



                con.Open();
                    int a = cmd.ExecuteNonQuery();

                    if (a > 0)
                    {
                        MessageBox.Show($"We are coming", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                      //  count += 1;


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
/*            else
            {
                MessageBox.Show("Sorry, No service available");
            }




        }*/



        public void Reset()
        {
            textBox3.Clear();
           // textBox1.Clear();
            textBox2.Clear();
        }









        private void button5_Click(object sender, EventArgs e)
        {

        }



        private void textBox3_TextChanged(object sender, EventArgs e)
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
