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

## **Download and run**

Download [the complete project](example.zip) and open **Example.sln** in a compatible IDE. Automatic NuGet restore should run when it opens. The project accepts supported installed release SDKs instead of requiring one exact patch. [Setup and supported environments](/slides/net/examples/getting-started/) explains native libraries, fonts and the SDK/runtime distinction.

```text
dotnet run --project Example.csproj -- --mode evaluation
```

Evaluation mode needs no license and retains the SDK watermark/text limits. For full licensed checks, set ASPOSE_LICENSE_PATH to your authorized license and use --mode licensed. Fonts and synthetic fixtures needed by this recipe are included or acquired as documented. The supplied bootstrap prepares a separate output workspace and prints its absolute path. The complete download includes the bootstrap, solution and editor profiles.


## **Input and prerequisites**

Use a supported .NET SDK with the supplied project. Evaluation mode runs without a license; licensed mode requires your own authorized license covering this release. No license is distributed.

All presentation input is created by the code from original synthetic data.

## **Example**

PdfOptions.Password sets the PDF user/open password. AccessPermissions grants printing in this example while omitting the copy and modify flags. The program creates its own presentation and preserves it while exporting the encrypted PDF.

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.
The copied program writes its files under `example-output` by default.

The program generates its input. The PDF open password `reader-demo` is for demonstration. The permissions allow printing and high-quality printing; copying and modification are not granted. These settings apply to the PDF, while `original.pptx` remains readable.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static class Program
{
    private static void Main()
    {
        var licensePath = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        if (!string.IsNullOrWhiteSpace(licensePath))
            new License().SetLicense(licensePath);
        var outputDirectory = Directory.CreateDirectory("example-output").FullName;
        const string demoOpenPassword = "reader-demo";
        const string sourcePath = "example-output/original.pptx";
        const string pdfPath = "example-output/protected.pdf";
        using (var source = new Presentation())
        {
            Label(source.Slides[0], "Protected PDF example");
            source.Save(sourcePath, SaveFormat.Pptx);
        }

        using var presentation = new Presentation(sourcePath);
        var pdfSecurity = new PdfOptions
        {
            Password = demoOpenPassword,
            AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint
        };
        presentation.Save(pdfPath, SaveFormat.Pdf, pdfSecurity);
        Console.WriteLine($"Saved {pdfPath}; use the demonstration password to open it.");
        Console.WriteLine("Output: " + outputDirectory);
    }

    private static IAutoShape Label(IBaseSlide slide, string text, float y = 50)
    {
        var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, y, 560, 90);
        shape.TextFrame.Text = text;
        shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 24;
        return shape;
    }
}
```

## **Run and inspect the result**

Extract the download into an empty directory and run:

```text
dotnet restore Example.sln
dotnet run --project Example.csproj --configuration Release --no-restore -- --mode evaluation
```

The code writes "original.pptx", "protected.pdf", plus "result.json". Checks stop execution on an unexpected result; inspect visual outputs as well as the recorded data.

## **Practical limits**

The API demonstrated here exposes an opening password and access permissions; it does not expose a separate selectable owner-password property. Permission enforcement depends on the PDF viewer and is not absolute copy prevention. Use your own secrets for real documents. Verify exported files with a separate PDF reader, not only the export return value.

Read the [detailed guide](/slides/net/convert-powerpoint-to-pdf/) for the full API and platform requirements.
