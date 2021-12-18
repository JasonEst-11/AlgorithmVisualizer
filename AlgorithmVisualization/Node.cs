using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgorithmVisualization
{
    public class Node
    {
        public int key, depth;
        public Node left, right;
        public Label label;

        public Node(int val, int depth, Label name)
        {
            this.key = val;
            this.depth = depth;
            this.label = name;
            this.left = null;
            this.right = null;
            
        }
    }
}
