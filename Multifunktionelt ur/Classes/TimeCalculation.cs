using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Multifunktionelt_ur.Classes
{
    class TimeCalculation
    {
        public void StartTimer()
        {
            TimeSpan total = TimeSpan.FromSeconds(5);
            DispatcherTimer timer = new DispatcherTimer();
            Stopwatch sw = new Stopwatch();

            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += (sender, e) =>
            {
                double secondsLeft = (total - sw.Elapsed).TotalSeconds;

                if (secondsLeft <= 0)
                {
                    timer.Stop();
                    secondsLeft = 0;
                }

                
            };

            sw.Start();
            timer.Start();
        
        }
    }
}
