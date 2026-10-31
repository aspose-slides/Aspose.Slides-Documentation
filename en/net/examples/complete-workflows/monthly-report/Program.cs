using System.IO.Compression;
using System.Threading.Tasks;
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
    private static ExampleContext Context = null!;
    private static Task<int> Main(string[] args) => ExampleBootstrap.RunAsync(args, async context =>
    {
        Context = context;
        context.BeginAction("complete-workflows/monthly-report/block-001");
        RunExample();
        await Task.CompletedTask;
        context.Pass("complete-workflows/monthly-report/block-001", "recipe semantic assertions", "source inputs preserved", "documented output generated");
    });

    private static void RunExample()
    {
        var records = JsonDocument.Parse(File.ReadAllText("sales.json")).RootElement.EnumerateArray().ToArray();
        double total = records.Sum(r => r.GetProperty("units").GetDouble());
        Require(records.All(r => r.GetProperty("units").GetDouble() >= 0), "Units must be nonnegative.");
        using (var template = Deck("Monthly report: {{month}}", "{{product}}"))
        {
            Label(template.Slides[0], "{{total}}", "Total", 40, 120, 350, 60);
            Label(template.Slides[1], "{{units}}", "Units", 40, 150, 500, 80);
            template.Save("template.pptx", SaveFormat.Pptx);
        }
        string original = Hash("template.pptx");
        using var report = new Presentation("template.pptx");
        var search = new TextSearchOptions { CaseSensitive = true };
        foreach (var shape in report.Slides[0].Shapes.OfType<IAutoShape>().Where(shape => shape.Name is "Title" or "Total"))
        {
            shape.TextFrame.ReplaceText("{{month}}", "October", search, null);
            shape.TextFrame.ReplaceText("{{total}}", "Total units: " + total, search, null);
        }
        var chart = report.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 410, 120, 500, 340);
        chart.ChartData.Series.Clear(); chart.ChartData.Categories.Clear();
        var book = chart.ChartData.ChartDataWorkbook; book.Clear(0);
        var series = chart.ChartData.Series.Add(book.GetCell(0, 0, 1, "Units"), chart.Type);
        var table = report.Slides[0].Shapes.AddTable(40, 220, new double[] { 210, 120 }, Enumerable.Repeat(36.0, records.Length + 1).ToArray());
        table[0, 0].TextFrame.Text = "Product"; table[1, 0].TextFrame.Text = "Units";
        var detailTemplate = report.Slides[1];
        for (int i = 0; i < records.Length; i++)
        {
            string product = records[i].GetProperty("product").GetString()!;
            double units = records[i].GetProperty("units").GetDouble();
            chart.ChartData.Categories.Add(book.GetCell(0, i + 1, 0, product));
            series.DataPoints.AddDataPointForBarSeries(book.GetCell(0, i + 1, 1, units));
            table[0, i + 1].TextFrame.Text = product; table[1, i + 1].TextFrame.Text = units.ToString(System.Globalization.CultureInfo.InvariantCulture);
            var detail = report.Slides.AddClone(detailTemplate);
            foreach (var shape in detail.Shapes.OfType<IAutoShape>().Where(shape => shape.Name is "Title" or "Units"))
            {
                shape.TextFrame.ReplaceText("{{product}}", product, search, null);
                shape.TextFrame.ReplaceText("{{units}}", units.ToString(System.Globalization.CultureInfo.InvariantCulture), search, null);
            }
        }
        report.Slides.RemoveAt(1);
        report.Save("monthly-report.pptx", SaveFormat.Pptx); report.Save("monthly-report.pdf", SaveFormat.Pdf);
        using var reopened = new Presentation("monthly-report.pptx");
        Require(reopened.Slides.Count == records.Length + 1, "Wrong report size.");
        var savedChart = reopened.Slides[0].Shapes.OfType<IChart>().Single();
        Require(savedChart.ChartData.Series[0].DataPoints.Sum(p => Convert.ToDouble(p.Value.Data)) == total, "Chart values do not reconcile.");
        Require(!reopened.Slides.Any(s => Text(s).Contains("{{")), "Unfilled marker remains.");
        string[] savedText = SavedText("monthly-report.pptx");
        Require(!savedText.Any(text => text.Contains("{{", StringComparison.Ordinal)), "A persisted template marker remains.");
        Require(savedText.Contains("Monthly report: October") && savedText.Contains("Total units: " + total), "Persisted summary differs.");
        foreach (var record in records) Require(savedText.Contains(record.GetProperty("product").GetString()!) && savedText.Contains(record.GetProperty("units").GetDouble().ToString(System.Globalization.CultureInfo.InvariantCulture)), "Persisted detail data differs.");
        Require(Hash("template.pptx") == original, "Template was overwritten.");
        Preview(reopened, "preview.png");
        Report(new { records = records.Length, total, slides = reopened.Slides.Count, input_preserved = true });
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
            portion.PortionFormat.LatinFont = new FontData("Noto Sans");
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
        }
        return shape;
    }

    private static string Text(ISlide slide) => string.Join(" ", slide.Shapes.OfType<IAutoShape>().Where(s => s.Name is "Title" or "Total" or "Units").Select(s => s.TextFrame?.Text));
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

    // Inspect persisted OOXML independently; evaluation text getters remain explicitly limited.
    private static string[] SavedText(string file)
    {
        using var archive = ZipFile.OpenRead(file);
        System.Xml.Linq.XNamespace drawing = "http://schemas.openxmlformats.org/drawingml/2006/main";
        return archive.Entries.Where(entry => entry.FullName.StartsWith("ppt/", StringComparison.Ordinal) && entry.FullName.EndsWith(".xml", StringComparison.Ordinal))
            .SelectMany(entry => { using var stream = entry.Open(); return System.Xml.Linq.XDocument.Load(stream, System.Xml.Linq.LoadOptions.PreserveWhitespace).Descendants(drawing + "p").Select(paragraph => string.Concat(paragraph.Descendants(drawing + "t").Select(node => node.Value))).ToArray(); }).ToArray();
    }

}
