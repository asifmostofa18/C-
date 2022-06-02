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
    public partial class Expences_details_form : Form
    {
        public Expences_details_form()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-195LKBK;Initial Catalog=Students;Integrated Security=True");
        public int Serial;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string et = comboBox2.Text;
            string name = textBox1.Text;
            DateTime date  = dateTimePicker1.Value;
            string des = textBox7.Text;
            string amount = textBox5.Text;

            if (et.Equals(""))
            {
                MessageBox.Show("Please enter data");
            }

            else if (name.Equals(""))
            {
                MessageBox.Show("Please enter data");
            }

            else if (date.Equals(""))
            {
                MessageBox.Show("Please enter data");
            }
            else if (des.Equals(""))
            {
                MessageBox.Show("Please enter data");
            }
            else if (amount.Equals(""))
            {
                MessageBox.Show("Please enter data");
            }

            else
            {
                SqlCommand cmd = new SqlCommand("insert into Table_4 values(@et, @name, @date, @des,@amount)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@et", comboBox2.Text);
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@des", textBox7.Text);
                cmd.Parameters.AddWithValue("@amount", textBox5.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("New expense added successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetExpenseRecord();
                ResetForm();
            }
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

		private void label8_Click(object sender, EventArgs e)
		{

		}

		private void label7_Click(object sender, EventArgs e)
		{

		}

        private void button3_Click(object sender, EventArgs e)
        {
            if (Serial > 0)
            {
                SqlCommand cmd = new SqlCommand("UPDATE Table_4 SET ET= @et,Name=@name,Date=@date,Des=@des,Amount=@amount WHERE Serial=@ID ", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@et", comboBox2.Text);
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@des", textBox7.Text);
                cmd.Parameters.AddWithValue("@amount", textBox5.Text);
                cmd.Parameters.AddWithValue("@ID", this.Serial);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Expense Information is updated successfully", "updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetExpenseRecord();
                ResetForm();
            }
            else
            {
                MessageBox.Show("Select an expense to update his Info", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }
        

		private void panel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void button6_Click(object sender, EventArgs e)
		{
            this.Dispose();
		}

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Expences_details_form_Load(object sender, EventArgs e)
        {
            GetExpenseRecord();
        }

        private void GetExpenseRecord()
        {
            SqlCommand cmd = new SqlCommand("Select * from Table_4", con);
            DataTable dt = new DataTable();

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();

            dataGridView4.DataSource = dt;
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
            dateTimePicker1.ResetText();
            textBox7.Clear();
            textBox5.Clear();

            textBox1.Focus();
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Serial = Convert.ToInt32(dataGridView4.SelectedRows[0].Cells[0].Value);
            comboBox2.Text = dataGridView4.SelectedRows[0].Cells[1].Value.ToString();
            textBox1.Text = dataGridView4.SelectedRows[0].Cells[2].Value.ToString();
            textBox7.Text = dataGridView4.SelectedRows[0].Cells[4].Value.ToString();
            textBox5.Text = dataGridView4.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Serial > 0)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Table_4 WHERE Serial=@ID ", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@ID", this.Serial);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Expense is deleted from system", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetExpenseRecord();
                ResetForm();
            }

            else
            {
                MessageBox.Show("Select an Expense to delet this Info", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
