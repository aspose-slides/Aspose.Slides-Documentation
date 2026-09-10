---
title: "Kezelés diagram adatjelölőkkel prezentációkban Python használatával"
linktitle: "Adatjelölő"
type: docs
url: /hu/python-java/chart-data-marker/
keywords:
- diagram
- adatpont
- jelölő
- jelölő beállítások
- jelölő méret
- kitöltés típusa
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Tanulja meg, hogyan testre szabhatja a diagram adatjelölőket az Aspose.Slides for Python via Java környezetben, növelve a prezentáció hatását PPT és PPTX formátumokban, világos Python kódpéldákkal."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet a diagram adatjelölőkkel dolgozni az Aspose.Slides-ben. Megmutatja, hogyan hozhatunk létre diagramot, hogyan érhetjük el egy sorozatot és annak adatpontjait, hogyan alkalmazhatunk képi kitöltést a jelölőkre adatpont szinten, hogyan állíthatjuk be a jelölő méretét, és hogyan menthetjük el a frissített prezentációt. Továbbá megjegyzi, hogy a szabványos jelölő alakzatok a [MarkerStyleType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/markerstyletype/) felsorolásban érhetők el, és hogy a jelölő megjelenése megmarad a diagramok raszteres formátumokba vagy SVG-be exportálásakor.

## **Diagram jelölő beállítások megadása**

A jelölőket egy adott sorozat diagram adatpontjain lehet beállítani. A diagram jelölő beállításához kövesse ezeket a lépéseket:

- Példányosítsa a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályt.
- Hozza létre az alapértelmezett diagramot.
- Állítsa be a képeket.
- Érje el az első diagram sorozatot.
- Adjon hozzá új adatpontokat.
- Írja a prezentációt a lemezre.

Az alábbi példa a diagram jelölő beállításait adatpont szinten állítja be.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

# Üres prezentáció létrehozása.
presentation = Presentation()
try:
    # Az első dia elérése
    slide = presentation.getSlides().get_Item(0)

    # Az alapértelmezett diagram létrehozása
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400)

    # Az alapértelmezett diagramadat munkalap indexének lekérése.
    default_worksheet_index = 0

    # A diagramadat munkafüzet lekérése.
    workbook = chart.getChartData().getChartDataWorkbook()

    # Demo sorozat törlése
    chart.getChartData().getSeries().clear()

    # Új sorozat hozzáadása
    series_name_cell = workbook.getCell(default_worksheet_index, 1, 1, "Series 1")
    chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    # Az első kép betöltése.
    desert_bytes = Path("Desert.jpg").read_bytes()
    desert_image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(desert_bytes))

    # A második kép betöltése.
    tulips_bytes = Path("Tulips.jpg").read_bytes()
    tulips_image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(tulips_bytes))

    # Az első diagram sorozat elérése.
    series = chart.getChartData().getSeries().get_Item(0)

    # Adatpontok hozzáadása.
    value_cell = workbook.getCell(default_worksheet_index, 1, 1, 4.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(desert_image)

    value_cell = workbook.getCell(default_worksheet_index, 2, 1, 2.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(tulips_image)

    value_cell = workbook.getCell(default_worksheet_index, 3, 1, 3.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(desert_image)

    value_cell = workbook.getCell(default_worksheet_index, 4, 1, 4.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(tulips_image)

    # A diagram sorozat jelölő méretének módosítása.
    series.getMarker().setSize(15)

    # A prezentáció mentése diagrammal
    presentation.save("MarkOptions_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **GYIK**

**Mely jelölő alakzatok érhetők el alapértelmezés szerint?**

A szabványos alakzatok elérhetők (kör, négyzet, rombusz, háromszög stb.); a lista a [MarkerStyleType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/markerstyletype/) osztály által van meghatározva. Ha nem szabványos alakzatra van szüksége, használjon képi kitöltésű jelölőt a saját grafika megjelenítéséhez.

**Megmaradnak a jelölők egy diagram képbe vagy SVG-be exportálásakor?**

Igen. A diagramok [raszteres formátumokra](/slides/hu/python-java/convert-powerpoint-to-png/) való renderelésekor vagy a [alakzatok SVG-ként](/slides/hu/python-java/render-a-slide-as-an-svg-image/) történő mentésekor a jelölők megtartják megjelenésüket és beállításaikat, beleértve a méretet, a kitöltést és a körvonalat.