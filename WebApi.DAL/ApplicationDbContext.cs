using Microsoft.EntityFrameworkCore;
using WebApi.DAL.Entities;
using WebApi.DAL.Properties;

namespace WebApi.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(Resources.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Customer>(entity =>
            {
                entity.ToTable("customers");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Firstname)
                    .HasColumnType("character varying")
                    .HasColumnName("firstname")
                    .IsRequired();

                entity.Property(e => e.Lastname)
                    .HasColumnType("character varying")
                    .HasColumnName("lastname")
                    .IsRequired();
            });
        }
    }
}
