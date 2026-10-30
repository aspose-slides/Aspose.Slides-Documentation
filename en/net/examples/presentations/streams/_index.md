---
title: Work with Presentation Streams
type: docs
weight: 20
url: /net/examples/presentations/streams/
description: "Load and save presentation streams while controlling their positions and lifetimes."
keywords:
- presentation example
- C#
- .NET
- Aspose.Slides
---

Load and save presentation streams while controlling their positions and lifetimes.

## Input and prerequisites

The code creates its own synthetic input; no presentation or image download is required. Use .NET 8 SDK 8.0.427 and Aspose.Slides for .NET 26.10.0; the supplied project pins these versions and was tested on Windows. Set the **ASPOSE_LICENSE_PATH** environment variable to your own valid license file to run every assertion in this complete example. Evaluation limits can change the saved content, so the program fails clearly when no license has been applied.

[Download the complete project](example.zip), including the pinned project, package lock and the code below. The license file is not included.

## Example

Both MemoryStream and FileStream are reset to position zero before loading. The caller keeps its streams alive until the Presentation is disposed, then copies the saved bytes with ToArray. The final reopen happens after the editing streams have been disposed.

```csharp
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
    private static void Main()
    {
        ApplyLicense();
        byte[] inputBytes;
        using (var created = new Presentation())
        using (var output = new MemoryStream())
        {
            Label(created.Slides[0], "Stream input");
            created.Save(output, SaveFormat.Pptx);
            inputBytes = output.ToArray(); // Independent bytes survive stream disposal.
        }
        File.WriteAllBytes("input.pptx", inputBytes);
        string originalHash = Hash("input.pptx");
        byte[] editedBytes;
        using (var input = new MemoryStream(inputBytes))
        using (var output = new MemoryStream())
        {
            input.Position = input.Length; // A reused stream need not be positioned at its start.
            input.Position = 0;            // Explicitly reset before passing it to the reader.
            using (var editable = new Presentation(input))
            {
                editable.Slides[0].Shapes.OfType<IAutoShape>().Single().TextFrame.Text = "Stream output";
                editable.Save(output, SaveFormat.Pptx);
            }
            Require(input.CanRead && output.CanWrite, "Caller-owned streams unexpectedly closed.");
            editedBytes = output.ToArray();
        }
        using (var returnedInput = new MemoryStream(editedBytes))
        using (var afterDisposal = new Presentation(returnedInput))
            Require(Text(afterDisposal.Slides[0]) == "Stream output", "Returned bytes are not independent.");
        using (var file = File.OpenRead("input.pptx"))
        {
            file.Position = Math.Min(10, file.Length);
            file.Position = 0;
            using (var loaded = new Presentation(file))
                Require(Text(loaded.Slides[0]) == "Stream input", "File stream did not load correctly.");
            Require(file.CanRead, "The caller must retain ownership of the file stream.");
        }
        File.WriteAllBytes("output.pptx", editedBytes);
        Require(Hash("input.pptx") == originalHash, "Input bytes changed.");
        Report(new { bytes_reopened = true, streams_owned_by_caller = true, position_reset = true, original_unchanged = true });
    }

    private static void ApplyLicense()
    {
        string? path = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        var license = new Aspose.Slides.License();
        if (!string.IsNullOrWhiteSpace(path)) license.SetLicense(path);
        if (!license.IsLicensed())
            throw new InvalidOperationException("Set ASPOSE_LICENSE_PATH to a valid license file for this complete example.");
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

    private static string Text(ISlide slide) => string.Join("|", slide.Shapes.OfType<IAutoShape>().Select(s => s.TextFrame.Text));
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

The example uses readable, seekable streams. Do not assume an arbitrary HTTP request stream has these capabilities; buffer it explicitly when necessary. ToArray returns a separate byte array and does not depend on the current stream position.

See the [detailed guide](/slides/net/open-presentation/) and [individual slide examples](/slides/net/examples/elements/slide/).
