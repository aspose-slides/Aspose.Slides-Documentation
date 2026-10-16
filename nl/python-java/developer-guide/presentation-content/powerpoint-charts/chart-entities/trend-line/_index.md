---
title: Trendlijnen toevoegen aan presentatiegrafieken in Python
linktitle: Trendlijn
type: docs
url: /nl/python-java/trend-line/
keywords:
- grafiek
- trendlijn
- exponentiële trendlijn
- lineaire trendlijn
- logaritmische trendlijn
- trendlijn met voortschrijdend gemiddelde
- polynomiale trendlijn
- machts trendlijn
- aangepaste trendlijn
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Voeg snel trendlijnen toe en pas ze aan in PowerPoint‑grafieken met Aspose.Slides voor Python via Java — een praktische gids om uw publiek te boeien."
---
## **Overzicht**

Dit artikel legt uit hoe je trendlijnen kunt toevoegen aan presentatiegrafieken met Aspose.Slides. Het laat zien hoe je een grafiek maakt, trendlijnen toevoegt aan grafiekseries, en werkt met verschillende trendlinietypen, waaronder exponentiële, lineaire, logaritmische, bewegend gemiddelde, polynomiale en machts.

Het beschrijft ook hoe je een aangepaste lijn aan een grafiek toevoegt door een vorm toe te voegen, en bevat een korte FAQ over de projectiewaarden ‘forward’ en ‘backward’ van een trendlijn en of trendlijnen behouden blijven bij export naar PDF of SVG en bij het renderen van grafieken als afbeeldingen.

## **Trendlijn toevoegen**

Gebruik [TrendlineCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/trendlinecollection/#add) om een trendlijn toe te voegen aan een grafiekserie, waarbij het type wordt geselecteerd met [TrendlineType](https://reference.aspose.com/slides/python-java/aspose.slides/trendlinetype/). Het voorbeeld maakt een gegroepeerde kolomgrafiek met standaardgegevens en voegt twee trendlijnen toe aan elk van de drie series.

De exponentiële trendlijn verbergt zijn vergelijking en R‑kwadraat‑waarde via [setDisplayEquation](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setDisplayEquation) en [setDisplayRSquaredValue](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setDisplayRSquaredValue), terwijl de lineaire trendlijn rood is. De logaritmische trendlijn gebruikt [addTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#addTextFrameForOverriding) voor een aangepast label. Het bewegende gemiddelde gebruikt een [setPeriod](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setPeriod) van drie gegevenspunten en een aangepaste [setTrendlineName](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setTrendlineName).

De polynomiale trendlijn heeft een orde van drie, ingesteld via [setOrder](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setOrder), en breidt één categorie vooruit uit via [setForward](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setForward). De machts‑trendlijn breidt één categorie terug uit via [setBackward](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setBackward).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, TrendlineType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400)

    first_series = chart.getChartData().getSeries().get_Item(0)

    exponential_trendline = first_series.getTrendLines().add(TrendlineType.Exponential)
    exponential_trendline.setDisplayEquation(False)
    exponential_trendline.setDisplayRSquaredValue(False)

    linear_trendline = first_series.getTrendLines().add(TrendlineType.Linear)
    linear_trendline.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    linear_trendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)

    second_series = chart.getChartData().getSeries().get_Item(1)

    logarithmic_trendline = second_series.getTrendLines().add(TrendlineType.Logarithmic)
    logarithmic_trendline.addTextFrameForOverriding("New log trend line")

    moving_average_trendline = second_series.getTrendLines().add(TrendlineType.MovingAverage)
    moving_average_trendline.setPeriod(jpype.JByte(3))
    moving_average_trendline.setTrendlineName("New TrendLine Name")

    third_series = chart.getChartData().getSeries().get_Item(2)

    polynomial_trendline = third_series.getTrendLines().add(TrendlineType.Polynomial)
    polynomial_trendline.setForward(1)
    polynomial_trendline.setOrder(jpype.JByte(3))

    power_trendline = third_series.getTrendLines().add(TrendlineType.Power)
    power_trendline.setBackward(1)

    presentation.save("ChartTrendLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Intercept van een trendlijn instellen**

Gebruik [setIntercept](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setIntercept) om de Y‑waarde van een trendlijn te fixeren bij X = 0. Deze instelling wordt ondersteund voor lineaire, exponentiële en polynomiale trendlijnen.

Bijvoorbeeld, een productiekostmodel moet mogelijk beginnen met bekende vaste kosten van 100, zelfs wanneer metingen bij niet‑nul productievolumes een andere basislijn suggereren. Voor een lineaire trendlijn dwingt het fixeren van de intercept de vergelijking `y = ax + b` tot `b = 100`; de helling wordt dan passend gemaakt aan de gegevens onder die beperking. Het verplaatst niet simpelweg een reeds passende lijn. Instellingen voor het kruisen van assen bepalen waar de assen van de grafiek elkaar ontmoeten, niet de coëfficiënten van de aangepaste trendlijn.

Het volgende voorbeeld maakt een spreidings‑ (XY‑)grafiek met productievolumes van 1 tot 4 en kosten van 170, 200, 230 en 260. Het slaat de grafiek op met de standaard automatische intercept, stelt de intercept in op 100, en slaat een tweede PPTX op. De twee bestanden verschillen alleen in de intercept‑instelling. De trendlijn toont zijn vergelijking en strekt zich uit tot X = 0.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, TrendlineType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210)
    chart.setLegend(False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    name_cell = workbook.getCell(0, 0, 1, "Production cost")
    series = chart.getChartData().getSeries().add(name_cell, ChartType.ScatterWithMarkers)
    costs = [170, 200, 230, 260]

    for i in range(len(costs)):
        x_cell = workbook.getCell(0, i + 1, 0, i + 1)
        y_cell = workbook.getCell(0, i + 1, 1, costs[i])
        series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    trendline = series.getTrendLines().add(TrendlineType.Linear)
    trendline.setDisplayEquation(True)
    trendline.setBackward(1)

    presentation.save("AutomaticIntercept.pptx", SaveFormat.Pptx)

    trendline.setIntercept(100)
    presentation.save("FixedIntercept.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Met automatische berekening leveren deze gegevens `y = 30x + 140` op. Het instellen van de intercept op 100 in plaats daarvan levert ongeveer `y = 43.33x + 100` op: de aangepaste waarde bij nul komt overeen met de bekende basislijn, terwijl de lijn niet langer door elk gegevenspunt gaat.

| Automatische intercept | Vaste intercept van 100 |
| --- | --- |
| ![Lineaire trendlijn met een automatisch berekende intercept van 140](intercept-automatic.png) | ![Lineaire trendlijn met een vaste intercept van 100](intercept-fixed.png) |

Beide afbeeldingen gebruiken dezelfde gegevens en as‑schalen. De trendlijnen worden terug uitgerekt tot X = 0 om hun intercepten te tonen.

Standaard retourneert [getIntercept](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#getIntercept) `NaN`, wat een niet‑gespecificeerde intercept aanduidt in plaats van nul. De intercept wordt vervolgens automatisch berekend uit de gegevens.

## **Aangepaste lijn toevoegen**

Een aangepaste lijn is een vorm die over de grafiek wordt getekend in plaats van een trendlijn die wordt berekend uit seriedata. Dit voorbeeld gebruikt [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAutoShape) om een horizontale lijn toe te voegen aan de dia boven de grafiek. De positie van de lijn wordt opgegeven in dia‑coördinaten, gemeten in points, zodat hij begint bij de linkerrand van de grafiek en halverwege de grafiek ligt. De breedte komt overeen met de breedte van de grafiek. De methode [getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) geeft toegang tot de lijnopmaak die wordt gebruikt om een effen rode kleur toe te passen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)

    line = slide.getShapes().addAutoShape(ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0)
    line.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("AddCustomLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Wat betekenen 'forward' en 'backward' voor een trendlijn?**

Het zijn de lengtes van de trendlijn die naar voren/achteren worden geprojecteerd: voor spreidings‑ (XY‑)grafieken — in as‑eenheden; voor niet‑spreidingsgrafieken — in aantal categorieën. Alleen niet‑negatieve waarden zijn toegestaan.

**Wordt de trendlijn behouden bij het exporteren van de presentatie naar PDF of SVG, of bij het renderen van een dia naar een afbeelding?**

Ja. Aspose.Slides zet presentaties om naar [PDF](/slides/nl/python-java/convert-powerpoint-to-pdf/) of [SVG](/slides/nl/python-java/render-a-slide-as-an-svg-image/) en rendert grafieken naar afbeeldingen; trendlijnen, als onderdeel van de grafiek, blijven behouden tijdens deze bewerkingen. Er is ook een methode beschikbaar om een afbeelding van de grafiek zelf [een afbeelding van de grafiek exporteren](/slides/nl/python-java/create-shape-thumbnails/).