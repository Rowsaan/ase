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
using System.IO;

namespace ASE_Component_I
{
    /// <summary>
    /// Form1 contains all the components like buttons
    /// panel text field and all
    /// </summary>
    public partial class Form1 : Form
    {

        public int positionXaxis = 0;
        public int positionYaxis = 0;
        string[] shapes = {"drawto", "moveto", "rectangle", "circle","triangle"};
        public bool draw = false;
        public bool load = false;
        public bool save = true;
        public bool execute = false;
        public bool clear_bool = false;
        public bool reset_bool = false;
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// this methods takes two parameters x and y which when given values
        /// acts as another origin which is taken refrence for any drawing of
        /// shapes formerly the values of x and y are (0,0) 
        /// </summary>
        /// <param name="x">x co ordinate of origin</param>
        /// <param name="y">y co ordinate of origin</param>
        public void pentomove(int x, int y)
        {
            Pen pen_move = new Pen(Color.Black, 2);
            positionXaxis = x;
            positionYaxis = y;




        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// method to draw a line from (positionXaxis,positionYaxis) to 
        /// given points (a,b)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public void pentodraw(int a, int b)
        {
            Pen mew = new Pen(Color.Black, 2);
            Graphics g = panel1.CreateGraphics();
            g.DrawLine(mew, positionXaxis, positionYaxis, a, b);
            positionXaxis = a;
            positionYaxis = b;
        }
        /// <summary>
        /// takes every line of the command and checks for the shape names 
        /// if it is in array shapes.
        /// </summary>
        /// <param name="line">line of command stored after each loop </param>
        /// <returns></returns>
        public bool checkCommand(string line)
        {
            for (int a = 0; a < shapes.Length; a++)
            {
                if (line.Contains(shapes[a]))
                {
                   

                    return true;
                }
            }
            return false;
        }

        /// <summary>
        ///methods which becomes active as soon as Execute button is pressed. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void button2_Click(object sender, EventArgs e)
        {
            execute = false;
            var multi_command = textBox2.Text;
            string[] multi_syntax = multi_command.Split('\n');
            for(int i=0; i<multi_syntax.Length-1; i++)
            {
                String pte = multi_syntax[i].Trim();
                string[] m_syntax = pte.Split('(');
                
                bool check = checkCommand(multi_syntax[i].ToLower());
//check the line which contains error
                if (!check)
                {

                    textBox1.Text = "Line: " + (i+1)+" Command Doesnot Exist";
                    panel1.Refresh();
                    break;
                   
                }


                try
                {
//executes if "moveto" command is triggered
                    if (string.Compare(m_syntax[0].ToLower(), "moveto") == 0)
                    {
                        String[] parameter1 = m_syntax[1].Split(',');
                        if (parameter1.Length != 2)
                            throw new Exception("MoveTo Takes Only 2 Parameters");
                        else if (!parameter1[parameter1.Length - 1].Contains(')'))
                            throw new Exception(" " + "Missing Paranthesis!!");
                        else
                        {
                            String[] parameter2 = parameter1[1].Split(')');
                            String p1 = parameter1[0];
                            String p2 = parameter2[0];
                            pentomove(int.Parse(p1), int.Parse(p2));
                            if (parameter1.Length > 1 && parameter1.Length < 3)
                                pentomove(int.Parse(p1), int.Parse(p2));
                            else
                                throw new ArgumentException("MoveTo takes Only 2 Parameters");

                        }
                    }
                    else if (m_syntax[0].Equals("\n"))
                    {

                    }
//executes if "drawto" command is triggered
                    else if (string.Compare(m_syntax[0].ToLower(), "drawto") == 0)
                    {

                        String[] parameter1 = m_syntax[1].Split(',');
                        if(parameter1.Length != 2)
                            throw new Exception("DrawTo Takes Only 2 Parameters");
                        else if (!parameter1[parameter1.Length-1].Contains(')'))
                            throw new Exception(" " + "Missing Paranthesis!!");
                        else
                        {
                            String[] parameter2 = parameter1[1].Split(')');
                            String p1 = parameter1[0];
                            String p2 = parameter2[0];
                            pentodraw(int.Parse(p1), int.Parse(p2));
                            if (parameter1.Length == 2)
                                pentodraw(int.Parse(p1), int.Parse(p2));
                            
                            else
                            {
                                throw new ArgumentException("DrawTo Takes Only 2 Parameters");
                            }
                        }

                    }
 //executes if "clear()" command is triggered
                    else if (string.Compare(m_syntax[0].ToLower(), "clear") == 0)
                    {
                        clear();
                    }
//executes if "reset()" command is triggered
                    else if (string.Compare(m_syntax[0].ToLower(), "reset") == 0)
                    {
                        reset();
                    }
 //executes if "rectangle" command is triggered
                    else if (string.Compare(m_syntax[0].ToLower(), "rectangle") == 0)
                    {
                        String[] parameter1 = m_syntax[1].Split(',');
                        if (parameter1.Length != 2)
                            throw new Exception("Rectangle Takes Only 2 Parameters");
                        else if (!parameter1[parameter1.Length - 1].Contains(')'))
                            throw new Exception(" " + "Missing Paranthesis!!");
                        else
                        {
                            String[] parameter2 = parameter1[1].Split(')');
                            String p1 = parameter1[0];
                            String p2 = parameter2[0];
                            if (parameter1.Length > 1 && parameter1.Length < 3)
                                rectangle_draw(positionXaxis, positionYaxis, int.Parse(p1), int.Parse(p2));
                            else
                                throw new ArgumentException("Rectangle Takes Only 2 Parameters");
                        }
                    }
//executes if "circle" command is triggered
                    else if (string.Compare(m_syntax[0].ToLower(), "circle") == 0)
                    {
                        String test = m_syntax[1];
                        String[] parameter2 = m_syntax[1].Split(')');
                       if (!test.Contains(')'))
                            throw new Exception(" " + "Missing Paranthesis!!");
                        else
                        {
                            String p2 = parameter2[0];
                            if (p2 != null || p2 != "" || p2 != " ")
                                circle_draw(positionXaxis, positionYaxis, int.Parse(p2));
                            else
                                throw new ArgumentException("Circle Takes Only 1 Parameter");

                        }
                    }
//executes if "triangle" command is triggered
                    else if (string.Compare(m_syntax[0].ToLower(), "triangle") == 0)
                    {
                        String[] parameter1 = m_syntax[1].Split(',');
                        if (parameter1.Length != 2)
                            throw new Exception("Triangle Takes Only 2 Parameters");
                        else if (!parameter1[parameter1.Length - 1].Contains(')'))
                            throw new Exception(" " + "Missing Paranthesis!!");
                        else
                        {
                        String[] parameter2 = parameter1[1].Split(')');
                        String p1 = parameter1[0];
                        String p2 = parameter2[0];
                            if (parameter1.Length > 1 && parameter1.Length < 3)
                                triangle_draw(positionXaxis, positionYaxis, int.Parse(p1), int.Parse(p2));
                            else
                                throw new ArgumentException("Triangle Takes Only 2 Parameters");
                        }
                    }
                }
                catch (ArgumentException ecp) {
                    textBox1.Text ="Error in Line:" + (i+1)+" " + ecp.Message;
                    panel1.Refresh();
                }
                
                catch (Exception ee)  
                {
                    textBox1.Text = "Error in Line:" + (i+1)+ " " + "parameter Error!!"+ee.Message;
                    panel1.Refresh();
                    break;
                }


            }

            textBox1.Refresh();
            execute = true;

        }
        /// <summary>
        /// this method is trigerred when clear button is clicked.
        /// this clears text box as well as panel where drawing is 
        /// drawn
        /// </summary>
        public void clear()
        {
            clear_bool = false;
            panel1.Refresh();
            textBox2.Clear();
            clear_bool = true;
        }
        /// <summary>
        /// this button reset the point of reference or origin to (0,0)
        /// </summary>
        public void reset()
        {
            reset_bool = false;
            positionXaxis = 0;
            positionYaxis = 0;
            reset_bool = true;
        }
        /// <summary>
        /// the a and b is assigned as point of origin which is given (0,0)
        /// at first which can replaced using moveto command. the c and d is 
        /// given for the width and height of the rectangle. this method is to draw 
        /// rectangle.
        /// </summary>
        /// <param name="a">x co ordinate of origin</param>
        /// <param name="b">y co ordinate of origin</param>
        /// <param name="c">width of the rectangle</param>
        /// <param name="d">height of the rectangle</param>
        public void rectangle_draw(int a, int b,int c, int d )
        {
            draw = false;
            Rectangle mewmew = new Rectangle();
            mewmew.saved_values(a, b, c, d);
            Graphics g = panel1.CreateGraphics();
            mewmew.Draw_shape(g);
            draw = true;
        }
        /// <summary>
        /// the a and b is assigned as point of origin which is given (0,0)
        /// at first which can replaced using moveto command. the c is given to
        /// radius of circle.this is to draw circle
        /// </summary>
        /// <param name="a">x co ordinate of origin</param>
        /// <param name="b">y co ordinate of origin</param>
        /// <param name="c">radius of circle</param>
        public void circle_draw(int a, int b, int c)
        {
            draw = false;
            Circle mewmew2 = new Circle();
            mewmew2.saved_values(a, b, c);
            Graphics g = panel1.CreateGraphics();
            mewmew2.Draw_shape(g);
            draw = true;
        }
        
        public void triangle_draw(int a, int b, int c, int d)
        {
            draw = false;
            Triangle mewmew4 = new Triangle();
            mewmew4.saved_values(a, b, c, d);
            Graphics g = panel1.CreateGraphics();
            mewmew4.Draw_shape(g);
            draw = true;
        }

        /// <summary>
        /// triggered when reset button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void button1_Click(object sender, EventArgs e)
        {
            reset();
        }
        /// <summary>
        /// triggered when clear button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            clear();
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        /// <summary>
        /// method to load a file which is created and saved before.
        /// </summary>
        /// <param name="sender">where event came from</param>
        /// <param name="e">what is in the event</param>
        public void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            load= false;
            OpenFileDialog loadFileDialog = new OpenFileDialog();
            loadFileDialog.Filter = "Text File (.txt)|*.txt";       
            loadFileDialog.Title = "Open File...";

            if (loadFileDialog.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader streamReader = new System.IO.StreamReader(loadFileDialog.FileName);
                textBox2.Text = streamReader.ReadToEnd();
                streamReader.Close();
            }
            load = true;
        }
        /// <summary>
        /// to save the file written in coding text box to the given drive with
        /// the given name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save = true;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text File (.txt)| *.txt";
            saveFileDialog.Title = "Save File...";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter fWriter = new StreamWriter(saveFileDialog.FileName);
                fWriter.Write(textBox2.Text);
                fWriter.Close();
                

            }
            save = true;

        }
        /// <summary>
        /// trigerrred when exit button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// trigerrred when about button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Created by Roshan Giri,Component I,ASE\n© Copyright 2019. All Rights Reserved.","About");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
    