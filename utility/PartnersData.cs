using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.utility
{

    // класс для получения нужных данных по партнеру
    public class PartnersData
    {
        public int id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string director { get; set; }
        public string phone { get; set; }
        public float rating { get; set; }
        public int discount { get; set; }
    }
}
