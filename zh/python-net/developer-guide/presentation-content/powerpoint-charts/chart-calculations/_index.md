---
title: 图表计算
type: docs
weight: 50
url: /zh/python-net/chart-calculations/
keywords: "图表计算, 图表元素, 元素位置, 图表值 Python, Aspose.Slides for Python via .NET"
description: "PowerPoint 图表计算和 Python 中的值"
---

## **计算图表元素的实际值**
Aspose.Slides for Python via .NET 提供了一个简单的 API 用于获取这些属性。这将帮助您计算图表元素的实际值。实际值包括实现 IActualLayout 接口的元素的位置 (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) 和实际轴值 (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale)。

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



## **计算父图表元素的实际位置**
Aspose.Slides for Python via .NET 提供了一个简单的 API 用于获取这些属性。IActualLayout 的属性提供有关父图表元素实际位置的信息。必须之前调用方法 IChart.ValidateChartLayout() 以填充属性为实际值。

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



## **隐藏图表信息**
该主题帮助您理解如何从图表中隐藏信息。使用 Aspose.Slides for Python via .NET，您可以隐藏**标题、竖轴、横轴**和**网格线**。以下代码示例显示如何使用这些属性。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 140, 118, 320, 370)

    # 隐藏图表标题
    chart.has_title = False

    # 隐藏值轴
    chart.axes.vertical_axis.is_visible = False

    # 类别轴可见性
    chart.axes.horizontal_axis.is_visible = False

    # 隐藏图例
    chart.has_legend = False

    # 隐藏主网格线
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    #for i in range(len(chart.chart_data.series)):
    #    chart.chart_data.series.remove_at(i)

    series = chart.chart_data.series[0]

    series.marker.symbol = charts.MarkerStyleType.CIRCLE
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.position = charts.LegendDataLabelPosition.TOP
    series.marker.size = 15

    # 设置系列线条颜色
    series.format.line.fill_format.fill_type = slides.FillType.SOLID
    series.format.line.fill_format.solid_fill_color.color = draw.Color.purple
    series.format.line.dash_style = slides.LineDashStyle.SOLID

    pres.save("HideInformationFromChart.pptx", slides.export.SaveFormat.PPTX)
```