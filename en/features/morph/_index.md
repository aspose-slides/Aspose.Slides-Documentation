---
title: Work with Morph
description: Configure Morph transitions between related slides.
type: docs
url: /features/morph/
weight: 1140
feature_id: morph
feature_group: animation
translationKey: slides-feature-morph
feature_catalogue_version: 3
feature_guides:
- /slides/net/slide-transition/
---

## **Overview**

Use Morph to describe a transition between slides that share related objects or text. Choose object, word or character behavior and preserve the transition settings in the presentation. Object naming helps identify related shapes across the slides.

## **Usage example**

This C# example uses Aspose.Slides for .NET. Clone a slide, move and widen its named rectangle, and assign Morph to the second slide. Matching names beginning with two exclamation marks identify the related shapes for a compatible slideshow. The PNG shows a static endpoint, not the Morph motion. No input file is needed. It saves *morph.pptx* and *morph.png*. Install the library using the [installation guide](/slides/net/installation/).

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
target.Name = "!!Results";
var secondSlide = presentation.Slides.AddClone(slide);
secondSlide.Shapes[0].X = 260;
secondSlide.Shapes[0].Width = 400;
secondSlide.SlideShowTransition.Type = TransitionType.Morph;
presentation.Save("morph.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("morph.png", ImageFormat.Png);
```

## **FAQ**

### **Is Morph stored as a slide animation effect?**

Morph is configured as a slide transition. It connects successive slide states rather than acting like an ordinary entrance effect on one shape.

### **How should shapes be matched between Morph slides?**

Start with related objects, for example by cloning the slide. Give corresponding shapes the same explicit name beginning with two exclamation marks when you need to identify the match.

### **Does a static PDF preserve the Morph motion?**

No. A static PDF contains slide views. Keep the transition in a presentation for a compatible slideshow; static export does not preserve the movement.

## **Guides**

- [Manage Slide Transitions in Presentations in .NET](/slides/net/slide-transition/)

Related feature: [Set slide transitions and timing](/slides/features/slide-transitions/).
