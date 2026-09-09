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
description: "Erstellen Sie dynamischen animierten Text in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python via Java, mit leicht verständlichen, optimierten Python-Codebeispielen."
---
## **Übersicht**

Dieser Artikel erklärt, wie man in Aspose.Slides animierten Text verwendet, indem man Animationseffekte auf einzelne Absätze anwendet und die bereits zugewiesenen Effekte eines Absatzes in einem Textfeld abruft. Er konzentriert sich auf die API‑Methoden zum Hinzufügen von Absatz‑Animationen und zum Prüfen vorhandener Absatz‑Animationseffekte in einer Präsentation.

## **Animations‑Effekte zu Absätzen hinzufügen**

Die [addEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/sequence/#addEffect)-Methode der [Sequence](https://reference.aspose.com/slides/de/python-java/aspose.slides/sequence/)-Klasse ermöglicht das Hinzufügen von Animationseffekten zu einem einzelnen Absatz. Der folgende Beispielcode zeigt, wie ein Animationseffekt zu einem einzelnen Absatz hinzugefügt wird:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

presentation = Presentation("Presentation.pptx")
try:
    # Absatz auswählen, dem ein Effekt hinzugefügt werden soll.
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Einen Fly-Animationseffekt zum ausgewählten Absatz hinzufügen.
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick)

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Animations‑Effekte von Absätzen abrufen**

Möglicherweise möchten Sie die auf einen Absatz angewendeten Animationseffekte abrufen – zum Beispiel, um diese Effekte auf einen anderen Absatz oder ein anderes Shape anzuwenden.

Aspose.Slides for Python via Java ermöglicht das Abrufen aller Animationseffekte, die auf Absätze in einem Textfeld (Shape) angewendet wurden. Der folgende Beispielcode zeigt, wie die auf einen Absatz angewendeten Animationseffekte abgerufen werden:

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

**Wie unterscheiden sich Textanimationen von Folien‑Übergängen und können sie kombiniert werden?**

Textanimationen steuern das Verhalten von Objekten im zeitlichen Verlauf einer Folie, während [Übergänge](/slides/de/python-java/slide-transition/) festlegen, wie Folien wechseln. Sie sind unabhängig und können zusammen verwendet werden; die Wiedergabereihenfolge wird vom Animations‑Zeitplan und den Übergangseinstellungen bestimmt.

**Werden Textanimationen beim Exportieren in PDF oder Bilder beibehalten?**

Nein. PDF‑ und Raster‑Bilder sind statisch, sodass Sie nur einen einzelnen Folienzustand ohne Bewegung sehen. Um Bewegung zu erhalten, verwenden Sie den Export nach [Video](/slides/de/python-java/convert-powerpoint-to-video/) oder [HTML](/slides/de/python-java/export-to-html5/).

**Funktionieren Textanimationen in Layouts und im Folien‑Master?**

Auf Layout‑/Master‑Objekte angewendete Effekte werden von den Folien geerbt, aber ihr Timing und die Interaktion mit Folien‑Animationen hängen von der endgültigen Reihenfolge auf der Folie ab.