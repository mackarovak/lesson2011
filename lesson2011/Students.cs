using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson2011
{
    class Students
    {
        public string name { get; private set; }
        public string affiliation { get; private set; }
        public double ratio { get; set; }
        public Students (string name, string affiliation)
        {
            this.name = name;
            this.affiliation = affiliation;
            ratio = 1;
        }
        public override string ToString()
        {
            return ($"{name}, {affiliation} ");
        }
    }
}
