---
title: 在 Python 中向演示文稿图表添加趋势线
linktitle: 趋势线
type: docs
url: /zh/python-net/trend-line/
keywords:
- 图表
- 趋势线
- 指数趋势线
- 线性趋势线
- 对数趋势线
- 移动平均趋势线
- 多项式趋势线
- 幂趋势线
- 自定义趋势线
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 快速在 PowerPoint 图表中添加和自定义趋势线——实用指南，帮助您吸引观众。"
---
## **概述**

本文介绍如何使用 Aspose.Slides 向演示文稿图表添加趋势线。它展示了如何创建图表、向图表系列添加趋势线，以及使用多种趋势线类型，包括指数、线性、对数、移动平均、多项式和幂。

它还说明了如何通过插入直线形状向图表添加自定义线，并包含一个简短的 FAQ，内容涉及趋势线的 forward 和 backward 投影值以及在导出为 PDF 或 SVG、以及渲染图表为图像时趋势线是否会被保留。

## **添加趋势线**

使用 [TrendlineCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendlinecollection/add/) 向图表系列添加趋势线，并使用 [TrendlineType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendlinetype/) 选择其类型。示例创建了一个带默认数据的簇状柱形图，并为其三个系列中的每个系列添加了两条趋势线。

指数趋势线通过 [display_equation](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/display_equation/) 和 [display_r_squared_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/display_r_squared_value/) 隐藏其公式和决定系数(R²)，而线性趋势线为红色。对数趋势线使用 [add_text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/add_text_frame_for_overriding/) 设置自定义标签。移动平均使用 [period](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/period/) 为三个数据点，并使用自定义的 [trendline_name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/trendline_name/)。

多项式趋势线的 [order](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/order/) 为三，并通过 [forward](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/forward/) 向前延伸一个类别。幂趋势线通过 [backward](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/backward/) 向后延伸一个类别。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 400)

    first_series = chart.chart_data.series[0]

    exponential_trendline = first_series.trend_lines.add(charts.TrendlineType.EXPONENTIAL)
    exponential_trendline.display_equation = False
    exponential_trendline.display_r_squared_value = False

    linear_trendline = first_series.trend_lines.add(charts.TrendlineType.LINEAR)
    linear_trendline.format.line.fill_format.fill_type = slides.FillType.SOLID
    linear_trendline.format.line.fill_format.solid_fill_color.r = 255
    linear_trendline.format.line.fill_format.solid_fill_color.g = 0
    linear_trendline.format.line.fill_format.solid_fill_color.b = 0

    second_series = chart.chart_data.series[1]

    logarithmic_trendline = second_series.trend_lines.add(charts.TrendlineType.LOGARITHMIC)
    logarithmic_trendline.add_text_frame_for_overriding("New log trend line")

    moving_average_trendline = second_series.trend_lines.add(charts.TrendlineType.MOVING_AVERAGE)
    moving_average_trendline.period = 3
    moving_average_trendline.trendline_name = "New TrendLine Name"

    third_series = chart.chart_data.series[2]

    polynomial_trendline = third_series.trend_lines.add(charts.TrendlineType.POLYNOMIAL)
    polynomial_trendline.forward = 1
    polynomial_trendline.order = 3

    power_trendline = third_series.trend_lines.add(charts.TrendlineType.POWER)
    power_trendline.backward = 1

    presentation.save("ChartTrendLines.pptx", slides.export.SaveFormat.PPTX)
```

## **设置趋势线截距**

使用 [intercept](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/intercept/) 将趋势线在 X = 0 时的 Y 值固定。此设置支持线性、指数和多项式趋势线。

例如，生产成本模型可能需要从已知的固定成本 100 开始，即使在非零产量的测量值暗示不同的基线。对于线性趋势线，将截距固定会把方程 `y = ax + b` 限制为 `b = 100`；在此约束下斜率会根据数据进行拟合。这并不是简单地移动已经拟合好的直线。轴交叉设置控制图表坐标轴的交点位置，而不是已拟合趋势线的系数。

下面的示例创建了一个散点 (XY) 图表，产量从 1 到 4，对应成本分别为 170、200、230 和 260。它使用默认的自动截距保存图表，然后将截距设置为 100 并保存第二个 PPTX。这两个文件仅在截距设置上不同。趋势线显示其公式并向后延伸至 X = 0。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.SCATTER_WITH_MARKERS, 20, 20, 480, 210)
    chart.has_legend = False

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    name_cell = workbook.get_cell(0, 0, 1, "Production cost")
    series = chart.chart_data.series.add(name_cell, charts.ChartType.SCATTER_WITH_MARKERS)
    costs = [170, 200, 230, 260]

    for i, cost in enumerate(costs):
        x_cell = workbook.get_cell(0, i + 1, 0, i + 1)
        y_cell = workbook.get_cell(0, i + 1, 1, cost)
        series.data_points.add_data_point_for_scatter_series(x_cell, y_cell)

    trendline = series.trend_lines.add(charts.TrendlineType.LINEAR)
    trendline.display_equation = True
    trendline.backward = 1

    presentation.save("AutomaticIntercept.pptx", slides.export.SaveFormat.PPTX)

    trendline.intercept = 100
    presentation.save("FixedIntercept.pptx", slides.export.SaveFormat.PPTX)
```

使用自动计算时，这些数据得到 `y = 30x + 140`。将截距设置为 100 则大约得到 `y = 43.33x + 100`：零点的拟合值匹配已知基线，但直线不再经过每个数据点。

| 自动截距 | 固定截距 100 |
| --- | --- |
| ![自动计算截距为 140 的线性趋势线](intercept-automatic.png) | ![截距固定为 100 的线性趋势线](intercept-fixed.png) |

两幅图使用相同的数据和坐标轴比例。趋势线向后延伸至 X = 0，以显示其截距。

默认情况下，该属性包含 `float("nan")`，表示截距未指定而非零。随后截距会根据数据自动计算。

## **添加自定义线**

自定义线是一种绘制在图表之上的形状，而非从系列数据计算得到的趋势线。此示例使用 [ShapeCollection.add_auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_auto_shape/) 在幻灯片的图表上方添加一条水平线。该线的位置以幻灯片坐标（点）指定，因此从图表左边缘开始，位于图表中部。其宽度与图表宽度相同。[line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) 为线条设置了实心红色。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)

    line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, chart.x, chart.y + chart.height / 2, chart.width, 0)
    line.line_format.fill_format.fill_type = slides.FillType.SOLID
    line.line_format.fill_format.solid_fill_color.r = 255
    line.line_format.fill_format.solid_fill_color.g = 0
    line.line_format.fill_format.solid_fill_color.b = 0

    presentation.save("AddCustomLines.pptx", slides.export.SaveFormat.PPTX)
```

## **常见问题**

**趋势线的 'forward' 和 'backward' 是什么含义？**

它们是趋势线向前/向后投射的长度：对于散点 (XY) 图表，以坐标轴单位计；对于非散点图表，以类别数量计。仅允许非负值。

**导出演示文稿为 PDF 或 SVG，或将幻灯片渲染为图像时，趋势线会被保留吗？**

会。Aspose.Slides 可以将演示文稿转换为 [PDF](/slides/zh/python-net/convert-powerpoint-to-pdf/) 或 [SVG](/slides/zh/python-net/render-a-slide-as-an-svg-image/)，并将图表渲染为图像；作为图表组成部分的趋势线在这些操作中会被保留。还提供了将图表本身 [导出为图像](/slides/zh/python-net/create-shape-thumbnails/) 的方法。