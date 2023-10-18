using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _1017_조별실습
{
	public partial class Member_User : Form
	{
		AccountControl ac = AccountControl.Singleton;

		#region 컨트롤과 연결된 속성
		public string MemberId { get; set; }
		public string AccId { get; private set; }
		public int Balance { get; private set; }
		public DateTime MemberDate { get { return DateTime.Now; } }
		#endregion

		public Member_User()
		{
			InitializeComponent();
		}

		public void PrintAll()
		{
			listBox1.Items.Clear();
			foreach (Account account in ac.Acc)
			{
				listBox1.Items.Add(account);
			}

		}

		private void button1_Click(object sender, EventArgs e)
		{
			AccId = textBox3.Text;
			ac.Create_Account(AccId, MemberId, MemberDate);
			PrintAll();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			this.Close();
			PrintAll();
		}

		private void Member_User_Load(object sender, EventArgs e)
		{
			PrintAll();
			label1.Text = String.Format("접속중인 아이디 : {0}", MemberId);
		}

		private void Member_User_FormClosing(object sender, FormClosingEventArgs e)
		{
			AccountFile.FileSave(ac.Acc);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			string accId = textBox3.Text;
			int money = int.Parse(textBox2.Text);
			ac.Input_Account(accId, money);
			PrintAll();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			string accId = textBox3.Text;
			int money = int.Parse(textBox2.Text);
			ac.Output_Account(accId, money);
			PrintAll();
		}

		//계좌이체
        private void button4_Click(object sender, EventArgs e)
        {
			string acc1 = textBox1.Text;    // 상대계좌
			string acc2 = textBox3.Text;    // 내계좌

			int money = int.Parse(textBox2.Text);

			ac.transfer_Account(acc1, acc2, money);
			PrintAll();

		}
	}
}
