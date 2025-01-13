using Avalonia.Controls;
using Avalonia.Media;
using Avalonia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mnogougolniki
{
    public class CustomControl : UserControl
    {
        private List<Shape> shapes = [
            new Circle(700, 700),
            new Square(100, 100)
        ];
        
        int prex, prey;

        public void Delete(double X, double Y)
        {
            int i = shapes.Count() - 1;
            while (i >= 0)
            {
                if (shapes[i].IsInside((int)X, (int)Y))
                {
                    shapes.Remove(shapes[i]);
                    break;
                }

                i--;
            }
            InvalidateVisual();
        }
        
        public void Click(double X, double Y)
        {
            Console.WriteLine("click");
            bool in_shape = false;
            foreach (var shape in shapes)
            {
                if (shape.IsInside((int)X, (int)Y))
                {
                    in_shape = true;
                    prex = (int)X;
                    prey = (int)Y;
                    shape.Move = true;
                }
            }

            if (!in_shape)
            {
                shapes.Add(new Triangle((int)X, (int)Y));
            }
            InvalidateVisual();
        }

        public void Move(double X, double Y)
        {
            Console.WriteLine("move");
            foreach (var shape in shapes)
            {
                if (shape.Move)
                {
                    shape.X += (int)X - prex;
                    shape.Y += (int)Y - prey;
                }
                
            }
            prex = (int)X;
            prey = (int)Y;
            InvalidateVisual();
        }
        
        public void Realise(double X, double Y)
        {
            Console.WriteLine("realise");
            foreach (var shape in shapes)
            {
                if (shape.Move)
                {
                    shape.X += (int)X - prex;
                    shape.Y += (int)Y - prey;
                    shape.Move = false;
                }
            }
            prex = (int)X;
            prey = (int)Y;
            InvalidateVisual();
        }
        
        
        public override void Render(DrawingContext drawingContext)
        {
            foreach (var s in  shapes)
            {
                s.Draw(drawingContext);
            }
        }
    }
}
