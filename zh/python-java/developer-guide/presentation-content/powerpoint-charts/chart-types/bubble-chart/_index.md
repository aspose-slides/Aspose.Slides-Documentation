---
title: 使用 Python 在演示文稿中自定义气泡图
linktitle: 气泡图
type: docs
url: /zh/python-java/bubble-chart/
keywords:
- 气泡图
- 气泡大小
- 大小缩放
- 大小表示
- PowerPoint
- 演示文稿
- Python
- Java
- Aspose.Slides
description: 使用 Aspose.Slides for Python via Java 在 PowerPoint 中创建并自定义强大的气泡图，轻松提升数据可视化效果。
---
## **概述**

本文展示了如何在 Aspose.Slides 中使用气泡图。它涵盖了两个特定的自定义选项：通过 [setBubbleSizeScale](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeScale) 方法对气泡大小进行缩放，以及通过 [setBubbleSizeRepresentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeRepresentation) 方法控制气泡大小值的表示方式。

示例演示了如何创建气泡图、调整其大小缩放以及将气泡大小表示切换为使用宽度。文章还包含一个简短的 FAQ 部分，阐明了对 “Bubble with 3-D” 图表类型的支持，指出实际图表限制取决于性能和目标 PowerPoint 版本，并解释导出通过 Aspose.Slides 渲染引擎保留图表外观。

## **气泡图大小缩放**
Aspose.Slides for Python via Java 支持通过 [ChartSeries.getBubbleSizeScale](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartseries/#getBubbleSizeScale)、[ChartSeriesGroup.getBubbleSizeScale](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartseriesgroup/#getBubbleSizeScale) 和 [ChartSeriesGroup.setBubbleSizeScale](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeScale) 方法对气泡图大小进行缩放。以下示例展示了如何缩放气泡大小。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 100, 100, 400, 300)

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150)

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **将数据表示为气泡图大小**
ChartSeriesGroup 类中提供了 [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeRepresentation) 和 [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartseriesgroup/#getBubbleSizeRepresentation) 方法。气泡大小表示指定了气泡图中气泡大小值的表现方式。可能的取值有 [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/zh/python-java/aspose.slides/bubblesizerepresentationtype/#Area) 和 [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/zh/python-java/aspose.slides/bubblesizerepresentationtype/#Width)。[**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/zh/python-java/aspose.slides/bubblesizerepresentationtype/) 枚举定义了将数据表示为气泡图大小的可能方式。以下示例展示了如何使用宽度来表示气泡大小。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BubbleSizeRepresentationType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, True)

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(BubbleSizeRepresentationType.Width)

    presentation.save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常见问题**

**是否支持 “带 3-D 效果的气泡图”，并且它与普通气泡图有何区别？**

是的。有一种独立的图表类型 “Bubble with 3-D”。它为气泡应用 3-D 样式，但不会添加额外的坐标轴；数据仍保持 X-Y-S（size）结构。该类型可在 [chart type](https://reference.aspose.com/slides/zh/python-java/aspose.slides/charttype/) 类中使用。

**气泡图中系列和数据点的数量是否有限制？**

在 API 层面没有硬性限制；约束取决于性能和目标 PowerPoint 版本。建议保持数据点数量在合理范围，以利于可读性和渲染速度。

**导出（PDF、图像）会如何影响气泡图的外观？**

导出为受支持的格式会保留图表外观；渲染由 Aspose.Slides 引擎完成。对于栅格/矢量格式，遵循一般的图表渲染规则（分辨率、抗锯齿），因此请为打印选择足够的 DPI。