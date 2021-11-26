using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задание1");
            Console.WriteLine(GC.GetTotalMemory(false));

            Account account1 = new Account(1000);
            Account account2 = new Account(1000);
            account1.MakeTransfer(account2, 500);
            account2.MakeTransfer(account1, 100);

            Console.WriteLine(GC.GetTotalMemory(false));

            account1.Dispose("acc1.txt");
            account2.Dispose("acc2.txt");

            Console.WriteLine(GC.GetTotalMemory(false));

            Console.WriteLine("Задания 1,2");
            BankFabric.DeleteAccount(BankFabric.CreateAccount());

            Console.WriteLine("Домашние задания 11.");
            Creator.DeleteAccount(BankFabric.CreateAccount());

            Console.ReadKey();
        }
    }
}
