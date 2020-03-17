using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TBH.UpdateHandler
{
    /// <summary>
    /// Interface for each proccessor class.
    /// </summary>
    public interface iUpdate
    {
        /// <summary>
        /// Fill this for every proccess class that you have
        /// </summary>
        Trigger Trigger { get; }

        /// <summary>
        /// Proccess triggerd update here.
        /// </summary>
        /// <param name="Client">The bot Client that sent update.</param>
        /// <param name="update">Recieved update from Client.</param>
        /// <param name="CustomData">Every Custom data that you want to send to proccessor.</param>
        /// <returns>return true if proccess id done.</returns>
        Task<bool> ProccessUpdateAsync(TelegramBotClient client, Update newupdate, string CustomData);
    }

    /// <summary>
    /// Detacts where most proccess current update.
    /// </summary>
    public class Trigger
    {
        public UpdateType UpdateType { get; set; }
        public string[] TextTriggers { get; set; }
    }
}
