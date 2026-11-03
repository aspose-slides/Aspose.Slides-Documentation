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
- slide advance timing
- code example
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Add, read and remove slide transitions, and set slide advance timing with Aspose.Slides for .NET C# examples."
---

This article demonstrates applying slide transition effects and timings with **Aspose.Slides for .NET**.

## Download and run

[Download the complete project](example.zip), extract it, and open `Example.sln` or run:

```console
dotnet restore Example.sln
dotnet run --project Example.csproj -- --mode evaluation
```

The download includes every case below, its fixture helpers and inputs. `Program.cs` runs all cases; use `--action block-001` to run one independently. Outputs and an action report are written to the printed output directory. No previous example or working-directory setup is required. Evaluation adds a watermark and can truncate read-back text; the short fixtures still have explicit structural checks. For full text and no watermark, use `--mode licensed --license PATH` with your own valid license. See the [setup guide](/slides/net/examples/getting-started/) for supported SDKs and native prerequisites.

Each printed `CaseNN.cs` file is compiled verbatim. The download checks each case in `CaseVerification.cs` before saving and after reopening the result.

## **Add a Slide Transition**

Apply a fade transition effect to the first slide.

```csharp
using Aspose.Slides;
using Aspose.Slides.SlideShow;

internal static partial class Program
{
    static void Case01()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        // Apply a fade transition.
        slide.SlideShowTransition.Type = TransitionType.Fade;

        VerifyCase01(presentation);
    }
}
```

## **Access a Slide Transition**

Read the transition type currently assigned to a slide.

```csharp
using Aspose.Slides;
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

        VerifyCase02(presentation);
    }
}
```

## **Remove a Slide Transition**

Clear any transition effect by setting the type to `None`.

```csharp
using Aspose.Slides;
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

        VerifyCase03(presentation);
    }
}
```

<a id="set-transition-duration"></a>

## **Set Slide Advance Timing**

Set the slide advance time to two seconds and allow a click to advance the slide.

```csharp
using Aspose.Slides;

internal static partial class Program
{
    static void Case04()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        slide.SlideShowTransition.AdvanceOnClick = true;
        slide.SlideShowTransition.AdvanceAfterTime = 2000; // in milliseconds

        VerifyCase04(presentation);
    }
}
```
