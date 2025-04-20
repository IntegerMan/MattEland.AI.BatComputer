using System.ComponentModel;
using MattEland.AI.BatCli.Helpers;
using Spectre.Console;
using Spectre.Console.Cli;

namespace MattEland.AI.BatCli.Commands;

[Description("Generates a random number")]
public class RandomCommand : AsyncCommand<RandomCommand.Settings>
{
    private readonly Random _random = new();
    
    public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        if (settings.Min >= settings.Max)
        {
            AnsiConsole.MarkupLine("[Red]The minimum value must be less than the maximum value[/]");
            return 1;
        }
        
        int number = _random.Next(settings.Min, settings.Max + 1);
        
        Rows content = new(
            new Markup($"The random number between {settings.Min.AsFieldLabel()} and {settings.Max.AsFieldLabel()} is {number.Accented()}{Environment.NewLine}"),
            number.AsFigletText(Styles.AccentColor)
        );
        
        Panel panel = new(content)
        {
            Header = new PanelHeader("Random Number".AsHeader()),
            Padding = new Padding(2, 1, 2, 0),
            BorderStyle = Styles.StructureStyle
        };
        AnsiConsole.Write(new Padder(panel, new Padding(2,0)));
        
        await Task.CompletedTask;
        
        return 0;
    }
    
    public class Settings : CommandSettings
    {
        [CommandArgument(1, "[Max]"), Description("The maximum value for the random number")]
        public int Max { get; set; } = 6;
    
        [CommandOption("-m|--min <Min>"), Description("The minimum value for the random number")]
        public int Min { get; set; } = 1;    
    }
}
