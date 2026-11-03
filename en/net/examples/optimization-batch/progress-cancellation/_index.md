---
title: Track Progress and Cancel Processing
type: docs
weight: 50
url: /net/examples/optimization-batch/progress-cancellation/
description: "Observe PDF export progress, request an SDK interruption during another export, and confirm that the operation stops before completion."
---

Observe PDF export progress, request an SDK interruption during another export, and confirm that the operation stops before completion.

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
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System;
using Aspose.Slides.Charts;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;
using Aspose.Slides.Warnings;
using Aspose.Slides;
using Microsoft.VisualBasic.FileIO;

internal static class Program
{
    private static Task<int> Main() => RunChecked();

    private sealed class Progress : IProgressCallback
    {
        public List<double> Values {get;}=new();private readonly InterruptionTokenSource? _source;public bool Requested{get;private set;}
        public Progress(InterruptionTokenSource? source=null){_source=source;}
        public void Reporting(double value){Values.Add(value);if(_source!=null&&!Requested&&value>0){Requested=true;_source.Interrupt();}}
    }

    private static void SaveWithProgress()
    {
        Example.Setup();using(var p=new Presentation())
        {for(int i=0;i<24;i++){var slide=i==0?p.Slides[0]:p.Slides.AddEmptySlide(p.LayoutSlides[0]);Example.Text(slide.Shapes,"Title","Slide "+(i+1));Example.ChartData(Example.Chart(slide,"Chart"),new[]{"A","B","C"},new[]{"Series"},new[]{new[]{1.0,2.0,3.0}});}p.Save("output/input.pptx",SaveFormat.Pptx);}
        var fullProgress=new Progress();using(var p=new Presentation("output/input.pptx")){p.Save("output/complete.pdf",SaveFormat.Pdf,new PdfOptions{ProgressCallback=fullProgress});}
        Example.Require(fullProgress.Values.Count>0&&fullProgress.Values.Max()==100,"Full PDF export did not report completion.");
        var source=new InterruptionTokenSource();var cancellationProgress=new Progress(source);bool exceptionObserved=false;
        try{using var p=new Presentation("output/input.pptx",new LoadOptions{InterruptionToken=source.Token});p.Save("output/partial.pdf",SaveFormat.Pdf,new PdfOptions{ProgressCallback=cancellationProgress});}
        catch(OperationCanceledException){exceptionObserved=true;}
        finally{if(File.Exists("output/partial.pdf"))File.Delete("output/partial.pdf");}
        using(var exclusive=File.Open("output/input.pptx",FileMode.Open,FileAccess.ReadWrite,FileShare.None)){}
        // Some library export paths return normally after an interruption. Compare
        // their progress against the successful control, rather than requiring an exception.
        bool stopped=exceptionObserved||(cancellationProgress.Requested&&cancellationProgress.Values.Count>0&&cancellationProgress.Values.Max()<100);
        Example.Require(cancellationProgress.Requested&&stopped,"Cancellation request did not stop the SDK operation before completion.");
        Example.Require(!File.Exists("output/partial.pdf"),"Partial output was retained.");
        Example.Json("output/progress.json",new{complete=fullProgress.Values,cancelled=cancellationProgress.Values,cancellation_requested=cancellationProgress.Requested,operation_stopped=stopped,operation_canceled_exception=exceptionObserved});
        Example.Result(new{progress_observed=true,cancellation_requested=true,operation_stopped=true,partial_output_removed=true,input_unlocked=true});
    }

    private static ExampleContext Context = null!;

    private static Task<int> RunChecked() => ExampleBootstrap.RunAsync(async ctx =>
    {
        Context = ctx;
        Example.Context = ctx;
        SaveWithProgress();
        await Task.CompletedTask;
    });
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

    public static IAutoShape Text(IShapeCollection shapes,string name,string value,float x=35,float y=35,float width=600,float height=70)
    {
        var shape=shapes.AddAutoShape(ShapeType.Rectangle,x,y,width,height);
        shape.Name=name; shape.TextFrame.Text=value;
        shape.FillFormat.FillType=FillType.Solid; shape.FillFormat.SolidFillColor.Color=Color.White;
        foreach(var para in shape.TextFrame.Paragraphs) foreach(var portion in para.Portions)
        { portion.PortionFormat.LatinFont=new FontData("Noto Sans"); portion.PortionFormat.FontHeight=20; portion.PortionFormat.FillFormat.FillType=FillType.Solid; portion.PortionFormat.FillFormat.SolidFillColor.Color=Color.FromArgb(35,65,100); }
        return shape;
    }

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
  "progress_observed": true,
  "cancellation_requested": true,
  "operation_stopped": true,
  "partial_output_removed": true,
  "input_unlocked": true
}
```

The control export must reach 100 percent. A second progress callback requests interruption after work begins; the sample requires either OperationCanceledException or observed progress stopping below 100 percent. Some export paths return normally after interruption, so a request or normal return alone is not treated as success. Partial output is removed, the source can be opened exclusively after disposal, and the completed control PDF remains available. Callback frequency is operation-dependent.

## Learn more

- [Support For Interruptable Library](https://docs.aspose.com/slides/net/support-for-interruptable-library/)
- [Convert PPT and PPTX to PDF in .NET [Advanced Features Included]](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)
- [Convert PowerPoint Presentations to Animated GIFs in .NET](https://docs.aspose.com/slides/net/convert-powerpoint-to-animated-gif/)


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
