using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacketSwitchedDesign
{
    class Router
    {
        private int Number { get; set; }
        private bool IsEdge { get; set; }

        public Router(int number, bool isEdge)
        {
            this.Number = number;
            this.IsEdge = isEdge;
        }
    }
}
