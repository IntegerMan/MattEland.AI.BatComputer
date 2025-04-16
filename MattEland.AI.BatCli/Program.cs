// See https://aka.ms/new-console-template for more information

using MattEland.AI.BatLogic;
using Microsoft.Extensions.AI;
using Spectre.Console;

IAnsiConsole console = AnsiConsole.Console;

// Figlet logo
console.Write(new FigletText("BatCLI"));
console.MarkupLine("[bold green]By Matt Eland[/]");
console.WriteLine();

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
