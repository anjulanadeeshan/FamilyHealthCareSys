using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;

namespace FamilyHealthCareSys
{
    public partial class frmUserLogin : Form
    {
        public frmUserLogin()
        {
            InitializeComponent();
        }
        ConnectionString Conn = new ConnectionString();

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection Con = Conn.GetCon();
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from UserTb where UserName = '"+ Usertxt.Text + "' and Password = '"+Pwtxt.Text+"' ", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                frmU_Vaccination user = new frmU_Vaccination();
                this.Hide();
                this.Close();
                user.Show();
            }
            else 
            {
                MessageBox.Show("Your Password or username is incorrect. \n Enter a valid password or username");
                Usertxt.Clear();
                Pwtxt.Clear();
                Usertxt.Focus();
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            frmLogin obj1 = new frmLogin();
            obj1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Usertxt.Clear();
            Pwtxt.Clear();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Do you want to exit", "Exit", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Show();

            }
        }
    }
}
