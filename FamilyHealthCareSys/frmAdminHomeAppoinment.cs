using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net;

namespace FamilyHealthCareSys
{
    public partial class frmAdminHomeAppoinment : Form
    {
        public frmAdminHomeAppoinment()
        {
            InitializeComponent();
        }
        ConnectionString Conn = new ConnectionString();

        private void fillName() 
        {
            SqlConnection Con = Conn.GetCon();
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select Childname from MemberTb", Con);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                string data = rdr["Childname"].ToString();
                NameCb.Items.Add(data);
            }

            rdr.Close();
            Con.Close();
        }
        private void fillVaccination()
        {
            SqlConnection Con = Conn.GetCon();
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select VacType from VaccineTb", Con);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                string data = rdr["VacType"].ToString();
                VactypeCb.Items.Add(data);
            }

            rdr.Close();
            Con.Close();
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void frmAppinment_Load(object sender, EventArgs e)
        {
            fillName();
            fillVaccination();
            RefreshData();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            frmAdminHomeVaccination Vac = new frmAdminHomeVaccination();
            Vac.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            frmAdminHomeUser User = new frmAdminHomeUser();
            User.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            frmAdminHomeAddMember Add = new frmAdminHomeAddMember();
            Add.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                try
                {
                    string query = "Insert into AppTb values('" + NameCb.SelectedItem.ToString() + "','" + VactypeCb.SelectedItem.ToString() + "', '" + Date.Value.Date + "','" + textBox1.Text + "', '" + textBox2.Text + "')";
                    MyMember Mem = new MyMember();
                    Mem.AddMember(query);
                    MessageBox.Show("Appoinment successfully added");
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
                RefreshData();
            }
        }
        private void RefreshData()
        {
            MyMember Mem = new MyMember();
            string query = "select * from AppTb";
            DataSet ds = Mem.ShowMember(query);

            dataGridView1.DataSource = ds.Tables[0];
        }
        int key = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                NameCb.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells["Appname"].FormattedValue.ToString();
                VactypeCb.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells["VaccineType"].FormattedValue.ToString();
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["Time"].FormattedValue.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["Place"].FormattedValue.ToString();

                try
                {
                    if (NameCb.SelectedItem.ToString() == "")
                    {
                        key = 0;
                    }
                    else
                    {
                        key = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    }
                }
                catch(Exception Ex) 
                {
                    MessageBox.Show(Ex.Message);
                }
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
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
                    string query = "Delete from AppTb where AppId= " + key + "";
                    Mem.DeleteMember(query);

                    MessageBox.Show("Appoinment successfully deleted");

                    RefreshData();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
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
                    string query = "Update AppTb set Appname ='" + NameCb.SelectedValue.ToString() + "', VaccineType='" +VactypeCb.SelectedValue.ToString() + "', Date='" + Date.Value.Date + "',Time='" + textBox1.Text + "', Place='" + textBox2.Text + "' where AppId = '" + key + "' ";
                    Mem.UpdateMember(query);


                    MessageBox.Show("Appoinment successfully Updated");

                    RefreshData();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
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

        private void button8_Click(object sender, EventArgs e)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void NameCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
