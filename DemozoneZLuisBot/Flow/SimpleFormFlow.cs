using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemozoneZLuisBot.Flow
{
    public enum SelectionLevel1
    {
        Selection1, Selection2, Selection3
    }
    public enum SelectionLevel3
    {
        Selection111, Selection222, Selection333
    }
    public enum SelectionLevel2
    {
        Selection11, Selection22, Selection33
    }
    [Serializable]
    public class SimpleFormFlow
    {
        [Prompt("Quelle {&} voulez-vous ? {||}")]
        public SelectionLevel1? SelectionL1;
        public SelectionLevel2? SelectionL2;
        public SelectionLevel3? SelectionL3;

        public static IForm<SimpleFormFlow> BuildSimpleFlowForm()
        {
            //Step 1
            return new FormBuilder<SimpleFormFlow>()
               .Message("Bienvenue dans ce flow simple !")
               .Build();

            //return new FormBuilder<SimpleFormFlow>()
            //    .Message("Bienvenue dans ce flow simple !")
            //    .Field(nameof(SelectionL1))
            //    .Field(nameof(SelectionL2))
            //    .Field(nameof(SelectionL3))
            //    .Confirm(async (state) =>
            //    {
            //        string[] choix = new string[3];
            //        choix[0] = state.SelectionL1.Value.ToString();
            //        choix[1] = state.SelectionL2.Value.ToString();
            //        choix[2] = state.SelectionL3.Value.ToString();
            //        return new PromptAttribute(choix);
            //    })
            //    .Build();

        }
    }
}