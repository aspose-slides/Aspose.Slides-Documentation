---
title: PowerPoint-Text in Python animieren
linktitle: Animierter Text
type: docs
weight: 60
url: /de/python-net/animated-text/
keywords:
- animierter Text
- Textanimation
- animierter Absatz
- Absatzanimation
- Animationseffekt
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erstellen Sie dynamischen animierten Text in PowerPoint- und OpenDocument-Präsentationen mithilfe von Aspose.Slides für Python über .NET, mit leicht nachvollziehbaren, optimierten Codebeispielen."
---

## **Übersicht**

Dieser Artikel zeigt, wie Text in PowerPoint‑Präsentationen mit Aspose.Slides für Python animiert werden kann. Sie lernen, Effekte einzelnen Absätzen hinzuzufügen, Trigger anzupassen und bestehende Animationssequenzen auszulesen. Am Ende können Sie wiederverwendbare Text‑Animations‑Workflows erstellen, die in das Standard‑PPTX‑Format exportiert werden und in PowerPoint korrekt abgespielt werden.

## **Paragraph-Animations-Effekte hinzufügen**

Die Methode [add_effect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/add_effect/) der Klasse [Sequence](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) ermöglicht das Anwenden eines Animations‑Effekts auf einen einzelnen Absatz. Der Beispielcode unten demonstriert, wie das geht:
```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    # Wählen Sie den Absatz zum Hinzufügen des Effekts aus.
    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Fügen Sie dem ausgewählten Absatz einen Fly-Animationseffekt hinzu.
    effect = slide.timeline.main_sequence.add_effect(paragraph,
                                                     slides.animation.EffectType.FLY,
                                                     slides.animation.EffectSubtype.LEFT,
                                                     slides.animation.EffectTriggerType.ON_CLICK)
    presentation.save("ParagraphAnimationEffect.pptx", slides.export.SaveFormat.PPTX)
```


## **Paragraph-Animations-Effekte abrufen**

Möglicherweise möchten Sie ermitteln, welche Animations‑Effekte einem Absatz zugewiesen sind – zum Beispiel, wenn Sie diese Effekte auf einen anderen Absatz oder ein anderes Shape kopieren wollen.

Aspose.Slides für Python erlaubt das Abrufen aller Animations‑Effekte, die auf die Absätze in einem Text‑Frame (Shape) angewendet wurden. Der Beispielcode unten zeigt, wie die Animations‑Effekte eines Absatzes ausgelesen werden:
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

**Wie unterscheiden sich Text‑Animationen von Folien‑Übergängen und können sie kombiniert werden?**

Text‑Animationen steuern das Verhalten von Objekten über die Zeit auf einer Folie, während [transitions](/slides/de/python-net/slide-transition/) festlegen, wie Folienwechsel ablaufen. Sie sind unabhängig und können gemeinsam verwendet werden; die Wiedergabereihenfolge wird durch die Animations‑Zeitachse und die Übergangs‑Einstellungen bestimmt.

**Werden Text‑Animationen beim Exportieren in PDF oder Bilder beibehalten?**

Nein. PDF‑ und Raster‑Bilddateien sind statisch, sodass nur ein einzelner Folienzustand ohne Bewegung angezeigt wird. Um Bewegung zu erhalten, benutzen Sie den Export nach [video](/slides/de/python-net/convert-powerpoint-to-video/) oder [HTML](/slides/de/python-net/export-to-html5/).

**Funktionieren Text‑Animationen in Layouts und im Folien‑Master?**

Effekte, die auf Layout‑/Master‑Objekte angewendet werden, werden von den Folien geerbt, aber ihr Timing und ihre Interaktion mit Folien‑Animationen hängen von der endgültigen Sequenz auf der jeweiligen Folie ab.