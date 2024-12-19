using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.entities;
using WpfApp1.utility;

namespace WpfApp1.models
{
    public class PartnersModel
    {
        // список партнеров
        public List<PartnersData> partners;


        public PartnersModel()
        {
            // инициализируем наш список
            partners = new List<PartnersData>(GetPartnersData());
        }


        // метод заполнения списка путем получения нужных данных из бд таблицы Partners
        private List<PartnersData> GetPartnersData()
        {
            List<PartnersData> result = new List<PartnersData>();
            using (var context = new MyDbContext())
            {
                foreach (var i in context.Partners)
                {
                    PartnersData partnersData = new PartnersData();
                    partnersData.id = i.id;
                    partnersData.type = i.PartnerType;
                    partnersData.name = i.PartnerName;
                    partnersData.director = i.Director;
                    partnersData.phone = i.DirectorPhone;
                    partnersData.rating = i.Rating;
                    partnersData.discount = getDiscount(i.id);

                    result.Add(partnersData);
                }
            }
            return result;
        }


        // метод высчитывания скидки партнера через его количество продаж
        private int getDiscount(int partnerID)
        {
            using (var context = new MyDbContext())
            {
                if (context.partnerProducts.Where(ch => ch.PartnerID == partnerID).Count() == 0) return 0;

                int totalAmount = (int)context.partnerProducts.Where(ch => ch.PartnerID == partnerID).Sum(ch => ch.SaleCount);
                if (totalAmount < 10000)
                {
                    return 0;
                }
                else if (totalAmount > 10000 && totalAmount < 50000)
                {
                    return 5;
                }
                else
                {
                    return 10;
                }
            }
        }
    }
}
