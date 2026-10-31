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
description: "Work with Ink in Aspose.Slides for .NET: draw, import, and edit strokes, adjust color and width, and export to PPT, PPTX, and ODP using C# examples."
---

This article provides examples of accessing existing ink shapes and removing them using **Aspose.Slides for .NET**.

> ❗ **Note:** Ink shapes represent user input from specialized devices. Aspose.Slides cannot create new ink strokes programmatically, but you can read and modify existing ink.

## Download and run

[Download the complete project](example.zip), extract it, and open `Example.sln` or run:

```console
dotnet restore Example.sln
dotnet run --project Example.csproj -- --mode evaluation
```

The download includes every case below, its fixture helpers and inputs. `Program.cs` runs all cases; use `--action block-001` to run one independently. Outputs and an action report are written to the printed output directory. No previous example or working-directory setup is required. Evaluation adds a watermark and can truncate read-back text; the short fixtures still have explicit structural checks. For full text and no watermark, use `--mode licensed --license PATH` with your own valid license. See the [setup guide](/slides/net/examples/getting-started/) for supported SDKs and native prerequisites.

Each printed `CaseNN.cs` file is compiled verbatim with the included `Program.cs` and bootstrap. Checks run before saving and after reopening the result.

## **Access Ink**

Read the tags from the first ink shape on a slide.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Ink;

internal static partial class Program
{
    static void Case01()
    {
        using var presentation = new Presentation(Context.Input("ink.pptx"));
        var slide = presentation.Slides[0];

        var inkShape = slide.Shapes.OfType<Ink>().First();
        inkShape.CustomData.Tags["kind"] = "Ink";
        if (inkShape != null)
        {
            var tags = inkShape.CustomData.Tags;
            if (tags.Count > 0)
            {
                var tagName = tags.GetNameByIndex(0);
                Context.Require(tags[tagName] == "Ink", "Read the known Ink tag value.");
            }
        }

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-001", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<Ink>().Any(), "AccessInk: semantic check 1 failed.");
            Context.Require(p.Slides[0].Shapes.OfType<Ink>().First().CustomData.Tags.Count > 0, "AccessInk: semantic check 2 failed.");
        });
        Context.Pass("elements/ink/block-001", "AccessInk", "save-reopen-structure");
    }
}
```

## **Remove Ink**

Delete an ink shape from the slide if one exists.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Ink;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation(Context.Input("ink.pptx"));
        var slide = presentation.Slides[0];

        if (slide.Shapes.FirstOrDefault(s => s is Ink) is Ink ink)
        {
            slide.Shapes.Remove(ink);
        }

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(!p.Slides[0].Shapes.OfType<Ink>().Any(), "RemoveInk: semantic check 1 failed.");
        });
        Context.Pass("elements/ink/block-002", "RemoveInk", "save-reopen-structure");
    }
}
```
