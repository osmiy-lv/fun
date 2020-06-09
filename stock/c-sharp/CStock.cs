using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace stock
{
    class CStock : INotifyPropertyChanged
    {
        private List<int> prices = new List<int>();

        public int Profit
        {
            get
            {
                int max_profit = 0;
                int profit = 0;

                List<int> d = prices.Zip(prices.Skip(1), (a, b) => b - a).ToList<int>();

                for (int i = 0; i < d.Count; i++)
                {
                    profit += d[i];

                    if (profit < 0)
                    {
                        profit = 0;
                    }

                    if (profit > max_profit)
                    {
                        max_profit = profit;
                    }
                }

                return max_profit;
            }
        }

        public String Prices
        {
            get
            {
                return String.Join(", ", this.prices);
            }
            set
            {
                this.prices = value?.Split(',').Select(Int32.Parse).ToList<int>();
                OnPropertyChanged("Prices");
                OnPropertyChanged("Profit");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
