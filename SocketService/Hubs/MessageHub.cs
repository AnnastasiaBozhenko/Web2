using Common.ClientHubs;
using Common.Models;
using Microsoft.AspNetCore.SignalR;
using SocketService.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocketService.Hubs
{
    public class MessageHub : Hub<IMessageHub>
    {
        private readonly ITimerService timerService;

        public MessageHub(ITimerService timerService)
        {
            this.timerService = timerService;
        }

        public async Task TimerElapsed(List<User> users, DateTime timerStartedAt)
        {
            await Clients.All.TimerElapsed(users, timerStartedAt);
        }

        public Task Register(RegisterRequest request)
        {
            timerService.RegisterUser(request.Id);
            return Task.CompletedTask;
        }
    }
}