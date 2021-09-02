using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelBilgiSistemi
{
    public abstract class LinkedListADT
    {
        public node head;
        public int size;

        public abstract void Insert(object value);
        public abstract node GetElement(object position);
    }
}
