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
	public partial class Student_Registrationform : Form
	{
		public Student_Registrationform()
		{
			InitializeComponent();
		}

		SqlConnection con = new SqlConnection("Data Source=DESKTOP-195LKBK;Initial Catalog=Students;Integrated Security=True");
        public int Serial;
		private void Student_Registrationform_Load(object sender, EventArgs e)
		{
			GetStudentsRecord();
		}

        private void GetStudentsRecord()
        {
			SqlCommand cmd = new SqlCommand("Select * from Table_1", con);
			DataTable dt = new DataTable();

			con.Open();

			SqlDataReader sdr = cmd.ExecuteReader();
			dt.Load(sdr);
			con.Close();

			StudentRecordDataGridView.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{
            string session = textBox1.Text;
            string stu_id = textBox2.Text;
            string s_name = textBox3.Text;
            string f_name = textBox4.Text;
            string s_gender = comboBox1.Text;
            DateTime dob = dateTimePicker1.Value;
            string p_no = textBox7.Text;
            string fees = textBox8.Text;
            string s_class = textBox9.Text;
            string section = textBox10.Text;
            string address = textBox11.Text;
            string result = textBox12.Text;

            if (session.Equals(""))
            {
                MessageBox.Show("Please enter data");
            }

            else if (stu_id.Equals(""))
            {
                MessageBox.Show("Please enter data");
            }

            else if (s_name.Equals(""))
            {
                MessageBox.Show("Please enter data");
            }
            else if (f_name.Equals(""))
            {
                MessageBox.Show("Please enter data");
            }
            else if (s_gender.Equals(""))
            {
                MessageBox.Show("Please enter data");
            }
            else if (dob.Equals(""))
            {
                MessageBox.Show("Please enter data");
            }
            else if (p_no.Equals(""))
            {
                MessageBox.Show("Please enter data");
            }

            else if (fees.Equals(""))
            {
                MessageBox.Show("Please enter data");
            }
            else if (s_class.Equals(""))
            {
                MessageBox.Show("Please enter data");
            }
            else if (section.Equals(""))
            {
                MessageBox.Show("Please enter data");
            }
            else if (address.Equals(""))
            {
                MessageBox.Show("Please enter data");
            }
            else if (result.Equals(""))
            {
                MessageBox.Show("Please enter data");
            }

            else
            {
                SqlCommand cmd = new SqlCommand("insert into Table_1 values(@session, @stu_id, @s_name, @f_name, @s_gender, @dob, @p_no,@fees,@s_class,@section,@address,@result)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@session", textBox1.Text);
                cmd.Parameters.AddWithValue("@stu_id", textBox2.Text);
                cmd.Parameters.AddWithValue("@s_name", textBox3.Text);
                cmd.Parameters.AddWithValue("@f_name", textBox4.Text);
                cmd.Parameters.AddWithValue("@s_gender", comboBox1.Text);
                cmd.Parameters.AddWithValue("@dob", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@p_no", textBox7.Text);
                cmd.Parameters.AddWithValue("@fees", textBox8.Text);
                cmd.Parameters.AddWithValue("@s_class", textBox9.Text);
                cmd.Parameters.AddWithValue("@section", textBox10.Text);
                cmd.Parameters.AddWithValue("@address", textBox11.Text);
                cmd.Parameters.AddWithValue("@result", textBox12.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("New Student added successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetStudentsRecord();
                ResetForm();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Serial > 0)
            {
                SqlCommand cmd = new SqlCommand("UPDATE Table_1 SET Session= @session,Student_Id=@stu_id,Name=@s_name,Father_Name=@f_name,Gender=@s_gender,DOB=@dob,Phone_No=@p_no,fees=@fees,Class=@s_class,Section=@section,Address=@address,result=@result WHERE Serial=@ID ", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@session", textBox1.Text);
                cmd.Parameters.AddWithValue("@stu_id", textBox2.Text);
                cmd.Parameters.AddWithValue("@s_name", textBox3.Text);
                cmd.Parameters.AddWithValue("@f_name", textBox4.Text);
                cmd.Parameters.AddWithValue("@s_gender", comboBox1.Text);
                cmd.Parameters.AddWithValue("@dob", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@p_no", textBox7.Text);
                cmd.Parameters.AddWithValue("@fees", textBox8.Text);
                cmd.Parameters.AddWithValue("@s_class", textBox9.Text);
                cmd.Parameters.AddWithValue("@section", textBox10.Text);
                cmd.Parameters.AddWithValue("@address", textBox11.Text);
                cmd.Parameters.AddWithValue("@result", textBox12.Text);
                cmd.Parameters.AddWithValue("@ID", this.Serial);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Student Information is updated successfully", "updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetStudentsRecord();
                ResetForm();
            }
            else
            {
                MessageBox.Show("Select an Student to update his Info", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
			this.Dispose();
        }

        private void StudentRecordDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ResetForm();

        }

        private void ResetForm()
        {
            Serial = 0;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.ResetText();
            dateTimePicker1.ResetText();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();

            textBox1.Focus();
        }

        private void StudentRecordDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Serial = Convert.ToInt32(StudentRecordDataGridView.SelectedRows[0].Cells[0].Value);
            textBox1.Text = StudentRecordDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = StudentRecordDataGridView.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = StudentRecordDataGridView.SelectedRows[0].Cells[3].Value.ToString();
            textBox4.Text = StudentRecordDataGridView.SelectedRows[0].Cells[4].Value.ToString();
            comboBox1.Text = StudentRecordDataGridView.SelectedRows[0].Cells[5].Value.ToString();
            textBox7.Text = StudentRecordDataGridView.SelectedRows[0].Cells[7].Value.ToString();
            textBox8.Text = StudentRecordDataGridView.SelectedRows[0].Cells[8].Value.ToString();
            textBox9.Text = StudentRecordDataGridView.SelectedRows[0].Cells[9].Value.ToString();
            textBox10.Text = StudentRecordDataGridView.SelectedRows[0].Cells[10].Value.ToString();
            textBox11.Text = StudentRecordDataGridView.SelectedRows[0].Cells[11].Value.ToString();
           // textBox12.Text = StudentRecordDataGridView.SelectedRows[0].Cells[12].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Serial > 0)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Table_1 WHERE Serial=@ID ", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@ID", this.Serial);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Student is deleted from system", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetStudentsRecord();
                ResetForm();
            }

            else
            {
                MessageBox.Show("Select an Student to delet his Info", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
