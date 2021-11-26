using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson2011
{
    class Toss
    {
        public string name;
        public int tickets;
        public Stack<int> Winners;
        public Toss(string name, int tickets, Stack <int> Winners)
        {
            this.name = name;
            this.tickets = tickets;
            this.Winners = Winners;
        }
        public override string ToString()
        {
            string temp = "";
            foreach (int index in Winners)
            {
                temp += Program.student[index]+"\n";
            }
            return $"{name}, {temp}";
        }
    }
}
