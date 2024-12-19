using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.models;
using WpfApp1.utility;

namespace WpfApp1.viewModel
{
    public class PartnerHistoryVM : MainViewModel
    {
        // ссылка на модель
        private PartnerHisotryModel _model;
        // ссылка на навигацию
        private Navigation _navigation;
        // текущий партнер(айди)
        private int _currentPartner;

        // текущее имя партнера
        private string _currentPartnerName;

        public string CurrentPartnerName
        {
            get { return _currentPartnerName; }
            set { _currentPartnerName = value; OnPropertyChanged(); }
        }

        // история продаж партнера
        private List<ProductHistory> _products;

        public List<ProductHistory> Products
        {
            get { return _products; }
            set { _products = value; OnPropertyChanged(); }
        }

        // команды
        public ICommand goBackCommand { get; set; }


        public PartnerHistoryVM(Navigation navigation, int partnerID)
        {
            // привязка данных
            _navigation = navigation; 
            _currentPartner = partnerID;

            // инициализация и привязка данных
            _model = new PartnerHisotryModel(_currentPartner);
            CurrentPartnerName = _model.getPartnerNameByID();
            Products = _model.products;

            // привязка данных
            goBackCommand = new RelayCommand(goBack);
        }
        
        // метод нажатия назад
        private void goBack(object obj)
        {
            _navigation.CurrentView = new PartnersVM(_navigation);
        }
    }
}
