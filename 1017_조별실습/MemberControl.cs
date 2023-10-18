using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1017_조별실습
{
	internal class MemberControl
	{
		private List<Member> members = new List<Member>();
		public List<Member> Members { get { return members; } }

		#region 싱글톤 패턴
		public static MemberControl Singleton { get; private set; }
		static MemberControl()
		{
			Singleton = new MemberControl();
		}
		private MemberControl()
		{
		}
		#endregion

		#region 메서드
		public bool Member_Insert(string id, string password, string name, string phone, DateTime date)
		{
			try
			{
				Member member = new Member(id, password, name, phone, date);
				foreach (Member m in members) 
				{
					if (m.MemberId == id)
						return false;
				}
				members.Add(member);
				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				return false;
			}
		}

		// 로그인
		public bool Member_Login(string id, string password)
		{
			try
			{
				Member member = members.Find(m => m.MemberId == id);
				if (member.Password == password)
				{
					return true;
				}
				
				MessageBox.Show("일치하지 않는 Id, PassWord");
				return false;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				return false;
			}
		}



		// 로그아웃
		public void Member_Logout()
		{
			try
			{
				MessageBox.Show("로그아웃");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
		#endregion

	}
}
