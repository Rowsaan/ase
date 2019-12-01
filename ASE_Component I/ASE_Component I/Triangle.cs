using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Component_I
{
    class Triangle:Shape
    {
        
        private int x, y, bas, per;

        public void saved_values(int a, int b, int c, int d)
        {
            x = a;
            y = b;
            bas = c;
            per = d;
            

        }
        public override void Draw_shape(Graphics g)
        {
            Pen mew3 = new Pen(Color.Green, 3);
            PointF A = new PointF(x, y);
            PointF B = new PointF(x+per, y);
            PointF C = new PointF(B.X, B.Y+per) ;
            PointF[] bro= { A, B, C };
            g.DrawPolygon (mew3,bro);
        }


    }
}

