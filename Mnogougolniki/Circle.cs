﻿using Avalonia.Media;
using Avalonia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Mnogougolniki
{
    sealed class Circle : Shape
    {
        public Circle(int x, int y) : base(x, y) { }
        
        public override bool IsInside(int X, int Y)
        {
            return (x - X) * (x - X) + (y - Y) * (y - Y) <= r * r;
        }

        public override void Draw(DrawingContext dc)
        {
            Brush brush = new SolidColorBrush(Colors.White);

            Brush brush2 = new SolidColorBrush(color);

            Pen pen = new(brush2, 1, lineCap: PenLineCap.Square);

            dc.DrawEllipse(brush, pen, new Point(x, y), r, r);
        }
    }
}
