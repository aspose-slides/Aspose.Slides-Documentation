---
title: SlideTransition
type: docs
weight: 110
url: /net/examples/elements/slide-transition/
keywords:
- slide transition example
- add slide transition
- access slide transition
- remove slide transition
- transition duration
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Control slide transitions in C# with Aspose.Slides: choose types, speed, sound, and timing to polish presentations in PPT, PPTX and ODP."
---

Demonstrates applying slide transition effects and timings with **Aspose.Slides for .NET**.

## **Add a Slide Transition**

Apply a fade transition effect to the first slide.

```csharp
static void Add_Slide_Transition()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // Apply a fade transition
    slide.SlideShowTransition.Type = TransitionType.Fade;
}
```

## **Access a Slide Transition**

Read the transition type currently assigned to a slide.

```csharp
static void Access_Slide_Transition()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    slide.SlideShowTransition.Type = TransitionType.Push;

    // Access the transition type
    var type = slide.SlideShowTransition.Type;
}
```

## **Remove a Slide Transition**

Clear any transition effect by setting the type to `None`.

```csharp
static void Remove_Slide_Transition()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    slide.SlideShowTransition.Type = TransitionType.Fade;

    // Remove transition by setting none
    slide.SlideShowTransition.Type = TransitionType.None;
}
```

## **Set Transition Duration**

Specify how long the slide is displayed before advancing automatically.

```csharp
static void Set_Transition_Duration()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    slide.SlideShowTransition.AdvanceOnClick = true;
    slide.SlideShowTransition.AdvanceAfterTime = 2000; // in milliseconds
}
```
