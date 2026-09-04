---
title: Hiperhivatkozás
type: docs
weight: 130
url: /hu/python-java/examples/elements/hyperlink/
keywords:
- kód példa
- hiperhivatkozás
- hiperhivatkozás hozzáadása
- hiperhivatkozás elérése
- hiperhivatkozás eltávolítása
- hiperhivatkozás frissítése
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Hiperhivatkozások hozzáadása és kezelése az Aspose.Slides for Python via Java segítségével: linkek létrehozása, elérése, eltávolítása és frissítése PPT, PPTX és ODP prezentációkban."
---
Ez a cikk bemutatja a hiperhivatkozások hozzáadását, elérését, eltávolítását és frissítését alakzatokon **Aspose.Slides for Python via Java** használatával.

Telepítse a csomagot a [Installation](/slides/hu/python-java/installation/) útmutató szerint. Minden példa a `asposeslides` modult importálja a JVM indítása előtt, majd a JVM futása után importálja az API-t.

## **Hiperhivatkozás hozzáadása**

Hozzon létre egy téglalap alakzatot, amelynek hiperhivatkozása egy külső weboldalra mutat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com"))
finally:
    presentation.dispose()
```

## **Hiperhivatkozás elérése**

Olvassa el a hiperhivatkozás adatait az alakzat szövegrészéből.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com"))

    hyperlink = text_portion.getPortionFormat().getHyperlinkClick()
finally:
    presentation.dispose()
```

## **Hiperhivatkozás eltávolítása**

Törölje a hiperhivatkozást az alakzat szövegéből.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com"))

    text_portion.getPortionFormat().setHyperlinkClick(None)
finally:
    presentation.dispose()
```

## **Hiperhivatkozás frissítése**

Módosítsa egy meglévő hiperhivatkozás célját. Használja a [HyperlinkManager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlinkmanager/) elemet a már hiperhivatkozást tartalmazó szöveg módosításához, ami a PowerPoint biztonságos hiperhivatkozás-frissítési módját utánozza.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://old.example.com"))

    # A meglévő szövegben lévő hiperhivatkozás módosítását ezen keresztül kell végezni
    # HyperlinkManager-rel, ahelyett, hogy közvetlenül állítaná be a tulajdonságot.
    # Ez utánzja, ahogy a PowerPoint biztonságosan frissíti a hiperhivatkozásokat.
    text_portion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com")
finally:
    presentation.dispose()
```