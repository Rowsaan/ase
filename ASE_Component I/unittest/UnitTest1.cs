using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASE_Component_I;
using System.Windows.Forms;
namespace unittest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Move()
        {
            var form = new Form1();
            var x = form.positionXaxis;
            var y = form.positionYaxis;
            form.pentomove(10,20);
            bool eql = false;
            if (x != form.positionXaxis && y != form.positionYaxis)
                eql = true;
            Assert.IsTrue(eql);
        }

      [TestMethod]
      public void Draw()
        {
            var form = new Form1();
            var x = form.positionXaxis;
            var y = form.positionYaxis;
            form.pentodraw(10, 20);
            bool eql = false;
            if (x != form.positionXaxis && y != form.positionYaxis)
                eql = true;
            Assert.IsTrue(eql);
        }
        


        [TestMethod]
        public void Rectangle()
        {
            var form = new Form1();
            form.rectangle_draw(1, 2, 3, 4);
            Assert.IsTrue(form.draw);
        }

        [TestMethod]
        public void Circle()
        {
            var form = new Form1();
            form.circle_draw(0,0,4);
            Assert.IsTrue(form.draw);
        }

        [TestMethod]
        public void Triangle()
        {
            var form = new Form1();
            form.triangle_draw(0,0,23,34);
            Assert.IsTrue(form.draw);
        }
        [TestMethod]
        public void Execute()
        {
            var form = new Form1();
            object a = new object();
            EventArgs b = new EventArgs();
            form.button2_Click(a, b);
            Assert.IsTrue(form.execute);

        }

        [TestMethod]
        public void Reset()
        {
            var form = new Form1();
            form.reset();
            Assert.IsTrue(form.reset_bool);

        }

        [TestMethod]
        public void Clear()
        {
            var form = new Form1();
            form.clear();
            Assert.IsTrue(form.clear_bool);

        }

        [TestMethod]
        public void Load() 
        {
            var form = new Form1();
            object a = new object();
            EventArgs b = new EventArgs();
            form.loadToolStripMenuItem_Click(a, b);
            Assert.IsTrue(form.load);
        }

        [TestMethod]
        public void Save()
        {
            var form = new Form1();
            object a = new object();
            EventArgs b = new EventArgs();
            form.loadToolStripMenuItem_Click(a, b);
            Assert.IsTrue(form.load);
        }


    }
}
