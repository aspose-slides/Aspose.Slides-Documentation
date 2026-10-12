---
title: Hantera diagramdataetiketter i presentationer med Python
linktitle: Dataetikett
type: docs
url: /sv/python-java/chart-data-label/
keywords:
- diagram
- dataetikett
- dataprecision
- procent
- etikettavstånd
- etikettplacering
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Lär dig att lägga till och formatera diagramdataetiketter i PowerPoint-presentationer med Aspose.Slides för Python via Java för mer engagerande bilder."
---
## **Introduktion**

Dataetiketter visar information om diagramserier och enskilda datapunkter, vilket hjälper läsaren att identifiera värden och förstå diagrammet. Denna artikel förklarar hur man formaterar värden, visar procenttal, läser etiketttext, styr etiketter utanför axelns maximum, justerar avståndet mellan kategoriaxelns etiketter och placerar cirkeldiagramsetiketter.

## **Ange dataprecision i diagrammets dataetiketter**

Använd [setNumberFormatOfValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setNumberFormatOfValues) för att formatera serievärden. Detta exempel skapar ett linjediagram med standarddata, visar dess datatabell och aktiverar värdeetiketter för den första serien. Formatet `#,##0.00` visar ett tusentalsavgränsare och två decimaler utan att ändra de underliggande värdena.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300)
    chart.setDataTable(True)

    series = chart.getChartData().getSeries().get_Item(0)
    series.setNumberFormatOfValues("#,##0.00")
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Visa procent som etiketter**

För ett staplat stapeldiagram beräknas varje värde som en procentandel av sin kategorisumma och texten tilldelas den textram som returneras av [getTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getTextFrameForOverriding). Detta exempel använder diagrammets standarddata och visar procent med två decimaler i ett 8‑punkts typsnitt. Kategorier med en totalsumma på noll hoppas över för att undvika division med noll. Beräkna om den anpassade etiketttexten om diagramdata ändras.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Portion, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 400, 400)

    chart_series = chart.getChartData().getSeries()
    category_totals = [0.0] * chart.getChartData().getCategories().size()
    for category_index in range(len(category_totals)):
        for series_index in range(chart_series.size()):
            data_point = chart_series.get_Item(series_index).getDataPoints().get_Item(category_index)
            category_totals[category_index] += float(data_point.getValue().getData())

    for series_index in range(chart_series.size()):
        series = chart_series.get_Item(series_index)
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(False)

        for point_index in range(series.getDataPoints().size()):
            data_point = series.getDataPoints().get_Item(point_index)
            label = data_point.getLabel()
            if category_totals[point_index] == 0:
                print(f"Cannot calculate a percentage for category {point_index}: the total is zero.")
                continue
            point_percentage = float(data_point.getValue().getData()) / category_totals[point_index] * 100

            portion = Portion()
            portion.setText(f"{point_percentage:.2f} %")
            portion.getPortionFormat().setFontHeight(8)
            label.getTextFrameForOverriding().setText("")
            paragraph = label.getTextFrameForOverriding().getParagraphs().get_Item(0)
            paragraph.getPortions().add(portion)

            label_format = label.getDataLabelFormat()
            label_format.setShowValue(True)
            label_format.setShowSeriesName(False)
            label_format.setShowPercentage(False)
            label_format.setShowLegendKey(False)
            label_format.setShowCategoryName(False)
            label_format.setShowBubbleSize(False)

    presentation.save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ställ in procenttecken med diagrammets dataetiketter**

När värden lagras som bråk, använd [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormat) för att visa procenttal. Skicka `False` till [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) för att tillämpa etikettformatet oberoende av källcellerna.

Detta exempel skapar ett 100 % staplat stapeldiagram med röda och blå serier över fyra kategorier. Varje par av värden summeras till 1. Etikettformatet `0.0%` visar 0,30 som 30,0 %, medan den vertikala axeln använder två decimaler. Båda serierna använder vit etiketttext i 10 punkter.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400)

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%")

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    for i in range(4):
        category_cell = workbook.getCell(worksheet_index, i + 1, 0, f"Category {i + 1}")
        chart.getChartData().getCategories().add(category_cell)

    series_names = ["Reds", "Blues"]
    series_colors = [Color.RED, Color.BLUE]
    values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]]

    for i, series_name in enumerate(series_names):
        series_cell = workbook.getCell(worksheet_index, 0, i + 1, series_name)
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())
        for j, value in enumerate(values[i]):
            value_cell = workbook.getCell(worksheet_index, j + 1, i + 1, jpype.JDouble(value))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

        series.getFormat().getFill().setFillType(FillType.Solid)
        series.getFormat().getFill().getSolidFillColor().setColor(series_colors[i])

        label_format = series.getLabels().getDefaultDataLabelFormat()
        label_format.setShowValue(True)
        label_format.setNumberFormatLinkedToSource(False)
        label_format.setNumberFormat("0.0%")
        portion_format = label_format.getTextFormat().getPortionFormat()
        portion_format.setFontHeight(10)
        portion_format.getFillFormat().setFillType(FillType.Solid)
        portion_format.getFillFormat().getSolidFillColor().setColor(Color.WHITE)

    presentation.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Läs den faktiska texten för dataetiketter**

Använd [getActualLabelText](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getActualLabelText) för att hämta den text som produceras av en dataetiketts inställningar. Detta är användbart när man extraherar etiketter för rapporter, söker i presentationsinnehåll eller validerar genererade diagram. I exemplet nedan kombinerar standard [data label format](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/) varje kategorinamn, serienamn och värde. En punkt formaterar sitt värde som procent, och en annan använder anpassad text från [getTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getTextFrameForOverriding).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    first_category_cell = workbook.getCell(0, 1, 0, "Q1")
    chart.getChartData().getCategories().add(first_category_cell)
    second_category_cell = workbook.getCell(0, 2, 0, "Q2")
    chart.getChartData().getCategories().add(second_category_cell)

    north_series_cell = workbook.getCell(0, 0, 1, "North")
    north = chart.getChartData().getSeries().add(north_series_cell, chart.getType())
    north_first_value_cell = workbook.getCell(0, 1, 1, jpype.JDouble(0.25))
    north.getDataPoints().addDataPointForBarSeries(north_first_value_cell)
    north_second_value_cell = workbook.getCell(0, 2, 1, jpype.JDouble(0.75))
    north.getDataPoints().addDataPointForBarSeries(north_second_value_cell)

    south_series_cell = workbook.getCell(0, 0, 2, "South")
    south = chart.getChartData().getSeries().add(south_series_cell, chart.getType())
    south_first_value_cell = workbook.getCell(0, 1, 2, jpype.JDouble(0.40))
    south.getDataPoints().addDataPointForBarSeries(south_first_value_cell)
    south_second_value_cell = workbook.getCell(0, 2, 2, jpype.JDouble(0.60))
    south.getDataPoints().addDataPointForBarSeries(south_second_value_cell)

    for series in chart.getChartData().getSeries():
        label_format = series.getLabels().getDefaultDataLabelFormat()
        label_format.setShowCategoryName(True)
        label_format.setShowSeriesName(True)
        label_format.setShowValue(True)

    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormatLinkedToSource(False)
    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormat("0%")
    south.getLabels().get_Item(0).getTextFrameForOverriding().setText("Reviewed")

    for series in chart.getChartData().getSeries():
        for point in series.getDataPoints():
            label = point.getLabel()
            if not label.isVisible():
                continue

            print(f"Value: {point.getValue().getData()}; label: {label.getActualLabelText()}")
finally:
    presentation.dispose()
```

Det tal som lagras i en datapunkt förblir `0.75`, även när dess etikett visar `75 %` tillsammans med kategori- och serienamnen. Anpassad text ersätter den genererade etiketttexten. [getActualLabelText](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getActualLabelText) returnerar den resulterande etikettsträngen i båda fallen. Kontrollera [isVisible](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#isVisible) separat, som visas ovan, när du vill extrahera endast synliga etiketter.

## **Styr dataetiketter utanför axelns maximum**

När du begränsar ett axelintervall manuellt kan vissa datapunkter överskrida dess maximum. Använd [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setShowDataLabelsOverMaximum) för att styra om deras dataetiketter visas. Denna inställning ändrar etikettens synlighet; den ändrar inte axelintervallet eller de underliggande datapunkterna.

Exemplet nedan skapar ett 2D grupperat stapeldiagram med värdena 60 och 120. Det skickar `False` till [setAutomaticMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMaxValue) och sätter maximum till 100 med [setMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMaxValue) på den vertikala axeln. Den första bilden tillåter etiketter utanför maximum; en kopia av den bilden inaktiverar dem. Båda bilderna sparas i `DataLabelsOverMaximum.pptx`.

Aktivera värdeetiketter med [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue). Diagramnivåinställningen aktiverar inte värdevisning i sig själv eller åsidosätter en enskild etikett som har inaktiverad värdevisning. Detta exempel aktiverar värden för hela serien och använder [setPosition](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setPosition) för att placera etiketter på utsidan av varje stapel.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LegendDataLabelPosition, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setLegend(False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()

    first_category = workbook.getCell(0, 1, 0, "Within range")
    second_category = workbook.getCell(0, 2, 0, "Above maximum")

    chart.getChartData().getCategories().add(first_category)
    chart.getChartData().getCategories().add(second_category)

    series_name = workbook.getCell(0, 0, 1, "Values")
    series = chart.getChartData().getSeries().add(series_name, chart.getType())

    first_value = workbook.getCell(0, 1, 1, jpype.JDouble(60))
    second_value = workbook.getCell(0, 2, 1, jpype.JDouble(120))

    series.getDataPoints().addDataPointForBarSeries(first_value)
    series.getDataPoints().addDataPointForBarSeries(second_value)

    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd)

    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setMaxValue(100)
    chart.setShowDataLabelsOverMaximum(True)

    second_slide = presentation.getSlides().addClone(slide)
    second_chart = second_slide.getShapes().get_Item(0)
    second_chart.setShowDataLabelsOverMaximum(False)

    presentation.save("DataLabelsOverMaximum.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

```

Följande bilder visar de sparade bilderna renderade av Microsoft PowerPoint. Med `True` är etiketten **120** synlig vid den övre gränsen; med `False` är den dold. Etiketten **60** förblir synlig, axelmaximum förblir **100**, och den andra datapunkten förblir **120** i båda fallen.

| setShowDataLabelsOverMaximum(True) | setShowDataLabelsOverMaximum(False) |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Detta exempel använder ett 2D stapeldiagram med en värdeaxel. Diagram utan en värdeaxel, såsom cirkel- och donutdiagram, har inget axelmaximum att begränsa på detta sätt.
{{% /alert %}}

## **Ställ in etikettavstånd från en axel**

Använd [setLabelOffset](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLabelOffset) för att styra avståndet mellan kategoriaxelns etiketter och axeln. Värdet är en procentandel av den maximala teckenstorleken för axelns etiketter. Detta exempel skapar ett grupperat stapeldiagram och sätter den horisontella axelns etikettavstånd till 500. Denna inställning påverkar kategoriaxelns etiketter snarare än etiketter kopplade till enskilda datapunkter.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)
    chart.getAxes().getHorizontalAxis().setLabelOffset(500)

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Justera etikettplacering**

I ett cirkeldiagram justeras dataetikettens positioner för att förbättra avståndet och ge plats för förbindelselänkar.

Detta exempel visar värdet för den första datapunkten, placerar dess etikett utanför sektorn och justerar dess horisontella och vertikala offset med hjälp av [setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) och [setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY). Dessa offset är relativa till diagrammets bredd respektive höjd.

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LegendDataLabelPosition, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 200, 200)
    series = chart.getChartData().getSeries()
    
    label = series.get_Item(0).getLabels().get_Item(0)
    label.getDataLabelFormat().setShowValue(True)
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd)
    label.setX(0.71)
    label.setY(0.04)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Cirkeldiagram med en justerad dataetikettposition](pie-chart-adjusted-label.png)

## **Lägg till flera rader med dataetiketter ovanför ett stapeldiagram**

Detta exempel skapar ett stapeldiagram med två rader dataetiketter ovanför plotområdet. Serie A visar de synliga staplarna, medan Serie B och Serie C tillhandahåller de extra etiketterna. Deras staplar är dolda genom att ta bort fyllning och kontur. Metoden [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap) justerar alla tre serier med samma kategoricentra.

Inställningarna för [ChartPlotArea](https://reference.aspose.com/slides/python-java/aspose.slides/chartplotarea/) reserverar utrymme för etikettraderna. Efter att [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) beräknat standardpositionerna, bevarar [DataLabel.setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) och [DataLabel.setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY) den horisontella justeringen och applicerar vertikala offset för att ordna etiketterna i två rader. Siffrorna förblir dataetiketter kopplade till serievärdena; endast radrubrikerna är separata textformer.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LayoutTargetType, LegendDataLabelPosition, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 40, 40, 640, 200)
    chart.setTitle(False)
    chart.setLegend(False)
    chart.getTextFormat().getPortionFormat().setFontHeight(12)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    categories = ["North", "South", "East", "West"]
    series_names = ["Series A", "Series B", "Series C"]
    series_values = [[35, 42, 28, 47], [22, 31, 19, 26], [12, 16, 14, 18]]

    for category_index, category in enumerate(categories):
        category_cell = workbook.getCell(0, category_index + 1, 0, category)
        chart.getChartData().getCategories().add(category_cell)

    for series_index, series_name in enumerate(series_names):
        series_cell = workbook.getCell(0, 0, series_index + 1, series_name)
        series = chart.getChartData().getSeries().add(series_cell, ChartType.ClusteredColumn)

        for category_index, value in enumerate(series_values[series_index]):
            value_cell = workbook.getCell(0, category_index + 1, series_index + 1, jpype.JDouble(value))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

        if series_index > 0:
            # Dölj kolumnerna för B och C, men behåll deras dataetiketter.
            series.getFormat().getFill().setFillType(FillType.NoFill)
            series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
            label_format = series.getLabels().getDefaultDataLabelFormat()
            label_format.setShowValue(True)
            label_format.getTextFormat().getPortionFormat().setFontHeight(12)
            label_fill = label_format.getTextFormat().getPortionFormat().getFillFormat()
            label_fill.setFillType(FillType.Solid)
            label_fill.getSolidFillColor().setColor(Color.BLACK)
            label_format.setPosition(LegendDataLabelPosition.InsideBase)

    # Rikta in alla tre serier med samma kategoricentra.
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setOverlap(jpype.JByte(100))

    # Använd färre referenslinjer i detta kompakta exempel.
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setMajorUnit(10)

    # Reservera utrymme ovanför diagrammet för två rader med dataetiketter.
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner)
    chart.getPlotArea().setX(0.15)
    chart.getPlotArea().setY(0.32)
    chart.getPlotArea().setWidth(0.80)
    chart.getPlotArea().setHeight(0.48)
    chart.validateChartLayout()

    for series_index in range(1, len(series_names)):
        series = chart.getChartData().getSeries().get_Item(series_index)
        row_top = 0.15 if series_index == 1 else 0.03

        for category_index in range(len(categories)):
            data_label = series.getDataPoints().get_Item(category_index).getLabel()
            # Behåll standard horisontell position. Y är ett avstånd från
            # den standardetikettpositionen, uttryckt som en andel av diagramhöjden.
            data_label.setX(0)
            data_label.setY(row_top - data_label.getActualY() / chart.getHeight())

        # Endast radrubriken är en separat textform.
        heading_y = chart.getY() + row_top * chart.getHeight()
        row_heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, chart.getX(), heading_y, 85, 18)
        row_heading.getFillFormat().setFillType(FillType.NoFill)
        row_heading.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        row_heading.addTextFrame(series_names[series_index])
        row_heading.getTextFrame().getTextFrameFormat().setMarginTop(0)
        row_heading.getTextFrame().getTextFrameFormat().setMarginBottom(0)
        heading_format = row_heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
        heading_format.setFontHeight(12)
        heading_format.getFillFormat().setFillType(FillType.Solid)
        heading_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    presentation.save("multiple-rows-of-labels.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Stapeldiagram med två rader dataetiketter ovanför plotområdet](multiple-rows-of-labels.png)

## **FAQ**

**Hur kan jag förhindra att dataetiketter överlappar i täta diagram?**

Kombinera automatisk placering av etiketter, förbindelselänkar och minskad teckenstorlek; om nödvändigt, dölj vissa fält (t.ex. kategorin) eller visa etiketter endast för extrema värden eller nyckelpunkter.

**Hur kan jag inaktivera etiketter endast för noll, negativa eller tomma värden?**

Filtrera datapunkter innan etiketter aktiveras och stäng av visning för värden på 0, negativa värden eller saknade värden enligt en definierad regel.

**Hur kan jag säkerställa en enhetlig etikettstil vid export till PDF/bilder?**

Ange explicit teckensnittsfamilj och storlek och verifiera att teckensnittet är tillgängligt i renderingsmiljön för att undvika fallback.