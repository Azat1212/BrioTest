using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrioTest.Radio.Structs;

namespace BrioTest.Radio
{
    class Transmitter
    {
        internal Transmitter()
        {
            SignalTimes = new List<SignalTime>();
            Points = new List<Point>();
        }
        internal List<SignalTime> SignalTimes;
        internal List<Point> Points;

    }
}
