---
title: Lägg till trendlinjer i presentationsdiagram i Python
linktitle: Trendlinje
type: docs
url: /sv/python-java/trend-line/
keywords:
- diagram
- trendlinje
- exponentiell trendlinje
- linjär trendlinje
- logaritmisk trendlinje
- glidande medelvärdestrendlinje
- polynomtrendlinje
- potenstrendlinje
- anpassad trendlinje
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Lägg snabbt till och anpassa trendlinjer i PowerPoint-diagram med Aspose.Slides för Python via Java — en praktisk guide för att engagera din publik."
---
## **Översikt**

Denna artikel förklarar hur man lägger till trendlinjer i presentationsdiagram med hjälp av Aspose.Slides. Den visar hur man skapar ett diagram, lägger till trendlinjer i diagramserier och arbetar med flera typer av trendlinjer, inklusive exponentiell, linjär, logaritmisk, glidande medelvärde, polynom och potens.

Den beskriver också hur man lägger till en anpassad linje i ett diagram genom att infoga en linjeform, och innehåller en kort FAQ om framåt- och bakåtriktade trendlinjprojektioner samt om trendlinjer bevaras vid export till PDF eller SVG och vid rendering av diagram som bilder.

## **Lägg till en trendlinje**

Aspose.Slides for Python via Java tillhandahåller ett enkelt API för att hantera olika diagramtrendlinjer:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
2. Hämta en referens till en bild genom dess index.
3. Lägg till ett diagram med standarddata och önskad typ (detta exempel använder [ChartType.ClusteredColumn](https://reference.aspose.com/slides/sv/python-java/aspose.slides/charttype/#ClusteredColumn)).
4. Lägg till en exponentiell trendlinje till diagramserie 1.
5. Lägg till en linjär trendlinje till diagramserie 1.
6. Lägg till en logaritmisk trendlinje till diagramserie 2.
7. Lägg till en glidande medelvärdestrendlinje till diagramserie 2.
8. Lägg till en polynomtrendlinje till diagramserie 3.
9. Lägg till en potenstrendlinje till diagramserie 3.
10. Skriv den ändrade presentationen till en PPTX‑fil.

Följande kod skapar ett diagram med trendlinjer.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, TrendlineType
from java.awt import Color

# Skapa en instans av Presentation-klassen.
presentation = Presentation()
try:
    # Skapa ett gruppade kolumndiagram.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400)

    # Lägg till en exponentiell trendlinje till diagramserie 1.
    exponential_trend_line = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential)
    exponential_trend_line.setDisplayEquation(False)
    exponential_trend_line.setDisplayRSquaredValue(False)

    # Lägg till en linjär trendlinje till diagramserie 1.
    linear_trend_line = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear)
    linear_trend_line.setTrendlineType(TrendlineType.Linear)
    linear_trend_line.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    linear_trend_line.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)

    # Lägg till en logaritmisk trendlinje till diagramserie 2.
    logarithmic_trend_line = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic)
    logarithmic_trend_line.setTrendlineType(TrendlineType.Logarithmic)
    logarithmic_trend_line.addTextFrameForOverriding("New log trend line")

    # Lägg till en glidande medelvärdestrendlinje till diagramserie 2.
    moving_average_trend_line = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage)
    moving_average_trend_line.setTrendlineType(TrendlineType.MovingAverage)
    moving_average_trend_line.setPeriod(jpype.JByte(3))
    moving_average_trend_line.setTrendlineName("New TrendLine Name")

    # Lägg till en polynomtrendlinje till diagramserie 3.
    polynomial_trend_line = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial)
    polynomial_trend_line.setTrendlineType(TrendlineType.Polynomial)
    polynomial_trend_line.setForward(1)
    polynomial_trend_line.setOrder(jpype.JByte(3))

    # Lägg till en potenstrendlinje till diagramserie 3.
    power_trend_line = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Power)
    power_trend_line.setTrendlineType(TrendlineType.Power)
    power_trend_line.setBackward(1)

    # Spara presentationen.
    presentation.save("ChartTrendLines_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Lägg till en anpassad linje**

Aspose.Slides for Python via Java tillhandahåller ett enkelt API för att lägga till anpassade linjer i ett diagram. För att lägga till en enkel linje i ett diagram på en vald bild, följ dessa steg:

- Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
- Hämta en referens till en bild genom dess index.
- Skapa ett nytt diagram med metoden [addChart](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapecollection/#addChart) i klassen [ShapeCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapecollection/).
- Lägg till en linjeform med metoden [addAutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapecollection/#addAutoShape) med [ShapeType.Line](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapetype/#Line).
- Ange färgen på formens linje.
- Skriv den ändrade presentationen till en PPTX‑fil.

Följande kod skapar ett diagram med en anpassad linje.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Skapa en instans av Presentation-klassen.
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

**Vad betyder 'forward' och 'backward' för en trendlinje?**

De är längderna på trendlinjen som projiceras framåt eller bakåt: för spridningsdiagram (XY) mäts de i axelenheter; för icke‑spridningsdiagram mäts de i antalet kategorier. Endast icke‑negativa värden är tillåtna.

**Kommer trendlinjen att bevaras när presentationen exporteras till PDF eller SVG, eller när en bild renderas till en bild?**

Ja. Aspose.Slides konverterar presentationer till [PDF](/slides/sv/python-java/convert-powerpoint-to-pdf/)/[SVG](/slides/sv/python-java/render-a-slide-as-an-svg-image/) och renderar diagram till bilder; trendlinjer, som en del av diagrammet, bevaras under dessa operationer. En metod finns också för att [exportera en bild av diagrammet](/slides/sv/python-java/create-shape-thumbnails/) själva.