using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Multifunktionelt_ur.Classes
{
    public class TimeCalculation
    {
        readonly DispatcherTimer timer = new DispatcherTimer();
        
        public void StartTimer(string output)
        {
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0,0,0,1);
            void timer_Tick(object sender, EventArgs e)
            {
                DateTime now = DateTime.Now;
                output = now.ToString("HH:mm:ss");
                CommandManager.InvalidateRequerySuggested();
            }
        }
    }
}
