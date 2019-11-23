using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using System.IO;
using PERFGaming;
using PERFGaming.Modules;

namespace DiscordTutorialBot
{
    class Program
    {
        DiscordSocketClient _client;
        CommandHandler _handler;

        static void Main(string[] args)
        => new Program().StartAsync().GetAwaiter().GetResult();

        public async Task StartAsync()
        {
            if (Config.bot.token == "" || Config.bot.token == null) return;
            _client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Verbose
            });
            _client.Log += Log;
            //_client.Ready += RepeatingTimer.StartTimer;
            _client.UserJoined += AnnounceUserJoined;
            _client.UserLeft += UserLeft;
            _client.MessageReceived += _client_MessageReceivedAsync;
            await _client.LoginAsync(TokenType.Bot, Config.bot.token);
            await _client.StartAsync();
            Global.Client = _client;
            _handler = new CommandHandler();
            await _handler.InitializeAsync(_client);
            await Task.Delay(-1);
            
        }

        private async Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.Message);
        }

        


        public async Task AnnounceUserJoined(SocketGuildUser user)
        {
            if (user.Guild.Id == 348854075137327104)
            {
                var channel = _client.GetChannel(372379260335292418) as SocketTextChannel;
                var embed = new EmbedBuilder();
                embed.ThumbnailUrl = user.GetAvatarUrl();
                embed.WithColor(new Color(0x13ef42));
                embed.Title = $"**{user.Nickname} Joined The Server:**";
                embed.Description = ($" **User:** {user.Mention} \n **Time**: {DateTime.UtcNow}: \n **Server:** {user.Guild.Name}");
                await channel.SendMessageAsync("", false, embed: embed);
            }
            else
                return;
        }

        public async Task UserLeft(SocketGuildUser user)
        {
            if (user.Guild.Id == 348854075137327104)
            {
                var channel = _client.GetChannel(409618220446777344) as SocketTextChannel;
                var embed = new EmbedBuilder();
                embed.ThumbnailUrl = user.GetAvatarUrl();
                embed.WithColor(new Color(0x13ef42));
                embed.Title = $"**{user.Nickname} Left The Server:**";
                embed.Description = ($" **User:** {user.Mention} \n **Time**: {DateTime.UtcNow}: \n **Server:** {user.Guild.Name}");
                await user.SendMessageAsync($"We are sad seeing you go from the server, Please provide us with feedback as why did you leave");
                await channel.SendMessageAsync("", false, embed: embed);
            }
            else
                return;

        }


        //word filter system
        private async Task _client_MessageReceivedAsync(SocketMessage msg)
        {
           

            //test

            //test
            {
                
                /*string mydocuments = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}";
                string path = mydocuments + @"\LoggerBot-Logs";
                string logpath = $"{path}\\{e.Server.Id}-chatlog.txt";
                DirectoryInfo di = Directory.CreateDirectory(path);
                File.Create(logpath); */
                using (StreamWriter text = File.AppendText($"-chatlog.txt"))
                {
                    text.WriteLine($"{msg.Author} ({msg.Author.Id}) in #{msg.Channel.Name} ({msg.Channel.Id}): {msg.Content}");                                       //log msg to txt file
                }
            };

            {
              
                if (msg.Author.Id == 285047879180091392)
                {
                    return;
                }
                var booboowords = new List<string>() {"fuck", "F u c k", "fck", "f.uck", "Fuck", "FUCK", "bitch", "Bitch", "nigger", "Nigger", "Cunt", "cunt", "anal", "anus", "arse", "ass", "ballsack", "balls", "bastard", "bitch", "biatch",
                "blowjob", "blow job", "bollock", "bollok", "boner", "boob", "bugger", "homo", "jerk", "knobend", "knob end", "Pussy", "pussy", "Dick", "dick", "Dickhead", "dickhead", "B8tch", "b8tch"

};
                if (booboowords.Any(x => msg.Content.ToLower().Contains(x)))
                {
                    await msg.Author.GetOrCreateDMChannelAsync();
                    var embed = new EmbedBuilder();
                    embed.WithColor(240, 98, 146);
                    embed.Title = $"**{msg.Author.Username}** be careful";
                    embed.Description = $"**Username: **{msg.Author}\n**abusive language **refrain from using abusive language"; ///embed values///
                    await msg.Author.SendMessageAsync("", false, embed); ///sends embed///

                    await msg.Channel.SendMessageAsync($"{(msg.Author).Mention} abusive language, CHECK YOUR DM");
                    await msg.DeleteAsync();
                }

                if (msg.Content.Contains("Hi"))
                {
                    var embed = new EmbedBuilder();
                    embed.WithColor(240, 98, 146);
                    embed.Title = $"{msg.Author.Username}";
                    embed.Description = $"{msg.Author} Hi";
                    await msg.Channel.SendMessageAsync("", false, embed); ///sends embed///
                    return;

                }
                else if (msg.Content.Contains("Hello"))
                {
                    var embed = new EmbedBuilder();
                    embed.WithColor(240, 98, 146);
                    embed.Title = $"{msg.Author.Username}";
                    embed.Description = $"{msg.Author} Hello";
                    await msg.Channel.SendMessageAsync("", false, embed); ///sends embed///
                    return;

                }
                else if (msg.Content.Contains("hello"))
                {
                    var embed = new EmbedBuilder();
                    embed.WithColor(240, 98, 146);
                    embed.Title = $"{msg.Author.Username}";
                    embed.Description = $"{msg.Author} Hello";
                    await msg.Channel.SendMessageAsync("", false, embed); ///sends embed///
                    return;
                }
                else if (msg.Content.Contains("Hey"))
                {
                    var embed = new EmbedBuilder();
                    embed.WithColor(240, 98, 146);
                    embed.Title = $"{msg.Author.Username}";
                    embed.Description = $"{msg.Author} Hey";
                    await msg.Channel.SendMessageAsync("", false, embed); ///sends embed///
                    return;
                }
                else if (msg.Content.Contains("hey"))
                {
                    var embed = new EmbedBuilder();
                    embed.WithColor(240, 98, 146);
                    embed.Title = $"{msg.Author.Username}";
                    embed.Description = $"{msg.Author} hey";
                    await msg.Channel.SendMessageAsync("", false, embed); ///sends embed///
                    return;
                }
                else if (msg.Content.Contains("What is this"))
                {
                    var embed = new EmbedBuilder();
                    embed.WithColor(255, 87, 34);
                    embed.Title = $"{msg.Author.Username}";
                    embed.Description = $"{msg.Author} Glad you asked! this is a Gaming discord, where you guys play almost every game, this discord also has tech/game news, we give beta codes for games sometimes, and much more";
                    await msg.Channel.SendMessageAsync("", false, embed); ///sends embed///
                    return;
                }
                else if (msg.Content.Contains("what is this"))
                {
                    var embed = new EmbedBuilder();
                    embed.WithColor(255, 87, 34);
                    embed.Title = $"{msg.Author.Username}";
                    embed.Description = $"{msg.Author} Glad you asked! this is a Gaming discord, where you guys play almost every game, this discord also has tech/game news, we give beta codes for games sometimes, and much more";
                    await msg.Channel.SendMessageAsync("", false, embed); ///sends embed///
                    return;
                }
                else if (msg.Content.Contains("what is this?"))
                {
                    var embed = new EmbedBuilder();
                    embed.WithColor(255, 87, 34);
                    embed.Title = $"{msg.Author.Username}";
                    embed.Description = $"{msg.Author} Glad you asked! this is a Gaming discord, where you guys play almost every game, this discord also has tech/game news, we give beta codes for games sometimes, and much more";
                    await msg.Channel.SendMessageAsync("", false, embed); ///sends embed///
                    return;
                }
                else if (msg.Content.Contains("What is this?"))
                {
                    var embed = new EmbedBuilder();
                    embed.WithColor(255, 87, 34);
                    embed.Title = $"{msg.Author.Username}";
                    embed.Description = $"{msg.Author} Glad you asked! this is a Gaming discord, where you guys play almost every game, this discord also has tech/game news, we give beta codes for games sometimes, and much more";
                    await msg.Channel.SendMessageAsync("", false, embed); ///sends embed///
                    return;
                }

                else if (msg.Content.Contains("discord.gg/"))
                {
                    await msg.Author.GetOrCreateDMChannelAsync();
                    var embed = new EmbedBuilder();
                    embed.WithColor(245, 0, 87);
                    embed.Title = $"{msg.Author.Username}";
                    embed.Description = $"Hey {msg.Author} discord invites and short URLs aren't allowd in this server";
                    await msg.Author.SendMessageAsync("", false, embed); ///sends embed///
                    await msg.DeleteAsync();
                    return;
                }
                else if (msg.Content.Contains("goo.gl/"))
                {
                    await msg.Author.GetOrCreateDMChannelAsync();
                    var embed = new EmbedBuilder();
                    embed.WithColor(245, 0, 87);
                    embed.Title = $"{msg.Author.Username}";
                    embed.Description = $"Hey {msg.Author} discord invites and short URLs aren't allowd in this server";
                    await msg.Author.SendMessageAsync("", false, embed); ///sends embed///
                    await msg.DeleteAsync();
                    return;
                }
                else if (msg.Content.Contains("bit.ly/"))
                {
                    await msg.Author.GetOrCreateDMChannelAsync();
                    var embed = new EmbedBuilder();
                    embed.WithColor(245, 0, 87);
                    embed.Title = $"{msg.Author.Username}";
                    embed.Description = $"Hey {msg.Author} discord invites and short URLs aren't allowd in this server";
                    await msg.Author.SendMessageAsync("", false, embed); ///sends embed///
                    await msg.DeleteAsync();
                    return;
                }




            }



        }
    }
}

