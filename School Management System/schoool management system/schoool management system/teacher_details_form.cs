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
    public partial class teacher_details_form : Form
    {
        public teacher_details_form()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-195LKBK;Initial Catalog=Students;Integrated Security=True");
        public int Serial;

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string t_id = textBox1.Text;
            string name = textBox2.Text;
            string nid = textBox3.Text;
            string des = textBox4.Text;
            DateTime dob = dateTimePicker1.Value;
            string ex = textBox8.Text;
            string ri = textBox9.Text;
            string email = textBox5.Text;

            if (t_id.Equals(""))
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
            else if (des.Equals(""))
            {
                MessageBox.Show("Please enter data");
            }
            else if (dob.Equals(""))
            {
                MessageBox.Show("Please enter data");
            }
            else if (ex.Equals(""))
            {
                MessageBox.Show("Please enter data");
            }

            else if (ri.Equals(""))
            {
                MessageBox.Show("Please enter data");
            }
            else if (email.Equals(""))
            {
                MessageBox.Show("Please enter data");
            }

            else
            {
                SqlCommand cmd = new SqlCommand("insert into Table_2 values(@t_id, @name, @nid, @des,@dob,@ex,@ri,@email)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@t_id", textBox1.Text);
                cmd.Parameters.AddWithValue("@name", textBox2.Text);
                cmd.Parameters.AddWithValue("@nid", textBox3.Text);
                cmd.Parameters.AddWithValue("@des", textBox4.Text);
                cmd.Parameters.AddWithValue("@dob", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@ex", textBox8.Text);
                cmd.Parameters.AddWithValue("@ri", textBox9.Text);
                cmd.Parameters.AddWithValue("@email", textBox5.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("New Student added successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetTeacherRecord();
                ResetForm();
            }



        }

        private void teacher_details_form_Load(object sender, EventArgs e)
        {
            GetTeacherRecord();
        }

        private void GetTeacherRecord()
        {
            SqlCommand cmd = new SqlCommand("Select * from Table_2", con);
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
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            dateTimePicker1.ResetText();
            textBox8.Clear();
            textBox9.Clear();
            textBox5.Clear();

            textBox1.Focus();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Serial > 0)
            {
                SqlCommand cmd = new SqlCommand("UPDATE Table_2 SET T_ID= @t_id,Name=@name,NID=@nid,Designation=@des,DOB=@dob,Experience=@ex,RI=@ri,Email=@email WHERE Serial=@ID ", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@t_id", textBox1.Text);
                cmd.Parameters.AddWithValue("@name", textBox2.Text);
                cmd.Parameters.AddWithValue("@nid", textBox3.Text);
                cmd.Parameters.AddWithValue("@des", textBox4.Text);
                cmd.Parameters.AddWithValue("@dob", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@ex", textBox8.Text);
                cmd.Parameters.AddWithValue("@ri", textBox9.Text);
                cmd.Parameters.AddWithValue("@email", textBox5.Text);
                cmd.Parameters.AddWithValue("@ID", this.Serial);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Teacher Information is updated successfully", "updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetTeacherRecord();
                ResetForm();
            }
            else
            {
                MessageBox.Show("Select a Teacher to update his Info", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
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
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();

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

                MessageBox.Show("Teacher is deleted from system", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetTeacherRecord();
                ResetForm();
            }

            else
            {
                MessageBox.Show("Select a Teacher to delet his Info", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
