using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;

namespace Bartlebot
{
    class MyBot
    {
        DiscordClient discord;
        CommandService commands;

        string[] imagePaths;

        public MyBot()
        {
            discord = new DiscordClient(x =>
            {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });

            discord.UsingCommands(x =>
            {
                x.PrefixChar = '!';
                x.AllowMentionPrefix = true;
            });

            commands = discord.GetService<CommandService>();

            RegisterCommands();

            discord.ExecuteAndWait(async () =>
            {
                await discord.Connect("Mjg3MzQ5ODEyMDI4NzY4MjU2.C5t_jA.RW5USgMK_O_pr1GvzK__oogzyM8", TokenType.Bot);
            });
        }

        private void RegisterCommands()
        {
            commands.CreateCommand("memes").Do(async (e) =>
                {
                    await e.Channel.SendMessage("fuck off Jon");
                });
        }

        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
