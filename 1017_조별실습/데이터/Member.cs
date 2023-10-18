using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1017_조별실습
{
	internal class Member
	{
		public string MemberId { get; private set; }	// 회원아이디
		public string Password { get; private set; }	// 비밀번호
		public string Name { get; private set; }		// 이름
		public string Phone { get; private set; }		// 전화번호
		public DateTime Date { get; private set; }		// 회원가입일


		public Member(string memberId, string password, string name, string phone, DateTime date)
		{
			MemberId = memberId;
			Password = password;
			Name = name;
			Phone = phone;
			Date = date;
		}
		public override string ToString()
		{
			return MemberId + "\t" + Name + "\t" + Phone + "\t" + Date;
		}
	}
}
