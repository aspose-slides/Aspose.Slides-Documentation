---
title: Populate Charts from Data
type: docs
weight: 30
url: /net/examples/templates-data/populate-charts/
description: "Read synthetic JSON sales data and update an editable chart, including the cells of its embedded workbook."
---

Read synthetic JSON sales data and update an editable chart, including the cells of its embedded workbook.

## Example

The chart workbook stores category labels in the first column and series names in the first row.
Clear the template chart's existing data, add the labels and series names, and link each data point
to its workbook cell. [Program.cs](Program.cs) contains the chart update. [Example.cs](Example.cs)
creates the synthetic template and verifies the saved report.

```csharp
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
```

## Expected result and checks

The program writes its semantic checks to `output/result.json` and throws if a required
result differs. Expected check values are:

```json
{
  "series_count": 2,
  "category_count": 2,
  "all_values_checked": true,
  "embedded_workbook_checked": true
}
```

The sample updates categories, series names and every data point explicitly. It reopens the saved PPTX and checks both chart values and workbook cells. It also exports the embedded workbook for inspection. The example reads its sales data from a JSON fixture.

## Learn more

- [Create or Update PowerPoint Presentation Charts in .NET](https://docs.aspose.com/slides/net/create-chart/)
- [Manage Chart Workbooks in Presentations in .NET](https://docs.aspose.com/slides/net/chart-workbook/)
- [Manage Chart Data Series in Presentations in .NET](https://docs.aspose.com/slides/net/chart-series/)


## Open and run the complete project

[Download the complete project](example.zip), extract it and open `Example.sln`, or run:

```text
dotnet restore Example.sln
dotnet run --project Example.csproj --configuration Release -- --mode evaluation
```

Use the current supported .NET 10 SDK/runtime. The project keeps a stable `net8.0`
target and accepts compatible stable SDKs; no exact SDK patch is required.
Evaluation runs without a license and explicitly ignores license environment settings.
It uses bounded fixtures and checks valid output while allowing the evaluation watermark
and documented read-back text truncation. For unrestricted checks, use `--mode licensed`
with your authorized `ASPOSE_LICENSE_PATH`. No license is included.

Inputs are copied from `Fixtures` into a separate output workspace. The program prints
the absolute output path; `execution.json` records the actual runtime and verified action.
The portable PNG helper creates original synthetic pixels without a Windows bitmap engine.
See [setup and prerequisites](/slides/net/examples/getting-started/) for native libraries,
fonts, IDE settings and the .NET 8/9 runtime support boundary of 2026-11-10.
