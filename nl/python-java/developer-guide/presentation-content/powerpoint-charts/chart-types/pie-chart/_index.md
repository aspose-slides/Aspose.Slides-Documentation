---
title: Cirkeldiagrammen aanpassen in presentaties met Python via Java
linktitle: Cirkeldiagram
type: docs
url: /nl/python-java/pie-chart/
keywords:
- cirkeldiagram
- diagram beheren
- diagram aanpassen
- diagramopties
- diagraminstellingen
- plotopties
- segmentkleur
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Leer hoe u cirkeldiagrammen kunt maken en aanpassen in Python via Java met Aspose.Slides, exporteerbaar naar PowerPoint, waardoor u uw dataverhaal in enkele seconden verbetert."
---
## **Overzicht**

Dit artikel legt uit hoe u met cirkeldiagrammen in Aspose.Slides werkt. Het laat zien hoe u secundaire plotopties kunt configureren voor Pie of Pie- en Bar of Pie-diagrammen, en hoe u automatische kleurtoewijzing van segmenten voor een standaard cirkeldiagram kunt inschakelen.

De voorbeelden richten zich op praktische stappen voor het aanpassen van diagrammen, zoals een diagram toevoegen aan een dia, het aanpassen van series- en labelinstellingen, het vervangen van standaard diagramgegevens door aangepaste categorieën en waarden, en het opslaan van de bijgewerkte presentatie.

## **Secundaire plotopties voor Pie of Pie- en Bar of Pie-diagrammen**

Aspose.Slides for Python via Java ondersteunt secundaire plotopties voor Pie of Pie- en Bar of Pie-diagrammen. Deze sectie laat zien hoe u die opties specificeert met Aspose.Slides. Volg deze stappen:

1. Instantieer een [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) object.
1. Voeg een diagram toe aan de dia.
1. Specificeer de secundaire plotopties van het diagram.
1. Schrijf de presentatie naar schijf.

Het volgende voorbeeld stelt verschillende eigenschappen van een Pie of Pie-diagram in.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

# Maak een instantie van de Presentation-klasse aan.
presentation = Presentation()
try:
    # Voeg een diagram toe aan de dia.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400)

    # Stel verschillende eigenschappen in.
    series = chart.getChartData().getSeries().get_Item(0)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setSecondPieSize(149)
    series_group.setPieSplitBy(PieSplitType.ByPercentage)
    series_group.setPieSplitPosition(53)

    # Schrijf de presentatie naar schijf.
    presentation.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Automatische kleuren van cirkeldiagramsegmenten instellen**

Aspose.Slides for Python via Java biedt een eenvoudige API voor het instellen van automatische kleuren van cirkeldiagramsegmenten. Het volgende voorbeeld toont hoe u deze instellingen toepast.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse.
1. Toegang tot de eerste dia.
1. Voeg een diagram toe met standaardgegevens.
1. Stel de diagramtitel in.
1. Stel de index van het werkblad met diagramgegevens in.
1. Haal het werkboek met diagramgegevens op.
1. Verwijder de standaard series en categorieën.
1. Voeg nieuwe categorieën toe.
1. Voeg een nieuwe serie toe.
1. Stel de nieuwe serie in om waarden weer te geven.

Schrijf de gewijzigde presentatie naar een PPTX-bestand.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

# Maak een instantie van de Presentation-klasse aan.
presentation = Presentation()
try:
    # Voeg een diagram toe met standaardgegevens.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # Stel de diagramtitel in.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # Stel de index van het werkblad met diagramgegevens in.
    default_worksheet_index = 0

    # Haal het werkboek met diagramgegevens op.
    workbook = chart.getChartData().getChartDataWorkbook()

    # Verwijder de standaard series en categorieën.
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # Voeg nieuwe categorieën toe.
    first_category_cell = workbook.getCell(0, 1, 0, "First Qtr")
    chart.getChartData().getCategories().add(first_category_cell)
    second_category_cell = workbook.getCell(0, 2, 0, "2nd Qtr")
    chart.getChartData().getCategories().add(second_category_cell)
    third_category_cell = workbook.getCell(0, 3, 0, "3rd Qtr")
    chart.getChartData().getCategories().add(third_category_cell)

    # Voeg een nieuwe serie toe.
    series_cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_cell, chart.getType())

    # Vul de seriesgegevens.
    first_value_cell = workbook.getCell(default_worksheet_index, 1, 1, jpype.JInt(20))
    series.getDataPoints().addDataPointForPieSeries(first_value_cell)
    second_value_cell = workbook.getCell(default_worksheet_index, 2, 1, jpype.JInt(50))
    series.getDataPoints().addDataPointForPieSeries(second_value_cell)
    third_value_cell = workbook.getCell(default_worksheet_index, 3, 1, jpype.JInt(30))
    series.getDataPoints().addDataPointForPieSeries(third_value_cell)

    # Stel de nieuwe serie in om waarden weer te geven.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    series.getParentSeriesGroup().setColorVaried(True)
    presentation.save("Pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Zijn de 'Pie of Pie' en 'Bar of Pie' varianten ondersteund?**

Ja, de bibliotheek [ondersteunt](https://reference.aspose.com/slides/nl/python-java/aspose.slides/charttype/) een secundaire plot voor cirkeldiagrammen, inclusief de types 'Pie of Pie' en 'Bar of Pie'.

**Kan ik alleen het diagram exporteren als afbeelding (bijvoorbeeld PNG)?**

Ja, u kunt het diagram zelf [exporteren als afbeelding](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getImage) (bijvoorbeeld PNG) zonder de volledige presentatie.