using SocketClient.Hubs;
using System;

namespace SocketClient
{
    class Program
    {
        static MessageHub hub;

        static void Main(string[] args)
        {
            string numStr = null;
            if (args != null && args.Length > 0)
            {
                numStr = args[0];
            }
            else
            {
                Console.WriteLine("Enter client number: ");
                numStr = Console.ReadLine();
            }
           
            if (int.TryParse(numStr, out int num))
            {
                hub = new MessageHub();
                hub.TimerElapsed += Hub_TimerElapsed;
                hub.ConnectAsync(num).GetAwaiter().GetResult();
            }
            else
            {
                Console.WriteLine("Wrong number");
            }

            Console.ReadKey();
        }

        private static void Hub_TimerElapsed(object sender, EventArgumentss.TimerElapsedEventArgs e)
        {
            Console.WriteLine($"Server timer elapsed. Started at {e.TimerStartedAt}");
            foreach(var user in e.User)
            {
                Console.WriteLine($"User ID: {user.UserName}, ConnectedAt: {user.ConnectedAt}");
            }
        }
    }
}
