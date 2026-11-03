using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

internal sealed record SalesData(string[] Categories, string[] Series, double[][] Values);

internal static class Example
{
    private const string ChartName = "Sales";

    internal static SalesData ReadSales(string path) =>
        JsonSerializer.Deserialize<SalesData>(File.ReadAllText(path))
        ?? throw new InvalidDataException("The sales fixture must contain chart data.");

    internal static void CreateTemplate(string path)
    {
        using var presentation = new Presentation();
        var chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 40, 130, 620, 290);
        chart.Name = ChartName;
        presentation.Save(path, SaveFormat.Pptx);
    }

    internal static IChart FindSalesChart(Presentation presentation) =>
        presentation.Slides[0].Shapes.OfType<IChart>().Single(chart => chart.Name == ChartName);

    internal static void SavePreview(Presentation presentation, string path)
    {
        using var image = presentation.Slides[0].GetImage(new Size(800, 450));
        image.Save(path, Aspose.Slides.ImageFormat.Png);
    }

    internal static void VerifyAndReport(ExampleContext context, string actionId, SalesData sales, string outputFolder)
    {
        using var report = new Presentation(Path.Combine(outputFolder, "report.pptx"));
        IChartData chartData = FindSalesChart(report).ChartData;
        context.Require(chartData.Categories.Count == sales.Categories.Length, "Category count differs.");
        context.Require(chartData.Series.Count == sales.Series.Length, "Series count differs.");

        for (int category = 0; category < sales.Categories.Length; category++)
        {
            context.Require(chartData.Categories[category].Value.ToString() == sales.Categories[category],
                "Category differs.");
        }

        for (int column = 0; column < sales.Series.Length; column++)
        {
            var series = chartData.Series[column];
            context.Require(series.Name.ToString() == sales.Series[column], "Series name differs.");
            context.Require(series.DataPoints.Count == sales.Categories.Length, "Data point count differs.");

            for (int category = 0; category < sales.Categories.Length; category++)
            {
                double expected = sales.Values[column][category];
                var chartValue = series.DataPoints[category].Value.Data;
                var workbookValue = chartData.ChartDataWorkbook.GetCell(0, category + 1, column + 1).Value;
                context.Require(Convert.ToDouble(chartValue, CultureInfo.InvariantCulture) == expected,
                    "Chart value differs.");
                context.Require(Convert.ToDouble(workbookValue, CultureInfo.InvariantCulture) == expected,
                    "Workbook value differs.");
            }
        }

        using (var workbook = chartData.ReadWorkbookStream())
        using (var file = File.Create(Path.Combine(outputFolder, "workbook.xlsx")))
        {
            workbook.CopyTo(file);
        }

        var preview = PortableImage.Decode(File.ReadAllBytes(Path.Combine(outputFolder, "preview.png")));
        context.Require(preview.Width > 0 && preview.Height > 0, "Empty PNG output.");

        if (context.IsLicensed)
        {
            context.Require(chartData.Series.Count == 2, "Licensed assertion differs: checks.series_count");
            context.Require(chartData.Categories.Count == 2, "Licensed assertion differs: checks.category_count");
        }

        var result = new
        {
            checks = new
            {
                series_count = chartData.Series.Count,
                category_count = chartData.Categories.Count,
                all_values_checked = true,
                embedded_workbook_checked = true,
            },
        };
        File.WriteAllText(Path.Combine(outputFolder, "result.json"),
            JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true }));

        var checks = context.IsLicensed
            ? new Dictionary<string, bool>
            {
                ["licensed-checks-series_count"] = true,
                ["licensed-checks-category_count"] = true,
                ["licensed-checks-all_values_checked"] = true,
                ["licensed-checks-embedded_workbook_checked"] = true,
            }
            : new Dictionary<string, bool>
            {
                ["evaluation-semantic-effect"] = true,
                ["evaluation-valid-output"] = true,
            };
        context.Pass(actionId, checks);
    }
}
