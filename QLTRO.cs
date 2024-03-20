using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN
{
    internal class QLTRO
    {
        private string idp;
        private string cmnd;
        private string tinhtrang;
        private double? tc=null ;
        private double? tt=null;
        private double? tdn=null;

        public QLTRO()
        {

        }

        public QLTRO(string idp, string cmnd, string tinhtrang, double? tc, double? tt, double? tdn)
        {
            this.idp = idp;
            this.cmnd = cmnd;
            this.tinhtrang = tinhtrang;
            this.tc = tc;
            this.tt = tt;
            this.tdn = tdn;
        }

        public string Idp { get => idp; set => idp = value; }
        public string Cmnd { get => cmnd; set => cmnd = value; }
        public string Tinhtrang { get => tinhtrang; set => tinhtrang = value; }
        public double? Tc { get => tc; set => tc = value; }
        public double? Tt { get => tt; set => tt = value; }
        public double? Tdn { get => tdn; set => tdn = value; }
        public double? conno()
        {
            return Tt + Tdn;
        }
    }
}
