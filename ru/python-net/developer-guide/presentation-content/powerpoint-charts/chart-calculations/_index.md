---
title: Расчеты диаграмм
type: docs
weight: 50
url: /ru/python-net/chart-calculations/
keywords: "Расчеты диаграмм, элементы диаграммы, позиция элементов, значения диаграмм Python, Aspose.Slides для Python via .NET"
description: "Расчеты и значения диаграмм PowerPoint на Python"
---

## **Расчет фактических значений элементов диаграммы**
Aspose.Slides для Python via .NET предоставляет простой API для получения этих свойств. Это поможет вам рассчитать фактические значения элементов диаграммы. Фактические значения включают позицию элементов, которые реализуют интерфейс IActualLayout (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) и фактические значения осей (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale).

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


## **Расчет фактической позиции родительских элементов диаграммы**
Aspose.Slides для Python via .NET предоставляет простой API для получения этих свойств. Свойства IActualLayout предоставляют информацию о фактической позиции родительского элемента диаграммы. Необходимо предварительно вызвать метод IChart.ValidateChartLayout(), чтобы заполнить свойства фактическими значениями.

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


## **Скрытие информации из диаграммы**
Эта тема поможет вам понять, как скрыть информацию из диаграммы. Используя Aspose.Slides для Python via .NET, вы можете скрыть **Название, Вертикальную ось, Горизонтальную ось** и **Сеточные линии** из диаграммы. Ниже приведен пример кода, который показывает, как использовать эти свойства.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 140, 118, 320, 370)

    # Скрытие названия диаграммы
    chart.has_title = False

    # Скрытие оси значений
    chart.axes.vertical_axis.is_visible = False

    # Видимость категории оси
    chart.axes.horizontal_axis.is_visible = False

    # Скрытие легенды
    chart.has_legend = False

    # Скрытие основных сеточных линий
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    #for i in range(len(chart.chart_data.series)):
    #    chart.chart_data.series.remove_at(i)

    series = chart.chart_data.series[0]

    series.marker.symbol = charts.MarkerStyleType.CIRCLE
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.position = charts.LegendDataLabelPosition.TOP
    series.marker.size = 15

    # Установка цвета линии серии
    series.format.line.fill_format.fill_type = slides.FillType.SOLID
    series.format.line.fill_format.solid_fill_color.color = draw.Color.purple
    series.format.line.dash_style = slides.LineDashStyle.SOLID

    pres.save("HideInformationFromChart.pptx", slides.export.SaveFormat.PPTX)
```