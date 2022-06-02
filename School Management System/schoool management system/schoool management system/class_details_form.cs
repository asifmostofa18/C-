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
    public partial class class_details_form : Form
    {
        public class_details_form()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-195LKBK;Initial Catalog=Students;Integrated Security=True");
        public int Serial;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void class_details_form_Load(object sender, EventArgs e)
        {
            GetClassRecord();
        }

        private void GetClassRecord()
        {
            SqlCommand cmd = new SqlCommand("Select * from Table_3", con);
            DataTable dt = new DataTable();

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();

            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Serial > 0)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Table_3 WHERE Serial=@ID ", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@ID", this.Serial);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Class is deleted from system", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetClassRecord();
                ResetForm();
            }

            else
            {
                MessageBox.Show("Select a Class to delet his Info", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            textBox5.Clear();
            textBox6.Clear();

            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string classs = textBox1.Text;
            string nos = textBox2.Text;
            string noc = textBox3.Text;
            string noft = textBox4.Text;
            string rn = textBox5.Text;
            string section = textBox6.Text;

            if (classs.Equals(""))
            {
                MessageBox.Show("Please enter data");
            }

            else if (nos.Equals(""))
            {
                MessageBox.Show("Please enter data");
            }

            else if (noc.Equals(""))
            {
                MessageBox.Show("Please enter data");
            }
            else if (noft.Equals(""))
            {
                MessageBox.Show("Please enter data");
            }
            else if (rn.Equals(""))
            {
                MessageBox.Show("Please enter data");
            }
            else if (section.Equals(""))
            {
                MessageBox.Show("Please enter data");
            }

            else
            {
                SqlCommand cmd = new SqlCommand("insert into Table_3 values(@classs, @nos, @noc, @noft,@rn,@section)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@classs", textBox1.Text);
                cmd.Parameters.AddWithValue("@nos", textBox2.Text);
                cmd.Parameters.AddWithValue("@noc", textBox3.Text);
                cmd.Parameters.AddWithValue("@noft", textBox4.Text);
                cmd.Parameters.AddWithValue("@rn", textBox5.Text);
                cmd.Parameters.AddWithValue("@section", textBox6.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("New Class added successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetClassRecord();
                ResetForm();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Serial > 0)
            {
                SqlCommand cmd = new SqlCommand("UPDATE Table_3 SET class= @classs,NOS=@nos,NOC=@noc,NOFT=@noft,RN=@rn,Section=@section WHERE Serial=@ID ", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@classs", textBox1.Text);
                cmd.Parameters.AddWithValue("@nos", textBox2.Text);
                cmd.Parameters.AddWithValue("@noc", textBox3.Text);
                cmd.Parameters.AddWithValue("@noft", textBox4.Text);
                cmd.Parameters.AddWithValue("@rn", textBox5.Text);
                cmd.Parameters.AddWithValue("@section", textBox6.Text);
                cmd.Parameters.AddWithValue("@ID", this.Serial);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Class Information is updated successfully", "updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetClassRecord();
                ResetForm();
            }
            else
            {
                MessageBox.Show("Select a Class to update it's Info", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Serial = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
