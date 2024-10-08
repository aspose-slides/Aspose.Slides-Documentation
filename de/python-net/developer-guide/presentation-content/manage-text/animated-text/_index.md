---
title: Animierter Text
type: docs
weight: 60
url: /de/python-net/animated-text/
keywords: "Animierter Text, Animationseffekte, PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "Fügen Sie animierten Text und Effekte zu PowerPoint-Präsentationen in Python hinzu"
---

## Hinzufügen von Animationseffekten zu Absätzen

Wir haben die [**add_effect()**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) Methode zu den [**Sequence**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) und [**ISequence**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/isequence/) Klassen hinzugefügt. Mit dieser Methode können Sie Animationseffekte zu einem einzelnen Absatz hinzufügen. Dieser Beispielcode zeigt Ihnen, wie Sie einen Animationseffekt zu einem einzelnen Absatz hinzufügen:

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as presentation:
    # Absatz auswählen, um Effekt hinzuzufügen
    autoShape = presentation.slides[0].shapes[0]
    paragraph = autoShape.text_frame.paragraphs[0]

    # Fly-Animationseffekt zum ausgewählten Absatz hinzufügen
    effect = presentation.slides[0].timeline.main_sequence.add_effect(paragraph, slides.animation.EffectType.FLY, slides.animation.EffectSubtype.LEFT, slides.animation.EffectTriggerType.ON_CLICK)
    presentation.save("AnimationEffectinParagraph.pptx", slides.export.SaveFormat.PPTX)
```



## Abrufen der Animationseffekte in Absätzen

Sie können entscheiden, die Animationseffekte zu ermitteln, die einem Absatz hinzugefügt wurden – zum Beispiel in einem Szenario, in dem Sie die Animationseffekte in einem Absatz abrufen möchten, weil Sie planen, diese Effekte auf einen anderen Absatz oder ein anderes Shape anzuwenden.

Aspose.Slides für Python über .NET ermöglicht es Ihnen, alle Animationseffekte abzurufen, die auf Absätze in einem Textfeld (Shape) angewendet wurden. Dieser Beispielcode zeigt Ihnen, wie Sie die Animationseffekte in einem Absatz abrufen:

```py
import aspose.slides as slides

with slides.Presentation("AnimationEffectinParagraph.pptx") as pres:
    sequence = pres.slides[0].timeline.main_sequence
    autoShape = pres.slides[0].shapes[0]
    for paragraph in autoShape.text_frame.paragraphs:
        effects = sequence.get_effects_by_paragraph(paragraph)
        if len(effects) > 0:
            print("Absatz \"" + paragraph.text + "\" hat " + str(effects[0].type) + " Effekt.")
```