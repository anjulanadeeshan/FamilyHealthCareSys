using System;
using System.Collections;
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
    public partial class frmAdminHomeAddMember : Form
    {
        public frmAdminHomeAddMember()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmLogin obj3 = new frmLogin();
            obj3.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Values cann't be empty");
            }
            else 
            {
                string query = "Insert into MemberTb values('" + Childname.Text + "','" + Gender.SelectedItem.ToString() + "', '" + DOB.Value.Date + "','" + Mothername.Text + "', '" + Address.Text + "','" + Tel.Text + "', '" + Id.Text + "')";
                MyMember Mem = new MyMember();
                try
                {
                    Mem.AddMember(query);
                    MessageBox.Show("Member successfully added");
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
                RefreshData();
            }
            
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void Gender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmAdminHomeAddMember_Load(object sender, EventArgs e)
        {
            RefreshData();
            //Filter();



        }
        private void RefreshData() 
        {
            MyMember Mem = new MyMember();
            string query = "select * from MemberTb";
            DataSet ds = Mem.ShowMember(query);

            dataGridView1.DataSource = ds.Tables[0];


        }
        

        private void button7_Click(object sender, EventArgs e)
        {
            MyMember Mem = new MyMember();
            if (key == 0)
            {
                MessageBox.Show("Select the MemberId");    
            }
            else 
            {
                try
                {
                    string query = "Delete from MemberTb where MemberId= " + key + "";
                    Mem.DeleteMember(query);

                    MessageBox.Show("Member successfully deleted");

                    RefreshData();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
            
            

        }
        int key = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null) 
            {   
                dataGridView1.CurrentRow.Selected = true;
                Childname.Text = dataGridView1.Rows[e.RowIndex].Cells["Childname"].FormattedValue.ToString();
                Gender.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells["Gender"].FormattedValue.ToString();
                Mothername.Text = dataGridView1.Rows[e.RowIndex].Cells["MotherName"].FormattedValue.ToString();
                Address.Text = dataGridView1.Rows[e.RowIndex].Cells["Address"].FormattedValue.ToString();
                Tel.Text = dataGridView1.Rows[e.RowIndex].Cells["Tel"].FormattedValue.ToString();
                Id.Text = dataGridView1.Rows[e.RowIndex].Cells["Id"].FormattedValue.ToString();

                if (Childname.Text == "")
                {
                    key = 0;
                }
                else 
                {
                    key = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {

            MyMember Mem = new MyMember();
            if (key == 0)
            {
                MessageBox.Show("Select the MemberId");
            }
            else
            {
                try
                {
                    string query = "Update MemberTb set Childname='" + Childname.Text + "',Gender='" + Gender.SelectedItem.ToString() + "', DOB='" + DOB.Value.Date + "',MotherName='" + Mothername.Text + "', Address='" + Address.Text + "',Tel='" + Tel.Text + "', Id='" + Id.Text + "'where MemberId = '" + key + "' ";
                    Mem.UpdateMember(query);

                    
                    MessageBox.Show("Member successfully Updated");

                    RefreshData();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        

        private void button8_Click(object sender, EventArgs e)
        {
            Childname.Clear();
            //Gender.DataSource = null;
            Mothername.Clear();
            Tel.Clear();
            Id.Clear();
            Address.Clear();
        }

        private void DOB_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            frmAdminHomeAppoinment App = new frmAdminHomeAppoinment();
            App.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            frmAdminHomeVaccination obj4 = new frmAdminHomeVaccination();
            obj4.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAdminHomeAddMember obj = new frmAdminHomeAddMember();
            obj.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            frmAdminHomeUser obj = new frmAdminHomeUser();
            obj.Show();
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

        private void button3_Click_1(object sender, EventArgs e)
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

        private void button12_Click(object sender, EventArgs e)
        {

        }
    }
}
