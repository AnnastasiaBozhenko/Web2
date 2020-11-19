using Common.Models;
using System;
using System.Collections.Generic;

namespace SocketClient.EventArgumentss
{
    public class TimerElapsedEventArgs : EventArgs
    {
        public TimerElapsedEventArgs(List<User> user, DateTime timerStartedAt)
        {
            User = user;
            TimerStartedAt = timerStartedAt;
        }

        public List<User> User { get; set; }
        public DateTime TimerStartedAt { get; set; }
    }
}
