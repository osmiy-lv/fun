using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tree
{
    public class CTree<T>
    {
        public readonly T Value;

        private CTree<T> left = null;
        private CTree<T> right = null;

        public CTree(T value)
        {
            this.Value = value;
        }

        public CTree<T> Left
        {
            get { return this.left; }
            set { this.left = value; }
        }

        public CTree<T> Right
        {
            get { return this.right; }
            set { this.right = value; }
        }

        public TreeNode[] ToTreeNodes(String note=" (root)")
        {
            List<TreeNode> children = new List<TreeNode>();

            if (null != this.Left)
            {
                children.AddRange(this.Left.ToTreeNodes(" (L)"));
            }

            if (null != this.Right)
            {
                children.AddRange(this.Right.ToTreeNodes(" (R)"));
            }

            return new TreeNode[] { new TreeNode(String.Format("{0}{1}", this.Value, note), children.ToArray()) };
        }
    }
}
