using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RazorPagesApp
{
    public partial class RazorPagesAppContext : DbContext
    {
        public RazorPagesAppContext()
        {
        }

        public RazorPagesAppContext(DbContextOptions<RazorPagesAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MastersAvailability> MastersAvailabilities { get; set; } = null!;
        public virtual DbSet<Option> Options { get; set; } = null!;
        public virtual DbSet<OrdersList> OrdersLists { get; set; } = null!;
        public virtual DbSet<SystemPackage> SystemPackages { get; set; } = null!;
        public virtual DbSet<SystemTonnage> SystemTonnages { get; set; } = null!;
        public virtual DbSet<SystemType> SystemTypes { get; set; } = null!;
        public virtual DbSet<Themostat> Themostats { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server= LAPTOP-77MT8LVK; Database=RazorPagesApp; Trusted_Connection=True; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MastersAvailability>(entity =>
            {
                entity.ToTable("MastersAvailability");

                entity.Property(e => e.Date).HasColumnType("date");
            });

            modelBuilder.Entity<Option>(entity =>
            {
                entity.Property(e => e.Img)
                    .HasMaxLength(200)
                    .HasColumnName("IMG");

                entity.Property(e => e.OptionDesc).HasMaxLength(500);

                entity.Property(e => e.OptionName).HasMaxLength(100);
            });

            modelBuilder.Entity<OrdersList>(entity =>
            {
                entity.ToTable("OrdersList");

                entity.Property(e => e.OrderOptionsIds).HasMaxLength(200);

                entity.HasOne(d => d.OrderDateNavigation)
                    .WithMany(p => p.OrdersLists)
                    .HasForeignKey(d => d.OrderDate)
                    .HasConstraintName("FK__OrdersLis__Order__5165187F");

                entity.HasOne(d => d.OrderPackage)
                    .WithMany(p => p.OrdersLists)
                    .HasForeignKey(d => d.OrderPackageId)
                    .HasConstraintName("FK__OrdersLis__Order__4F7CD00D");

                entity.HasOne(d => d.OrderSystemTonnage)
                    .WithMany(p => p.OrdersLists)
                    .HasForeignKey(d => d.OrderSystemTonnageId)
                    .HasConstraintName("FK__OrdersLis__Order__4E88ABD4");

                entity.HasOne(d => d.OrderSystemType)
                    .WithMany(p => p.OrdersLists)
                    .HasForeignKey(d => d.OrderSystemTypeId)
                    .HasConstraintName("FK__OrdersLis__Order__4D94879B");

                entity.HasOne(d => d.OrderThermostat)
                    .WithMany(p => p.OrdersLists)
                    .HasForeignKey(d => d.OrderThermostatId)
                    .HasConstraintName("FK__OrdersLis__Order__5070F446");
            });

            modelBuilder.Entity<SystemPackage>(entity =>
            {
                entity.Property(e => e.Img)
                    .HasMaxLength(200)
                    .HasColumnName("IMG");

                entity.Property(e => e.SystemPackageDesc).HasMaxLength(500);

                entity.Property(e => e.SystemPackageName).HasMaxLength(100);

                entity.Property(e => e.TonnageId).HasColumnName("TonnageID");

                entity.HasOne(d => d.Tonnage)
                    .WithMany(p => p.SystemPackages)
                    .HasForeignKey(d => d.TonnageId)
                    .HasConstraintName("FK__SystemPac__Tonna__286302EC");
            });

            modelBuilder.Entity<SystemTonnage>(entity =>
            {
                entity.Property(e => e.SystemTonnageName).HasMaxLength(100);
            });

            modelBuilder.Entity<SystemType>(entity =>
            {
                entity.Property(e => e.Img)
                    .HasMaxLength(200)
                    .HasColumnName("IMG");

                entity.Property(e => e.SystemTypeName).HasMaxLength(100);
            });

            modelBuilder.Entity<Themostat>(entity =>
            {
                entity.Property(e => e.Img)
                    .HasMaxLength(200)
                    .HasColumnName("IMG");

                entity.Property(e => e.ThermoName).HasMaxLength(150);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
