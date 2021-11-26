using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework
{
    class Creator
    {
        public static HashTable hashTable;
        static Creator()
        {
            hashTable = new HashTable();
        }
        public static int CreateAccount()
        {
            Temp temp = new Temp();
            hashTable.Add(temp);
            return temp.Index;
        }
        public static int CreateAccount(double high, int storeys, int aparts, int entrances)
        {
            Temp temp = new Temp();
            hashTable.Add(temp);
            return temp.Index;
        }
        public static void DeleteAccount(int index)
        {
            hashTable.Delete(index);
        }
    }
}
