using Avalonia.Media;
using Avalonia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mnogougolniki
{
    abstract class Shape
    {
        static protected int r;

        protected int x, y;

        protected bool IsDragged, IsMoved;

        static protected Color color;
        public bool IsInShell{ get; set; } = true;

        protected Shape(int _x, int _y)
        {
            x = _x;
            y = _y;
            IsMoved = false;
        }

        static Shape()
        {
            color = Colors.Orange;
            r = 50;
        }

        public bool Move
        {
            get
            {
                return IsMoved;
            }
            set
            {
                IsMoved = value;
            }
        }

        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        public abstract void Draw(DrawingContext dc);

        public abstract bool IsInside(int X, int Y);
    }
}