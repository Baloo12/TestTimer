using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTimer.Model
{
    public class TTimer
    {
        #region Fields

        private int _totalSeconds;
        private readonly int _maxSecondsValue = 24*60*60;

        #endregion

        #region Constructors

        public TTimer() { }

        public TTimer(int maxSecondsValue)
        {
            _maxSecondsValue = maxSecondsValue;
        }

        #endregion

        #region Properties
        public int TotalSeconds
        {
            get { return _totalSeconds; }
            private set
            {
                if (0 <= value && value <= _maxSecondsValue)
                    _totalSeconds = value;
                else
                {
                    if (0 < value) _totalSeconds = 0;
                    if (value > _maxSecondsValue) _totalSeconds = _maxSecondsValue;
                    throw new InvalidOperationException(string.Format("Value is out of range. Total seconds number should be between 0 and {0}", _maxSecondsValue));
                }
            }
        }

        public DateTime Time
        {
            get { return DateTime.MinValue + TimeSpan.FromSeconds(_totalSeconds); }
        }

        public string TimeString
        {
            get { return Time.ToString("HH:mm:ss"); }
        }

        #endregion

        #region Methods

        public void Tick(int step)
        {
            try
            {
                TotalSeconds += step;
            }
            catch (InvalidOperationException) { }
        }

        public void SetTime(int seconds, bool throwException = false)
        {
            try
            {
                TotalSeconds = seconds;
            }
            catch (InvalidOperationException)
            {
                if (throwException)
                    throw;
            }
        }

        public void SetTime(string secondsString, bool throwException = false)
        {
            int seconds = 0;
            if (int.TryParse(secondsString, out seconds))
            {
                try
                {
                    TotalSeconds = seconds;
                }
                catch (InvalidOperationException)
                {
                    if (throwException)
                        throw;
                }
            }
            else
                throw new InvalidCastException("Invalid time format. Please enter number of seconds between 0 and 72000");
        }

        #endregion
    }
}
