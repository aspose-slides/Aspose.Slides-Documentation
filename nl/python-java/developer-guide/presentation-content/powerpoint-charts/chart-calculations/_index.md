---
title: Optimaliseer grafiekberekeningen voor presentaties in Python via Java
linktitle: Grafiekberekeningen
type: docs
weight: 50
url: /nl/python-java/chart-calculations/
keywords:
- grafiekberekeningen
- grafelementen
- elementpositie
- werkelijke positie
- onderliggend element
- bovenliggend element
- grafiekwaarden
- werkelijke waarde
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Begrijp grafiekberekeningen, gegevensupdates en precisiebesturing in Aspose.Slides voor Python via Java voor PPT en PPTX, met praktische Python-codevoorbeelden."
---
## **Overzicht**

Aspose.Slides biedt API's voor het werken met grafiekberekeningen en lay-outgegevens in presentaties. Dit artikel laat zien hoe u de werkelijke waarden van grafelementen kunt ophalen, inclusief de daadwerkelijke positie en grootte van grafelementen en de werkelijke waarden van grafiekassen. Het legt ook uit dat deze waarden worden ingevuld na validatie van de grafieklay-out.

Daarnaast toont het artikel hoe u de werkelijke positie van bovenliggende grafelementen kunt verkrijgen en hoe u grafelementen zoals de titel, assen, legenda en rasterlijnen kunt verbergen. Samen helpen deze voorbeelden u om grafieklay-outinformatie te inspecteren en de zichtbaarheid van grafelementen in PowerPoint‑presentaties programmatisch te regelen.

## **Werkelijke waarden van grafelementen berekenen**
Aspose.Slides for Python via Java biedt een eenvoudige API om deze eigenschappen op te halen. Methoden van de [Axis](https://reference.aspose.com/slides/nl/python-java/aspose.slides/axis/)‑klasse geven informatie over de werkelijke waarden van grafiekassen ([getActualMaxValue](https://reference.aspose.com/slides/nl/python-java/aspose.slides/axis/#getActualMaxValue), [getActualMinValue](https://reference.aspose.com/slides/nl/python-java/aspose.slides/axis/#getActualMinValue), [getActualMajorUnit](https://reference.aspose.com/slides/nl/python-java/aspose.slides/axis/#getActualMajorUnit), [getActualMinorUnit](https://reference.aspose.com/slides/nl/python-java/aspose.slides/axis/#getActualMinorUnit), [getActualMajorUnitScale](https://reference.aspose.com/slides/nl/python-java/aspose.slides/axis/#getActualMajorUnitScale), [getActualMinorUnitScale](https://reference.aspose.com/slides/nl/python-java/aspose.slides/axis/#getActualMinorUnitScale)). Roep eerst de [Chart.validateChartLayout](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chart/#validateChartLayout)‑methode aan om deze eigenschappen met werkelijke waarden te vullen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getHorizontalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getHorizontalAxis().getActualMinorUnit()
finally:
    presentation.dispose()
```

## **Werkelijke positie van bovenliggende grafelementen berekenen**
Aspose.Slides for Python via Java biedt een eenvoudige API om deze eigenschappen op te halen. Methoden van de [ChartPlotArea](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartplotarea/)‑klasse geven informatie over de daadwerkelijke positie en grootte van het grafiek‑plotgebied ([getActualX](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartplotarea/#getActualX), [getActualY](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartplotarea/#getActualY), [getActualWidth](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartplotarea/#getActualWidth), [getActualHeight](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartplotarea/#getActualHeight)). Roep eerst de [Chart.validateChartLayout](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chart/#validateChartLayout)‑methode aan om deze eigenschappen met werkelijke waarden te vullen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350)
    chart.validateChartLayout()

    x = chart.getPlotArea().getActualX()
    y = chart.getPlotArea().getActualY()
    width = chart.getPlotArea().getActualWidth()
    height = chart.getPlotArea().getActualHeight()
finally:
    presentation.dispose()
```

## **Grafelementen verbergen**
Deze sectie legt uit hoe u informatie uit een grafiek kunt verbergen. Met Aspose.Slides for Python via Java kunt u de **Titel, verticale as, horizontale as** en **rasterlijnen** verbergen. Het onderstaande code‑voorbeeld laat zien hoe u deze eigenschappen kunt gebruiken.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LegendDataLabelPosition, LineDashStyle, MarkerStyleType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370)

    # Verberg de grafiektitel.
    chart.setTitle(False)

    # Verberg de waardenas.
    chart.getAxes().getVerticalAxis().setVisible(False)

    # Verberg de categoriena.
    chart.getAxes().getHorizontalAxis().setVisible(False)

    # Verberg de legenda.
    chart.setLegend(False)

    # Verberg de hoofdroosterlijnen.
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    # Houd alleen de eerste reeks. Verwijderen vanaf het einde houdt de resterende indexen geldig.
    series_collection = chart.getChartData().getSeries()
    while series_collection.size() > 1:
        series_collection.removeAt(series_collection.size() - 1)

    series = series_collection.get_Item(0)

    series.getMarker().setSymbol(MarkerStyleType.Circle)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.Top)
    series.getMarker().setSize(15)

    # Stel de lijnkleur van de reeks in.
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA)
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid)

    presentation.save("HideInformationFromChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Werken externe Excel‑werkboeken als gegevensbron, en hoe beïnvloedt dat de herberekening?**

Ja. Een grafiek kan een extern werkboek refereren: wanneer u de externe bron verbindt of vernieuwt, worden formules en waarden uit dat werkboek gehaald, en de grafiek geeft de updates weer tijdens openen/bewerken. Met de API kunt u het pad van het externe werkboek opgeven en de gekoppelde gegevens beheren.

**Kan ik trendlijnen berekenen en weergeven zonder zelf regressie te implementeren?**

Ja. Trendlijnen (lineair, exponentieel en andere) worden toegevoegd en bijgewerkt door Aspose.Slides; hun parameters worden automatisch opnieuw berekend op basis van de seriedata, dus u hoeft zelf geen berekeningen te implementeren.

**Als een presentatie meerdere grafieken met externe koppelingen bevat, kan ik bepalen welk werkboek elke grafiek gebruikt voor berekende waarden?**

Ja. Elke grafiek kan naar zijn eigen externe werkboek verwijzen, of u kunt per grafiek een extern werkboek maken/vervangen, onafhankelijk van de andere grafieken.