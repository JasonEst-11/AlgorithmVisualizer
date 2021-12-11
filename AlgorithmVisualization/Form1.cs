using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgorithmVisualization
{
    public partial class Form1 : Form
    {
        private Form activeform;
        public Form1()
        {
            InitializeComponent();
        }

       private void Openchildform(Form childform)
        {
            if (activeform != null)
            {
                activeform.Close();
            }
            activeform = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;
            this.containerpanel.Controls.Add(childform);
            this.containerpanel.Tag = childform;
            childform.BringToFront();
            childform.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Openchildform(new Forms.FormTree());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Openchildform(new Forms.FormGraph());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Openchildform(new Forms.FormLinkedList());
        }
    }


}
