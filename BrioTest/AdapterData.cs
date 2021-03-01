using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrioTest.Radio;
using BrioTest.Radio.Structs;

namespace BrioTest
{
    class AdapterData
    {
        public (Receivers receivers, List<SignalTime> signalTimes) Parse(string input)
        {
            Receivers receivers;
            List<SignalTime> signalTimes = new List<SignalTime>();

            var stringsCoords = input.Split("\r\n,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            double[] coords = new double[stringsCoords.Length];

            for (int i = 0; i < stringsCoords.Length; i++)
            {
                coords[i] = Convert.ToDouble(stringsCoords[i]);
            }

            receivers.A = new Radio.Receiver(new Point(coords[0], coords[1]));
            receivers.B = new Radio.Receiver(new Point(coords[2], coords[3]));
            receivers.C = new Radio.Receiver(new Point(coords[4], coords[5]));

            for (int i = 6; i < coords.Length - 2; i += 3)
            {
                SignalTime signalTime = new SignalTime(coords[i], coords[i + 1], coords[i + 2]);
                signalTimes.Add(signalTime);
            }
            return (receivers, signalTimes);
        }

        public void SaveData(Receivers receivers, List<SignalTime> signalTimes)
        {


        }
        public void SaveData(List<Point> points)
        {


        }
    }
}
