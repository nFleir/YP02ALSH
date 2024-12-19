using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Xml;
using WpfApp1.entities;

namespace WpfApp1
{
    // класс для контекста базы данных
    public class MyDbContext : DbContext
    {
        // таблицы
        public DbSet<Partners> Partners { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<ProductType> productType { get; set; }
        public DbSet<MaterialType> materialType { get; set; }
        public DbSet<Partner_Products> partnerProducts { get; set; }

        public MyDbContext() : base("MyDbContext")
        {

        }

        // обработчик при создании модели
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // корректиризуем данные дабы orm понимала что к чему и как относится

            // продукты партнеров
            modelBuilder.Entity<Partner_Products>()
                        .Property(e => e.ProductID)
                        .HasColumnName("id_продукция");
            modelBuilder.Entity<Partner_Products>()
                        .Property(e => e.PartnerID)
                        .HasColumnName("id_партнера");
            modelBuilder.Entity<Partner_Products>()
                        .Property(e => e.SaleCount)
                        .HasColumnName("Количество продукции")
                        .HasColumnType("FLOAT");
            modelBuilder.Entity<Partner_Products>()
                        .Property(e => e.SaleDate)
                        .HasColumnName("Дата продажи");

            // партнеры
            modelBuilder.Entity<Partners>()
                .Property(e => e.PartnerType)
                .HasColumnName("Тип партнера");

            modelBuilder.Entity<Partners>()
                .Property(e => e.PartnerName)
                .HasColumnName("Наименование партнера");

            modelBuilder.Entity<Partners>()
                .Property(e => e.Director)
                .HasColumnName("Директор");

            modelBuilder.Entity<Partners>()
                .Property(e => e.DirectorMail)
                .HasColumnName("Электронная почта партнера");

            modelBuilder.Entity<Partners>()
                .Property(e => e.DirectorPhone)
                .HasColumnName("Телефон партнера");

            modelBuilder.Entity<Partners>()
                .Property(e => e.DirectorAddress)
                .HasColumnName("Юридический адрес партнера");

            modelBuilder.Entity<Partners>()
                .Property(e => e.INN)
                .HasColumnName("ИНН")
                .HasColumnType("FLOAT");  

            modelBuilder.Entity<Partners>()
                .Property(e => e.Rating)
                .HasColumnName("Рейтинг")
                .HasColumnType("FLOAT");

            // продукты
            modelBuilder.Entity<Products>()
                    .Property(e => e.id)
                    .HasColumnName("id");
            modelBuilder.Entity<Products>()
                        .Property(e => e.ProductType)
                        .HasColumnName("Тип продукции");
            modelBuilder.Entity<Products>()
                        .Property(e => e.ProductName)
                        .HasColumnName("Наименование продукции");
            modelBuilder.Entity<Products>()
                        .Property(e => e.Article)
                        .HasColumnName("Артикул")
                        .HasColumnType("FLOAT");
            modelBuilder.Entity<Products>()
                            .Property(e => e.PartnerMinPrice)
                            .HasColumnName("Минимальная стоимость для партнера")
                            .HasColumnType("FLOAT");
        }
    }
}
