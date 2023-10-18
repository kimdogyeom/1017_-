using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace _1017_조별실습
{
	public partial class InsertForm : Form
	{
		#region 컨트롤과 연결된 속성
		public string MemberId
		{
			get { return textBox1.Text; }

			set { textBox1.Text = value; }
		}

		public string MemberPw
		{
			get { return textBox2.Text; }
			set { textBox2.Text = value; }
		}

		public string MemberName 
		{
			get { return textBox3.Text; }
			set { textBox3.Text = value; }
		}
		public string MemberPhone
		{
			get { return textBox4.Text; }
			set { textBox4.Text = value; }
		}
		public DateTime MemberDate
		{
			get { return dateTimePicker1.Value; }
			set { dateTimePicker1.Value = value; }
		}

		#endregion

		public InsertForm()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			
		}
	}
}
