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
description: "Lär dig hur du skapar och anpassar cirkeldiagram i Python via Java med Aspose.Slides, exporteras till PowerPoint, och förbättrar din datapresentation på sekunder."
---
## **Översikt**

Denna artikel förklarar hur man arbetar med cirkeldiagram i Aspose.Slides. Den visar hur man konfigurerar sekundära plot‑alternativ för Pie of Pie‑ och Bar of Pie‑diagram, samt hur man aktiverar automatisk färgläggning av segment för ett standardcirkeldiagram.

Exemplen fokuserar på praktiska steg för anpassning av diagram, såsom att lägga till ett diagram på en bild, justera serie‑ och etikettinställningar, ersätta standarddiagramdata med egna kategorier och värden, samt spara den uppdaterade presentationen.

## **Sekundära plot‑alternativ för Pie of Pie‑ och Bar of Pie‑diagram**

Aspose.Slides för Python via Java stöder sekundära plot‑alternativ för Pie of Pie‑ och Bar of Pie‑diagram. Det här avsnittet visar hur man specificerar dessa alternativ med Aspose.Slides. Följ dessa steg:

1. Instansiera ett [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/)-objekt.
1. Lägg till ett diagram på bilden.
1. Specificera diagrammets sekundära plot‑alternativ.
1. Skriv presentationen till disk.

Följande exempel ställer in olika egenskaper för ett Pie of Pie-diagram.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

    # Skapa en instans av Presentation-klassen.
presentation = Presentation()
try:
    # Lägg till ett diagram på bilden.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400)

    # Ställ in olika egenskaper.
    series = chart.getChartData().getSeries().get_Item(0)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setSecondPieSize(149)
    series_group.setPieSplitBy(PieSplitType.ByPercentage)
    series_group.setPieSplitPosition(53)

    # Spara presentationen till disk.
    presentation.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ställ in automatisk färgläggning av cirkeldiagramsegment**

Aspose.Slides för Python via Java tillhandahåller ett enkelt API för att ställa in automatisk färgläggning av cirkeldiagramsegment. Följande exempel visar hur dessa inställningar tillämpas.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
1. Hämta den första bilden.
1. Lägg till ett diagram med standarddata.
1. Ange diagramrubriken.
1. Ställ in indexet för diagrammets datakalkylblad.
1. Hämta diagrammets dataarbetsbok.
1. Ta bort standardserierna och -kategorierna.
1. Lägg till nya kategorier.
1. Lägg till en ny serie.
1. Ställ in den nya serien för att visa värden.

Skriv den modifierade presentationen till en PPTX‑fil.

```python
import jpage
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

# Skapa en instans av Presentation-klassen.
presentation = Presentation()
try:
    # Lägg till ett diagram med standarddata.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # Ställ in diagramtiteln.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # Ställ in indexet för diagrammets datakalkylblad.
    default_worksheet_index = 0

    # Hämta diagrammets dataarbetsbok.
    workbook = chart.getChartData().getChartDataWorkbook()

    # Ta bort standardserierna och -kategorierna.
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # Lägg till nya kategorier.
    first_category_cell = workbook.getCell(0, 1, 0, "First Qtr")
    chart.getChartData().getCategories().add(first_category_cell)
    second_category_cell = workbook.getCell(0, 2, 0, "2nd Qtr")
    chart.getChartData().getCategories().add(second_category_cell)
    third_category_cell = workbook.getCell(0, 3, 0, "3rd Qtr")
    chart.getChartData().getCategories().add(third_category_cell)

    # Lägg till en ny serie.
    series_cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_cell, chart.getType())

    # Fyll i seriedata.
    first_value_cell = workbook.getCell(default_worksheet_index, 1, 1, jpype.JInt(20))
    series.getDataPoints().addDataPointForPieSeries(first_value_cell)
    second_value_cell = workbook.getCell(default_worksheet_index, 2, 1, jpype.JInt(50))
    series.getDataPoints().addDataPointForPieSeries(second_value_cell)
    third_value_cell = workbook.getCell(default_worksheet_index, 3, 1, jpype.JInt(30))
    series.getDataPoints().addDataPointForPieSeries(third_value_cell)

    # Ställ in den nya serien för att visa värden.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    series.getParentSeriesGroup().setColorVaried(True)
    presentation.save("Pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Stöds varianterna 'Pie of Pie' och 'Bar of Pie'?**

Ja, biblioteket [stödjer](https://reference.aspose.com/slides/sv/python-java/aspose.slides/charttype/) ett sekundärt plot för cirkeldiagram, inklusive typerna 'Pie of Pie' och 'Bar of Pie'.

**Kan jag exportera endast diagrammet som en bild (t.ex. PNG)?**

Ja, du kan [exportera själva diagrammet som en bild](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getImage) (t.ex. PNG) utan hela presentationen.