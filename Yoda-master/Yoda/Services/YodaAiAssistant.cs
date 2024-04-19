﻿using Azure;
using Azure.AI.OpenAI;
using Yoda.Config;
using Yoda.Models;
using Yoda.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoda.Services
{
    public class YodaAiAssistant : IAiAssistant
    {
        private ISettings _settings;
        private const string AssistantBehaviorDescription = "Master Yoda I am. Advice, fun facts and jokes I do tell.";
        private string YodaAiAssistantBehaviorDescription = AssistantBehaviorDescription;
        public YodaAiAssistant(ISettings settings)
        {
            _settings = settings;
        }

        //private IList<ChatRequestMessage> BuildChatContext(IList<ChatMessage> chatInboundHistory, ChatMessage userMessage)
        //{
        //    var chatContext = new List<ChatRequestMessage>();

        //    chatContext.Add(new ChatRequestSystemMessage(AssistantBehaviorDescription));

        //    foreach (var chatMessage in chatInboundHistory)
        //        chatContext.Add(new ChatRequestAssistantMessage(chatMessage.MessageBody));

        //    chatContext.Add(new ChatRequestUserMessage(userMessage.MessageBody));

        //    return chatContext;

        //}

        public async Task<ChatMessage> GetCompletion()
        {
              //var messages = BuildChatContext(chatInboundHistory, userMessage);
            try
            { 
            var client = new OpenAIClient(new Uri(_settings.AzureOpenAiEndPoint), new AzureKeyCredential(_settings.AzureOpenAiKey));
            string deploymentName = "starwarsyodachat";
            //string searchIndex = "finder";
                string fact = "Give me a fun fact";

                var chatCompletionsOptions = new ChatCompletionsOptions()
                {
                    Messages =
                    {
                       /* new ChatRequestSystemMessage ("You are an AI bot that emulates a Master Yoda writing assistant who speaks in a Yoda style. You offer advice, fun facts and tell jokes. \r\nHere are some example of Master Yoda's style:\r\n - Patience you must have my young Padawan.\r\n - In a dark place we find ourselves, and a little more knowledge lights our way.\r\n - Once you start down the dark path, forever will it dominate your destiny. Consume you, it will."),
                        new ChatRequestUserMessage ("Greetings Young Padawan. Patience you must have, for answers I shall provide."),*/
                        new ChatMessage(ChatRole.System,YodaAiAssistantBehaviorDescription),
                        new ChatMessage(ChatRole.User, fact),
                    },
                };
                Response<ChatCompletions> response = await client.GetChatCompletionsAsync(deploymentName, chatCompletionsOptions);
                ChatMessage responseMessage = response.Value.Choices[0].Message;

                return responseMessage;

            }
            catch (Exception ex)
            {

            }

            return null;
        }

        //foreach (var message in messages)
        //    chatCompletionsOptions.Messages.Add(message);

        //Response<ChatCompletions> response = client.GetChatCompletions(chatCompletionsOptions);

        //ChatResponseMessage responseMessage = response.Value.Choices[0].Message;

        //return responseMessage;

    }
}
