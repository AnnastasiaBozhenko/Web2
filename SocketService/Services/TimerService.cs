using Common.ClientHubs;
using Common.Models;
using Microsoft.AspNetCore.SignalR;
using SocketService.Hubs;
using SocketService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SocketService.Services
{
    public class TimerService : ITimerService
    {
        private readonly IHubContext<MessageHub, IMessageHub> hub;
        private object _syncRoot = new object();
        private List<User> users = new List<User>();
        private DateTime startedAt;
        private Timer timer;

        public TimerService(IHubContext<MessageHub, IMessageHub> hub)
        {
            this.hub = hub;
        }

        public void RegisterUser(string userId)
        {
            lock(_syncRoot)
            {
                if (users.Count == 0)
                {
                    timer = new Timer(Callback, null, TimeSpan.FromSeconds(11), TimeSpan.FromMilliseconds(-1));
                    startedAt = DateTime.Now;
                }
                users.Add(new User() { UserName = userId, ConnectedAt = DateTime.Now });
            }
        }

        private void Callback(object state)
        {
            hub.Clients.All.TimerElapsed(users, startedAt);
        }
    }
}
