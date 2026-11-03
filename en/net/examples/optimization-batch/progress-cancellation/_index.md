---
title: Track Progress and Cancel Processing
type: docs
weight: 50
url: /net/examples/optimization-batch/progress-cancellation/
description: "Observe PDF export progress, request an SDK interruption during another export, and confirm that the operation stops before completion."
---

Observe PDF export progress, request an SDK interruption during another export, and confirm that the operation stops before completion.

<span id="run-the-example"></span>

## **Example**

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.
The copied program writes its files under `example-output` by default.

The program generates four text slides and writes `complete.pdf` under `example-output`. No input file is needed. The second export uses the SDK interruption token; its partial PDF is always removed.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static class Program
{
    private static int Main()
    {
        var licensePath = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        if (!string.IsNullOrWhiteSpace(licensePath))
            new License().SetLicense(licensePath);
        var output = Directory.CreateDirectory("example-output").FullName;
        var inputPath = Path.Combine(output, "input.pptx");
        var completePath = Path.Combine(output, "complete.pdf");
        var partialPath = Path.Combine(output, "partial.pdf");
        CreateInput(inputPath);
        // First export: observe progress through completion.
        var completeProgress = new ExportProgress();
        using (var presentation = new Presentation(inputPath))
        {
            var options = new PdfOptions
            {
                ProgressCallback = completeProgress
            };
            presentation.Save(completePath, SaveFormat.Pdf, options);
        }

        Console.WriteLine($"Completed export: {completeProgress.MaximumPercent}% - {completePath}");
        if (completeProgress.MaximumPercent != 100)
        {
            Console.Error.WriteLine("The control export did not report completion.");
            return 1;
        }

        // Second export: interrupt once, as soon as positive progress is reported.
        var interruption = new InterruptionTokenSource();
        var cancelledProgress = new ExportProgress(interruption);
        var cancellationException = false;
        try
        {
            var loadOptions = new LoadOptions
            {
                InterruptionToken = interruption.Token
            };
            using var presentation = new Presentation(inputPath, loadOptions);
            var saveOptions = new PdfOptions
            {
                ProgressCallback = cancelledProgress
            };
            presentation.Save(partialPath, SaveFormat.Pdf, saveOptions);
        }
        catch (OperationCanceledException)
        {
            cancellationException = true;
        }
        finally
        {
            // The presentation has been disposed before partial output is deleted.
            if (File.Exists(partialPath))
                File.Delete(partialPath);
        }

        // Some export paths return normally after interruption.
        var stopped = cancellationException || (cancelledProgress.InterruptionRequested && cancelledProgress.MaximumPercent < 100);
        if (!cancelledProgress.InterruptionRequested || !stopped)
        {
            Console.Error.WriteLine("The cancellation request did not stop the export.");
            return 1;
        }

        Console.WriteLine($"Interrupted at {cancelledProgress.MaximumPercent}%; partial PDF removed.");
        return 0;
    }

    private static void CreateInput(string path)
    {
        using var presentation = new Presentation();
        for (var index = 0; index < 4; index++)
        {
            var slide = index == 0 ? presentation.Slides[0] : presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
            var title = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 600, 100);
            title.TextFrame.Text = $"Progress example - slide {index + 1}";
        }

        presentation.Save(path, SaveFormat.Pptx);
    }

    private sealed class ExportProgress(InterruptionTokenSource? interruption = null) : IProgressCallback
    {
        public double MaximumPercent { get; private set; }
        public bool InterruptionRequested { get; private set; }

        public void Reporting(double percent)
        {
            MaximumPercent = Math.Max(MaximumPercent, percent);
            if (interruption != null && !InterruptionRequested && percent > 0)
            {
                InterruptionRequested = true;
                interruption.Interrupt();
            }
        }
    }
}
```

## **Expected result and checks**

The console reports 100 percent for `example-output/complete.pdf`, then reports an interrupted export. The second operation must throw [OperationCanceledException](https://learn.microsoft.com/en-us/dotnet/api/system.operationcanceledexception) or stop below 100 percent after requesting interruption. Callback frequency varies by export path. The downloaded project additionally records callback arrays and checks that the input unlocks after disposal.

## **Learn more**

- [Support For Interruptable Library](/slides/net/support-for-interruptable-library/)
- [Convert PPT and PPTX to PDF in .NET [Advanced Features Included]](/slides/net/convert-powerpoint-to-pdf/)
- [Convert PowerPoint Presentations to Animated GIFs in .NET](/slides/net/convert-powerpoint-to-animated-gif/)


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
