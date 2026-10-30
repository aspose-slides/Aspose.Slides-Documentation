using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

internal static class Program
{
    private static void Main()
    {
        var licensePath = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        if (!string.IsNullOrWhiteSpace(licensePath)) new License().SetLicense(licensePath);
        using var source = CreateSource();
        source.Save("source.pptx", SaveFormat.Pptx);
        var list = source.Slides[2].Shapes.AddAutoShape(ShapeType.Rectangle, 300, 110, 300, 150);
        list.TextFrame.Text = "First point\nSecond point";
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
        if (!markdown.Contains("First point") || !imagesExported) throw new InvalidOperationException("List/image output is missing.");
        Report(new { slide_text = markdown.Contains("Alpha"), table_value = markdown.Contains("12"), list_text = true, images_exported = imagesExported });
    }

    private static Presentation CreateSource()
    {
        var deck = new Presentation();
        deck.SlideSize.SetSize(640, 360, SlideSizeScaleType.DoNotScale);
        var layout = deck.LayoutSlides.GetByType(SlideLayoutType.Blank);
        string[] labels = { "Alpha", "Bravo", "Charlie", "Hidden" };
        for (int i = 0; i < labels.Length; i++)
        {
            var slide = i == 0 ? deck.Slides[0] : deck.Slides.AddEmptySlide(layout);
            var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 20, 580, 55);
            shape.TextFrame.Text = labels[i];
            shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("Arial");
            shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 26;
            slide.NotesSlideManager.AddNotesSlide().NotesTextFrame.Text = "Speaker note " + labels[i];
            slide.Hidden = i == 3;
        }
        var table = deck.Slides[0].Shapes.AddTable(30, 100, new double[] { 140, 100 }, new double[] { 35, 35 });
        table[0, 0].TextFrame.Text = "Product";
        table[1, 0].TextFrame.Text = "Units";
        table[0, 1].TextFrame.Text = "Pens";
        table[1, 1].TextFrame.Text = "12";
        deck.Slides[1].Shapes.AddChart(ChartType.ClusteredColumn, 30, 100, 400, 220);
        using (var bitmap = new Bitmap(100, 60))
        {
            using (var graphics = Graphics.FromImage(bitmap)) graphics.Clear(Color.CornflowerBlue);
            using var stream = new MemoryStream();
            bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            var image = deck.Images.AddImage(stream.ToArray());
            deck.Slides[2].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 120, 200, 120, image);
        }
        deck.Slides[0].Timeline.MainSequence.AddEffect(deck.Slides[0].Shapes[0], EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
        deck.Slides[0].SlideShowTransition.Type = TransitionType.Fade;
        return deck;
    }

    private static void Report(object values)
    {
        string json = JsonSerializer.Serialize(values, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("result.json", json);
        Console.WriteLine(json);
    }
}
