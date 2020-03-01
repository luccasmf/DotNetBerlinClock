using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Classes
{
    public class BerlinUhr
    {
        [MaxLength(1)]
        private string secondsIndicator = string.Empty;
        [MaxLength(4)]
        private string hourIndicator1 = string.Empty;
        [MaxLength(4)]
        private string hourIndicator2 = string.Empty;
        [MaxLength(11)]
        private string minuteIndicator1 = string.Empty;
        [MaxLength(4)]
        private string minuteIndicator2 = string.Empty;

        public string Hour
        {
            get { return string.Format("{0}\r\n{1}", hourIndicator1, hourIndicator2); }
            set
            {
                var hourCount = int.Parse(value) % 5;

                hourIndicator1 = (new string('R', ((int.Parse(value) - hourCount) / 5))).PadRight(4, 'O');
                hourIndicator2 = (new string('R', hourCount)).PadRight(4, 'O');
            }
        }

        public string Minute
        {
            get { return string.Format("{0}\r\n{1}", minuteIndicator1, minuteIndicator2); }
            set
            {
                int minutes = int.Parse(value);

                for (int i = 5; i < minutes; i += 5)
                {
                    minuteIndicator1 += i % 3 == 0 ? "R" : "Y";
                }
                minuteIndicator1 = minuteIndicator1.PadRight(11, 'O');
                minuteIndicator2 = (new string('Y', minutes % 5)).PadRight(4, 'O');
            }
        }

        public string Seconds { get { return secondsIndicator; } set { secondsIndicator = int.Parse(value) % 2 == 0 ? "Y" : "O"; } }


        public string ToString()
        {
            return string.Format("{0}\r\n{1}\r\n{2}", Seconds, Hour, Minute);
        }
    }
}
