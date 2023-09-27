using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editor
{
    public partial class corner : UserControl
    {
        public corner()
        {
            InitializeComponent();
        }
        public Form1 f;

        public int aXpos = 0;
        public int aYpos = 0;

        public bool isMouseDown = false;

        public bool isMouseMoving = false;

        public List<int> listXY = new List<int>();
        public List<int> returnListaXY()
        {
            return this.listXY;
        }

        public void setXYos(int a, int b)
        {
            this.aXpos = a;
            this.aYpos = b;
        }

        private void corner_Load(object sender, EventArgs e)
        {
            try
            {
                f = (Form1)Parent;
            }
            catch { }
        }

        private void corner_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
        }

        private void corner_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown == true)
            {
                this.Left += e.X;
                this.Top += e.Y;
                this.aXpos = this.Left;
                this.aYpos = this.Top;
            
            f.setPointsX(this.aXpos);
            f.setPointsY(this.aYpos);
            f.resizeTheWindowUp();
         }
        }
        private void corner_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
           
        }
    }
}
