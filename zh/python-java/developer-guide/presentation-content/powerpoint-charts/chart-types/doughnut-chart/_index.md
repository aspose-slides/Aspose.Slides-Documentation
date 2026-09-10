---
title: 使用 Python via Java 在演示文稿中定制环形图
linktitle: 环形图
type: docs
weight: 30
url: /zh/python-java/doughnut-chart/
keywords:
- 环形图
- 中心间隙
- 孔大小
- PowerPoint
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Python via Java 中创建和定制环形图，支持 PowerPoint 格式的动态演示文稿。"
---
## **概述**

本文展示了如何在 Aspose.Slides 中使用环形图，包括将图表添加到幻灯片、设置中心孔的大小以及保存演示文稿。重点介绍了 [setDoughnutHoleSize](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartseriesgroup/#setDoughnutHoleSize) 方法，并演示了在代码中自定义此图表类型的基本步骤。

文中还包含了简短的 FAQ，涉及相关的环形图场景，例如使用多个系列创建多个环、处理炸裂环形图以及将图表导出为光栅图像或 SVG。

## **指定环形图的中心间隙**

{{% alert color="info" title="注意" %}}

Aspose.Slides for Python via Java 支持指定环形图中心孔的大小。本节通过示例演示如何指定孔的大小。

{{% /alert %}}

要指定环形图中心孔的大小，请按照以下步骤操作：

1. 实例化一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 对象。
2. 向幻灯片添加环形图。
3. 指定环形图中心孔的大小。
4. 将演示文稿写入磁盘。

以下示例演示了如何设置环形图中心孔的大小。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# 创建 Presentation 类的实例。
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400)
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize(jpype.JByte(90))

    # 将演示文稿写入磁盘。
    presentation.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常见问题**

**可以创建具有多个环的多层环形图吗？**

可以。向单个环形图添加多个系列——每个系列都会成为一个独立的环。环的顺序由系列在集合中的顺序决定。

**是否支持“炸裂”环形图（分离的切片）？**

支持。有炸裂环形图 [chart type](https://reference.aspose.com/slides/zh/python-java/aspose.slides/charttype/) 并且数据点上有爆炸属性；您可以单独分离切片。

**如何获取环形图的图像（PNG/SVG）用于报告？**

图表是一个 [shape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/)；您可以将其渲染为 [raster image](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#getImage) 或导出为 SVG 图像。