using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework
{
    class HashTable
    {
        private Dictionary<int, Indexcreation> hashtable;
        public HashTable()
        {
            hashtable = new Dictionary<int, Indexcreation>();
        }
        internal void Add (Indexcreation indexcreation)
        {
            hashtable.Add(indexcreation.Index, indexcreation);
        }
        internal void Delete (int index)
        {
            hashtable.Remove(index);
        }
    }
}
