using BerlinClock.Classes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        public string convertTime(string aTime)
        {
            try
            {
                string[] timeParts = aTime.Split(':');

                int hours = int.Parse(timeParts[0]);
                int minutes = int.Parse(timeParts[1]);
                int seconds = int.Parse(timeParts[2]);

                if (hours > 24 || minutes > 59 || seconds > 59)
                    throw new Exception();

                BerlinUhr clock = new BerlinUhr();

                clock.Hour = hours.ToString();
                clock.Minute = minutes.ToString();
                clock.Seconds = seconds.ToString();

                return clock.ToString();
            }
            catch
            {
                return "Invalid time format.";
            }
        }
    }
}
