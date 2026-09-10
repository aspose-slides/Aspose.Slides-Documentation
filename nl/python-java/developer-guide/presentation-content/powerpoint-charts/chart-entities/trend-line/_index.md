---
title: Trendlijnen toevoegen aan presentatiediagrammen in Python
linktitle: Trendlijn
type: docs
url: /nl/python-java/trend-line/
keywords:
- diagram
- trendlijn
- exponentiële trendlijn
- lineaire trendlijn
- logaritmische trendlijn
- voortschrijdende gemiddelde trendlijn
- polynomiale trendlijn
- machts trendlijn
- aangepaste trendlijn
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Voeg snel trendlijnen toe aan PowerPoint‑diagrammen en pas ze aan met Aspose.Slides voor Python via Java — een praktische gids om uw publiek te boeien."
---
## **Overzicht**

Dit artikel legt uit hoe u trendlijnen kunt toevoegen aan presentatiediagrammen met behulp van Aspose.Slides. Het laat zien hoe u een diagram maakt, trendlijnen toevoegt aan diagramreeksen, en werkt met verschillende trendlijntypen, waaronder exponentieel, lineair, logaritmisch, voortschrijdend gemiddelde, polynoom en macht.

Het beschrijft ook hoe u een aangepaste lijn aan een diagram kunt toevoegen door een lijnvorm in te voegen, en bevat een korte FAQ over de waarden voor vooruit- en achterwaartse projectie van trendlijnen en of trendlijnen behouden blijven bij export naar PDF of SVG en bij het renderen van diagrammen als afbeeldingen.

## **Trendlijn toevoegen**

Aspose.Slides for Python via Java biedt een eenvoudige API voor het beheren van verschillende trendlijnen in diagrammen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse.
2. Verkrijg een referentie naar een dia op basis van de index.
3. Voeg een diagram toe met standaardgegevens en het gewenste type (in dit voorbeeld wordt [ChartType.ClusteredColumn](https://reference.aspose.com/slides/nl/python-java/aspose.slides/charttype/#ClusteredColumn) gebruikt).
4. Voeg een exponentiële trendlijn toe aan diagramreeks 1.
5. Voeg een lineaire trendlijn toe aan diagramreeks 1.
6. Voeg een logaritmische trendlijn toe aan diagramreeks 2.
7. Voeg een trendlijn voor voortschrijdend gemiddelde toe aan diagramreeks 2.
8. Voeg een polynomiale trendlijn toe aan diagramreeks 3.
9. Voeg een machts‑trendlijn toe aan diagramreeks 3.
10. Schrijf de gewijzigde presentatie naar een PPTX‑bestand.

De volgende code maakt een diagram met trendlijnen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, TrendlineType
from java.awt import Color

# Maak een instantie van de Presentation-klasse.
presentation = Presentation()
try:
    # Maak een gegroepeerde kolomdiagram.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400)

    # Voeg een exponentiële trendlijn toe aan diagramreeks 1.
    exponential_trend_line = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential)
    exponential_trend_line.setDisplayEquation(False)
    exponential_trend_line.setDisplayRSquaredValue(False)

    # Voeg een lineaire trendlijn toe aan diagramreeks 1.
    linear_trend_line = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear)
    linear_trend_line.setTrendlineType(TrendlineType.Linear)
    linear_trend_line.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    linear_trend_line.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)

    # Voeg een logaritmische trendlijn toe aan diagramreeks 2.
    logarithmic_trend_line = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic)
    logarithmic_trend_line.setTrendlineType(TrendlineType.Logarithmic)
    logarithmic_trend_line.addTextFrameForOverriding("New log trend line")

    # Voeg een trendlijn voor voortschrijdend gemiddelde toe aan diagramreeks 2.
    moving_average_trend_line = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage)
    moving_average_trend_line.setTrendlineType(TrendlineType.MovingAverage)
    moving_average_trend_line.setPeriod(jpype.JByte(3))
    moving_average_trend_line.setTrendlineName("New TrendLine Name")

    # Voeg een polynomiale trendlijn toe aan diagramreeks 3.
    polynomial_trend_line = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial)
    polynomial_trend_line.setTrendlineType(TrendlineType.Polynomial)
    polynomial_trend_line.setForward(1)
    polynomial_trend_line.setOrder(jpype.JByte(3))

    # Voeg een machts trendlijn toe aan diagramreeks 3.
    power_trend_line = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Power)
    power_trend_line.setTrendlineType(TrendlineType.Power)
    power_trend_line.setBackward(1)

    # Sla de presentatie op.
    presentation.save("ChartTrendLines_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Aangepaste lijn toevoegen**

Aspose.Slides for Python via Java biedt een eenvoudige API om aangepaste lijnen aan een diagram toe te voegen. Om een eenvoudige lijn aan een diagram op een geselecteerde dia toe te voegen, volgt u deze stappen:

- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse.
- Verkrijg een referentie naar een dia op basis van de index.
- Maak een nieuw diagram met behulp van de [addChart](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapecollection/#addChart) methode van de [ShapeCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapecollection/) klasse.
- Voeg een lijnvorm toe met de [addAutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapecollection/#addAutoShape) methode en [ShapeType.Line](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapetype/#Line).
- Stel de kleur van de lijn van de vorm in.
- Schrijf de gewijzigde presentatie naar een PPTX‑bestand.

De volgende code maakt een diagram met een aangepaste lijn.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Maak een instantie van de Presentation-klasse.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)
    shape = chart.getUserShapes().getShapes().addAutoShape(ShapeType.Line, 0, chart.getHeight() / 2, chart.getWidth(), 0)

    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("Presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Wat betekenen 'forward' en 'backward' voor een trendlijn?**

Dit zijn de lengtes van de trendlijn die vooruit of achteruit worden geprojecteerd: bij spreidings‑ (XY‑) diagrammen worden ze gemeten in as‑eenheden; bij niet‑spreidings diagrammen worden ze gemeten in het aantal categorieën. Alleen niet‑negatieve waarden zijn toegestaan.

**Wordt de trendlijn behouden bij het exporteren van de presentatie naar PDF of SVG, of bij het renderen van een dia als afbeelding?**

Ja. Aspose.Slides converteert presentaties naar [PDF](/slides/nl/python-java/convert-powerpoint-to-pdf/)/[SVG](/slides/nl/python-java/render-a-slide-as-an-svg-image/) en rendert diagrammen naar afbeeldingen; trendlijnen, als onderdeel van het diagram, worden behouden tijdens deze bewerkingen. Er is ook een methode beschikbaar om een afbeelding van het diagram zelf te [exporteren](/slides/nl/python-java/create-shape-thumbnails/).