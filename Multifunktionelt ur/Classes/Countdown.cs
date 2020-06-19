using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multifunktionelt_ur.Classes
{
    public class Countdown
    {
        public void countDown(int hour, int minute, int second)
        {
            
            DateTime endTime = new DateTime(DateTime.Now.Year,DateTime.Now.Month ,DateTime.Now.Day ,hour,minute,second, DateTime.Now.Millisecond);
            TimeSpan CountDown = endTime.Subtract(DateTime.Now);

            string output = CountDown.ToString();
            return output;
        }

    }
}
