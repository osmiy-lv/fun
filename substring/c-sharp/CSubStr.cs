using System;
using System.ComponentModel;

namespace substring
{
    class CSubStr : INotifyPropertyChanged
    {
        String value = "";

        public int MaxLen
        {
            get
            {
                int max_len = 0;
                int start_pos = 0;
                int substr_len = 0;
                int i = 0;

                for (i = 0; i < this.value.Length; i++)
                {
                    int c_at_left = this.value.Substring(start_pos, i - start_pos).IndexOf(this.value[i]);

                    if (c_at_left < 0)
                        continue;

                    substr_len = i - start_pos;
                    max_len = (substr_len > max_len) ? substr_len : max_len;
                    start_pos += c_at_left + 1;
                }

                substr_len = i - start_pos;
                max_len = (substr_len > max_len) ? substr_len : max_len;

                return max_len;
            }
        }

        public String Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
                OnPropertyChanged("Value");
                OnPropertyChanged("MaxLen");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
