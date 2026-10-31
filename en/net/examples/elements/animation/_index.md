---
title: Animation
type: docs
weight: 100
url: /net/examples/elements/animation/
keywords:
- animation
- add animation
- access animation
- remove animation
- animation sequence
- code example
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Explore Aspose.Slides for .NET animation examples: add, sequence, and customize effects and transitions with C# for PPT, PPTX, and ODP presentations."
---

This article demonstrates how to create simple animations and manage their sequence using **Aspose.Slides for .NET**.

## Download and run

[Download the complete project](example.zip), extract it, and open `Example.sln` or run:

```console
dotnet restore Example.sln
dotnet run --project Example.csproj -- --mode evaluation
```

The download includes every case below, its fixture helpers and inputs. `Program.cs` runs all cases; use `--action block-001` to run one independently. Outputs and an action report are written to the printed output directory. No previous example or working-directory setup is required. Evaluation adds a watermark and can truncate read-back text; the short fixtures still have explicit structural checks. For full text and no watermark, use `--mode licensed --license PATH` with your own valid license. See the [setup guide](/slides/net/examples/getting-started/) for supported SDKs and native prerequisites.

Each printed `CaseNN.cs` file is compiled verbatim with the included `Program.cs` and bootstrap. Checks run before saving and after reopening the result.

## **Add an Animation**

Create a rectangle shape and apply a fade effect triggered on click.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

internal static partial class Program
{
    static void Case01()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);

        // Fade effect.
        slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-001", p =>
        {
            Context.Require(p.Slides[0].Timeline.MainSequence.Count == 1 && p.Slides[0].Timeline.MainSequence[0].Type == EffectType.Fade, "AddAnimation: semantic check 1 failed.");
        });
        Context.Pass("elements/animation/block-001", "AddAnimation", "save-reopen-structure");
    }
}
```

## **Access an Animation**

Retrieve the first animation effect from the slide timeline.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
        slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

        // Access the first animation effect.
        var effect = slide.Timeline.MainSequence[0];

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.Slides[0].Timeline.MainSequence.Count == 1 && p.Slides[0].Timeline.MainSequence[0].Type == EffectType.Fade, "AccessAnimation: semantic check 1 failed.");
        });
        Context.Pass("elements/animation/block-002", "AccessAnimation", "save-reopen-structure");
    }
}
```

## **Remove an Animation**

Remove an animation effect from the sequence.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

internal static partial class Program
{
    static void Case03()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
        var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

        // Remove the effect.
        slide.Timeline.MainSequence.Remove(effect);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(p.Slides[0].Timeline.MainSequence.Count == 0, "RemoveAnimation: semantic check 1 failed.");
        });
        Context.Pass("elements/animation/block-003", "RemoveAnimation", "save-reopen-structure");
    }
}
```

## **Sequence Animations**

Add multiple effects and demonstrate the order in which animations occur.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

internal static partial class Program
{
    static void Case04()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
        var shape2 = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 200, 50, 100, 100);

        var sequence = slide.Timeline.MainSequence;
        sequence.AddEffect(shape1, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
        sequence.AddEffect(shape2, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-004", p =>
        {
            Context.Require(p.Slides[0].Timeline.MainSequence.Count == 2 && ((IAutoShape)p.Slides[0].Timeline.MainSequence[0].TargetShape).ShapeType == ShapeType.Rectangle && ((IAutoShape)p.Slides[0].Timeline.MainSequence[1].TargetShape).ShapeType == ShapeType.Ellipse, "SequenceAnimations: semantic check 1 failed.");
        });
        Context.Pass("elements/animation/block-004", "SequenceAnimations", "save-reopen-structure");
    }
}
```
