using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacketSwitchedDesign
{
    public class ETEConnection
    {
        private Router SourceNode { get; set; }
        private Router Destnode { get; set; }
        public ISet<Link> Route = new HashSet<Link>();
        public float C_EF { get; set; }
        public float C_AF { get; set; }
        public float C_BE { get; set; }

        //public ETEConnection(Router[] route)
        //{
        ////    this.SourceNode = sourceNode;
        ////    this.Destnode = destNode;    
        //    this.Route = route;
        //}
        
    }
}
