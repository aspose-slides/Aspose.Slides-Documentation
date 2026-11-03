using System.Threading.Tasks;
using System;
using System.IO;
using System.Linq;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

internal static partial class Program
{
    private static Task<int> Main(string[] args) => RunChecked(args);

    private static void ExportMarkdown(bool licensed)
    {
        using var source = CreateSource(licensed);
        source.Save("source.pptx", SaveFormat.Pptx);
        var list = source.Slides[2].Shapes.AddAutoShape(ShapeType.Rectangle, 300, 110, 300, 150);
        list.TextFrame.Text = licensed ? "First point\nSecond point" : "One\nTwo";
        foreach (var paragraph in list.TextFrame.Paragraphs)
        {
            paragraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
            paragraph.ParagraphFormat.Bullet.Char = (char)8226;
        }
        var options = new MarkdownSaveOptions
        {
            ExportType = MarkdownExportType.Visual,
            BasePath = Directory.GetCurrentDirectory(),
            ImagesSaveFolderName = "images",
            ShowSlideNumber = true
        };
        source.Save("slides.md", SaveFormat.Md, options);
        string markdown = File.ReadAllText("slides.md");
        if (!markdown.Contains("Alpha") || !markdown.Contains("Pens")) throw new InvalidOperationException("Expected text/table data missing.");
        bool imagesExported = Directory.Exists("images") && Directory.GetFiles("images", "*", SearchOption.AllDirectories).Length > 0;
        if (!markdown.Contains(licensed ? "First point" : "One") || !imagesExported) throw new InvalidOperationException("List/image output is missing.");
        Report(new { slide_text = markdown.Contains("Alpha"), table_value = markdown.Contains("12"), list_text = true, images_exported = imagesExported });
    }
}
