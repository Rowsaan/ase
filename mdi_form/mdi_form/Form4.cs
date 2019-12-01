using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mdi_form
{
    public partial class Form4 : Form
    {

        Bitmap myBitmap;
        Graphics g;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void Form4_Paint(object sender, PaintEventArgs e)
        {
          

            myBitmap = new Bitmap(640, 480);
            g = Graphics.FromImage(myBitmap);
            Pen p = new Pen(Color.Red, 2);
            g.DrawLine(p, 0, 0, 640, 480);
            
            Graphics WindowG = e.Graphics;
            WindowG.DrawImageUnscaled(myBitmap, 0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
        myBitmap.Save("d:\\LineImage.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
}
