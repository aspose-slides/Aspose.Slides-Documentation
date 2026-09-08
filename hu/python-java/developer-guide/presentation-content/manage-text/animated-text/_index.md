---
title: PowerPoint szöveg animálása Pythonon keresztül Java-val
linktitle: Animált szöveg
type: docs
weight: 60
url: /hu/python-java/animated-text/
keywords:
- animált szöveg
- szöveganimáció
- animált bekezdés
- bekezdés animáció
- animációs hatás
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Dinamikus animált szöveget készítsen PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Python via Java használatával, könnyen követhető, optimalizált Python kódrészletekkel."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan dolgozhat animált szöveggel az Aspose.Slides-ban animációs hatások alkalmazásával egyedi bekezdésekhez, és hogyan kérdezheti le a bekezdéshez már hozzárendelt hatásokat egy szövegdobozban. Az API-módszerekre összpontosít, amelyek bekezdés-szintű animáció hozzáadására és a meglévő bekezdés-animációs hatások vizsgálatára egy prezentációban.

## **Animációs hatások hozzáadása bekezdésekhez**

Az [addEffect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sequence/#addEffect) metódus a [Sequence](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sequence/) osztályban lehetővé teszi animációs hatások hozzáadását egyetlen bekezdéshez. Ez a példakód bemutatja, hogyan adhat animációs hatást egy bekezdéshez:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

presentation = Presentation("Presentation.pptx")
try:
    # Válassza ki a bekezdést, amelyhez hatást szeretne hozzáadni.
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Adjon egy Fly animációs hatást a kiválasztott bekezdéshez.
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick)

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Animációs hatások lekérése bekezdésekhez**

Lehet, hogy szeretné megtudni, milyen animációs hatások lettek egy bekezdéshez hozzáadva – például egy helyzetben, ahol a bekezdés animációs hatásait egy másik bekezdésre vagy alakzatra szeretné alkalmazni.

Az Aspose.Slides for Python via Java lehetővé teszi, hogy lekérje az összes animációs hatást, amely a szövegdobozban (alakzatban) lévő bekezdésekhez van alkalmazva. Ez a példakód bemutatja, hogyan kérheti le egy bekezdés animációs hatásait:

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

## **GYIK**

**Hogyan különbözik a szöveganimáció a diaátmenetektől, és kombinálhatóak-e?**

A szöveganimációk az objektum viselkedését szabályozzák az időben egy dián, míg a [átmenetek](/slides/hu/python-java/slide-transition/) irányítják, hogyan változnak a diák. Függetlenek, és együtt is használhatók; a lejátszási sorrendet az animációs idővonal és az átmenet beállításai határozzák meg.

**Megmaradnak a szöveganimációk PDF vagy képek exportálásakor?**

Nem. A PDF és a raszteres képek statikusak, ezért a diát egyetlen állapotban látja mozgás nélkül. A mozgás megtartásához használjon [videót](/slides/hu/python-java/convert-powerpoint-to-video/) vagy [HTML](/slides/hu/python-java/export-to-html5/) exportot.

**Működnek a szöveganimációk elrendezésekben és a dia mesterben?**

Az elrendezés/mester objektumokra alkalmazott hatások öröklődnek a diákra, de azok időzítése és a dia-szintű animációkkal való kölcsönhatása a végső sorrendtől a dián függ.