---
title: Hantera diagramdatamarkörer i presentationer med Python
linktitle: Datamarkör
type: docs
url: /sv/python-java/chart-data-marker/
keywords:
- diagram
- datapunkt
- markör
- marköralternativ
- markörstorlek
- fyllningstyp
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Lär dig hur du anpassar diagramdatamarkörer i Aspose.Slides för Python via Java, vilket ökar presentationens genomslag i PPT- och PPTX-format med tydliga Python-kodexempel."
---
## **Översikt**

Denna artikel förklarar hur man arbetar med diagramdatamarkörer i Aspose.Slides. Den visar hur man skapar ett diagram, får åtkomst till en serie och dess datapunkter, applicerar bildfyllningar på markörer på datapunktnivå, justerar markörstorlek och sparar den uppdaterade presentationen. Den nämner också att standardmarkörformer finns tillgängliga via uppräkningen [MarkerStyleType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/markerstyletype/) och att markörens utseende bevaras vid export av diagram till rasterformat eller SVG.

## **Ställ in diagrammarköralternativ**

Markörer kan sättas på diagramdatapunkter inom en specifik serie. För att ange diagrammarköralternativ, följ dessa steg:

- Instansiera klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
- Skapa standarddiagrammet.
- Ställ in bilderna.
- Få åtkomst till den första diagramserien.
- Lägg till nya datapunkter.
- Skriv presentationen till disk.

Följande exempel anger diagrammarköralternativ på datapunktnivå.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

# Skapa en tom presentation.
presentation = Presentation()
try:
    # Hämta åtkomst till första bilden
    slide = presentation.getSlides().get_Item(0)

    # Skapa standarddiagrammet
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400)

    # Hämta standarddiagrammets dataarbetsblad index.
    default_worksheet_index = 0

    # Hämta diagrammets dataarbetsbok.
    workbook = chart.getChartData().getChartDataWorkbook()

    # Ta bort demonstrationsserier
    chart.getChartData().getSeries().clear()

    # Lägg till ny serie
    series_name_cell = workbook.getCell(default_worksheet_index, 1, 1, "Series 1")
    chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    # Ladda den första bilden.
    desert_bytes = Path("Desert.jpg").read_bytes()
    desert_image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(desert_bytes))

    # Ladda den andra bilden.
    tulips_bytes = Path("Tulips.jpg").read_bytes()
    tulips_image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(tulips_bytes))

    # Hämta den första diagramserien.
    series = chart.getChartData().getSeries().get_Item(0)

    # Lägg till datapunkter.
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

    # Ändra diagramseriens markörstorlek.
    series.getMarker().setSize(15)

    # Spara presentation med diagram
    presentation.save("MarkOptions_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Vanliga frågor**

**Vilka markörformer finns tillgängliga direkt?**

Standardformer är tillgängliga (cirkel, fyrkant, diamant, triangel osv.); listan definieras av klassen [MarkerStyleType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/markerstyletype/). Om du behöver en icke‑standardform, använd en markör med en bildfyllning för att efterlikna anpassade visuella element.

**Behåller markörer sina egenskaper när ett diagram exporteras till en bild eller SVG?**

Ja. När diagram renderas till [rasterformat](/slides/sv/python-java/convert-powerpoint-to-png/) eller när [former sparas som SVG](/slides/sv/python-java/render-a-slide-as-an-svg-image/), behåller markörerna sitt utseende och sina inställningar, inklusive storlek, fyllning och kontur.