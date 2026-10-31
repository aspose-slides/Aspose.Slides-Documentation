---
title: Group Shape
type: docs
weight: 170
url: /net/examples/elements/group-shape/
keywords:
- group
- add group shape
- access group shape
- remove group shape
- ungroup shapes
- code example
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Manage grouped shapes in Aspose.Slides for .NET: create, nest, align, reorder, and style group shapes with C# examples in PPT, PPTX, and ODP presentations."
---

Examples for creating groups of shapes, accessing them, ungrouping, and removal using **Aspose.Slides for .NET**.

## Download and run

[Download the complete project](example.zip), extract it, and open `Example.sln` or run:

```console
dotnet restore Example.sln
dotnet run --project Example.csproj -- --mode evaluation
```

The download includes every case below, its fixture helpers and inputs. `Program.cs` runs all cases; use `--action block-001` to run one independently. Outputs and an action report are written to the printed output directory. No previous example or working-directory setup is required. Evaluation adds a watermark and can truncate read-back text; the short fixtures still have explicit structural checks. For full text and no watermark, use `--mode licensed --license PATH` with your own valid license. See the [setup guide](/slides/net/examples/getting-started/) for supported SDKs and native prerequisites.

Each printed `CaseNN.cs` file is compiled verbatim with the included `Program.cs` and bootstrap. Checks run before saving and after reopening the result.

## **Add a Group Shape**

Create a group containing two basic shapes.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case01()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var group = slide.Shapes.AddGroupShape();
        group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
        group.Shapes.AddAutoShape(ShapeType.Ellipse, 60, 0, 50, 50);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-001", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IGroupShape>().Single().Shapes.Count == 2, "AddGroupShape: semantic check 1 failed.");
        });
        Context.Pass("elements/group-shape/block-001", "AddGroupShape", "save-reopen-structure");
    }
}
```

## **Access a Group Shape**

Retrieve the first group shape from a slide.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var group = slide.Shapes.AddGroupShape();
        group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

        var firstGroup = slide.Shapes.OfType<IGroupShape>().First();

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IGroupShape>().Single().Shapes.Count == 1, "AccessGroupShape: semantic check 1 failed.");
        });
        Context.Pass("elements/group-shape/block-002", "AccessGroupShape", "save-reopen-structure");
    }
}
```

## **Remove a Group Shape**

Delete a group shape from the slide.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case03()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var group = slide.Shapes.AddGroupShape();

        slide.Shapes.Remove(group);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(!p.Slides[0].Shapes.OfType<IGroupShape>().Any(), "RemoveGroupShape: semantic check 1 failed.");
        });
        Context.Pass("elements/group-shape/block-003", "RemoveGroupShape", "save-reopen-structure");
    }
}
```

## **Ungroup Shapes**

Move shapes out of a group container.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case04()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var group = slide.Shapes.AddGroupShape();
        var rect = group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

        // Move shape out of the group.
        slide.Shapes.AddClone(rect);
        group.Shapes.Remove(rect);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-004", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IGroupShape>().Single().Shapes.Count == 0 && p.Slides[0].Shapes.OfType<IAutoShape>().Any(s => s.ShapeType == ShapeType.Rectangle), "UngroupShapes: semantic check 1 failed.");
        });
        Context.Pass("elements/group-shape/block-004", "UngroupShapes", "save-reopen-structure");
    }
}
```
