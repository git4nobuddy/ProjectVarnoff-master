using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ProjectVarnoff.Database
{
    public partial class Model1 : DbContext
    {
         private static Model1 Instance;
        public static Model1 Init()
        {
            if (Instance == null)
                Instance = new Model1();
            return Instance;
        }






    

        public Model1()
            : base("name=EfModel")
        {
        }

        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<ClientService> ClientService { get; set; }
        public virtual DbSet<DocumentByService> DocumentByService { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Manufacturer> Manufacturer { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductPhoto> ProductPhoto { get; set; }
        public virtual DbSet<ProductSale> ProductSale { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<ServicePhoto> ServicePhoto { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Patronymic)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.RegistrationDate)
                .HasPrecision(6);

            modelBuilder.Entity<Client>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.GenderCode)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.ClientService)
                .WithRequired(e => e.Client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Tag)
                .WithMany(e => e.Client)
                .Map(m => m.ToTable("TagOfClient", "").MapLeftKey("ClientID").MapRightKey("TagID"));

            modelBuilder.Entity<ClientService>()
                .Property(e => e.StartTime)
                .HasPrecision(6);

            modelBuilder.Entity<ClientService>()
                .Property(e => e.Comment)
                .IsUnicode(false);

            modelBuilder.Entity<ClientService>()
                .HasMany(e => e.DocumentByService)
                .WithRequired(e => e.ClientService)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DocumentByService>()
                .Property(e => e.DocumentPath)
                .IsUnicode(false);

            modelBuilder.Entity<Gender>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Gender>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Gender>()
                .HasMany(e => e.Client)
                .WithRequired(e => e.Gender)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Manufacturer>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.MainImagePath)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductPhoto)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductSale)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Product1)
                .WithMany(e => e.Product2)
                .Map(m => m.ToTable("AttachedProduct", "").MapLeftKey("MainProductID").MapRightKey("AttachedProductID"));

            modelBuilder.Entity<ProductPhoto>()
                .Property(e => e.PhotoPath)
                .IsUnicode(false);

            modelBuilder.Entity<ProductSale>()
                .Property(e => e.SaleDate)
                .HasPrecision(6);

            modelBuilder.Entity<Service>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Service>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Service>()
                .HasMany(e => e.ClientService)
                .WithRequired(e => e.Service)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Service>()
                .HasMany(e => e.ServicePhoto)
                .WithRequired(e => e.Service)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ServicePhoto>()
                .Property(e => e.PhotoPath)
                .IsUnicode(false);

            modelBuilder.Entity<Tag>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Tag>()
                .Property(e => e.Color)
                .IsUnicode(false);
        }
    }
}
