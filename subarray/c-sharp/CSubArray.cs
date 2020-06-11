using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace subarray
{
    class CSubArray : INotifyPropertyChanged
    {
        List<int> values = new List<int>();

        public int MaxSum
        {
            get
            {
                try
                {
                    int max_sum = this.values.First();
                    int curr_sum = 0;

                    this.values.ForEach(delegate (int n)
                    {
                        curr_sum = (n > (n + curr_sum)) ? n : n + curr_sum;
                        max_sum = (curr_sum > max_sum) ? curr_sum : max_sum;
                    });

                    return max_sum;
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }

        public String Numbers
        {
            get
            {
                return String.Join(", ", this.values);
            }
            set
            {
                this.values.Clear();
                this.values.AddRange(value?.Split(',').Select(Int32.Parse).ToList<int>());
                OnPropertyChanged("MaxSum");
                OnPropertyChanged("Numbers");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
