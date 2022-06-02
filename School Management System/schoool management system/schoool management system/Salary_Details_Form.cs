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
    public partial class Salary_Details_Form : Form
    {
        public Salary_Details_Form()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-195LKBK;Initial Catalog=Students;Integrated Security=True");
        public int Serial;

        private void button2_Click(object sender, EventArgs e)
        {
            string month = comboBox2.Text;
            string e_id = textBox1.Text;
            string name = textBox7.Text;
            string nid = textBox5.Text;
            DateTime dob = dateTimePicker1.Value;
            string des = textBox3.Text;
            string status = textBox4.Text;
            DateTime idate = dateTimePicker2.Value;
            string ts = textBox2.Text;

            if (month.Equals(""))
            {
                MessageBox.Show("Please enter data");
            }

            else if (e_id.Equals(""))
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
            else if (dob.Equals(""))
            {
                MessageBox.Show("Please enter data");
            }
            else if (des.Equals(""))
            {
                MessageBox.Show("Please enter data");
            }
            else if (status.Equals(""))
            {
                MessageBox.Show("Please enter data");
            }

            else if (idate.Equals(""))
            {
                MessageBox.Show("Please enter data");
            }
            else if (ts.Equals(""))
            {
                MessageBox.Show("Please enter data");
            }

            else
            {
                SqlCommand cmd = new SqlCommand("insert into Table_5 values(@month, @e_id, @name, @nid,@dob,@des,@status,@idate,@ts)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@month", comboBox2.Text);
                cmd.Parameters.AddWithValue("@e_id", textBox1.Text);
                cmd.Parameters.AddWithValue("@name", textBox7.Text);
                cmd.Parameters.AddWithValue("@nid", textBox5.Text);
                cmd.Parameters.AddWithValue("@dob", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@des", textBox3.Text);
                cmd.Parameters.AddWithValue("@status", textBox4.Text);
                cmd.Parameters.AddWithValue("@idate", dateTimePicker2.Value);
                cmd.Parameters.AddWithValue("@ts", textBox2.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("New Salary added successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetSalaryRecord();
                ResetForm();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Serial > 0)
            {
                SqlCommand cmd = new SqlCommand("UPDATE Table_5 SET Month= @month,E_ID=@e_id,Name=@name,NID=@nid,DOB=@dob,Designation=@des,Status=@status,ISSUE_DATE=@idate,TS=@ts WHERE Serial=@ID ", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@month", comboBox2.Text);
                cmd.Parameters.AddWithValue("@e_id", textBox1.Text);
                cmd.Parameters.AddWithValue("@name", textBox7.Text);
                cmd.Parameters.AddWithValue("@nid", textBox5.Text);
                cmd.Parameters.AddWithValue("@dob", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@des", textBox3.Text);
                cmd.Parameters.AddWithValue("@status", textBox4.Text);
                cmd.Parameters.AddWithValue("@idate", dateTimePicker2.Value);
                cmd.Parameters.AddWithValue("@ts", textBox2.Text);
                cmd.Parameters.AddWithValue("@ID", this.Serial);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Salary Information is updated successfully", "updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetSalaryRecord();
                ResetForm();
            }
            else
            {
                MessageBox.Show("Select an salary to update its Info", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

		private void button6_Click(object sender, EventArgs e)
		{
            this.Dispose();
		}

        private void Salary_Details_Form_Load(object sender, EventArgs e)
        {
            GetSalaryRecord();
        }

        private void GetSalaryRecord()
        {
            SqlCommand cmd = new SqlCommand("Select * from Table_5", con);
            DataTable dt = new DataTable();

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();

            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            Serial = 0;
            comboBox2.ResetText();
            textBox1.Clear();
            textBox7.Clear();
            textBox5.Clear();
            dateTimePicker1.ResetText();
            textBox3.Clear();
            textBox4.Clear();
            dateTimePicker2.ResetText();
            textBox2.Clear();

            comboBox2.Focus();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Serial = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            comboBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Serial > 0)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Table_5 WHERE Serial=@ID ", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@ID", this.Serial);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Salary is deleted from system", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetSalaryRecord();
                ResetForm();
            }

            else
            {
                MessageBox.Show("Select a Salary to delet its Info", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
