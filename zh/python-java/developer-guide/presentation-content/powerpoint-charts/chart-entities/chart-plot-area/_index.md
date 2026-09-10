---
title: 在 Python 中自定义演示文稿图表的绘图区
linktitle: 绘图区
type: docs
url: /zh/python-java/chart-plot-area/
keywords:
- 图表
- 绘图区
- 绘图区宽度
- 绘图区高度
- 绘图区大小
- 布局模式
- PowerPoint
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via Java 在 PowerPoint 演示文稿中自定义图表绘图区。轻松提升幻灯片视觉效果。"
---
## **概述**

本文展示了如何在 Aspose.Slides 中使用图表的绘图区。它解释了通过验证图表布局，然后读取其 X、Y、宽度和高度值来获取绘图区的实际位置和大小。

它还演示了在手动设置布局时，如何使用 [LayoutTargetType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/layouttargettype/) 配置绘图区的布局模式，以定义绘图区是根据其内部区域还是包括坐标轴和坐标轴标签的外部区域计算。

## **获取图表绘图区的宽度和高度**

Aspose.Slides for Python via Java 提供了一个简单的 API 来读取图表绘图区的实际位置和大小。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。
1. 访问第一张幻灯片。
1. 添加一个带有默认数据的图表。
1. 在获取实际值之前调用 [Chart.validateChartLayout](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chart/#validateChartLayout) 方法。
1. 获取相对于图表左上角的图表元素的实际 X 位置（左）。
1. 获取相对于图表左上角的图表元素的实际 Y 位置（上）。
1. 获取图表元素的实际宽度。
1. 获取图表元素的实际高度。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

# 创建 Presentation 类的实例。
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350)
    chart.validateChartLayout()

    plot_area = chart.getPlotArea()
    x = plot_area.getActualX()
    y = plot_area.getActualY()
    width = plot_area.getActualWidth()
    height = plot_area.getActualHeight()
finally:
    presentation.dispose()
```

## **设置图表绘图区的布局模式**

Aspose.Slides for Python via Java 提供了一个简单的 API 来设置图表绘图区的布局模式。[ChartPlotArea](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartplotarea/) 类中提供了 [setLayoutTargetType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartplotarea/#setLayoutTargetType) 和 [getLayoutTargetType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartplotarea/#getLayoutTargetType) 方法。如果绘图区的布局是手动定义的，此设置指定是根据内部（不包括坐标轴和坐标轴标签）还是外部（包括坐标轴和坐标轴标签）来布局。[LayoutTargetType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/layouttargettype/) 枚举定义了两种可能的值。

- [Inner](https://reference.aspose.com/slides/zh/python-java/aspose.slides/layouttargettype/#Inner) 指定绘图区大小不包括刻度线和坐标轴标签。
- [Outer](https://reference.aspose.com/slides/zh/python-java/aspose.slides/layouttargettype/#Outer) 指定绘图区大小包括刻度线和坐标轴标签。

下面给出示例代码。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LayoutTargetType, Presentation, SaveFormat

# 创建 Presentation 类的实例。
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400)
    plot_area = chart.getPlotArea()
    plot_area.setX(0.2)
    plot_area.setY(0.2)
    plot_area.setWidth(0.7)
    plot_area.setHeight(0.7)
    plot_area.setLayoutTargetType(LayoutTargetType.Inner)

    presentation.save("SetLayoutMode_inner.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常见问题**

**实际 X、实际 Y、实际宽度和实际高度以什么单位返回？**

以点（points）为单位；1 英寸 = 72 点。这些是 Aspose.Slides 的坐标单位。

**绘图区与图表区域在内容上有何区别？**

绘图区是数据绘制区域（系列、网格线、趋势线等）；图表区域包括周围的元素（标题、图例等）。在三维图表中，绘图区还包括墙面/底面和坐标轴。

**当布局手动时，绘图区的 X、Y、宽度和高度如何解释？**

它们是图表整体大小的比例（0–1）；在此模式下，自动定位被禁用，使用您设置的比例值。

**为何在添加或移动图例后绘图区位置会变化？**

图例位于图表区域的绘图区之外，但会影响布局和可用空间，因此在自动定位生效时，绘图区可能会移动。（这是 PowerPoint 图表的标准行为。）