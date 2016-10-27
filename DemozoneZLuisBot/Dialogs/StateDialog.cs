using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;

namespace DemozoneZLuisBot.Dialogs
{
    [Serializable]
    public class StateDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }
        public virtual async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;
            string userName;

            // First try to peek the name of the user
            if (!context.UserData.TryGetValue(ContextConstants.UserNameKey, out userName))
            {
                PromptDialog.Text(context, this.ResumeAfterPrompt, "Before get started, please tell me your name?");
                return;
            }

            await context.PostAsync($"Hello again: {userName}");
            context.Wait(MessageReceivedAsync);
        }
        private async Task ResumeAfterPrompt(IDialogContext context, IAwaitable<string> result)
        {

            var userName = await result;
            await context.PostAsync($"Welcome {userName}");

            //Save the name
            context.UserData.SetValue(ContextConstants.UserNameKey, userName);
            context.Wait(MessageReceivedAsync);
        }
    }
}