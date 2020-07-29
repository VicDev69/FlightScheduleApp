using System.Xml.Serialization;

public class FlightData  {
    
    private string airlineField;
    
    private ushort flightNumberField;
    
    private string commercialFlightNumberField;
    
    private string fromField;
    
    private string toField;
    
    private string aircraftField;
    
    private string aircraftTypeField;
    
    private string aircraftATCTypeField;
    
    private string sTDField;
    
    private string sTAField;
    
    private int maxPaxField;
    
    private short maxCargoField;
    
    private int randomPayloadField;
    
    private int repetativeField;
    
    private int isMasterField;
    
    private string beginDateField;
    
    private string endDateField;
    
    private uint daysField;
    
    private int adultsField;
    
    private int femalesField;
    
    private int childrenField;
    
    private int infantsField;
    
    private int baggageField;
    
    private int baggageFieldSpecified;
    
    private int cargoField;
    
    private int payloadField;

    // Default Constructor declared in case any other constructor is created
    public FlightData()
    {
    }

    /// <remarks/>
    public string Airline {
        get {
            return this.airlineField;
        }
        set {
            this.airlineField = value;
        }
    }
    
    /// <remarks/>
    public ushort FlightNumber {
        get {
            return this.flightNumberField;
        }
        set {
            this.flightNumberField = value;
        }
    }
    
    /// <remarks/>
    public string CommercialFlightNumber {
        get {
            return this.commercialFlightNumberField;
        }
        set {
            this.commercialFlightNumberField = value;
        }
    }
    
    /// <remarks/>
    public string From {
        get {
            return this.fromField;
        }
        set {
            this.fromField = value;
        }
    }
    
    /// <remarks/>
    public string To {
        get {
            return this.toField;
        }
        set {
            this.toField = value;
        }
    }
    
    /// <remarks/>
    public string Aircraft {
        get {
            return this.aircraftField;
        }
        set {
            this.aircraftField = value;
        }
    }
    
    /// <remarks/>
    public string AircraftType {
        get {
            return this.aircraftTypeField;
        }
        set {
            this.aircraftTypeField = value;
        }
    }
    
    /// <remarks/>
    public string AircraftATCType {
        get {
            return this.aircraftATCTypeField;
        }
        set {
            this.aircraftATCTypeField = value;
        }
    }
    
    /// <remarks/>
    public string STD {
        get {
            return this.sTDField;
        }
        set {
            this.sTDField = value;
        }
    }
    
    /// <remarks/>
    public string STA {
        get {
            return this.sTAField;
        }
        set {
            this.sTAField = value;
        }
    }
    
    /// <remarks/>
    public int MaxPax {
        get {
            return this.maxPaxField;
        }
        set {
            this.maxPaxField = value;
        }
    }
    
    /// <remarks/>
    public short MaxCargo {
        get {
            return this.maxCargoField;
        }
        set {
            this.maxCargoField = value;
        }
    }
    
    /// <remarks/>
    public int RandomPayload {
        get {
            return this.randomPayloadField;
        }
        set {
            this.randomPayloadField = value;
        }
    }
    
    /// <remarks/>
    public int Repetative {
        get {
            return this.repetativeField;
        }
        set {
            this.repetativeField = value;
        }
    }
    
    /// <remarks/>
    public int IsMaster {
        get {
            return this.isMasterField;
        }
        set {
            this.isMasterField = value;
        }
    }
    
    /// <remarks/>
    public string BeginDate {
        get {
            return this.beginDateField;
        }
        set {
            this.beginDateField = value;
        }
    }
    
    /// <remarks/>
    public string EndDate {
        get {
            return this.endDateField;
        }
        set {
            this.endDateField = value;
        }
    }
    
    /// <remarks/>
    public uint Days {
        get {
            return this.daysField;
        }
        set {
            this.daysField = value;
        }
    }
    
    /// <remarks/>
    public int Adults {
        get {
            return this.adultsField;
        }
        set {
            this.adultsField = value;
        }
    }
    
    /// <remarks/>
    public int Females {
        get {
            return this.femalesField;
        }
        set {
            this.femalesField = value;
        }
    }
    
    /// <remarks/>
    public int Children {
        get {
            return this.childrenField;
        }
        set {
            this.childrenField = value;
        }
    }
    
    /// <remarks/>
    public int Infants {
        get {
            return this.infantsField;
        }
        set {
            this.infantsField = value;
        }
    }
    
    /// <remarks/>
    public int Baggage {
        get {
            return this.baggageField;
        }
        set {
            this.baggageField = value;
        }
    }
    
    /// <remarks/>
    public int BaggageSpecified {
        get {
            return this.baggageFieldSpecified;
        }
        set {
            this.baggageFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public int Cargo {
        get {
            return this.cargoField;
        }
        set {
            this.cargoField = value;
        }
    }
    
    /// <remarks/>
    public int Payload {
        get {
            return this.payloadField;
        }
        set {
            this.payloadField = value;
        }
    }
}
