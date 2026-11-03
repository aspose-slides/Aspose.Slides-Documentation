using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Charts;
using System.Threading.Tasks;

internal static partial class Program
{
    private static Task<int> Main(string[] args) => RunChecked(args);
    private sealed record SeriesData(string Name, double? [] Values);
    private sealed record ChartData(int Slide, string Shape, string Source, string? ExternalWorkbook, string[] Categories, SeriesData[] Series, string? Workbook = null);
    private static SeriesData ReadSeries(IChartSeries series)
    {
        var values = new List<double?>();
        foreach (var point in series.DataPoints)
        {
            object? value = point.Value.Data;
            values.Add(value is null ? null : Convert.ToDouble(value, CultureInfo.InvariantCulture));
        }

        return new SeriesData(series.Name.ToString(), values.ToArray());
    }

    private static void ExtractChartData()
    {
        CreateInput();
        using var input = new Presentation("output/input.pptx");
        var rows = new List<ChartData>();
        int workbooks = 0;
        for (int i = 0; i < input.Slides.Count; i++)
        {
            int embeddedChartNumber = 0;
            foreach (var chart in Example.Walk(input.Slides[i].Shapes).OfType<IChart>())
            {
                var data = chart.ChartData;
                if (data.DataSourceType == ChartDataSourceType.ExternalWorkbook)
                {
                    // Reading categories, series or a workbook stream could open the link.
                    rows.Add(new ChartData(i + 1, chart.Name, "external_not_read", data.ExternalWorkbookPath, [], []));
                    continue;
                }

                string[] categories = data.Categories.Select(category => category.Value?.ToString() ?? "").ToArray();
                SeriesData[] series = data.Series.Select(ReadSeries).ToArray();
                embeddedChartNumber++;
                string workbookName = $"workbook-{i + 1}-{embeddedChartNumber}.xlsx";
                string workbookPath = Path.Combine("output", workbookName);
                using var workbook = data.ReadWorkbookStream();
                using var file = File.Create(workbookPath);
                workbook.CopyTo(file);
                workbooks++;
                rows.Add(new ChartData(i + 1, chart.Name, "embedded", null, categories, series, workbookName));
            }
        }

        Example.Json("output/chart-data.json", rows);
        VerifyExtraction(rows, workbooks);
    }
}
