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

internal static partial class Program
{
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
}
