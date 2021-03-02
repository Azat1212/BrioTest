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
        
        public void SaveData(Receivers receivers, List<SignalTime> signalTimes, string fileName)
        {
            StringBuilder data = new StringBuilder();
                data.AppendFormat(
                    $"{receivers.A.location.X.ToString()},{receivers.A.location.Y.ToString()}," +
                    $"{receivers.B.location.X.ToString()},{receivers.B.location.Y.ToString()}," +
                    $"{receivers.C.location.X.ToString()},{receivers.C.location.Y.ToString()}" + Environment.NewLine);

            foreach (var signalTime in signalTimes)
            {
                data.AppendFormat(
                    $"{((decimal)signalTime.TimeToFirstResiever).ToString()}," +
                    $"{((decimal)signalTime.TimeToSecondResiever).ToString()}," +
                    $"{((decimal)signalTime.TimeToThirdResiever).ToString()}" + Environment.NewLine);
            }

            SaveFile(data.ToString(), fileName);
        }
        public void SaveData(List<Point> points, string fileName)
        {
            StringBuilder data = new StringBuilder();
            
            foreach (var point in points)
            {
                data.AppendFormat(
                    $"{point.X.ToString()}," +
                    $"{point.Y.ToString()}," + Environment.NewLine);
            }
            SaveFile(data.ToString(), fileName);
        }
        

        private void SaveFile(string data, string fileName)
        {
            System.IO.File.WriteAllText(fileName, data);
        }
    }
}
