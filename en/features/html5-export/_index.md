---
title: Export presentations to HTML5
description: Create HTML5 presentation output with navigation and supported animation.
type: docs
url: /features/html5-export/
weight: 1260
feature_id: html5-export
feature_group: rendering
translationKey: slides-feature-html5-export
feature_catalogue_version: 3
feature_guides:
- /slides/net/export-to-html5/
---

## **Overview**

Export slides as HTML5 content with styles and scripts for browser viewing. The output can include navigation, hyperlinks, media and supported animation. Publish the generated HTML together with its associated files so the browser can load the presentation.

## **Usage example (C#)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example. Create two slides, add a supported fade effect to the first and write HTML5 into an output directory. Serve that directory with its generated CSS and slide assets. The generated player also references external JavaScript libraries, so those dependencies must be reachable. Click the slide to start playback when the player waits for a user gesture, then use its navigation controls.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.IO;
using Aspose.Slides.Animation;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 140);
shape.AddTextFrame("Sample slide");
var effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
effect.Timing.Duration = 1;
var secondSlide = presentation.Slides.AddClone(presentation.Slides[0]);
((IAutoShape)secondSlide.Shapes[0]).TextFrame.Text = "Second slide";
Directory.CreateDirectory("html5");
var options = new Html5Options { AnimateShapes = true, AnimateTransitions = true };
presentation.Save("html5/index.html", SaveFormat.Html5, options);
presentation.Save("source.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Is the generated player fully self-contained for offline use?**

The output references external JavaScript libraries. Its script dependencies must be reachable or handled separately by the hosting application.

### **Which generated assets must be deployed together?**

Deploy the generated HTML, CSS, slide content and other associated resource files together. Keep external player script dependencies reachable.

### **Can I choose whether the generated HTML5 includes navigation controls?**

The standard HTML5 export options do not expose a navigation-visibility switch. This example uses the generated controls; a different navigation interface needs work in the hosting application.

## **Guides**

- [Convert Presentations to HTML5 in .NET](/slides/net/export-to-html5/)

Related feature: [Save HTML styles in separate CSS files](/slides/features/separate-css/).
