using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tree
{
    public static class CGlobals
    {
        public static CTree<int> GenerateIntegerTree()
        {
            CTree<int> root = new CTree<int>(10);

            root.Left = new CTree<int>(4);
            root.Right = new CTree<int>(6);
            root.Left.Left = new CTree<int>(1);
            root.Left.Right = new CTree<int>(3);
            root.Right.Left = new CTree<int>(5);
            root.Right.Right = new CTree<int>(0);

            return root;
        }

        public static CTree<int> inputTree = GenerateIntegerTree();

        public static int[] RecursiveInorderDump(CTree<int> tree)
        {
            List<int> result = new List<int>();

            if (null != tree.Left)
            {
                result.AddRange(RecursiveInorderDump(tree.Left));
            }

            result.AddRange(new int[] { tree.Value });

            if (null != tree.Right)
            {
                result.AddRange(RecursiveInorderDump(tree.Right));
            }

            return result.ToArray<int>();
        }

        public static int[] IterativeInorderDump(CTree<int> tree)
        {
            List<int> result = new List<int>();
            Stack<CTree<int>> leftNodes = new Stack<CTree<int>>();

            CTree<int> pos = tree;

            while (true)
            {
                if (null != pos)
                {
                    leftNodes.Push(pos);
                    pos = pos.Left;
                }
                else if (leftNodes.Count > 0)
                {
                    pos = leftNodes.Pop();
                    result.Add(pos.Value);
                    pos = pos.Right;
                }
                else
                {
                    break;
                }
            }

            return result.ToArray<int>();
        }
    }
}
