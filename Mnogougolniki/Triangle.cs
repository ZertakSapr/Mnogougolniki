using Avalonia;
using Avalonia.Media;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Mnogougolniki
{
    sealed class Triangle : Shape
    {
        public Triangle(int x, int y) : base(x, y) { }

        private double r2 = r * (double)Math.Sqrt(3) / 2;

        private double r3 = (double)r / 2;

        public override bool IsInside(int X, int Y)
        {
            Point point = new Point(X, Y);

            Point p1 = new Point(x, y - r);

            Point p2 = new Point(x - r2, y + r3);

            Point p3 = new Point(x + r2, y + r3);

            double S = Shape.r * Shape.r * Math.Sqrt(3) * 3 * 0.25;

            return Math.Abs(S - Heron(p1, p2, point) - Heron(p1, p3, point) - Heron(p2, p3, point)) <= 0.01;
        }

        public override void Draw(DrawingContext dc)
        {
            Brush brush = new SolidColorBrush(color);

            Pen pen = new(brush, 1, lineCap: PenLineCap.Square);

            Point p1 = new Point(x, y - r);

            Point p2 = new Point(x - r2, y + r3);

            Point p3 = new Point(x + r2, y + r3);


            dc.DrawLine(pen, p1, p2);

            dc.DrawLine(pen, p2, p3);

            dc.DrawLine(pen, p1, p3);
        }

        private static double Heron(Point p1, Point p2, Point p3)
        {
            double a = Point.Distance(p1, p2);

            double b = Point.Distance(p1, p3);

            double c = Point.Distance(p2, p3);

            double SP = (a + b + c) / 2;

            return Math.Sqrt(SP * (SP - a) * (SP - b) * (SP - c));
        }
    }
}