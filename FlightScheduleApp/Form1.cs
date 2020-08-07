using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using FlightTimes;
using System.Xml.Linq;
using OfficeOpenXml;

namespace FlightScheduleApp
{
    public partial class Form1 : Form
    {
        DateTime dtBegin;
        DateTime dtEnd;
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnOpenFile_Click(object sender, EventArgs e)
        {
            dtBegin = dtpBegin.Value;
            dtEnd = dtpEnd.Value;

            if (dtEnd.CompareTo(dtBegin) < 0)
            {
                string message = "End date must be greater than begin date.";
                string caption = "Invalid date(s)";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                _ = MessageBox.Show(message, caption, buttons);
                return;
            }

            if (dgfOpenTxt.ShowDialog() == DialogResult.OK)
            {
                string fname = dgfOpenTxt.FileName;
                List<Flight> flights; // = new List<Flight>();
                if (!string.IsNullOrEmpty(fname))
                {
                    string fType = fname.Substring(fname.LastIndexOf('.') + 1);
                    if (fType.Equals("xlsm"))
                    {
                        flights = CreateFlightsFromExcel(fname);
                    }
                    else
                    {

                        //TODO Need to create flights from Excel worksheet
                        // Process the csv file and create n instance of Lcis<flights>
                        flights = CreateFlights(fname, dtBegin, dtEnd);
                    }

                    WriteScheduleXml(flights);
                }
            }
        }

        private List<Flight> CreateFlightsFromExcel(string fName)
        {
            using (var package = new ExcelPackage(new FileInfo(fName)))
            {
                var firstSheet = package.Workbook.Worksheets["First Sheet"];
                var rowCount = firstSheet.Dimension.Rows;
                var colCount = firstSheet.Dimension.Columns;

                // Loop through each row (alternate rows only)
                for (int i = 2; i < rowCount + 1; i += 2)
                {
                    Flight flight = new Flight();
                    // Get the start and end dates for the schedules
                    flight.commercialFlightNumber = firstSheet.Cells[i, 1].Text;

                    string strFlightNumber = "000";
                    int startSub = 2;
                    switch (flight.commercialFlightNumber.Substring(0, 1))
                    {
                        case "M":
                            flight.airline = "ME";
                            startSub = 3;
                            break;
                        default:
                            flight.airline = "FL";
                            startSub = 2;
                            break;

                    }


                    strFlightNumber = string.Format("{0:000}", flight.commercialFlightNumber.Substring(startSub));

                    flight.flightNumber = (ushort)Convert.ToInt16(strFlightNumber);

                    string departing = firstSheet.Cells[i, 2].Text;
                    flight.from = departing.Substring(0, 4);
                    flight.scheduledTimeOfDeparture = GetDate(departing.Substring(6, 4));
                    DateTime tm = DateTime.Parse(flight.scheduledTimeOfDeparture);
                    // TODO use the following code, or similar, to determine the arrival date/time 
                    DateTime tm1 =tm.AddHours(5);
                    DateTime tm2=tm1.AddMinutes(50);
                    string srtm = tm2.ToString("yyyy/MM/dd HH:mm");
                    

                    //string departingTime = departing.Substring(6, 4);
                    string duration = firstSheet.Cells[i, 4].Text;
                    int durationMinutes = Convert.ToInt32(duration.Substring(duration.Length - 2, 2));
                    int durationHours = Convert.ToInt32(duration.Substring(0, duration.Length-3));
                    tm = tm.AddHours(durationHours);
                    tm = tm.AddMinutes(durationMinutes);
                    flight.scheduledTimeOfArrival = tm.ToString("yyyy/MM/dd hh:mm");
                    //TODO split arriving onto ICAO and arrival time
                    string arriving = firstSheet.Cells[i, 5].Text;
                    flight.to = arriving.Substring(0, 4);
                    string arrivingTime = arriving.Substring(6, 4);

                    StringBuilder sb = new StringBuilder();
                    for (int j = 7; j < 14; j++)
                    {
                        string day = firstSheet.Cells[i, j].Text;

                        if (firstSheet.Cells[i, j].Text.Length > 0)
                        {
                            sb.Append(day);
                        }
                    }
                    string daysOfOperaton = sb.ToString();
                    string type = firstSheet.Cells[i, 15].Text;


                }
            }
            return null;

        }

        private string GetDate(string strTime)
        {
            DateTime dt = DateTime.Today;
            string tme = string.Format("{0:00}:{1:00}",strTime.Substring(0,2),
                strTime.Substring(2,2));
            string output = string.Format("{0:yyyy/MM/dd} {1:}",dt,tme);
            return output;
        }

        private List<Flight> CreateFlights(string fname, DateTime dtBegin, DateTime dtEnd)
        {
            List<Flight> flights = new List<Flight>();

            string beginDate = dtBegin.ToString("yyyy/MM/dd HH:mm");
            string endDate = dtEnd.ToString("yyyy/MM/dd HH:mm");

            using (var fs = new FileStream(fname, FileMode.Open, FileAccess.Read))
            {
                using (var sr = new StreamReader(fs, Encoding.UTF8))
                {

                    string line;
                    int rowCount = 0;
                    ;
                    while ((line = sr.ReadLine()) != null)// && rowCount < 6)
                    {
                        if (rowCount % 2 == 1)
                        {
                            Flight flight = new Flight();
                            string[] cols = line.Split('\t');
                            flight.commercialFlightNumber = cols[0];
                            string commercialFlightNumber = cols[0];
                            string airline = "FL";
                            string strFlightNumber = string.Format("{0:000}", cols[0].Substring(2));

                            if (cols[0].Substring(0, 2).Equals("ME"))
                            {
                                airline = "ME";
                                strFlightNumber = string.Format("{0:000}", cols[0].Substring(3));
                            }
                            //fflightAirline = airline;
                            ushort flightNumber = Convert.ToUInt16(strFlightNumber);

                            // Aircraft Type
                            string aircraftType = cols[13];
                            string aircraftATCType = cols[13];


                            // Get FROM and TO
                            string from = cols[1].Substring(0, 4);
                            string to = cols[4].Substring(0, 4);
                            // Departure and arrival time

                            FlightTime depTime = new FlightTime(
                            Convert.ToInt32(cols[1].Substring(6, 2)),
                            Convert.ToInt32(cols[1].Substring(8, 2)));

                            FlightTime arrTime = new FlightTime(
                            Convert.ToInt32(cols[4].Substring(6, 2)),
                            Convert.ToInt32(cols[4].Substring(8, 2)));

                            DateTime depDate = DateTime.Today;
                            DateTime arrDate = depDate;
                            if (depTime > arrTime)
                            {
                                // Add one day to arrival date
                                arrDate = arrDate.AddDays(1.0);
                            }

                            // Format the dates so that they can be stored in STD and STA
                            string std = depDate.ToString("yyyy/MM/dd") + " " + depTime.ToString();
                            string sta = arrDate.ToString("yyyy/MM/dd") + " " + arrTime.ToString();

                            // add the begin date and end date of the schedule
                            string BeginDate = dtBegin.ToString("yyyy/MM/dd HH:mm");
                            string EndDate = dtEnd.ToString("yyyy/MM/dd HH:mm");
                            int randomPayload = 1;
                            int repetative = 1;

                            // Get days of operation
                            uint days = GetDaysOfOperation(cols);
                            int isMaster = 1;
                            int adults = -1;
                            int females = -1;
                            int children = -1;
                            int infants = -1;
                            int baggage = -1;
                            //int baggage = -1;
                            int cargo = -1;
                            int payload = -1;
                            string aircraft = null;


                            // Misc. fields
                            int maxPax = -1;
                            int maxCargo = -1;

                            flight = new Flight(airline, flightNumber, commercialFlightNumber,
                                from, to, aircraft, aircraftType, aircraftATCType, std, sta, maxPax, maxCargo,
                                randomPayload, repetative, isMaster, beginDate, endDate, days, adults, females,
                                children, infants, baggage, cargo, payload);

                            flights.Add(flight);


                        }
                        rowCount++;
                    }
                }
            }
            return flights;
        }

        private uint GetDaysOfOperation(in string[] cols)
        {
            StringBuilder sb = new StringBuilder(7);
            for (int i = 6; i < 13; i++)
            {
                if (!string.IsNullOrEmpty(cols[i]))
                {
                    sb.Append(i - 5);
                }
            }
            return Convert.ToUInt32(sb.ToString());
        }

        private void WriteScheduleXml(List<Flight> flights)
        {
            XDocument xDoc = new XDocument(
                new XElement("PFPX_FLIGHT_LIST",
                    from flight in flights
                    select new XElement("FLIGHT",
                    new XElement("Airline", flight.airline),
                    new XElement("FlightNumber", flight.flightNumber),
                    new XElement("CommercialFlightNumber", flight.commercialFlightNumber),
                    new XElement("From", flight.@from),
                    new XElement("To", flight.to),
                    new XElement("STD", flight.scheduledTimeOfDeparture),
                    new XElement("STA", flight.scheduledTimeOfArrival),
                    new XElement("MaxPax", flight.maxPax),
                    new XElement("MaxCargo", flight.maxCargo),
                    new XElement("Repetative", flight.repetative),
                    new XElement("IsMaster", flight.isMaster),
                    new XElement("BeginDate", flight.beginDate),
                    new XElement("EndDate", flight.endDate),
                    new XElement("Days", flight.days),
                    new XElement("Payload", flight.payload)
                    )));
            xDoc.Save(@"C:\Users\vicgr\source\repos\FlightScheduleApp\FlightScheduleApp\Demo.xml");
        }

        private void BntClose_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
