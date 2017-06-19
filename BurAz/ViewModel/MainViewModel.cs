using System;
using System.Windows;
using System.Windows.Threading;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace BurAz.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            _dispTimerCounter = time;
            _dispTimer = new DispatcherTimer();
            _dispTimer.Interval = TimeSpan.FromMilliseconds(1000);
            _dispTimer.Tick += new EventHandler(dispTimer_Tick);
        }

        private void dispTimer_Tick(object sender, EventArgs e)
        {
            ABCTimer = (_dispTimerCounter--).ToString();
            if (_dispTimerCounter == 0)
            {
                _dispTimerCounter = time;
            }
        }

        private const int time = 10;

        DispatcherTimer _dispTimer;
        int _dispTimerCounter;

        private string _abcTimer;
        public string ABCTimer
        {
            get { return _abcTimer; }
            set { _abcTimer = value; RaisePropertyChanged(() => ABCTimer); }
        }

        public RelayCommand ABCStart => new RelayCommand(() => _dispTimer.Start());

        public string ABCLetter { get; set; }

        public string ABCTrue { get; set; }

        public string ABCFalse { get; set; }
    }
}