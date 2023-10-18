using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1017_조별실습
{
	public class Account
	{
		public string AccId { get; private set; }	// 계좌번호
		public string MemberId{ get; private set; }	// 회원아이디
		public int Balance { get; set; }	// 잔액
		public DateTime Date { get; private set; }	// 개설날짜


		public Account(string accid,string memberid, int balance, DateTime date) {
			AccId = accid;
			MemberId = memberid;
			Balance = balance;
			Date = date;
		}

		public override string ToString() {
			return AccId + "\t" + MemberId + "\t" + Balance + "\t" + Date;
		}
	}
}
