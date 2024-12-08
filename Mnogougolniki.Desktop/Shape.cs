using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Mnogougolniki.Desktop
{
    public abstract class Shape
    {
        protected int x, y;
        static int r;
        static Shape()
        {
            r = 25;
        }
        protected Shape(int xx, int yy)
        {
            x = xx;
            y = yy;
        }
        protected int GetX{
            get{ return x; }
            set { x = value; }

        }
        protected int GetY
        {
            get { return y; }
            set { y = value; }

        }
    }
}

