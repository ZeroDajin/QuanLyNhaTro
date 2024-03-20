using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN
{
     class TaikhoanAD
    {
        private string taikhoanad;
        private string matkhauad;

        public TaikhoanAD()
        {
        }

        public TaikhoanAD(string taikhoanad, string matkhauad)
        {
            this.taikhoanad = taikhoanad;
            this.matkhauad = matkhauad;
        }

        public string Taikhoanad { get => taikhoanad; set => taikhoanad = value; }
        public string Matkhauad { get => matkhauad; set => matkhauad = value; }
    }
}
