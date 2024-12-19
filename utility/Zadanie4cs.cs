using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.entities;

namespace WpfApp1.utility
{
    // класс для 4 пункта
    // Метод должен рассчитывать целое количество материала, необходимого
    // для производства указанного количества продукции, учитывая возможный
    // брак материала.
    internal class Zadanie4cs
    {
        public int CalculateMaterial(int productTypeId,
               int materialTypeId,
               int productCount,
               double parameter1,
               double parameter2)
        {
            if (productTypeId <= 0 || materialTypeId <= 0 || productCount <= 0 || parameter1 <= 0 || parameter2 <= 0)
            {
                return -1;
            }
            var productType = getProductType(productTypeId);
            if (productType == null)
            {
                return -1;
            }
            var materialType = getMaterialType(materialTypeId);
            if (materialType == null)
            {
                return -1;
            }
            try
            {
                double materialPerUnit = parameter1 * parameter2 * Convert.ToDouble(productType.ProductCoefficient);
                double totalMaterial = materialPerUnit * productCount;
                double defectMultiplier = 1 + (materialType.defect / 100);
                totalMaterial *= defectMultiplier;
                return (int)Math.Ceiling(totalMaterial);
            }
            catch
            {
                return -1;
            }
        }

        private ProductType getProductType(int id)
        {
            using (var context = new MyDbContext())
            {
                return context.productType.FirstOrDefault(ch => ch.id == id);
            }
        }

        private MaterialType getMaterialType(int id)
        {
            using (var context = new MyDbContext())
            {
                return context.materialType.FirstOrDefault(ch => ch.id == id);
            }
        }
    }
}
