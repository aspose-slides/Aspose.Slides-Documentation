---
title: 优化 Python 演示文稿中的图表计算
linktitle: 图表计算
type: docs
weight: 50
url: /zh/python-net/chart-calculations/
keywords:
- 图表计算
- 图表元素
- 元素位置
- 实际位置
- 子元素
- 父元素
- 图表数值
- 实际数值
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "了解 Aspose.Slides for Python via .NET 在 PPT、PPTX 和 ODP 中的图表计算、数据更新和精度控制，并附有实用代码示例。"
---

## **计算图表元素的实际值**
Aspose.Slides for Python via .NET 提供了一个简单的 API 用于获取这些属性。这将帮助您计算图表元素的实际值。实际值包括继承 [IActualLayout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/iactuallayout/) 类的元素位置（IActualLayout.ActualX、IActualLayout.ActualY、IActualLayout.ActualWidth、IActualLayout.ActualHeight）以及实际坐标轴值（IAxis.ActualMaxValue、IAxis.ActualMinValue、IAxis.ActualMajorUnit、IAxis.ActualMinorUnit、IAxis.ActualMajorUnitScale、IAxis.ActualMinorUnitScale）。
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
Aspose.Slides for Python via .NET 提供了一个简单的 API 用于获取这些属性。IActualLayout 的属性提供了父图表元素实际位置的信息。需要先调用 IChart.ValidateChartLayout() 方法以用实际值填充这些属性。
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
本章节帮助您了解如何隐藏图表中的信息。使用 Aspose.Slides for Python via .NET，您可以隐藏图表的 **标题、垂直坐标轴、水平坐标轴** 和 **网格线**。下面的代码示例展示了如何使用这些属性。
```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 140, 118, 320, 370)

    # 隐藏图表标题
    chart.has_title = False

    # 隐藏数值轴
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

    # 设置系列线颜色
    series.format.line.fill_format.fill_type = slides.FillType.SOLID
    series.format.line.fill_format.solid_fill_color.color = draw.Color.purple
    series.format.line.dash_style = slides.LineDashStyle.SOLID

    pres.save("HideInformationFromChart.pptx", slides.export.SaveFormat.PPTX)
```


## **常见问题**

**外部 Excel 工作簿可以作为数据源吗？这会如何影响重新计算？**

是的。图表可以引用外部工作簿：当您连接或刷新外部源时，公式和数值会从该工作簿中获取，图表在打开/编辑操作期间会反映这些更新。API 允许您 [specify the external workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) 路径并管理链接的数据。

**我可以在不自行实现回归的情况下计算并显示趋势线吗？**

是的。[Trendlines](/slides/zh/python-net/trend-line/)（线性、指数等）由 Aspose.Slides 添加并自动更新；它们的参数会根据系列数据自动重新计算，因此您无需自行实现计算。

**如果一个演示文稿包含多个带有外部链接的图表，我能控制每个图表使用哪个工作簿进行计算吗？**

是的。每个图表都可以指向其自己的 [external workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/)，或者您可以为每个图表单独创建/替换外部工作簿，彼此独立。