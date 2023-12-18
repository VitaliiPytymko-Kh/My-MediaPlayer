using System.Windows;
using System.Windows.Input;

namespace My_MediaPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        void OnMouseDownPlayMedia(object sender, MouseButtonEventArgs args)
        {
            myMediaElement.Play();
            InitializePropertyValues();
        }

        private void InitializePropertyValues()
        {
            myMediaElement.Volume = (double)myMediaElement.Volume;
            myMediaElement.SpeedRatio = (double)myMediaElement.SpeedRatio;
        }

        private void OnMouseDownPauseMedia(object sender, MouseButtonEventArgs args)
        {
            myMediaElement.Pause();
        }

        private void OnMouseDownStopMedia(object sender, MouseButtonEventArgs args)
        {
            myMediaElement?.Stop();
        }

        private void ChangeMediaVolume(object sender, RoutedPropertyChangedEventArgs<double> args)
        {
            myMediaElement.Volume = (double)volumeSlider.Value;
        }

        private void ChangeMediaSpeedRatio(object sender, RoutedPropertyChangedEventArgs<double> args)
        {
            myMediaElement.SpeedRatio = (double)speedRatioSlider.Value;
        }

        private void SeekToMediaPosition(object sender, RoutedPropertyChangedEventArgs<double> args)
        {
            int SliderValue = (int)timelineSlider.Value;
            TimeSpan ts = new TimeSpan(0, 0, 0, 0, SliderValue);
            myMediaElement.Position = ts;
        }

        private void Element_MediaEnded(object sender, RoutedEventArgs e)
        {
            myMediaElement.Stop();
        }

        private void Element_MediaOpened(object sender, RoutedEventArgs e)
        {
            timelineSlider.Maximum = myMediaElement.NaturalDuration.TimeSpan.TotalMilliseconds;
        }
    }
}