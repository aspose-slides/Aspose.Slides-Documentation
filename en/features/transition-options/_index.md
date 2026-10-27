---
title: Set transition effects, direction and sound
description: Configure transition direction, advanced effects and sound.
type: docs
url: /features/transition-options/
weight: 1160
feature_id: transition-options
feature_group: transitions
translationKey: slides-feature-transition-options
feature_catalogue_version: 3
feature_guides:
- /slides/net/slide-transition/
---

## **Overview**

Use transition-specific options for effects such as 3D-style transitions, directional movement and other presentation transitions. You can also attach transition sound and choose its playback behavior. The available settings depend on the transition type.

## **Usage example**

This C# example uses Aspose.Slides for .NET. Configure a push transition with an 800-millisecond duration and allow the first slide to advance either on a mouse click or after 3,000 milliseconds. Transition duration and slide-advance delay are separate settings. The PNG is a static view. No input file is needed. It saves *transition-options.pptx* and *transition-options.png*. Install the library using the [installation guide](/slides/net/installation/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var target = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
target.Name = "Reveal target";
target.TextFrame.Text = "Quarterly results";
presentation.Slides.AddClone(slide);
var transition = slide.SlideShowTransition;
transition.Type = TransitionType.Push;
transition.Duration = 800;
transition.AdvanceOnClick = true;
transition.AdvanceAfter = true;
transition.AdvanceAfterTime = 3000;
presentation.Save("transition-options.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("transition-options.png", ImageFormat.Png);
```

## **FAQ**

### **Does every transition use the same direction settings?**

No. Select the transition type first, then use the options associated with that effect.

### **Can I combine timed advance with mouse-click advance?**

Yes. Enable both settings so a compatible slideshow can advance on a click or when the specified delay expires.

### **What is the difference between transition duration and slide advance time?**

Transition duration controls the visual movement between slide states. Advance time controls how long the slide waits before moving on; these settings use milliseconds in this sample.

## **Guides**

- [Manage Slide Transitions in Presentations in .NET](/slides/net/slide-transition/)

Related feature: [Set slide transitions and timing](/slides/features/slide-transitions/).
