using System.Threading.Tasks;
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    private static Task<int> Main(string[] args) => RunChecked(args);
    private static void EmbedFonts()
    {
        LoadVerifiedFonts("NotoSans-Regular.ttf");
        try
        {
            byte[] font = File.ReadAllBytes("fonts/NotoSans-Regular.ttf");
            foreach (bool full in new[]
            {
                true,
                false
            }

            )
            {
                using var p = new Presentation();
                p.SlideSize.SetSize(640, 360, SlideSizeScaleType.DoNotScale);
                var shape = Label(p.Slides[0], "Embedded Noto Sans");
                shape.Name = "sample";
                shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("Noto Sans");
                p.FontsManager.AddEmbeddedFont(font, full ? EmbedFontCharacters.All : EmbedFontCharacters.OnlyUsed);
                p.Save(full ? "full.pptx" : "used.pptx", SaveFormat.Pptx);
            }

            FontsLoader.ClearCache();
            Require(!FontsLoader.GetFontFolders().Any(folder => Path.GetFullPath(folder).StartsWith(AppContext.BaseDirectory, StringComparison.OrdinalIgnoreCase)), "An application font folder remains registered after ClearCache.");
            ValidateEmbeddedPayload("full.pptx", font, true);
            ValidateEmbeddedPayload("used.pptx", font, false);
            File.Delete("fonts/NotoSans-Regular.ttf");
            foreach (string file in new[]
            {
                "full.pptx",
                "used.pptx"
            }

            )
            {
                using var p = new Presentation(file);
                Require(p.FontsManager.GetEmbeddedFonts().Any(f => f.FontName == "Noto Sans"), "Embedded family missing in " + file);
                Require(p.Slides[0].Shapes.OfType<IAutoShape>().Single(s => s.Name == "sample").TextFrame.Text == Context.ExpectedText("Embedded Noto Sans"), "Text changed.");
                if (file == "full.pptx")
                    Render(p.Slides[0], "preview.png");
            }

            Require(!File.Exists("fonts/NotoSans-Regular.ttf"), "External font file still exists.");
            Report(new { full_embedded = true, used_embedded = true, reopened_without_external_file = true, text_retained = true });
        }
        finally
        {
            FontsLoader.ClearCache();
        }
    }
}
