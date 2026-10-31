---
title: Collect Rendering and Export Warnings
type: docs
weight: 60
url: /net/examples/optimization-batch/warnings/
description: "Collect a real missing-font export warning and distinguish a completed conversion with warnings from a failed corrupt-file conversion."
---

Collect a real missing-font export warning and distinguish a completed conversion with warnings from a failed corrupt-file conversion.

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
        ctx.BeginAction("optimization-batch/warnings/block-001");
        RunExample();
        string path=File.Exists("output/result.json")?"output/result.json":"result.json";
        using var result=JsonDocument.Parse(File.ReadAllText(path));
        var checks=new System.Collections.Generic.Dictionary<string,bool>();
        if(ctx.IsLicensed)
        {
            using var expected=JsonDocument.Parse("{\"checks.font_warning_observed\":true,\"checks.warning_export_completed\":true,\"checks.corrupt_input_failed\":true,\"checks.error_not_reported_as_success\":true}");
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
        ctx.Pass("optimization-batch/warnings/block-001",checks);
        await Task.CompletedTask;
    });


    private sealed class Warnings : IWarningCallback
    {
        public List<object> Items {get;}=new();
        public ReturnAction Warning(IWarningInfo warning){Items.Add(new{type=warning.WarningType.ToString(),description=warning.Description});return ReturnAction.Continue;}
    }
    private static void RunExample()
    {
        Example.Setup();using(var p=new Presentation())
        {var shape=Example.Text(p.Slides[0].Shapes,"Text","Font substitution warning fixture");shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont=new FontData("Example_Missing_Font_734991");p.Save("output/input.pptx",SaveFormat.Pptx);}
        var warnings=new Warnings();using(var p=new Presentation("output/input.pptx")){p.Save("output/with-warning.pdf",SaveFormat.Pdf,new PdfOptions{WarningCallback=warnings});}
        File.WriteAllBytes("output/corrupt.pptx",new byte[]{0x50,0x4b,3,4,0,0,0});string? error=null;
        try{using var failed=new Presentation("output/corrupt.pptx",new LoadOptions{LoadFormat=LoadFormat.Pptx});failed.Save("output/should-not-exist.pdf",SaveFormat.Pdf);}catch(Exception ex){error=ex.GetType().Name+": "+ex.Message;}
        Example.Require(warnings.Items.Count>0,"Missing-font warning was not observed.");Example.Require(error!=null&&!File.Exists("output/should-not-exist.pdf"),"Failed conversion reported success.");
        Example.Json("output/report.json",new{successful_export_with_warnings=new{success=true,warnings=warnings.Items},failed_export=new{success=false,error}});
        Example.Result(new{font_warning_observed=true,warning_export_completed=true,corrupt_input_failed=true,error_not_reported_as_success=true});
    }

}
```

## Expected result and checks

The program writes its semantic checks to `output/result.json` and throws if a required
result differs. Expected check values are:

```json
{
  "font_warning_observed": true,
  "warning_export_completed": true,
  "corrupt_input_failed": true,
  "error_not_reported_as_success": true
}
```

The callback records WarningType and Description and returns Continue. Production applications should choose whether a warning is acceptable for their output requirements. A recoverable warning is not an error, and a failed file must not be recorded as successful. Configure fonts or substitution rules before retrying when typography matters.

## Learn more

- [Handle Presentation Warnings in .NET](https://docs.aspose.com/slides/net/presentation-warnings/)
- [Configure Font Substitution in Presentations in .NET](https://docs.aspose.com/slides/net/font-substitution/)


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
