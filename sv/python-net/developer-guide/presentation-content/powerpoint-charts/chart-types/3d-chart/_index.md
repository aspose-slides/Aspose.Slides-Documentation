---
title: Anpassa 3D-diagram i presentationer med Python
linktitle: 3D-diagram
type: docs
url: /sv/python-net/3d-chart/
keywords:
- 3d-diagram
- rotation
- djup
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Lär dig hur du skapar och anpassar 3-D-diagram i Aspose.Slides för Python via .NET, med stöd för PPT, PPTX och ODP-filer – förbättra dina presentationer idag."
---
## **Översikt**

Den här artikeln förklarar hur du anpassar ett 3D-diagram i Aspose.Slides genom att konfigurera `rotation_3d`-inställningar såsom `rotation_x`, `rotation_y`, `depth_percents` och `right_angle_axes`. Den går igenom att skapa en presentation, lägga till ett 3D-diagram med standarddata, tillämpa de nödvändiga 3D-vyinställningarna och spara den modifierade presentationen som en PPTX‑fil.

## **Ställ in RotationX, RotationY och DepthPercents‑egenskaper för 3D‑diagram**
Aspose.Slides for Python via .NET tillhandahåller ett enkelt API för att ställa in dessa egenskaper. Följande artikel hjälper dig att sätta olika egenskaper som X,Y‑rotation, **DepthPercents** osv. Exempelkoden tillämpar att sätta de ovan nämnda egenskaperna.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
2. Åtkomst till den första bilden.
3. Lägg till ett diagram med standarddata.
4. Ställ in Rotation3D‑egenskaper.
5. Skriv den modifierade presentationen till en PPTX‑fil.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Skapa en instans av Presentation-klassen
with slides.Presentation() as presentation:
            
    # Åtkomst till den första bilden
    slide = presentation.slides[0]

    # Lägg till diagram med standarddata
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    # Ställ in index för diagramdatablad
    defaultWorksheetIndex = 0

    # Hämtar diagramdatabladet
    fact = chart.chart_data.chart_data_workbook

    # Lägg till serier
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.type)

    # Lägg till kategorier
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"))

    # Ställ in Rotation3D-egenskaper
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    # Ta andra diagramserien
    series = chart.chart_data.series[1]

    # Fyll nu på seriedata
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 2, 60))

    # Ställ in OverLap-värde
    series.parent_series_group.overlap = 100         

    # Spara presentationen till disk
    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Vanliga frågor**

**Vilka diagramtyper stödjer 3D‑läge i Aspose.Slides?**

Aspose.Slides stödjer 3D‑varianter av stapeldiagram, inklusive Column 3D, Clustered Column 3D, Stacked Column 3D och 100 % Stacked Column 3D, tillsammans med relaterade 3D‑typer som exponeras via uppräkningen [ChartType](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/charttype/). För en exakt, uppdaterad lista, kontrollera medlemmarna i [ChartType](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/charttype/) i API‑referensen för den version du har installerat.

**Kan jag få en rasterbild av ett 3D‑diagram för en rapport eller webben?**

Ja. Du kan exportera ett diagram till en bild via [chart API](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chart/get_image/) eller [render the entire slide](/slides/sv/python-net/convert-powerpoint-to-png/) till format som PNG eller JPEG. Detta är användbart när du behöver en pixelperfekt förhandsgranskning eller vill bädda in diagrammet i dokument, instrumentbrädor eller webbsidor utan att kräva PowerPoint.

**Hur presterar skapande och rendering av stora 3D‑diagram?**

Prestanda beror på datavolym och visuell komplexitet. För bästa resultat, håll 3D‑effekterna minimala, undvik tunga texturer på väggar och diagramytor, begränsa antalet datapunkter per serie när det är möjligt, och rendera till en lämpligt stor utdata (upplösning och dimensioner) som matchar målskärmen eller utskriftsbehoven.