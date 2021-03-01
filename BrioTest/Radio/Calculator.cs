﻿using System;
using System.Collections.Generic;
using System.Linq;
using BrioTest.Radio.Structs;

namespace BrioTest.Radio
{
    internal class Calculator
    {
        private Receivers _receivers;
        private Transmitter _transmitter = new Transmitter();
        private double epsilon = 0.1;

        public void Callulate(Receivers receivers, List<SignalTime> signalsTime)
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

            foreach (var Point in _transmitter.Points)
            {
                Console.WriteLine(Point.X + "    " + Point.Y);
            }
        }

        public void AddTransmitterPoint(Point point)
        {

        }

        public List<Point> GetTransmitterPoints()
        {
            return _transmitter.Points;
        }

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

            //Log.d("INTERSECTION Circle1 AND Circle2:", "(" + intersectionPoint1_x + "," + intersectionPoint1_y + ")" + " AND (" + intersectionPoint2_x + "," + intersectionPoint2_y + ")");

            //пересекается ли круг 3 в любой из указанных выше точек пересечения
            dx = intersectionPoint1.X - _receivers.C.location.X;
            dy = intersectionPoint1.Y - _receivers.C.location.Y;
            double d1 = Math.Sqrt((dy * dy) + (dx * dx));

            dx = intersectionPoint2.X - _receivers.C.location.X;
            dy = intersectionPoint2.Y - _receivers.C.location.Y;
            double d2 = Math.Sqrt((dy * dy) + (dx * dx));

            if (Math.Abs(d1 - r2) < epsilon * r2)
            {
                _transmitter.Points.Add(new Point(intersectionPoint1.X, intersectionPoint1.Y));
            }
            else if (Math.Abs(d2 - r2) < epsilon * r2)
            {
                _transmitter.Points.Add(new Point(intersectionPoint2.X, intersectionPoint2.Y));
            }
            else
            {
                return false;
                //throw new Exception("пересечение не найдено");
            }
            return true;
        }

        /// <summary>
        /// Получаем проиденное растояние сигнала в метрах
        /// </summary>
        /// <param name="time">время прохождения сигнала</param>
        /// <returns></returns>
        private static double TimeToDistance(double time)
        {
            return time * 1000.0 * 1000.0 * (1.0);
        }

    }
}