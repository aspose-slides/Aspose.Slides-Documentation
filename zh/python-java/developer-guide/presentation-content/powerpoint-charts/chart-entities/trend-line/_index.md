---
title: 在 Python 中向演示文稿图表添加趋势线
linktitle: 趋势线
type: docs
url: /zh/python-java/trend-line/
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
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 快速在 PowerPoint 图表中添加并自定义趋势线——一本帮助您吸引受众的实用指南。"
---
## **概述**

本文介绍如何使用 Aspose.Slides 向演示文稿图表添加趋势线。它展示了如何创建图表、向图表系列添加趋势线，以及如何使用多种趋势线类型，包括指数、线性、对数、移动平均、多项式和幂趋势线。

它还说明了如何通过插入直线形状向图表添加自定义线，并包含一个简短的常见问题，涉及趋势线的前向和后向投影值以及在导出为 PDF 或 SVG，或将图表渲染为图像时是否会保留趋势线。

## **添加趋势线**

Aspose.Slides for Python via Java provides a simple API for managing different chart trend lines:

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 添加具有默认数据和所需类型的图表（本示例使用 [ChartType.ClusteredColumn](https://reference.aspose.com/slides/zh/python-java/aspose.slides/charttype/#ClusteredColumn)）。
4. 向图表系列 1 添加指数趋势线。
5. 向图表系列 1 添加线性趋势线。
6. 向图表系列 2 添加对数趋势线。
7. 向图表系列 2 添加移动平均趋势线。
8. 向图表系列 3 添加多项式趋势线。
9. 向图表系列 3 添加幂趋势线。
10. 将修改后的演示文稿写入 PPTX 文件。

以下代码创建了带有趋势线的图表。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, TrendlineType
from java.awt import Color

# 创建 Presentation 类的实例。
presentation = Presentation()
try:
    # 创建簇状柱形图。
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400)

    # 向图表系列 1 添加指数趋势线。
    exponential_trend_line = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential)
    exponential_trend_line.setDisplayEquation(False)
    exponential_trend_line.setDisplayRSquaredValue(False)

    # 向图表系列 1 添加线性趋势线。
    linear_trend_line = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear)
    linear_trend_line.setTrendlineType(TrendlineType.Linear)
    linear_trend_line.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    linear_trend_line.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)

    # 向图表系列 2 添加对数趋势线。
    logarithmic_trend_line = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic)
    logarithmic_trend_line.setTrendlineType(TrendlineType.Logarithmic)
    logarithmic_trend_line.addTextFrameForOverriding("New log trend line")

    # 向图表系列 2 添加移动平均趋势线。
    moving_average_trend_line = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage)
    moving_average_trend_line.setTrendlineType(TrendlineType.MovingAverage)
    moving_average_trend_line.setPeriod(jpype.JByte(3))
    moving_average_trend_line.setTrendlineName("New TrendLine Name")

    # 向图表系列 3 添加多项式趋势线。
    polynomial_trend_line = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial)
    polynomial_trend_line.setTrendlineType(TrendlineType.Polynomial)
    polynomial_trend_line.setForward(1)
    polynomial_trend_line.setOrder(jpype.JByte(3))

    # 向图表系列 3 添加幂趋势线。
    power_trend_line = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Power)
    power_trend_line.setTrendlineType(TrendlineType.Power)
    power_trend_line.setBackward(1)

    # 保存演示文稿。
    presentation.save("ChartTrendLines_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **添加自定义线**

Aspose.Slides for Python via Java provides a simple API to add custom lines to a chart. To add a plain line to a chart on a selected slide, follow these steps:

- 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。
- 通过索引获取幻灯片的引用。
- 使用 [ShapeCollection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapecollection/) 类的 [addChart](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapecollection/#addChart) 方法创建新图表。
- 使用 [addAutoShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapecollection/#addAutoShape) 方法并指定 [ShapeType.Line](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapetype/#Line) 添加直线形状。
- 设置形状线条的颜色。
- 将修改后的演示文稿写入 PPTX 文件。

以下代码创建了带有自定义线的图表。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# 创建 Presentation 类的实例。
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)
    shape = chart.getUserShapes().getShapes().addAutoShape(ShapeType.Line, 0, chart.getHeight() / 2, chart.getWidth(), 0)

    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("Presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常见问题**

**趋势线的“前向”和“后向”是什么意思？**

它们是趋势线向前或向后投射的长度：对于散点 (XY) 图表，以坐标轴单位计量；对于非散点图表，以类别数计量。仅允许非负值。

**在将演示文稿导出为 PDF 或 SVG，或将幻灯片渲染为图像时，趋势线会被保留吗？**

是的。Aspose.Slides 可将演示文稿转换为 [PDF](/slides/zh/python-java/convert-powerpoint-to-pdf/)/[SVG](/slides/zh/python-java/render-a-slide-as-an-svg-image/) 并将图表渲染为图像；趋势线作为图表的一部分，在这些操作中会被保留。还提供了一个方法可[导出图表的图像](/slides/zh/python-java/create-shape-thumbnails/)。