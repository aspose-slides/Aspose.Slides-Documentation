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

## Adding Animation Effects to Paragraphs

We added the [**add_effect()**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) method to the [**Sequence**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) and [**ISequence**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/isequence/) classes. This method allows you to add animation effects to a single paragraph. This sample code shows you how to add an animation effect to a single paragraph:

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as presentation:
    # select paragraph to add effect
    autoShape = presentation.slides[0].shapes[0]
    paragraph = autoShape.text_frame.paragraphs[0]

    # add Fly animation effect to selected paragraph
    effect = presentation.slides[0].timeline.main_sequence.add_effect(paragraph, slides.animation.EffectType.FLY, slides.animation.EffectSubtype.LEFT, slides.animation.EffectTriggerType.ON_CLICK)
    presentation.save("AnimationEffectinParagraph.pptx", slides.export.SaveFormat.PPTX)
```



## Getting the Animation Effects in Paragraphs

You may decide to find out the animation effects added to a paragraph—for example, in one scenario, you want to get the animation effects in a paragraph because you plan to apply those effects to another paragraph or shape.

Aspose.Slides for Python via .NET allows you to get all the animation effects applied to paragraphs contained in a text frame (shape). This sample code shows you how to get the animation effects in a paragraph:

```py
import aspose.slides as slides

with slides.Presentation("AnimationEffectinParagraph.pptx") as pres:
    sequence = pres.slides[0].timeline.main_sequence
    autoShape = pres.slides[0].shapes[0]
    for paragraph in autoShape.text_frame.paragraphs:
        effects = sequence.get_effects_by_paragraph(paragraph)
        if len(effects) > 0:
            print("Paragraph \"" + paragraph.text + "\" has " + str(effects[0].type) + " effect.")
```

