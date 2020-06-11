using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Phone
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private CPhone2Str p2s;
        private Binding p2s_binding;

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.p2s = new CPhone2Str();
            this.p2s.PropertyChanged += new PropertyChangedEventHandler(this.OnP2S_Change);

            this.p2s_binding = new Binding("Text", this.p2s, "Phone", true, DataSourceUpdateMode.OnPropertyChanged);
            this.p2s_binding.BindingComplete += new BindingCompleteEventHandler(this.OnP2S_BindingComplete);

            this.txtPhone.DataBindings.Add(p2s_binding);

            this.p2s.Phone = "23";  // set an initial value and trigger all the handlers
        }

        private void OnP2S_BindingComplete(object sender, BindingCompleteEventArgs args)
        {
            switch (args.BindingCompleteState)
            {
                case BindingCompleteState.Success:
                    this.txtPhone.ForeColor = Color.Black;
                    this.lblPhoneMsg.ForeColor = Color.Black;
                    this.lblPhoneMsg.Text = "";
                    break;
                default:
                    this.txtPhone.ForeColor = Color.Red;
                    this.lblPhoneMsg.ForeColor = Color.Red;
                    this.lblPhoneMsg.Text = "Error: " + args.ErrorText;
                    break;
            }
        }

        private void OnP2S_Change(object sender, EventArgs e)
        {
            this.lstOutput.Items.Clear();

            String[] s_list = this.p2s.Translate();
            this.lstOutput.Items.AddRange(s_list);
            this.lblOutputMsg.Text = String.Format("({0})", s_list.Count());
        }
    }
}
