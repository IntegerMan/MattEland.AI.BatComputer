using MattEland.AI.BatCli.Helpers;
using MattEland.AI.BatLogic;
using Microsoft.Extensions.AI;
using Spectre.Console;

IAnsiConsole console = AnsiConsole.Console;

// Figlet logo
console.DisplayLogo();
IChatClient chatClient = new EchoChatClient();

// Get a message from the user
console.MarkupLine("[yellow]Enter a message to send to the echo chat client:[/]");
string userInput = console.Ask<string>($"[green]{ChatRole.User}:[/]");

ChatMessage message = new(ChatRole.User, userInput);
ChatResponse response = await chatClient.GetResponseAsync(message);

foreach (ChatMessage responseMessage in response.Messages)
{
    console.MarkupLine($"[cyan]{responseMessage.Role}:[/] {responseMessage.Text}");
}
