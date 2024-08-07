using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Boren.Traveler.Data;

public partial class TravelerDbContext : DbContext
{
    public TravelerDbContext()
    {
    }

    public TravelerDbContext(DbContextOptions<TravelerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Place> Places { get; set; }

    public virtual DbSet<Trip> Trips { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=Traveler;Username=postgres;port=5432");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Place>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Place_pkey");

            entity.ToTable("Place");

            entity.Property(e => e.CustomName)
                .HasMaxLength(255)
                .HasComment("自訂名稱");
            entity.Property(e => e.Location).HasComment("座標");
            entity.Property(e => e.Order).HasComment("順序");
            entity.Property(e => e.OriginName)
                .HasMaxLength(255)
                .HasComment("Place API.displayName");
            entity.Property(e => e.PlaceApiId)
                .HasMaxLength(128)
                .HasComment("Place API.Id");
            entity.Property(e => e.Remark).HasComment("備註");
            entity.Property(e => e.Stay).HasComment("停留時長");

            entity.HasOne(d => d.Trip).WithMany(p => p.Places)
                .HasForeignKey(d => d.TripId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Place_TripId_fkey");
        });

        modelBuilder.Entity<Trip>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Trip_pkey");

            entity.ToTable("Trip", tb => tb.HasComment("旅程"));

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasComment("旅程名稱");
            entity.Property(e => e.Time).HasComment("創建時間");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
