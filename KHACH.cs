using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN
{
    internal class KHACH
    {
        private string cmndk;
        private string name;
        private string phone;
        private string sex;
        private string diachi;

        public KHACH()
        {
        }

        public KHACH(string cmndk, string name, string phone,string sex , string diachi)
        {
            this.cmndk = cmndk;
            this.name = name;
            this.phone = phone;
            this.sex = sex;
            this.diachi = diachi;
        }

        public string Cmndk { get => cmndk; set => cmndk = value; }
        public string Name { get => name; set => name = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Sex { get => sex; set => sex = value; }
        public string Diachi { get => diachi; set => diachi = value; }
    }
}
