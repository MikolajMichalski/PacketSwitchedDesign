using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacketSwitchedDesign
{
    public class Network
    {
        public int NumberOfNodes { get; set; }
        public ISet<Link> Links = new HashSet<Link>();
        public ISet<Router> Routers = new HashSet<Router>();
        public ISet<ETEConnection> DPConnections = new HashSet<ETEConnection>();
        public float[][] WZ_EF { get; set; }
        public float[][] WZ_AF { get; set; }
        public float[][] WZ_BE { get; set; }
        public float A1 { get; set; }
        public float A12 { get; set; }
        public float A123 { get; set; }

    }
}
