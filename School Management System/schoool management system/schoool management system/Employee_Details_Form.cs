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

namespace schoool_management_system
{
    public partial class Employee_Details_Form : Form
    {
        public Employee_Details_Form()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-195LKBK;Initial Catalog=Employee;Integrated Security=True");
        public int Serial;

        private void button3_Click(object sender, EventArgs e)
        {
            if (Serial > 0)
            {
                SqlCommand cmd = new SqlCommand("UPDATE Table_2 SET E_ID= @e_id,Name=@name,NID=@nid,F_Name=@f_name,DOB=@dob,Status=@status,Amount=@amount WHERE Serial=@ID ", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@e_id", textBox1.Text);
                cmd.Parameters.AddWithValue("@name", textBox2.Text);
                cmd.Parameters.AddWithValue("@nid", textBox3.Text);
                cmd.Parameters.AddWithValue("@f_name", textBox4.Text);
                cmd.Parameters.AddWithValue("@dob", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@status", textBox8.Text);
                cmd.Parameters.AddWithValue("@amount", textBox9.Text);
                cmd.Parameters.AddWithValue("@ID", this.Serial);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Emplyee Information is updated successfully", "updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetEmployeeRecord();
                ResetfullForm();
            }
            else
            {
                MessageBox.Show("Select an Employee to update his Info", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Serial > 0)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Table_2 WHERE Serial=@ID ", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@ID", this.Serial);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Employee is deleted from system", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetEmployeeRecord();
                ResetfullForm();
            }

            else
            {
                MessageBox.Show("Select an Employee to delet his Info", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ResetfullForm();
        }

        private void ResetfullForm()
        {
            Serial = 0;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            dateTimePicker1.ResetText();
            textBox8.Clear();
            textBox9.Clear();
            textBox1.Focus();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string e_id = textBox1.Text;
            string name = textBox2.Text;
            string nid = textBox3.Text;
            string f_name = textBox4.Text;
            DateTime dob = dateTimePicker1.Value;
            string status = textBox8.Text;
            string amount = textBox9.Text;

            if (e_id.Equals(""))
            {
                MessageBox.Show("Please enter data");
            }

            else if (name.Equals(""))
            {
                MessageBox.Show("Please enter data");
            }

            else if (nid.Equals(""))
            {
                MessageBox.Show("Please enter data");
            }
            else if (f_name.Equals(""))
            {
                MessageBox.Show("Please enter data");
            }
            else if (dob.Equals(""))
            {
                MessageBox.Show("Please enter data");
            }
            else if (status.Equals(""))
            {
                MessageBox.Show("Please enter data");
            }

            else if (amount.Equals(""))
            {
                MessageBox.Show("Please enter data");
            }

            else
            {
                SqlCommand cmd = new SqlCommand("insert into Table_2 values(@e_id, @name, @nid, @f_name,@dob,@status,@amount)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@e_id", textBox1.Text);
                cmd.Parameters.AddWithValue("@name", textBox2.Text);
                cmd.Parameters.AddWithValue("@nid", textBox3.Text);
                cmd.Parameters.AddWithValue("@f_name", textBox4.Text);
                cmd.Parameters.AddWithValue("@dob", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@status", textBox8.Text);
                cmd.Parameters.AddWithValue("@amount", textBox9.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("New Emplyee added successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetEmployeeRecord();
                ResetfullForm();
            }

    }

        private void Employee_Details_Form_Load(object sender, EventArgs e)
        {
            GetEmployeeRecord();

        }

        private void GetEmployeeRecord()
        {
            SqlCommand cmd = new SqlCommand("Select * from Table_2", con);
            DataTable dt = new DataTable();

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();

            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Serial = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox8.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            textBox9.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
