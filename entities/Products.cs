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
    // сущность для таблицы Products
    public class Products : MainViewModel
    {
        [Key] public int id { get; set; }

        private int _productType;
        public int ProductType
        {
            get => _productType;
            set
            {
                if (_productType != value)
                {
                    _productType = value;
                    OnPropertyChanged(nameof(ProductType));
                }
            }
        }

        private string _productName;
        public string ProductName
        {
            get => _productName;
            set
            {
                if (_productName != value)
                {
                    _productName = value;
                    OnPropertyChanged(nameof(ProductName));
                }
            }
        }

        private float _article;
        public float Article
        {
            get => _article;
            set
            {
                if (_article != value)
                {
                    _article = value;
                    OnPropertyChanged(nameof(Article));
                }
            }
        }

        private float _partnerMinPrice;
        public float PartnerMinPrice
        {
            get => _partnerMinPrice;
            set
            {
                if (_partnerMinPrice != value)
                {
                    _partnerMinPrice = value;
                    OnPropertyChanged(nameof(PartnerMinPrice));
                }
            }
        }

    }
}
