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
	public partial class Member_Admin : Form
	{
        AccountControl ac = AccountControl.Singleton;
        MemberControl mc = MemberControl.Singleton;

        public Member_Admin()
		{
			InitializeComponent();
		}

		public void PrintAll()
		{
			listBox1.Items.Clear();
			listBox2.Items.Clear();
			foreach (Member mcc in mc.Members)
			{
				listBox1.Items.Add(mcc);
			}

            foreach (Account acc in ac.Acc)
            {
                listBox2.Items.Add(acc);
            }
        }

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void Member_Admin_Load(object sender, EventArgs e)
		{
			PrintAll();
		}
	}
}
