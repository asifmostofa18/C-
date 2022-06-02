using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace schoool_management_system
{
	public partial class Dashboard : Form
	{
		public Dashboard()
		{
			InitializeComponent();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			using (Student_Registrationform res=new schoool_management_system.Student_Registrationform())
			{
				res.ShowDialog();
			}
		}

        private void button4_Click(object sender, EventArgs e)
        {
			using (class_details_form cd = new class_details_form())
            {
				cd.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
			using (Employee_Details_Form emp = new Employee_Details_Form())
            {
				emp.ShowDialog();
            }
        }

		private void button17_Click(object sender, EventArgs e)
		{
			using (Expences_details_form ex = new schoool_management_system.Expences_details_form())
			{
				ex.ShowDialog();

			}
		}

		private void button9_Click(object sender, EventArgs e)
		{
			using(Salary_Details_Form sal = new Salary_Details_Form())
			{
				sal.ShowDialog();
			}
		}

        private void button20_Click(object sender, EventArgs e)
        {
			this.Dispose();
		}

        private void button8_Click(object sender, EventArgs e)
        {
			using (teacher_details_form t = new teacher_details_form())
			{
				t.ShowDialog();
			}
		}

		private void button16_Click(object sender, EventArgs e)
		{
			using (search_student_form s = new schoool_management_system.search_student_form())
			{
				s.ShowDialog();
			}
		}

		private void button11_Click(object sender, EventArgs e)
		{

		}

		private void button14_Click(object sender, EventArgs e)
		{

		}

		private void button10_Click(object sender, EventArgs e)
		{
			using (Search_teacher s = new schoool_management_system.Search_teacher())
			{
				s.ShowDialog();
			}
		}

		private void button15_Click(object sender, EventArgs e)
		{
			using (search_employee s = new schoool_management_system.search_employee())
			{
				s.ShowDialog();
			}
		}

        private void button13_Click(object sender, EventArgs e)
        {
			using (result_form re = new schoool_management_system.result_form())
			{
				re.ShowDialog();
			}
		}

        private void button6_Click(object sender, EventArgs e)
        {
			using (fees_form fe = new schoool_management_system.fees_form())
			{
				fe.ShowDialog();
			}
		}

		private void button12_Click(object sender, EventArgs e)
		{
			using (Notice fe = new schoool_management_system.Notice())
			{
				fe.ShowDialog();
			}
		}
	}
}
