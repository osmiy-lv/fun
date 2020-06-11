using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.ComponentModel;

namespace Phone
{
    class CPhone2Str : INotifyPropertyChanged
    {
        [Serializable]
        public class UnsupportedCharacterError : Exception
        {
            public UnsupportedCharacterError() :
                base("unsupported character")
            {
                // pass
            }

            public UnsupportedCharacterError(Char[] allowed) :
                base(String.Format("unsupported character, allowed [{0}]", new String(allowed)))
            {
                // pass
            }

            public UnsupportedCharacterError(Char c, Char[] allowed) :
                base(String.Format("{0} is out of allowed character set [{1}]", c, new String(allowed)))
            {
                // pass
            }
        }

        [Serializable]
        public class LengthOutOfRangeError : Exception
        {
            public LengthOutOfRangeError() :
                base("out of range")
            {
                // pass
            }

            public LengthOutOfRangeError(String val, int min_len, int max_len) :
                base(string.Format("len('{0}') = {1} is out of range [{2}, {3}]",
                    val, val.Length, min_len, max_len))
            {
                // pass
            }
        }

        private readonly Dictionary<Char, Char[]> num2char = new Dictionary<Char, Char[]>()
        {
            { '1', new Char[] { '1' } },
            { '2', new Char[] { 'a', 'b', 'c' } },
            { '3', new Char[] { 'd', 'e', 'f' } },
            { '4', new Char[] { 'g', 'h', 'i' } },
            { '5', new Char[] { 'j', 'k', 'l' } },
            { '6', new Char[] { 'm', 'n', 'o' } },
            { '7', new Char[] { 'p', 'q', 'r', 's' } },
            { '8', new Char[] { 't', 'u', 'v' } },
            { '9', new Char[] { 'w', 'x', 'y', 'z' } },
            { '0', new Char[] { ' ' } }
        };

        private String phone;
        private readonly int min_len;
        private readonly int max_len;

        public CPhone2Str(String phone="23", int min_len = 2, int max_len = 9)
        {
            this.min_len = min_len;
            this.max_len = max_len;
            this.Phone = phone;
        }

        public String[] Translate ()
        {
            List<String> result = new List<string>() { "" };

            foreach (Char c in this.Phone)
            {
                try
                {
                    List<String> new_result = new List<string>();
                    this.num2char[c]?.ToList().ForEach(n_c => result.ForEach(s => new_result.Add(s + n_c)));
                    result = new_result;
                }
                catch (KeyNotFoundException)
                {
                    throw new UnsupportedCharacterError(c, this.num2char.Keys.ToArray<Char>());
                }
            }

            return result.ToArray<String>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public String Phone
        {
            get { return this.phone; }
            set {
                if (null == value || value.Length < this.min_len || value.Length > this.max_len)
                {
                    throw new LengthOutOfRangeError(phone, this.min_len, this.max_len);
                }

                String txt_rgx = String.Format("^[{0}]*$", new String(this.num2char.Keys.ToArray<Char>()));

                var rgx_phone = new Regex(txt_rgx);
                if (! rgx_phone.IsMatch(value))
                {
                    throw new UnsupportedCharacterError(this.num2char.Keys.ToArray<Char>());
                }

                this.phone = value;

                OnPropertyChanged("Phone");
            }
        }
    }
}
