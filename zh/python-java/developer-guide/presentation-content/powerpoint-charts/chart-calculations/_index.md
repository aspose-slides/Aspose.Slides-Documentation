---
title: 在 Python via Java 中为演示文稿优化图表计算
linktitle: 图表计算
type: docs
weight: 50
url: /zh/python-java/chart-calculations/
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
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "了解 Aspose.Slides for Python via Java 在 PPT 和 PPTX 中的图表计算、数据更新和精度控制，并提供实用的 Python 代码示例。"
---
## **概述**

Aspose.Slides 为在演示文稿中处理图表计算和布局数据提供了 API。本文展示了如何检索图表元素的实际数值，包括图表元素的真实位置和大小以及坐标轴的实际数值。它还说明这些数值是在图表布局验证后填充的。

此外，本文演示了如何获取父图表元素的实际位置以及如何隐藏图表组件（如标题、坐标轴、图例和网格线）。通过这些示例，您可以以编程方式检查 PowerPoint 演示文稿中的图表布局信息并控制图表元素的可见性。

## **计算图表元素的实际数值**
Aspose.Slides for Python via Java 提供了获取这些属性的简易 API。[Axis](https://reference.aspose.com/slides/zh/python-java/aspose.slides/axis/) 类的方法提供关于图表坐标轴实际数值的信息（[getActualMaxValue](https://reference.aspose.com/slides/zh/python-java/aspose.slides/axis/#getActualMaxValue)、[getActualMinValue](https://reference.aspose.com/slides/zh/python-java/aspose.slides/axis/#getActualMinValue)、[getActualMajorUnit](https://reference.aspose.com/slides/zh/python-java/aspose.slides/axis/#getActualMajorUnit)、[getActualMinorUnit](https://reference.aspose.com/slides/zh/python-java/aspose.slides/axis/#getActualMinorUnit)、[getActualMajorUnitScale](https://reference.aspose.com/slides/zh/python-java/aspose.slides/axis/#getActualMajorUnitScale)、[getActualMinorUnitScale](https://reference.aspose.com/slides/zh/python-java/aspose.slides/axis/#getActualMinorUnitScale)）。请先调用 [Chart.validateChartLayout](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chart/#validateChartLayout) 方法以用实际数值填充这些属性。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getHorizontalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getHorizontalAxis().getActualMinorUnit()
finally:
    presentation.dispose()
```

## **计算父图表元素的实际位置**
Aspose.Slides for Python via Java 提供了获取这些属性的简易 API。 [ChartPlotArea](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartplotarea/) 类的方法提供关于图表绘图区域实际位置和大小的信息（[getActualX](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartplotarea/#getActualX)、[getActualY](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartplotarea/#getActualY)、[getActualWidth](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartplotarea/#getActualWidth)、[getActualHeight](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartplotarea/#getActualHeight)）。请先调用 [Chart.validateChartLayout](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chart/#validateChartLayout) 方法以用实际数值填充这些属性。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350)
    chart.validateChartLayout()

    x = chart.getPlotArea().getActualX()
    y = chart.getPlotArea().getActualY()
    width = chart.getPlotArea().getActualWidth()
    height = chart.getPlotArea().getActualHeight()
finally:
    presentation.dispose()
```

## **隐藏图表元素**
本节说明如何隐藏图表中的信息。使用 Aspose.Slides for Python via Java，您可以隐藏 **Title、Vertical Axis、Horizontal Axis** 和 **Grid Lines**。下面的代码示例展示了如何使用这些属性。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LegendDataLabelPosition, LineDashStyle, MarkerStyleType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370)

    # 隐藏图表标题。
    chart.setTitle(False)

    # 隐藏数值轴。
    chart.getAxes().getVerticalAxis().setVisible(False)

    # 隐藏类别轴。
    chart.getAxes().getHorizontalAxis().setVisible(False)

    # 隐藏图例。
    chart.setLegend(False)

    # 隐藏主网格线。
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    # 仅保留第一系列。从末尾删除可保持其余索引有效。
    series_collection = chart.getChartData().getSeries()
    while series_collection.size() > 1:
        series_collection.removeAt(series_collection.size() - 1)

    series = series_collection.get_Item(0)

    series.getMarker().setSymbol(MarkerStyleType.Circle)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.Top)
    series.getMarker().setSize(15)

    # 设置系列线条颜色。
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA)
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid)

    presentation.save("HideInformationFromChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常见问题**

**外部 Excel 工作簿可以作为数据源吗？这会如何影响重新计算？**  
是的。图表可以引用外部工作簿：当连接或刷新外部源时，公式和数值会从该工作簿获取，图表在打开/编辑期间会反映这些更新。API 允许您[指定外部工作簿](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdata/#setExternalWorkbook)路径并管理链接数据。

**我可以在不自己实现回归的情况下计算并显示趋势线吗？**  
可以。[Trendlines](/slides/zh/python-java/trend-line/)（线性、指数等）由 Aspose.Slides 添加并自动更新，其参数会根据系列数据重新计算，您无需自行实现计算。

**如果演示文稿中有多个带外部链接的图表，我可以控制每个图表使用哪个工作簿进行计算吗？**  
可以。每个图表都可以指向各自的[external workbook](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdata/#setExternalWorkbook)，或者您可以为每个图表单独创建/替换外部工作簿，而不影响其他图表。