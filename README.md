# ChatGPT-.NET-CLI
![Build/Test](https://github.com/AlanTanner/ChatGPT-.NET-CLI/actions/workflows/dotnet.yml/badge.svg) ![visitors](https://visitor-badge.glitch.me/badge?page_id=AlanTanner.ChatGPT-.NET-CLI)

> :warning: You will need an OpenAI API to build this app


This is a basic .NET command line client for OpenAI's chatGPT. It uses the unoffical OPENAI .NET SDK [betalgo/openai](https://github.com/betalgo/openai) created by [Betalgo](https://github.com/betalgo).

### Defult Settings

1. Currently set ot use the ChatGPT 3.5-Turbo model.
2. ChatGPT replies are in green, while user input are in white.
3. The first system param set for ChatGPT is "Introduce yourself".

<img width="717" alt="Screenshot 2023-03-11 at 6 06 56 PM" src="https://user-images.githubusercontent.com/8541450/224515497-a2da8f16-1ffc-4434-9ffe-bf7603f5d01d.png">

## Requirement 
1. An active [OpenAI API key](https://openai.com/blog/openai-api)
2. [.NET 7](https://dotnet.microsoft.com/en-us/download/dotnet/7.0) Installed on your machine to build the app

## Getting Started
1. open the Cmd or Terminal to the base folder '/ChatGPT-.NET-CLI'
2. ensure that .NET & is installed

## Store OpenAI API keys
1. added the API key to your user secrets
```shell
dotnet user-secrets init
dotnet user-secrets set "OpenAIServiceOptions:ApiKey" "YOUR_OPENAI_API_KEY"
```
## Build The Project
1. build the project
```shell
dotnet build ChatGPT-.NET-CLI.sln
```
2. Currently it is set to build to the '/bin/Debug/net7.0' folder

## Start the app
1. From the base folder you can run the following
```shell
dotnet run bin/Debug/net7.0/ChatGPTDemo
```
