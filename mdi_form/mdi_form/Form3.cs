using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;


namespace mdi_form
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen mypen = new Pen(Color.Black, 2);
            g.DrawLine(mypen, 0, 0, 100, 100);
        }

       

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Point pt1 = new Point(0, 0);
            Point pt2 = new Point(200, 200);
            Rectangle rect1 = new Rectangle(50, 80, 100, 130);
            Graphics g = e.Graphics;
            Pen myBlackpen = new Pen(Color.Black, 5);

            g.DrawLine(myBlackpen, pt1, pt2);
            g.DrawLine(myBlackpen, 0, 50, 200, 50);

            g.DrawEllipse(myBlackpen, 50, 50, 200, 100);

            g.DrawRectangle(myBlackpen, rect1);
            myBlackpen.Dispose();
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //Draw Bezier curve
            g.DrawBezier(new Pen(Color. BlueViolet, 5), new Point (50,60), new Point(150,10), new Point(200,230), new Point(100,100));

            //polygon points
            PointF point1 = new PointF(50.0f, 250.0f);
            PointF point2 = new PointF(100.0f, 25.0f);
            PointF point3 = new PointF(150.0f, 5.0f);
            PointF point4 = new PointF(250.0f, 50.0f);
            PointF point5 = new PointF(300.0f, 100.0f);
            PointF[] polygonPoints = { point1, point2, point3, point4, point5 };
            //Draw Polygon
            g.DrawPolygon(new Pen(Color.Chocolate, 10), polygonPoints);
        }

        private void pictureBox3_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect1 = new Rectangle(10, 10, 50, 50);
            Rectangle rect2 = new Rectangle(60, 60, 80, 100);

            SolidBrush Brush1 = new SolidBrush(Color.Aquamarine);
            g.FillRectangle(Brush1, rect1);

            LinearGradientBrush Brush2 = new LinearGradientBrush(rect2, Color.Tan, Color.SandyBrown, LinearGradientMode.BackwardDiagonal);
            g.FillRectangle(Brush2, rect2);


        }

        private void pictureBox4_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
