using Discord;
using Discord.WebSocket;
using System;
using System.Resources;
using System.Threading.Tasks;

namespace GuildaRPG {
    class DiscordAPI
    {
        //public static void Main(string[] args) => new DiscordAPI().MainAsync().GetAwaiter().GetResult();

        private DiscordSocketClient _client;

        public async Task MainAsync()
        {
            try
            {
                var config = new DiscordSocketConfig()
                {
                    MessageCacheSize = 10,
                    LogLevel = LogSeverity.Verbose
                };

                using (_client = new DiscordSocketClient(config))
                {
                    _client.Log += Log;

                    _client.Ready += () =>
                    {
                        Console.WriteLine("= Ready=");
                        return Task.CompletedTask;
                    };

                    _client.MessageDeleted += OnMessageDeleted;
                    _client.MessageUpdated += OnMessageUpdated;
                    _client.MessageReceived += OnMessageReceived;

                    await _client.LoginAsync(TokenType.Bot, Properties.Resources.DISCORD_API_TOKEN);
                    await _client.StartAsync();

                    await Task.Delay(-1);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
                Environment.Exit(-1);
            }
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        private async Task OnMessageDeleted(Cacheable<IMessage, ulong> before, ISocketMessageChannel channel)
        {
            var message = await before.GetOrDownloadAsync();
            Console.WriteLine($"Deleted: {message}");
        }

        private async Task OnMessageUpdated(Cacheable<IMessage, ulong> before, SocketMessage after, ISocketMessageChannel channel)
        {
            var message = await before.GetOrDownloadAsync();
            Console.WriteLine($"{message} -> {after}");
        }

        private async Task OnMessageReceived(SocketMessage msg)
        {
            Console.WriteLine($"{msg}");
            if (msg is SocketUserMessage)
            {
                await ReactWithEmojiAsync((SocketUserMessage)msg);
                await ReactWithEmoteAsync((SocketUserMessage)msg, "<:dogu:615533972071645220>");
            }
        }

        private async Task ReactWithEmojiAsync(SocketUserMessage userMsg)
        {
            var emoji = new Emoji("\uD83D\uDC4C");
            await userMsg.AddReactionAsync(emoji);
            // :hordasimbolo:498694040410128385
        }

        private async Task ReactWithEmoteAsync(SocketUserMessage userMsg, string escapedEmote)
        {
            if (Emote.TryParse(escapedEmote, out var emote))
            {
                await userMsg.AddReactionAsync(emote);
            }
        }

    }
}
