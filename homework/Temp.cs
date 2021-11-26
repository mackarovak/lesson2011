using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework
{
    class Temp:Indexcreation
    {
        private int Height;
        private int Numberoffloors;
        private int Numberofapartments;
        private int Numberofentrances;
        private static int UniqueNumber = 0;

        public Temp()
        {
            index = UniqueNumber++;
        }

        public Temp(int Height, int Numberoffloors, int Numberofapartments, int Numberofentrances)
        {
            index = UniqueNumber++;
            this.Height = Height;
            this.Numberoffloors = Numberoffloors;
            this.Numberofapartments = Numberofapartments;
            this.Numberofentrances = Numberofentrances;
        }
    }
}
