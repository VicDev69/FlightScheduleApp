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
                        flights = CreateFlights(fname);
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

        private List<Flight> CreateFlights(string fname)
        {
            throw new NotImplementedException();
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
                    Flight flight;
                    while ((line = sr.ReadLine()) != null)// && rowCount < 6)
                    {
                        if (rowCount % 2 == 1)
                        {

                            string[] cols = line.Split('\t');
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
                    new XElement("Airline", flight.Airline),
                    new XElement("FlightNumber", flight.FlightNumber),
                    new XElement("CommercialFlightNumber", flight.CommercialFlightNumber),
                    new XElement("From", flight.From),
                    new XElement("To", flight.To),
                    new XElement("STD", flight.STD),
                    new XElement("STA", flight.STA),
                    new XElement("MaxPax", flight.MaxPax),
                    new XElement("MaxCargo", flight.MaxCargo),
                    new XElement("Repetative", flight.Repetative),
                    new XElement("IsMaster", flight.IsMaster),
                    new XElement("BeginDate", flight.BeginDate),
                    new XElement("EndDate", flight.EndDate),
                    new XElement("Days", flight.Days),
                    new XElement("Payload", flight.Payload)
                    )));
            xDoc.Save(@"C:\Users\vicgr\source\repos\FlightScheduleApp\FlightScheduleApp\Demo.xml");
        }

        private void BntClose_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
