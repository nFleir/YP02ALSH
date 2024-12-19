using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using System.Xml.Linq;
using WpfApp1.entities;
using WpfApp1.utility;

namespace WpfApp1.models
{
    public class AddAndEditUserModel
    {
        // создаем лист для дальнейшего хранения типов компаний
        public List<string> types;

        public AddAndEditUserModel()
        {
            // инициализируем наш лист
            types = new List<string>(getTypes());
        }

        // получаем список из бд таблицы Partners по столбцу PartnerType без повторений
        private List<string> getTypes()
        {
            List<string> result = new List<string>();
            using (var context = new MyDbContext())
            {
                foreach (var i in context.Partners)
                {
                    if (result.Contains(i.PartnerType) == false) result.Add(i.PartnerType);
                }
            }
            return result;
        }


        // методы проверок данных для создания или изменения партнера
        public bool checkName(string name) => !string.IsNullOrEmpty(name) && name.Length > 0 && name.Length <= 255;
        public bool checkType(string type) => !string.IsNullOrEmpty(type);
        public bool checkFio(string fio) => !string.IsNullOrEmpty(fio) && fio.Length > 0 && fio.Length <= 255;
        public bool checkMail(string mail) => !string.IsNullOrEmpty(mail) && mail.Length > 0 && mail.Length <= 255;
        public bool checkPhone(string phone) => !string.IsNullOrEmpty(phone) && phone.Length > 0 && phone.Length <= 15;
        public bool checkAddress(string address) => !string.IsNullOrEmpty(address) && address.Length > 0 && address.Length <= 255;
        public bool checkINN(string inn) => inn.Length == 10;
        public bool checkRating(float rating) => rating > 0 && rating <= 10;


        // метод добавления нового пользователя
        public void AddNewUser(string name, string type, string fio, string mail, string phone, string address, string inn, float rating)
        {
            DbManager.addNewUser(name, type, fio, mail, phone, address, inn, rating);
        }


        // метод изменения существующего пользователя
        public void EditUser(int id, string name, string type, string fio, string mail, string phone, string address, string inn, float rating)
        {
            DbManager.editUser(id, name, type, fio, mail, phone, address, inn, rating);
        }

        // метод получения пользователя для изменения
        public Partners getEditPartner(int id)
        {
            return DbManager.getPartnerByID(id);
        }
    }
}
