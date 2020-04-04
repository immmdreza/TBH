using System.Collections.Generic;
using System.Threading.Tasks;
using TBH.UpdateHandler;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace HelloWorldTBH.Proccessors
{
    class SayHello : iUpdate
    {
        Trigger iUpdate.Trigger =>
            new Trigger { TextTriggers = new List<string> { "hello" }, UpdateType = UpdateType.Message };

        async Task<bool> iUpdate.ProccessUpdateAsync(TelegramBotClient client, Update newupdate, Dictionary<string, object> customData)
        {
            try
            {
                InlineKeyboardMarkup Keys = new InlineKeyboardMarkup(
                    new InlineKeyboardButton[][]
                    {
                        new InlineKeyboardButton[]{InlineKeyboardButton.WithCallbackData(":)","H1")},
                        new InlineKeyboardButton[]{InlineKeyboardButton.WithCallbackData(":(","H2")}
                    });

                Message message = newupdate.Message;

                if ((string)customData["LangCode"] == "fa")
                {
                    await client.SendTextMessageAsync(
                        message.Chat.Id,
                        "سلامممم",
                        replyMarkup: Keys);
                }
                else
                {
                    await client.SendTextMessageAsync(
                        message.Chat.Id,
                        "Hi there!",
                        replyMarkup: Keys);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
