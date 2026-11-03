using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

internal static class Program
{
    private const string ActionId = "templates-data/populate-charts/block-001";

    private static Task<int> Main(string[] args) => ExampleBootstrap.RunAsync(args, RunExample);

    private static Task RunExample(ExampleContext context)
    {
        context.BeginAction(ActionId);
        var sales = Example.ReadSales(Path.Combine(context.OutputRoot, "sales.json"));
        string outputFolder = Path.Combine(context.OutputRoot, "output");
        Directory.CreateDirectory(outputFolder);

        string templatePath = Path.Combine(outputFolder, "template.pptx");
        string reportPath = Path.Combine(outputFolder, "report.pptx");
        Example.CreateTemplate(templatePath);

        using (var presentation = new Presentation(templatePath))
        {
            IChart chart = Example.FindSalesChart(presentation);
            PopulateChart(chart, sales);
            presentation.Save(reportPath, SaveFormat.Pptx);
            Example.SavePreview(presentation, Path.Combine(outputFolder, "preview.png"));
        }

        Example.VerifyAndReport(context, ActionId, sales, outputFolder);
        return Task.CompletedTask;
    }

    private static void PopulateChart(IChart chart, SalesData sales)
    {
        IChartData chartData = chart.ChartData;
        IChartDataWorkbook workbook = chartData.ChartDataWorkbook;
        const int worksheetIndex = 0;

        chartData.Series.Clear();
        chartData.Categories.Clear();
        workbook.Clear(worksheetIndex);

        // Column zero holds the category labels. Row zero holds the series names.
        for (int category = 0; category < sales.Categories.Length; category++)
        {
            chartData.Categories.Add(workbook.GetCell(worksheetIndex, category + 1, 0, sales.Categories[category]));
        }

        for (int column = 0; column < sales.Series.Length; column++)
        {
            var seriesName = workbook.GetCell(worksheetIndex, 0, column + 1, sales.Series[column]);
            var series = chartData.Series.Add(seriesName, ChartType.ClusteredColumn);
            for (int category = 0; category < sales.Categories.Length; category++)
            {
                var value = workbook.GetCell(worksheetIndex, category + 1, column + 1, sales.Values[column][category]);
                series.DataPoints.AddDataPointForBarSeries(value);
            }
        }
    }
}
