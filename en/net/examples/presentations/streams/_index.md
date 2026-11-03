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

Evaluation mode needs no license and retains the SDK watermark/text limits. For full licensed checks, set ASPOSE_LICENSE_PATH to your authorized license and use --mode licensed. Fonts and synthetic fixtures needed by this recipe are included or acquired as documented. The supplied bootstrap prepares a separate output workspace and prints its absolute path. The complete download includes the bootstrap, solution and editor profiles.


## Input and prerequisites

The code creates its own synthetic input. Use a compatible stable SDK with the included Aspose.Slides.NET6.CrossPlatform 26.10.0 project; .NET 10 LTS is recommended. Evaluation mode performs the recipe without a license and retains the SDK watermark and text limits. Licensed mode additionally checks unrestricted content using your authorized license.

[Download the complete project](example.zip), including the solution, source, configuration and bundled fonts. No license is distributed.

## Example

Both MemoryStream and FileStream are reset to position zero before loading. The caller keeps its streams alive until the Presentation is disposed, then copies the saved bytes with ToArray. The final reopen happens after the editing streams have been disposed.

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

byte[] originalBytes;
using (var presentation = new Presentation())
using (var output = new MemoryStream())
{
    var shape = presentation.Slides[0].Shapes.AddAutoShape(
        ShapeType.Rectangle, 50, 80, 350, 80);
    shape.TextFrame.Text = "Input";
    presentation.Save(output, SaveFormat.Pptx);
    originalBytes = output.ToArray();
}
File.WriteAllBytes("input.pptx", originalBytes);

byte[] editedBytes;
using (var input = new MemoryStream(originalBytes))
using (var output = new MemoryStream())
{
    input.Position = input.Length; // Simulate a stream used by the caller.
    input.Position = 0;
    using (var presentation = new Presentation(input))
    {
        var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
        shape.TextFrame.Text = "Edit";
        presentation.Save(output, SaveFormat.Pptx);
    }

    // The caller still owns both streams after disposing the presentation.
    if (!input.CanRead || !output.CanWrite)
        throw new InvalidOperationException("A caller-owned stream was closed.");
    editedBytes = output.ToArray();
}

// The copied bytes survive disposal of the editing streams.
using (var input = new MemoryStream(editedBytes))
using (var presentation = new Presentation(input))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
    Console.WriteLine($"Reopened edited text: {shape.TextFrame.Text}");
}

using (var input = File.OpenRead("input.pptx"))
{
    input.ReadByte();
    input.Position = 0;
    using var presentation = new Presentation(input);
    Console.WriteLine($"Loaded {presentation.Slides.Count} slide from a file stream.");
}

File.WriteAllBytes("output.pptx", editedBytes);
```

## Run the downloaded project

Extract the project into an empty working directory, restore its packages, then run it:

```text
dotnet restore Example.csproj
dotnet run --project Example.csproj --configuration Release --no-restore
```

The copied program writes `input.pptx` and `output.pptx` in the working directory. The downloaded project also writes `result.json`. It reopens the generated presentation files and checks the expected data. A failed check raises an exception; successful checks are recorded in "result.json".


## Practical limits

The example uses readable, seekable streams. Do not assume an arbitrary HTTP request stream has these capabilities; buffer it explicitly when necessary. ToArray returns a separate byte array and does not depend on the current stream position.

See the [detailed guide](/slides/net/open-presentation/) and [individual slide examples](/slides/net/examples/elements/slide/).
