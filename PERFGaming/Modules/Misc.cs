using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Discord;
using Discord.WebSocket;
using System.Diagnostics;
using PERFGaming;
using Newtonsoft.Json;

namespace PERFGaming.Modules
{
    public class Misc : ModuleBase<SocketCommandContext>
    {
        
        [Command("echo")]
        public async Task Echo([Remainder]string message)
        {
            if (Context.Guild.Id == 348854075137327104 || Context.User.Id == 285047879180091392 || Context.User.Id == 410299915231821824)
            {
                var embed = new EmbedBuilder();
                embed.WithTitle("Message by " + Context.User.Username);
                embed.WithDescription(message);
                embed.WithColor(new Color(0, 255, 0));

                await Context.Channel.SendMessageAsync("", false, embed);
            }
            else
                await Context.Channel.SendMessageAsync("I don't accept commands in this server, Please Contact my owner kingofcold#4799");
        }

        [Command("pick")]
        public async Task PickOne([Remainder]string message)
        {
            if (Context.Guild.Id == 348854075137327104 || Context.User.Id == 285047879180091392 || Context.User.Id == 410299915231821824)
            {
                string[] options = message.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);


                Random r = new Random();
                string selection = options[r.Next(0, options.Length)];

                var embed = new EmbedBuilder();
                embed.WithTitle("Choice for " + Context.User.Username);
                embed.WithDescription(selection);
                embed.WithColor(new Color(255, 255, 0));


                await Context.Channel.SendMessageAsync("", false, embed);
            }
            else
                await Context.Channel.SendMessageAsync("I don't accept commands in this server, Please Contact my owner kingofcold#4799");
        }

        [Command("secret")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task RevealSecret([Remainder]string arg = "")
        {
            if (Context.Guild.Id == 348854075137327104 || Context.User.Id == 285047879180091392 || Context.User.Id == 410299915231821824)
            {
                var dmChannel = await Context.User.GetOrCreateDMChannelAsync();
                await dmChannel.SendMessageAsync(Utilities.GetAlert("SECRET"));
            }
            else
                await Context.Channel.SendMessageAsync("I don't accept commands in this server, Please Contact my owner kingofcold#4799");

        }

        [Command("Ban")]
        [Summary("Ban @Username")]
        [RequireUserPermission(GuildPermission.BanMembers)] ///Needed User Permissions ///
        [RequireBotPermission(GuildPermission.BanMembers)] ///Needed Bot Permissions ///
        public async Task BanAsync(SocketGuildUser user = null, [Remainder] string reason = null)
        {
            if (Context.Guild.Id == 348854075137327104 || Context.User.Id == 285047879180091392 || Context.User.Id == 410299915231821824)
            {
                if (user == null) throw new ArgumentException("You must mention a user");
                if (user == null) await Context.Channel.SendMessageAsync("You must mention a user!");

                if (reason == null) throw new ArgumentException("You must give a reason!");
                if (reason == null) await Context.Channel.SendMessageAsync("You must mention a user!");

                var gld = Context.Guild as SocketGuild;
                var embed = new EmbedBuilder(); ///starts embed///
                embed.WithColor(new Color(0x4900ff)); ///hexacode colours ///
                embed.Title = $"**{user.Username}** was banned";///Who was banned///
                embed.Description = $"**Username: **{user.Username}\n**Banned by: **{Context.User.Mention}!\n**Reason: **{reason}"; ///Embed values///

                await user.SendMessageAsync($"You have been banned from {Context.Guild.Name} for {reason} by {Context.User}");

                await gld.AddBanAsync(user, 5);///bans selected user///

                await Context.Channel.SendMessageAsync("", false, embed);///sends embed///
            }
            else
                await Context.Channel.SendMessageAsync("I don't accept commands in this server, Please Contact my owner kingofcold#4799");

        }

        [Command("Kick")]
        [RequireBotPermission(GuildPermission.KickMembers)] ///Needed BotPerms///
        [RequireUserPermission(GuildPermission.KickMembers)] ///Needed User Perms///
        public async Task KickAsync(SocketGuildUser user, [Remainder] string reason = "No reason provided.")
        {
            if (Context.Guild.Id == 348854075137327104 || Context.User.Id == 285047879180091392 || Context.User.Id == 410299915231821824)
            {
                if (user == null) throw new ArgumentException("You must mention a user");
                if (user == null) await Context.Channel.SendMessageAsync("You must mention a user!");

                if (reason == null) throw new ArgumentException("You must give a reason!");
                if (reason == null) await Context.Channel.SendMessageAsync("You must mention a user!");

                var gld = Context.Guild as SocketGuild;
                var embed = new EmbedBuilder(); ///starts embed///
                embed.WithColor(new Color(0x4900ff)); ///hexacode colours ///
                embed.Title = $" {user.Username} has been kicked from {user.Guild.Name}"; ///who was kicked///
                embed.Description = $"**Username: **{user.Username}\n**Kicked by: **{Context.User.Mention}!\n**Reason: **{reason}"; ///embed values///

                await user.SendMessageAsync($"You have been kicked from {Context.Guild.Name} for {reason} by {Context.User}");

                await user.KickAsync(reason); ///kicks selected user///

                await Context.Channel.SendMessageAsync("", false, embed); ///sends embed///
            }
            else
                await Context.Channel.SendMessageAsync("I don't accept commands in this server, Please Contact my owner kingofcold#4799");
        }


        string[] predictionsTexts = new string[]
            {
                "It is very unlikely.",
                "I don't think so...",
                "Yes !",
                "I don't know",
                "No."
            };
        Random rand = new Random();
        [Command("8ball")]
        [Summary("Gives a prediction")]
        public async Task EightBall([Remainder] string input)
        {
            if (Context.Guild.Id == 348854075137327104 || Context.User.Id == 285047879180091392 || Context.User.Id == 410299915231821824)
            {
                int randomIndex = rand.Next(predictionsTexts.Length);
                string text = predictionsTexts[randomIndex];
                await ReplyAsync(Context.User.Mention + ", " + text);
            }
            else
                await Context.Channel.SendMessageAsync("I don't accept commands in this server, Please Contact my owner kingofcold#4799");
        }

        [Command("Ping")]
        [Alias("ping", "pong")]
        [Summary("Returns a pong")]
        public async Task Say()
        {
            if (Context.Guild.Id == 348854075137327104 || Context.User.Id == 285047879180091392 || Context.User.Id == 410299915231821824)
            {
                await ReplyAsync("Pong!");
            }
            else
                await Context.Channel.SendMessageAsync("I don't accept commands in this server, Please Contact my owner kingofcold#4799");

        }

        //CLEAR MSGS// 
        [Command("clear", RunMode = RunMode.Async)]
        [Summary("Clears up to 1000 messages")]
        [RequireUserPermission(GuildPermission.Administrator)]
        [RequireBotPermission(ChannelPermission.ManageMessages)]
        public async Task ClearAll()
        {
            if (Context.Guild.Id == 348854075137327104 || Context.User.Id == 285047879180091392 || Context.User.Id == 410299915231821824)
            {

                var messagesToDelete = await Context.Channel.GetMessagesAsync(1000).Flatten();
                await this.Context.Channel.DeleteMessagesAsync(messagesToDelete);
                await this.ReplyAsync("messages removed");
            }
            else
                await Context.Channel.SendMessageAsync("I don't accept commands in this server, Please Contact my owner kingofcold#4799");
        }
        //end clear code//

        //bot INFO//
        [Command("botinfo")]
        [Summary("Shows All Bot Info.")]
        public async Task Info()
        {
            if (Context.Guild.Id == 348854075137327104 || Context.User.Id == 285047879180091392 || Context.User.Id == 410299915231821824)
            {
                using (var process = Process.GetCurrentProcess())
                {
                    /*this is required for up time*/
                    var embed = new EmbedBuilder();
                    var application = await Context.Client.GetApplicationInfoAsync(); /*for lib version*/
                    embed.ImageUrl = application.IconUrl; /*pulls bot Avatar. Not needed can be removed*/
                    embed.WithColor(new Color(0x4900ff)) /*Hexacode colours*/

                    .AddField(y =>
                    {
                        /*new embed field*/
                        y.Name = "Author.";  /*Field name here*/
                        y.Value = application.Owner.Username; application.Owner.Id.ToString(); /*Code here. If INT convert to string*/
                        y.IsInline = false;
                    })
                    .AddField(y =>  /* add new field, rinse and repeat*/
                    {
                        y.Name = "Uptime.";
                        var time = DateTime.Now - process.StartTime; /* Subtracts current time and start time to get Uptime*/
                        var sb = new StringBuilder();
                        if (time.Days > 0)
                        {
                            sb.Append($"{time.Days}d ");
                        }
                        if (time.Hours > 0)
                        {
                            sb.Append($"{time.Hours}h ");
                        }
                        if (time.Minutes > 0)
                        {
                            sb.Append($"{time.Minutes}m ");
                        }
                        sb.Append($"{time.Seconds}s ");
                        y.Value = sb.ToString();
                        y.IsInline = true;
                    })
                    .AddField(y =>
                    {
                        y.Name = "Server Amount.";
                        y.Value = (Context.Client as DiscordSocketClient).Guilds.Count.ToString(); /*Numbers of servers the bot is in*/
                        y.IsInline = false;
                    })
                    .AddField(y =>
                    {
                        y.Name = "Number Of Users";
                        y.Value = (Context.Client as DiscordSocketClient).Guilds.Sum(g => g.Users.Count).ToString(); /*Counts users*/
                        y.IsInline = false;
                    })
                    .AddField(y =>
                    {
                        y.Name = "Channels";
                        y.Value = (Context.Client as DiscordSocketClient).Guilds.Sum(g => g.Channels.Count).ToString();
                        y.IsInline = false;
                    });
                    await this.ReplyAsync("", embed: embed);
                }
            }
            else
                await Context.Channel.SendMessageAsync("I don't accept commands in this server, Please Contact my owner kingofcold#4799");
        }
        //ends bot INFO//

        // user info//
        [Command("userinfo")]
        [Name("userinfo `<user>`")]
        public async Task UserInfo(IGuildUser user)
        {
            if (Context.Guild.Id == 348854075137327104 || Context.User.Id == 285047879180091392 || Context.User.Id == 410299915231821824)
            {
                var application = await Context.Client.GetApplicationInfoAsync();
                var date = $"{user.CreatedAt.Month}/{user.CreatedAt.Day}/{user.CreatedAt.Year}";
                var auth = new EmbedAuthorBuilder()

                {

                    Name = user.Username,

                };

                var embed = new EmbedBuilder()

                {
                    Color = new Color(29, 140, 209),
                    Author = auth
                };

                var us = user as SocketGuildUser;

                var D = us.Username;

                var A = us.Discriminator;
                var T = us.Id;
                var S = date;
                var C = us.Status;
                var CC = us.JoinedAt;
                var O = us.Game;
                embed.Title = $"**{us.Username}** Information";
                embed.Description = $"Username: **{D}**\nDiscriminator: **{A}**\nUser ID: **{T}**\nCreated at: **{S}**\nCurrent Status: **{C}**\nJoined server at: **{CC}**\nPlaying: **{O}**";

                await ReplyAsync("", false, embed.Build());
            }
            else
                await Context.Channel.SendMessageAsync("I don't accept commands in this server, Please Contact my owner kingofcold#4799");
        }

        //server info//
        [Command("ServerInfo")]
        [Alias("sinfo", "servinfo")]
        [Remarks("Info about a server")]
        public async Task GuildInfo()
        {
            if (Context.Guild.Id == 348854075137327104 || Context.User.Id == 285047879180091392 || Context.User.Id == 410299915231821824)
            {
                EmbedBuilder embedBuilder;
                embedBuilder = new EmbedBuilder();
                embedBuilder.WithColor(new Color(0, 71, 171));

                var gld = Context.Guild as SocketGuild;
                var client = Context.Client as DiscordSocketClient;


                if (!string.IsNullOrWhiteSpace(gld.IconUrl))
                    embedBuilder.ThumbnailUrl = gld.IconUrl;
                var O = gld.Owner.Username;

                var V = gld.VoiceRegionId;
                var C = gld.CreatedAt;
                var N = gld.DefaultMessageNotifications;
                var VL = gld.VerificationLevel;
                var XD = gld.Roles.Count;
                var X = gld.MemberCount;
                var Z = client.ConnectionState;

                embedBuilder.Title = $"{gld.Name} Server Information";
                embedBuilder.Description = $"Server Owner: **{O}\n**Voice Region: **{V}\n**Created At: **{C}\n**MsgNtfc: **{N}\n**Verification: **{VL}\n**Role Count: **{XD}\n **Members: **{X}\n **Conntection state: **{Z}\n\n**";
                await ReplyAsync("", false, embedBuilder);
            }
            else
                await Context.Channel.SendMessageAsync("I don't accept commands in this server, Please Contact my owner kingofcold#4799");
        }
        //server info end//

        //Help//
        [Command("help")]
        public async Task Help()
        {
            await Context.User.GetOrCreateDMChannelAsync();
            var embed = new EmbedBuilder();
            embed.WithTitle("General Commands");
            embed.WithDescription("help - Shows you this!" + Environment.NewLine +
                                  "serverinfo - Gives you information about the server!" + Environment.NewLine + "userinfo (username) - Shows you information about the mentioned user!" 
                                  + Environment.NewLine +
                                  "Ping - Pings the bot" + Environment.NewLine + "Echo - Echo what you typed" + Environment.NewLine + "Pick (1st choice|2nd choice..etc) - pick a random choice" 
                                  + Environment.NewLine +
                                  "8ball -Ask the magic eightball a question!" + Environment.NewLine + "WhatLevelIs (Number) - tells you that EXP is what Level " 
                                  + Environment.NewLine + "Quote - Gives you a random quote" + Environment.NewLine + "DM - Message the bot owner");
            embed.WithColor(new Color(250, 250, 0));

            var embed2 = new EmbedBuilder();
            embed2.WithColor(new Color(156, 204, 101));
            embed2.WithTitle("Fun Commands");
            embed2.WithDescription("coinflip - flip the coin" + Environment.NewLine + "addmany 10 60...etc - adds the numbers" + Environment.NewLine + "multiply 10 60...etc - multiply the numbers");


            var embed1 = new EmbedBuilder();
            embed1.WithTitle("MODERATION COMMANDS");
            embed1.WithDescription("Ban (username) (Reason) - Bans a member" + Environment.NewLine +
                                  "kick (username) (Reason) - kicks a member" + Environment.NewLine + "Warn (username) - Warn a member (3 Warnings = Automatic Ban)" 
                                  + Environment.NewLine + "ClearWarns (username) - Clear all warnings of the mentioned user " + Environment.NewLine + "clear - clear messages from a channel"
                                  + Environment.NewLine + "Mute (username) (reason) - Mute a user" + Environment.NewLine + "UnMute (username) (reason) - Unmute a user");
            embed1.WithColor(new Color(255, 171, 0));

            await Context.User.SendMessageAsync("", false, embed);
            await Context.User.SendMessageAsync("", false, embed2);
            await Context.User.SendMessageAsync("", false, embed1);
            await Context.Channel.SendMessageAsync(Context.User.Mention + " " + "Check your DM");
        }



        //Quote//
        string[] quoteTexts = new string[]
            {
                "If you want to achieve greatness stop asking for permission.",
                "Things work out best for those who make the best of how things work out.",
                "To live a creative life, we must lose our fear of being wrong.",
                "The Way Get Started Is To Quit Talking And Begin Doing.",
                "The Pessimist Sees Difficulty In Every Opportunity. The Optimist Sees Opportunity In Every Difficulty.",
                "Don’t Let Yesterday Take Up Too Much Of Today.",
                "You Learn More From Failure Than From Success. Don’t Let It Stop You. Failure Builds Character.",
                "Don't cry because it's over, smile because it happened.",
                "Be yourself; everyone else is already taken.",
                "Two things are infinite: the universe and human stupidity; and I'm not sure about the universe.",
                "Be who you are and say what you feel, because those who mind don't matter, and those who matter don't mind.",
                "A room without books is like a body without a soul.",
                "You miss 100% of the shots you don’t take.",
                "The most difficult thing is the decision to act, the rest is merely tenacity.",
                "Definiteness of purpose is the starting point of all achievement."
            };
        private Random quote = new Random();
        [Command("quote")]
        [Summary("Your random quote")]
        public async Task Quote()
        {
            if (Context.Guild.Id == 348854075137327104 || Context.User.Id == 285047879180091392 || Context.User.Id == 410299915231821824)
            {
                int randomIndex = rand.Next(quoteTexts.Length);
                string text = quoteTexts[randomIndex];
                await ReplyAsync(Context.User.Mention + ", " + text);
            }
            else
                await Context.Channel.SendMessageAsync("I don't accept commands in this server, Please Contact my owner kingofcold#4799");
        }



        [Command("dm")]
        public async Task sendmsgtoowner([Remainder] string text)
        {
            var embed = new EmbedBuilder()
            {
                Color = new Color(231, 31, 31)
            };
            var application = await Context.Client.GetApplicationInfoAsync();
            var user = application.Owner.GetOrCreateDMChannelAsync();
            var z = await application.Owner.GetOrCreateDMChannelAsync();
            embed.Description = $"`{Context.User.Username}` **from** `{Context.Guild.Name}` **send you a message!**\n\n{text}";
            await z.SendMessageAsync("", false, embed);
            await Context.Channel.SendMessageAsync("Your message has been sent");
        }

        [Command("WhatLevelIs")]
        public async Task WhatLevelIS(uint xp)
        {
            if (Context.Guild.Id == 348854075137327104 || Context.User.Id == 285047879180091392 || Context.User.Id == 410299915231821824)
            {
                uint level = (uint)Math.Sqrt(xp / 50);
                await Context.Channel.SendMessageAsync("The level is " + level);
            }
            else
                await Context.Channel.SendMessageAsync("I don't accept commands in this server, Please Contact my owner kingofcold#4799");

        }

        [Command("Warn")]
        [RequireUserPermission(GuildPermission.BanMembers)]
        [RequireBotPermission(GuildPermission.BanMembers)]
        public async Task warn(IGuildUser user, [Remainder] string reason = "No reason provided.")
        {
            if (Context.Guild.Id == 348854075137327104 || Context.User.Id == 285047879180091392 || Context.User.Id == 410299915231821824)
            {
                var userAccount = UserAccounts.GetAccount((SocketUser)user);
                userAccount.NumberOfWarnings++;
                UserAccounts.SaveAccounts();
                if (user.Id == 285047879180091392)
                {
                    await Context.Channel.SendMessageAsync("I can't warn that user");
                    return;
                }
                else if (user.Id == 410299915231821824)
                {
                    await Context.Channel.SendMessageAsync("I can't warn that user");
                    return;
                }
                else
                {
                    if (userAccount.NumberOfWarnings >= 3)
                    {
                        await Context.User.GetOrCreateDMChannelAsync();
                        var embed = new EmbedBuilder();
                        embed.WithColor(240, 98, 146);
                        embed.Title = $"**{user.Username}** was banned";
                        embed.Description = $"**Username: **{user.Username}\n**Banned by: **{Context.User.Mention}\n**Warnings: **3 or more warnings"; ///embed values///
                        await user.SendMessageAsync("", false, embed); ///sends embed///
                        var embed1 = new EmbedBuilder();
                        embed1.WithColor(new Color(0x4900ff));
                        embed1.Title = $"**{user.Username}** was banned";
                        embed1.Description = $"**Username: **{user.Username}\n**Banned by: **{Context.User.Mention}\n**Warnings: **3 or more warnings"; ///embed values///
                        await user.SendMessageAsync("", false, embed); ///sends embed///
                        await ReplyAsync("", false, embed1);
                        await user.Guild.AddBanAsync(user, 5);

                    }
                    else if (userAccount.NumberOfWarnings == 2)
                    {
                        var gld = Context.Guild as SocketGuild;
                        var embed = new EmbedBuilder();
                        embed.WithColor(173, 20, 87); ///hexacode colours ///
                        embed.Title = $" {user.Username} has been warned from {user.Guild.Name}"; ///who was kicked///
                        embed.Description = $"**Username: **{user.Username}\n**Warned by: **{Context.User.Mention}\n**Warnings: **That is your 2nd warning, next time it's a ban"; ///embed values///
                        await Context.Channel.SendMessageAsync("", false, embed); ///sends embed///
                    }
                    else if (userAccount.NumberOfWarnings == 1)
                    {
                        var gld = Context.Guild as SocketGuild;
                        var embed = new EmbedBuilder();
                        embed.WithColor(245, 0, 87);
                        embed.Title = $" {user.Username} has been warned from {user.Guild.Name}"; ///who was kicked///
                        embed.Description = $"**Username: **{user.Username}\n**Warned by: **{Context.User.Mention}\n**Warnings: **That is your 1st warning, be careful and read the rules"; ///embed values///
                        await Context.Channel.SendMessageAsync("", false, embed); ///sends embed///
                    }
                }
            }
            else
                await Context.Channel.SendMessageAsync("I don't accept commands in this server, Please Contact my owner kingofcold#4799");
        }

        public class clearwarns : ModuleBase<SocketCommandContext>
        {
            [Command("ClearWarns")]
            [RequireUserPermission(GuildPermission.ManageMessages)]
            [RequireBotPermission(GuildPermission.ManageMessages)]
            public async Task warn(IGuildUser user)
            {
                if (Context.Guild.Id == 348854075137327104 || Context.User.Id == 285047879180091392 || Context.User.Id == 410299915231821824)
                {
                    var userAccount = UserAccounts.GetAccount((SocketUser)user);

                    if (user == null) throw new ArgumentException("You must mention a user");

                    await Context.Channel.SendMessageAsync("Users warns have been cleared!");

                    userAccount.NumberOfWarnings = 0;
                    UserAccounts.SaveAccounts();
                }
                else
                    await Context.Channel.SendMessageAsync("I don't accept commands in this server, Please Contact my owner kingofcold#4799");
            }
        }


        [Command("Mute")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        [RequireBotPermission(GuildPermission.ManageRoles)]
        public async Task mutecmd(IGuildUser user, [Remainder] string reason = "No reason provided.")
        {
            if (Context.Guild.Id == 348854075137327104 || Context.User.Id == 285047879180091392 || Context.User.Id == 410299915231821824)
            {
                var userAccount = UserAccounts.GetAccount((SocketUser)user);

                if (user == null) throw new ArgumentException("You must mention a user");
                if (user == null) await Context.Channel.SendMessageAsync("You must mention a user!");
                if (reason == null) throw new ArgumentException("You must give a reason!");
                if (reason == null) await Context.Channel.SendMessageAsync("You must mention a user!");

                if (user.Id == 410299915231821824)
                {
                    await Context.Channel.SendMessageAsync("I can't mute that user");
                    return;

                }
                else if (user.Id == 285047879180091392)
                {
                    await Context.Channel.SendMessageAsync("I can't mute that user");
                    return;
                }
                else
                {
                    var role = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Muted");
                    userAccount.IsMuted = true;
                    UserAccounts.SaveAccounts();

                    var embed = new EmbedBuilder();
                    embed.WithColor(156, 39, 176);
                    embed.Title = $" {user.Username} has been muted by {Context.User.Username}";
                    embed.Description = $"**Username: **{user.Username}\n**Muted by: **{Context.User.Mention}\n**Reason: **{reason}";
                    await Context.Channel.SendMessageAsync("", false, embed);
                    await (user as IGuildUser).AddRoleAsync(role);
                }
            }
            else
                await Context.Channel.SendMessageAsync("I don't accept commands in this server, Please Contact my owner kingofcold#4799");
        }


        [Command("UnMute")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        [RequireBotPermission(GuildPermission.ManageRoles)]
        public async Task Unmutecmd(IGuildUser user, [Remainder] string reason = "No reason provided.")
        {
            if (Context.Guild.Id == 348854075137327104 || Context.User.Id == 285047879180091392 || Context.User.Id == 410299915231821824)
            {
                var userAccount = UserAccounts.GetAccount((SocketUser)user);

                if (user == null) throw new ArgumentException("You must mention a user");
                if (user == null) await Context.Channel.SendMessageAsync("You must mention a user!");
                if (reason == null) throw new ArgumentException("You must give a reason!");
                if (reason == null) await Context.Channel.SendMessageAsync("You must mention a user!");

                var role = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Muted");
                userAccount.IsMuted = false;
                UserAccounts.SaveAccounts();

                var embed = new EmbedBuilder();
                embed.WithColor(255, 87, 34);
                embed.Title = $" {user.Username} has been unmuted by {Context.User.Username}";
                embed.Description = $"**Username: **{user.Username}\n**Unmuted by: **{Context.User.Mention}\n**Reason: **{reason}";
                await Context.Channel.SendMessageAsync("", false, embed);
                await (user as IGuildUser).RemoveRoleAsync(role);
            }
            else
                await Context.Channel.SendMessageAsync("I don't accept commands in this server, Please Contact my owner kingofcold#4799");
        }

        [Command("hi")]
        private async Task Hi()
        {
            await ReplyAsync("Hi" + "" + Context.User.Mention );

        }

        [Command("Hello")]
        private async Task Hello()
        {
            await ReplyAsync("Hello"+ "" + Context.User.Mention);

        }

        [Command("Hey")]
        private async Task Hey()
        {
            await ReplyAsync("Hey" + "" + Context.User.Mention);
        }

        [Command("Statsof")]
        public async Task Stats(SocketGuildUser user)
        {
            if (user.Id == 285047879180091392  || user.Id == 305259385934839808 || user.Id == 272396646350848001 || user.Id == 295153128070971392 || user.Id == 299003827242270720)
            {
                await Context.Channel.SendMessageAsync($"{Context.User.Mention} you don't have permission to view {user.Username} details ");
            }
            else
            {
                var userAccount = UserAccounts.GetAccount(user);
                await Context.Channel.SendMessageAsync($"{user.Username} is level {userAccount.LevelNumber} and has {userAccount.XP} XP");
            }
               
            
        }


        [Command("addXP")]
        [RequireUserPermission(GuildPermission.BanMembers)]
        public async Task AddXP(IGuildUser user, uint xp)
        {
            if (Context.Guild.Id == 348854075137327104 || Context.User.Id == 285047879180091392 || Context.User.Id == 410299915231821824)
            {
                if (user.Id == 285047879180091392 || user.Id == 410299915231821824 || user.Id == 305259385934839808 || user.Id == 272396646350848001 || user.Id == 295153128070971392 || user.Id == 299003827242270720)
                {
                    await Context.Channel.SendMessageAsync($"{Context.User.Mention} you don't have permission to use this command on {user.Username}");
                }
                else
                {
                    var account = UserAccounts.GetAccount(((SocketUser)user));
                    account.XP += xp;
                    UserAccounts.SaveAccounts();
                    await Context.Channel.SendMessageAsync($"{user.Username} gained {xp} XP from {Context.User.Mention}");
                }
            }
            else
                await Context.Channel.SendMessageAsync("I don't accept commands in this server, Please Contact my owner kingofcold#4799");

        }

    
        
        //user nickname
        [Command("nickname")]
        [Summary("Change your nickname to the specified text")]
        [RequireUserPermission(GuildPermission.ChangeNickname)]
        public Task Nick([Remainder]string name)
                => Nick(Context.User as SocketGuildUser, name);




        //Mod nickname
        [Command("nick")]
        [Summary("Change another user's nickname to the specified text")]
        [RequireUserPermission(GuildPermission.ManageNicknames)]
        public async Task Nick(SocketGuildUser user, [Remainder]string name)
        {
            await user.ModifyAsync(x => x.Nickname = name);
            await ReplyAsync($"{user.Mention} I changed your name to **{name}**");
        }

        [Command("clearuser")]
        [Remarks("Purges A User's Last 100 Messages")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        public async Task Clear(SocketGuildUser user)
        {
            if (user.Id == 285047879180091392 || user.Id == 410299915231821824 || user.Id == 305259385934839808 || user.Id == 272396646350848001 || user.Id == 295153128070971392 || user.Id == 299003827242270720)
            {
                await Context.Channel.SendMessageAsync($"{Context.User.Mention} you don't have permission to use this command on {user.Username}");
            }
            else
            {
                var messages = await Context.Message.Channel.GetMessagesAsync(100).Flatten();

                var result = messages.Where(x => x.Author.Id == user.Id && x.CreatedAt >= DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(14)));

                await Context.Message.Channel.DeleteMessagesAsync(result);
            }
            
        }


        [Command("resetXP")]
        [RequireUserPermission(GuildPermission.BanMembers)]
        public async Task resetXP(IGuildUser user)
        {
            if (user.Id == 285047879180091392 || user.Id == 410299915231821824 || user.Id == 305259385934839808 || user.Id == 272396646350848001 || user.Id == 295153128070971392 || user.Id == 299003827242270720)
            {
                await Context.Channel.SendMessageAsync($"{Context.User.Mention} you don't have permission to use this command on {user.Username}");
            }
            else
            {
                var account = UserAccounts.GetAccount(((SocketUser)user));
                account.XP = 0;
                UserAccounts.SaveAccounts();
                await Context.Channel.SendMessageAsync($"{user.Username} XP has been reseted by {Context.User.Mention}");
            }

        }



        [Command("Warnings")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        public async Task amtwarnings(IGuildUser user)
        {
            if (user.Id == 285047879180091392 || user.Id == 410299915231821824 || user.Id == 305259385934839808 || user.Id == 272396646350848001 || user.Id == 295153128070971392 || user.Id == 299003827242270720)
            {
                await Context.Channel.SendMessageAsync($"{Context.User.Mention} you don't have permission to use this command on {user.Username}");
            }
            else
            {
                var userAccount = UserAccounts.GetAccount((SocketUser)user);

                if (user == null) throw new ArgumentException("You must mention a user");
                if (user == null) await Context.Channel.SendMessageAsync("You must mention a user!");

                var embed = new EmbedBuilder();
                embed.WithColor(new Color(0xF44336));
                embed.Title = $"Warnings for: {user.Username}";
                embed.Description = $"**Username: **{user.Username}\n**Amount of warnings: **{userAccount.NumberOfWarnings}!";
                await Context.Channel.SendMessageAsync("", false, embed);
            }
                
        }

        //to be added to the VPS
        [Command("Game"), Alias("ChangeGame", "SetGame")]
        [Remarks("Change what the bot is currently playing.")]
        [RequireOwner]
        public async Task SetGame([Remainder] string gamename)
        {
            await Context.Client.SetGameAsync(gamename);
            await ReplyAsync($"Changed game to {Context.Client.CurrentUser.Game?.Name}");
        }


        [Command("coinflip")]
        public async Task coinflip()
        {
            Random rng = new Random();
            var result = rng.Next(0, 2) == 0 ? "Heads" : "Tails";
            await Context.Channel.SendMessageAsync($"You flipped {result}");
        }

        [Name("Math")]
        [Summary("Do some math I guess")]
        public class MathModule : ModuleBase<SocketCommandContext>
        {
           
            [Command("multiply")]
            [Summary("Get the product of two numbers.")]
            public async Task Say(int a, int b)
            {
                int product = a * b;
                await ReplyAsync($"The product of `{a} * {b}` is `{product}`.");
            }

            [Command("addmany")]
            [Summary("Get the sum of many numbers")]
            public async Task Say(params int[] numbers)
            {
                int sum = numbers.Sum();
                await ReplyAsync($"The sum of `{string.Join(", ", numbers)}` is `{sum}`.");
            }
        }




    }
}
