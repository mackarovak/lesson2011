using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework
{
    class BankFabric
    {
        public static HashTable hashTable;
        static BankFabric()
        {
            hashTable = new HashTable();
        }
        public static int CreateAccount()
        {
            Account account = new Account();
            hashTable.Add(account);
            return account.Index;
        }
        public static int CreateAccount(double balance)

        {
            Account account = new Account();
            hashTable.Add(account);
            return account.Index;
        }
        public static int CreateAccount(Account.AccountType accountType)
        {
            Account account = new Account();
            hashTable.Add(account);
            return account.Index;
        }
        public static int CreateAccount(double balance, Account.AccountType accountType)
        {
            Account account = new Account();
            hashTable.Add(account);
            return account.Index;
        }
        public static void DeleteAccount(int index)
        {
            hashTable.Delete(index);
        }
    }
}
