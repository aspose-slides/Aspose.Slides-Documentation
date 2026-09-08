---
title: PowerPoint-Text in Python via Java animieren
linktitle: Animierter Text
type: docs
weight: 60
url: /de/python-java/animated-text/
keywords:
- animierter Text
- Textanimation
- animierter Absatz
- Absatzanimation
- Animationseffekt
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Erstellen Sie dynamischen animierten Text in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python via Java, mit leicht nachvollziehbaren, optimierten Python-Codebeispielen."
---
## **Übersicht**

Dieser Artikel erklärt, wie man in Aspose.Slides animierten Text verwendet, indem man Animations‑Effekte einzelnen Absätzen zuweist und bereits zugewiesene Effekte eines Absatzes in einem Text‑Frame abruft. Er konzentriert sich auf die API‑Methoden zum Hinzufügen von Absatz‑Animationen und zum Untersuchen vorhandener Absatz‑Animationseffekte in einer Präsentation.

## **Animationseffekte zu Absätzen hinzufügen**

Die [addEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/sequence/#addEffect)-Methode der [Sequence](https://reference.aspose.com/slides/de/python-java/aspose.slides/sequence/)-Klasse ermöglicht das Hinzufügen von Animations‑Effekten zu einem einzelnen Absatz. Dieser Beispielcode zeigt, wie man einem einzelnen Absatz einen Animations‑Effekt hinzufügt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

presentation = Presentation("Presentation.pptx")
try:
    # Wählen Sie den Absatz aus, dem ein Effekt hinzugefügt werden soll.
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Fügen Sie dem ausgewählten Absatz einen Fly-Animationseffekt hinzu.
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick)

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Animationseffekte von Absätzen abrufen**

Möglicherweise möchten Sie die zu einem Absatz hinzugefügten Animations‑Effekte ermitteln – zum Beispiel, wenn Sie diese Effekte auf einen anderen Absatz oder ein Shape anwenden wollen.

Aspose.Slides für Python via Java ermöglicht das Abrufen aller Animations‑Effekte, die auf Absätze in einem Text‑Frame (Shape) angewendet wurden. Dieser Beispielcode zeigt, wie man die Animations‑Effekte eines Absatzes abruft:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    sequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence()
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    for paragraph in auto_shape.getTextFrame().getParagraphs():
        effects = sequence.getEffectsByParagraph(paragraph)

        if len(effects) > 0:
            print(f'Paragraph "{paragraph.getText()}" has {effects[0].getType()} effect.')
finally:
    presentation.dispose()
```

## **FAQ**

**Wie unterscheiden sich Textanimationen von Folienübergängen, und können sie kombiniert werden?**

Textanimationen steuern das Verhalten von Objekten über die Zeit auf einer Folie, während [Übergänge](/slides/de/python-java/slide-transition/) bestimmen, wie Folien gewechselt werden. Sie sind unabhängig und können zusammen verwendet werden; die Wiedergabereihenfolge wird vom Animations‑Zeitplan und den Übergangseinstellungen bestimmt.

**Werden Textanimationen beim Export in PDF oder Bilddateien beibehalten?**

Nein. PDF‑ und Raster‑Bilddateien sind statisch, sodass Sie nur einen einzelnen Folienzustand ohne Bewegung sehen. Um Bewegung zu erhalten, verwenden Sie den Export nach [Video](/slides/de/python-java/convert-powerpoint-to-video/) oder [HTML](/slides/de/python-java/export-to-html5/).

**Funktionieren Textanimationen in Layouts und im Folienmaster?**

Auf Layout‑/Master‑Objekte angewendete Effekte werden von Folien geerbt, aber ihr Timing und ihre Interaktion mit Folien‑Animationen hängen von der endgültigen Reihenfolge auf der Folie ab.