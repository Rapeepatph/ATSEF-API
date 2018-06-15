using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ATSEFAPI.DBModels
{
    public partial class ATSEF_DBContext : DbContext
    {
        public virtual DbSet<Airport> Airport { get; set; }
        public virtual DbSet<Distances201712> Distances201712 { get; set; }
        public virtual DbSet<Fix> Fix { get; set; }
        public virtual DbSet<Flight> Flight { get; set; }
        public virtual DbSet<Flightplan> Flightplan { get; set; }
        public virtual DbSet<FlightProfile> FlightProfile { get; set; }
        public virtual DbSet<GroupProfile> GroupProfile { get; set; }
        public virtual DbSet<GroupStatistic> GroupStatistic { get; set; }
        public virtual DbSet<RunwayHeading> RunwayHeading { get; set; }

        public ATSEF_DBContext(DbContextOptions<ATSEF_DBContext> options)
          : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airport>(entity =>
            {
                entity.ToTable("AIRPORT");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("CODE")
                    .HasMaxLength(10);

                entity.Property(e => e.Elevation).HasColumnName("ELEVATION");

                entity.Property(e => e.Latitude).HasColumnName("LATITUDE");

                entity.Property(e => e.Longitude).HasColumnName("LONGITUDE");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(255);

                entity.Property(e => e.Tma)
                    .HasColumnName("TMA")
                    .HasMaxLength(5);
            });

            modelBuilder.Entity<Distances201712>(entity =>
            {
                entity.HasKey(e => e.FlightId);

                entity.ToTable("distances_2017_12");

                entity.Property(e => e.FlightId)
                    .HasColumnName("flight_id")
                    .HasColumnType("int(12)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Actype)
                    .HasColumnName("actype")
                    .HasMaxLength(4);

                entity.Property(e => e.AllGc)
                    .HasColumnName("all_gc")
                    .HasColumnType("double(14,8)");

                entity.Property(e => e.AllPtp)
                    .HasColumnName("all_ptp")
                    .HasColumnType("double(14,8)");

                entity.Property(e => e.ArrAngle)
                    .HasColumnName("arr_angle")
                    .HasColumnType("double(14,8)");

                entity.Property(e => e.ArrInnerActual)
                    .HasColumnName("arr_inner_actual")
                    .HasColumnType("double(14,8)");

                entity.Property(e => e.ArrInnerAngle)
                    .HasColumnName("arr_inner_angle")
                    .HasColumnType("double(14,8)");

                entity.Property(e => e.ArrInnerMin)
                    .HasColumnName("arr_inner_min")
                    .HasColumnType("double(14,8)");

                entity.Property(e => e.ArrInnerPhase)
                    .HasColumnName("arr_inner_phase")
                    .HasMaxLength(200);

                entity.Property(e => e.ArrOuterActual)
                    .HasColumnName("arr_outer_actual")
                    .HasColumnType("double(14,8)");

                entity.Property(e => e.ArrOuterGc)
                    .HasColumnName("arr_outer_gc")
                    .HasColumnType("double(14,8)");

                entity.Property(e => e.ArrOuterMin)
                    .HasColumnName("arr_outer_min")
                    .HasColumnType("double(14,8)");

                entity.Property(e => e.ArrOuterPhase)
                    .HasColumnName("arr_outer_phase")
                    .HasMaxLength(200);

                entity.Property(e => e.Ata)
                    .HasColumnName("ata")
                    .HasColumnType("datetime");

                entity.Property(e => e.Atd)
                    .HasColumnName("atd")
                    .HasColumnType("datetime");

                entity.Property(e => e.Callsign)
                    .HasColumnName("callsign")
                    .HasMaxLength(15);

                entity.Property(e => e.Dep)
                    .HasColumnName("dep")
                    .HasMaxLength(80);

                entity.Property(e => e.DepActual)
                    .HasColumnName("dep_actual")
                    .HasColumnType("double(14,8)");

                entity.Property(e => e.DepMin)
                    .HasColumnName("dep_min")
                    .HasColumnType("double(14,8)");

                entity.Property(e => e.DepPhase)
                    .HasColumnName("dep_phase")
                    .HasMaxLength(200);

                entity.Property(e => e.Dest)
                    .HasColumnName("dest")
                    .HasMaxLength(80);

                entity.Property(e => e.EnrActual)
                    .HasColumnName("enr_actual")
                    .HasColumnType("double(14,8)");

                entity.Property(e => e.EnrGc)
                    .HasColumnName("enr_gc")
                    .HasColumnType("double(14,8)");

                entity.Property(e => e.EnrGcD)
                    .HasColumnName("enr_gc_d")
                    .HasColumnType("double(14,8)");

                entity.Property(e => e.EnrGcG)
                    .HasColumnName("enr_gc_g")
                    .HasColumnType("double(14,8)");

                entity.Property(e => e.EnrMin)
                    .HasColumnName("enr_min")
                    .HasColumnType("double(14,8)");

                entity.Property(e => e.EnrPhase)
                    .HasColumnName("enr_phase")
                    .HasMaxLength(200);

                entity.Property(e => e.EnrPtp)
                    .HasColumnName("enr_ptp")
                    .HasColumnType("double(14,8)");

                entity.Property(e => e.Runway)
                    .HasColumnName("runway")
                    .HasMaxLength(6);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Fix>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.ToTable("FIX");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(20);

                entity.Property(e => e.LatDegree)
                    .HasColumnName("LAT_DEGREE")
                    .HasMaxLength(20);

                entity.Property(e => e.Latitude)
                    .HasColumnName("LATITUDE")
                    .HasMaxLength(20);

                entity.Property(e => e.LongDegree)
                    .HasColumnName("LONG_DEGREE")
                    .HasMaxLength(20);

                entity.Property(e => e.Longitude)
                    .HasColumnName("LONGITUDE")
                    .HasMaxLength(20);
            });

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
                    .HasColumnName("ISSUED_DATE")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();
            });

            modelBuilder.Entity<Flightplan>(entity =>
            {
                entity.ToTable("FLIGHTPLAN");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Aircraft)
                    .HasColumnName("AIRCRAFT")
                    .HasMaxLength(10);

                entity.Property(e => e.AlternateAerodrome)
                    .HasColumnName("ALTERNATE_AERODROME")
                    .HasMaxLength(20);

                entity.Property(e => e.AlternateAerodrome2)
                    .HasColumnName("ALTERNATE_AERODROME_2")
                    .HasMaxLength(20);

                entity.Property(e => e.Ata)
                    .HasColumnName("ATA")
                    .HasColumnType("datetime");

                entity.Property(e => e.Atd)
                    .HasColumnName("ATD")
                    .HasColumnType("datetime");

                entity.Property(e => e.Callsign)
                    .HasColumnName("CALLSIGN")
                    .HasMaxLength(20);

                entity.Property(e => e.Cancelled)
                    .HasColumnName("CANCELLED")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Changed)
                    .HasColumnName("CHANGED")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Comnav)
                    .HasColumnName("COMNAV")
                    .HasMaxLength(50);

                entity.Property(e => e.DepartureAerodrome)
                    .HasColumnName("DEPARTURE_AERODROME")
                    .HasMaxLength(128);

                entity.Property(e => e.DepartureDate)
                    .HasColumnName("DEPARTURE_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.DestinationAerodrome)
                    .HasColumnName("DESTINATION_AERODROME")
                    .HasMaxLength(128);

                entity.Property(e => e.Eet)
                    .HasColumnName("EET")
                    .HasColumnType("datetime");

                entity.Property(e => e.Equipment)
                    .HasColumnName("EQUIPMENT")
                    .HasMaxLength(50);

                entity.Property(e => e.Eta)
                    .HasColumnName("ETA")
                    .HasColumnType("datetime");

                entity.Property(e => e.Etd)
                    .HasColumnName("ETD")
                    .HasColumnType("datetime");

                entity.Property(e => e.FdmsId)
                    .HasColumnName("FDMS_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FirstAchievedDistance).HasColumnName("FIRST_ACHIEVED_DISTANCE");

                entity.Property(e => e.FirstEnrDistance).HasColumnName("FIRST_ENR_DISTANCE");

                entity.Property(e => e.FirstEntLat).HasColumnName("FIRST_ENT_LAT");

                entity.Property(e => e.FirstEntLon).HasColumnName("FIRST_ENT_LON");

                entity.Property(e => e.FirstEntX).HasColumnName("FIRST_ENT_X");

                entity.Property(e => e.FirstEntY).HasColumnName("FIRST_ENT_Y");

                entity.Property(e => e.FirstExitLat).HasColumnName("FIRST_EXIT_LAT");

                entity.Property(e => e.FirstExitLon).HasColumnName("FIRST_EXIT_LON");

                entity.Property(e => e.FirstExitX).HasColumnName("FIRST_EXIT_X");

                entity.Property(e => e.FirstExitY).HasColumnName("FIRST_EXIT_Y");

                entity.Property(e => e.FirstFlightDistance).HasColumnName("FIRST_FLIGHT_DISTANCE");

                entity.Property(e => e.Fix)
                    .HasColumnName("FIX")
                    .HasMaxLength(512);

                entity.Property(e => e.FlightDelayed)
                    .HasColumnName("FLIGHT_DELAYED")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.FlightType)
                    .HasColumnName("FLIGHT_TYPE")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FlightplanType)
                    .HasColumnName("FLIGHTPLAN_TYPE")
                    .HasMaxLength(10);

                entity.Property(e => e.InboundLat).HasColumnName("INBOUND_LAT");

                entity.Property(e => e.InboundLon).HasColumnName("INBOUND_LON");

                entity.Property(e => e.InboundTime)
                    .HasColumnName("INBOUND_TIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.InboundX).HasColumnName("INBOUND_X");

                entity.Property(e => e.InboundY).HasColumnName("INBOUND_Y");

                entity.Property(e => e.Item18)
                    .HasColumnName("ITEM_18")
                    .HasMaxLength(1024);

                entity.Property(e => e.Kpi04A1).HasColumnName("KPI04_A1");

                entity.Property(e => e.Kpi04A2).HasColumnName("KPI04_A2");

                entity.Property(e => e.Kpi04B1).HasColumnName("KPI04_B1");

                entity.Property(e => e.Kpi04B2).HasColumnName("KPI04_B2");

                entity.Property(e => e.Level)
                    .HasColumnName("LEVEL")
                    .HasMaxLength(10);

                entity.Property(e => e.OutboundLat).HasColumnName("OUTBOUND_LAT");

                entity.Property(e => e.OutboundLon).HasColumnName("OUTBOUND_LON");

                entity.Property(e => e.OutboundTime)
                    .HasColumnName("OUTBOUND_TIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.OutboundX).HasColumnName("OUTBOUND_X");

                entity.Property(e => e.OutboundY).HasColumnName("OUTBOUND_Y");

                entity.Property(e => e.RegistrationNumber)
                    .HasColumnName("REGISTRATION_NUMBER")
                    .HasMaxLength(128);

                entity.Property(e => e.Route)
                    .HasColumnName("ROUTE")
                    .HasMaxLength(1024);

                entity.Property(e => e.Rule)
                    .HasColumnName("RULE")
                    .HasMaxLength(10);

                entity.Property(e => e.SecondAchievedDistance).HasColumnName("SECOND_ACHIEVED_DISTANCE");

                entity.Property(e => e.SecondEnrDistance).HasColumnName("SECOND_ENR_DISTANCE");

                entity.Property(e => e.SecondEntLat).HasColumnName("SECOND_ENT_LAT");

                entity.Property(e => e.SecondEntLon).HasColumnName("SECOND_ENT_LON");

                entity.Property(e => e.SecondEntX).HasColumnName("SECOND_ENT_X");

                entity.Property(e => e.SecondEntY).HasColumnName("SECOND_ENT_Y");

                entity.Property(e => e.SecondFlightDistance).HasColumnName("SECOND_FLIGHT_DISTANCE");

                entity.Property(e => e.Speed)
                    .HasColumnName("SPEED")
                    .HasMaxLength(10);

                entity.Property(e => e.Squawk)
                    .HasColumnName("SQUAWK")
                    .HasMaxLength(10);

                entity.Property(e => e.WakeTurbulence)
                    .HasColumnName("WAKE_TURBULENCE")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<FlightProfile>(entity =>
            {
                entity.ToTable("FLIGHT_PROFILE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccSectors)
                    .HasColumnName("ACC_SECTORS")
                    .HasMaxLength(255);

                entity.Property(e => e.Aircraft)
                    .HasColumnName("AIRCRAFT")
                    .HasMaxLength(10);

                entity.Property(e => e.Arrival)
                    .HasColumnName("ARRIVAL")
                    .HasMaxLength(128);

                entity.Property(e => e.ArrivalTime)
                    .HasColumnName("ARRIVAL_TIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.Callsign)
                    .IsRequired()
                    .HasColumnName("CALLSIGN")
                    .HasMaxLength(10);

                entity.Property(e => e.Departure)
                    .HasColumnName("DEPARTURE")
                    .HasMaxLength(128);

                entity.Property(e => e.DepartureFlag).HasColumnName("DEPARTURE_FLAG");

                entity.Property(e => e.DeptTma)
                    .HasColumnName("DEPT_TMA")
                    .HasMaxLength(10);

                entity.Property(e => e.DestTma)
                    .HasColumnName("DEST_TMA")
                    .HasMaxLength(10);

                entity.Property(e => e.DestinationFlag).HasColumnName("DESTINATION_FLAG");

                entity.Property(e => e.DirectDistance).HasColumnName("DIRECT_DISTANCE");

                entity.Property(e => e.EndRadian).HasColumnName("END_RADIAN");

                entity.Property(e => e.FirstAchievedDistance).HasColumnName("FIRST_ACHIEVED_DISTANCE");

                entity.Property(e => e.FirstActualDistance).HasColumnName("FIRST_ACTUAL_DISTANCE");

                entity.Property(e => e.FirstEnrDistance).HasColumnName("FIRST_ENR_DISTANCE");

                entity.Property(e => e.FirstEnrTime)
                    .HasColumnName("FIRST_ENR_TIME")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.FirstEntAppDuration)
                    .HasColumnName("FIRST_ENT_APP_DURATION")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.FirstEntLat).HasColumnName("FIRST_ENT_LAT");

                entity.Property(e => e.FirstEntLevel)
                    .HasColumnName("FIRST_ENT_LEVEL")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FirstEntLon).HasColumnName("FIRST_ENT_LON");

                entity.Property(e => e.FirstEntRefRadian).HasColumnName("FIRST_ENT_REF_RADIAN");

                entity.Property(e => e.FirstEntTime)
                    .HasColumnName("FIRST_ENT_TIME")
                    .HasColumnType("timestamp");

                entity.Property(e => e.FirstEntX).HasColumnName("FIRST_ENT_X");

                entity.Property(e => e.FirstEntY).HasColumnName("FIRST_ENT_Y");

                entity.Property(e => e.FirstEntryRadian).HasColumnName("FIRST_ENTRY_RADIAN");

                entity.Property(e => e.FirstEntrySector)
                    .HasColumnName("FIRST_ENTRY_SECTOR")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FirstExitLat).HasColumnName("FIRST_EXIT_LAT");

                entity.Property(e => e.FirstExitLevel)
                    .HasColumnName("FIRST_EXIT_LEVEL")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FirstExitLon).HasColumnName("FIRST_EXIT_LON");

                entity.Property(e => e.FirstExitTime)
                    .HasColumnName("FIRST_EXIT_TIME")
                    .HasColumnType("timestamp");

                entity.Property(e => e.FirstExitX).HasColumnName("FIRST_EXIT_X");

                entity.Property(e => e.FirstExitY).HasColumnName("FIRST_EXIT_Y");

                entity.Property(e => e.FirstLat).HasColumnName("FIRST_LAT");

                entity.Property(e => e.FirstLevel)
                    .HasColumnName("FIRST_LEVEL")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FirstLon).HasColumnName("FIRST_LON");

                entity.Property(e => e.FirstRefRadian).HasColumnName("FIRST_REF_RADIAN");

                entity.Property(e => e.FirstTime)
                    .HasColumnName("FIRST_TIME")
                    .HasColumnType("timestamp");

                entity.Property(e => e.FirstTravelTime)
                    .HasColumnName("FIRST_TRAVEL_TIME")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.FirstX).HasColumnName("FIRST_X");

                entity.Property(e => e.FirstY).HasColumnName("FIRST_Y");

                entity.Property(e => e.FlightRule)
                    .HasColumnName("FLIGHT_RULE")
                    .HasMaxLength(20);

                entity.Property(e => e.FlightType)
                    .HasColumnName("FLIGHT_TYPE")
                    .HasColumnType("int(1)");

                entity.Property(e => e.FlightplanId)
                    .HasColumnName("FLIGHTPLAN_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Kpi05A1).HasColumnName("KPI05_A1");

                entity.Property(e => e.Kpi05A2).HasColumnName("KPI05_A2");

                entity.Property(e => e.Kpi05B1).HasColumnName("KPI05_B1");

                entity.Property(e => e.Kpi05B2).HasColumnName("KPI05_B2");

                entity.Property(e => e.LastLat).HasColumnName("LAST_LAT");

                entity.Property(e => e.LastLevel)
                    .HasColumnName("LAST_LEVEL")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LastLon).HasColumnName("LAST_LON");

                entity.Property(e => e.LastTime)
                    .HasColumnName("LAST_TIME")
                    .HasColumnType("timestamp");

                entity.Property(e => e.LastX).HasColumnName("LAST_X");

                entity.Property(e => e.LastY).HasColumnName("LAST_Y");

                entity.Property(e => e.MaxLevel)
                    .HasColumnName("MAX_LEVEL")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RunwayHeading)
                    .HasColumnName("RUNWAY_HEADING")
                    .HasMaxLength(2);

                entity.Property(e => e.SecondAchievedDistance).HasColumnName("SECOND_ACHIEVED_DISTANCE");

                entity.Property(e => e.SecondActualDistance).HasColumnName("SECOND_ACTUAL_DISTANCE");

                entity.Property(e => e.SecondEnrDistance).HasColumnName("SECOND_ENR_DISTANCE");

                entity.Property(e => e.SecondEnrTime)
                    .HasColumnName("SECOND_ENR_TIME")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.SecondEntAppDuration)
                    .HasColumnName("SECOND_ENT_APP_DURATION")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.SecondEntLat).HasColumnName("SECOND_ENT_LAT");

                entity.Property(e => e.SecondEntLevel)
                    .HasColumnName("SECOND_ENT_LEVEL")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SecondEntLon).HasColumnName("SECOND_ENT_LON");

                entity.Property(e => e.SecondEntRefRadian).HasColumnName("SECOND_ENT_REF_RADIAN");

                entity.Property(e => e.SecondEntTime)
                    .HasColumnName("SECOND_ENT_TIME")
                    .HasColumnType("timestamp");

                entity.Property(e => e.SecondEntX).HasColumnName("SECOND_ENT_X");

                entity.Property(e => e.SecondEntY).HasColumnName("SECOND_ENT_Y");

                entity.Property(e => e.SecondEntryRadian).HasColumnName("SECOND_ENTRY_RADIAN");

                entity.Property(e => e.SecondEntrySector)
                    .HasColumnName("SECOND_ENTRY_SECTOR")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SecondTravelTime)
                    .HasColumnName("SECOND_TRAVEL_TIME")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Squawk)
                    .IsRequired()
                    .HasColumnName("SQUAWK")
                    .HasMaxLength(4);

                entity.Property(e => e.StartRadian).HasColumnName("START_RADIAN");

                entity.Property(e => e.StateEntLat).HasColumnName("STATE_ENT_LAT");

                entity.Property(e => e.StateEntLevel)
                    .HasColumnName("STATE_ENT_LEVEL")
                    .HasColumnType("int(11)");

                entity.Property(e => e.StateEntLon).HasColumnName("STATE_ENT_LON");

                entity.Property(e => e.StateEntX).HasColumnName("STATE_ENT_X");

                entity.Property(e => e.StateEntY).HasColumnName("STATE_ENT_Y");

                entity.Property(e => e.StateExitLat).HasColumnName("STATE_EXIT_LAT");

                entity.Property(e => e.StateExitLevel)
                    .HasColumnName("STATE_EXIT_LEVEL")
                    .HasColumnType("int(11)");

                entity.Property(e => e.StateExitLon).HasColumnName("STATE_EXIT_LON");

                entity.Property(e => e.StateExitX).HasColumnName("STATE_EXIT_X");

                entity.Property(e => e.StateExitY).HasColumnName("STATE_EXIT_Y");

                entity.Property(e => e.Tagname)
                    .HasColumnName("TAGNAME")
                    .HasMaxLength(20);

                entity.Property(e => e.UnknownFlag).HasColumnName("UNKNOWN_FLAG");

                entity.Property(e => e.Waypoints)
                    .HasColumnName("WAYPOINTS")
                    .HasMaxLength(4096);
            });

            modelBuilder.Entity<GroupProfile>(entity =>
            {
                entity.ToTable("GROUP_PROFILE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateFrom)
                    .HasColumnName("DATE_FROM")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateTo)
                    .HasColumnName("DATE_TO")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(45);

                entity.Property(e => e.Status).HasColumnType("bit(2)");
            });

            modelBuilder.Entity<GroupStatistic>(entity =>
            {
                entity.ToTable("GROUP_STATISTIC");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Aircraft)
                    .HasColumnName("AIRCRAFT")
                    .HasMaxLength(10);

                entity.Property(e => e.Arrival)
                    .HasColumnName("ARRIVAL")
                    .HasMaxLength(4);

                entity.Property(e => e.Avg)
                    .HasColumnName("AVG")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Max)
                    .HasColumnName("MAX")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Min)
                    .HasColumnName("MIN")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.P15).HasColumnType("bigint(20)");

                entity.Property(e => e.P20).HasColumnType("bigint(20)");

                entity.Property(e => e.P80).HasColumnType("bigint(20)");

                entity.Property(e => e.P85).HasColumnType("bigint(20)");

                entity.Property(e => e.Predict)
                    .HasColumnName("PREDICT")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.ProfileId)
                    .HasColumnName("PROFILE_ID")
                    .HasColumnType("int(10)");

                entity.Property(e => e.RunwayHeading)
                    .HasColumnName("RUNWAY_HEADING")
                    .HasMaxLength(2);

                entity.Property(e => e.SecondEntrySector)
                    .HasColumnName("SECOND_ENTRY_SECTOR")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<RunwayHeading>(entity =>
            {
                entity.ToTable("RUNWAY_HEADING");

                entity.HasIndex(e => e.AirportId)
                    .HasName("fk_AirportID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AirportId).HasColumnName("AIRPORT_ID");

                entity.Property(e => e.Elevation).HasColumnName("ELEVATION");

                entity.Property(e => e.Heading).HasColumnName("HEADING");

                entity.Property(e => e.Latitude).HasColumnName("LATITUDE");

                entity.Property(e => e.Longitude).HasColumnName("LONGITUDE");

                entity.Property(e => e.Sign)
                    .IsRequired()
                    .HasColumnName("SIGN")
                    .HasMaxLength(5);

                entity.HasOne(d => d.Airport)
                    .WithMany(p => p.RunwayHeading)
                    .HasForeignKey(d => d.AirportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_AirportID");
            });
        }
    }
}
