---
title: Protect Exported PDF Files
type: docs
weight: 40
url: /net/examples/protection-signatures/pdf-security/
description: "Set a PDF opening password and requested printing permissions during presentation export."
keywords:
- C# example
- .NET
- presentation
- Aspose.Slides
---

Set a PDF opening password and requested printing permissions during presentation export.

## Download and run

Download [the complete project](example.zip) and open **Example.sln** in a compatible IDE. Automatic NuGet restore should run when it opens. The project accepts supported installed release SDKs instead of requiring one exact patch. [Setup and supported environments](/slides/net/examples/getting-started/) explains native libraries, fonts and the SDK/runtime distinction.

```text
dotnet run --project Example.csproj -- --mode evaluation
```

Evaluation mode needs no license and retains the SDK watermark/text limits. For full licensed checks, set ASPOSE_LICENSE_PATH to your authorized license and use --mode licensed. Fonts and synthetic fixtures needed by this recipe are included or acquired as documented. The supplied bootstrap prepares a separate output workspace and prints its absolute path. The complete download includes that bootstrap, solution and editor profiles; the C# block below is Program.cs from the same archive.


## Input and prerequisites

Use a supported .NET SDK with the supplied project. Evaluation mode runs without a license; licensed mode requires your own authorized license covering this release. No license is distributed.

All presentation input is created by the code from original synthetic data.

[Download the complete project](example.zip), including code, solution, project and required helpers. Normal package restore is supported.

## Example

PdfOptions.Password sets the PDF user/open password. AccessPermissions grants printing in this example while omitting the copy and modify flags. The program creates its own presentation and preserves it while exporting the encrypted PDF.

```csharp
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;

internal static class Program
{
    private static ExampleContext Context = null!;
    private static Task<int> Main(string[] args) => ExampleBootstrap.RunAsync(args, async context =>
    {
        Context = context;
        context.BeginAction("protection-signatures/pdf-security/block-001");
        RunExample();
        await Task.CompletedTask;
        context.Pass("protection-signatures/pdf-security/block-001", "recipe semantic assertions", "source inputs preserved", "documented output generated");
    });

    private static void RunExample()
    {
        using (var original = new Presentation())
        {
            Label(original.Slides[0], "Protected PDF example");
            original.Save("original.pptx", SaveFormat.Pptx);
        }
        string originalHash = Hash("original.pptx");
        using (var presentation = new Presentation("original.pptx"))
        {
            var options = new PdfOptions
            {
                Password = "reader-demo",
                AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint
            };
            presentation.Save("protected.pdf", SaveFormat.Pdf, options);
        }
        Require(new FileInfo("protected.pdf").Length > 100, "PDF export is empty.");
        Require(Hash("original.pptx") == originalHash, "Original changed.");
        Report(new { exported = true, original_unchanged = true });
    }


    private static void Require(bool condition, string message)
    {
        if (!condition) throw new InvalidOperationException(message);
    }
    private static IAutoShape Label(IBaseSlide slide, string text, float y = 50)
    {
        var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, y, 560, 90);
        shape.TextFrame.Text = text;
        shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 24;
        return shape;
    }
    private static string Hash(string path) => Convert.ToHexString(SHA256.HashData(File.ReadAllBytes(path))).ToLowerInvariant();
    private static void Report(object checks)
    {
        string json = JsonSerializer.Serialize(new { checks }, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("result.json", json);
        Console.WriteLine(json);
    }
    private static void Render(ISlide slide, string output)
    {
        using var image = slide.GetImage(new Size(640, 360));
        image.Save(output, Aspose.Slides.ImageFormat.Png);
    }
}
```

## Run and inspect the result

Extract the download into an empty directory and run:

```text
dotnet restore Example.sln
dotnet run --project Example.csproj --configuration Release --no-restore -- --mode evaluation -- --mode evaluation
```

The code writes "original.pptx", "protected.pdf", plus "result.json". Checks stop execution on an unexpected result; inspect visual outputs as well as the recorded data.

## Practical limits

The API demonstrated here exposes an opening password and access permissions; it does not expose a separate selectable owner-password property. Permission enforcement depends on the PDF viewer and is not absolute copy prevention. Use your own secrets for real documents. Verify exported files with a separate PDF reader, not only the export return value.

Read the [detailed guide](/slides/net/convert-powerpoint-to-pdf/) for the full API and platform requirements.
