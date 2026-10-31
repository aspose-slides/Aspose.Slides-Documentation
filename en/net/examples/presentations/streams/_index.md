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

Both MemoryStream and FileStream are reset to position zero before loading. The caller keeps its streams alive until the Presentation is disposed, then copies the saved bytes with ToArray. The final reopen happens after the editing streams have been disposed.

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
        context.BeginAction("presentations/streams/block-001");
        RunExample();
        await Task.CompletedTask;
        context.Pass("presentations/streams/block-001", "recipe semantic assertions", "source inputs preserved", "documented output generated");
    });

    private static void RunExample()
    {
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
                editable.Slides[0].Shapes.OfType<IAutoShape>().Single(s => s.Name.StartsWith("content-", StringComparison.Ordinal)).TextFrame.Text = "Stream output";
                editable.Save(output, SaveFormat.Pptx);
            }
            Require(input.CanRead && output.CanWrite, "Caller-owned streams unexpectedly closed.");
            editedBytes = output.ToArray();
        }
        using (var returnedInput = new MemoryStream(editedBytes))
        using (var afterDisposal = new Presentation(returnedInput))
            Require(Text(afterDisposal.Slides[0]) == Context.ExpectedText("Stream output"), "Returned bytes are not independent.");
        using (var file = File.OpenRead("input.pptx"))
        {
            file.Position = Math.Min(10, file.Length);
            file.Position = 0;
            using (var loaded = new Presentation(file))
                Require(Text(loaded.Slides[0]) == Context.ExpectedText("Stream input"), "File stream did not load correctly.");
            Require(file.CanRead, "The caller must retain ownership of the file stream.");
        }
        File.WriteAllBytes("output.pptx", editedBytes);
        Require(Hash("input.pptx") == originalHash, "Input bytes changed.");
        Report(new { bytes_reopened = true, streams_owned_by_caller = true, position_reset = true, original_unchanged = true });
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

The example uses readable, seekable streams. Do not assume an arbitrary HTTP request stream has these capabilities; buffer it explicitly when necessary. ToArray returns a separate byte array and does not depend on the current stream position.

See the [detailed guide](/slides/net/open-presentation/) and [individual slide examples](/slides/net/examples/elements/slide/).
