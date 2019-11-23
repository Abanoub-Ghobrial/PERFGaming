using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using System.IO;
using Discord.WebSocket;
using PERFGaming;

namespace PERFGaming.Modules
{
    public class UserAccount
    {
        public ulong ID { get; set; }

        public uint Points { get; set; }

        public uint XP { get; set; }

        public bool IsMuted { get; set; }

        public uint NumberOfWarnings { get; set; }

        public uint LevelNumber 
        {
            get
            {
                return (uint)Math.Sqrt(XP / 50);
            }
        }
    }

}
