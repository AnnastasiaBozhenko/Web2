using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.ClientHubs
{
    public interface IMessageHub
    {
        Task TimerElapsed(List<User> user, DateTime timerStartedAt);
        Task Register(RegisterRequest request);
    }
}
