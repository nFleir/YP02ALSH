using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.utility;

namespace WpfApp1.entities
{
    // сущность для таблицы Partners
    public class Partners : MainViewModel
    {
        [Key] public int id { get; set; }


        private string _partnerType;
        public string PartnerType
        {
            get => _partnerType;
            set
            {
                if (_partnerType != value)
                {
                    _partnerType = value;
                    OnPropertyChanged(nameof(PartnerType));
                }
            }
        }

        private string _partnerName;
        public string PartnerName
        {
            get => _partnerName;
            set
            {
                if (_partnerName != value)
                {
                    _partnerName = value;
                    OnPropertyChanged(nameof(PartnerName));
                }
            }
        }

        private string _director;
        public string Director
        {
            get => _director;
            set
            {
                if (_director != value)
                {
                    _director = value;
                    OnPropertyChanged(nameof(Director));
                }
            }
        }

        private string _directorMail;
        public string DirectorMail
        {
            get => _directorMail;
            set
            {
                if (_directorMail != value)
                {
                    _directorMail = value;
                    OnPropertyChanged(nameof(DirectorMail));
                }
            }
        }

        private string _directorPhone;
        public string DirectorPhone
        {
            get => _directorPhone;
            set
            {
                if (_directorPhone != value)
                {
                    _directorPhone = value;
                    OnPropertyChanged(nameof(DirectorPhone));
                }
            }
        }

        private string _directorAddress;

        public string DirectorAddress
        {
            get => _directorAddress;
            set
            {
                if (_directorAddress != value)
                {
                    _directorAddress = value;
                    OnPropertyChanged(nameof(DirectorAddress));
                }
            }
        }

        private float _inn;
        public float INN
        {
            get => _inn;
            set
            {
                if (_inn != value)
                {
                    _inn = value;
                    OnPropertyChanged(nameof(INN));
                }
            }
        }

        private float _rating;
        public float Rating
        {
            get => _rating;
            set
            {
                if (_rating != value)
                {
                    _rating = value;
                    OnPropertyChanged(nameof(Rating));
                }
            }
        }

    }
}
