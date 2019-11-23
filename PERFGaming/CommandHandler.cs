using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Discord;
using PERFGaming.Modules;

namespace DiscordTutorialBot
{
    class CommandHandler
    {
        DiscordSocketClient _client;
        CommandService _service;

        public async Task InitializeAsync(DiscordSocketClient client)
        {
            _client = client;
            _service = new CommandService();
            await _service.AddModulesAsync(Assembly.GetEntryAssembly());
            _client.MessageReceived += HandleCommandAsync;
            _client.UserJoined += UserJoined;
            _client.Ready += play;
            _client.Ready += backOnline;
            
        }

        public async Task play()
        {
            await _client.SetGameAsync("Use: Bhelp");

        }

        private async Task UserJoined(SocketGuildUser user)
        {
            var role = user.Guild.Roles.Where(has => has.Name.ToUpper() == "PERF GAMING".ToUpper());
            await user.AddRolesAsync(role);
        }

        public async Task backOnline()
        {
            var channel = _client.GetChannel(392166969102827520) as SocketTextChannel;
            var embed = new EmbedBuilder();
            embed.WithTitle("Good Bye");
            embed.WithDescription(" Everything has to come to an end, sometime." + Environment.NewLine + " Tonight will mark my last day with you" + Environment.NewLine +
                " I hope you guys have fun in the future and get more active");
            embed.WithColor(new Color(250, 250, 0));
            embed.WithAuthor("GOOD BYE, PERFGaming Bot, Developed by kingofcold#4799");
            await channel.SendMessageAsync("", false, embed);
            /*var embed = new EmbedBuilder();
            embed.WithColor(new Color(0x13ef42));
            embed.Title = ("GOOD BYE");
            embed.WithDescription = (" Everything has to come to an end, sometime." + Environment.NewLine + " Tonight will mark my last day with you" + Environment.NewLine + 
                " I hope you guys have fun in the future and get more active" );
            embed.Description = (" GOOD BYE, PERFGaming BOT, Developed by kingofcold#4799 ");
            await channel.SendMessageAsync("", false, embed: embed);
            */
        }
    
    



    private async Task HandleCommandAsync(SocketMessage s)
        {
            var msg = s as SocketUserMessage;
            if (msg == null) return;
            var context = new SocketCommandContext(_client, msg);
            if (context.User.IsBot) return;

        
            //Mute check
            var userAccount = UserAccounts.GetAccount(context.User);
            if (userAccount.IsMuted)
            {
                await context.Message.DeleteAsync();
                return;
            }
            
            //Leveling up 
            Levelling.UserSentMessage((SocketGuildUser)context.User, (SocketTextChannel)context.Channel);
        
            int argPos = 0;
            if (msg.HasStringPrefix(Config.bot.cmdPrefix, ref argPos)
                || msg.HasMentionPrefix(_client.CurrentUser, ref argPos))
            {
                var result = await _service.ExecuteAsync(context, argPos);
                if (!result.IsSuccess && result.Error != CommandError.UnknownCommand)
                {
                    Console.WriteLine(result.ErrorReason);
                }
            }
        }

    }
}
