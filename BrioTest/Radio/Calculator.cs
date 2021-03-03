using System;
using System.Collections.Generic;
using System.Linq;
using BrioTest.Radio.Structs;

namespace BrioTest.Radio
{
    internal class Calculator
    {
        private Receivers _receivers;
        private Transmitter _transmitter = new Transmitter();
        private const double epsilon = 0.1;
        private const double velocity = 1000.0; // скорость прохождения сигнала
        private const double metersPerKilometer = 1000.0; // перевод из километров в метры

        /// <summary>
        /// Расчитывает траекторию передатчика относительно заданных сигналов сигнала
        /// </summary>
        public void Calculate(Receivers receivers, List<SignalTime> signalsTime)
        {
            _receivers = receivers;
            _transmitter.SignalTimes = signalsTime;

            foreach (var signalTime in _transmitter.SignalTimes)
            {
                HasThreeCircleIntersection(
                    TimeToDistance(signalTime.TimeToFirstResiever),
                    TimeToDistance(signalTime.TimeToSecondResiever),
                    TimeToDistance(signalTime.TimeToThirdResiever));
            }
        }

        /// <summary>
        /// Добавляет новые координаты передатчика и расчитывает сигналы для каждого приемника
        /// </summary>
        public void AddTransmitterPoint(Point point)
        {
            _transmitter.Points.Add(point);

            var time1 = CalculateTime(point, _receivers.A.location);
            var time2 = CalculateTime(point, _receivers.B.location);
            var time3 = CalculateTime(point, _receivers.C.location);

            _transmitter.SignalTimes.Add(new SignalTime(time1,time2,time3));
        }
        /// <summary>
        /// Расчитывает время  прохождения сигнала между точками
        /// /// </summary>
        private double CalculateTime(Point point1, Point point2)
        {
            var distance = Math.Sqrt(Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point1.Y, 2));
            return distance/(velocity * metersPerKilometer);
        }

        /// <summary>
        /// Возвращает траекторию передатчика
        /// </summary>
        public List<Point> GetTransmitterPoints()
        {
            return _transmitter.Points;
        }

        /// <summary>
        /// Возвращает координаты приемников
        /// </summary>
        public List<Point> GetReceiverPoints()
        {
            return new List<Point>()
            {
                _receivers.A.location,
                _receivers.B.location,
                _receivers.C.location
            };
        }

        /// <summary>
        /// Возвращает приемники и времена прохождения сигнала для каждой точки передатчика
        /// </summary>
        public (Receivers receivers, List<SignalTime> signalTimes) GetData()
        {
            return (_receivers, _transmitter.SignalTimes);
        }

        /// <summary>
        /// Определяет пересечение трех окружностей 
        /// </summary>
        /// <param name="r0">Радиус первой окружности</param>
        /// <param name="r1">Радиус второй окружности</param>
        /// <param name="r2">Радиус третьей окружности</param>
        /// <returns></returns>
        private bool HasThreeCircleIntersection(double r0, double r1, double r2)
        {
            double a, dx, dy, d, h, rx, ry;
            Point point2;
            Point intersectionPoint1, intersectionPoint2;

            //dx и dy - вертикальные и горизонтальные расстояния между центрами А и Б
            dx = _receivers.B.location.X - _receivers.A.location.X;
            dy = _receivers.B.location.Y - _receivers.A.location.Y;

            // растояние между центрами А и Б
            d = Math.Sqrt(dy * dy + dx * dx);

            if (d > (r0 + r1))
            {
                // не пересекаются
                return false;
            }
            if (d < Math.Abs(r0 - r1))
            {
                // один из окружностей полность находится в другом
                return false;
            }

            // point2 - точка пересечения d и линией соединяющей  точки пересечения окружностей

            // Растояние между центром A и p2
            a = ((r0 * r0) - (r1 * r1) + (d * d)) / (2.0 * d);

            point2.X = _receivers.A.location.X + (dx * a / d);
            point2.Y = _receivers.A.location.Y + (dy * a / d);

            //расстояние от точки 2 до любой из точек пересечения окружностей
            h = Math.Sqrt(r0 * r0 - a * a);

            // смещения от точки 2 до точек пересечения окружностей
            //rx = -dy * (h / d);
            rx = -dy * (h / d);
            ry = dx * (h / d);

            //Точки пересечения окружностей
            intersectionPoint1.X = point2.X + rx;
            intersectionPoint1.Y = point2.Y + ry;

            intersectionPoint2.X = point2.X - rx;
            intersectionPoint2.Y = point2.Y - ry;
            
            //пересекается ли круг 3 в любой из указанных выше точек пересечения
            dx = intersectionPoint1.X - _receivers.C.location.X;
            dy = intersectionPoint1.Y - _receivers.C.location.Y;
            double d1 = Math.Sqrt((dy * dy) + (dx * dx));

            dx = intersectionPoint2.X - _receivers.C.location.X;
            dy = intersectionPoint2.Y - _receivers.C.location.Y;
            double d2 = Math.Sqrt((dy * dy) + (dx * dx));

            if (Math.Abs(d1 - r2) < epsilon * r2)
            {
                _transmitter.Points.Add(new Point(Math.Round(intersectionPoint1.X, 8), Math.Round(intersectionPoint1.Y, 8)));
            }
            else if (Math.Abs(d2 - r2) < epsilon * r2)
            {
                _transmitter.Points.Add(new Point(Math.Round(intersectionPoint2.X, 8), Math.Round(intersectionPoint2.Y, 8)));
            }
            else
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Расчитывает растояние сигнала в метрах по заданному времени
        /// </summary>
        /// <param name="time">время прохождения сигнала</param>
        /// <returns></returns>
        private static double TimeToDistance(double time)
        {
            return time * velocity * metersPerKilometer;
        }

    }
}
