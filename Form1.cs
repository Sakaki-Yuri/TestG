using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTVN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 child = new Form2();
            child.MdiParent = this;
            child.Show();
            this.button1.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1 = new Button();
            button1.Text = "button1";
            button1.Location = new Point(12, 12);
            button1.Size = new Size(44, 29);
            this.Controls.Add(button1); 
        }
    }
}
