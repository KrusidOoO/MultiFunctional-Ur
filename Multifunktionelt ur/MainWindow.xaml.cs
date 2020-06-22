using Multifunktionelt_ur.Classes;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace Multifunktionelt_ur
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Stopwatch stopwatch = new Stopwatch();



        public MainWindow()
        {

            InitializeComponent();
            stopStopWatch.Visibility = Visibility.Hidden;
            lap.Visibility = Visibility.Hidden;
            startStopWatch.Visibility = Visibility.Visible;
            reset.Visibility = Visibility.Hidden;
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            DispatcherTimer dispatcherTimer2 = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_tick);
            dispatcherTimer2.Tick += new EventHandler(dispatcherTimer2_tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer2.Interval = new TimeSpan(0, 0, 0, 0, 1);

            dispatcherTimer.Start();
            dispatcherTimer2.Start();
            void dispatcherTimer_tick(object sender, EventArgs e)
            {
                DateTime now = DateTime.Now;
                Watch.Text = "Klokken er:\n" + now.ToString("HH:mm:ss");
                Watch2.Text = now.ToString("HH:mm:ss");
                CommandManager.InvalidateRequerySuggested();
            }
            void dispatcherTimer2_tick(object sender, EventArgs e)
            {
                stopWatch.Text = stopwatch.Elapsed.ToString();
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
            lapsListBox.Items.Add("Omgang " + lapsListBox.Items.Count.ToString() + ": " + stopWatch.Text.Remove(10, 5));
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            stopwatch.Reset();
            for (int i = lapsListBox.Items.Count - 1; i >= 0; i--)
            {
                string removeItems = "00";
                if (lapsListBox.Items[i].ToString().Contains(removeItems))
                {
                    lapsListBox.Items.RemoveAt(i);
                }
            }
            reset.Visibility = Visibility.Hidden;
            stopStopWatch.Visibility = Visibility.Hidden;

        }

        private void CountDownButton_Click(object sender, RoutedEventArgs e)
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 1,0);
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_tick3);
            dispatcherTimer.Start();
            if(!countDown.Text.Contains("00:00:00")&&!dispatcherTimer.IsEnabled)
            {
                dispatcherTimer.Start();
            }
        }
        void dispatcherTimer_tick3(object sender, EventArgs e)
        {
            DateTime endtime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(HourInput.Text), Convert.ToInt32(MinuteInput.Text), Convert.ToInt32(SecondInput.Text));
            TimeSpan CountingDown = endtime.Subtract(DateTime.Now);
            var str = string.Format("{0}:{1}:{2}", CountingDown.Hours, CountingDown.Minutes, CountingDown.Seconds);
            countDown.Text = str;
            CommandManager.InvalidateRequerySuggested();
        }

        private void AddAlarmButton_Click(object sender, RoutedEventArgs e)
        {
            var yeet = (HoursList.SelectedItem as ListBoxItem).Content; 
            var lmao = (MinutesList.SelectedItem as ListBoxItem).Content;
            var input = yeet + " : " + lmao + " \n" + AlarmDescription.Text;
            AlarmsListBox.Items.Add(input);
        }

        private void EditSaveAlarmButton_Click(object sender, RoutedEventArgs e)
        {
            string selectedAlarm;
            int indexOf = AlarmsListBox.SelectedIndex;
            selectedAlarm = (HoursList.SelectedItem as ListBoxItem).Content + " : " + (MinutesList.SelectedItem as ListBoxItem).Content + "\n" + AlarmDescription.Text;
            AlarmsListBox.Items[AlarmsListBox.SelectedIndex] = selectedAlarm;
        }

        private void DeleteAlarmButton_Click(object sender, RoutedEventArgs e)
        {
            AlarmsListBox.Items.RemoveAt(AlarmsListBox.SelectedIndex);
        }
    }
}
