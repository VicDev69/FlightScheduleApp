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
            string aircraftATCType, string scheduledTimeOfDeparture, 
            string scheduledTimeOfArrival, int maxPax, int maxCargo, 
            int randomPayload, int repetative, int isMaster, string beginDate, 
            string endDate, uint days, int adults, int females, int children, int infants, 
            int baggage, int cargo, int payload)
        {
            this.airline = airline;
            this.flightNumber = flightNumber;
            this.commercialFlightNumber = commercialFlightNumber;
            this.from = from;
            this.to = to;
            this.aircraft = aircraft;
            this.aircraftType = aircraftType;
            this.aircraftATCType = aircraftATCType;
            this.scheduledTimeOfDeparture = scheduledTimeOfDeparture;
            this.scheduledTimeOfArrival = scheduledTimeOfArrival;
            this.maxPax = maxPax;
            this.maxCargo = maxCargo;
            this.randomPayload = randomPayload;
            this.repetative = repetative;
            this.isMaster = isMaster;
            this.beginDate = beginDate;
            this.endDate = endDate;
            this.days = days;
            this.adults = adults;
            this.females = females;
            this.children = children;
            this.infants = infants;
            this.baggage = baggage;
            this.cargo = cargo;
            this.payload = payload;
        }

        // Properties
        // Airline is derived from the field that cotains CommercialFlightNumber
        public string airline { get; set; }
        // Flght is derived from the field that cotains CommercialFlightNumber
        public ushort flightNumber { get; set; }
        public string commercialFlightNumber { get; set; }
        // From and To are Substrings from cells from te data source
        public string from { get; set; }
        public string to { get; set; }
        public string aircraft { get; set; }
        public string aircraftType { get; set; }
        public string aircraftATCType { get; set; }
        // Scheduled Time of Departure is derived from the same cells that contain
        // the From data
        public string scheduledTimeOfDeparture { get; set; }
        // Scheduled Time of Arrival is derived from the same cells that contain
        // the To data
        public string scheduledTimeOfArrival { get; set; }
        public int maxPax { get; set; }
        public int maxCargo { get; set; }
        public int randomPayload { get; set; }
        public int repetative { get; set; }
        public int isMaster { get; set; }
        public string beginDate { get; set; }
        public string endDate { get; set; }
        public uint days { get; set; }
        public int adults { get; set; }
        public int females { get; set; }
        public int children { get; set; }
        public int infants { get; set; }
        public int baggage { get; set; }
        public int cargo { get; set; }
        public int payload { get; set; }

        // Methods


    }
}
