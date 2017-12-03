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
        public ISet<Router> Routers = new HashSet<Router>();
        private ETEConnection[] DP { get; set; }
        public float[][] WZ_EF { get; set; }
        public float[][] WZ_AF { get; set; }
        public float[][] WZ_BE { get; set; }
        public float[] Lambda_EF { get; set; }
        public float[] Lambda_AF { get; set; }
        public float[] Lambda_BE { get; set; }
        public float A1 { get; set; }
        public float A12 { get; set; }
        public float A123 { get; set; }

        //public Network(int numberOfNodes, ETEConnection[] dp, float[][] wz_ef, float[][] wz_af, float[][] wz_be,
        //               float[] lambda_EF, float[] lambda_AF, float[] lambda_BE, float a1, float a12, float a123)
        //{
        //    this.NumberOfNodes = numberOfNodes;
        //    this.DP = dp;
        //    this.WZ_EF = wz_ef;
        //    this.WZ_AF = wz_af;
        //    this.WZ_BE = wz_be;
        //    this.Lambda_EF = lambda_EF;
        //    this.Lambda_AF = lambda_AF;
        //    this.Lambda_BE = lambda_BE;
        //    this.A1 = a1;
        //    this.A12 = a12;
        //    this.A123 = a123;
        //}
    }
}
