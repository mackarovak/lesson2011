using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace lesson2011
{
    internal class LQueue<T> : Queue
    {
        public override void Enqueue(object obj)
        {

            base.Enqueue(obj);
            if (Count == 4)
            {
                Dequeue();
            }
        }
    }
}
