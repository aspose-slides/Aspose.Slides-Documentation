---
title: Read and Update Presentation Properties
type: docs
weight: 50
url: /net/examples/presentations/properties/
description: "Read file information, update metadata, and retain the presentation content and unrelated properties."
keywords:
- presentation example
- C#
- .NET
- Aspose.Slides
---

Read file information, update metadata, and retain the presentation content and unrelated properties.

## **Input and prerequisites**

The copied program generates its own input. See the [setup guide](/slides/net/examples/getting-started/) for supported SDKs and native dependencies. Evaluation output includes the SDK watermark and text limits.

## **Example**

GetPresentationInfo reads the file format and encryption state before a full load. The editing block changes selected built-in values and sets custom string, integer, Boolean, date and floating-point values. The final block reads each custom value with its matching typed overload.

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.
The copied program writes its files in the current working directory.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static class Program
{
    private static void Main()
    {
        string? licensePath = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        if (!string.IsNullOrWhiteSpace(licensePath))
            new License().SetLicense(licensePath);

        const string sourcePath = "input.pptx";
        const string copyPath = "output.pptx";
        DateTime reviewDate = new DateTime(2026, 10, 1, 12, 0, 0, DateTimeKind.Utc);
        using (var created = new Presentation())
        {
            AddTitle(created.Slides[0], "Data");
            created.DocumentProperties.Title = "Original title";
            created.DocumentProperties.Subject = "Retain this subject";
            created.DocumentProperties.SetCustomPropertyValue("Existing", "keep");
            created.Save(sourcePath, SaveFormat.Pptx);
        }

        var info = PresentationFactory.Instance.GetPresentationInfo(sourcePath);
        Console.WriteLine($"Input: {info.LoadFormat}; encrypted: {info.IsEncrypted}");
        using (var editable = new Presentation(sourcePath))
        {
            var properties = editable.DocumentProperties;
            properties.Title = "Reviewed presentation";
            properties.Author = "Example author";
            properties.SetCustomPropertyValue("Customer", "Example company");
            properties.SetCustomPropertyValue("Revision", 7);
            properties.SetCustomPropertyValue("Approved", true);
            properties.SetCustomPropertyValue("ReviewDate", reviewDate);
            properties.SetCustomPropertyValue("Total", 123.5);
            editable.Save(copyPath, SaveFormat.Pptx);
        }

        using (var reopened = new Presentation(copyPath))
        {
            var properties = reopened.DocumentProperties;
            properties.GetCustomPropertyValue("Customer", out string customer);
            Console.WriteLine("customer: " + customer);
            properties.GetCustomPropertyValue("Revision", out int revision);
            Console.WriteLine("revision: " + revision);
            properties.GetCustomPropertyValue("Approved", out bool approved);
            Console.WriteLine("approved: " + approved);
            properties.GetCustomPropertyValue("ReviewDate", out DateTime actualDate);
            Console.WriteLine("actualDate: " + actualDate);
            properties.GetCustomPropertyValue("Total", out double total);
            Console.WriteLine("total: " + total);
            properties.GetCustomPropertyValue("Existing", out string existing);
        }
    }

    private static IAutoShape AddTitle(ISlide slide, string text)
    {
        var title = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 20, 580, 55);
        title.Name = "RecipeTitle";
        title.TextFrame.Text = text;
        title.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 26;
        return title;
    }
}
```

<span id="run-and-check-the-result"></span>

## **Download and run**

[Download the complete project](example.zip), extract it, and open `Example.sln` or run the following commands.

```text
dotnet restore Example.sln
dotnet run --project Example.csproj --configuration Release --no-restore -- --mode evaluation
```

The downloaded project writes "input.pptx", "output.pptx" and "result.json". It reopens the generated presentation files and checks the expected data. A failed check raises an exception; successful checks are recorded in "result.json".

Use `--mode licensed` with your authorized `ASPOSE_LICENSE_PATH` for unrestricted checks. The project prints its output directory.


## **Practical limits**

Choose custom property types explicitly and normalize date/time handling in your application. Metadata can contain private information; only set values intended for the output. This example edits selected fields and does not claim to sanitize all metadata.

See the [detailed guide](/slides/net/presentation-properties/) and [individual slide examples](/slides/net/examples/elements/slide/).
