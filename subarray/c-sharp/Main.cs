using System;
using System.Drawing;
using System.Windows.Forms;

namespace subarray
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private CSubArray sba;
        private Binding sba_binding_values;
        private Binding sba_binding_maxsum;


        private void Main_Load(object sender, EventArgs e)
        {
            this.sba = new CSubArray();

            this.sba_binding_values = new Binding("Text", this.sba, "Numbers", true, DataSourceUpdateMode.OnPropertyChanged);
            this.sba_binding_values.BindingComplete += new BindingCompleteEventHandler(this.OnSBA_BindingComplete);
            this.txtInput.DataBindings.Add(sba_binding_values);

            this.sba_binding_maxsum = new Binding("Text", this.sba, "MaxSum", false, DataSourceUpdateMode.OnPropertyChanged);
            this.txtOutput.DataBindings.Add(sba_binding_maxsum);

            this.sba.Numbers = "-2,1,-3,4,-1,2,1,-5,4";  // set an initial value and trigger all the handlers
        }

        private void OnSBA_BindingComplete(object sender, BindingCompleteEventArgs args)
        {
            switch (args.BindingCompleteState)
            {
                case BindingCompleteState.Success:
                    this.txtInput.ForeColor = Color.Black;
                    this.lblInputMsg.ForeColor = Color.Black;
                    this.lblInputMsg.Text = "";
                    break;
                default:
                    this.txtInput.ForeColor = Color.Red;
                    this.lblInputMsg.ForeColor = Color.Red;
                    this.lblInputMsg.Text = "Error: " + args.ErrorText;
                    break;
            }
        }
    }
}
