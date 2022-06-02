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
	public partial class search_employee : Form
	{
		public search_employee()
		{
			InitializeComponent();
		}
		SqlConnection con = new SqlConnection("Data Source=DESKTOP-195LKBK;Initial Catalog=Employee;Integrated Security=True");
		SqlDataAdapter adpt;
		DataTable dt;
		private void textBox2_TextChanged(object sender, EventArgs e)
		{

		}

		private void button3_Click(object sender, EventArgs e)
		{
			showdata();
		}

		public void showdata()
		{
			adpt = new SqlDataAdapter("SELECT * FROM Table_2  WHERE E_ID = '" + textBox2.Text + "'  ", con);
			dt = new DataTable();
			adpt.Fill(dt);
			dataGridView1.DataSource = dt;
		}
	}
}
