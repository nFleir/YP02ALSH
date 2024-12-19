using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp1.models;
using WpfApp1.utility;

namespace WpfApp1.viewModel
{
    public class PartnersVM : MainViewModel
    {
        // инициализация модели
        private PartnersModel _partnersModel = new PartnersModel();
        // ссылка на навигацию
        private Navigation _navigation;


        // список партнеров
        private List<PartnersData> _partnersData;
        public List<PartnersData> PartnersData
        {
            get { return _partnersData; }
            set { _partnersData = value; OnPropertyChanged(); }
        }
        
        // команды
        public ICommand addMemberCommand { get; set; }
        public ICommand editMemberCommand { get; set; }
        public ICommand checkHistoryCommand { get; set; }

        public PartnersVM(Navigation navigation)
        {
            // привязка данных
            _partnersData = _partnersModel.partners;

            addMemberCommand = new RelayCommand(addMember);
            editMemberCommand = new RelayCommand(editMember);
            checkHistoryCommand = new RelayCommand(checkHistory);


            _navigation = navigation;
        }

        // метод добавления партнера
        private void addMember(object obj)
        {
            _navigation.CurrentView = new AddAndEditUserVM(_navigation);
        }

        // метод изменения партнеров
        private void editMember(object obj)
        {
            if (obj is int)
            {
                _navigation.CurrentView = new AddAndEditUserVM(_navigation, (int)obj);
            }
        }

        // метод проверки истории
        private void checkHistory(object obj)
        {
            if (obj is int)
            {
                _navigation.CurrentView = new PartnerHistoryVM(_navigation, (int)obj);
            }
        }
    }
}
