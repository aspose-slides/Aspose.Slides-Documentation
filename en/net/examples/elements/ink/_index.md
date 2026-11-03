---
title: Ink
type: docs
weight: 180
url: /net/examples/elements/ink/
keywords:
- ink
- access ink
- remove ink
- code example
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Set and read a tag on an existing ink shape or remove the shape with Aspose.Slides for .NET C# examples."
---

Use **Aspose.Slides for .NET** to set and read tags on an existing ink shape or remove the shape from the slide.

> ❗ **Note:** Ink shapes represent user input from specialized devices. Aspose.Slides cannot create new ink strokes programmatically, but you can read and modify existing ink.

For the copied blocks, pass the path to a PPTX with ink on its first slide, for example `dotnet run -- ink.pptx`. You can use your own deck or the [sample input](Fixtures/ink.pptx).

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.

## Download and run

[Download the complete project](example.zip), extract it, and open `Example.sln` or run:

```console
dotnet restore Example.sln
dotnet run --project Example.csproj -- --mode evaluation
```

The download includes every case below, its fixture helpers and inputs. `Program.cs` runs all cases; use `--action block-001` to run one independently. Outputs and an action report are written to the printed output directory. No previous example or working-directory setup is required. Evaluation adds a watermark and can truncate read-back text; the short fixtures still have explicit structural checks. For full text and no watermark, use `--mode licensed --license PATH` with your own valid license. See the [setup guide](/slides/net/examples/getting-started/) for supported SDKs and native prerequisites.

<a id="access-ink"></a>

## **Set and Read an Ink Tag**

Set a tag on the first ink shape and read back the known tag value.

```csharp
using System;
using Aspose.Slides.Export;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Ink;

// Pass the path to a PPTX file with ink on its first slide as the first argument.
if (args.Length != 1)
{
    Console.WriteLine("Usage: dotnet run -- <ink.pptx>");
    return;
}

using var presentation = new Presentation(args[0]);
var slide = presentation.Slides[0];

var inkShape = slide.Shapes.OfType<Ink>().First();
inkShape.CustomData.Tags["kind"] = "Ink";
var tags = inkShape.CustomData.Tags;
if (tags.Count > 0)
{
    var tagName = tags.GetNameByIndex(0);
    Console.WriteLine($"{tagName}: {tags[tagName]}");
}

presentation.Save("ink-01.pptx", SaveFormat.Pptx);
```

## **Remove Ink**

Delete an ink shape from the slide if one exists.

```csharp
using System;
using Aspose.Slides.Export;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Ink;

// Pass the path to a PPTX file with ink on its first slide as the first argument.
if (args.Length != 1)
{
    Console.WriteLine("Usage: dotnet run -- <ink.pptx>");
    return;
}

using var presentation = new Presentation(args[0]);
var slide = presentation.Slides[0];

if (slide.Shapes.FirstOrDefault(s => s is Ink) is Ink ink)
{
    slide.Shapes.Remove(ink);
}

presentation.Save("ink-02.pptx", SaveFormat.Pptx);
```
