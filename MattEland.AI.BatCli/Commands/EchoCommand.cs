using JetBrains.Annotations;
using Microsoft.Extensions.AI;
using Spectre.Console;
using Spectre.Console.Cli;

namespace MattEland.AI.BatCli.Commands;

[UsedImplicitly]
public class EchoCommand(IAnsiConsole console, IChatClient chatClient) : AsyncCommand<EchoCommand.Settings>
{
    [UsedImplicitly]
    public sealed class Settings : CommandSettings
    {
        [CommandArgument(0, "[message]")]
        public string? Message { get; [UsedImplicitly] init; }
    }

    public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        string userInput;
        if (string.IsNullOrWhiteSpace(settings.Message))
        {
            console.MarkupLine("[yellow]Enter a message to send to the echo chat client:[/]");
            userInput = console.Ask<string>($"[green]{ChatRole.User}:[/]");
        }
        else
        {
            userInput = settings.Message;
        }

        ChatMessage message = new(ChatRole.User, userInput);
        ChatResponse response = await chatClient.GetResponseAsync(message);

        foreach (ChatMessage responseMessage in response.Messages)
        {
            console.MarkupLine($"[cyan]{responseMessage.Role}:[/] {responseMessage.Text}");
        }    
        
        return 0;
    }
}
