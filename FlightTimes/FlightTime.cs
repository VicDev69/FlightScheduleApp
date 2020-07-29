using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace FlightTimes
{
    public struct FlightTime : IEquatable<FlightTime>
    {
      public FlightTime(int hour, int minute)
        {
            Hour = hour;
            Minute = minute;
        }

        public int Hour { get; }
        public int Minute { get; }

        public override bool Equals(object obj)
            => obj is FlightTime time && Equals(time);

        public bool Equals(FlightTime other) 
            =>(Hour,Minute)== (other.Hour, other.Minute);

        public override int GetHashCode()
            => (Hour, Minute).GetHashCode();

        public override string ToString()
            => string.Format("{0:00}:{1:00}", Hour, Minute);


        public static bool operator ==(FlightTime left, FlightTime right)
            => left.Equals(right);
       

        public static bool operator !=(FlightTime left, FlightTime right)
            => !(left == right);

        public static bool operator > (FlightTime depTime, FlightTime arrTime)
        {
            bool status = false;
            if(depTime.Hour > arrTime.Hour && depTime.Minute > arrTime.Minute)
            {
                status = true;
            }
            return status;
        }

        public static bool operator <(FlightTime depTime, FlightTime arrTime)
        {
            bool status = false;
            if (depTime.Hour < arrTime.Hour && depTime.Minute < arrTime.Minute)
            {
                status = true;
            }
            return status;
        }
    }
}
