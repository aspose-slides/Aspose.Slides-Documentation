---
title: Diagramok exportálása prezentációkból Python via Java
linktitle: Diagram exportálása
type: docs
weight: 90
url: /hu/python-java/export-chart/
keywords:
- diagram
- diagram képbe
- diagram képként
- diagramkép kinyerése
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan exportálhatja a prezentációs diagramokat az Aspose.Slides for Python via Java segítségével, PPT és PPTX formátumok támogatásával, és egyszerűsítse a jelentéstételt bármilyen munkafolyamatban."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy egy diagramot a bemutatóból képként exportálja. Ez a cikk bemutatja, hogyan lehet egy diagramról képet szerezni és elmenteni, ami akkor hasznos, ha a diagramok vizuális elemeit a PowerPoint bemutatón kívül szeretné újra felhasználni.

Az alapvető képexportálási folyamat mellett a cikk a gyakori exporttal kapcsolatos kérdésekre is kitér, többek között a diagram tartalmának SVG formátumba mentésére, a kimeneti méret vezérlésére a renderelési beállítások segítségével, betűtípusok betöltésére a címkék és a jelmagyarázat megjelenésének megőrzése érdekében, valamint az eredeti bemutató formázásának (témák, stílusok, kitöltések és effektek) megtartására a renderelés során.

## **Diagramkép lekérése**
Az Aspose.Slides for Python via Java támogatja egy adott diagram képének kinyerését. Az alábbi példa bemutatja, hogyan kell ezt megtenni.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, ImageFormat, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart_image = chart.getImage()
    try:
        chart_image.save("image.jpg", ImageFormat.Jpeg)
    finally:
        chart_image.dispose()
finally:
    presentation.dispose()
```

## **GYIK**

**Exportálhatok egy diagramot vektorként (SVG) a raszteres kép helyett?**

Igen. A diagram egy alakzat, és tartalma SVG‑ként menthető a [shape-to-SVG mentési módszer] (https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#writeAsSvgToBytes) segítségével.

**Hogyan állíthatom be a exportált diagram pontos pixelméretét?**

Használja a képrenderelés túlterheléseit, amelyek lehetővé teszik a méret vagy a skála megadását – a könyvtár támogatja az objektumok adott mérettel/skálával történő renderelését.

**Mit tegyek, ha a címkék és a jelmagyarázat betűtípusa hibásan jelenik meg export után?**

[Töltsük be a szükséges betűtípusokat](/slides/hu/python-java/custom-font/) a [FontsLoader] (https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsloader/) segítségével, hogy a diagram renderelése megőrizze a metrikákat és a szöveg megjelenését.

**Tiszteletben tartja-e az export a PowerPoint témát, stílusokat és effektusokat?**

Igen. Az Aspose.Slides renderelője követi a bemutató formázását (témák, stílusok, kitöltések, effektusok), így a diagram megjelenése megmarad.

**Hol találom a diagramképeken túlmutató renderelési/exportálási lehetőségeket?**

Lásd az [API] (https://reference.aspose.com/slides/hu/python-java/aspose.slides/)/[dokumentáció] (/slides/hu/python-java/convert-powerpoint/) a kimeneti célpontokhoz ([PDF] (/slides/hu/python-java/convert-powerpoint-to-pdf/), [SVG] (/slides/hu/python-java/render-a-slide-as-an-svg-image/), [XPS] (/slides/hu/python-java/convert-powerpoint-to-xps/), [HTML] (/slides/hu/python-java/convert-powerpoint-to-html/), stb.) és a kapcsolódó renderelési beállítások.