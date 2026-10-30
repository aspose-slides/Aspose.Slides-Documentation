using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static class Program
{
    private static void CreateDeck(string path, string prefix, Color color)
    {
        using var deck = new Presentation();
        deck.SlideSize.SetSize(640, 360, SlideSizeScaleType.DoNotScale);
        deck.Masters[0].Background.Type = BackgroundType.OwnBackground;
        deck.Masters[0].Background.FillFormat.FillType = FillType.Solid;
        deck.Masters[0].Background.FillFormat.SolidFillColor.Color = color;
        var blank = deck.LayoutSlides.GetByType(SlideLayoutType.Blank);
        for (int i = 0; i < 3; i++)
        {
            ISlide slide = i == 0 ? deck.Slides[0] : deck.Slides.AddEmptySlide(blank);
            Label(slide, prefix + (i + 1));
            slide.NotesSlideManager.AddNotesSlide().NotesTextFrame.Text = "Notes for " + prefix + (i + 1);
        }
        deck.Sections.AddSection("Opening", deck.Slides[0]);
        deck.Sections.AddSection("Details", deck.Slides[1]);
        deck.Save(path, SaveFormat.Pptx);
    }

    private static void CheckOrder(string path, params string[] expected)
    {
        using var result = new Presentation(path);
        Require(result.Slides.Count == expected.Length, "Extra or missing slide in " + path);
        Require(result.Slides.Select(Text).SequenceEqual(expected), "Wrong slide order in " + path);
    }

    private static void Main()
    {
        ApplyLicense();
        CreateDeck("blue.pptx", "A", Color.LightBlue);
        CreateDeck("green.pptx", "B", Color.LightGreen);
        string blueHash = Hash("blue.pptx"), greenHash = Hash("green.pptx");
        using var blue = new Presentation("blue.pptx");
        using var green = new Presentation("green.pptx");
        using (var merged = new Presentation())
        {
            merged.Slides.RemoveAt(0); // Remove the destination's default blank slide.
            foreach (var slide in blue.Slides) merged.Slides.AddClone(slide);
            foreach (var slide in green.Slides) merged.Slides.AddClone(slide);
            merged.Save("merged.pptx", SaveFormat.Pptx);
        }
        CheckOrder("merged.pptx", "A1", "A2", "A3", "B1", "B2", "B3");
        using (var merged = new Presentation("merged.pptx"))
        {
            Require(merged.Slides[0].LayoutSlide.MasterSlide.Background.FillFormat.SolidFillColor.Color.ToArgb() == Color.LightBlue.ToArgb(), "Blue master was lost.");
            Require(merged.Slides[3].LayoutSlide.MasterSlide.Background.FillFormat.SolidFillColor.Color.ToArgb() == Color.LightGreen.ToArgb(), "Green master was lost.");
            Require(merged.Slides[3].NotesSlideManager.NotesSlide.NotesTextFrame.Text.Contains("Notes for B1"), "Speaker notes were lost.");
            using var first = merged.Slides[0].GetImage(new Size(640, 360));
            first.Save("source-design-blue.png", Aspose.Slides.ImageFormat.Png);
            using var fourth = merged.Slides[3].GetImage(new Size(640, 360));
            fourth.Save("source-design-green.png", Aspose.Slides.ImageFormat.Png);
        }
        using (var selected = new Presentation())
        {
            selected.Slides.RemoveAt(0);
            selected.Slides.AddClone(blue.Slides[2]);
            selected.Slides.AddClone(green.Slides[0]);
            selected.Save("selected.pptx", SaveFormat.Pptx);
        }
        CheckOrder("selected.pptx", "A3", "B1");
        using (var destination = new Presentation("blue.pptx"))
        {
            destination.Slides.RemoveAt(0);
            destination.Slides.RemoveAt(0);
            destination.Slides.RemoveAt(0);
            var destinationLayout = destination.LayoutSlides.GetByType(SlideLayoutType.Blank);
            destination.Slides.AddClone(green.Slides[0], destinationLayout);
            destination.Save("destination-design.pptx", SaveFormat.Pptx);
        }
        CheckOrder("destination-design.pptx", "B1");
        using (var result = new Presentation("destination-design.pptx"))
        {
            Require(result.Slides[0].LayoutSlide.MasterSlide.Background.FillFormat.SolidFillColor.Color.ToArgb() == Color.LightBlue.ToArgb(), "Destination layout was not applied.");
            using var image = result.Slides[0].GetImage(new Size(640, 360));
            image.Save("destination-design.png", Aspose.Slides.ImageFormat.Png);
        }
        Require(Hash("blue.pptx") == blueHash && Hash("green.pptx") == greenHash, "A source file changed.");
        Report(new { merged_slides = 6, selected_slides = 2, order_verified = true, source_masters_retained = true, destination_layout_applied = true, notes_retained = true, originals_unchanged = true });
    }

    private static void ApplyLicense()
    {
        string? path = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        var license = new Aspose.Slides.License();
        if (!string.IsNullOrWhiteSpace(path)) license.SetLicense(path);
        if (!license.IsLicensed())
            throw new InvalidOperationException("Set ASPOSE_LICENSE_PATH to a valid license file for this complete example.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition) throw new InvalidOperationException(message);
    }

    private static IAutoShape Label(ISlide slide, string text)
    {
        var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 80, 540, 100);
        shape.Name = "content-" + text;
        shape.TextFrame.Text = text;
        shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 28;
        return shape;
    }

    private static string Text(ISlide slide) => string.Join("|", slide.Shapes.OfType<IAutoShape>().Select(s => s.TextFrame.Text));
    private static string Hash(string file) => Convert.ToHexString(SHA256.HashData(File.ReadAllBytes(file)));
    private static void Report(object checks)
    {
        string json = JsonSerializer.Serialize(new { checks }, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("result.json", json);
        Console.WriteLine(json);
    }
}
