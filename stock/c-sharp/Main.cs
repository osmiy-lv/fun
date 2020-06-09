using System;
using System.Drawing;
using System.Windows.Forms;

namespace stock
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private CStock stk;
        private Binding stk_binding_prices;
        private Binding stk_binding_profit;

        private void Main_Load(object sender, EventArgs e)
        {
            this.stk = new CStock();

            this.stk_binding_prices = new Binding("Text", this.stk, "Prices", true, DataSourceUpdateMode.OnPropertyChanged);
            this.stk_binding_prices.BindingComplete += new BindingCompleteEventHandler(this.OnSTK_BindingComplete);
            this.txtInput.DataBindings.Add(stk_binding_prices);

            this.stk_binding_profit = new Binding("Text", this.stk, "Profit", false, DataSourceUpdateMode.OnPropertyChanged);
            this.txtOutput.DataBindings.Add(stk_binding_profit);

            this.stk.Prices = "7,1,5,3,6,4";  // set an initial value and trigger all the handlers
        }

        private void OnSTK_BindingComplete(object sender, BindingCompleteEventArgs args)
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
