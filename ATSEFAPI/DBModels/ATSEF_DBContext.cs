using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ATSEFAPI.DBModels
{
    public partial class ATSEF_DBContext : DbContext
    {
        public virtual DbSet<Flight> Flight { get; set; }
        public virtual DbSet<FlightProfile> FlightProfile { get; set; }

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        ////#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                optionsBuilder.UseMySql("Server=172.16.21.200;User Id=rdas;Password=aerothai;Database=ATSEF_DB");
        //            }
        //        }
        public ATSEF_DBContext(DbContextOptions options)
         : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>(entity =>
            {
                entity.ToTable("FLIGHT");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AircraftType)
                    .IsRequired()
                    .HasColumnName("AIRCRAFT_TYPE")
                    .HasMaxLength(20);

                entity.Property(e => e.FlightNumber)
                    .IsRequired()
                    .HasColumnName("FLIGHT_NUMBER")
                    .HasMaxLength(10);

                entity.Property(e => e.IssuedDate)
                    .IsRequired()
                    .HasColumnName("ISSUED_DATE")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<FlightProfile>(entity =>
            {
                entity.ToTable("FLIGHT_PROFILE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccSectors)
                    .HasColumnName("ACC_SECTORS")
                    .HasMaxLength(255);

                entity.Property(e => e.Arrival)
                    .HasColumnName("ARRIVAL")
                    .HasMaxLength(4);

                entity.Property(e => e.Callsign)
                    .IsRequired()
                    .HasColumnName("CALLSIGN")
                    .HasMaxLength(10);

                entity.Property(e => e.Departure)
                    .HasColumnName("DEPARTURE")
                    .HasMaxLength(4);

                entity.Property(e => e.DeptTma)
                    .HasColumnName("DEPT_TMA")
                    .HasMaxLength(10);

                entity.Property(e => e.DestTma)
                    .HasColumnName("DEST_TMA")
                    .HasMaxLength(10);

                entity.Property(e => e.DirectDistance).HasColumnName("DIRECT_DISTANCE");

                entity.Property(e => e.EndRadian).HasColumnName("END_RADIAN");

                entity.Property(e => e.FirstEnrDistance).HasColumnName("FIRST_ENR_DISTANCE");

                entity.Property(e => e.FirstEnrTime)
                    .HasColumnName("FIRST_ENR_TIME")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.FirstEntLevel)
                    .HasColumnName("FIRST_ENT_LEVEL")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FirstEntTime)
                    .HasColumnName("FIRST_ENT_TIME")
                    .HasMaxLength(20);

                entity.Property(e => e.FirstEntX).HasColumnName("FIRST_ENT_X");

                entity.Property(e => e.FirstEntY).HasColumnName("FIRST_ENT_Y");

                entity.Property(e => e.FirstExitLevel)
                    .HasColumnName("FIRST_EXIT_LEVEL")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FirstExitTime)
                    .HasColumnName("FIRST_EXIT_TIME")
                    .HasMaxLength(20);

                entity.Property(e => e.FirstExitX).HasColumnName("FIRST_EXIT_X");

                entity.Property(e => e.FirstExitY).HasColumnName("FIRST_EXIT_Y");

                entity.Property(e => e.FirstLevel)
                    .HasColumnName("FIRST_LEVEL")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FirstTime)
                    .HasColumnName("FIRST_TIME")
                    .HasMaxLength(20);

                entity.Property(e => e.FirstX).HasColumnName("FIRST_X");

                entity.Property(e => e.FirstY).HasColumnName("FIRST_Y");

                entity.Property(e => e.FlightType)
                    .HasColumnName("FLIGHT_TYPE")
                    .HasColumnType("int(1)");

                entity.Property(e => e.LastLevel)
                    .HasColumnName("LAST_LEVEL")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LastTime)
                    .HasColumnName("LAST_TIME")
                    .HasMaxLength(20);

                entity.Property(e => e.LastX).HasColumnName("LAST_X");

                entity.Property(e => e.LastY).HasColumnName("LAST_Y");

                entity.Property(e => e.SecondEnrDistance).HasColumnName("SECOND_ENR_DISTANCE");

                entity.Property(e => e.SecondEnrTime)
                    .HasColumnName("SECOND_ENR_TIME")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.SecondEntLevel)
                    .HasColumnName("SECOND_ENT_LEVEL")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SecondEntTime)
                    .HasColumnName("SECOND_ENT_TIME")
                    .HasMaxLength(20);

                entity.Property(e => e.SecondEntX).HasColumnName("SECOND_ENT_X");

                entity.Property(e => e.SecondEntY).HasColumnName("SECOND_ENT_Y");

                entity.Property(e => e.Squawk)
                    .IsRequired()
                    .HasColumnName("SQUAWK")
                    .HasMaxLength(4);

                entity.Property(e => e.StartRadian).HasColumnName("START_RADIAN");

                entity.Property(e => e.Waypoints)
                    .HasColumnName("WAYPOINTS")
                    .HasMaxLength(4096);
            });
        }
    }
}
