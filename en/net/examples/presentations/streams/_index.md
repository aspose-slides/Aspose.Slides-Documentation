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

## **Input and prerequisites**

The copied program generates its own input. See the [setup guide](/slides/net/examples/getting-started/) for supported SDKs and native dependencies. Evaluation output includes the SDK watermark and text limits.

## **Example**

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
    var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 80, 350, 80);
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
    {
        Console.Error.WriteLine("A caller-owned stream was closed.");
        return;
    }

    editedBytes = output.ToArray();
}

// The copied bytes survive disposal of the editing streams.
using (var input = new MemoryStream(editedBytes))
using (var presentation = new Presentation(input))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
    Console.WriteLine($"MemoryStream edited text: {shape.TextFrame.Text}");
}

using (var input = File.OpenRead("input.pptx"))
{
    input.ReadByte();
    input.Position = 0;
    using var presentation = new Presentation(input);
    Console.WriteLine($"FileStream loaded {presentation.Slides.Count} slide after reset.");
}

File.WriteAllBytes("output.pptx", editedBytes);
```

<span id="run-the-downloaded-project"></span>

## **Download and run**

[Download the complete project](example.zip), extract it, and open `Example.sln` or run the following commands.

```text
dotnet restore Example.sln
dotnet run --project Example.csproj --configuration Release --no-restore -- --mode evaluation
```

The copied program writes `input.pptx` and `output.pptx` in the working directory. The downloaded project also writes `result.json`. It reopens the generated presentation files and checks the expected data. A failed check raises an exception; successful checks are recorded in "result.json".

Use `--mode licensed` with your authorized `ASPOSE_LICENSE_PATH` for unrestricted checks. The project prints its output directory.


## **Practical limits**

The example uses readable, seekable streams. Do not assume an arbitrary HTTP request stream has these capabilities; buffer it explicitly when necessary. ToArray returns a separate byte array and does not depend on the current stream position.

See the [detailed guide](/slides/net/open-presentation/) and [individual slide examples](/slides/net/examples/elements/slide/).
