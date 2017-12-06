using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacketSwitchedDesign
{
    public class Router
    {
        public string Type { get; set; }
        public int Number { get; set; }
        public float Lambda_EF { get; set; }
        public float Lambda_AF { get; set; }
        public float Lambda_BE { get; set; }
        public int EfQueueLength { get; set; }
        public int AfQueueLength { get; set; }
        public int BeQueueLength { get; set; }

        public Router(int number, string type)
        {
            this.Number = number;
            this.Type = type;
        }
    }
}
