using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.entities
{
    // сущность для таблицы MaterialType
    public class MaterialType
    {
        [Key] public int id { get; set; }

        [Column("[Тип материала]")]
        public string type {  get; set; }

        [Column("[Процент брака материала ]")]
        public float defect { get; set; }
    }
}
