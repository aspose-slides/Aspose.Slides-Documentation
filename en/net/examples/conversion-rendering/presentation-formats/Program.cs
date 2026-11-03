using System.Threading.Tasks;
using System;
using System.Linq;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    private static Task<int> Main(string[] args) => RunChecked(args);
    private static void ConvertFormats(bool licensed)
    {
        using var source = CreateSource(licensed);
        source.Save("source.pptx", SaveFormat.Pptx);
        (SaveFormat Format, string Extension)[] formats = [(SaveFormat.Pptx, "pptx"), (SaveFormat.Ppt, "ppt"), (SaveFormat.Odp, "odp")];
        int checks = 0;
        foreach (var(format, extension)in formats)
        {
            string convertedPath = "converted." + extension;
            source.Save(convertedPath, format);
            using var reopened = new Presentation(convertedPath);
            if (reopened.Slides.Count != 4)
                throw new InvalidOperationException("Slide count changed in " + extension);
            string text = string.Join(" ", reopened.Slides.SelectMany(s => s.Shapes.OfType<IAutoShape>()).Select(s => s.TextFrame.Text));
            if (!text.Contains("Alpha") || !text.Contains(licensed ? "Hidden" : "Hide"))
                throw new InvalidOperationException("Text changed in " + extension);
            reopened.Save("from-" + extension + ".pptx", SaveFormat.Pptx);
            using var preview = reopened.Slides[0].GetImage(new Size(320, 180));
            preview.Save("preview-" + extension + ".png", Aspose.Slides.ImageFormat.Png);
            checks++;
        }

        Report(new { formats_checked = checks, slides_per_deck = 4 });
    }
}
