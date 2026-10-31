---
title: Slide Transition
type: docs
weight: 110
url: /net/examples/elements/slide-transition/
keywords:
- slide transition
- add slide transition
- access slide transition
- remove slide transition
- transition duration
- code example
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Master slide transitions in Aspose.Slides for .NET: add, customize, and sequence effects and durations with C# examples for PPT, PPTX, and ODP presentations."
---

This article demonstrates applying slide transition effects and timings with **Aspose.Slides for .NET**.

## Download and run

[Download the complete project](example.zip), extract it, and open `Example.sln` or run:

```console
dotnet restore Example.sln
dotnet run --project Example.csproj -- --mode evaluation
```

The download includes every case below, its fixture helpers and inputs. `Program.cs` runs all cases; use `--action block-001` to run one independently. Outputs and an action report are written to the printed output directory. No previous example or working-directory setup is required. Evaluation adds a watermark and can truncate read-back text; the short fixtures still have explicit structural checks. For full text and no watermark, use `--mode licensed --license PATH` with your own valid license. See the [setup guide](/slides/net/examples/getting-started/) for supported SDKs and native prerequisites.

Each printed `CaseNN.cs` file is compiled verbatim with the included `Program.cs` and bootstrap. Checks run before saving and after reopening the result.

## **Add a Slide Transition**

Apply a fade transition effect to the first slide.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

internal static partial class Program
{
    static void Case01()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        // Apply a fade transition.
        slide.SlideShowTransition.Type = TransitionType.Fade;

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-001", p =>
        {
            Context.Require(p.Slides[0].SlideShowTransition.Type == TransitionType.Fade, "AddSlideTransition: semantic check 1 failed.");
        });
        Context.Pass("elements/slide-transition/block-001", "AddSlideTransition", "save-reopen-structure");
    }
}
```

## **Access a Slide Transition**

Read the transition type currently assigned to a slide.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        slide.SlideShowTransition.Type = TransitionType.Push;

        // Access the transition type.
        var type = slide.SlideShowTransition.Type;

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.Slides[0].SlideShowTransition.Type == TransitionType.Push, "AccessSlideTransition: semantic check 1 failed.");
        });
        Context.Pass("elements/slide-transition/block-002", "AccessSlideTransition", "save-reopen-structure");
    }
}
```

## **Remove a Slide Transition**

Clear any transition effect by setting the type to `None`.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

internal static partial class Program
{
    static void Case03()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        slide.SlideShowTransition.Type = TransitionType.Fade;

        // Remove transition by setting none.
        slide.SlideShowTransition.Type = TransitionType.None;

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(p.Slides[0].SlideShowTransition.Type == TransitionType.None, "RemoveSlideTransition: semantic check 1 failed.");
        });
        Context.Pass("elements/slide-transition/block-003", "RemoveSlideTransition", "save-reopen-structure");
    }
}
```

## **Set Transition Duration**

Specify how long the slide is displayed before advancing automatically.

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

        slide.SlideShowTransition.AdvanceOnClick = true;
        slide.SlideShowTransition.AdvanceAfterTime = 2000; // in milliseconds

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-004", p =>
        {
            Context.Require(p.Slides[0].SlideShowTransition.AdvanceOnClick && p.Slides[0].SlideShowTransition.AdvanceAfterTime == 2000, "SetTransitionDuration: semantic check 1 failed.");
        });
        Context.Pass("elements/slide-transition/block-004", "SetTransitionDuration", "save-reopen-structure");
    }
}
```
