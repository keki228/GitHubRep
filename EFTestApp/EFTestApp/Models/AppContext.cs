using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace EFTestApp.Models
{
    public class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        //public DbSet<Passport> Passports { get; set; }
        public AppContext()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EFTestApp;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>();
            modelBuilder.Entity<Passport>();
            modelBuilder.Entity<Company>().Property(x => x.Name).HasColumnName("Manifacturer");
            modelBuilder.Entity<Passport>().HasKey(x => new { x.INN, x.SerialNumber });
            modelBuilder.Entity<User>().HasKey(x => x.Id).HasName("UsersPrimaryKey");
            modelBuilder.Entity<User>().HasAlternateKey(x => x.Position);
            modelBuilder.Entity<User>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<User>().Property(x => x.Info).ValueGeneratedNever();
            modelBuilder.Entity<User>().Property(x => x.Age).HasDefaultValue(18);
            modelBuilder.Entity<User>().Property(x => x.CreatedDate).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Company>().Property(x => x.Id).IsRequired();

            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());

            modelBuilder.Entity<User>()
                .HasOne(x => x.Motherland)
                .WithMany(y => y.Users)
                .HasForeignKey(z => z.CountryId);

            modelBuilder.Entity<User>()
                .HasOne(x => x.Manifacturer)
                .WithMany(y => y.Users)
                .HasForeignKey(z => z.CompanyId);

            modelBuilder.Entity<User>().HasData(
                new User[]
                {
                    new User {Id = 1, Name = "Nurs", Position = "Norm", Info = "hz"}

                });
        }
    }
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.Property(x => x.Name).HasColumnType("varchar(20)");
        }
    }
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Компании").Property(x => x.Name).HasMaxLength(25);
        }
    }
}
