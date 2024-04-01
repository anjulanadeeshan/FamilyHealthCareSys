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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FamilyHealthCareSys
{
    public partial class frmAdminHomeUser : Form
    {
        public frmAdminHomeUser()
        {
            InitializeComponent();
        }
        ConnectionString Conn = new ConnectionString();
        private void fillUserName()
        {
            SqlConnection Con = Conn.GetCon();
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select Childname from MemberTb", Con);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                string data = rdr["Childname"].ToString();
                UserNameCb.Items.Add(data);
            }

            rdr.Close();
            Con.Close();
        }
        private void RefreshData()
        {
            MyMember Mem = new MyMember();
            string query = "select * from UserTb";
            DataSet ds = Mem.ShowMember(query);

            dataGridView1.DataSource = ds.Tables[0];
        }
        

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            frmAdminHomeAddMember obj = new frmAdminHomeAddMember();
            obj.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            frmAdminHomeVaccination obj5 = new frmAdminHomeVaccination();
            obj5.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            frmAdminHomeAppoinment App = new frmAdminHomeAppoinment();
            App.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void frmAdminHomeUser_Load(object sender, EventArgs e)
        {
            fillUserName();
            RefreshData();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                UserNameCb.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells["UserName"].FormattedValue.ToString();
                Teltxt.Text = dataGridView1.Rows[e.RowIndex].Cells["Phone"].FormattedValue.ToString();
                Pwtxt.Text = dataGridView1.Rows[e.RowIndex].Cells["Password"].FormattedValue.ToString();

                try
                {
                    if (UserNameCb.SelectedItem.ToString() == "")
                    {
                        key = 0;
                    }
                    else
                    {
                        key = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }
        int key = 0;
        private void button10_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                try
                {
                    string query = "Insert into UserTb values('" + UserNameCb.SelectedItem.ToString() + "', '" + Teltxt.Text + "', '" + Pwtxt.Text + "')";
                    MyMember Mem = new MyMember();
                    Mem.AddMember(query);
                    MessageBox.Show("Username Password successfully added");
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
                RefreshData();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MyMember Mem = new MyMember();
            if (key == 0)
            {
                MessageBox.Show("Select the UserId");
            }
            else
            {
                try
                {
                    string query = "Update UserTb set UserName ='" + UserNameCb.SelectedItem.ToString() + "',Phone='" + Teltxt.Text + "', Password  = '"+ Pwtxt.Text +"' where UserId = '" + key + "' ";
                    Mem.UpdateMember(query);


                    MessageBox.Show("User Name, Password successfully Updated");

                    RefreshData();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MyMember Mem = new MyMember();
            if (key == 0)
            {
                MessageBox.Show("Select the AppId");
            }
            else
            {
                try
                {
                    string query = "Delete from UserTb where UserId= " + key + "";
                    Mem.DeleteMember(query);

                    MessageBox.Show("Username Password successfully deleted");

                    RefreshData();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Teltxt.Clear();
            Pwtxt.Clear();
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
    }    
}
