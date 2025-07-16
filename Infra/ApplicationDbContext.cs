using Microsoft.EntityFrameworkCore;
using PicPaySimplificado.Model;
using System;

namespace PicPaySimplificado.Infra
{

	public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
		public DbSet<CarteiraEntity> Wallets { get; set; }
        public DbSet<TransferenciaEntity> transfers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarteiraEntity>()
                .HasIndex(w => new {w.CpfCnpj, w.Email})
                .IsUnique();

            modelBuilder.Entity<TransferenciaEntity>()
                .HasKey(t => t.IdTransaction);
            
            
            modelBuilder.Entity<CarteiraEntity>()
                .Property(c => c.SaldoConta)
                .HasColumnType("decimal(18,2)");
            
            modelBuilder.Entity<TransferenciaEntity>()
                .Property(t => t.Valor)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<CarteiraEntity>()
                .Property(w => w.TipoUsuario)
                .HasConversion<string>();

            modelBuilder.Entity<TransferenciaEntity>()
                .HasOne(t => t.Sender)
                .WithMany()
                .HasForeignKey(t => t.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TransferenciaEntity>()
                .HasOne(t => t.Receiver)
                .WithMany()
                .HasForeignKey(t => t.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
