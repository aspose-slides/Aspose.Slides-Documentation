---
title: Save HTML styles in separate CSS files
description: Keep HTML5 presentation styles in separate CSS files.
type: docs
url: /features/separate-css/
weight: 1280
feature_id: separate-css
feature_group: rendering
translationKey: slides-feature-separate-css
feature_catalogue_version: 3
feature_guides:
- /slides/net/export-to-html5/
---

## **Overview**

HTML5 export writes presentation styles into CSS files beside the HTML document. Serve those files with the generated output so the browser can apply its slide and master styling. Separate stylesheets also let a hosting application manage caching and additional style rules.

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

### **Does classic HTML export use the same CSS-file workflow?**

No. Classic HTML can include supplied CSS inline. The separate generated stylesheets described here belong to HTML5 output.

### **Where are the generated CSS files referenced?**

The generated HTML references the companion CSS files through stylesheet links. Preserve their relative locations when hosting.

### **What happens if the stylesheet is missing from the published output?**

The browser can lose slide or master styling. Deploy the companion stylesheets and check resource requests for missing files.

## **Guides**

- [Convert Presentations to HTML5 in .NET](/slides/net/export-to-html5/)

Related feature: [Export presentations to HTML5](/slides/features/html5-export/).
