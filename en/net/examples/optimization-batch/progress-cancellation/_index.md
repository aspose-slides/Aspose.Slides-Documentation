---
title: Track Progress and Cancel Processing
type: docs
weight: 50
url: /net/examples/optimization-batch/progress-cancellation/
description: "Observe PDF export progress, request an SDK interruption during another export, and confirm that the operation stops before completion."
---

Observe PDF export progress, request an SDK interruption during another export, and confirm that the operation stops before completion.

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

    private sealed class Progress : IProgressCallback
    {
        public List<double> Values {get;}=new();private readonly InterruptionTokenSource? _source;public bool Requested{get;private set;}
        public Progress(InterruptionTokenSource? source=null){_source=source;}
        public void Reporting(double value){Values.Add(value);if(_source!=null&&!Requested&&value>0){Requested=true;_source.Interrupt();}}
    }
    private static void Main()
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

}
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
