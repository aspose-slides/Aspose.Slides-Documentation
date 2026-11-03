---
title: Collect Rendering and Export Warnings
type: docs
weight: 60
url: /net/examples/optimization-batch/warnings/
description: "Collect a real missing-font export warning and distinguish a completed conversion with warnings from a failed corrupt-file conversion."
---

Collect a real missing-font export warning and distinguish a completed conversion with warnings from a failed corrupt-file conversion.

<span id="run-the-example"></span>

## **Example**

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.
The copied program writes its files under `example-output` by default.

The generated source deliberately requests a nonexistent font. Warnings continue the PDF export and are printed with their type and description. A separate corrupt input demonstrates failure cleanup.

```csharp
using System.Collections.Generic;
using System.IO;
using System;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;
using Aspose.Slides;

internal static class Program
{
    private static int Main()
    {
        var licensePath = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        if (!string.IsNullOrWhiteSpace(licensePath))
            new License().SetLicense(licensePath);
        var outputDirectory = Directory.CreateDirectory("example-output").FullName;
        using (var input = new Presentation())
        {
            var text = input.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 600, 80);
            text.TextFrame.Text = "Font substitution warning fixture";
            text.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("Example_Missing_Font_734991");
            input.Save("example-output/input.pptx", SaveFormat.Pptx);
        }

        var warningCollector = new ExportWarnings();
        using (var presentation = new Presentation("example-output/input.pptx"))
        {
            var options = new PdfOptions
            {
                WarningCallback = warningCollector
            };
            presentation.Save("example-output/with-warning.pdf", SaveFormat.Pdf, options);
        }

        foreach (var warning in warningCollector.Items)
            Console.WriteLine($"{warning.Type}: {warning.Description}");
        // A failed input is separate from a successful export with warnings.
        const string failedOutput = "example-output/should-not-exist.pdf";
        File.WriteAllBytes("example-output/corrupt.pptx", new byte[] { 0x50, 0x4b, 3, 4, 0, 0, 0 });
        var corruptInputRejected = false;
        try
        {
            using var invalid = new Presentation("example-output/corrupt.pptx", new LoadOptions { LoadFormat = LoadFormat.Pptx });
            invalid.Save(failedOutput, SaveFormat.Pdf);
            Console.Error.WriteLine("The corrupt-input control unexpectedly completed.");
        }
        catch (Exception error)
        {
            corruptInputRejected = true;
            Console.WriteLine("Corrupt input failed: " + error.GetType().Name);
        }
        finally
        {
            if (File.Exists(failedOutput))
                File.Delete(failedOutput);
        }

        if (!corruptInputRejected) return 1;
        Console.WriteLine("Output: " + outputDirectory);
        return 0;
    }

    private sealed record ExportWarning(string Type, string Description);
    private sealed class ExportWarnings : IWarningCallback
    {
        public List<ExportWarning> Items { get; } = new();

        public ReturnAction Warning(IWarningInfo warning)
        {
            Items.Add(new ExportWarning(warning.WarningType.ToString(), warning.Description));
            return ReturnAction.Continue;
        }
    }
}
```

## **Expected result and checks**

`example-output/with-warning.pdf` remains available despite font warnings. The failed control leaves no PDF. The downloaded project additionally checks the callback and failure report.

## **Learn more**

- [Handle Presentation Warnings in .NET](/slides/net/presentation-warnings/)
- [Configure Font Substitution in Presentations in .NET](/slides/net/font-substitution/)


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
