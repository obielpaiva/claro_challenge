using Microsoft.EntityFrameworkCore;
using Projeto_Claro.Models;

namespace Projeto_Claro.Data
{

    public class DatabaseContext : DbContext
    {
        
        public virtual DbSet<ticketModel> Ticket { get; set; }
        
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence<int>("sequence_id", schema: "dbo").StartsAt(1).IncrementsBy(1);

            modelBuilder.Entity<ticketModel>(entity =>
            {   
                entity.Property(e =>e.RequestId).HasDefaultValueSql("NEXT VALUE FOR dbo.sequence_id").ValueGeneratedOnAdd();
                entity.Property(e => e.NameUser).HasColumnType("varchar(200)").HasColumnName("Name").IsRequired();
                entity.Property(e => e.Description).HasColumnType("varchar(200)").HasColumnName("Descrição").IsRequired();
                entity.Property(e => e.IPlocal).HasColumnType("varchar(100)").HasColumnName("IP do usuario");
                entity.Property(E => E.CPF).HasColumnName("varchar(100)").HasColumnName("CPF");

            });
        }
    }
}
