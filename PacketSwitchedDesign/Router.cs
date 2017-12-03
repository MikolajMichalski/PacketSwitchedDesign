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

        public Router(int number, string type)
        {
            this.Number = number;
            this.Type = type;
        }
    }
}
