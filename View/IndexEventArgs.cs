using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    public class IndexEventArgs : EventArgs
    {
        public Int32 Index { get; set; }

        public Form1 Form1
        {
            get => default;
            set
            {
            }
        }

        public IndexEventArgs(int index)
        {
            Index = index;
        }
    }
}
