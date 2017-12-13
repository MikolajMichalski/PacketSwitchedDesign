using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacketSwitchedDesign
{
    public class Link
    {
        public string Index { get; set; }
        public Router SourceRouter { get; set; }    
        public Router DestRouter { get; set; }       
        public float ThroughputEF { get; set; }
        public float ThroughputAF { get; set; }
        public float ThroughputBE { get; set; }
        public int ThroughputOTN { get; set; }
        public float LinkLength { get; set; }
        public float B_EF { get; set; }
        public float B_AF { get; set; }
        public float B_BE { get; set; }
        public float A_EF { get; set; }
        public float A_AF { get; set; }
        public float A_BE { get; set; }

        public double B_EF1 { get; set; }
        public double B_AF1 { get; set; }
        public double B_BE1 { get; set; }
        public Link(Router sourceRouter, Router destRouter,  float linkLength)
        {
            this.SourceRouter = sourceRouter;
            this.DestRouter = destRouter;
            this.LinkLength = linkLength;
            this.Index = sourceRouter.Number.ToString() + destRouter.Number.ToString();
            this.ThroughputEF = 0;
            this.ThroughputAF = 0;
            this.ThroughputBE = 0;
            this.B_EF = 0;
            this.B_AF = 0;
            this.B_BE = 0;
            this.A_EF = 0;
            this.A_AF = 0;
            this.A_BE = 0;
            this.B_EF1 = 0;
            this.B_AF1 = 0;
            this.B_BE1 = 0;
        }
    }
}
