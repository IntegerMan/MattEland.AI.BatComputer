using System.Reflection;
using Spectre.Console;

namespace MattEland.AI.BatCli.Helpers;

public static class Styles
{
    private static FigletFont? _font;

    public static Lazy<FigletFont> DefaultFont { get; } = new(() =>
    {
        string combine = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "", "Doom.flf");
        return _font ??= FigletFont.Parse(File.ReadAllText(combine));
    });

    public static Color HeaderColor => Color.Yellow;
    public static Color FieldLabelColor => Color.Blue;
    public static Color AccentColor => Color.LightSalmon3;
    public static Color WarningColor => Color.Orange3;
    public static Color SuccessColor => Color.Green3;
    public static Color StructureColor => Color.SteelBlue;
    public static Style StructureStyle => new(StructureColor);
    public static Color PromptColor => Color.MediumOrchid;

    public static string AsHeader(this string text) 
        => $"[{HeaderColor}]{Markup.Escape(text)}[/]";    
    
    public static string AsFieldLabel(this object text) 
        => AsSecondary(text);

    public static string Accented(this object input) 
        => $"[{AccentColor}]{Markup.Escape(input.ToString() ?? "")}[/]";

    public static string Warning(this object input) 
        => $"[{WarningColor}]{Markup.Escape(input.ToString() ?? "")}[/]";
    
    public static string AsSecondary(this object text) 
        => $"[{FieldLabelColor}]{Markup.Escape(text.ToString() ?? "")}[/]";
    
    public static string AsSuccess(this object text) 
        => $"[{SuccessColor}]{Markup.Escape(text.ToString() ?? "")}[/]";

}
