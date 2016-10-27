using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using System.Text;

namespace DemozoneZLuisBot.Dialogs
{
    [Serializable]
    //[LuisModel("f9e34d22-d88d-4e5b-99b0-f0589c9671a0", "3cea665036ba4a5a92f0026694e70c7c")]    
    [LuisModel("eb5fee16-6e98-4d4f-ab18-f6b835ca237f", "3cea665036ba4a5a92f0026694e70c7c")]        
    public class LuisRootDialog : LuisDialog<object>
    {

        [LuisIntent("None")]
        public async Task None(IDialogContext context, IAwaitable<IMessageActivity> activity, LuisResult result)
        {
            await context.PostAsync("Je n'ai pas compris la requête");
            context.Wait(this.MessageReceived);
        }


        [LuisIntent("ChercherFichiers")]
        public async Task Search(IDialogContext context, IAwaitable<IMessageActivity> activity, LuisResult result)
        {

            var message = await activity;

            string formatResult = FormatLuisResult(result);
            await context.PostAsync(formatResult);

            context.Wait(this.MessageReceived);


        }

        private string FormatLuisResult(LuisResult result)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("# OriginalQuery");
            sb.AppendLine();
            sb.Append($"{result.Query}");
            sb.AppendLine();
            sb.AppendLine("## Intents");
            var allIntents = result.Intents;
            foreach(var intent in allIntents)
            {
                sb.AppendLine();
                sb.AppendLine($"Name : {intent.Intent}");
                sb.AppendLine();
                sb.AppendLine($"Score : {intent.Score}");
            }
            
            sb.AppendLine();

            var allEntities = result.Entities;
            sb.Append("### Entities");

            foreach (var entity in allEntities)
            {
                sb.AppendLine();
                sb.Append($"1. Name : {entity.Entity}");
                sb.AppendLine();
                sb.Append($"2. Score : {entity.Score}");
                sb.AppendLine();                
                
            }
            return sb.ToString();
        }
    }
}