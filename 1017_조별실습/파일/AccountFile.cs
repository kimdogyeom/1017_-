using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1017_조별실습
{
    internal class AccountFile
    {
        private const string FILE_NAME = "accounts.txt";

        public static void FileSave(List<Account> accounts)
        {
            StreamWriter sw = new StreamWriter(FILE_NAME);

            //Head(메타데이터) : 몇개 저장?
            int size = accounts.Count;
            sw.WriteLine(size);

            //Data(실제 데이터)
            foreach (Account account in accounts)
            {
                //객체 직렬화 : 객체 -> 문자열 or byte배열
                string temp = string.Empty;
                temp += account.AccId + "#";
                temp += account.MemberId+ "#";
                temp += account.Balance + "#";
                temp += account.Date;

                sw.WriteLine(temp);
            }
            sw.Close();
        }

        public static void FileLoad(List<Account> accounts)
        {
            try
            {
                StreamReader sr = new StreamReader(FILE_NAME);

                //head정보 획득
                int size = int.Parse(sr.ReadLine());

                //본 데이터 획득
                for (int i = 0; i < size; i++)
                {
                    //역직렬화 : string -> Member
                    string temp = sr.ReadLine();    //홍길동#대전

                    string[] sp = temp.Split('#');  //#으로 자르기 

                    string accid        = sp[0];
                    string memberid     = sp[1];
                    int balance         = int.Parse(sp[2]);
                    DateTime date       = DateTime.Parse(sp[3]);

                    accounts.Add(new Account(accid, memberid, balance, date));
                }
                sr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
