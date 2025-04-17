using MattEland.AI.BatCli.Commands;
using MattEland.AI.BatCli.Helpers;
using MattEland.AI.BatCli.Infrastructure;
using MattEland.AI.BatLogic;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Spectre.Console;
using Spectre.Console.Cli;

IAnsiConsole console = AnsiConsole.Console;
console.DisplayLogo();

ServiceCollection services = new();
services.AddSingleton<IChatClient, EchoChatClient>();
services.AddSingleton<IAnsiConsole>(_ => AnsiConsole.Console);

AlfredTypeRegistrar registrar = new(services);

CommandApp<EchoCommand> app = new CommandApp<EchoCommand>(registrar);
app.Run(args);
