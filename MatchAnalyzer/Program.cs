using Discord.Webhook;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MatchAnalyzer
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // Rank - RocketStats_RankName.txt
            // MMR - RocketStats_MMR.txt
            // Wins - RocketStats_Win.txt
            // Loss - RocketStats_Loss.txt
            // Streak - RocketStats_Streak.txt
            
            string folderpath = AppDomain.CurrentDomain.BaseDirectory;
            Console.Title = "Match Analyzer - KingVon.pub";
            Console.WriteLine("Match Analyzer - made by ryan");
            Console.Write("\nIf you have purchased this, you have been");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" SCAMMED ");
            Console.ResetColor();
            Console.WriteLine("\ndiscord.gg/7SFRgk3yQP");
            string webhook = File.ReadAllText(folderpath + "\\webhook.txt");
            Console.WriteLine("\nPress Any key to start watching stats");
            Console.ReadKey();
            Console.WriteLine("Anaylzing Stats....");
            

            while (true)
            {
                var webhookObject = new WebhookObject();

                string filePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string rocketstats = Path.Combine(filePath + "\\bakkesmod\\bakkesmod\\data\\RocketStats");
                string rank = File.ReadAllText(rocketstats + "\\RocketStats_RankName.txt");
                string MMR = File.ReadAllText(rocketstats + "\\RocketStats_MMR.txt");
                string Wins = File.ReadAllText(rocketstats + "\\RocketStats_Win.txt");
                string Loss = File.ReadAllText(rocketstats + "\\RocketStats_Loss.txt");
                string Streak = File.ReadAllText(rocketstats + "\\RocketStats_Streak.txt");

                webhookObject.AddEmbed(builder =>
                {
                    builder.WithTitle("Match Analyzer - KingVon.pub")
                        .WithColor(Colors.Red)
                        .WithThumbnail("https://files.catbox.moe/8pvnib.png")
                        .AddField("Rank", $"`{rank}`")
                        .AddField("MMR", $"`{MMR}`")
                        .AddField("Streak", $"`{Streak}`")
                        .AddField("Wins", $"`{Wins}`")
                        .AddField("Losses", $"`{Loss}`");
                });

                await Webhook.SendAsync(webhook, webhookObject, "MatchAnalyzer", "https://files.catbox.moe/8pvnib.png");
                Thread.Sleep(60000);

            }
        }
    }
}
