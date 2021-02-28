using System;
using System.Linq;
using BrioTest.Radio.Structs;

namespace BrioTest.Radio
{
    internal class Calculate
    {
        internal static Receiver A = new Receiver();
        public static void ParseAndCalculate(string doc)
        {
            var stringsCoords =  doc.Split("\r\n,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            double[] coords = new double[stringsCoords.Length];

            for (int i = 0; i < stringsCoords.Length; i++)
            {
                coords[i] = Convert.ToDouble(stringsCoords[i]);
            }

            A.location = new Point(coords[0], coords[1]);
            var B = new Receiver()
            {
                location = new Point(coords[2], coords[3])
            };
            var C = new Receiver()
            {
                location = new Point(coords[4], coords[5])
            };


            var transmitter = new Transmitter();
            for (int i = 6; i < coords.Length - 2; i+=3)
            {
                SignalTime signalTime = new SignalTime(coords[i], coords[i+1], coords[i+2]);
                transmitter.SignalTimes.Add(signalTime);
            }


        }


    }
}
