---
title: Convert Multiple Presentations
type: docs
weight: 40
url: /net/examples/optimization-batch/batch-conversion/
description: "Convert mixed valid, corrupt and encrypted presentations sequentially and with at most two independent workers."
---

Convert mixed valid, corrupt and encrypted presentations sequentially and with at most two independent workers.

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

    private sealed record JobResult(string Source,string Output,bool Success,string? Error);

    private static async Task<(JobResult[] Results,int Peak)> ConvertAll(string[] files,string directory,int workerLimit)
    {
        Directory.CreateDirectory(directory);var results=new ConcurrentBag<JobResult>();int active=0,peak=0;
        await Parallel.ForEachAsync(files,new ParallelOptions{MaxDegreeOfParallelism=workerLimit},(path,cancellation)=>
        {
            int current=Interlocked.Increment(ref active);int observed;
            do{observed=Volatile.Read(ref peak);if(current<=observed)break;}while(Interlocked.CompareExchange(ref peak,current,observed)!=observed);
            string identity=Example.Hash(Encoding.UTF8.GetBytes(Path.GetRelativePath("output/inputs",path)))[..12];
            string destination=Path.Combine(directory,Path.GetFileNameWithoutExtension(path)+"-"+identity+".pdf");
            try
            {using var p=new Presentation(path,new LoadOptions{LoadFormat=LoadFormat.Pptx});p.Save(destination,SaveFormat.Pdf);Example.Require(File.ReadAllBytes(destination).Take(5).SequenceEqual(Encoding.ASCII.GetBytes("%PDF-")),"Invalid PDF header.");results.Add(new(path,destination,true,null));}
            catch(Exception ex){if(File.Exists(destination))File.Delete(destination);results.Add(new(path,destination,false,ex.GetType().Name+": "+ex.Message));}
            finally{Interlocked.Decrement(ref active);}return ValueTask.CompletedTask;
        });
        return(results.OrderBy(r=>r.Source,StringComparer.Ordinal).ToArray(),peak);
    }

    private static async Task ConvertBatch()
    {
        CreateInput();
        string[] files=Directory.GetFiles("output/inputs","*.pptx",System.IO.SearchOption.AllDirectories).OrderBy(p=>p,StringComparer.Ordinal).ToArray();
        var sequential=await ConvertAll(files,"output/sequential",1);var parallel=await ConvertAll(files,"output/parallel",2);
        VerifyOutput(sequential, parallel);
    }

    private static void CreateInput()
    {
        Example.Setup();Directory.CreateDirectory("output/inputs/a");Directory.CreateDirectory("output/inputs/b");
        foreach(var item in new[]{("a/shared.pptx","North"),("b/shared.pptx","South"),("later.pptx","Processed after failures")})
        {using var p=new Presentation();Example.Text(p.Slides[0].Shapes,"Text",item.Item2);p.Save("output/inputs/"+item.Item1,SaveFormat.Pptx);}
        File.WriteAllBytes("output/inputs/corrupt.pptx",new byte[]{0x50,0x4b,3,4,0,0,0});
        using(var p=new Presentation()){p.ProtectionManager.Encrypt("SyntheticExamplePassword");p.Save("output/inputs/locked.pptx",SaveFormat.Pptx);}
    }

    private static ExampleContext Context = null!;

    private static Task<int> RunChecked() => ExampleBootstrap.RunAsync(async ctx =>
    {
        Context = ctx;
        Example.Context = ctx;
        await ConvertBatch();
        await Task.CompletedTask;
    });

    private static void VerifyOutput((JobResult[] Results, int Peak) sequential, (JobResult[] Results, int Peak) parallel)
    {
        foreach(var result in new[]{sequential,parallel})
        {Example.Require(result.Results.Count(r=>r.Success)==3&&result.Results.Count(r=>!r.Success)==2,"File outcomes differ.");Example.Require(result.Results.Where(r=>r.Success).Select(r=>r.Output).Distinct().Count()==3,"Output filenames collide.");Example.Require(result.Results.Single(r=>r.Source.EndsWith("later.pptx")).Success,"Later job did not run.");}
        Example.Require(sequential.Peak<=1&&parallel.Peak<=2,"Worker limit exceeded.");
        Example.Json("output/results.json",new{sequential=sequential.Results,parallel=parallel.Results,sequential_peak=sequential.Peak,parallel_peak=parallel.Peak});
        Example.Result(new{successes_per_run=3,failures_per_run=2,unique_outputs=true,worker_limits_observed=true,later_jobs_processed=true});
    }
}

internal static class Example
{
    public static ExampleContext Context = null!;

    public static void Setup() { Directory.CreateDirectory("output"); }

    public static void Require(bool value,string message) { if(!value) throw new InvalidOperationException(message); }

    public static string Hash(byte[] data)=>System.Convert.ToHexString(SHA256.HashData(data)).ToLowerInvariant();

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
  "successes_per_run": 3,
  "failures_per_run": 2,
  "unique_outputs": true,
  "worker_limits_observed": true,
  "later_jobs_processed": true
}
```

The worker loop, filename policy and result manifest belong to the application. Each worker owns its Presentation instance; no mutable presentation is shared. Source-relative identity hashes distinguish equal basenames. Per-file failures are retained and processing continues. Two workers is an example limit, not a universal memory recommendation. Initialize licensing before starting workers.

## Learn more

- [Convert PPT and PPTX to PDF in .NET [Advanced Features Included]](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)
- [Multithreading in Aspose.Slides for .NET](https://docs.aspose.com/slides/net/multithreading/)


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
