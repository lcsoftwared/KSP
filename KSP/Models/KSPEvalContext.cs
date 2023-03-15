using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KSP.Models
{
    public partial class KSPEvalContext : DbContext
    {
        public KSPEvalContext()
        {
        }

        public KSPEvalContext(DbContextOptions<KSPEvalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Beneficiario> Beneficiarios { get; set; } = null!;
        public virtual DbSet<Empleado> Empleados { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("server=localhost; database=KSPEval; integrated security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Beneficiario>(entity =>
            {
                entity.HasKey(e => e.IdBeneficiario);

                entity.Property(e => e.DtFechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("dtFechaNacimiento");

                entity.Property(e => e.StrNombreCompleto)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("strNombreCompleto");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado);

                entity.Property(e => e.BitEstatus).HasColumnName("bitEstatus");

                entity.Property(e => e.DatFechaContratacion)
                    .HasColumnType("date")
                    .HasColumnName("datFechaContratacion");

                entity.Property(e => e.ImgFoto)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("imgFoto");

                entity.Property(e => e.MnySalario)
                    .HasColumnType("money")
                    .HasColumnName("mnySalario");

                entity.Property(e => e.StrNombreCompleto)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("strNombreCompleto");

                entity.Property(e => e.StrPuesto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("strPuesto");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
