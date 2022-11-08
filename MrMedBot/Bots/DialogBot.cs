// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio CoreBot v4.18.1

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using Microsoft.Extensions.Logging;

namespace MrMedBot.Bots
{
    // This IBot implementation can run any type of Dialog. The use of type parameterization is to allows multiple different bots
    // to be run at different endpoints within the same project. This can be achieved by defining distinct Controller types
    // each with dependency on distinct IBot types, this way ASP Dependency Injection can glue everything together without ambiguity.
    // The ConversationState is used by the Dialog system. The UserState isn't, however, it might have been used in a Dialog implementation,
    // and the requirement is that all BotState objects are saved at the end of a turn.
    public class DialogBot<T> : ActivityHandler
        where T : Dialog
    {
#pragma warning disable SA1401 // Fields should be private
        protected readonly Dialog Dialog;
        protected readonly BotState ConversationState;
        protected readonly BotState UserState;
        protected readonly ILogger Logger;
#pragma warning restore SA1401 // Fields should be private

        public DialogBot(ConversationState conversationState, UserState userState, T dialog, ILogger<DialogBot<T>> logger)
        {
            ConversationState = conversationState;
            UserState = userState;
            Dialog = dialog;
            Logger = logger;
        }

        public override async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default(CancellationToken))
        {
            await base.OnTurnAsync(turnContext, cancellationToken);

            // Save any state changes that might have occurred during the turn.
            await ConversationState.SaveChangesAsync(turnContext, false, cancellationToken);
            await UserState.SaveChangesAsync(turnContext, false, cancellationToken);

            /*var reply = MessageFactory.Text("");

            reply.SuggestedActions = new SuggestedActions()*/
            var card = new ReceiptCard
            {
                /*Buttons = new List<CardAction>()
                {
                    *//*new CardAction() { Title = "What is your helpline number Mr. Med?", Type = ActionTypes.ImBack, Value = "What is your helpline number Mr. Med?" },
                    new CardAction() { Title = "What is your dial number of Ambulance?", Type = ActionTypes.ImBack, Value = "What is your dial number of Ambulance?"},
                    new CardAction() { Title = "I Want to know about Prescription?", Type = ActionTypes.ImBack, Value = "I Want to know about Prescription?"},
                       new CardAction() { Title = "Is This Enough ? Or Want To know More?", Type = ActionTypes.ImBack, Value = "Is This Enough ? Or Want To know More?"},*//*
                },*/
            };
            var reply = MessageFactory.Attachment(card.ToAttachment());
            await turnContext.SendActivityAsync(reply, cancellationToken);



            if (turnContext.Activity.Text == "What is your helpline number Mr. Med?")
            {
                await turnContext.SendActivityAsync($"9898121270");
                var AfterHelplineCard = new HeroCard
                {
                    Buttons = new List<CardAction>()
                    {
                         new CardAction() { Title = "What is your dial number of Ambulance?", Type = ActionTypes.ImBack, Value = "What is your dial number of Ambulance?"},
                         new CardAction() { Title = "Please tell me about your services.", Type = ActionTypes.ImBack, Value = "Please tell me about your services."},
                         new CardAction() { Title = "List of available departments.", Type = ActionTypes.ImBack, Value = "List of available departments."},
                         new CardAction() { Title = "I have some other query.", Type = ActionTypes.ImBack, Value = "I have some other query."},
                         new CardAction() { Title = "Exit", Type = ActionTypes.ImBack, Value = "Exit"},
                    },
                };
                reply = MessageFactory.Attachment(AfterHelplineCard.ToAttachment());
                await turnContext.SendActivityAsync(reply, cancellationToken);
            }




            if (turnContext.Activity.Text == "What is your dial number of Ambulance?")
            {
                await turnContext.SendActivityAsync($"108");
                var AfterAmbulanceCard = new HeroCard
                {
                    Buttons = new List<CardAction>()
                    {
                         new CardAction() { Title = "What is your helpline number Mr. Med?", Type = ActionTypes.ImBack, Value = "What is your helpline number Mr. Med?"},
                         new CardAction() { Title = "Please tell me about your services.", Type = ActionTypes.ImBack, Value = "Please tell me about your services."},
                         new CardAction() { Title = "List of available departments.", Type = ActionTypes.ImBack, Value = "List of available departments."},
                         new CardAction() { Title = "I have some other query.", Type = ActionTypes.ImBack, Value = "I have some other query."},
                         new CardAction() { Title = "Exit", Type = ActionTypes.ImBack, Value = "Exit"},
                    },
                };
                reply = MessageFactory.Attachment(AfterAmbulanceCard.ToAttachment());
                await turnContext.SendActivityAsync(reply, cancellationToken);
            }




            if (turnContext.Activity.Text == "Please tell me about your services.")
            {
                await turnContext.SendActivityAsync($"We provide the following services : \r\n Emergency room services \r\n Short-term hospitalization \r\n X-ray/radiology services \r\n General and specialty surgical services \r\n Blood services \r\n Laboratory services \r\n Pediatric specialty care \r\n Prescription services \r\n Rehabilitation services and physical therapy \r\n Home nursing services \r\n Nutritional counseling \r\n Mental health care \r\n Nutritional counseling");
                var AfterPrescriptionCard = new HeroCard
                {
                    Buttons = new List<CardAction>()
                    {
                         new CardAction() { Title = "What is your helpline number Mr. Med?", Type = ActionTypes.ImBack, Value = "What is your helpline number Mr. Med?"},
                         new CardAction() { Title = "What is your dial number of Ambulance?", Type = ActionTypes.ImBack, Value = "What is your dial number of Ambulance?"},
                         new CardAction() { Title = "List of available departments.", Type = ActionTypes.ImBack, Value = "List of available departments."},
                         new CardAction() { Title = "I have some other query.", Type = ActionTypes.ImBack, Value = "I have some other query."},
                         new CardAction() { Title = "Exit", Type = ActionTypes.ImBack, Value = "Exit"},
                    },
                };
                reply = MessageFactory.Attachment(AfterPrescriptionCard.ToAttachment());
                await turnContext.SendActivityAsync(reply, cancellationToken);
            }
            if (turnContext.Activity.Text == "I have some other query.")
            {
                await turnContext.SendActivityAsync($"Our executive will call you shortly on your registered mobile number!");
                var AfterPrescriptionCard = new HeroCard
                {
                    Buttons = new List<CardAction>()
                    {
                         new CardAction() { Title = "What is your helpline number Mr. Med?", Type = ActionTypes.ImBack, Value = "What is your helpline number Mr. Med?"},
                         new CardAction() { Title = "What is your dial number of Ambulance?", Type = ActionTypes.ImBack, Value = "What is your dial number of Ambulance?"},
                         new CardAction() { Title = "Please tell me about your services.", Type = ActionTypes.ImBack, Value = "Please tell me about your services."},
                         new CardAction() { Title = "List of available departments.", Type = ActionTypes.ImBack, Value = "List of available departments."},
                         new CardAction() { Title = "Exit", Type = ActionTypes.ImBack, Value = "Exit"},
                    },
                };
                reply = MessageFactory.Attachment(AfterPrescriptionCard.ToAttachment());
                await turnContext.SendActivityAsync(reply, cancellationToken);
            }



            if (turnContext.Activity.Text == "List of available departments.")
            {
                await turnContext.SendActivityAsync($"Outpatient department (OPD) \r\n Surgical department \r\n Inpatient service (IP) \r\n Nursing department \r\n Physical medicine \r\n Paramedical department \r\n Rehabilitation department \r\n Dietary department \r\n Pharmacy department \r\n Operation theater complex (OT) \r\n Radiology department (X-ray) \r\n Non-professional services");
                var AfterPrescriptionCard = new HeroCard
                {
                    Buttons = new List<CardAction>()
                    {
                         new CardAction() { Title = "What is your helpline number Mr. Med?", Type = ActionTypes.ImBack, Value = "What is your helpline number Mr. Med?"},
                         new CardAction() { Title = "What is your dial number of Ambulance?", Type = ActionTypes.ImBack, Value = "What is your dial number of Ambulance?"},
                         new CardAction() { Title = "Please tell me about your services.", Type = ActionTypes.ImBack, Value = "Please tell me about your services."},
                         new CardAction() { Title = "I have some other query.", Type = ActionTypes.ImBack, Value = "I have some other query."},
                         new CardAction() { Title = "Exit", Type = ActionTypes.ImBack, Value = "Exit"},
                    },
                };
                reply = MessageFactory.Attachment(AfterPrescriptionCard.ToAttachment());
                await turnContext.SendActivityAsync(reply, cancellationToken);
            }

          




            if (turnContext.Activity.Text == "Exit")
            {
                await turnContext.SendActivityAsync($"Thats Enough ! Thank You For Your Knowledge.");
                
                //await turnContext.SendActivityAsync(reply, cancellationToken);
            }

        }
    

        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            Logger.LogInformation("Running dialog with Message Activity.");

            // Run the Dialog with the new message Activity.
            await Dialog.RunAsync(turnContext, ConversationState.CreateProperty<DialogState>("DialogState"), cancellationToken);
        }
    }
}
