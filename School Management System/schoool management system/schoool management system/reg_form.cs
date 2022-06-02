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
    public partial class reg_form : Form
    {
        public reg_form()
        {
            InitializeComponent();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-195LKBK;Initial Catalog=Students;Integrated Security=True");
            if (textBox1.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Please enter valid data");
            }
            else
            {
                SqlCommand cmd = new SqlCommand("insert into login values(@User_Name, @Password)", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@User_Name", textBox1.Text);
                cmd.Parameters.AddWithValue("@Password", textBox2.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Registration Complete!");
                this.Dispose();

            }



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void reg_form_Load(object sender, EventArgs e)
        {

        }
    }
}
