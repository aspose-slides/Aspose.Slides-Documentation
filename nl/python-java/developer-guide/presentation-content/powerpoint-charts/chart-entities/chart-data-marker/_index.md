---
title: Beheer diagramdatamarkers in presentaties met Python
linktitle: Datamarker
type: docs
url: /nl/python-java/chart-data-marker/
keywords:
- diagram
- datapunt
- marker
- markeropties
- marker grootte
- vullingstype
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Leer hoe u diagramdatamarkers in Aspose.Slides voor Python via Java kunt aanpassen, waardoor de impact van presentaties in PPT- en PPTX-formaten wordt vergroot met duidelijke Python-codevoorbeelden."
---
## **Overzicht**

Dit artikel legt uit hoe u met diagramdatamarkers in Aspose.Slides kunt werken. Het laat zien hoe u een diagram maakt, een serie en de bijbehorende datapunten benadert, afbeeldingsvullingen toepast op markers op het niveau van individuele datapunten, de marker‑grootte aanpast en de bijgewerkte presentatie opslaat. Het vermeldt tevens dat standaard marker‑vormen beschikbaar zijn via de [MarkerStyleType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/markerstyletype/) enumeratie en dat de uitstraling van markers behouden blijft bij het exporteren van diagrammen naar rasterformaten of SVG.

## **Instellen van diagrammarkeropties**
Markers kunnen worden ingesteld op diagramdatapunten binnen een specifieke serie. Volg deze stappen om diagrammarkeropties in te stellen:

- Instantieer de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse.
- Maak het standaarddiagram.
- Stel de afbeeldingen in.
- Benader de eerste diagramserie.
- Voeg nieuwe datapunten toe.
- Schrijf de presentatie naar schijf.

Het volgende voorbeeld stelt diagrammarkeropties in op het niveau van individuele datapunten.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

# Maak een lege presentatie aan.
presentation = Presentation()
try:
    # Toegang tot de eerste dia
    slide = presentation.getSlides().get_Item(0)

    # Maak het standaarddiagram aan
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400)

    # Haal de index van het standaard werkblad met diagramdata op.
    default_worksheet_index = 0

    # Haal het werkboek met diagramdata op.
    workbook = chart.getChartData().getChartDataWorkbook()

    # Verwijder demo-reeks
    chart.getChartData().getSeries().clear()

    # Voeg een nieuwe reeks toe
    series_name_cell = workbook.getCell(default_worksheet_index, 1, 1, "Series 1")
    chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    # Laad de eerste afbeelding.
    desert_bytes = Path("Desert.jpg").read_bytes()
    desert_image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(desert_bytes))

    # Laad de tweede afbeelding.
    tulips_bytes = Path("Tulips.jpg").read_bytes()
    tulips_image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(tulips_bytes))

    # Toegang tot de eerste diagramreeks.
    series = chart.getChartData().getSeries().get_Item(0)

    # Voeg datapunten toe.
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

    # Wijzig de marker-grootte van de diagramreeks.
    series.getMarker().setSize(15)

    # Sla de presentatie op met diagram
    presentation.save("MarkOptions_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Welke marker‑vormen zijn er standaard beschikbaar?**

Standaardvormen zijn beschikbaar (cirkel, vierkant, diamant, driehoek, enz.); de lijst wordt gedefinieerd door de [MarkerStyleType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/markerstyletype/) klasse. Als u een niet‑standaard vorm nodig heeft, gebruik dan een marker met een afbeeldingvulling om aangepaste visuals te emuleren.

**Worden markers behouden bij het exporteren van een diagram naar een afbeelding of SVG?**

Ja. Bij het renderen van diagrammen naar [raster formats](/slides/nl/python-java/convert-powerpoint-to-png/) of het opslaan van [shapes as SVG](/slides/nl/python-java/render-a-slide-as-an-svg-image/) behouden markers hun uiterlijk en instellingen, inclusief grootte, vulling en omtrek.