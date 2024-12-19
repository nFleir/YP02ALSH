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

    // сущность для таблицы PartnerProducts
    public class Partner_Products : MainViewModel
    {
        [Key] public int id { get; set; }


        private int _productID;
        public int ProductID
        {
            get => _productID;
            set
            {
                if (_productID != value)
                {
                    _productID = value;
                    OnPropertyChanged(nameof(_productID));
                }
            }
        }

        private int _partnerID;

        public int PartnerID
        {
            get => _partnerID;
            set
            {
                if (_partnerID != value)
                {
                    _partnerID = value;
                    OnPropertyChanged(nameof(_partnerID));
                }
            }
        }

        private float _saleCount;
        public float SaleCount
        {
            get => _saleCount;
            set
            {
                if (_saleCount != value)
                {
                    _saleCount = value;
                    OnPropertyChanged(nameof(SaleCount));
                }
            }
        }

        private DateTime _saleDate;
        public DateTime SaleDate
        {
            get => _saleDate;
            set
            {
                if (_saleDate != value)
                {
                    _saleDate = value;
                    OnPropertyChanged(nameof(SaleDate));
                }
            }
        }
    }
}
