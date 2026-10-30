---
title: Collect Rendering and Export Warnings
type: docs
weight: 60
url: /net/examples/optimization-batch/warnings/
description: "Collect a real missing-font export warning and distinguish a completed conversion with warnings from a failed corrupt-file conversion."
---

Collect a real missing-font export warning and distinguish a completed conversion with warnings from a failed corrupt-file conversion.

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
using System.Runtime.Versioning;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;
using Aspose.Slides.Warnings;

[SupportedOSPlatform("windows")]
internal static class Program
{

    private sealed class Warnings : IWarningCallback
    {
        public List<object> Items {get;}=new();
        public ReturnAction Warning(IWarningInfo warning){Items.Add(new{type=warning.WarningType.ToString(),description=warning.Description});return ReturnAction.Continue;}
    }
    private static void Main()
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
