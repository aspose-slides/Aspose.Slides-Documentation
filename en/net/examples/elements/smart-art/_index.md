---
title: SmartArt
type: docs
weight: 140
url: /net/examples/elements/smart-art/
keywords:
- SmartArt
- add SmartArt
- access SmartArt
- remove SmartArt
- SmartArt layout
- code example
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Work with SmartArt in Aspose.Slides for .NET: create, edit, convert, and style diagrams with C# for PowerPoint and OpenDocument presentations."
---

This article demonstrates how to add SmartArt graphics, access them, remove them, and change layouts using **Aspose.Slides for .NET**.

## Download and run

[Download the complete project](example.zip), extract it, and open `Example.sln` or run:

```console
dotnet restore Example.sln
dotnet run --project Example.csproj -- --mode evaluation
```

The download includes every case below, its fixture helpers and inputs. `Program.cs` runs all cases; use `--action block-001` to run one independently. Outputs and an action report are written to the printed output directory. No previous example or working-directory setup is required. Evaluation adds a watermark and can truncate read-back text; the short fixtures still have explicit structural checks. For full text and no watermark, use `--mode licensed --license PATH` with your own valid license. See the [setup guide](/slides/net/examples/getting-started/) for supported SDKs and native prerequisites.

Each printed `CaseNN.cs` file is compiled verbatim with the included `Program.cs` and bootstrap. Checks run before saving and after reopening the result.

## **Add SmartArt**

Insert a SmartArt graphic using one of the built-in layouts.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

internal static partial class Program
{
    static void Case01()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-001", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<ISmartArt>().Single().Layout == SmartArtLayoutType.BasicProcess, "AddSmartArt: semantic check 1 failed.");
        });
        Context.Pass("elements/smart-art/block-001", "AddSmartArt", "save-reopen-structure");
    }
}
```

## **Access SmartArt**

Retrieve the first SmartArt object on a slide.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

        var firstSmartArt = slide.Shapes.OfType<ISmartArt>().First();

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<ISmartArt>().Single().AllNodes.Count > 0, "AccessSmartArt: semantic check 1 failed.");
        });
        Context.Pass("elements/smart-art/block-002", "AccessSmartArt", "save-reopen-structure");
    }
}
```

## **Remove SmartArt**

Delete a SmartArt shape from the slide.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

internal static partial class Program
{
    static void Case03()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

        slide.Shapes.Remove(smartArt);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(!p.Slides[0].Shapes.OfType<ISmartArt>().Any(), "RemoveSmartArt: semantic check 1 failed.");
        });
        Context.Pass("elements/smart-art/block-003", "RemoveSmartArt", "save-reopen-structure");
    }
}
```

## **Change SmartArt Layout**

Update the layout type of an existing SmartArt graphic.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

internal static partial class Program
{
    static void Case04()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);

        smartArt.Layout = SmartArtLayoutType.VerticalPictureList;

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-004", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<ISmartArt>().Single().Layout == SmartArtLayoutType.VerticalPictureList, "ChangeSmartArtLayout: semantic check 1 failed.");
        });
        Context.Pass("elements/smart-art/block-004", "ChangeSmartArtLayout", "save-reopen-structure");
    }
}
```
