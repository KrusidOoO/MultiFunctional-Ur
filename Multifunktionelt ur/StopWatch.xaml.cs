using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Multifunktionelt_ur
{
    /// <summary>
    /// Interaction logic for StopWatch.xaml
    /// </summary>
    public partial class StopWatch : Window
    {
        Stopwatch stopwatch = new Stopwatch();
        public StopWatch()
        {
            InitializeComponent();

            stopStopWatch.Visibility = Visibility.Hidden;
            lap.Visibility = Visibility.Hidden;
            startStopWatch.Visibility = Visibility.Visible;
            reset.Visibility = Visibility.Hidden;
            DispatcherTimer dispatchertimer = new DispatcherTimer();
            dispatchertimer.Tick += new EventHandler(dispatchertimer_tick);
            dispatchertimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            dispatchertimer.Start();

            void dispatchertimer_tick(object sender, EventArgs e)
            {
                Watch.Text =stopwatch.Elapsed.ToString();
                CommandManager.InvalidateRequerySuggested();
            }
        }
        private void StartStopWatch_Click(object sender, RoutedEventArgs e)
        {
            stopStopWatch.Visibility = Visibility.Visible;
            lap.Visibility = Visibility.Visible;
            startStopWatch.Visibility = Visibility.Hidden;
            reset.Visibility = Visibility.Hidden;
            stopwatch.Start();
        }
        private void StopStopWatch_Click(object sender, RoutedEventArgs e)
        {
            stopwatch.Stop();
            startStopWatch.Visibility = Visibility.Visible;
            reset.Visibility = Visibility.Visible;
            lap.Visibility = Visibility.Hidden;
        }

        private void Lap_Click(object sender, RoutedEventArgs e)
        {
            lapsListBox.Items.Add("Omgang " + lapsListBox.Items.Count.ToString() + ": " + Watch.Text.Remove(10,5));
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            stopwatch.Reset();
            for(int i=lapsListBox.Items.Count-1;i>=0;i--)
            {
                string removeItems = "00";
                if(lapsListBox.Items[i].ToString().Contains(removeItems))
                {
                    lapsListBox.Items.RemoveAt(i);
                }
            }
            reset.Visibility = Visibility.Hidden;
            stopStopWatch.Visibility = Visibility.Hidden;
            
        }
    }
}
