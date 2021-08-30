using System;
using System.Windows.Threading;

namespace WpfExtensions.TimerExtension
{
    public class Timer
    {
        private readonly DispatcherTimer _timer = new DispatcherTimer();
        private int _interval;

        public int Interval
        {
            get { return _interval; }
            set
            {
                if (value < 1) value = 1;
                _interval = value;
            }
        }

        public int TimeLeft { get; private set; }
        public bool IsTimerStarted { get; private set; } = false;
        public bool IsRepeated { get; set; } = false;
        public Action TimerStopped { get; set; }

        private void TimerTick(object sender, EventArgs e)
        {
            if (TimeLeft <= 0)
            {
                TimerStopped?.Invoke();
                if (IsRepeated) StartTimer();
                else StopTimer();
            }
            else
            {
                TimeLeft--;
            }
        }

        public void StartTimer()
        {
            TimeLeft = Interval;
            _timer.Start();
            IsTimerStarted = true;
        }
        public void StartTimer(int minutes, int seconds)
        {
            StartTimer(0, minutes, seconds);
        }
        public void StartTimer(int hours, int minutes, int seconds)
        {
            StartTimer();
            Interval = 3600 * hours + 60 * minutes + seconds;
        }
        public void StopTimer()
        {
            IsTimerStarted = false;
            _timer.Stop();
            TimeLeft = Interval;
        }
        public void StopTimer(int minutes, int seconds)
        {
            StopTimer(0, minutes, seconds);
        }
        public void StopTimer(int hours, int minutes, int seconds)
        {
            StopTimer();
            Interval = 3600 * hours + 60 * minutes + seconds;
        }
        public void ResetTime()
        {
            TimeLeft = Interval;
        }

        public Timer() : this(0, 30, () => { }) { }
        public Timer(int minutes, int seconds, Action timerStopped) : this(0, minutes, seconds, timerStopped) { }
        public Timer(int hours, int minutes, int seconds, Action timerStopped) : this(hours, minutes, seconds, false, timerStopped) { }
        public Timer(int minutes, int seconds, bool isRepeated, Action timerStopped) : this(0, minutes, seconds, isRepeated, timerStopped) { }
        public Timer(int hours, int minutes, int seconds, bool isRepeated, Action timerStopped)
        {
            _timer.Tick += new EventHandler(TimerTick);
            _timer.Interval = new TimeSpan(0, 0, 1);
            Interval = 3600 * hours + 60 * minutes + seconds;
            TimerStopped = timerStopped;
            IsRepeated = isRepeated;
        }
    }
}
