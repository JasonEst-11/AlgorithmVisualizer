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
    public partial class FormTree : Form
    {
        private BinarySearchTree binarySearchTree = new BinarySearchTree();
        public int popUpInt;
        private Node parentNode;

        public FormTree()
        {
            InitializeComponent();
        }

        private void addNewNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var popUpForm = new Forms.InputVal(this);
            popUpForm.ShowDialog();

            //previous node location
            if (binarySearchTree.GetRoot() is null)
            {
                Label parent = new Label();
                binarySearchTree.Insert(popUpInt, parent);
                parentNode = binarySearchTree.GetRoot();

                //creating first label dynamically inside the panel

                parent.Text = binarySearchTree.GetRoot().key.ToString();
                parent.Location = new Point((panel1.Width - parent.Width) / 2, panel1.Location.Y + 100);
                NodeCreator(parent);
                return;
            }

            //creating new labels dynamically inside the panel
            Label subTreeNode = new Label();
            binarySearchTree.Insert(popUpInt, subTreeNode);
            var previousNode = binarySearchTree.FindParentRec(parentNode,popUpInt);
            if (previousNode.left != null && previousNode.left.key.Equals(popUpInt))
            {
                //Idk if this will cause problems the more nodes we add. Oh well.
                subTreeNode.Location = new Point(previousNode.label.Location.X - (200/ previousNode.left.depth), previousNode.label.Location.Y + 100);
                subTreeNode.Text = previousNode.left.key.ToString();
                NodeCreator(subTreeNode);
            }
            else if (previousNode.right != null && previousNode.right.key.Equals(popUpInt))
            {
                //Same issue as above
                subTreeNode.Location = new Point(previousNode.label.Location.X + (200 / previousNode.right.depth), previousNode.label.Location.Y + 100);
                subTreeNode.Text = previousNode.right.key.ToString();
                NodeCreator(subTreeNode);
            }

        }
        //TO BE ADDED
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void NodeCreator(Label nodeLabel)
        {

            nodeLabel.Font = new Font("Microsoft Sans Serif", 16);
            nodeLabel.ContextMenuStrip = contextMenuStrip2;
            nodeLabel.AutoSize = true;
            nodeLabel.Anchor = AnchorStyles.None;
            nodeLabel.BorderStyle = BorderStyle.FixedSingle;
            nodeLabel.Visible = true;
            nodeLabel.Parent = panel1;
 
        }

        private void addNewNodeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            addNewNodeToolStripMenuItem_Click(sender, e);
        }


    }
}
