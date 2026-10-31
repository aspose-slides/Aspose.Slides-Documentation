---
title: Reduce Presentation Size
type: docs
weight: 10
url: /net/examples/optimization-batch/compression/
description: "Compress an intentionally oversized picture at 96 DPI, save a new presentation and compare file size and representative renders."
---

Compress an intentionally oversized picture at 96 DPI, save a new presentation and compare file size and representative renders.

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

```csharp
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;
using Aspose.Slides.Warnings;

internal static class Program
{
    private static ExampleContext Context = null!;
    private static Task<int> Main(string[] args) => ExampleBootstrap.RunAsync(args, async ctx =>
    {
        Context = ctx;
        Example.Context = ctx;
        ctx.BeginAction("optimization-batch/compression/block-001");
        RunExample();
        string path=File.Exists("output/result.json")?"output/result.json":"result.json";
        using var result=JsonDocument.Parse(File.ReadAllText(path));
        var checks=new System.Collections.Generic.Dictionary<string,bool>();
        if(ctx.IsLicensed)
        {
            using var expected=JsonDocument.Parse("{\"checks.fixture_shrank\":true,\"checks.geometry_preserved\":true,\"checks.render_difference_within_limit\":true,\"checks.reopened\":true}");
            foreach(var field in expected.RootElement.EnumerateObject())
            {
                var actual=result.RootElement;foreach(string part in field.Name.Split('.'))actual=actual.GetProperty(part);
                ctx.Require(actual.ToString()==field.Value.ToString(),"Licensed assertion differs: "+field.Name);
                checks["licensed-"+field.Name.Replace('.','-')]=true;
            }
        }
        else
        {
            var values=result.RootElement.TryGetProperty("checks",out var nested)?nested:result.RootElement;
            foreach(var field in values.EnumerateObject())if(field.Value.ValueKind==JsonValueKind.False)throw new InvalidOperationException("Evaluation assertion failed: "+field.Name);
            checks["evaluation-semantic-effect"]=true;checks["evaluation-valid-output"]=true;
        }
        foreach(string pdf in Directory.GetFiles(".","*.pdf",SearchOption.AllDirectories))ctx.Require(File.ReadAllBytes(pdf).AsSpan(0,5).SequenceEqual(System.Text.Encoding.ASCII.GetBytes("%PDF-")),"Invalid PDF output.");
        foreach(string png in Directory.GetFiles(".","*.png",SearchOption.AllDirectories)){var image=PortableImage.Decode(File.ReadAllBytes(png));ctx.Require(image.Width>0&&image.Height>0,"Empty PNG output.");}
        ctx.Pass("optimization-batch/compression/block-001",checks);
        await Task.CompletedTask;
    });


    private static double MeanDifference(string first,string second) => PortableImage.Difference(first,second);
    private static void RunExample()
    {
        Example.Setup();using(var p=new Presentation())
        {Example.Text(p.Slides[0].Shapes,"Title","Reduce an oversized raster image",30,20,620,60);
         p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle,80,110,500,300,p.Images.AddImage(Example.Png(4000,2400,Color.Teal))).Name="Oversized image";
         p.Save("output/input.pptx",SaveFormat.Pptx);Example.Render(p,"output/before.png");}
        long before=new FileInfo("output/input.pptx").Length;
        bool compressed;
        using(var p=new Presentation("output/input.pptx"))
        {var frame=Example.Named<IPictureFrame>(p.Slides[0],"Oversized image");compressed=frame.PictureFormat.CompressImage(true,PicturesCompression.Dpi96);p.Save("output/compressed.pptx",SaveFormat.Pptx);Example.Render(p,"output/after.png");}
        long after=new FileInfo("output/compressed.pptx").Length;
        using var reopened=new Presentation("output/compressed.pptx");var picture=Example.Named<IPictureFrame>(reopened.Slides[0],"Oversized image");
        double difference=MeanDifference("output/before.png","output/after.png");
        Example.Require(compressed&&after<before,"The deliberately oversized fixture did not shrink.");
        Example.Require(picture.Width==500&&picture.Height==300&&reopened.Slides.Count==1,"Frame or slides changed.");
        Example.Require(difference<3,"Representative render changed too much.");
        Example.Json("output/measurements.json",new{before_bytes=before,after_bytes=after,mean_rgb_difference=difference,resolution="96 DPI"});
        Example.Result(new{fixture_shrank=true,geometry_preserved=true,render_difference_within_limit=true,reopened=true});
    }

}
```

## Expected result and checks

The program writes its semantic checks to `output/result.json` and throws if a required
result differs. Expected check values are:

```json
{
  "fixture_shrank": true,
  "geometry_preserved": true,
  "render_difference_within_limit": true,
  "reopened": true
}
```

Compression is a quality choice: this fixture is deliberately much larger than its display frame. The result must shrink while its measured mean RGB render difference remains small. Real files may shrink less or not at all. Keep the original when quality requirements may change; the sample reports actual byte counts rather than a universal savings claim.

## Learn more

- [Optimize Image Management in Presentations in .NET](https://docs.aspose.com/slides/net/image/)
- [Save Presentations in .NET](https://docs.aspose.com/slides/net/save-presentation/)


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
