using Multifunktionelt_ur.Classes;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Multifunktionelt_ur.Classes
{
    class TimerProperties
    {
        public void Timer(DateTime time,string input)
        {
            time = DateTime.Now;
            input = "";
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0,1);
            void dispatcherTimer_tick(object sender, EventArgs e)
            {

                CommandManager.InvalidateRequerySuggested();
            }
        }
    }
}
