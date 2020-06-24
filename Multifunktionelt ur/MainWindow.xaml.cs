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
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        DispatcherTimer dispatcherTimer3 = new DispatcherTimer();


        public MainWindow()
        {
            TimeCalculation TC = new TimeCalculation(Watch.Text);

            InitializeComponent();
            stopStopWatch.Visibility = Visibility.Hidden;
            addLap.Visibility = Visibility.Hidden;
            startStopWatch.Visibility = Visibility.Visible;
            reset.Visibility = Visibility.Hidden;
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 1, 0);

            dispatcherTimer3.Interval = new TimeSpan(0, 0, 0, 1, 0);
            dispatcherTimer3.Tick += new EventHandler(dispatcherTimer_tick3);

            dispatcherTimer.Start();

            void dispatcherTimer_tick(object sender, EventArgs e)
            {
                DateTime now = DateTime.Now;
                Watch.Text = "Klokken er:\n" + now.ToString("HH:mm:ss");
                Watch2.Text = now.ToString("HH:mm:ss");
                CommandManager.InvalidateRequerySuggested();
            }

        }
        #region Stopwatch
        private void StartStopWatch_Click(object sender, RoutedEventArgs e)
        {
            stopStopWatch.Visibility = Visibility.Visible;
            addLap.Visibility = Visibility.Visible;
            startStopWatch.Visibility = Visibility.Hidden;
            reset.Visibility = Visibility.Hidden;
            stopwatch.Start();
            stopWatch.Text = stopwatch.Elapsed.TotalHours.ToString() + " : " + stopwatch.Elapsed.TotalMinutes.ToString() + " : " + stopwatch.Elapsed.TotalSeconds.ToString();
        }
        private void StopStopWatch_Click(object sender, RoutedEventArgs e)
        {
            stopwatch.Stop();
            startStopWatch.Visibility = Visibility.Visible;
            reset.Visibility = Visibility.Visible;
            addLap.Visibility = Visibility.Hidden;
        }

        private void AddLap_Click(object sender, RoutedEventArgs e)
        {
            lapsListBox.Items.Add("Omgang " + (lapsListBox.Items.Count + 1).ToString() + ": " + stopWatch.Text.Remove(10, 5));
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
        #endregion

        #region Countdown
        private void CountDownButton_Click(object sender, RoutedEventArgs e)
        {
            dispatcherTimer3.Start();
        }
        void dispatcherTimer_tick3(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            DateTime endtime = new DateTime(now.Year, now.Month, now.Day, Convert.ToInt32(HourInput.Text), Convert.ToInt32(MinuteInput.Text), Convert.ToInt32(SecondInput.Text));
            TimeSpan CountingDown = endtime.Subtract(DateTime.Now);
            var str = string.Format("{0}:{1}:{2}", CountingDown.Hours, CountingDown.Minutes, CountingDown.Seconds);
            countDown.Text = str;
            CountDownList.Items.Add(str);
            double secondsLeft = (CountingDown - stopwatch.Elapsed).TotalSeconds;
            if (secondsLeft <= 0)
            {
                MessageBox.Show("Det er nu, det er nu");
                dispatcherTimer3.Stop();
                secondsLeft = 0;
            }
            CommandManager.InvalidateRequerySuggested();
        }
        #endregion

        #region Alarm
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
        #endregion
    }
}
