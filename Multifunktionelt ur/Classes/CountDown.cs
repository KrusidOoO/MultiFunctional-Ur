using System;
using System.Diagnostics;
using System.Windows.Input;
using System.Windows.Threading;
using Multifunktionelt_ur.Interfaces;
using Multifunktionelt_ur.Classes;

namespace Multifunktionelt_ur.Classes
{
    class CountDown
    {

        public void Counter(DateTime endtime)
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            Stopwatch stopwatch = new Stopwatch();
            MainWindow main = new MainWindow();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_tick3);
            dispatcherTimer.Start();

            void dispatcherTimer_tick3(object sender, EventArgs e)
            {
                DateTime now = DateTime.Now;
                TimeSpan CountingDown = endtime.Subtract(DateTime.Now);
                var str = string.Format("{0}:{1}:{2}", CountingDown.Hours, CountingDown.Minutes, CountingDown.Seconds);
                main.countDown.Text = str;
                //main.CountDownList.Items.Add(str);
                double secondsLeft = (CountingDown - stopwatch.Elapsed).TotalSeconds;
                if (secondsLeft <= 0)
                {
                    dispatcherTimer.Stop();
                    secondsLeft = 0;
                }
                CommandManager.InvalidateRequerySuggested();
            }
        }

    }
}
