---
title: Diagramm-Berechnungen
type: docs
weight: 50
url: /python-net/chart-calculations/
keywords: "Diagramm Berechnungen, Diagramm Elemente, Elementposition, Diagramm Werte Python, Aspose.Slides für Python über .NET"
description: "PowerPoint Diagramm Berechnungen und Werte in Python"
---

## **Berechnung der tatsächlichen Werte von Diagrammelementen**
Aspose.Slides für Python über .NET bietet eine einfache API, um diese Eigenschaften abzurufen. Dies hilft Ihnen, die tatsächlichen Werte der Diagrammelemente zu berechnen. Die tatsächlichen Werte umfassen die Position von Elementen, die das IActualLayout-Interface implementieren (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) und die tatsächlichen Achsenwerte (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale).

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    maxValue = chart.axes.vertical_axis.actual_max_value
    minValue = chart.axes.vertical_axis.actual_min_value
    majorUnit = chart.axes.horizontal_axis.actual_major_unit
    minorUnit = chart.axes.horizontal_axis.actual_minor_unit
```



## **Berechnung der tatsächlichen Position von Eltern-Diagrammelementen**
Aspose.Slides für Python über .NET bietet eine einfache API, um diese Eigenschaften abzurufen. Die Eigenschaften von IActualLayout liefern Informationen über die tatsächliche Position des übergeordneten Diagrammelements. Es ist erforderlich, die Methode IChart.ValidateChartLayout() vorher aufzurufen, um die Eigenschaften mit tatsächlichen Werten zu füllen.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    x = chart.plot_area.actual_x
    y = chart.plot_area.actual_y
    w = chart.plot_area.actual_width
    h = chart.plot_area.actual_height
```



## **Informationen aus dem Diagramm ausblenden**
Dieses Thema hilft Ihnen zu verstehen, wie man Informationen aus dem Diagramm ausblendet. Mit Aspose.Slides für Python über .NET können Sie **Titel, Vertikale Achse, Horizontale Achse** und **Gitternetzlinien** aus dem Diagramm ausblenden. Der folgende Code zeigt, wie man diese Eigenschaften verwendet.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 140, 118, 320, 370)

    # Ausblenden des Diagrammtitels
    chart.has_title = False

    # Ausblenden der Werteachse
    chart.axes.vertical_axis.is_visible = False

    # Sichtbarkeit der Kategorienachse
    chart.axes.horizontal_axis.is_visible = False

    # Ausblenden der Legende
    chart.has_legend = False

    # Ausblenden der Hauptgitternetzlinien
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    #for i in range(len(chart.chart_data.series)):
    #    chart.chart_data.series.remove_at(i)

    series = chart.chart_data.series[0]

    series.marker.symbol = charts.MarkerStyleType.CIRCLE
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.position = charts.LegendDataLabelPosition.TOP
    series.marker.size = 15

    # Linie Farbe der Serie festlegen
    series.format.line.fill_format.fill_type = slides.FillType.SOLID
    series.format.line.fill_format.solid_fill_color.color = draw.Color.purple
    series.format.line.dash_style = slides.LineDashStyle.SOLID

    pres.save("HideInformationFromChart.pptx", slides.export.SaveFormat.PPTX)
```