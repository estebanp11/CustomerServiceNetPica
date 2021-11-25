using CustomerService.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerService.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<Customer> Customers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasKey(o => new { o.numeroDocumento, o.tipoDocumento });
        }

        internal Task SaveChangesAsync(Customer cliente)
        {
            throw new NotImplementedException();
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql(@"Server=172.17.0.1;Port=5432;Database=postgres;Username=postgres;Password=postgres");
        //    //optionsBuilder.UseNpgsql(@"Server=Localhost;Port=5432;Database=postgres;Username=postgres;Password=123456");
        //    base.OnConfiguring(optionsBuilder);
        //}
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Customer>()
        //        .HasKey(o => new { o.numeroDocumento, o.tipoDocumento });
        //}
    }
}
