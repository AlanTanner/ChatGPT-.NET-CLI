
using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ChatGPT_.NET_CLI.Helpers
{
    internal class ChatGPT
    {
        public static async Task RunChat(IOpenAIService sdk, string systemPrompt)
        {
            Console.WriteLine("Chat Completion starting:");
            try
            {
                var history = new List<ChatMessage>
                {
                    new(StaticValues.ChatMessageRoles.System, systemPrompt)
                };
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                    var completionResult = sdk.ChatCompletion.CreateCompletionAsStream(new ChatCompletionCreateRequest
                    {
                        Messages = history,
                        Model = Models.ChatGpt3_5Turbo
                    });

                    StringBuilder stringBuilder = new StringBuilder();
                    await foreach (var completion in completionResult)
                    {
                        if (completion.Successful)
                        {
                            string reply = completion.Choices.First().Message.Content;
                            Console.Write(reply);
                            stringBuilder.Append(reply);
                        }
                        else
                        {
                            if (completion.Error == null)
                            {
                                throw new Exception("Unknown Error");
                            }
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"{completion.Error.Code}: {completion.Error.Message}");
                            break;
                        }
                    }
                    Console.ResetColor();
                    Console.Write("\n\n");

                    //save response from chatGPT
                    history.Add(new(StaticValues.ChatMessageRoles.Assistant, stringBuilder.ToString()));
                    
                    string? message = string.Empty;
                    do
                    {
                        message = Console.ReadLine();
                    } while (string.IsNullOrEmpty(message));
                    Console.Write('\n');
                    history.Add(new(StaticValues.ChatMessageRoles.User, message));

                    //if user types exit, end the chat
                    if (string.Equals(message, "exit", StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


    }
}