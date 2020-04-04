using System.Collections.Generic;
using System.Threading.Tasks;
using TBH.UpdateHandler;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace HelloWorldTBH.Proccessors
{
    class HelloCalls : iUpdate
    {
        Trigger iUpdate.Trigger =>
            new Trigger { TextTriggers = new List<string> { "H" }, UpdateType = UpdateType.CallbackQuery };

        async Task<bool> iUpdate.ProccessUpdateAsync(TelegramBotClient client, Update newupdate, Dictionary<string, object> customData)
        {
            CallbackQuery callBackQuery = newupdate.CallbackQuery;

            string parts = callBackQuery.Data.Replace("H", "");
            switch (parts)
            {
                case "1":
                    {
                        await client.AnswerCallbackQueryAsync(
                            callBackQuery.Id,
                            "Why so happy?!",
                            true);

                        return true;
                    }
                case "2":
                    {
                        await client.AnswerCallbackQueryAsync(
                            callBackQuery.Id,
                            "Why so Sad?!",
                            true);

                        return true;
                    }

                default: return false;
            }
        }
    }
}
