using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.entities;

namespace WpfApp1.utility
{

    // класс для работы с бд
    public static class DbManager
    {

        // метод получения экземпляра Partner по айди
        public static Partners getPartnerByID(int id)
        {
            using (var context = new MyDbContext())
            {
                return context.Partners.First(ch => ch.id == id);
            }
        }

        // метод добавления нового пользователя
        public static void addNewUser(string name, string type, string fio, string mail, string phone, string address, string inn, float rating)
        {
            using (var context = new MyDbContext())
            {
                Partners partner = new Partners();
                partner.PartnerName = name;
                partner.PartnerType = type;
                partner.Director = fio;
                partner.DirectorMail = mail;
                partner.DirectorPhone = phone;
                partner.DirectorAddress = address;
                partner.INN = float.Parse(inn); 
                partner.Rating = rating;
                context.Partners.Add(partner);
                context.SaveChanges();
            }
        }

        // метод изменения существующего пользователя
        public static void editUser(int id, string name, string type, string fio, string mail, string phone, string address, string inn, float rating)
        {
            using (var context = new MyDbContext())
            {
                var partner = context.Partners.First(ch => ch.id == id);
                partner.PartnerName = name;
                partner.PartnerType = type;
                partner.Director = fio;
                partner.DirectorMail = mail;
                partner.DirectorPhone = phone;
                partner.DirectorAddress = address;
                partner.INN = float.Parse(inn);
                partner.Rating = rating;
                context.SaveChanges();
            }
        }

        // метод получения истории продаж продукции по айди партнера
        public static List<ProductHistory> getProductsHistoryByPartnerID(int partnerID)
        {
            List<ProductHistory> result = new List<ProductHistory>();
            using (var context = new MyDbContext())
            {
                foreach (var i in context.partnerProducts.Where(ch => ch.PartnerID == partnerID))
                {
                    ProductHistory product = new ProductHistory();
                    product.partnerName = getPartnerNameByID(i.PartnerID);
                    product.name = getProductNameByID(i.ProductID);
                    product.count = i.SaleCount;
                    product.date = i.SaleDate;
                    result.Add(product);
                }
            }
            return result;
        }

        // метод получения имени партнера по его айди
        public static string getPartnerNameByID(int id)
        {
            using (var context = new MyDbContext())
            {
                return context.Partners.First(ch => ch.id == id).PartnerName;
            }
        }

        // метод получения названия продукта по его айди
        public static string getProductNameByID(int id)
        {
            using (var context = new MyDbContext())
            {
                return context.Products.First(ch => ch.id == id).ProductName;
            }
        }
    }
}
