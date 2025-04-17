using Spectre.Console;

namespace MattEland.AI.BatCli.Helpers;

public static class DisplayHelpers
{
    public static void DisplayLogo(this IAnsiConsole console)
    {
        FigletFont font = FigletFont.Load("Doom.flf");
        console.Write(new FigletText(font, "ALFRED").Color(Color.Yellow1).Justify(Justify.Center));
        console.Write(new Rule("[white]By[/] [cyan]Matt Eland[/]").RuleStyle("blue").Justify(Justify.Center));
        console.WriteLine();
    }
}
