using Common.ClientHubs;
using Common.Models;
using Microsoft.AspNetCore.SignalR.Client;
using SocketClient.EventArgumentss;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocketClient.Hubs
{
    public class MessageHub
    {
        HubConnection connection;

        public event EventHandler<TimerElapsedEventArgs> TimerElapsed;

        public async Task ConnectAsync(int clientNumber)
        {
            connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/messagehub")
                .Build();

            connection.On<List<User>, DateTime>("TimerElapsed", (users, timerStartedAt) =>
            {
                Task.Run(() =>
                {
                    TimerElapsed?.Invoke(this, new TimerElapsedEventArgs(users, timerStartedAt));
                });
            });

            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };

            try
            {
                await connection.StartAsync();
                await SendRegisterMessage(clientNumber);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private async Task SendRegisterMessage(int number)
        {
            try
            {
                await connection.InvokeAsync("Register", new RegisterRequest(number));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

    }
}
