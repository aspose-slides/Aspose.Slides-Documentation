---
title: Extract Chart Data
type: docs
weight: 50
url: /net/examples/content-extraction/chart-data/
description: "Read editable chart categories, series and numeric values, export embedded workbooks, and identify external workbook references."
---

Read editable chart categories, series and numeric values, export embedded workbooks, and identify external workbook references.

<span id="run-the-example"></span>

## **Example**

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.
The copied program writes its files under `output/` in the current working directory.

```csharp
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

internal static class Program
{
    private static void Main()
    {
        string? licensePath = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        if (!string.IsNullOrWhiteSpace(licensePath))
            new License().SetLicense(licensePath);

        Directory.CreateDirectory("output");
        ExtractChartData();
    }

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
            foreach (var chart in Walk(input.Slides[i].Shapes).OfType<IChart>())
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

        Json("output/chart-data.json", rows);
        Console.WriteLine("Results: " + Path.GetFullPath("output"));
    }

    private static void CreateInput()
    {
        using var presentation = new Presentation();
        var embedded = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 40, 60, 600, 350);
        embedded.Name = "Internal chart";
        SetChartData(embedded);
        var linkedSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
        var linked = linkedSlide.Shapes.AddChart(ChartType.ClusteredColumn, 40, 60, 600, 350);
        linked.Name = "External chart";
        linked.ChartData.SetExternalWorkbook("https://example.invalid/unfetched.xlsx", false);
        presentation.Save("output/input.pptx", SaveFormat.Pptx);
    }

    private static void SetChartData(IChart chart)
    {
        var data = chart.ChartData;
        var workbook = data.ChartDataWorkbook;
        data.Series.Clear();
        data.Categories.Clear();
        workbook.Clear(0);
        string[] categories = ["Jan", "Feb"];
        string[] names = ["North", "South"];
        double[][] values = [[125.5, 80], [50, 75.25]];
        for (int row = 0; row < categories.Length; row++)
            data.Categories.Add(workbook.GetCell(0, row + 1, 0, categories[row]));
        for (int column = 0; column < names.Length; column++)
        {
            var series = data.Series.Add(workbook.GetCell(0, 0, column + 1, names[column]), ChartType.ClusteredColumn);
            for (int row = 0; row < categories.Length; row++)
                series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, row + 1, column + 1, values[column][row]));
        }
    }

    private static IEnumerable<IShape> Walk(IShapeCollection shapes)
    {
        foreach (var shape in shapes)
        {
            yield return shape;
            if (shape is IGroupShape group)
            {
                foreach (var child in Walk(group.Shapes))
                    yield return child;
            }
        }
    }

    private static void Json(string path, object value)
    {
        string json = JsonSerializer.Serialize(value, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(path, json, new UTF8Encoding(false));
    }
}
```

## **Expected result and checks**

`output/chart-data.json` contains Jan/Feb categories and North/South values from the embedded chart. Its `Workbook` field points to `workbook-1-1.xlsx`; the second number is an embedded-chart ordinal, preventing collisions on the same slide. Missing point values remain JSON null. The linked workbook URL is recorded without reading or refreshing it.

The downloaded project writes its verification checks to `output/result.json`. The following values describe the ZIP’s checks; the copied program does not write this report:

```json
{
  "charts": 2,
  "embedded_workbooks": 1,
  "external_links": 1,
  "all_numeric_values_checked": true,
  "external_data_not_refreshed": true
}
```

Embedded values are preserved as numbers or null. For external workbooks the JSON records the link and the explicit external_not_read state, with empty category/series arrays. Reading linked workbook cells can cause a download, so this offline example does not inspect them. Missing values remain null; the example does not invent external data or turn chart images into editable data.

## **Learn more**

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
