using System;
using System.Collections.Generic;

namespace ATSEFAPI.DBModels
{
    public partial class Flightplan
    {
        public uint Id { get; set; }
        public int? FdmsId { get; set; }
        public string Squawk { get; set; }
        public string Callsign { get; set; }
        public string Aircraft { get; set; }
        public string AlternateAerodrome { get; set; }
        public string AlternateAerodrome2 { get; set; }
        public DateTime? Ata { get; set; }
        public DateTime? Atd { get; set; }
        public string Comnav { get; set; }
        public string DepartureAerodrome { get; set; }
        public DateTime? DepartureDate { get; set; }
        public string DestinationAerodrome { get; set; }
        public DateTime? Eet { get; set; }
        public string Equipment { get; set; }
        public DateTime? Eta { get; set; }
        public DateTime? Etd { get; set; }
        public string Fix { get; set; }
        public string FlightplanType { get; set; }
        public int? FlightType { get; set; }
        public DateTime? InboundTime { get; set; }
        public string Item18 { get; set; }
        public string Level { get; set; }
        public DateTime? OutboundTime { get; set; }
        public string RegistrationNumber { get; set; }
        public string Route { get; set; }
        public string Rule { get; set; }
        public string Speed { get; set; }
        public string WakeTurbulence { get; set; }
        public sbyte? Cancelled { get; set; }
        public sbyte? Changed { get; set; }
        public sbyte? FlightDelayed { get; set; }
        public double? InboundX { get; set; }
        public double? InboundY { get; set; }
        public double? InboundLat { get; set; }
        public double? InboundLon { get; set; }
        public double? OutboundX { get; set; }
        public double? OutboundY { get; set; }
        public double? OutboundLat { get; set; }
        public double? OutboundLon { get; set; }
        public double? FirstExitX { get; set; }
        public double? FirstExitY { get; set; }
        public double? FirstExitLat { get; set; }
        public double? FirstExitLon { get; set; }
        public double? FirstEntX { get; set; }
        public double? FirstEntY { get; set; }
        public double? FirstEntLat { get; set; }
        public double? FirstEntLon { get; set; }
        public double? SecondEntX { get; set; }
        public double? SecondEntY { get; set; }
        public double? SecondEntLat { get; set; }
        public double? SecondEntLon { get; set; }
        public double? FirstEnrDistance { get; set; }
        public double? SecondEnrDistance { get; set; }
        public double? FirstFlightDistance { get; set; }
        public double? SecondFlightDistance { get; set; }
        public double? FirstAchievedDistance { get; set; }
        public double? SecondAchievedDistance { get; set; }
        public double? Kpi04A1 { get; set; }
        public double? Kpi04A2 { get; set; }
        public double? Kpi04B1 { get; set; }
        public double? Kpi04B2 { get; set; }
    }
}
