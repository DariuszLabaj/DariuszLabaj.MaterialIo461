using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DariuszLabaj.MaterialIo461.CustomUserControl
{
    /// <summary>
    /// Interaction logic for StopTimer.xaml
    /// </summary>
    public partial class StopTimer : UserControl
    {
        private DispatcherTimer _timer;
        private DateTime _startTime;
        private TimeSpan _additionalTime;
        private bool _isRunning;
        #region Dependency Properties
        public static readonly DependencyProperty ElapsedTimeProperty = DependencyProperty.Register(nameof(ElapsedTime), typeof(string), typeof(StopTimer), new PropertyMetadata("00:00:00.0"));
        public string ElapsedTime
        {
            get => (string)GetValue(ElapsedTimeProperty);
            set => SetValue(ElapsedTimeProperty, value);
        }
        public static readonly DependencyProperty ActiveColorProperty = DependencyProperty.Register(nameof(ActiveColor), typeof(SolidColorBrush), typeof(StopTimer), new PropertyMetadata(new SolidColorBrush(Color.FromRgb(0x1f, 0x6e, 0x79))));
        public SolidColorBrush ActiveColor
        {
            get => (SolidColorBrush)GetValue(ActiveColorProperty);
            set => SetValue(ActiveColorProperty, value);
        }
        public static readonly DependencyProperty InactiveColorProperty = DependencyProperty.Register(nameof(InactiveColor), typeof(SolidColorBrush), typeof(StopTimer), new PropertyMetadata(new SolidColorBrush(Color.FromRgb(0x13, 0x2e, 0x34))));
        public SolidColorBrush InactiveColor
        {
            get => (SolidColorBrush)GetValue(InactiveColorProperty);
            set => SetValue(InactiveColorProperty, value);
        }
        public static readonly DependencyProperty FontColorProperty = DependencyProperty.Register(nameof(FontColor), typeof(SolidColorBrush), typeof(StopTimer), new PropertyMetadata(new SolidColorBrush(Color.FromRgb(0x2e, 0xb4, 0xe9))));
        public SolidColorBrush FontColor
        {
            get => (SolidColorBrush)GetValue(FontColorProperty);
            set => SetValue(FontColorProperty, value);
        }
        public static readonly DependencyProperty BinaryCellsProperty = DependencyProperty.Register(nameof(BinaryCells), typeof(ObservableCollection<SolidColorBrush>), typeof(StopTimer), new PropertyMetadata(new ObservableCollection<SolidColorBrush>()));
        public ObservableCollection<SolidColorBrush> BinaryCells
        {
            get => (ObservableCollection<SolidColorBrush>)GetValue(BinaryCellsProperty);
            set => SetValue(BinaryCellsProperty, value);
        }
        #endregion
        public StopTimer()
        {
            _timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(10) };
            InitializeComponent();
            DataContext = this;
            InitializeCells();
        }

        private void InitializeCells()
        {
            BinaryCells = new ObservableCollection<SolidColorBrush>();
            for (int i = 0; i < 24; i++)
            {
                BinaryCells.Add(InactiveColor);
            }
        }
        private void UpdateBinaryDisplay(int value)
        {
            const int noOfCol = 6;
            const int noOfRows = 4;
            for (int i = 0; i < 24; i++)
            {
                int index = ((i % noOfRows) *noOfCol) + (noOfCol - i / noOfRows - 1);
                BinaryCells[index] = ((value >> i) & 1) == 1 ? ActiveColor : InactiveColor;
            }
        }
        private void TimerTick(object sender, EventArgs e)
        {
            TimeSpan elapsed = (DateTime.Now - _startTime) + _additionalTime;
            ElapsedTime = elapsed.ToString(@"hh\:mm\:ss\.f");
            UpdateBinaryDisplay((int)elapsed.TotalMilliseconds/100);
        }
        public void Start()
        {
            if (!_isRunning)
            {
                _startTime = DateTime.Now;
                _timer.Tick += TimerTick;
                _timer.Start();
                _isRunning = true;
            }
        }
        public void Stop()
        {
            _additionalTime = DateTime.Now - _startTime;
            _timer?.Stop();
            _isRunning = false;
        }
        public void Reset()
        {
            ElapsedTime = "00:00:00.0";
            _additionalTime = new TimeSpan();
            _startTime = DateTime.Now;
            UpdateBinaryDisplay(0);
        }
    }
}
