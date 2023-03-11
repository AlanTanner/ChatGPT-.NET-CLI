using ChatGPT_.NET_CLI.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenAI.GPT3.Extensions;
using OpenAI.GPT3.Interfaces;

try
{
    var builder = new ConfigurationBuilder().AddUserSecrets<Program>();
    IConfiguration configuration = builder.Build();

    var serviceCollection = new ServiceCollection();
    serviceCollection.AddScoped(_ => configuration);

    serviceCollection.AddOpenAIService();

    var serviceProvider = serviceCollection.BuildServiceProvider();
    var sdk = serviceProvider.GetRequiredService<IOpenAIService>();

    //this message is the starting prompt for chatGPT
    string systemMessage = "Introduce yourself";

    await ChatGPT.RunChat(sdk, systemMessage);
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(ex.Message);
    Console.ResetColor();
}
