using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Infrastructure;
using DataModel;
namespace RepositoryData
{
    public class ContextClass : DbContext
    {
        public ContextClass()
            : base("ContextClass")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Travel> Travels { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Yetki> Yetkis { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
               .HasMany(e => e.Messages) //one to many
               .WithRequired(e => e.User);//HasRequired or WithRequired non-nullable

            modelBuilder.Entity<User>()
               .HasMany(e => e.Travels);

            modelBuilder.Entity<User>()
               .HasMany(e => e.Products);

            modelBuilder.Entity<User>()
               .HasRequired<Yetki>(e => e.Yetki)
               .WithMany(e => e.User)
               .HasForeignKey<int>(e => e.YetkiId);

            modelBuilder.Entity<Yetki>()
              .HasMany(e => e.User)
              .WithRequired(e => e.Yetki)
              .WillCascadeOnDelete(true);

            modelBuilder.Entity<Yetki>()
              .HasMany(e => e.Products);

            modelBuilder.Entity<Yetki>()
              .HasMany(e => e.Travels)
              .WithRequired(e => e.Yetki)
              .WillCascadeOnDelete(true);

            modelBuilder.Entity<Message>()
                .HasRequired<User>(e => e.User)
                .WithMany(e => e.Messages)
                .HasForeignKey<int>(e => e.UserId);

           
            modelBuilder.Entity<Travel>()
               .HasRequired<Yetki>(e => e.Yetki)
               .WithMany(e => e.Travels)
               .HasForeignKey<int>(e => e.YetkiId);

          

            
        }




    }
}
