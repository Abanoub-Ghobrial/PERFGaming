using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace PERFGaming.Modules
{
    /*internal static class RepeatingTimer
    {
        private static Timer loopingTimer;
        private static SocketTextChannel channel;
        

        internal static Task StartTimer()
        {
            channel = Global.Client.GetGuild(348854075137327104).GetTextChannel(392166969102827520); 

            loopingTimer = new Timer()
            {
                Interval = 60000000000,
                AutoReset = true,
                Enabled = true
            };

            loopingTimer.Elapsed += OnTimerTicket;

            return Task.CompletedTask;
        }

        private static async void OnTimerTicket(object sender, ElapsedEventArgs e)
        {
            await channel.SendMessageAsync("Happy Easter everyone, I am granting each member 10000 XP. ENJOY");
        }
    }
    */
}
