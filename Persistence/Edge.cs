using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class Edge<T>
    {
        public T? Data { get; set; }
        public List<Int32>? Neighbours { get; set; }

        public Edge(T Data)
        {
            this.Data = Data;
            this.Neighbours = new List<Int32>();
        }
        public Edge()
        {
            this.Data = default;
            this.Neighbours = new List<Int32>();
        }
    }
}
