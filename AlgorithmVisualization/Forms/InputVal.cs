using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgorithmVisualization.Forms
{
    public partial class InputVal : Form
    {
        public static string input = null;
        private FormTree parentForm;

        public InputVal()
        {
            this.parentForm = null;
            InitializeComponent();
        }

        //Designating a Form as a parent so we know where to send the variable from the textBox1
        public InputVal(FormTree parentForm)
        {
            this.parentForm = parentForm;
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox objTextBox = (TextBox)sender;
            input = objTextBox.Text;
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            if (this.parentForm is null) return;
            try {
                parentForm.popUpInt = int.Parse(input);
                this.Close();
            }
            catch (FormatException){
                Console.WriteLine($"Unable to parse '{input}'");
            }

        }
    }
}
