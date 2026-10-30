using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Drawing;
using System.Security.Cryptography;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;

internal static class Program
{
    private static void Main()
    {
        var path = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        if (!string.IsNullOrWhiteSpace(path)) new License().SetLicense(path);
        var request = JsonDocument.Parse(File.ReadAllText("customer.json")).RootElement;
        string customer = request.GetProperty("customer").GetString()!;
        int[] selected = request.GetProperty("product_indices").EnumerateArray().Select(v => v.GetInt32()).ToArray();
        using (var catalog = Deck("Analytics", "Planning", "Reporting")) catalog.Save("catalog.pptx", SaveFormat.Pptx);
        string original = Hash("catalog.pptx");
        using var source = new Presentation("catalog.pptx");
        Require(selected.All(i => i >= 0 && i < source.Slides.Count), "Unknown product selection.");
        using var proposal = Deck("Proposal for " + customer);
        foreach (int i in selected) proposal.Slides.AddClone(source.Slides[i]);
        proposal.Save("proposal.pptx", SaveFormat.Pptx); proposal.Save("proposal.pdf", SaveFormat.Pdf);
        using var reopened = new Presentation("proposal.pptx");
        Require(reopened.Slides.Count == selected.Length + 1 && Text(reopened.Slides[0]).Contains(customer), "Proposal identity or count is wrong.");
        string[] expectedOrder = selected.Select(i => Text(source.Slides[i])).ToArray();
        for (int i = 0; i < expectedOrder.Length; i++)
            Require(Text(reopened.Slides[i + 1]) == expectedOrder[i], "Product order changed.");
        Require(Hash("catalog.pptx") == original, "Catalog was overwritten.");
        Preview(reopened, "preview.png");
        Report(new { customer, product_order = string.Join(",", expectedOrder), slides = reopened.Slides.Count, input_preserved = true });
    }

    private static Presentation Deck(params string[] titles)
    {
        var deck = new Presentation();
        deck.SlideSize.SetSize(960, 540, SlideSizeScaleType.DoNotScale);
        var layout = deck.LayoutSlides.GetByType(SlideLayoutType.Blank);
        for (int i = 0; i < titles.Length; i++)
        {
            var slide = i == 0 ? deck.Slides[0] : deck.Slides.AddEmptySlide(layout);
            Label(slide, titles[i], "Title", 40, 30, 880, 80);
        }
        return deck;
    }

    private static IAutoShape Label(ISlide slide, string value, string name, float x, float y, float w, float h)
    {
        var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, w, h);
        shape.Name = name;
        shape.FillFormat.FillType = FillType.Solid;
        shape.FillFormat.SolidFillColor.Color = Color.AliceBlue;
        shape.LineFormat.FillFormat.FillType = FillType.NoFill;
        shape.TextFrame.Text = value;
        shape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Normal;
        foreach (var paragraph in shape.TextFrame.Paragraphs)
        foreach (var portion in paragraph.Portions)
        {
            portion.PortionFormat.FontHeight = 24;
            portion.PortionFormat.LatinFont = new FontData("Arial");
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
        }
        return shape;
    }

    private static string Text(ISlide slide) => string.Join(" ", slide.Shapes.OfType<IAutoShape>().Select(s => s.TextFrame?.Text));
    private static string Hash(string path) => Convert.ToHexString(SHA256.HashData(File.ReadAllBytes(path)));
    private static void Require(bool value, string message) { if (!value) throw new InvalidOperationException(message); }
    private static void Preview(Presentation deck, string path)
    {
        using var image = deck.Slides[0].GetImage(new Size(640, 360));
        image.Save(path, Aspose.Slides.ImageFormat.Png);
    }
    private static void Report(object value)
    {
        string json = JsonSerializer.Serialize(value, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("result.json", json); Console.WriteLine(json);
    }
}
