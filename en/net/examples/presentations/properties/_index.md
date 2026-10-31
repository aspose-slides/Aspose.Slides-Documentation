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

## Download and run

Download [the complete project](example.zip) and open **Example.sln** in a compatible IDE. Automatic NuGet restore should run when it opens. The project accepts supported installed release SDKs instead of requiring one exact patch. [Setup and supported environments](/slides/net/examples/getting-started/) explains native libraries, fonts and the SDK/runtime distinction.

```text
dotnet run --project Example.csproj -- --mode evaluation
```

Evaluation mode needs no license and retains the SDK watermark/text limits. For full licensed checks, set ASPOSE_LICENSE_PATH to your authorized license and use --mode licensed. Fonts and synthetic fixtures needed by this recipe are included or acquired as documented. The supplied bootstrap prepares a separate output workspace and prints its absolute path. The complete download includes that bootstrap, solution and editor profiles; the C# block below is Program.cs from the same archive.


## Input and prerequisites

The code creates its own synthetic input. Use a compatible stable SDK with the included Aspose.Slides.NET6.CrossPlatform 26.10.0 project; .NET 10 LTS is recommended. Evaluation mode performs the recipe without a license and retains the SDK watermark and text limits. Licensed mode additionally checks unrestricted content using your authorized license.

[Download the complete project](example.zip), including the solution, source, configuration and bundled fonts. No license is distributed.

## Example

GetPresentationInfo reads the file format and encryption state before a full load. The editing block changes selected built-in values and sets custom string, integer, Boolean, date and floating-point values. The final block reads each custom value with its matching typed overload.

```csharp
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static class Program
{
    private static ExampleContext Context = null!;
    private static Task<int> Main(string[] args) => ExampleBootstrap.RunAsync(args, async context =>
    {
        Context = context;
        context.BeginAction("presentations/properties/block-001");
        RunExample();
        await Task.CompletedTask;
        context.Pass("presentations/properties/block-001", "recipe semantic assertions", "source inputs preserved", "documented output generated");
    });

    private static void RunExample()
    {
        DateTime reviewDate = new DateTime(2026, 10, 1, 12, 0, 0, DateTimeKind.Utc);
        using (var created = new Presentation())
        {
            Label(created.Slides[0], "Metadata example");
            created.DocumentProperties.Title = "Original title";
            created.DocumentProperties.Subject = "Retain this subject";
            created.DocumentProperties.SetCustomPropertyValue("Existing", "keep");
            created.Save("input.pptx", SaveFormat.Pptx);
        }
        string inputHash = Hash("input.pptx");
        var info = PresentationFactory.Instance.GetPresentationInfo("input.pptx");
        Require(info.LoadFormat == LoadFormat.Pptx && !info.IsEncrypted, "Unexpected input format/security state.");
        using (var editable = new Presentation("input.pptx"))
        {
            var properties = editable.DocumentProperties;
            properties.Title = "Reviewed presentation";
            properties.Author = "Example author";
            properties.SetCustomPropertyValue("Customer", "Example company");
            properties.SetCustomPropertyValue("Revision", 7);
            properties.SetCustomPropertyValue("Approved", true);
            properties.SetCustomPropertyValue("ReviewDate", reviewDate);
            properties.SetCustomPropertyValue("Total", 123.5);
            editable.Save("output.pptx", SaveFormat.Pptx);
        }
        using (var reopened = new Presentation("output.pptx"))
        {
            var properties = reopened.DocumentProperties;
            properties.GetCustomPropertyValue("Customer", out string customer);
            properties.GetCustomPropertyValue("Revision", out int revision);
            properties.GetCustomPropertyValue("Approved", out bool approved);
            properties.GetCustomPropertyValue("ReviewDate", out DateTime actualDate);
            properties.GetCustomPropertyValue("Total", out double total);
            properties.GetCustomPropertyValue("Existing", out string existing);
            Require(properties.Title == "Reviewed presentation" && properties.Author == "Example author", "Built-in values differ.");
            Require(customer == "Example company" && revision == 7 && approved && actualDate.ToUniversalTime() == reviewDate && total == 123.5, "Typed custom values differ.");
            Require(existing == "keep" && properties.Subject == "Retain this subject", "Unrelated properties changed.");
            Require(reopened.Slides.Count == 1 && Text(reopened.Slides[0]) == Context.ExpectedText("Metadata example"), "Presentation content changed.");
        }
        Require(Hash("input.pptx") == inputHash, "Original metadata file changed.");
        Report(new { built_in_properties = true, string_value = true, integer_value = true, boolean_value = true, date_value = true, numeric_value = true, unrelated_retained = true, content_retained = true, input_format = "Pptx", original_unchanged = true });
    }


    private static void Require(bool condition, string message)
    {
        if (!condition) throw new InvalidOperationException(message);
    }

    private static IAutoShape Label(ISlide slide, string text)
    {
        var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 80, 540, 100);
        shape.Name = "content-" + text;
        shape.TextFrame.Text = text;
        shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 28;
        return shape;
    }

    private static string Text(ISlide slide) => string.Join("|", slide.Shapes.OfType<IAutoShape>().Where(s => s.Name.StartsWith("content-", StringComparison.Ordinal)).Select(s => s.TextFrame.Text));
    private static string Hash(string file) => Convert.ToHexString(SHA256.HashData(File.ReadAllBytes(file)));
    private static void Report(object checks)
    {
        string json = JsonSerializer.Serialize(new { checks }, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("result.json", json);
        Console.WriteLine(json);
    }
}
```

## Run and check the result

Extract the project into an empty working directory, restore its locked packages, then run it:

```text
dotnet restore Example.csproj --locked-mode
dotnet run --project Example.csproj --configuration Release --no-restore
```

The example writes "input.pptx", "output.pptx" and "result.json". It reopens the generated presentation files and checks the expected data. A failed check raises an exception; successful checks are recorded in "result.json".


## Practical limits

Choose custom property types explicitly and normalize date/time handling in your application. Metadata can contain private information; only set values intended for the output. This example edits selected fields and does not claim to sanitize all metadata.

See the [detailed guide](/slides/net/presentation-properties/) and [individual slide examples](/slides/net/examples/elements/slide/).
