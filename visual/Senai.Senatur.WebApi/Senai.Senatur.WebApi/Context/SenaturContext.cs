using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.Senatur.WebApi.Domains
{
    public partial class SenaturContext : DbContext
    {
        public SenaturContext()
        {
        }

        public SenaturContext(DbContextOptions<SenaturContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pacotes> Pacotes { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress; Initial Catalog=SENATUR_MANHA;User Id=sa; pwd=132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pacotes>(entity =>
            {
                entity.HasKey(e => e.Pacoteid);

                entity.ToTable("PACOTES");

                entity.Property(e => e.Pacoteid).HasColumnName("PACOTEID");

                entity.Property(e => e.Ativo)
                    .IsRequired()
                    .HasColumnName("ATIVO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dataida)
                    .HasColumnName("DATAIDA")
                    .HasColumnType("datetime");

                entity.Property(e => e.Datavolta)
                    .HasColumnName("DATAVOLTA")
                    .HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("DESCRICAO")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Nomecidade)
                    .HasColumnName("NOMECIDADE")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nomepacote)
                    .IsRequired()
                    .HasColumnName("NOMEPACOTE")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Valor)
                    .HasColumnName("VALOR")
                    .HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.Usuarioid);

                entity.ToTable("USUARIOS");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__USUARIOS__161CF7244A41EF0A")
                    .IsUnique();

                entity.Property(e => e.Usuarioid).HasColumnName("USUARIOID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("SENHA")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Tipousuario)
                    .IsRequired()
                    .HasColumnName("TIPOUSUARIO")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
