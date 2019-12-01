using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ASE_Component_I
{
    /// <summary>
    /// parent class for all the shapes and drawing
    /// </summary>
   abstract class Shape
    {
        /// <summary>
        /// method for overriding
        /// </summary>
        /// <param name="g">object for Graphics</param>
        public abstract void Draw_shape(Graphics g);
    }
}
