using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using TestTimer.Model;
using System.Windows;

namespace TestTimer.ViewModel
{
    public class TimerVM : INotifyPropertyChanged
    {
        #region Base

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Fields

        private TTimer _inputTTimer;
        private TTimer _tickTTimer;

        private string _inputTimerContent;

        private ICommand _lostFocusCommand;
        private ICommand _gotFocusCommand;

        private bool _editorMode = false;
        private bool _oddSecondTick = true;

        // Only one timer has been used
        private static DispatcherTimer _changeValuesTimer;

        private string _warrningMessage;
        #endregion

        #region Construstors

        public TimerVM()
        {
            _inputTTimer = new TTimer(72000);
            _tickTTimer = new TTimer();

            LostFocusCommand = new RelayCommand(_ => LostFocus());
            GotFocusCommand = new RelayCommand(_ => GotFocus());

            _changeValuesTimer = new DispatcherTimer();
            _changeValuesTimer.Interval = TimeSpan.FromSeconds(1);
            _changeValuesTimer.Tick += (sender, e) => OnTimerTick();
            _changeValuesTimer.Start();
        }

        #endregion

        #region Properties

        public string InputTimerContent
        {
            get
            {
                if (string.IsNullOrEmpty(_warrningMessage))
                    _inputTimerContent = _editorMode ? _inputTTimer.TotalSeconds.ToString() : _inputTTimer.TimeString;
                return _inputTimerContent;
            }
            set
            {
                _inputTimerContent = value;
                WarrningMessage = string.Empty;
                try
                {
                    _inputTTimer.SetTime(value, true);
                }
                catch (Exception ex)
                {
                    if (ex is InvalidCastException || ex is InvalidOperationException)
                    {
                        WarrningMessage = ex.Message;
                    }
                    else
                        throw;
                }
                OnPropertyChanged();
            }
        }

        public string OddTimerContent
        {
            get { return _tickTTimer.TimeString; }
            set { OnPropertyChanged(); }
        }

        public string EvenTimerContent
        {
            get { return _tickTTimer.TimeString; }
            set { OnPropertyChanged(); }
        }

        #region Warnings

        public string WarrningMessage
        {
            get { return string.Format("Warrning: {0}", _warrningMessage); }
            set
            {
                _warrningMessage = value;
                OnPropertyChanged();
                OnPropertyChanged("IsWarrningVisible");
            }
        }

        public Visibility IsWarrningVisible
        {
            get { return string.IsNullOrEmpty(_warrningMessage) ? Visibility.Collapsed : Visibility.Visible; }
            set { OnPropertyChanged(); }
        }

        #endregion

        #region Commands

        public ICommand LostFocusCommand
        {
            get { return _lostFocusCommand; }
            set { _lostFocusCommand = value; }
        }

        public ICommand GotFocusCommand
        {
            get { return _gotFocusCommand; }
            set { _gotFocusCommand = value; }
        }

        #endregion
        #endregion

        #region Methods

        private void LostFocus()
        {
            _editorMode = false;
            OnPropertyChanged("InputTimerContent");
        }

        private void GotFocus()
        {
            _editorMode = true;
            OnPropertyChanged("InputTimerContent");
        }

        private void OnTimerTick()
        {
            int offset = _editorMode ? -1 : 1;

            _tickTTimer.Tick(offset);

            if (!_editorMode)
            {
                _inputTTimer.Tick(-1);
                OnPropertyChanged("InputTimerContent");
            }


            if (_oddSecondTick)
                OnPropertyChanged("OddTimerContent");
            else
                OnPropertyChanged("EvenTimerContent");
            _oddSecondTick = !_oddSecondTick;
        }

        #endregion
    }
}
