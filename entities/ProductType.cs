using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.entities
{
    // сущность для таблицы ProductType
    public class ProductType
    {
        [Key] public int id { get; set; }


        [Column("[Тип продукции]")]
        public string productType { get; set; }

        [Column("[Коэффициент типа продукции]")]
        public string ProductCoefficient { get; set; }
    }
}
