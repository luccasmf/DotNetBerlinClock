using System;
using System.Collections.Generic;
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


                string secondsIndicator = seconds % 2 == 0 ? "Y" : "O";

                var hourCount = hours % 5;

                string hourIndicator1 = (new string('R', ((hours - hourCount) / 5))).PadRight(4, 'O');
                string hourIndicator2 = (new string('R', hourCount)).PadRight(4, 'O');


                string minuteIndicator1 = string.Empty;
                for (int i = 5; i < minutes; i += 5)
                {
                    minuteIndicator1 += i % 3 == 0 ? "R" : "Y";
                }
                minuteIndicator1 = minuteIndicator1.PadRight(11, 'O');
                string minuteIndicator2 = (new string('Y', minutes % 5)).PadRight(4, 'O');

                return string.Format("{0}\r\n{1}\r\n{2}\r\n{3}\r\n{4}", secondsIndicator, hourIndicator1, hourIndicator2, minuteIndicator1, minuteIndicator2);
            }
            catch
            {
                return "Not a valid time format.";
            }
        }
    }
}
