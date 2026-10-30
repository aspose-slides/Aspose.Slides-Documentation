---
title: Populate Charts from Data
type: docs
weight: 30
url: /net/examples/templates-data/populate-charts/
description: "Read synthetic JSON sales data and update an editable chart, including the cells of its embedded workbook."
---

Read synthetic JSON sales data and update an editable chart, including the cells of its embedded workbook.

## Run the example

Download the [complete project](sample.zip), extract it, and run it with the .NET 8 SDK.
The project pins Aspose.Slides.NET 26.10.0. The example was tested on Windows x64.
For the complete data assertions, set `ASPOSE_LICENSE_PATH` to your own valid license;
the visible helper loads it when supplied. Evaluation mode may truncate text or add watermarks.

```text
dotnet restore Example.csproj --locked-mode
dotnet run --project Example.csproj --configuration Release --no-restore
```

The download contains [Program.cs](Program.cs), [Example.cs](Example.cs), the project,
dependency lock, and any JSON/CSV input. The helper source contains fixture generation,
license loading, serialization and assertions; it is part of the runnable project.
All presentation inputs are generated from original synthetic data. Results go to `output/`.

## Example

```csharp
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Runtime.Versioning;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

[SupportedOSPlatform("windows")]
internal static class Program
{

    private sealed record Data(string[] Categories,string[] Series,double[][] Values);
    private static void Main()
    {
        Example.Setup();var data=JsonSerializer.Deserialize<Data>(File.ReadAllText("sales.json"))!;
        using(var p=new Presentation()){Example.Chart(p.Slides[0],"Sales");p.Save("output/template.pptx",SaveFormat.Pptx);}
        using(var p=new Presentation("output/template.pptx"))
        {var chart=Example.Named<IChart>(p.Slides[0],"Sales");Example.ChartData(chart,data.Categories,data.Series,data.Values);p.Save("output/report.pptx",SaveFormat.Pptx);Example.Render(p,"output/preview.png");}
        using var result=new Presentation("output/report.pptx");var saved=Example.Named<IChart>(result.Slides[0],"Sales");
        Example.Require(saved.ChartData.Categories.Count==data.Categories.Length,"Category count differs.");
        for(int c=0;c<data.Series.Length;c++)
        {Example.Require(saved.ChartData.Series[c].Name.ToString()==data.Series[c],"Series name differs.");
         for(int r=0;r<data.Categories.Length;r++)
         {Example.Require(saved.ChartData.Categories[r].Value.ToString()==data.Categories[r],"Category differs.");
          Example.Require(Convert.ToDouble(saved.ChartData.Series[c].DataPoints[r].Value.Data,CultureInfo.InvariantCulture)==data.Values[c][r],"Chart value differs.");
          Example.Require(Convert.ToDouble(saved.ChartData.ChartDataWorkbook.GetCell(0,r+1,c+1).Value,CultureInfo.InvariantCulture)==data.Values[c][r],"Workbook value differs.");}}
        using(var stream=saved.ChartData.ReadWorkbookStream())using(var file=File.Create("output/workbook.xlsx"))stream.CopyTo(file);
        Example.Result(new{series_count=data.Series.Length,category_count=data.Categories.Length,all_values_checked=true,embedded_workbook_checked=true});
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

The sample updates categories, series names and every data point explicitly. It reopens the saved PPTX and checks both chart values and workbook cells. It also exports the embedded workbook for inspection. Data parsing is application code, not a built-in reporting engine.

## Learn more

- [Create or Update PowerPoint Presentation Charts in .NET](https://docs.aspose.com/slides/net/create-chart/)
- [Manage Chart Workbooks in Presentations in .NET](https://docs.aspose.com/slides/net/chart-workbook/)
- [Manage Chart Data Series in Presentations in .NET](https://docs.aspose.com/slides/net/chart-series/)
