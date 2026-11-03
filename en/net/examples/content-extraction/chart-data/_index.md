---
title: Extract Chart Data
type: docs
weight: 50
url: /net/examples/content-extraction/chart-data/
description: "Read editable chart categories, series and numeric values, export embedded workbooks, and identify external workbook references."
---

Read editable chart categories, series and numeric values, export embedded workbooks, and identify external workbook references.

## Run the example

Download the [complete project](example.zip), extract it, and run it with the .NET 8 SDK.
The project pins Aspose.Slides.NET6.CrossPlatform 26.10.0. The complete project uses portable image fixtures and the CrossPlatform package.
For the complete data assertions, set `ASPOSE_LICENSE_PATH` to your own valid license;
the visible helper loads it when supplied. Evaluation mode may truncate text or add watermarks.

```text
dotnet restore Example.csproj
dotnet run --project Example.csproj --configuration Release --no-restore
```

The download contains [Program.cs](Program.cs), [Example.cs](Example.cs), the project,
dependency lock, and any JSON/CSV input. The helper source contains fixture generation,
license loading, serialization and assertions; it is part of the runnable project.
All presentation inputs are generated from original synthetic data. Results go to `output/`.

## Example

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.
The copied program writes its files under `example-output` by default.

```csharp
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using System;
using Aspose.Slides.Charts;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;
using Aspose.Slides;
using Microsoft.VisualBasic.FileIO;

internal static class Program
{
    private static Task<int> Main() => RunChecked();

    private sealed record SeriesData(string Name,double?[] Values);

    private sealed record ChartData(int Slide,string Shape,string Source,string? ExternalWorkbook,string[] Categories,SeriesData[] Series);

    private static void ExtractChartData()
    {
        CreateInput();
        using var input=new Presentation("output/input.pptx");var rows=new List<ChartData>();int workbooks=0;
        for(int i=0;i<input.Slides.Count;i++)foreach(var chart in Example.Walk(input.Slides[i].Shapes).OfType<IChart>())
        {var data=chart.ChartData;bool external=data.DataSourceType==ChartDataSourceType.ExternalWorkbook;
         // Do not read linked category/series cells: doing so can open the external workbook.
         var categories=external?Array.Empty<string>():data.Categories.Select(c=>c.Value?.ToString()??"").ToArray();
         var series=external?Array.Empty<SeriesData>():data.Series.Select(s=>new SeriesData(s.Name.ToString(),s.DataPoints.Select(point=>point.Value.Data==null?(double?)null:Convert.ToDouble(point.Value.Data,CultureInfo.InvariantCulture)).ToArray())).ToArray();
         rows.Add(new(i+1,chart.Name,external?"external_not_read":"embedded",external?data.ExternalWorkbookPath:null,categories,series));
         if(!external){using var stream=data.ReadWorkbookStream();using var file=File.Create("output/workbook-"+(i+1)+".xlsx");stream.CopyTo(file);workbooks++;}}
        Example.Json("output/chart-data.json",rows);
        VerifyExtraction(rows, workbooks);
    }

    private static void CreateInput()
    {
        Example.Setup();using(var p=new Presentation())
        {var chart=Example.Chart(p.Slides[0],"Internal chart");Example.ChartData(chart,new[]{"Jan","Feb"},new[]{"North","South"},new[]{new[]{125.5,80.0},new[]{50.0,75.25}});
         var external=p.Slides.AddEmptySlide(p.LayoutSlides[0]);var linked=Example.Chart(external,"External chart");Example.ChartData(linked,new[]{"Cached"},new[]{"Cached"},new[]{new[]{10.0}});linked.ChartData.SetExternalWorkbook("https://example.invalid/unfetched.xlsx",false);p.Save("output/input.pptx",SaveFormat.Pptx);}
    }

    private static ExampleContext Context = null!;

    private static Task<int> RunChecked() => ExampleBootstrap.RunAsync(async ctx =>
    {
        Context = ctx;
        Example.Context = ctx;
        ExtractChartData();
        await Task.CompletedTask;
    });

    private static void VerifyExtraction(List<ChartData> rows, int workbooks)
    {
        var first=rows[0];Example.Require(first.Categories.SequenceEqual(new[]{"Jan","Feb"}),"Categories differ.");
        Example.Require(first.Series[0].Name=="North"&&first.Series[1].Name=="South","Series names differ.");
        Example.Require(first.Series[0].Values.SequenceEqual(new double?[]{125.5,80})&&first.Series[1].Values.SequenceEqual(new double?[]{50,75.25}),"Numeric data differs.");
        Example.Require(rows[1].ExternalWorkbook=="https://example.invalid/unfetched.xlsx"&&workbooks==1,"External workbook policy differs.");
        using(var zip=ZipFile.OpenRead("output/workbook-1.xlsx"))Example.Require(zip.GetEntry("xl/workbook.xml")!=null,"Missing workbook package.");
        Example.Result(new{charts=2,embedded_workbooks=1,external_links=1,all_numeric_values_checked=true,external_data_not_refreshed=true});
    }
}

internal static class Example
{
    public static ExampleContext Context = null!;

    public static void Setup() { Directory.CreateDirectory("output"); }

    public static void Require(bool value,string message) { if(!value) throw new InvalidOperationException(message); }

    public static void Result(object checks)
    { File.WriteAllText("output/result.json",JsonSerializer.Serialize(new {checks},new JsonSerializerOptions{WriteIndented=true}),new UTF8Encoding(false)); }

    public static void Json(string path,object value)
    { File.WriteAllText(path,JsonSerializer.Serialize(value,new JsonSerializerOptions{WriteIndented=true}),new UTF8Encoding(false)); }

    public static IEnumerable<IShape> Walk(IShapeCollection shapes)
    { foreach(IShape shape in shapes){yield return shape;if(shape is IGroupShape group)foreach(var child in Walk(group.Shapes))yield return child;} }

    public static IChart Chart(ISlide slide,string name)
    { var chart=slide.Shapes.AddChart(ChartType.ClusteredColumn,40,130,620,290);chart.Name=name;return chart; }

    public static void ChartData(IChart chart,string[] categories,string[] series,double[][] values)
    {
        var data=chart.ChartData;var book=data.ChartDataWorkbook;data.Series.Clear();data.Categories.Clear();book.Clear(0);
        for(int r=0;r<categories.Length;r++)data.Categories.Add(book.GetCell(0,r+1,0,categories[r]));
        for(int c=0;c<series.Length;c++)
        {var item=data.Series.Add(book.GetCell(0,0,c+1,series[c]),ChartType.ClusteredColumn);
         for(int r=0;r<categories.Length;r++)item.DataPoints.AddDataPointForBarSeries(book.GetCell(0,r+1,c+1,values[c][r]));}
    }
}

internal static class ExampleBootstrap
{
    public static async Task<int> RunAsync(Func<ExampleContext, Task> run)
    {
        string? licensePath = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        if (!string.IsNullOrWhiteSpace(licensePath))
            new License().SetLicense(licensePath);

        string start = Environment.CurrentDirectory;
        string output = Directory.CreateDirectory(Path.Combine(start, "example-output")).FullName;
        try
        {
            Environment.CurrentDirectory = output;
            await run(new ExampleContext(output, !string.IsNullOrWhiteSpace(licensePath)));
            Console.WriteLine("Output: " + output);
            return 0;
        }
        finally
        {
            Environment.CurrentDirectory = start;
        }
    }
}

internal sealed record ExampleContext(string OutputRoot, bool IsLicensed);
```

## Expected result and checks

The program writes its semantic checks to `output/result.json` and throws if a required
result differs. Expected check values are:

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

## Learn more

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
