---
title: "Kezeljen felső- és alsóindexet a prezentációkban Python segítségével Java-n keresztül"
linktitle: "Felsőindex és alsóindex"
type: docs
weight: 80
url: /hu/python-java/superscript-and-subscript/
keywords:
- "felsőindex"
- "alsóindex"
- "felsőindex hozzáadása"
- "alsóindex hozzáadása"
- "PowerPoint"
- "OpenDocument"
- "prezentáció"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Mesterszintű felső- és alsóindex az Aspose.Slides for Python via Java használatával, és emelje prezentációit professzionális szövegformázással a maximális hatás érdekében."
---
## **Áttekintés**

Az Aspose.Slides olyan funkciókat biztosít, amelyekkel felső- és alsóindex szöveget integrálhat PowerPoint (PPT, PPTX) és OpenDocument (ODP) prezentációiba. Akár kémiai képleteket, matematikai egyenleteket szeretne kiemelni, akár lábjegyzetekkel szeretne megjegyzéseket fűzni, ezek a speciális formázási lehetőségek az átláthatóságot és a pontosságot segítik. Ebben a cikkben megtanulja, hogyan alkalmazhatja zökkenőmentesen a felső- és alsóindex stílusokat, és hogyan érhet el professzionális eredményeket minden dián.

## **Felső- és alsóindex szöveg kezelése**

Bármely bekezdés részére felvehet felső- vagy alsóindex szöveget. Az Aspose.Slides szövegkeretében a formázás alkalmazásához használja a [setEscapement](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portionformat/#setEscapement) metódust a [PortionFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portionformat/) osztályon.

Az escapement érték –100 % (alsóindex) és 100 % (felsőindex) között mozog. Például:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
- Szerezzen be egy diát az indexe alapján.
- Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/) típusú [ShapeType.Rectangle](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapetype/#Rectangle) alakzatot a diához.
- Érje el a [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/)‑hoz tartozó [TextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/) objektumot.
- Törölje a meglévő bekezdéseket.
- Hozzon létre egy bekezdést a felsőindex szöveg tárolásához, és adja hozzá a szövegkeret [paragraph collection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/#getParagraphs) gyűjteményéhez.
- Hozzon létre egy részt.
- Használja a [setEscapement](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portionformat/#setEscapement) metódust 0‑tól 100‑ig terjedő érték beállításához felsőindexhez (0 = nincs felsőindex).
- Állítsa be a [Portion](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portion/) szövegét, és adja hozzá a bekezdés portion collection gyűjteményéhez.
- Hozzon létre egy bekezdést a alsóindex szöveg tárolásához, és adja hozzá a szövegkeret [paragraph collection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/#getParagraphs) gyűjteményéhez.
- Hozzon létre egy részt.
- Használja a [setEscapement](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portionformat/#setEscapement) metódust -100‑tól 0‑ig terjedő érték beállításához alsóindexhez (0 = nincs alsóindex).
- Állítsa be a [Portion](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portion/) szövegét, és adja hozzá a bekezdés portion collection gyűjteményéhez.
- Mentse a prezentációt PPTX fájlként.

A következő példa megvalósítja ezeket a lépéseket:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Paragraph, Portion, Presentation, SaveFormat, ShapeType

# Készítsen egy prezentációt.
presentation = Presentation()
try:
    # Szerezze be a diát.
    slide = presentation.getSlides().get_Item(0)

    # Hozzon létre egy szövegdobozt.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    # Hozzon létre egy bekezdést a felsőindex szöveghez.
    superscript_paragraph = Paragraph()

    # Hozzon létre egy részt normál szöveggel.
    title_portion = Portion()
    title_portion.setText("SlideTitle")
    superscript_paragraph.getPortions().add(title_portion)

    # Hozzon létre egy részt felsőindex szöveggel.
    superscript_portion = Portion()
    superscript_portion.getPortionFormat().setEscapement(30)
    superscript_portion.setText("TM")
    superscript_paragraph.getPortions().add(superscript_portion)

    # Hozzon létre egy bekezdést az alsóindex szöveghez.
    subscript_paragraph = Paragraph()

    # Hozzon létre egy részt normál szöveggel.
    base_portion = Portion()
    base_portion.setText("a")
    subscript_paragraph.getPortions().add(base_portion)

    # Hozzon létre egy részt alsóindex szöveggel.
    subscript_portion = Portion()
    subscript_portion.getPortionFormat().setEscapement(-25)
    subscript_portion.setText("i")
    subscript_paragraph.getPortions().add(subscript_portion)

    # Adja hozzá a bekezdéseket a szövegdobozhoz.
    text_frame.getParagraphs().add(superscript_paragraph)
    text_frame.getParagraphs().add(subscript_paragraph)

    presentation.save("formatText.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **GYIK**

**Megmarad a felső- és alsóindex formázás a PDF vagy más formátumokba exportáláskor?**

Igen, az Aspose.Slides megfelelően megőrzi a felső- és alsóindex formázást, amikor a prezentációkat PDF, PPT/PPTX, képek és egyéb támogatott formátumokba exportálja. A speciális formázás minden kimeneti fájlban érintetlen marad.

**Kombinálható a felső- vagy alsóindex más formázási stílusokkal, például félkövérrel vagy dőlt betűvel?**

Igen, az Aspose.Slides lehetővé teszi, hogy egyetlen szövegrészben több stílust keverjen. Engedélyezheti a félkövér, dőlt, aláhúzott formázást, és egyidejűleg alkalmazhat felső- vagy alsóindexet a [PortionFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portionformat/) megfelelő tulajdonságainak beállításával.

**Működik a felső- és alsóindex formázás táblákon, diagramokon vagy SmartArt‑on belüli szövegnél?**

Igen, az Aspose.Slides támogatja a formázást a legtöbb objektumban, beleértve a táblákat és diagramelemeket is. SmartArt használatakor hozzá kell férnie a megfelelő elemekhez (például a [SmartArtNode](https://reference.aspose.com/slides/hu/python-java/aspose.slides/smartartnode/)) és azok szövegkonténereibe, majd hasonló módon konfigurálnia kell a [PortionFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portionformat/) tulajdonságokat.