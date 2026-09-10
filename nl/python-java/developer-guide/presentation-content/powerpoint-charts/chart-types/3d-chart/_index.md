---
title: Pas 3D-grafieken aan in presentaties met Python
linktitle: 3D-grafiek
type: docs
url: /nl/python-java/3d-chart/
keywords:
- 3D-grafiek
- rotatie
- diepte
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Leer hoe je 3D-grafieken kunt maken en aanpassen in Aspose.Slides voor Python via Java, met ondersteuning voor PPT- en PPTX-bestanden - verbeter vandaag nog je presentaties."
---
## **Overzicht**

Dit artikel legt uit hoe je een 3D‑grafiek in Aspose.Slides kunt aanpassen door de instellingen van [Rotation3D](https://reference.aspose.com/slides/nl/python-java/aspose.slides/rotation3d/) te configureren, zoals [setRotationX](https://reference.aspose.com/slides/nl/python-java/aspose.slides/rotation3d/#setRotationX), [setRotationY](https://reference.aspose.com/slides/nl/python-java/aspose.slides/rotation3d/#setRotationY), [setDepthPercents](https://reference.aspose.com/slides/nl/python-java/aspose.slides/rotation3d/#setDepthPercents) en [setRightAngleAxes](https://reference.aspose.com/slides/nl/python-java/aspose.slides/rotation3d/#setRightAngleAxes). Het laat zien hoe je een presentatie maakt, een 3D‑grafiek met standaarddata toevoegt, de vereiste 3D‑weergave‑instellingen toepast en de aangepaste presentatie opslaat als een PPTX‑bestand.

## **X‑rotatie, Y‑rotatie en diepte van een 3D‑grafiek instellen**
Aspose.Slides for Python via Java biedt een eenvoudige API om deze eigenschappen in te stellen. Het onderstaande voorbeeld laat zien hoe je de X‑rotatie, Y‑rotatie en diepte van een 3D‑grafiek kunt configureren.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse.
2. Open de eerste dia.
3. Voeg een grafiek toe met standaarddata.
4. Stel de 3D‑rotatie‑eigenschappen in.
5. Schrijf de aangepaste presentatie weg naar een PPTX‑bestand.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    # Toegang tot de eerste dia.
    slide = presentation.getSlides().get_Item(0)

    # Voeg een grafiek toe met standaarddata.
    chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500)

    # Stel de werkbladindex voor de grafiekdata in.
    default_worksheet_index = 0

    # Haal het werkboek voor de grafiekdata op.
    workbook = chart.getChartData().getChartDataWorkbook()

    # Voeg series toe.
    series_cell = workbook.getCell(default_worksheet_index, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(series_cell, chart.getType())
    series_cell = workbook.getCell(default_worksheet_index, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(series_cell, chart.getType())

    # Voeg categorieën toe.
    category_cell = workbook.getCell(default_worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(default_worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(default_worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(category_cell)

    # Stel de 3D-rotatie-eigenschappen in.
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(270)
    chart.getRotation3D().setDepthPercents(150)

    # Toegang tot de tweede serie van de grafiek.
    series = chart.getChartData().getSeries().get_Item(1)

    # Vul de seriegegevens in.
    data_cell = workbook.getCell(default_worksheet_index, 1, 1, jpype.JInt(20))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 2, 1, jpype.JInt(50))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 3, 1, jpype.JInt(30))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 1, 2, jpype.JInt(30))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 2, 2, jpype.JInt(10))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 3, 2, jpype.JInt(60))
    series.getDataPoints().addDataPointForBarSeries(data_cell)

    # Sla de presentatie op.
    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Welke grafiektype‑varianten ondersteunen 3D‑modus in Aspose.Slides?**

Aspose.Slides ondersteunt 3D‑varianten van kolomgrafieken, waaronder Column 3D, Clustered Column 3D, Stacked Column 3D en 100 % Stacked Column 3D, evenals gerelateerde 3D‑typen die beschikbaar zijn via de [ChartType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/charttype/)‑klasse. Voor een exacte en actuele lijst, bekijk de leden van [ChartType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/charttype/) in de API‑referentie van jouw geïnstalleerde versie.

**Kan ik een raster‑afbeelding van een 3D‑grafiek krijgen voor een rapport of het web?**

Ja. Je kunt een grafiek exporteren naar een afbeelding via de [chart API](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getImage) of [de volledige dia renderen](/slides/nl/python-java/convert-powerpoint-to-png/) naar formaten zoals PNG of JPEG. Dit is handig wanneer je een pixel‑perfecte preview nodig hebt of de grafiek wilt insluiten in documenten, dashboards of webpagina’s zonder dat PowerPoint vereist is.

**Hoe presteert het bouwen en renderen van grote 3D‑grafieken?**

De prestaties hangen af van het datavolume en de visuele complexiteit. Voor optimale resultaten houd je 3D‑effecten tot een minimum, vermijd je zware texturen op wanden en plot‑gebieden, beperk je het aantal gegevenspunten per serie waar mogelijk, en render je naar een output van passende grootte (resolutie en afmetingen) die overeenkomt met het beoogde scherm of de afdruk.