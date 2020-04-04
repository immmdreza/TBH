using HelloWorldTBH.Proccessors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBH.UpdateHandler;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace HelloWorldTBH
{
    class Program
    {
        private static TelegramBotClient Client;
        private static User ME;

        static async Task Main(string[] args)
        {

            Client = new TelegramBotClient("1137273792:AAHt6N70TGK-n4EzOUub-WKD8njkXF7i4OI");

            ME = await Client.GetMeAsync();
            Console.Title = ME.FirstName;

            Client.OnUpdate += On_Update;

            TBH.Variables.UpdatesList.Add(new SayHello());
            TBH.Variables.UpdatesList.Add(new HelloCalls());

            Client.StartReceiving(new[] { UpdateType.Message, UpdateType.CallbackQuery });

            Console.WriteLine("Receiving update from " + ME.Username);

            Console.ReadLine();
            Client.StartReceiving();
        }

        private static async void On_Update(object sender, Telegram.Bot.Args.UpdateEventArgs e)
        {
            var Client = (TelegramBotClient)sender;
            iUpdate finder = null;
            var customdata = new Dictionary<string, object>();

            switch (e.Update.Type)
            {
                case UpdateType.Message:
                    {
                        finder = TBH.Variables.UpdatesList
                            .Where(x => x.Trigger.UpdateType == UpdateType.Message)
                            .FirstOrDefault(x => x.Trigger.TextTriggers.Any(c => c == e.Update.Message.Text.ToLower()));

                        customdata.Add("LangCode", e.Update.Message.From.LanguageCode);
                        break;
                    }
                case UpdateType.CallbackQuery:
                    {
                        finder = TBH.Variables.UpdatesList
                            .Where(x => x.Trigger.UpdateType == UpdateType.CallbackQuery)
                            .FirstOrDefault(x => e.Update.CallbackQuery.Data.StartsWith(x.Trigger.TextTriggers[0]));

                        customdata.Add("LangCode", e.Update.CallbackQuery.From.LanguageCode);
                        break;
                    }
                default:
                    break;
            }

            using (Proccessor proccessor = new Proccessor(finder,Client,e.Update,customdata))
            {
                if(finder is null) { return; }

                await proccessor.Proccess().ConfigureAwait(false);
            }
        }
    }
}
