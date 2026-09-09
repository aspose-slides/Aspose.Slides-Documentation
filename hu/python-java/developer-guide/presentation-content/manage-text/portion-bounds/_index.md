---
title: Szövegrész határainak lekérése bemutatókban Pythonon keresztül Java-val
linktitle: Rész határa
type: docs
weight: 47
url: /hu/python-java/portion-bounds/
keywords:
- szövegrész határok
- szövegrész
- szöveg rész
- szöveg koordináták
- szöveg pozíció
- PowerPoint
- bemutató
- Python
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan lehet lekérni a szövegrész határait PowerPoint bemutatókban az Aspose.Slides for Python via Java használatával."
---
## **Áttekintés**

A szövegrész egy bekezdésen belüli konkrét szövegtöredéket képvisel, és lehetővé teszi, hogy az adott töredékkel a környező tartalomtól függetlenül dolgozzon. Az Aspose.Slides-ban a részek akkor használhatók, amikor egy szövegtöredék határait szeretné lekérdezni, csak a bekezdés egy részére szeretne formázást alkalmazni, vagy részletesebb szinten szeretné szabályozni a szöveg viselkedését.

Ez a cikk bemutatja, hogyan lehet a rész körülhatároló téglalapját lekérni a [Portion.getRect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portion/#getRect) használatával. Emellett azt is megmutatja, hogyan lehet a rész elejének koordinátáit lekérni a [Portion.getCoordinates](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portion/#getCoordinates) használatával. Továbbá kiemeli a szokásos, a részhez kapcsolódó forgatókönyveket, például egyetlen szövegtöredékre történő hiperhivatkozás alkalmazását, a formázás rész, bekezdés, szövegkeret és téma öröklődésén keresztüli feloldását, valamint a megadott betűkészlet hiányával járó esetek kezelését.

## **A szövegrész határainak lekérése**

Használja a [Portion.getRect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portion/#getRect) metódust a szövegrész körülhatároló téglalapjának lekéréséhez:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    for paragraph in shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            rectangle = portion.getRect()
            print(f"X = {rectangle.x}; Y = {rectangle.y}; Width = {rectangle.width}; Height = {rectangle.height}")
finally:
    presentation.dispose()
```

## **A szövegrész koordinátáinak lekérése**

Használja a [Portion.getCoordinates](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portion/#getCoordinates) metódust a szövegrész elejének koordinátáinak lekéréséhez:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    for paragraph in shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            point = portion.getCoordinates()
            print(f"X = {point.x}; Y = {point.y}")
finally:
    presentation.dispose()
```

## **GYIK**

**Alkalmazhatok hiperhivatkozást csak a szöveg egy részére egyetlen bekezdésen belül?**

Igen, egy egyedi részhez [hozzárendelhet egy hiperhivatkozást](/slides/hu/python-java/manage-hyperlinks/) ; csak az a töredék lesz kattintható, nem a teljes bekezdés.

**Hogyan működik a stílusöröklődés: mit felülír egy rész, és mi kerül át a bekezdésből vagy a szövegkeretből?**

A rész szintű tulajdonságok a legmagasabb precedenciával rendelkeznek. Ha egy tulajdonság nincs beállítva a [Portion](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portion/) esetén, az Aspose.Slides a [Paragraph](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraph/) értékét veszi át. Ha ott sem van beállítva, az Aspose.Slides a [TextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/) vagy a [theme](https://reference.aspose.com/slides/hu/python-java/aspose.slides/theme/) stílusát használja.

**Mi történik, ha a részhez megadott betűkészlet hiányzik a célgépen vagy szerveren?**

[Betűkészlet helyettesítési szabályok](/slides/hu/python-java/font-selection-sequence/) érvényesülnek. A szöveg átalakulhat: a metrikák, a szóelválasztás és a szélesség változhat, ami a pontos pozicionálás szempontjából fontos.

**Beállíthatok-e a részhez specifikus szövegtöltés áttetszőséget vagy fokozatot a bekezdés többi részétől függetlenül?**

Igen, a szövegszín, a töltés és az áttetszőség a [Portion](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portion/) szinten eltérhet a szomszédos töredékektől.