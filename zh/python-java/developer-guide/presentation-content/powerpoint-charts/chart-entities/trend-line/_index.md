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
description: "通过 Aspose.Slides for Python via Java 快速在 PowerPoint 图表中添加和自定义趋势线——实用指南，帮助您吸引观众。"
---
## **概述**

本文介绍了如何使用 Aspose.Slides 向演示文稿图表添加趋势线。它展示了如何创建图表、向图表系列添加趋势线以及使用多种趋势线类型，包括指数、线性、对数、移动平均、多项式和幂。

它还说明了如何通过插入直线形状向图表添加自定义线，并包含一个简短的 FAQ，涉及趋势线的前向和后向投影值以及在导出为 PDF 或 SVG 或将图表渲染为图像时趋势线是否会被保留。

## **添加趋势线**

使用 [TrendlineCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/trendlinecollection/#add) 向图表系列添加趋势线，并使用 [TrendlineType](https://reference.aspose.com/slides/python-java/aspose.slides/trendlinetype/) 选择其类型。示例创建了一个具有默认数据的簇状柱形图，并为其三个系列中的每个系列添加了两条趋势线。

指数趋势线通过 [setDisplayEquation](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setDisplayEquation) 和 [setDisplayRSquaredValue](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setDisplayRSquaredValue) 隐藏其公式和决定系数，而线性趋势线为红色。对数趋势线使用 [addTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#addTextFrameForOverriding) 添加自定义标签。移动平均使用 [setPeriod](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setPeriod) 设置为三个数据点，并使用自定义的 [setTrendlineName](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setTrendlineName)。

多项式趋势线的阶数为三，通过 [setOrder](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setOrder) 设置，并通过 [setForward](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setForward) 向前延伸一个分类。幂趋势线通过 [setBackward](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setBackward) 向后延伸一个分类。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, TrendlineType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400)

    first_series = chart.getChartData().getSeries().get_Item(0)

    exponential_trendline = first_series.getTrendLines().add(TrendlineType.Exponential)
    exponential_trendline.setDisplayEquation(False)
    exponential_trendline.setDisplayRSquaredValue(False)

    linear_trendline = first_series.getTrendLines().add(TrendlineType.Linear)
    linear_trendline.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    linear_trendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)

    second_series = chart.getChartData().getSeries().get_Item(1)

    logarithmic_trendline = second_series.getTrendLines().add(TrendlineType.Logarithmic)
    logarithmic_trendline.addTextFrameForOverriding("New log trend line")

    moving_average_trendline = second_series.getTrendLines().add(TrendlineType.MovingAverage)
    moving_average_trendline.setPeriod(jpype.JByte(3))
    moving_average_trendline.setTrendlineName("New TrendLine Name")

    third_series = chart.getChartData().getSeries().get_Item(2)

    polynomial_trendline = third_series.getTrendLines().add(TrendlineType.Polynomial)
    polynomial_trendline.setForward(1)
    polynomial_trendline.setOrder(jpype.JByte(3))

    power_trendline = third_series.getTrendLines().add(TrendlineType.Power)
    power_trendline.setBackward(1)

    presentation.save("ChartTrendLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **设置趋势线截距**

使用 [setIntercept](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setIntercept) 将趋势线在 X = 0 时的 Y 值固定。此设置支持线性、指数和多项式趋势线。

例如，生产成本模型可能需要从已知的固定成本 100 开始，即使在非零产量的测量值暗示不同的基线。对于线性趋势线，固定截距会将公式 `y = ax + b` 限制为 `b = 100`；斜率在此约束下拟合到数据。它并不是简单地移动已拟合的直线。坐标轴交叉设置控制图表坐标轴的交点位置，而不是已拟合趋势线的系数。

下面的示例创建了一个散点 (XY) 图，产量从 1 到 4，成本分别为 170、200、230 和 260。它使用默认的自动截距保存图表，然后将截距设置为 100 并保存第二个 PPTX。这两个文件仅在截距设置上有所不同。趋势线显示其公式并向后延伸至 X = 0。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, TrendlineType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210)
    chart.setLegend(False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    name_cell = workbook.getCell(0, 0, 1, "Production cost")
    series = chart.getChartData().getSeries().add(name_cell, ChartType.ScatterWithMarkers)
    costs = [170, 200, 230, 260]

    for i in range(len(costs)):
        x_cell = workbook.getCell(0, i + 1, 0, i + 1)
        y_cell = workbook.getCell(0, i + 1, 1, costs[i])
        series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    trendline = series.getTrendLines().add(TrendlineType.Linear)
    trendline.setDisplayEquation(True)
    trendline.setBackward(1)

    presentation.save("AutomaticIntercept.pptx", SaveFormat.Pptx)

    trendline.setIntercept(100)
    presentation.save("FixedIntercept.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

使用自动计算时，这些数据得到 `y = 30x + 140`。将截距设为 100 则大约得到 `y = 43.33x + 100`：零点的拟合值匹配已知基线，而这条线不再通过所有数据点。

| 自动截距 | 固定截距 100 |
| --- | --- |
| ![自动计算截距为 140 的线性趋势线](intercept-automatic.png) | ![固定截距为 100 的线性趋势线](intercept-fixed.png) |

两个图像使用相同的数据和坐标轴比例。趋势线向后延伸至 X = 0，以显示其截距。

默认情况下，[getIntercept](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#getIntercept) 返回 `NaN`，表示未指定的截距而非零。随后截距会从数据自动计算。

## **添加自定义线**

自定义线是一种绘制在图表之上的形状，而不是从系列数据计算得到的趋势线。此示例使用 [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAutoShape) 在图表上方的幻灯片中添加一条水平线。该线的位置以幻灯片坐标（点）指定，因此从图表左边缘开始，位于图表高度的一半处。其宽度与图表宽度相同。[getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) 方法可访问用于设置实心红色的线条格式。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)

    line = slide.getShapes().addAutoShape(ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0)
    line.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("AddCustomLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常见问题**

**趋势线的“前向”和“后向”是什么意思？**

它们是趋势线向前/向后投射的长度：对于散点 (XY) 图，以坐标轴单位表示；对于非散点图，以分类数表示。仅允许非负值。

**导出演示文稿为 PDF 或 SVG，或将幻灯片渲染为图像时，会保留趋势线吗？**

是的。Aspose.Slides 可以将演示文稿转换为 [PDF](/slides/zh/python-java/convert-powerpoint-to-pdf/) 或 [SVG](/slides/zh/python-java/render-a-slide-as-an-svg-image/)，并将图表渲染为图像；作为图表一部分的趋势线在这些操作中会被保留。也提供了将图表本身[导出图表的图像](/slides/zh/python-java/create-shape-thumbnails/)的方法。