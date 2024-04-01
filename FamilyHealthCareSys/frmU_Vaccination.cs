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

namespace FamilyHealthCareSys
{
    public partial class frmU_Vaccination : Form
    {
        public frmU_Vaccination()
        {
            InitializeComponent();
        }
        ConnectionString Conn = new ConnectionString();

        private void fillName()
        {
            SqlConnection Con = Conn.GetCon();
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select Appname from AppTb", Con);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                string data = rdr["Appname"].ToString();
                NameCb.Items.Add(data);
            }

            rdr.Close();
            Con.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            MyMember Mem = new MyMember();
            string query = "select * from AppTb where Appname = '"+NameCb.SelectedItem.ToString()+"'";
            DataSet ds = Mem.ShowMember(query);

            dataGridView1.DataSource = ds.Tables[0];
        }

        private void frmU_Vaccination_Load(object sender, EventArgs e)
        {
            fillName();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmUserHome obj = new frmUserHome();
            this.Hide();
            obj.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmU_Info obj1 = new frmU_Info();
            this.Hide();
            obj1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Do you want to Logout", "Exit", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                frmLogin spl = new frmLogin();
                this.Hide();
                spl.Show();
            }
            else
            {
                this.Show();
            }
        }

        private void button11_Click(object sender, EventArgs e)
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

        private void button7_Click(object sender, EventArgs e)
        {

        }
    }
}
