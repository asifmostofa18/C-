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
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			SqlConnection conn = new SqlConnection("Data Source=DESKTOP-195LKBK;Initial Catalog=Students;Integrated Security=True");
			SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) From login where User_Name='" + textBox1.Text + "' and Password = '" + textBox2.Text + "'", conn);
			DataTable dt = new DataTable();
			sda.Fill(dt);
			if (dt.Rows[0][0].ToString() == "1")
			{
				this.Hide();
				Dashboard das = new Dashboard();
				das.ShowDialog();
			}

			else
			{
				MessageBox.Show("Please Enter Valid user name And password");
			}
		}

		private void label5_Click(object sender, EventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
			using (reg_form r = new schoool_management_system.reg_form())
			{
				r.ShowDialog();
			}
		}
    }
}
