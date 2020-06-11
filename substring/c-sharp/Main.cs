using System;
using System.Drawing;
using System.Windows.Forms;

namespace substring
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private CSubStr sbs;
        private Binding sbs_binding_value;
        private Binding sbs_binding_maxlen;


        private void Main_Load(object sender, EventArgs e)
        {
            this.sbs = new CSubStr();

            this.sbs_binding_value = new Binding("Text", this.sbs, "Value", true, DataSourceUpdateMode.OnPropertyChanged);
            this.sbs_binding_value.BindingComplete += new BindingCompleteEventHandler(this.OnSBS_BindingComplete);
            this.txtInput.DataBindings.Add(sbs_binding_value);

            this.sbs_binding_maxlen = new Binding("Text", this.sbs, "MaxLen", false, DataSourceUpdateMode.OnPropertyChanged);
            this.txtOutput.DataBindings.Add(sbs_binding_maxlen);

            this.sbs.Value = "abcabcbb";  // set an initial value and trigger all the handlers
        }

        private void OnSBS_BindingComplete(object sender, BindingCompleteEventArgs args)
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
