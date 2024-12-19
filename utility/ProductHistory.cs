using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.utility
{
    // класс для получения нужных данных по продукту
    public class ProductHistory
    {
        public string partnerName { get;set; }
        public string name { get; set; }
        public float count { get; set; }
        public DateTime date { get; set; }
    }
}
