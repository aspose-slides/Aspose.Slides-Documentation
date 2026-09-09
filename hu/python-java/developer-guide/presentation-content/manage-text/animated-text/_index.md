---
title: PowerPoint szöveg animálása Pythonból Java-val
linktitle: Animált szöveg
type: docs
weight: 60
url: /hu/python-java/animated-text/
keywords:
- animált szöveg
- szöveganimáció
- animált bekezdés
- bekezdésanimáció
- animációs hatás
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Dinamikus animált szöveget hozhat létre PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Python via Java használatával, könnyen követhető, optimalizált Python kódrészletekkel."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan lehet animált szöveggel dolgozni az Aspose.Slides-ben animációs hatások alkalmazásával az egyes bekezdésekre, valamint a szövegkeretben szereplő bekezdésekhez már hozzárendelt hatások lekérdezésével. A bemutatóban a bekezdés szintű animáció hozzáadásához és a meglévő bekezdés animációs hatások vizsgálatához használt API-módszerekre összpontosít.

## **Animációs hatások hozzáadása bekezdésekhez**

Az [addEffect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sequence/#addEffect) metódus a [Sequence](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sequence/) osztályban lehetővé teszi animációs hatások hozzáadását egyetlen bekezdéshez. Ez a mintakód megmutatja, hogyan lehet egy animációs hatást hozzáadni egy bekezdéshez:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

presentation = Presentation("Presentation.pptx")
try:
    # Válassza ki a bekezdést, amelyhez effektust szeretne hozzáadni.
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Adjunk egy Fly animációs hatást a kiválasztott bekezdéshez.
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick)

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Animációs hatások lekérdezése bekezdésekhez**

Lehet, hogy le szeretné kérdezni egy bekezdésre alkalmazott animációs hatásokat – például hogy ezeket a hatásokat egy másik bekezdésre vagy alakzatra alkalmazza.

Az Aspose.Slides for Python via Java lehetővé teszi, hogy megtudja az összes animációs hatást, amely a szövegkeretben (alakzat) lévő bekezdésekre van alkalmazva. Ez a mintakód megmutatja, hogyan lehet lekérdezni egy bekezdésre alkalmazott animációs hatásokat:

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

**Hogyan különböznek a szöveg animációk a diaátmenetektől, és kombinálhatók-e?**

A szöveg animációk egy objektum viselkedését szabályozzák az időben egy diához képest, míg a [transitions](/slides/hu/python-java/slide-transition/) a diák váltását irányítják. Függetlenek egymástól, és együtt is használhatók; a lejátszási sorrendet az animáció idővonala és a áttűnés beállításai szabályozzák.

**Megmaradnak a szöveg animációk PDF vagy képek exportálásakor?**

Nem. A PDF és a raszteres képek statikusak, ezért a dia egyetlen állapotát látja mozgás nélkül. A mozgás megőrzéséhez használja a [video](/slides/hu/python-java/convert-powerpoint-to-video/) vagy a [HTML](/slides/hu/python-java/export-to-html5/) exportot.

**Működnek a szöveg animációk elrendezésekben és a dia-maszterben?**

Az elrendezés/máster objektumokra alkalmazott hatásokat a diák öröklik, de azok időzítése és a dia-szintű animációkkal való kölcsönhatása a diához rendelt végső sorozattól függ.