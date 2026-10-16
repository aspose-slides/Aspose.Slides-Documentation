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
- trendlinje för glidande medelvärde
- polynomisk trendlinje
- potens trendlinje
- anpassad trendlinje
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Lägg snabbt till och anpassa trendlinjer i PowerPoint-diagram med Aspose.Slides för Python via Java — en praktisk guide för att engagera din publik."
---
## **Översikt**

Den här artikeln förklarar hur du lägger till trendlinjer i presentationsdiagram med hjälp av Aspose.Slides. Den visar hur du skapar ett diagram, lägger till trendlinjer i diagramserier och arbetar med flera trendlinjetyper, inklusive exponentiell, linjär, logaritmisk, glidande medelvärde, polynomisk och potens.

Den beskriver också hur du lägger till en anpassad linje i ett diagram genom att infoga en linjeform, och innehåller en kort FAQ om framåt‑ och bakåtriktade trendlinjeprojektioner samt huruvida trendlinjer bevaras vid export till PDF eller SVG och vid rendering av diagram som bilder.

## **Lägg till en trendlinje**

Använd [TrendlineCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/trendlinecollection/#add) för att lägga till en trendlinje i en diagramserie, och välj dess typ med [TrendlineType](https://reference.aspose.com/slides/python-java/aspose.slides/trendlinetype/). Exemplet skapar ett grupperat stapeldiagram med standarddata och lägger till två trendlinjer för var och en av dess tre serier.

Den exponentiella trendlinjen döljer sin ekvation och R‑kvadrat‑värde via [setDisplayEquation](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setDisplayEquation) och [setDisplayRSquaredValue](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setDisplayRSquaredValue), medan den linjära trendlinjen är röd. Den logaritmiska trendlinjen använder [addTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#addTextFrameForOverriding) för en anpassad etikett. Glidande medelvärde använder en [setPeriod](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setPeriod) på tre datapunkter och en anpassad [setTrendlineName](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setTrendlineName).

Den polynomiska trendlinjen har en ordning på tre, inställd via [setOrder](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setOrder) och sträcker sig en kategori framåt via [setForward](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setForward). Potens‑trendlinjen sträcker sig en kategori bakåt via [setBackward](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setBackward).

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

## **Ange ett intercept för en trendlinje**

Använd [setIntercept](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setIntercept) för att låsa en trendlinjes Y‑värde vid X = 0. Denna inställning stöds för linjära, exponentiella och polynomiska trendlinjer.

Till exempel kan en produktionskostnadsmodell behöva starta med kända fasta kostnader på 100, även när mätningar vid icke‑noll produktionsvolymer tyder på ett annat grundvärde. För en linjär trendlinje begränsar fixering av intercept ekvationen `y = ax + b` till `b = 100`; lutningen anpassas till data under den begränsningen. Det flyttar inte bara en redan anpassad linje. Inställningar för axelöverskridning styr var diagramaxlarna möts, inte koefficienterna för den anpassade trendlinjen.

Följande exempel skapar ett spridnings‑ (XY‑)diagram med produktionsvolymer från 1 till 4 och kostnader på 170, 200, 230 och 260. Det sparar diagrammet med standardinställning för automatiskt intercept, sätter interceptet till 100 och sparar en andra PPTX. De två filerna skiljer sig endast i intercept‑inställningen. Trendlinjen visar sin ekvation och sträcker sig tillbaka till X = 0.

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

Med automatisk beräkning ger dessa data `y = 30x + 140`. Att sätta interceptet till 100 i stället ger ungefär `y = 43.33x + 100`: det anpassade värdet vid noll matchar det kända grundvärdet, medan linjen inte längre går igenom varje datapunkt.

| Automatiskt intercept | Fast intercept på 100 |
| --- | --- |
| ![Linjär trendlinje med ett automatiskt beräknat intercept på 140](intercept-automatic.png) | ![Linjär trendlinje med ett fast intercept på 100](intercept-fixed.png) |

Båda bilderna använder samma data och axelskala. Trendlinjerna sträcks tillbaka till X = 0 för att visa sina intercept.

Som standard returnerar [getIntercept](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#getIntercept) `NaN`, vilket representerar ett ospecificerat intercept snarare än noll. Interceptet beräknas då automatiskt från data.

## **Lägg till en anpassad linje**

En anpassad linje är en form som ritas ovanpå diagrammet snarare än en trendlinje beräknad från seriedata. Detta exempel använder [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAutoShape) för att lägga till en horisontell linje på bilden ovanför diagrammet. Linjens position anges i bildkoordinater, mätt i punkter, så den startar vid diagrammets vänstra kant och ligger halvvägs ner i diagrammet. Dess bredd matchar diagrammets bredd. Metoden [getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) ger åtkomst till linjeformatet som används för att applicera en solid röd färg.

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

## **Vanliga frågor**

**Vad betyder 'forward' och 'backward' för en trendlinje?**

Det är längderna på trendlinjen som projiceras framåt/bakåt: för spridnings‑ (XY‑)diagram — i enhetsmått för axlarna; för icke‑spridningsdiagram — i antal kategorier. Endast icke‑negativa värden är tillåtna.

**Kommer trendlinjen att bevaras vid export av presentationen till PDF eller SVG, eller när en bild renderas till en bild?**

Ja. Aspose.Slides konverterar presentationer till [PDF](/slides/sv/python-java/convert-powerpoint-to-pdf/) eller [SVG](/slides/sv/python-java/render-a-slide-as-an-svg-image/) och renderar diagram till bilder; trendlinjer, som en del av diagrammet, bevaras under dessa operationer. En metod finns också för att [exportera en bild av diagrammet](/slides/sv/python-java/create-shape-thumbnails/) självt.