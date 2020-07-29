using System.Globalization;

namespace FlightTimes
{
    public class Flight
    {
        public Flight()
        {
        }

        public Flight(string airline, ushort flightNumber, string commercialFlightNumber, 
            string from, string to, string aircraft, string aircraftType, 
            string aircraftATCType, string sTD, string sTA, int maxPax, int maxCargo, 
            int randomPayload, int repetative, int isMaster, string beginDate, 
            string endDate, uint days, int adults, int females, int children, int infants, 
            int baggage, int cargo, int payload)
        {
            Airline = airline;
            FlightNumber = flightNumber;
            CommercialFlightNumber = commercialFlightNumber;
            From = from;
            To = to;
            Aircraft = aircraft;
            AircraftType = aircraftType;
            AircraftATCType = aircraftATCType;
            STD = sTD;
            STA = sTA;
            MaxPax = maxPax;
            MaxCargo = maxCargo;
            RandomPayload = randomPayload;
            Repetative = repetative;
            IsMaster = isMaster;
            BeginDate = beginDate;
            EndDate = endDate;
            Days = days;
            Adults = adults;
            Females = females;
            Children = children;
            Infants = infants;
            Baggage = baggage;
            Cargo = cargo;
            Payload = payload;
        }

        public string Airline { get; set; }
        public ushort FlightNumber { get; set; }
        public string CommercialFlightNumber { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Aircraft { get; set; }
        public string AircraftType { get; set; }
        public string AircraftATCType { get; set; }
        public string STD { get; set; }
        public string STA { get; set; }
        public int MaxPax { get; set; }
        public int MaxCargo { get; set; }
        public int RandomPayload { get; set; }
        public int Repetative { get; set; }
        public int IsMaster { get; set; }
        public string BeginDate { get; set; }
        public string EndDate { get; set; }
        public uint Days { get; set; }
        public int Adults { get; set; }
        public int Females { get; set; }
        public int Children { get; set; }
        public int Infants { get; set; }
        public int Baggage { get; set; }
        public int Cargo { get; set; }
        public int Payload { get; set; }

    }
}
