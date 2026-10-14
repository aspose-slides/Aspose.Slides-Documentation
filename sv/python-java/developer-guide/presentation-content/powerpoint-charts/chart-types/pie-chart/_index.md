---
title: Anpassa cirkeldiagram i presentationer med Python via Java
linktitle: Cirkeldiagram
type: docs
url: /sv/python-java/pie-chart/
keywords:
- cirkeldiagram
- hantera diagram
- anpassa diagram
- diagramalternativ
- diagraminställningar
- plotalternativ
- segmentfärg
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Skapa och anpassa cirkeldiagram i Python via Java med Aspose.Slides. Konfigurera sekundära plottar, visa dataetiketter och tillämpa automatiska segmentfärger i PowerPoint."
---
## **Översikt**

Den här artikeln förklarar hur man arbetar med cirkeldiagram i Aspose.Slides. Den visar hur man konfigurerar sekundära plot‑alternativ för Pie of Pie- och Bar of Pie-diagram, samt hur man aktiverar automatisk färgläggning av segment för ett standardcirkeldiagram.

Exemplen fokuserar på uppgifter för anpassning av diagram, såsom att lägga till ett diagram på en bild, justera serier och etikettinställningar, ersätta standarddiagramdata med egna kategorier och värden samt spara den uppdaterade presentationen.

## **Alternativ för sekundär plot för Pie of Pie- och Bar of Pie-diagram**

Aspose.Slides för Python via Java stöder alternativ för sekundär plot för Pie of Pie- och Bar of Pie-diagram. Dessa alternativ styr storleken på den sekundära plotten och hur datapunkter fördelas mellan de två plotterna.

Det följande exemplet skapar ett Pie of Pie-diagram i en ny presentation och visar datapunktvärden som etiketter. Metoden [setSecondPieSize](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setSecondPieSize) sätter storleken på den sekundära plotten till 149 % av huvudplotten. [setPieSplitBy](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitBy) väljer procentbaserad delning, och [setPieSplitPosition](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) sätter tröskeln till 53 %.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400)
    series = chart.getChartData().getSeries().get_Item(0)

    # Visa värden och konfigurera den sekundära plotten.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setSecondPieSize(149)
    series_group.setPieSplitBy(PieSplitType.ByPercentage)
    series_group.setPieSplitPosition(53)

    presentation.save("pie_of_pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Välj kategorier för den sekundära plotten**

Använd anpassad delning när du vill gruppera specifika kategorier i den sekundära plotten oavsett deras procentvärden. Till exempel kan en försäljningsrapport visa Online och Events tillsammans så att läsarna kan jämföra dessa två kanaler, även om de utgör 35 % respektive 10 % av den totala försäljningen.

Anropa [setPieSplitBy](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitBy) med [PieSplitType.Custom](https://reference.aspose.com/slides/python-java/aspose.slides/piesplittype/#Custom) och välj punkterna via [getPieSplitCustomPoints](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints). Metodens [add](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#add) i samlingen accepterar ett nollbaserat index i serien; använd [addItem](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#addItem) för att lägga till ett datapunktobjekt. I detta exempel väljer index 1 Online, och punkten på index 3 väljer Events. Partners läggs också till tillfälligt och exkluderas sedan med [removeItem](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#removeItem).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpole.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 200)

    # Ersätt standarddata med försäljning per kanal.
    workbook = chart.getChartData().getChartDataWorkbook()
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    category_names = ["Retail", "Online", "Partners", "Events"]
    values = [40, 35, 15, 10]
    series_name_cell = workbook.getCell(0, 0, 1, "Sales")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    for i in range(len(category_names)):
        category_cell = workbook.getCell(0, i + 1, 0, category_names[i])
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, jpype.JInt(values[i]))
        series.getDataPoints().addDataPointForPieSeries(value_cell)

    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setPieSplitBy(PieSplitType.Custom)
    series_group.setColorVaried(True)

    # Välj Online med dess nollbaserade index och Events med dess datapunktobjekt.
    series_group.getPieSplitCustomPoints().add(1)
    series_group.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3))

    # Uteslut Partners från urvalet utan att ta bort dess källdata.
    series_group.getPieSplitCustomPoints().add(2)
    series_group.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2))

    presentation.save("pie_of_pie_custom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Online (35) och Events (10) visas som separata segment i den sekundära plotten. I den primära plotten representeras de av ett sammanslaget segment med ett värde på 45, tillsammans med Retail (40) och Partners (15). Att ta bort Partners från den anpassade urvalet behåller det i den primära plotten; det tar inte bort kategorin eller dess värde från diagrammets källdata.

Följande bild visar den sparade presentationen i PowerPoint:

![Pie of Pie-diagram med Online och Events i den sekundära plotten och deras kombinerade värde på 45 i den primära plotten](pie_of_pie_custom.png)

## **Ställ in automatisk färgläggning av cirkeldiagramssegment**

Aspose.Slides för Python via Java kan automatiskt tilldela olika färger till cirkeldiagramssegment. Det följande exemplet skapar ett cirkeldiagram med en centrerad titel och ersätter standarddata med tre kvartalskategorier och deras värden. Metoden [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) visar värdena 20, 50 och 30 som etiketter, medan [setColorVaried](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setColorVaried) möjliggör en distinkt färg för varje segment.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # Lägg till en centrerad diagramrubrik.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # Ersätt standarddata med det första kalkylbladet.
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    category_names = ["First Qtr", "2nd Qtr", "3rd Qtr"]
    values = [20, 50, 30]
    series_name_cell = workbook.getCell(worksheet_index, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    for i in range(len(category_names)):
        category_cell = workbook.getCell(worksheet_index, i + 1, 0, category_names[i])
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(worksheet_index, i + 1, 1, jpype.JInt(values[i]))
        series.getDataPoints().addDataPointForPieSeries(value_cell)

    # Visa värden och tilldela olika färger till segmenten.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getParentSeriesGroup().setColorVaried(True)

    presentation.save("pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Vanliga frågor**

**Stöds Pie of Pie- och Bar of Pie-varianterna?**

Ja, biblioteket [stöder](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) en sekundär plot för cirkeldiagram, inklusive typerna Pie of Pie och Bar of Pie.

**Kan jag exportera bara diagrammet som en bild (till exempel PNG)?**

Ja, du kan [exportera diagrammet som en bild](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) (till exempel PNG) utan att exportera hela presentationen.