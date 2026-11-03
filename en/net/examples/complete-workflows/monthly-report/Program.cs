using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

internal static partial class Program
{
    private static void RunExample()
    {
        var salesJson = File.ReadAllText("sales.json");
        using var salesDocument = JsonDocument.Parse(salesJson);
        var sales = salesDocument.RootElement.EnumerateArray().Select(row => new ProductSales(row.GetProperty("product").GetString()!, row.GetProperty("units").GetDouble())).ToArray();
        Require(sales.All(row => row.Units >= 0), "Units must be nonnegative.");

        var totalUnits = sales.Sum(row => row.Units);
        CreateTemplate();
        var originalHash = Hash("template.pptx");
        using var report = new Presentation("template.pptx");
        var searchOptions = new TextSearchOptions
        {
            CaseSensitive = true
        };
        foreach (var shape in report.Slides[0].Shapes.OfType<IAutoShape>())
        {
            shape.TextFrame.ReplaceText("{{month}}", "October", searchOptions, null);
            shape.TextFrame.ReplaceText("{{total}}", "Total units: " + totalUnits, searchOptions, null);
        }

        AddSalesChart(report.Slides[0], sales);
        AddSummaryTable(report.Slides[0], sales);
        AddProductDetails(report, sales, searchOptions);
        Require(!report.Slides.Any(slide => slide.Shapes.OfType<IAutoShape>().Any(shape => shape.TextFrame.Text.Contains("{{"))), "A template placeholder remains unfilled.");

        report.Save("monthly-report.pptx", SaveFormat.Pptx);
        report.Save("monthly-report.pdf", SaveFormat.Pdf);
        VerifyMonthlyReport(sales, totalUnits, originalHash);
    }

    private sealed record ProductSales(string Product, double Units);
    private static void CreateTemplate()
    {
        using var template = CreateDeck("Monthly report: {{month}}", "{{product}}");
        AddLabel(template.Slides[0], "{{total}}", "Total", 40, 120, 350, 60);
        AddLabel(template.Slides[1], "{{units}}", "Units", 40, 150, 500, 80);
        template.Save("template.pptx", SaveFormat.Pptx);
    }

    private static void AddSalesChart(ISlide summary, ProductSales[] sales)
    {
        var chart = summary.Shapes.AddChart(ChartType.ClusteredColumn, 410, 120, 500, 340);
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();
        var workbook = chart.ChartData.ChartDataWorkbook;
        workbook.Clear(0);
        var series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Units"), chart.Type);
        for (var index = 0; index < sales.Length; index++)
        {
            chart.ChartData.Categories.Add(workbook.GetCell(0, index + 1, 0, sales[index].Product));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, index + 1, 1, sales[index].Units));
        }
    }

    private static void AddSummaryTable(ISlide summary, ProductSales[] sales)
    {
        var rowHeights = Enumerable.Repeat(36.0, sales.Length + 1).ToArray();
        var table = summary.Shapes.AddTable(40, 220, new double[] { 210, 120 }, rowHeights);
        table[0, 0].TextFrame.Text = "Product";
        table[1, 0].TextFrame.Text = "Units";
        for (var index = 0; index < sales.Length; index++)
        {
            table[0, index + 1].TextFrame.Text = sales[index].Product;
            table[1, index + 1].TextFrame.Text = sales[index].Units.ToString(System.Globalization.CultureInfo.InvariantCulture);
        }
    }

    private static void AddProductDetails(Presentation report, ProductSales[] sales, TextSearchOptions searchOptions)
    {
        var detailTemplate = report.Slides[1];
        foreach (var product in sales)
        {
            var detailSlide = report.Slides.AddClone(detailTemplate);
            foreach (var shape in detailSlide.Shapes.OfType<IAutoShape>())
            {
                shape.TextFrame.ReplaceText("{{product}}", product.Product, searchOptions, null);
                shape.TextFrame.ReplaceText("{{units}}", product.Units.ToString(System.Globalization.CultureInfo.InvariantCulture), searchOptions, null);
            }
        }

        // Clone all detail slides before removing their template.
        report.Slides.RemoveAt(1);
    }

    private static void VerifyMonthlyReport(ProductSales[] sales, double totalUnits, string originalHash)
    {
        using var reopened = new Presentation("monthly-report.pptx");
        Require(reopened.Slides.Count == sales.Length + 1, "Wrong report size.");
        var savedChart = reopened.Slides[0].Shapes.OfType<IChart>().Single();
        Require(savedChart.ChartData.Series[0].DataPoints.Sum(p => Convert.ToDouble(p.Value.Data)) == totalUnits, "Chart values do not reconcile.");
        Require(!reopened.Slides.Any(s => Text(s).Contains("{{")), "Unfilled marker remains.");
        string[] savedText = SavedText("monthly-report.pptx");
        Require(!savedText.Any(text => text.Contains("{{", StringComparison.Ordinal)), "A persisted template marker remains.");
        Require(savedText.Contains("Monthly report: October") && savedText.Contains("Total units: " + totalUnits), "Persisted summary differs.");
        foreach (var record in sales)
            Require(savedText.Contains(record.Product) && savedText.Contains(record.Units.ToString(System.Globalization.CultureInfo.InvariantCulture)), "Persisted detail data differs.");
        Require(Hash("template.pptx") == originalHash, "Template was overwritten.");
        Preview(reopened, "preview.png");
        Report(new { records = sales.Length, total = totalUnits, slides = reopened.Slides.Count, input_preserved = true });
    }
}
