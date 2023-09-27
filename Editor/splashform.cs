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
    public partial class splashform : Form
    {
        public splashform()
        {
            InitializeComponent();
        }

        private void splashform_Load(object sender, EventArgs e)
        {


            this.Focus();


        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void splashform_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
