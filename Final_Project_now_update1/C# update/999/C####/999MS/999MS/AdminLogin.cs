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
    public partial class AdminLogin : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public AdminLogin()
        {
            InitializeComponent();
        }



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool status = checkBox1.Checked;
            switch (status)
            {
                case true:
                    {
                        textBox2.UseSystemPasswordChar = false;
                        break;
                    }
                default:
                    {
                        textBox2.UseSystemPasswordChar = true;
                        break;
                    }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            /*            MessageBox.Show("Log in successfully ", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        AdminService as1 = new AdminService();
                        as1.ShowDialog();*/





        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            choose l1 = new choose();
            l1.ShowDialog();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Enter your nid please....");

            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) == true)
            {
                textBox2.Focus();
                errorProvider2.SetError(this.textBox2, "Enter your password please....");

            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from Admin where nid = @nid and pass = @pass";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@nid", textBox1.Text);
                cmd.Parameters.AddWithValue("@pass", textBox2.Text);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    MessageBox.Show("Log in successfully ", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    AdminService as1 = new AdminService();
                    as1.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Log in failed ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                con.Close();
            }
            else
            {
                MessageBox.Show("Please fill the form", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
