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
    public partial class Service : Form
    {

        public static Service instance;
        public Button b1;
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public Service()
        {
            InitializeComponent();
            instance = this;
            b1 = button4;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Fire f1 = new Fire();
            f1.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            More m1 = new More();
            m1.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Police p1 = new Police();
            p1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ambulance a2 = new Ambulance();
            a2.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cdoctor c1 = new Cdoctor();
            c1.ShowDialog();
            
        }

        private void button4_Click_2(object sender, EventArgs e)
        {
           
            
                SqlConnection con = new SqlConnection(cs);
                string query = "delete from login_details where nid=@nid";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@nid", login.instance.tb1.Text);


                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Log out Successfully.. ", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    choose a1 = new choose();
                    a1.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Log out failed ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

 




        }

        private void Service_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
