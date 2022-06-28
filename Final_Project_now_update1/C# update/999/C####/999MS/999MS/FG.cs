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
    public partial class FG : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public FG()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminService as1 = new AdminService();
            as1.ShowDialog();
        }

        private void FG_Load(object sender, EventArgs e)
        {

        }

        public void BindGridView()
        {


            SqlConnection con = new SqlConnection(cs);
            string query = "select * from Govt_service";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            dataGridView1.RowTemplate.Height = 100;




        }

        private void button13_Click(object sender, EventArgs e)
        {
            BindGridView();
        }

        public void Reset()
        {
            textBox3.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from Govt_service where nid=@nid";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@nid", textBox3.Text);


            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Data deleted Successfully.. ", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindGridView();
                Reset();
            }
            else
            {
                MessageBox.Show("Data not deleted !!!! ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
