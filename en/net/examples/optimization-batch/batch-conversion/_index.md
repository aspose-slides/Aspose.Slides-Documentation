---
title: Convert Multiple Presentations
type: docs
weight: 40
url: /net/examples/optimization-batch/batch-conversion/
description: "Convert mixed valid, corrupt and encrypted presentations sequentially and with at most two independent workers."
---

Convert mixed valid, corrupt and encrypted presentations sequentially and with at most two independent workers.

<span id="run-the-example"></span>

## **Example**

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.
The copied program writes its files under `example-output` by default.

No inputs are needed: the program creates three valid presentations and two failure controls. A hash of each relative input path prevents equal filenames in different folders from overwriting one another. Each job owns its presentation instance.

```csharp
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System;
using Aspose.Slides.Export;
using Aspose.Slides;

internal static class Program
{
    private static async Task Main()
    {
        var licensePath = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        if (!string.IsNullOrWhiteSpace(licensePath))
            new License().SetLicense(licensePath);
        var outputDirectory = Directory.CreateDirectory("example-output").FullName;
        CreateBatchInputs();
        var inputDirectory = Path.GetFullPath("example-output/inputs");
        var inputFiles = Directory.GetFiles(inputDirectory, "*.pptx", SearchOption.AllDirectories).OrderBy(path => path, StringComparer.Ordinal).ToArray();
        // The same files are converted with one worker, then a bound of two.
        var sequential = await ConvertBatch(inputFiles, inputDirectory, "example-output/sequential", 1);
        var parallel = await ConvertBatch(inputFiles, inputDirectory, "example-output/parallel", 2);
        foreach (var result in sequential.Concat(parallel))
            Console.WriteLine(result.Success ? $"Saved: {result.Output}" : $"Failed: {result.Source} - {result.Error}");
        Console.WriteLine("Output: " + outputDirectory);
    }

    private sealed record ConversionResult(string Source, string Output, bool Success, string? Error);
    private static async Task<ConversionResult[]> ConvertBatch(string[] inputs, string inputDirectory, string outputDirectory, int workerLimit)
    {
        Directory.CreateDirectory(outputDirectory);
        var results = new ConcurrentBag<ConversionResult>();
        var options = new ParallelOptions
        {
            MaxDegreeOfParallelism = workerLimit
        };
        await Parallel.ForEachAsync(inputs, options, (source, cancellation) =>
        {
            results.Add(ConvertOne(source, inputDirectory, outputDirectory));
            return ValueTask.CompletedTask;
        });
        return results.OrderBy(result => result.Source, StringComparer.Ordinal).ToArray();
    }

    private static ConversionResult ConvertOne(string source, string inputDirectory, string outputDirectory)
    {
        var relativePath = Path.GetRelativePath(inputDirectory, source);
        var pathBytes = Encoding.UTF8.GetBytes(relativePath);
        var identity = Convert.ToHexString(SHA256.HashData(pathBytes))[..12];
        var destination = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(source) + "-" + identity + ".pdf");
        try
        {
            if (PresentationFactory.Instance.GetPresentationInfo(source).LoadFormat != LoadFormat.Pptx)
                return new(source, destination, false, "Expected PPTX content.");
            using var presentation = new Presentation(source, new LoadOptions { LoadFormat = LoadFormat.Pptx });
            presentation.Save(destination, SaveFormat.Pdf);
            var pdfBytes = File.ReadAllBytes(destination);
            if (pdfBytes.Length < 5 || !pdfBytes.AsSpan(0, 5).SequenceEqual("%PDF-"u8))
            {
                File.Delete(destination);
                return new(source, destination, false, "The exported file has no PDF header.");
            }

            return new(source, destination, true, null);
        }
        catch (Exception error)
        {
            if (File.Exists(destination))
                File.Delete(destination);
            return new(source, destination, false, error.GetType().Name);
        }
    }

    private static void CreateBatchInputs()
    {
        Directory.CreateDirectory("example-output/inputs");
        foreach (var name in new[]
        {
            "01-first",
            "02-second",
            "05-after-failure"
        }

        )
        {
            using var presentation = new Presentation();
            var title = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 600, 80);
            title.TextFrame.Text = name;
            presentation.Save(Path.Combine("example-output/inputs", name + ".pptx"), SaveFormat.Pptx);
        }

        File.WriteAllText("example-output/inputs/03-corrupt.pptx", "This is not a presentation.");
        using var protectedInput = new Presentation();
        protectedInput.ProtectionManager.Encrypt("fixture-only");
        protectedInput.Save("example-output/inputs/04-protected.pptx", SaveFormat.Pptx);
    }
}
```

## **Expected result and checks**

Each of `example-output/sequential` and `example-output/parallel` contains three PDFs. Corrupt and password-protected inputs report failures without stopping later jobs. The download additionally measures peak workers and verifies input hashes.

## **Learn more**

- [Convert PPT and PPTX to PDF in .NET [Advanced Features Included]](/slides/net/convert-powerpoint-to-pdf/)
- [Multithreading in Aspose.Slides for .NET](/slides/net/multithreading/)


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
