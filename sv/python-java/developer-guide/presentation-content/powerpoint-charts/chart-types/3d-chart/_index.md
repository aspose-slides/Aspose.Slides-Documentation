---
title: Anpassa 3D-diagram i presentationer med Python
linktitle: 3D-diagram
type: docs
url: /sv/python-java/3d-chart/
keywords:
- 3D-diagram
- rotation
- djup
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Lär dig hur du skapar och anpassar 3D-diagram i Aspose.Slides för Python via Java, med stöd för PPT- och PPTX-filer—förbättra dina presentationer idag."
---
## **Översikt**

Den här artikeln förklarar hur du anpassar ett 3D-diagram i Aspose.Slides genom att konfigurera [Rotation3D](https://reference.aspose.com/slides/sv/python-java/aspose.slides/rotation3d/) inställningar såsom [setRotationX](https://reference.aspose.com/slides/sv/python-java/aspose.slides/rotation3d/#setRotationX), [setRotationY](https://reference.aspose.com/slides/sv/python-java/aspose.slides/rotation3d/#setRotationY), [setDepthPercents](https://reference.aspose.com/slides/sv/python-java/aspose.slides/rotation3d/#setDepthPercents), och [setRightAngleAxes](https://reference.aspose.com/slides/sv/python-java/aspose.slides/rotation3d/#setRightAngleAxes). Den går igenom hur du skapar en presentation, lägger till ett 3D-diagram med standarddata, tillämpar de nödvändiga 3D‑visningsinställningarna och sparar den modifierade presentationen som en PPTX‑fil.

## **Ställ in X-rotation, Y-rotation och djup för ett 3D-diagram**
Aspose.Slides för Python via Java erbjuder ett enkelt API för att ställa in dessa egenskaper. Följande exempel visar hur du sätter X‑rotation, Y‑rotation och djup för ett 3D-diagram.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) .
1. Få åtkomst till den första bilden.
1. Lägg till ett diagram med standarddata.
1. Ställ in 3D‑rotationsinställningarna.
1. Skriv den modifierade presentationen till en PPTX‑fil.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    # Hämta den första bilden.
    slide = presentation.getSlides().get_Item(0)

    # Lägg till ett diagram med standarddata.
    chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500)

    # Ställ in kalkylbladets index för diagramdata.
    default_worksheet_index = 0

    # Hämta arbetsboken för diagramdata.
    workbook = chart.getChartData().getChartDataWorkbook()

    # Lägg till serier.
    series_cell = workbook.getCell(default_worksheet_index, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(series_cell, chart.getType())
    series_cell = workbook.getCell(default_worksheet_index, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(series_cell, chart.getType())

    # Lägg till kategorier.
    category_cell = workbook.getCell(default_worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(default_worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(default_worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(category_cell)

    # Ställ in 3D-rotationsegenskaperna.
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(270)
    chart.getRotation3D().setDepthPercents(150)

    # Hämta den andra diagramserien.
    series = chart.getChartData().getSeries().get_Item(1)

    # Fyll i serie‑data.
    data_cell = workbook.getCell(default_worksheet_index, 1, 1, jpype.JInt(20))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 2, 1, jpype.JInt(50))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 3, 1, jpype.JInt(30))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 1, 2, jpype.JInt(30))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 2, 2, jpype.JInt(10))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 3, 2, jpype.JInt(60))
    series.getDataPoints().addDataPointForBarSeries(data_cell)

    # Spara presentationen.
    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Vanliga frågor**

**Vilka diagramtyper stöder 3D-läge i Aspose.Slides?**

Aspose.Slides stödjer 3D‑varianter av stapeldiagram, inklusive Column 3D, Clustered Column 3D, Stacked Column 3D och 100 % Stacked Column 3D, tillsammans med relaterade 3D‑typer som exponeras via klassen [ChartType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/charttype/). För en exakt, uppdaterad lista, kontrollera medlemmarna i [ChartType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/charttype/) i API‑referensen för din installerade version.

**Kan jag få en rasterbild av ett 3D-diagram för en rapport eller webben?**

Ja. Du kan exportera ett diagram till en bild via [chart API](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getImage) eller [render the entire slide](/slides/sv/python-java/convert-powerpoint-to-png/) till format som PNG eller JPEG. Detta är användbart när du behöver en pixelperfekt förhandsgranskning eller vill bädda in diagrammet i dokument, instrumentpaneler eller webbsidor utan att kräva PowerPoint.

**Hur presterande är det att bygga och rendera stora 3D-diagram?**

Prestanda beror på datavolym och visuell komplexitet. För bästa resultat, håll 3D‑effekter minimala, undvik tunga texturer på väggar och plotområden, begränsa antalet datapunkter per serie när det är möjligt, och rendera till en lämpligt stor utskrift (upplösning och dimensioner) för att matcha målskärmen eller utskriftsbehoven.