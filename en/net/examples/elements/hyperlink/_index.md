---
title: Hyperlink
type: docs
weight: 130
url: /net/examples/elements/hyperlink/
keywords:
- hyperlink
- add hyperlink
- access hyperlink
- remove hyperlink
- update hyperlink
- code example
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Add and manage hyperlinks in Aspose.Slides for .NET: link text, shapes, and images, set targets and actions for PPT, PPTX, and ODP with C# examples."
---

This article demonstrates adding, accessing, removing, and updating hyperlinks on shapes using **Aspose.Slides for .NET**.

## Download and run

[Download the complete project](example.zip), extract it, and open `Example.sln` or run:

```console
dotnet restore Example.sln
dotnet run --project Example.csproj -- --mode evaluation
```

The download includes every case below, its fixture helpers and inputs. `Program.cs` runs all cases; use `--action block-001` to run one independently. Outputs and an action report are written to the printed output directory. No previous example or working-directory setup is required. Evaluation adds a watermark and can truncate read-back text; the short fixtures still have explicit structural checks. For full text and no watermark, use `--mode licensed --license PATH` with your own valid license. See the [setup guide](/slides/net/examples/getting-started/) for supported SDKs and native prerequisites.

Each printed `CaseNN.cs` file is compiled verbatim with the included `Program.cs` and bootstrap. Checks run before saving and after reopening the result.

## **Add a Hyperlink**

Create a rectangle shape with a hyperlink pointing to an external website.

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

        var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.TextFrame.Text = "Aspose";

        var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
        textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-001", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IAutoShape>().Any(s => s.TextFrame?.Paragraphs.Any(q => q.Portions.Any(t => t.PortionFormat.HyperlinkClick?.ExternalUrl == "https://www.aspose.com")) == true), "AddHyperlink: semantic check 1 failed.");
        });
        Context.Pass("elements/hyperlink/block-001", "AddHyperlink", "save-reopen-structure");
    }
}
```

## **Access a Hyperlink**

Read hyperlink information from a shape's text portion.

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

        var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.TextFrame.Text = "Aspose";

        var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
        textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

        var hyperlink = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick;

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IAutoShape>().Any(s => s.TextFrame?.Paragraphs.Any(q => q.Portions.Any(t => t.PortionFormat.HyperlinkClick?.ExternalUrl == "https://www.aspose.com")) == true), "AccessHyperlink: semantic check 1 failed.");
        });
        Context.Pass("elements/hyperlink/block-002", "AccessHyperlink", "save-reopen-structure");
    }
}
```

## **Remove a Hyperlink**

Clear the hyperlink from a shape's text.

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

        var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.TextFrame.Text = "Aspose";

        var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
        textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

        textPortion.PortionFormat.HyperlinkClick = null;

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(!p.Slides[0].Shapes.OfType<IAutoShape>().Any(s => s.TextFrame?.Paragraphs.Any(q => q.Portions.Any(t => t.PortionFormat.HyperlinkClick != null)) == true), "RemoveHyperlink: semantic check 1 failed.");
        });
        Context.Pass("elements/hyperlink/block-003", "RemoveHyperlink", "save-reopen-structure");
    }
}
```

## **Update a Hyperlink**

Change the target of an existing hyperlink. Use `HyperlinkManager` to modify text that already contains a hyperlink, which mimics how PowerPoint updates hyperlinks safely.

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
        
        var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.TextFrame.Text = "Aspose";

        var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
        textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://old.example.com");

        // Changing a hyperlink inside existing text should be done via
        // HyperlinkManager rather than setting the property directly.
        // This mimics how PowerPoint safely updates hyperlinks.
        textPortion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://new.example.com");

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-004", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IAutoShape>().Any(s => s.TextFrame?.Paragraphs.Any(q => q.Portions.Any(t => t.PortionFormat.HyperlinkClick?.ExternalUrl == "https://new.example.com")) == true), "UpdateHyperlink: semantic check 1 failed.");
        });
        Context.Pass("elements/hyperlink/block-004", "UpdateHyperlink", "save-reopen-structure");
    }
}
```
