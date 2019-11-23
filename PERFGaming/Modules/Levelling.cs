using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PERFGaming;
using Discord;
using Discord.Commands;

namespace PERFGaming.Modules
{
    internal static class Levelling 
    {
        internal static async void UserSentMessage(SocketGuildUser user, SocketTextChannel channel)
        {
            if (user.Guild.Id == 348854075137327104)
            {
                var userAccount = UserAccounts.GetAccount(user);
                uint oldLevel = userAccount.LevelNumber;
                userAccount.XP += 50;
                UserAccounts.SaveAccounts();
                uint newLevel = userAccount.LevelNumber;

                if (oldLevel != userAccount.LevelNumber)
                {
                    if (channel.Id == 372375578155810816)
                    {
                        userAccount.XP += 50;
                        UserAccounts.SaveAccounts();

                    }
                    else if (user.Guild.Id == 295136411357544448)
                    {
                        await user.Guild.GetTextChannel(409647814008766474).SendMessageAsync("Sorry, I can't work here");
                    }
                    else
                    {
                        var embed = new EmbedBuilder();
                        embed.WithColor(67, 160, 71);
                        embed.WithTitle("LEVEL UP!");
                        embed.ThumbnailUrl = user.GetAvatarUrl();
                        embed.WithDescription(user.Username + " just leveled up!");
                        embed.AddInlineField("LEVEL", newLevel);
                        embed.AddInlineField("XP", userAccount.XP);
                        await user.Guild.GetTextChannel(410389794049359872).SendMessageAsync("", false, embed: embed);
                    }
                }

                if (userAccount.LevelNumber == 100)
                {
                    var role = user.Guild.Roles.FirstOrDefault(x => x.Name == "CONDITIONAL MODERATOR");
                    await (user as IGuildUser).AddRoleAsync(role);
                    var embed = new EmbedBuilder();
                    embed.WithTitle("Promotion");
                    embed.ThumbnailUrl = user.GetAvatarUrl();
                    embed.WithDescription(user.Username + "Congratulations, you have been promoted to CONDITIONAL MODERATOR role for being active and reaching lv 100");
                    embed.WithColor(new Color(255, 171, 0));
                    await user.Guild.GetTextChannel(410983760742318082).SendMessageAsync("", false, embed: embed);
                }
            }
            else
                return;
        }
       
    }
}

