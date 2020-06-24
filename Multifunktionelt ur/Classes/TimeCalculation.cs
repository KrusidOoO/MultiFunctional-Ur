using System;
using System.Diagnostics;
using System.Windows.Input;
using System.Windows.Threading;
using Multifunktionelt_ur.Interfaces;
using Multifunktionelt_ur.Classes;

namespace Multifunktionelt_ur.Classes
{
    class TimeCalculation : ITimeConfigurator
    {
        private string first;
        public TimeCalculation(string xx)
        {
            first = xx;
        }

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
            first = timer.ToString();
            sw.Start();
            timer.Start();

        }
        public void Add()
        {

        }

        public void Remove()
        {

        }
    }
}
