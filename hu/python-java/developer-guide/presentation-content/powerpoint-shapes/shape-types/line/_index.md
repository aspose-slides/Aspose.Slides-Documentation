---
title: Vonal alakzatok hozzáadása a prezentációkhoz Pythonon keresztül Java-val
linktitle: Vonal
type: docs
weight: 50
url: /hu/python-java/line/
keywords:
- vonal
- vonal létrehozása
- vonal hozzáadása
- egyszerű vonal
- vonal konfigurálása
- vonal testreszabása
- szaggatott stílus
- nyílfej
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan módosíthatja a vonalak formázását PowerPoint prezentációkban az Aspose.Slides for Python via Java segítségével. Fedezze fel a tulajdonságokat, metódusokat és példákat."
---
## **Áttekintés**

Aspose.Slides lehetővé teszi, hogy programozott módon vonal alakzatokat adjunk hozzá a PowerPoint-diákhoz. Ez a cikk bemutatja, hogyan hozhatunk létre egy egyszerű vonalat, és hogyan testreszabhatunk egy vonalat úgy, hogy nyílnak látszódjon.

Megtanulja, hogyan adjon hozzá vonal alakzatot egy diára, állítsa be a megjelenését, és mentse a módosított prezentációt. A példák a gyakorlati vonalformázási beállításokra koncentrálnak, mint például a stílus, a szélesség, a vonalas minta, a nyílfej beállítások és a kitöltőszín.

## **Egyszerű vonal létrehozása**

Egy egyszerű vonal hozzáadásához a prezentáció kiválasztott diájához kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation] osztályból.
- Szerezzen hivatkozást egy diára az indexe alapján.
- Adjon hozzá egy vonal alakzatot a [ShapeCollection] objektum [addAutoShape] metódusával.
- Írja ki a módosított prezentációt PPTX fájlként.

A következő példa egy vonalat ad az első diára a prezentációban:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Példányosítsa a Presentation osztályt, amely a PPTX fájlt képviseli.
presentation = Presentation()
try:
    # Szerezze meg az első diát.
    slide = presentation.getSlides().get_Item(0)

    # Adjon hozzá egy vonal alakzatot.
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0)

    # Írja a PPTX fájlt a lemezre.
    presentation.save("LineShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Nyíl alakú vonal létrehozása**

Az Aspose.Slides for Python via Java lehetővé teszi a fejlesztők számára, hogy a vonal tulajdonságait konfigurálják, hogy a vonal vonzóbb legyen. Egy vonal nyílszerű megjelenítéséhez kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation] osztályból.
- Szerezzen hivatkozást egy diára az indexe alapján.
- Adjon hozzá egy vonal alakzatot a [ShapeCollection] objektum [addAutoShape] metódusával.
- Állítsa be a [line style] egyik stílusra, amelyet az Aspose.Slides for Python via Java kínál.
- Állítsa be a vonal szélességét.
- Állítsa be a [dash style] egyik stílusra, amelyet az Aspose.Slides for Python via Java kínál.
- Állítsa be a [arrowhead style] és a [length] a vonal elején.
- Állítsa be a [arrowhead style] és a [length] a vonal végén.
- Írja ki a módosított prezentációt PPTX fájlként.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadLength, LineArrowheadStyle, LineDashStyle, LineStyle, Presentation, PresetColor, SaveFormat, ShapeType

# Példányosítsa a Presentation osztályt, amely a PPTX fájlt képviseli.
presentation = Presentation()
try:
    # Szerezze meg az első diát.
    slide = presentation.getSlides().get_Item(0)

    # Adjon hozzá egy vonal alakzatot.
    line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0)

    # Alkalmazza a formázást a vonalra.
    line_format = line.getLineFormat()
    line_format.setStyle(LineStyle.ThickBetweenThin)
    line_format.setWidth(10)

    line_format.setDashStyle(LineDashStyle.DashDot)

    line_format.setBeginArrowheadLength(LineArrowheadLength.Short)
    line_format.setBeginArrowheadStyle(LineArrowheadStyle.Oval)

    line_format.setEndArrowheadLength(LineArrowheadLength.Long)
    line_format.setEndArrowheadStyle(LineArrowheadStyle.Triangle)

    line_format.getFillFormat().setFillType(FillType.Solid)
    line_format.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.Maroon)

    # Írja a PPTX fájlt a lemezre.
    presentation.save("LineShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **GYIK**

**Átalakíthatom a normál vonalat csatlakozóvá, hogy a "rögzül" az alakzatokhoz?**

Nem. Egy normál vonal (egy [AutoShape] típusú [Line]) nem alakul automatikusan csatlakozóvá. Ahhoz, hogy rögzüljenek az alakzatokhoz, használja a dedikált [Connector] típust és a [corresponding APIs](/slides/hu/python-java/connector/) kapcsolatépítéshez.

**Mit tegyek, ha egy vonal tulajdonságai a témától öröklődnek, és nehéz meghatározni a végleges értékeket?**

[Olvassa el a hatékony tulajdonságokat](/slides/hu/python-java/shape-effective-properties/) a vonalra és a kitöltésére vonatkozóan – ezek már figyelembe veszik az öröklődést és a téma stílusait.

**Zárolhatom a vonalat a szerkesztés (mozgatás, átméretezés) ellen?**

Igen. Az alakzatok [lock objects] biztosítanak lehetőséget, hogy [disallow editing operations](/slides/hu/python-java/applying-protection-to-presentation/).