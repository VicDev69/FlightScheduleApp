using System.Xml.Serialization;

public class FlightData
{
    // Default Constructor declared in case any other constructor is created
    public FlightData()
    {
    }

    // Properties 
    /// <remarks/>
    public string Airline { get; set; }

    /// <remarks/>
    public ushort FlightNumber { get; set; }

    /// <remarks/>
    public string CommercialFlightNumber { get; set; }

    /// <remarks/>
    public string From { get; set; }

    /// <remarks/>
    public string To { get; set; }

    /// <remarks/>
    public string Aircraft { get; set; }

    /// <remarks/>
    public string AircraftType { get; set; }

    /// <remarks/>
    public string AircraftATCType { get; set; }

    /// <remarks/>
    public string STD { get; set; }

    /// <remarks/>
    public string STA { get; set; }

    /// <remarks/>
    public int MaxPax { get; set; }

    /// <remarks/>
    public short MaxCargo { get; set; }

    /// <remarks/>
    public int RandomPayload { get; set; }

    /// <remarks/>
    public int Repetative { get; set; }

    /// <remarks/>
    public int IsMaster { get; set; }

    /// <remarks/>
    public string BeginDate { get; set; }

    /// <remarks/>
    public string EndDate { get; set; }

    /// <remarks/>
    public uint Days { get; set; }

    /// <remarks/>
    public int Adults { get; set; }

    /// <remarks/>
    public int Females { get; set; }

    /// <remarks/>
    public int Children { get; set; }

    /// <remarks/>
    public int Infants { get; set; }

    /// <remarks/>
    public int Baggage { get; set; }

    /// <remarks/>
    public int BaggageSpecified { get; set; }

    /// <remarks/>
    public int Cargo { get; set; }

    /// <remarks/>
    public int Payload { get; set; }
}
