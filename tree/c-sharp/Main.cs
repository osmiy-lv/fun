using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tree
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.trvInputTree.Nodes.AddRange(CGlobals.inputTree.ToTreeNodes());
            this.trvInputTree.ExpandAll();
        }

        private void btnHandle_Click(object sender, EventArgs e)
        {
            this.txtOutRecursive.Text = String.Join(
                ", ", 
                CGlobals.RecursiveInorderDump(CGlobals.inputTree)
                );

            this.txtOutIterative.Text = String.Join(
                ", ",
                CGlobals.IterativeInorderDump(CGlobals.inputTree)
                );
        }
    }
}
