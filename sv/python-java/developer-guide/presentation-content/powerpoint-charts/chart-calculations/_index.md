---
title: Optimera diagramberäkningar för presentationer i Python via Java
linktitle: Diagramberäkningar
type: docs
weight: 50
url: /sv/python-java/chart-calculations/
keywords:
- diagramberäkningar
- diagramselement
- elementposition
- faktisk position
- underordnat element
- överordnat element
- diagramvärden
- faktiskt värde
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Förstå diagramberäkningar, datauppdateringar och precisionskontroll i Aspose.Slides för Python via Java för PPT och PPTX, med praktiska Python-kodexempel."
---
## **Översikt**

Aspose.Slides tillhandahåller API:er för att arbeta med diagramberäkningar och layoutdata i presentationer. Den här artikeln visar hur du hämtar de faktiska värdena för diagram‑element, inklusive den verkliga positionen och storleken på diagram‑element samt de faktiska värdena för diagramaxlar. Den förklarar också att dessa värden fylls i efter att diagramlayouten har validerats.

Dessutom demonstrerar artikeln hur du får den faktiska positionen för överordnade diagram‑element och hur du döljer diagramkomponenter såsom titel, axlar, förklaringsruta och rutnät. Tillsammans hjälper dessa exempel dig att inspektera diagramlayoutinformation och styra synligheten för diagram‑element i PowerPoint‑presentationer programmässigt.

## **Beräkna faktiska värden för diagram‑element**
Aspose.Slides for Python via Java tillhandahåller ett enkelt API för att hämta dessa egenskaper. Metoder i klassen [Axis](https://reference.aspose.com/slides/sv/python-java/aspose.slides/axis/) ger information om de faktiska värdena för diagramaxlar ([getActualMaxValue](https://reference.aspose.com/slides/sv/python-java/aspose.slides/axis/#getActualMaxValue), [getActualMinValue](https://reference.aspose.com/slides/sv/python-java/aspose.slides/axis/#getActualMinValue), [getActualMajorUnit](https://reference.aspose.com/slides/sv/python-java/aspose.slides/axis/#getActualMajorUnit), [getActualMinorUnit](https://reference.aspose.com/slides/sv/python-java/aspose.slides/axis/#getActualMinorUnit), [getActualMajorUnitScale](https://reference.aspose.com/slides/sv/python-java/aspose.slides/axis/#getActualMajorUnitScale), [getActualMinorUnitScale](https://reference.aspose.com/slides/sv/python-java/aspose.slides/axis/#getActualMinorUnitScale)). Anropa metoden [Chart.validateChartLayout](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chart/#validateChartLayout) först för att fylla dessa egenskaper med faktiska värden.

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

## **Beräkna faktisk position för överordnade diagram‑element**
Aspose.Slides for Python via Java tillhandahåller ett enkelt API för att hämta dessa egenskaper. Metoder i klassen [ChartPlotArea](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartplotarea/) ger information om den faktiska positionen och storleken på diagrammets ritområde ([getActualX](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartplotarea/#getActualX), [getActualY](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartplotarea/#getActualY), [getActualWidth](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartplotarea/#getActualWidth), [getActualHeight](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartplotarea/#getActualHeight)). Anropa metoden [Chart.validateChartLayout](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chart/#validateChartLayout) först för att fylla dessa egenskaper med faktiska värden.

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

## **Dölj diagram‑element**
Detta avsnitt förklarar hur du döljer information i ett diagram. Med Aspose.Slides for Python via Java kan du dölja **Titel, vertikal axel, horisontell axel** och **Rutnätslinjer**. Följande kodexempel visar hur du använder dessa egenskaper.

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

    # Dölj diagramtiteln.
    chart.setTitle(False)

    # Dölj värdeaxeln.
    chart.getAxes().getVerticalAxis().setVisible(False)

    # Dölj kategoriaxeln.
    chart.getAxes().getHorizontalAxis().setVisible(False)

    # Dölj förklaringen.
    chart.setLegend(False)

    # Dölj de stora rutnätslinjerna.
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    # Behåll endast den första serien. Borttagning från slutet behåller de återstående indexen giltiga.
    series_collection = chart.getChartData().getSeries()
    while series_collection.size() > 1:
        series_collection.removeAt(series_collection.size() - 1)

    series = series_collection.get_Item(0)

    series.getMarker().setSymbol(MarkerStyleType.Circle)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.Top)
    series.getMarker().setSize(15)

    # Ställ in serielinjens färg.
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA)
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid)

    presentation.save("HideInformationFromChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Vanliga frågor**

**Fungerar externa Excel‑arbetsböcker som datakälla, och hur påverkar det omberäkning?**

Ja. Ett diagram kan referera till en extern arbetsbok: när du ansluter eller uppdaterar den externa källan hämtas formler och värden från den arbetsboken, och diagrammet återspeglar uppdateringarna under öppnings‑/redigeringsoperationer. API‑et låter dig [ange den externa arbetsboken](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartdata/#setExternalWorkbook) sökväg och hantera den länkade datan.

**Kan jag beräkna och visa trendlinjer utan att implementera regression själv?**

Ja. [Trendlines](/slides/sv/python-java/trend-line/) (linjära, exponentiella och andra) läggs till och uppdateras av Aspose.Slides; deras parametrar beräknas om automatiskt från seriedatan, så du behöver inte implementera egna beräkningar.

**Om en presentation har flera diagram med externa länkar, kan jag styra vilken arbetsbok varje diagram använder för beräknade värden?**

Ja. Varje diagram kan peka på sin egen [externa arbetsbok](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartdata/#setExternalWorkbook), eller så kan du skapa/ersätta en extern arbetsbok per diagram oberoende av de andra.