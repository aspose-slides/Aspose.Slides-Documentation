---
title: Populate Charts from Data
type: docs
weight: 30
url: /net/examples/templates-data/populate-charts/
description: "Create an editable chart from inline JSON sales data. The download demonstrates updating a template chart and checks its embedded workbook."
---

Create an editable chart from inline JSON sales data. The download demonstrates updating a template chart and checks its embedded workbook.

## **Example**

Worksheet column zero stores category labels; row zero stores series names.
The copied program creates a chart, clears its default data and links each new data point to a workbook cell. [Program.cs](Program.cs) contains the chart update. [Example.cs](Example.cs)
creates the synthetic template and verifies the saved report.

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.

```csharp
using System;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const string json = """
    {
      "Categories": ["Jan", "Feb", "Mar"],
      "Series": ["Pens", "Paper"],
      "Values": [[12, 18, 15], [9, 14, 17]]
    }
    """;
var sales = JsonSerializer.Deserialize<SalesData>(json);
if (sales is null)
{
    Console.Error.WriteLine("Sales data is missing.");
    return;
}
using var presentation = new Presentation();
var chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 560, 320);
var data = chart.ChartData;
var workbook = data.ChartDataWorkbook;
const int worksheet = 0;
data.Series.Clear();
data.Categories.Clear();
workbook.Clear(worksheet);
for (int row = 0; row < sales.Categories.Length; row++)
    data.Categories.Add(workbook.GetCell(worksheet, row + 1, 0, sales.Categories[row]));
for (int column = 0; column < sales.Series.Length; column++)
{
    var name = workbook.GetCell(worksheet, 0, column + 1, sales.Series[column]);
    var series = data.Series.Add(name, ChartType.ClusteredColumn);
    for (int row = 0; row < sales.Categories.Length; row++)
    {
        var value = workbook.GetCell(worksheet, row + 1, column + 1, sales.Values[column][row]);
        series.DataPoints.AddDataPointForBarSeries(value);
    }
}

presentation.Save("report.pptx", SaveFormat.Pptx);
Console.WriteLine("Saved report.pptx");
internal sealed record SalesData(string[] Categories, string[] Series, double[][] Values);
```

## **Expected result and checks**

The copied program writes `report.pptx` with three categories (Jan, Feb, Mar), two series (Pens, Paper), and all six inline values. The downloaded project writes its semantic checks to `output/result.json` and throws if a required
result differs. Expected check values for the download’s two-category fixture are:

```json
{
  "series_count": 2,
  "category_count": 2,
  "all_values_checked": true,
  "embedded_workbook_checked": true
}
```

Both versions update the category labels, series names, and chart data points. The downloaded project reads sales data from a JSON fixture, checks the saved chart and workbook, and exports the workbook for inspection.

## **Learn more**

- [Create or Update PowerPoint Presentation Charts in .NET](/slides/net/create-chart/)
- [Manage Chart Workbooks in Presentations in .NET](/slides/net/chart-workbook/)
- [Manage Chart Data Series in Presentations in .NET](/slides/net/chart-series/)


## **Open and run the complete project**

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
See [setup and prerequisites](/slides/net/examples/getting-started/) for native libraries,
fonts, IDE settings and the .NET 8/9 runtime support boundary of 2026-11-10.
