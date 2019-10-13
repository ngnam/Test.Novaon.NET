using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Novaon.Web.Entities;

namespace Test.Novaon.Web.Infrastructure.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(ConfigureUserEntity);
        }

        private void ConfigureUserEntity(EntityTypeBuilder<User> b)
        {
            b.ToTable("Users", "AppTest");
            b.HasKey(c => c.Id);
            b.Property(c => c.Id).HasColumnName("Id").HasMaxLength(32).IsRequired();
            b.Property(c => c.Email).HasColumnName("Email").HasMaxLength(500);
            b.Property(c => c.PasswordHash).HasColumnName("PasswordHash").HasMaxLength(1000);
            b.HasIndex(p => p.Email).IsUnique();
        }
    }
}
