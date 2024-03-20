using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN
{
    internal class TaikhoanK
    {
        private string taikhoank;
        private string matkhauk;

        public TaikhoanK()
        {
        }

        public TaikhoanK(string taikhoank, string matkhauk)
        {
            this.taikhoank = taikhoank;
            this.matkhauk = matkhauk;
        }

        public string Taikhoank { get => taikhoank; set => taikhoank = value; }
        public string Matkhauk { get => matkhauk; set => matkhauk = value; }
    }
}
