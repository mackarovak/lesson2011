using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace homework
{
	class Account:Indexcreation
	{
		public enum AccountType
		{ 
			Current,
		    Savings 
		}
		private int index;
		private Type accountType;
		private double balance;
		private Queue<BankTransaction> transactions;

		static int index1 = 0;

		internal Account()
		{
			index = index1++;
			transactions = new Queue<BankTransaction>();
		}

		internal Account(double balance)
		{
			index = index1++;
			this.balance = balance;
			transactions = new Queue<BankTransaction>();
		}

		internal Account(Type accountType)
		{
			index = index1++;
			this.accountType = accountType;
			transactions = new Queue<BankTransaction>();
		}

		internal Account(Type accountType, double balance) : this(accountType)
		{
			this.balance = balance;
		}

		public bool Draw(double summa)
		{
			if (summa <= balance)
			{
				balance -= summa;
				transactions.Enqueue(new BankTransaction(-summa));
				return true;
			}
			else
			{
				return false;
			}
		}
		public bool Put(double summa)
		{
			if (summa > 0)
			{
				balance += summa;
				transactions.Enqueue(new BankTransaction(summa));
				return true;
			}
			else
			{
				return false;
			}
		}
		public bool MakeTransfer(Account receiver, double summa)
		{
			if (Draw(summa))
			{
				receiver.Put(summa);
				return true;
			}
			else
			{
				return false;
			}
		}
		public void Dispose(string file)
		{
			StreamWriter sw = new StreamWriter(file);
			sw.Write(string.Join("\n", transactions));
			sw.Close();
			GC.SuppressFinalize(sw);
		}
	}
}
