using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacketSwitchedDesign.Pages;

namespace PacketSwitchedDesign
{
    public class ETEConnection
    {
        public Router SourceNode { get; set; }
        public Router DestNode { get; set; }
        public ISet<Link> Route = new HashSet<Link>();
        public float WZ_CBR { get; set; }
        public float WZ_VBR1 { get; set; }
        public float WZ_VBR2 { get; set; }
        public float C_EF { get; set; }
        public float C_AF { get; set; }
        public float C_BE { get; set; }
    }
}
