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
    public class EchoPromptDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }
        private IEnumerable<string> Options = new List<string> { "Option1", "Option2", "Option3", "Option4" };
        public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            PromptDialog.Choice<string>(
                context, ResumeAfter, Options, "Select an option", "not a valid option", 2, PromptStyle.PerLine);
        }
        public async Task ResumeAfter(IDialogContext context, IAwaitable<string> result)
        {
            var selectedOption = await result;

            await context.PostAsync($"You choose: {selectedOption}");

            context.Wait(this.MessageReceivedAsync);
        }
    }
}