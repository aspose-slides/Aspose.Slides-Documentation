---
title: Slide Transition
type: docs
weight: 110
url: /net/examples/elements/slidetransition/
keywords:
- code example
- slide transition
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Master slide transitions in Aspose.Slides for .NET: add, customize, and sequence effects and durations with C# examples for PPT, PPTX, and ODP presentations."
---

This article demonstrates applying slide transition effects and timings with **Aspose.Slides for .NET**.

## **Add a Slide Transition**

Apply a fade transition effect to the first slide.

```csharp
static void AddSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Apply a fade transition.
    slide.SlideShowTransition.Type = TransitionType.Fade;
}
```

## **Access a Slide Transition**

Read the transition type currently assigned to a slide.

```csharp
static void AccessSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.Type = TransitionType.Push;

    // Access the transition type.
    var type = slide.SlideShowTransition.Type;
}
```

## **Remove a Slide Transition**

Clear any transition effect by setting the type to `None`.

```csharp
static void RemoveSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.Type = TransitionType.Fade;

    // Remove transition by setting none.
    slide.SlideShowTransition.Type = TransitionType.None;
}
```

## **Set Transition Duration**

Specify how long the slide is displayed before advancing automatically.

```csharp
static void SetTransitionDuration()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.AdvanceOnClick = true;
    slide.SlideShowTransition.AdvanceAfterTime = 2000; // in milliseconds
}
```
