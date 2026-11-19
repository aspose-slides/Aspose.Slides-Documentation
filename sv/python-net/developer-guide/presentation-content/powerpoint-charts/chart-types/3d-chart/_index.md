---
title: Anpassa 3D-diagram i presentationer med Python
linktitle: 3D-diagram
type: docs
url: /sv/python-net/3d-chart/
keywords:
- 3D-diagram
- rotation
- djup
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Skapa 3D-diagram i PowerPoint-presentationer med Aspose.Slides för Python via .NET. Justera rotation, höjdförhållanden, diagramdjup och avstånd mellan serier med Python‑exempel."
---
## **Översikt**

Aspose.Slides för Python via .NET låter dig anpassa visningen av ett 3D-diagram via egenskapen [Chart.rotation_3d](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/rotation_3d/) . Denna artikel visar hur du justerar rotation, höjdförhållanden, djup, vinkelräta axlar och avstånd mellan serier, och sedan sparar presentationen i PPTX-format.

## **Ställ in rotation och djup för ett 3D-diagram**

Exemplet nedan skapar en [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) och använder [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) för att lägga till ett staplat 3D-kolumndiagram på dess första bildspel. Det ersätter standardserierna och -kategorierna med två serier som innehåller tre värden vardera. Arbetsbladsindex `0` identifierar diagrammets första datakalkylblad; rad `0` innehåller serienamn, och kolumn `0` innehåller kategorietiketter.

[rotation_x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_x/) och [rotation_y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_y/) egenskaperna ställer in diagrammets rotation till 40 respektive 270 grader. [depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) sätter dess djup till 150 % av dess bredd, medan [right_angle_axes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/right_angle_axes/) möjliggör vinkelräta axlar istället för perspektiv. Den resulterande presentationen innehåller det ifyllda diagrammet med dessa 3D-vyinställningar.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    
    values = [[20, 50, 30], [30, 10, 60]]

    for category_index in range(3):
        category_cell = workbook.get_cell(worksheet_index, category_index + 1, 0, f"Category {category_index + 1}")
        chart.chart_data.categories.add(category_cell)

    for series_index in range(2):
        series_cell = workbook.get_cell(worksheet_index, 0, series_index + 1, f"Series {series_index + 1}")
        series = chart.chart_data.series.add(series_cell, chart.type)

        for category_index in range(3):
            value_cell = workbook.get_cell(worksheet_index, category_index + 1, series_index + 1, values[series_index][category_index])
            series.data_points.add_data_point_for_bar_series(value_cell)

    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Justera höjdförhållandena för ett 3D-diagram**

Använd [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) för att sätta höjden på ett 3D-diagram som en procentandel av dess bredd. Detta ändrar proportionerna i 3D‑scenen utan att ändra storleken på diagramobjektet på bilden.

Följande exempel skapar ett [COLUMN_3D](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) diagram med standarddata: tre serier och fyra kategorier. Det sparar tre presentationer med höjdförhållanden på 50 %, 100 % och 200 %. Diagrammets position, bredd och höjd förblir oförändrade. Data, rotation, djup, serievärden och formatering är identiska i alla tre filerna; bara höjdpromillen förändras.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 40, 30, 620, 460)
    chart.rotation_3d.rotation_x = 20
    chart.rotation_3d.rotation_y = 30
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.depth_percents = 100
    chart.chart_data.series[0].parent_series_group.gap_depth = 150

    for height_percent in (50, 100, 200):
        chart.rotation_3d.height_percents = height_percent
        presentation.save(f"chart_height_{height_percent}.pptx", slides.export.SaveFormat.PPTX)
```

Följande bilder exporterades från de genererade presentationerna med Microsoft PowerPoint. En lägre procentandel ger en plattare scen, medan en högre procentandel ger en högre scen inom samma diagramobjekt. PowerPoint kan också justera axelns tick‑intervall och etikettplacering för att passa scenen.

| Höjd: 50% | Höjd: 100% | Höjd: 200% |
| --- | --- | --- |
| ![3D-kolumndiagram med höjden inställd på 50 procent av dess bredd](height_percent_50.png) | ![3D-kolumndiagram med höjden inställd på 100 procent av dess bredd](height_percent_100.png) | ![3D-kolumndiagram med höjden inställd på 200 procent av dess bredd](height_percent_200.png) |

Dessa egenskaper styr olika aspekter av diagrammet:

| Egenskap | Effekt |
| --- | --- |
| [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) | Höjden på 3D‑scenen som en procentandel av dess bredd. |
| [Chart.height](https://reference.aspose.com/slides/python-net/aspose.slides/shape/height/) | Höjden på diagramobjektet på bilden, i punkter. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | Djupet på 3D‑scenen som en procentandel av dess bredd. |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | Avstånd mellan serier längs djupaxeln, som en procentandel av markörens bredd. |

Höjdinställningen påverkar 3D‑stapel- och stapeldiagram, inklusive cylinder-, kon‑ och pyramidalvarianter, samt 3D‑linje-, area‑, paj‑ och ytdiagram. Jämförelsen ovan använder den verifierade `COLUMN_3D`-typen. Inställningen förändrar inte utseendet på ett 2D-`CLUSTERED_COLUMN`‑diagram eller ett `BUBBLE_WITH_3D`‑diagram; dessa namn är medlemmar i uppräkningen [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/). För andra diagramformatinställningar, se [Chart Formatting](/slides/sv/python-net/chart-formatting/).

## **Justera avståndet mellan serier**

Använd [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) för att kontrollera avståndet mellan dataserier längs djupaxeln i ett 3D-diagram, uttryckt som en procentandel av markörens bredd. Använd värden från **0 till 500**, inklusive: `0` tar bort gapet, medan större värden ökar avståndet. Med ett fast diagramdjup gör ett större gap att markörerna blir tunnare längs djupaxeln.

Få åtkomst till gruppen via [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/). Inställningen gäller för varje serie i den gruppen, inte bara för den serie som används för åtkomst. [ChartSeries.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/gap_depth/) är skrivskyddad och reflekterar gruppens inställning.

Denna inställning påverkar 3D‑stapel‑ och stapeldiagram, inklusive deras cylinder-, kon‑ och pyramidalvarianter, samt 3D‑linje- och area‑diagram. Utseendet beror på om serierna är arrangerade i djup, grupperade eller staplade. För en tydlig jämförelse av gap mellan separata serier, använd `ChartType.COLUMN_3D` från uppräkningen [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/).

Dessa egenskaper styr olika aspekter av diagrammet:

| Egenskap | Effekt |
| --- | --- |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | Avstånd mellan serier längs djupaxeln, som en procentandel av markörens bredd. |
| [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) | Avstånd mellan intilliggande stapel‑ eller kolumnkluster, som en procentandel av stapel‑ eller kolumnbredden. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | Totalt diagramdjup, som en procentandel av diagrammens bredd. |

Följande fristående exempel använder standarddiagramdata som innehåller tre serier och fyra kategorier. Det sparar två presentationer med identiska data, rotation, gapbredd och diagramdjup; endast gapdjupet ändras.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 40, 30, 620, 230)

    chart.rotation_3d.rotation_x = 20
    chart.rotation_3d.rotation_y = 30
    chart.rotation_3d.depth_percents = 100

    series = chart.chart_data.series[0]
    group = series.parent_series_group
    group.gap_width = 150

    for gap_depth in (0, 500):
        group.gap_depth = gap_depth
        file_name = f"series_gap_depth_{gap_depth}.pptx"
        presentation.save(file_name, slides.export.SaveFormat.PPTX)
```

Följande bilder exporterades från de genererade presentationerna med Microsoft PowerPoint.

| Gappdjup: 0% | Gappdjup: 500% |
| --- | --- |
| ![3D-kolumndiagram utan gap mellan serier längs djupaxeln](gap_depth_0.png) | ![3D-kolumndiagram med ett 500 procent gap mellan serier längs djupaxeln](gap_depth_500.png) |

## **Ändra 3D-serietyp och stapelform**

I ett grupperat cylinder‑diagram börjar den första serien med cylindriska staplar. Exemplet läser [ChartSeries.type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/type/) och [ChartSeries.bar_3d_shape](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/bar_3d_shape/) före och efter varje förändring.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_CYLINDER, 20, 20, 500, 300)
    series = chart.chart_data.series[0]
    
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    series.type = charts.ChartType.CLUSTERED_CONE
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    series.bar_3d_shape = charts.ChartShapeType.BOX
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    presentation.save("series_shape.pptx", slides.export.SaveFormat.PPTX)
```

| Ändring på den första serien | `type` | `bar_3d_shape` |
| --- | --- | --- |
| Skapa diagrammet | `CLUSTERED_CYLINDER` | `CYLINDER` |
| Ställ in `type` till `CLUSTERED_CONE` | `CLUSTERED_CONE` | `CONE` |
| Ställ in `bar_3d_shape` till `BOX` | `CLUSTERED_COLUMN_3D` | `BOX` |

Att sätta formen till `BOX` ändrar också serietypen till `CLUSTERED_COLUMN_3D`. Om din kod har villkor baserade på serietyp, läs `series.type` efter att formen har ändrats. Ett värde som cachets före tilldelningen skulle fortfarande välja `CLUSTERED_CONE`‑grenen.

![PowerPoint-jämförelse som visar den första serien som cylindrar, koner och rektangulära kolumner från vänster till höger](series-shapes.png)

## **FAQ**

**Vilka diagramtyper stödjer 3D-läge i Aspose.Slides?**

Aspose.Slides stödjer 3D‑varianter av stapeldiagram, inklusive Column 3D, Clustered Column 3D, Stacked Column 3D och 100 % Stacked Column 3D, samt relaterade 3D‑typer som exponeras genom uppräkningen [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/). För en exakt, uppdaterad lista, kontrollera medlemmarna i [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) i API‑referensen för den installerade versionen.

**Kan jag få en rasterbild av ett 3D-diagram för en rapport eller webb?**

Ja. Du kan exportera ett diagram till en bild med [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) eller [rendera hela bilden](/slides/sv/python-net/convert-powerpoint-to-png/) till format som PNG eller JPEG. Detta är användbart när du behöver en rasterförhandsgranskning eller vill bädda in diagrammet i dokument, instrumentpaneler eller webbplatser utan att kräva PowerPoint.

**Hur presterar byggning och rendering av stora 3D-diagram?**

Prestandan beror på datavolym och visuell komplexitet. För bästa resultat, håll 3D‑effekter minimala, undvik tunga texturer på väggar och plotområden, begränsa antalet datapunkter per serie när det är möjligt, och rendera till en lämplig storlek på utdata (upplösning och dimensioner) för att matcha målskärmen eller utskriftsbehoven.