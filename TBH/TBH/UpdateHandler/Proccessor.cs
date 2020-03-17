using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TBH.UpdateHandler
{
    public class Proccessor : IDisposable
    {
        private iUpdate iupdate;
        private Update newupdate;
        private TelegramBotClient client;
        private string lc;

        /// <summary>
        /// Proccessor :)
        /// </summary>
        /// <param name="iupdate">iupdate class that is target.</param>
        /// <param name="Client">sender of update</param>
        /// <param name="update">Update itself</param>
        /// <param name="CustomData">Custom data</param>
        public Proccessor(iUpdate iupdate, TelegramBotClient Client, Update update, string CustomData)
        {
            this.iupdate = iupdate;
            client = Client;
            newupdate = update;
            lc = CustomData;
        }


        /// <summary>
        /// proccess given update.
        /// </summary>
        /// <returns>if proccess is done.</returns>
        public async Task<bool> Proccess() => await iupdate.ProccessUpdateAsync(client, newupdate, lc);

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.
                lc = null;
                client = null;
                newupdate = null;
                iupdate = null;

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~Proccessor() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }

}
