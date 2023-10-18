using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1017_조별실습
{
	public partial class MainForm : Form
	{
		MemberControl mc = MemberControl.Singleton;
		AccountControl ac = AccountControl.Singleton;

		public MainForm()
		{
			InitializeComponent();
		}
		
		// 로그인
		private void button1_Click(object sender, EventArgs e)
		{
			string id = textBox2.Text;
			string pw = textBox1.Text;

			if (id.Equals("admin") && pw.Equals("1234"))
			{
				// 어드민 창 실행
				Member_Admin dlg = new Member_Admin();
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					MessageBox.Show("로그아웃");
				}
			}
			
			else if (mc.Member_Login(id, pw))
			{
				// 로그인 된 경우 유저 창 실행
				Member_User dlg = new Member_User();
				dlg.MemberId = id;
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					MessageBox.Show("로그아웃");
				}
			}
			else
			{
				// 로그인 안된경우
			}


		}

		// 회원가입
		private void button2_Click(object sender, EventArgs e)
		{
			InsertForm dlg = new InsertForm();
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				if (mc.Member_Insert(dlg.MemberId, dlg.MemberPw, dlg.MemberName, dlg.MemberPhone, dlg.MemberDate))
				{
					MessageBox.Show("회원가입 성공");
				}
				else
				{
					MessageBox.Show("회원가입 실패");
				}
			}
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			MemberFile.FileSave(mc.Members);
			AccountFile.FileSave(ac.Acc);
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			MemberFile.FileLoad(mc.Members);
			AccountFile.FileLoad(ac.Acc);
		}
	}
}
