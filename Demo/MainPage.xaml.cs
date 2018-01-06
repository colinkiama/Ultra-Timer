using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UltraTimer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Demo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Timer myTimer = new Timer();
        string fmt = @"mm\:ss\.fff";
        public MainPage()
        {
            this.InitializeComponent();
            myTimer.TimerTicked += MyTimer_TimerTicked;
            myTimer.TimerReset += MyTimer_TimerReset;
            myTimer.TimerEnded += MyTimer_TimerEnded;
            myTimer.TimerPaused += MyTimer_TimerPaused;
            timeTextBlock.Text = myTimer.TimeLeft.ToString(fmt);
            eventsTextBlock.Text = "No events have occured yet";
        }

        private void MyTimer_TimerPaused(object sender, TimerEventArgs e)
        {
            eventsTextBlock.Text = $"Timer has paused - {DateTime.Now}";
        }

        private void MyTimer_TimerReset(object sender, TimerEventArgs e)
        {
            updateTimeTextBlock();
            eventsTextBlock.Text = $"Timer has been been reset - {DateTime.Now}";
        }

        private void MyTimer_TimerEnded(object sender, TimerEventArgs e)
        {
            updateTimeTextBlock();
            eventsTextBlock.Text = $"Timer has ended - {DateTime.Now}";
        }

        private void MyTimer_TimerTicked(object sender, TimerEventArgs e)
        {
            updateTimeTextBlock();
        }

        private void updateTimeTextBlock()
        {
            timeTextBlock.Text = myTimer.TimeLeft.ToString(fmt);
        }

        private void StartTimerButton_Click(object sender, RoutedEventArgs e)
        {
            myTimer.StartTimer();
        }

        private void PauseTimerButton_Click(object sender, RoutedEventArgs e)
        {
            myTimer.PauseTimer();
        }

        private void RestartTimerButton_Click(object sender, RoutedEventArgs e)
        {
            myTimer.PauseTimer();
            myTimer.ResetTimer();
        }
    }
}
