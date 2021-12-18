using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgorithmVisualization
{
    public class BinarySearchTree
    {
        Node root;
        public BinarySearchTree()
        {
            this.root = null;
        }

        public Node GetRoot()
        {
            return this.root;
        }

        public void Insert(int key, Label name)
        {
            
            root = InsertKey(root, key, name,0);
        }

        private Node InsertKey(Node root, int key, Label name, int depth)
        {
            // Return a new node if the tree is empty
            if (root is null)
            {
                root = new Node(key, depth, name);
                return root;
            }
            // Traverse to the right place and insert the node
            if (key < root.key)
                root.left = InsertKey(root.left, key, name, ++depth);
            else if (key > root.key)
                root.right = InsertKey(root.right, key, name, ++depth);
            return root;
        }

        public Node FindParentRec(Node root, int key)
        {
            // Return if the tree is empty
            if (root == null)
                return root;
            // Find the child (⓿_⓿)
            if (key < root.key)
            {
                if (root.left.key == key) 
                    return root;
                root= FindParentRec(root.left, key);
            }
            else if (key > root.key)
            {
                if (root.right.key == key) 
                    return root;
                root= FindParentRec(root.right, key);
            }
            return root;
        }

        public Node DeleteRec(Node root, int key)
        {
            // Return if the tree is empty
            if (root == null)
                return root;

            // Find the node to be deleted
            if (key < root.key)
                root.left = DeleteRec(root.left, key);
            else if (key > root.key)
                root.right = DeleteRec(root.right, key);
            else
            {
                // If the node is with only one child or no child
                if (root.left == null)
                    return root.right;
                else if (root.right == null)
                    return root.left;

                // If the node has two children
                // Place the inorder successor in position of the node to be deleted
                root.key = MinValue(root.right);

                // Delete the inorder successor
                root.right = DeleteRec(root.right, root.key);
            }

            return root;
        }

        private int MinValue(Node root)
        {
            int minv = root.key;
            while (root.left != null)
            {
                minv = root.left.key;
                root = root.left;
            }
            return minv;
        }
    }
}
