using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FamilyHealthCareSys
{
    public partial class frmAdminHomeVaccination : Form
    {
        public frmAdminHomeVaccination()
        {
            InitializeComponent();
        }

        private void Childname_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            frmAdminHomeUser obj1 = new frmAdminHomeUser();
            obj1.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            frmAdminHomeAddMember obj2 = new frmAdminHomeAddMember();
            obj2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (key == 0)
            
            {
                string query = "Insert into VaccineTb values('" + VacType.Text + "','" + Cost.Text + "', '" + Age.Text + "','" + Description.Text + "')";
                MyMember Mem = new MyMember();
                try
                {
                    Mem.AddMember(query);
                    MessageBox.Show("Vaccine details successfully added");
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
                RefreshData();
            }
        }

        private void frmVaccination_Load(object sender, EventArgs e)
        {
            RefreshData();
        }
        void RefreshData()
        {
            MyMember Mem = new MyMember();
            string query = "select * from VaccineTb";
            DataSet ds = Mem.ShowMember(query);

            dataGridView1.DataSource = ds.Tables[0];
        }

        int key = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                VacType.Text = dataGridView1.Rows[e.RowIndex].Cells["VacType"].FormattedValue.ToString();
                Cost.Text = dataGridView1.Rows[e.RowIndex].Cells["Cost"].FormattedValue.ToString();
                Age.Text = dataGridView1.Rows[e.RowIndex].Cells["Age"].FormattedValue.ToString();
                Description.Text = dataGridView1.Rows[e.RowIndex].Cells["Description"].FormattedValue.ToString();

                if (VacType.Text == "")
                {
                    key = 0;
                }
                else
                {
                    key = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MyMember Mem = new MyMember();
            if (key == 0)
            {
                MessageBox.Show("Select vaccine Id first");
            }
            else
            {
                try
                {
                    string query = "Update VaccineTb set VacType ='" + VacType.Text + "', Cost='" + Cost.Text + "', Age='" + Age.Text + "',Description ='" + Description.Text + "' where VaccineId = '" + key + "' ";
                    Mem.UpdateMember(query);


                    MessageBox.Show("Vaccine details successfully Updated");

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
            VacType.Clear();
            Cost.Clear();
            Age.Clear();
            Description.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
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
                    string query = "Delete from VaccineTb where VaccineId= " + key + "";
                    Mem.DeleteMember(query);

                    MessageBox.Show("Vaccine details successfully deleted");

                    RefreshData();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            frmAdminHomeAppoinment App = new frmAdminHomeAppoinment();
            App.Show();
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
    }
}
