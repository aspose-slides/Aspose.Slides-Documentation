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

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.

## Download and run

[Download the complete project](example.zip), extract it, and open `Example.sln` or run:

```console
dotnet restore Example.sln
dotnet run --project Example.csproj -- --mode evaluation
```

The download includes every case below, its fixture helpers and inputs. `Program.cs` runs all cases; use `--action block-001` to run one independently. Outputs and an action report are written to the printed output directory. No previous example or working-directory setup is required. Evaluation adds a watermark and can truncate read-back text; the short fixtures still have explicit structural checks. For full text and no watermark, use `--mode licensed --license PATH` with your own valid license. See the [setup guide](/slides/net/examples/getting-started/) for supported SDKs and native prerequisites.

## **Add an Animation**

Create a rectangle shape and apply a fade effect triggered on click.

```csharp
using Aspose.Slides.Export;
using Aspose.Slides;
using Aspose.Slides.Animation;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);

// Fade effect.
slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

presentation.Save("animation-01.pptx", SaveFormat.Pptx);
```

## **Access an Animation**

Retrieve the first animation effect from the slide timeline.

```csharp
using System;
using Aspose.Slides.Export;
using Aspose.Slides;
using Aspose.Slides.Animation;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

// Access the first animation effect.
var effect = slide.Timeline.MainSequence[0];
Console.WriteLine(effect.Type);

presentation.Save("animation-02.pptx", SaveFormat.Pptx);
```

## **Remove an Animation**

Remove an animation effect from the sequence.

```csharp
using Aspose.Slides.Export;
using Aspose.Slides;
using Aspose.Slides.Animation;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

// Remove the effect.
slide.Timeline.MainSequence.Remove(effect);

presentation.Save("animation-03.pptx", SaveFormat.Pptx);
```

## **Sequence Animations**

Add multiple effects and demonstrate the order in which animations occur.

```csharp
using Aspose.Slides.Export;
using Aspose.Slides;
using Aspose.Slides.Animation;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
var shape2 = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 200, 50, 100, 100);

var sequence = slide.Timeline.MainSequence;
sequence.AddEffect(shape1, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
sequence.AddEffect(shape2, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);

presentation.Save("animation-04.pptx", SaveFormat.Pptx);
```
