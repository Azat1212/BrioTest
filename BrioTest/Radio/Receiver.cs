using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrioTest.Radio.Structs;

namespace BrioTest.Radio
{
    public class Receiver
    {
        public Receiver(Point point)
        {
            location = point;
        }

        internal Point location;
    }
    public struct Receivers
    {
        public Receiver A;
        public Receiver B;
        public Receiver C;

    }
}
