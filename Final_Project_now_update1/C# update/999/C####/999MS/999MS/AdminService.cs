using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _999MS
{
    public partial class AdminService : Form
    {
        public AdminService()
        {
            InitializeComponent();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminLogin al1 = new AdminLogin();
            al1.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminPolice ap1 = new AdminPolice();
            ap1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminFire af1 = new AdminFire();
            af1.ShowDialog();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminAmbulance aa1 = new AdminAmbulance();
            aa1.ShowDialog();
        }

/*        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
            
           
           

            
        }*/

/*        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }*/

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Covid f3 = new Admin_Covid();
            f3.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            FD fd1 = new FD();
            fd1.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            FA fa1 = new FA();
            fa1.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            FC fc1 = new FC();
            fc1.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            FW fw1 = new FW();
            fw1.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            FG fg1 = new FG();
            fg1.ShowDialog();

        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Hide();
            allusers a1 = new allusers();
            a1.ShowDialog();

        }

        private void AdminService_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Covid a1 = new Admin_Covid();
            a1.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Userlogindetails a1 = new Userlogindetails();
            a1.ShowDialog();
        }
    }


}
