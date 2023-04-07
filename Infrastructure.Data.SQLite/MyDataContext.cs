using Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace Infrastructure.Data.Sqlite
{
    public class MyDataContext : DbContext
    {
        public MyDataContext()
        {
        }

        public MyDataContext(DbContextOptions options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Annonces>(x => x.ToTable("T_Annonces"));

        }
    }
}