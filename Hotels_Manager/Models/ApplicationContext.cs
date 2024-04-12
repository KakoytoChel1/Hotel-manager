using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Hotels_Manager;

public partial class ApplicationContext : DbContext
{
    public ApplicationContext() : base()
    {
        Database.EnsureCreated();
    }

    public virtual DbSet<Floor> Floors { get; set; }

    public virtual DbSet<Guest> Guests { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomType> RoomTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json")
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .Build();

        optionsBuilder.UseSqlite(config.GetConnectionString("DefaultConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Floor>(entity =>
        {
            entity.HasOne(d => d.Hotel)
                .WithMany(p => p.Floors)
                .HasForeignKey(d => d.HotelId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Guest>(entity =>
        {
            entity.HasOne(d => d.Room)
                .WithMany(p => p.Guests)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasOne(d => d.Guest)
                .WithOne(p => p.Reservation)
                .HasForeignKey<Reservation>(d => d.GuestId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasOne(d => d.Floor)
                .WithMany(p => p.Rooms)
                .HasForeignKey(d => d.FloorId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.RoomType)
                .WithMany(p => p.Rooms)
                .HasForeignKey(d => d.RoomTypeId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<RoomType>(entity =>
        {
            entity.HasIndex(e => e.TypeName, "IX_RoomTypes_TypeName")
                .IsUnique();
        });

        OnModelCreatingPartial(modelBuilder);
    }


    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
