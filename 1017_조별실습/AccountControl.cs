using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1017_조별실습
{
	internal class AccountControl
	{
		private List<Account> acc = new List<Account>();
		public List<Account> Acc { get { return acc; } }
		#region 싱글톤 패턴
		public static AccountControl Singleton { get; private set; }
		static AccountControl()
		{
			Singleton = new AccountControl();
		}
		private AccountControl()
		{
		}
		#endregion

		#region 메서드

		// 계좌개설 - 아이디,계좌번호,생성날짜
		public bool Create_Account(string accid, string id, DateTime date)
		{
			try
			{
				foreach (Account ac in acc)
				{
					if (ac.AccId == accid && accid == null)
						return false;
				}
				acc.Add(new Account(accid, id, 0, date));
				MessageBox.Show("계좌생성 성공");
				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show("{0}계좌생성 실패", ex.Message);
				return false;
			}
		}
		// 입금
		public bool Input_Account(string accid, int input_money)
		{
			try
			{
				if (input_money <= 0)
					return false;

				foreach (Account ac in acc)
				{
					if (ac.AccId == accid)
					{
						ac.Balance += input_money;
					}
				}
				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return false;
			}
		}

		// 출금
		public bool Output_Account(string accid, int output_money)
		{
			try
			{
				if (output_money <= 0)
				{
					return false;
				}

				foreach (Account ac in acc)
				{
					if (ac.AccId == accid)
					{
						if (ac.Balance < output_money)
						{
							MessageBox.Show("출금실패 돈 너무적음");
							return false;
						}
						else
						{
							ac.Balance -= output_money;
							return true;
						}
					}
				}
				return false;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return false;
			}
		}

		// 계좌이체
		public bool transfer_Account(string acc1, string acc2, int money)
		{
			try
			{
				int idx_I = idx_to_Acc(acc1);
				int idx_O = idx_to_Acc(acc2);

				if (acc[idx_O].Balance < money)
				{
					return false;
				}
				else
				{
					acc[idx_O].Balance -= money;
					acc[idx_I].Balance += money;

					return true;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return false;
			}
		}

		public int idx_to_Acc(string accid)
		{
			for (int i = 0; i < acc.Count; i++)
			{
				if (acc[i].AccId == accid)
					return i;
			}
			throw new Exception("없는 정보");
		}
		#endregion
	}
}
