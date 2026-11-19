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
description: "Skapa 3D-diagram i PowerPoint-presentationer med Aspose.Slides för Python via Java. Justera rotation, höjdförhållanden, diagramdjup och avstånd mellan serier med Python-exempel."
---
## **Översikt**

Aspose.Slides för Python via Java låter dig anpassa vyn av ett 3D‑diagram via metoden [Chart.getRotation3D](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getRotation3D). Detta artikel visar hur du justerar rotation, höjdförhållanden, djup, räta vinkel‑axlar och avstånd mellan serier, och sedan sparar presentationen i PPTX‑format.

## **Ställ in rotation och djup för ett 3D‑diagram**

Exemplet nedan skapar en [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) och använder [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) för att lägga till ett staplat 3D‑kolumndiagram på den första bilden. Det ersätter standardserierna och -kategorierna med två serier som innehåller tre värden vardera. Arbetsbladsindex `0` identifierar diagrammets första dataarbetsblad; rad `0` innehåller serienamnen och kolumn `0` innehåller kategorietiketter.

Metoderna [setRotationX](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationX) och [setRotationY](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationY) sätter diagrammets rotation till 40 respektive 270 grader. [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) anger dess djup till 150 % av dess bredd, medan [setRightAngleAxes](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRightAngleAxes) aktiverar räta vinkel‑axlar istället för perspektiv. Den resulterande presentationen innehåller det fyllda diagrammet med dessa 3D‑vyerinställningar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    values = [[20, 50, 30], [30, 10, 60]]

    for category_index in range(3):
        category_cell = workbook.getCell(worksheet_index, category_index + 1, 0, f"Category {category_index + 1}")
        chart.getChartData().getCategories().add(category_cell)

    for series_index in range(2):
        series_cell = workbook.getCell(worksheet_index, 0, series_index + 1, f"Series {series_index + 1}")
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())

        for category_index in range(3):
            value_cell = workbook.getCell(worksheet_index, category_index + 1, series_index + 1, jpype.JDouble(values[series_index][category_index]))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(270)
    chart.getRotation3D().setDepthPercents(150)

    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Justera höjdförhållandena för ett 3D‑diagram**

Använd [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) för att ange höjden på ett 3D‑diagram som en procentandel av dess bredd. Detta ändrar proportionerna i 3D‑scenen utan att ändra storleken på diagramobjektet på bilden.

Följande exempel skapar ett [Column3D](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) diagram med standarddata: tre serier och fyra kategorier. Det sparar tre presentationer med höjdförhållanden på 50 %, 100 % och 200 %. Diagrammets position, bredd och höjd förblir oförändrade. Data, rotation, djup, serievärdesavstånd och formatering är identiska i alla tre filerna; endast höjdpunktsprocenten ändras.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 460)
    chart.getRotation3D().setRotationX(jpype.JByte(20))
    chart.getRotation3D().setRotationY(30)
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setDepthPercents(100)
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150)

    for height_percent in [50, 100, 200]:
        chart.getRotation3D().setHeightPercents(height_percent)
        presentation.save(f"chart_height_{height_percent}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Följande bilder illustrerar samma höjdinställningar i motsvarande .NET‑exempel och exporterades med Microsoft PowerPoint. En mindre procentsats ger en plattare scen, medan en större procentsats ger en högre scen inom samma diagramobjekt. PowerPoint kan också justera axelintervall och etikettplacering för att passa scenen.

| Höjd: 50% | Höjd: 100% | Höjd: 200% |
| --- | --- | --- |
| ![3D‑kolumndiagram med höjden inställd på 50 % av dess bredd](height_percent_50.png) | ![3D‑kolumndiagram med höjden inställd på 100 % av dess bredd](height_percent_100.png) | ![3D‑kolumndiagram med höjden inställd på 200 % av dess bredd](height_percent_200.png) |

Dessa metoder styr olika aspekter av diagrammet:

| Metod | Effekt |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) | Höjden på 3D‑scenen som en procentandel av dess bredd. |
| [Chart.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHeight) | Höjden på diagramobjektet på bilden, i punkt. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | Djupet på 3D‑scenen som en procentandel av dess bredd. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | Avståndet mellan serier längs djupaxeln, som en procentandel av markörens bredd. |

Höjdinställningen påverkar 3D‑kolumn- och stapeldiagram, inklusive cylinder-, kon- och pyramidalvarianter, samt 3D‑linje-, yta-, paj- och ytdiagram. Jämförelsen ovan använder den verifierade `Column3D`‑typen. Inställningen förändrar inte utseendet på ett 2D‑`ClusteredColumn`‑diagram eller ett `BubbleWith3D`‑diagram; dessa namn är medlemmar i klassen [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/). För andra diagramutseendeinställningar, se [Chart Formatting](/slides/sv/python-java/chart-formatting/).

## **Justera avståndet mellan serier**

Använd [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) för att kontrollera avståndet mellan dataserier längs djupaxeln i ett 3D‑diagram, uttryckt som en procentandel av markörens bredd. Använd värden från **0 till 500**, inklusive: `0` tar bort avståndet, medan större värden ökar avståndet. Med ett fixerad diagramdjup gör ett ökat avstånd markörerna tunnare längs djupaxeln.

Få åtkomst till gruppen via [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup). Inställningen gäller för varje serie i den gruppen, inte bara för den serie som används för åtkomst. [ChartSeries.getGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getGapDepth) returnerar djupavståndet och reflekterar gruppens inställning.

Denna inställning påverkar 3D‑kolumn- och stapeldiagram, inklusive deras cylinder-, kon- och pyramidalvarianter, samt 3D‑linje- och områdesdiagram. Utseendet beror på om serierna är ordnade i djup, grupperade eller staplade. För en tydlig jämförelse av avstånd mellan separata serier, använd `ChartType.Column3D` från klassen [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/).

Dessa metoder styr olika aspekter av diagrammet:

| Metod | Effekt |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | Avståndet mellan serier längs djupaxeln, som en procentandel av markörens bredd. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) | Avståndet mellan intilliggande stapel‑ eller kolumnkluster, som en procentandel av stapelns eller kolumnens bredd. |
| [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | Diagrammets totala djup, som en procentandel av diagrammets bredd. |

Följande fristående exempel använder standarddiagramdata, som innehåller tre serier och fyra kategorier. Det sparar två presentationer med identisk data, rotation, avståndsbredd och diagramdjup; endast avståndsdjupet ändras.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 230)

    chart.getRotation3D().setRotationX(jpype.JByte(20))
    chart.getRotation3D().setRotationY(30)
    chart.getRotation3D().setDepthPercents(100)

    series = chart.getChartData().getSeries().get_Item(0)
    group = series.getParentSeriesGroup()
    group.setGapWidth(150)

    for gap_depth in [0, 500]:
        group.setGapDepth(gap_depth)

        file_name = f"series_gap_depth_{gap_depth}.pptx"
        presentation.save(file_name, SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Följande bilder illustrerar samma avståndsdjupinställningar i motsvarande .NET‑exempel och exporterades med Microsoft PowerPoint.

| Avståndsdjup: 0% | Avståndsdjup: 500% |
| --- | --- |
| ![3D‑kolumndiagram utan avstånd mellan serier längs djupaxeln](gap_depth_0.png) | ![3D‑kolumndiagram med ett 500 % avstånd mellan serier längs djupaxeln](gap_depth_500.png) |

## **Ändra 3D‑serietyp och stapelform**

I ett grupperat cylindriskt diagram börjar den första serien med en cylindrisk stapelform. Exemplet skriver ut heltalsvärdena som returneras av [ChartSeries.getType](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getType) och [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getBar3DShape) före och efter varje ändring. Tabellen visar de motsvarande konstantnamnen.

```python
import jpyle
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartShapeType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredCylinder, 20, 20, 500, 300)
    series = chart.getChartData().getSeries().get_Item(0)
    
    print(f"{series.getType()} | {series.getBar3DShape()}")

    series.setType(ChartType.ClusteredCone)
    print(f"{series.getType()} | {series.getBar3DShape()}")

    series.setBar3DShape(ChartShapeType.Box)
    print(f"{series.getType()} | {series.getBar3DShape()}")

    presentation.save("series_shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| Ändring av den första serien | Serietyp | Stapelform |
| --- | --- | --- |
| Skapa diagrammet | `ClusteredCylinder` | `Cylinder` |
| Ställ in serietypen till `ClusteredCone` | `ClusteredCone` | `Cone` |
| Ställ in stapelformen till `Box` | `ClusteredColumn3D` | `Box` |

Att ställa in formen till `Box` ändrar även serietypen till `ClusteredColumn3D`. Om din kod har villkor beroende på serietyp, anropa `series.getType()` efter att ha ändrat formen. ett värde som cachats före tilldelningen skulle fortfarande välja `ClusteredCone`‑grenen.

![PowerPoint‑jämförelse som visar den första serien som cylindrar, koner och rektangulära kolumner från vänster till höger](series-shapes.png)

## **FAQ**

**Vilka diagramtyper stödjer 3D‑läge i Aspose.Slides?**

Aspose.Slides stödjer 3D‑varianter av kolumndiagram, inklusive Column 3D, Clustered Column 3D, Stacked Column 3D och 100 % Stacked Column 3D, samt relaterade 3D‑typer som exponeras via klassen [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/). För en exakt, uppdaterad lista, kontrollera medlemmarna i [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) i API‑referensen för din installerade version.

**Kan jag få en rasterbild av ett 3D‑diagram för en rapport eller webb?**

Ja. Du kan exportera ett diagram till en bild med [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) eller [rendera hela bilden](/slides/sv/python-java/convert-powerpoint-to-png/) till format som PNG eller JPEG. Detta är användbart när du behöver en rasterförhandsgranskning eller vill bädda in diagrammet i dokument, instrumentpaneler eller webbsidor utan att behöva PowerPoint.

**Hur presterar byggandet och renderingen av stora 3D‑diagram?**

Prestanda beror på datavolym och visuellt komplexitet. För bästa resultat, håll 3D‑effekter till ett minimum, undvik tunga texturer på väggar och diagramområden, begränsa antalet datapunkter per serie när det är möjligt, och rendera till en lämplig stor output (upplösning och dimensioner) för att matcha måldisplayen eller utskriftsbehoven.