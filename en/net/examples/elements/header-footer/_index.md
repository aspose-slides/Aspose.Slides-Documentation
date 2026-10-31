---
title: Header Footer
type: docs
weight: 220
url: /net/examples/elements/header-footer/
aliases:
  - /net/examples/elements/elements/header-footer/
keywords:
- header footer
- add header footer
- update header footer
- code example
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Control slide headers and footers with Aspose.Slides for .NET: add dates, slide numbers, and custom text in PPT, PPTX, and ODP with C# examples."
---

This article demonstrates how to add footers and update date and time placeholders using **Aspose.Slides for .NET**.

## Download and run

[Download the complete project](example.zip), extract it, and open `Example.sln` or run:

```console
dotnet restore Example.sln
dotnet run --project Example.csproj -- --mode evaluation
```

The download includes every case below, its fixture helpers and inputs. `Program.cs` runs all cases; use `--action block-001` to run one independently. Outputs and an action report are written to the printed output directory. No previous example or working-directory setup is required. Evaluation adds a watermark and can truncate read-back text; the short fixtures still have explicit structural checks. For full text and no watermark, use `--mode licensed --license PATH` with your own valid license. See the [setup guide](/slides/net/examples/getting-started/) for supported SDKs and native prerequisites.

Each printed `CaseNN.cs` file is compiled verbatim with the included `Program.cs` and bootstrap. Checks run before saving and after reopening the result.

## **Add a Footer**

Add text to the footer area of a slide and make it visible.

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

        slide.HeaderFooterManager.SetFooterVisibility(isVisible: true);
        slide.HeaderFooterManager.SetFooterText("Foot");

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-001", p =>
        {
            Context.Require(p.Slides[0].HeaderFooterManager.IsFooterVisible, "AddHeaderFooter: semantic check 1 failed.");
            Context.Require(p.Slides[0].Shapes.OfType<IAutoShape>().Any(s => s.TextFrame.Text == "Foot"), "AddHeaderFooter: semantic check 2 failed.");
        });
        Context.Pass("elements/header-footer/block-001", "AddHeaderFooter", "save-reopen-structure");
    }
}
```

## **Update Date and Time**

Modify the date and time placeholder on a slide.

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

        slide.HeaderFooterManager.SetDateTimeVisibility(isVisible: true);
        slide.HeaderFooterManager.SetDateTimeText("Today");

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.Slides[0].HeaderFooterManager.IsDateTimeVisible, "UpdateDateTime: semantic check 1 failed.");
            Context.Require(p.Slides[0].Shapes.OfType<IAutoShape>().Any(s => s.TextFrame.Text == "Today"), "UpdateDateTime: semantic check 2 failed.");
        });
        Context.Pass("elements/header-footer/block-002", "UpdateDateTime", "save-reopen-structure");
    }
}
```
