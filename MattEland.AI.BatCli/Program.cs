using MattEland.AI.BatCli.Commands;
using MattEland.AI.BatCli.Helpers;
using MattEland.AI.BatCli.Infrastructure;
using MattEland.AI.BatLogic;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Spectre.Console;
using Spectre.Console.Cli;

try
{
    IAnsiConsole console = AnsiConsole.Console;
    console.DisplayLogo();

    // If the user didn't specify any arguments, prompt them now
    if (args.Length == 0)
    {
        console.MarkupLine($"[{Styles.WarningColor}]No arguments were specified. Please enter a command:[/]");
        string? input = console.Ask<string>($"[{Styles.PromptColor}]Command:[/]");
        args = input?.Split(' ') ?? [];
    }
    
    ServiceCollection services = new();
    services.AddSingleton<IChatClient, EchoChatClient>();
    services.AddSingleton<IAnsiConsole>(_ => AnsiConsole.Console);

    AlfredTypeRegistrar registrar = new(services);

    CommandApp app = new(registrar);
    app.Configure(config =>
    {
        config.CaseSensitivity(CaseSensitivity.None);
        config.SetApplicationName("Alfred");

        config.AddCommand<RandomCommand>("random")
            .WithAlias("rand")
            .WithAlias("roll");

        // TODO: Weather
        
        // TODO: Projects
        
        // TODO: Tasks
        
        // TODO: Git Analysis
        
        // TODO: AsMCP Server
        
        config.AddCommand<EchoCommand>("echo")
            .WithDescription("Echoes a message back to the user");

        config.SetExceptionHandler((ex, _) =>
        {
            if (ex is CommandRuntimeException runtimeEx)
            {
                AnsiConsole.MarkupInterpolated($"[Red]{runtimeEx.Message}[/]");
                return -2;
            }

            AnsiConsole.WriteException(ex, ExceptionFormats.ShortenEverything);
            return -1;
        });
    });
    return app.Run(args);
}
catch (Exception ex)
{
    AnsiConsole.WriteException(ex, ExceptionFormats.ShortenEverything);
    return -3;
}
