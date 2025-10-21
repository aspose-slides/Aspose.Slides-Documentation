---
title: Animate PowerPoint Text in Python
linktitle: Animated Text
type: docs
weight: 60
url: /python-net/animated-text/
keywords:
- animated text
- text animation
- animated paragraph
- paragraph animation
- animation effect
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Create dynamic animated text in PowerPoint and OpenDocument presentations using Aspose.Slides for Python via .NET, with easy-to-follow, optimized code examples."
---

## **Overview**

This article shows how to animate text in PowerPoint presentations using Aspose.Slides for Python. You'll learn to add effects to individual paragraphs, adjust triggers, and read back existing animation sequences. By the end, you'll be able to create reusable text-animation workflows that export to standard PPTX and play correctly in PowerPoint.

## **Add Paragraph Animation Effects**

The [add_effect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/add_effect/) method of the [Sequence](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) class lets you apply an animation effect to a single paragraph. The sample code below demonstrates how to do this:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    # Select the paragraph to add the effect.
    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Add a Fly animation effect to the selected paragraph.
    effect = slide.timeline.main_sequence.add_effect(paragraph,
                                                     slides.animation.EffectType.FLY,
                                                     slides.animation.EffectSubtype.LEFT,
                                                     slides.animation.EffectTriggerType.ON_CLICK)
    presentation.save("ParagraphAnimationEffect.pptx", slides.export.SaveFormat.PPTX)
```

## **Get Paragraph Animation Effects**

You may want to determine which animation effects are applied to a paragraph—for example, if you plan to copy those effects to another paragraph or shape.

Aspose.Slides for Python lets you retrieve all animation effects applied to the paragraphs in a text frame (shape). The sample code below shows how to get a paragraph’s animation effects:

```py
import aspose.slides as slides

with slides.Presentation("ParagraphAnimationEffect.pptx") as presentation:
    slide = presentation.slides[0]
    sequence = slide.timeline.main_sequence
    auto_shape = slide.shapes[0]

    for paragraph in auto_shape.text_frame.paragraphs:
        effects = sequence.get_effects_by_paragraph(paragraph)
        if len(effects) > 0:
            print(f"Paragraph \"{paragraph.text}\" has the first animation effect of type {str(effects[0].type)}.")
```

## **FAQ**

**How do text animations differ from slide transitions, and can they be combined?**

Text animations control object behavior over time on a slide, while [transitions](/slides/python-net/slide-transition/) control how slides change. They’re independent and can be used together; playback order is governed by the animation timeline and the transition settings.

**Are text animations preserved when exporting to PDF or images?**

No. PDF and raster images are static, so you’ll see a single state of the slide without motion. To keep movement, use [video](/slides/python-net/convert-powerpoint-to-video/) or [HTML](/slides/python-net/export-to-html5/) export.

**Do text animations work in layouts and the slide master?**

Effects applied to layout/master objects are inherited by slides, but their timing and interaction with slide-level animations depend on the final sequence on the slide.
