using System.ComponentModel;
using System.Reflection;
using Spectre.Console;

namespace MattEland.AI.BatCli.Helpers;

public static class DisplayHelper
{
    public static string ToFriendlyName(this Enum value)
    {
        FieldInfo? fieldInfo = value.GetType().GetField(value.ToString());
        DescriptionAttribute[]? attributes =
            fieldInfo?.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

        if (attributes is null || attributes.Length == 0)
            return value.ToString();

        return attributes?[0].Description ?? value.ToString();
    }

    /*
    public static async Task DisplayImageAsync(this Uri? imageUri, int maxWidth = 30, bool showUrl = false)
    {
        if (imageUri is null)
            return;

        CanvasImage? image = await GetWebImageAsync(imageUri, maxWidth);

        if (image != null)
        {
            AnsiConsole.Write(image);
        }

        if (showUrl)
        {
            AnsiConsole.MarkupLine($"[Yellow]Image URL:[/] {Markup.Escape(imageUri.ToString())}");
        }
    }

    public static async Task<CanvasImage?> GetWebImageAsync(Uri imageUri, int maxWidth, bool logOnFailure = true)
    {
        try
        {
            using HttpClient webClient = new();
            await using Stream stream = await webClient.GetStreamAsync(imageUri);

            CanvasImage image = new(stream)
            {
                MaxWidth = maxWidth
            };
            return image;
        }
        catch (HttpRequestException ex)
        {
            if (logOnFailure)
            {
                AnsiConsole.MarkupLineInterpolated(
                    $"[Red]Could not download image '{imageUri}':[/] [Yellow]{ex.Message}[/]");
            }

            return null;
        }
    }

    public static void DisplayImage(this Stream imageStream, int maxWidth = 30)
        => AnsiConsole.Write(new CanvasImage(imageStream)
        {
            MaxWidth = maxWidth
        });

    public static void DisplayImage(this string imagePath, int maxWidth = 30)
        => AnsiConsole.Write(GetDiskImage(imagePath, maxWidth));

    public static CanvasImage GetDiskImage(string imagePath, int maxWidth = 30)
        => new(imagePath)
        {
            MaxWidth = maxWidth
        };
        */

    public static void WriteAsFigletText(this object input, Color? color = null, Justify? justify = null)
        => AnsiConsole.Write(AsFigletText(input, color, justify));

    public static FigletText AsFigletText(this object input, Color? color = null, Justify? justify = null)
    {
        string? text = input.ToString();

        return new(Styles.DefaultFont.Value, text ?? "")
        {
            Color = color ?? Styles.HeaderColor,
            Justification = justify,
            Pad = false
        };
    }
    
    public static void DisplayLogo(this IAnsiConsole console)
    {
        FigletFont font = Styles.DefaultFont.Value;
        console.Write(new FigletText(font, "ALFRED").Color(Color.Yellow1).Justify(Justify.Center));
        Version version = Assembly.GetEntryAssembly()!.GetName().Version!;
        console.Write(new Rule($"[Yellow]Command-line conversational AI utility by [SteelBlue]Matt Eland[/]. Version [SteelBlue]{version}[/].[/]").LeftJustified());
        console.WriteLine();
    }
}
