---
title: Interrupt presentation processing
description: Interrupt a long presentation load or export operation.
type: docs
url: /features/cancel-processing/
weight: 290
feature_id: cancel-processing
feature_group: operations
translationKey: slides-feature-cancel-processing
feature_catalogue_version: 3
feature_guides:
- /slides/net/support-for-interruptable-library/
---

## **Overview**

Attach the library's interruption mechanism when opening a presentation, then signal it when your application needs to stop processing. This is useful for cancelled user requests or jobs that should no longer continue. Keep cancellation state alongside the job in your application.

## **Usage example**

This C# example uses Aspose.Slides for .NET. It creates a three-slide deck with many shapes, attaches a library interruption token when loading, and exports on a worker. The caller interrupts after the first PDF progress callback and discards the output whenever cancellation was requested, even if the save returns normally. Cancellation is cooperative, so smaller jobs may finish first.

For setup, see [Install Aspose.Slides for .NET](/slides/net/installation/).

```csharp
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var source = new Presentation())
{
    for (var i = 0; i < 3; i++)
    {
        var slide = i == 0 ? source.Slides[0] : source.Slides.AddEmptySlide(source.Slides[0].LayoutSlide);
        for (var j = 0; j < 300; j++)
        {
            var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, j % 20 * 30, j / 20 * 25, 28, 23);
            shape.TextFrame.Text = "Hello";
        }
    }
    source.Save("input.pptx", SaveFormat.Pptx);
}
var tokenSource = new InterruptionTokenSource();
var options = new LoadOptions { InterruptionToken = tokenSource.Token };
using var started = new ManualResetEventSlim(false);
var reporter = new SignalProgress(started);
var job = Task.Run(() =>
{
    try
    {
        using var presentation = new Presentation("input.pptx", options);
        var saveOptions = new PdfOptions { ProgressCallback = reporter };
        presentation.Save("partial.pdf", SaveFormat.Pdf, saveOptions);
    }
    catch (Exception error)
    {
        Console.WriteLine($"Worker stopped: {error.GetType().Name}");
    }
    finally
    {
        started.Set();
    }
});
started.Wait();
tokenSource.Interrupt();
job.Wait();
Console.WriteLine($"Last PDF progress: {reporter.LastValue:F1}");
if (tokenSource.Token.IsInterruptionRequested)
{
    if (File.Exists("partial.pdf"))
        File.Delete("partial.pdf");
    Console.WriteLine("Cancellation requested; output discarded.");
}

class SignalProgress : IProgressCallback
{
    private readonly ManualResetEventSlim started;
    public double LastValue { get; private set; } = -1;

    public SignalProgress(ManualResetEventSlim started)
    {
        this.started = started;
    }

    public void Reporting(double progressValue)
    {
        LastValue = progressValue;
        started.Set();
    }
}
```

## **FAQ**

### **Can I use the output from an interrupted save?**

Discard it. A save can return after interruption with incomplete output, so your application must track cancellation rather than treat a normal return as completion.

### **How do I connect a .NET cancellation token to library interruption?**

Monitor the .NET cancellation token in your application and signal the library’s interruption source when it is cancelled. Pass the library token in the presentation’s load options; see the [interruption guide](/slides/net/support-for-interruptable-library/).

### **Can I reuse an interruption token source for another operation?**

Use a fresh source for an independent job after interruption. Tokens from an interrupted source remain interrupted, so sharing it would also cancel later operations.

## **Guides**

- [Support For Interruptable Library (.NET)](/slides/net/support-for-interruptable-library/)

Related feature: [Track export progress](/slides/features/export-progress/).
