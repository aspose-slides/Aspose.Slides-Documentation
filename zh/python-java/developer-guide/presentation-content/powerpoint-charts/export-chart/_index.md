---
title: 通过 Java 的 Python 导出演示文稿图表
linktitle: 导出图表
type: docs
weight: 90
url: /zh/python-java/export-chart/
keywords:
- 图表
- 图表转图像
- 图表作为图像
- 提取图表图像
- PowerPoint
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via Java 导出演示文稿图表，支持 PPT 和 PPTX 格式，并将报告流程简化到任何工作流中。"
---
## **概述**

Aspose.Slides 允许您将演示文稿中的图表导出为图像。本文展示了如何获取图表的图像并保存它，这在需要在 PowerPoint 演示文稿之外重复使用图表视觉效果时非常有用。

除了基本的图像导出工作流，本文还解答了常见的导出相关问题，包括将图表内容保存为 SVG、通过渲染选项控制输出大小、加载字体以保留标签和图例的外观，以及在渲染期间保持原始演示文稿的格式（主题、样式、填充和效果）。

## **获取图表图像**
Aspose.Slides for Python via Java 支持提取特定图表的图像。下面的示例演示了如何进行此操作。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, ImageFormat, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart_image = chart.getImage()
    try:
        chart_image.save("image.jpg", ImageFormat.Jpeg)
    finally:
        chart_image.dispose()
finally:
    presentation.dispose()
```

## **常见问题**

**我可以将图表导出为矢量（SVG）而不是光栅图像吗？**

是的。图表是一种形状，其内容可以使用[shape-to-SVG saving method](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#writeAsSvgToBytes)保存为 SVG。

**如何以像素为单位设置导出图表的精确尺寸？**

使用允许指定尺寸或比例的图像渲染重载——库支持使用给定的尺寸/比例渲染对象。

**如果导出后标签和图例中的字体显示不正确，我该怎么办？**

[Load the required fonts](/slides/zh/python-java/custom-font/) 通过 [FontsLoader](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsloader/) 加载所需的字体，以便在图表渲染时保留度量和文本外观。

**导出是否遵循 PowerPoint 的主题、样式和效果？**

是的。Aspose.Slides 的渲染器遵循演示文稿的格式（主题、样式、填充、效果），因此图表的外观得以保留。

**在哪里可以找到除图表图像之外的可用渲染/导出功能？**

请参阅 [API](https://reference.aspose.com/slides/zh/python-java/aspose.slides/)/[documentation](/slides/zh/python-java/convert-powerpoint/) 了解输出目标（[PDF](/slides/zh/python-java/convert-powerpoint-to-pdf/)、[SVG](/slides/zh/python-java/render-a-slide-as-an-svg-image/)、[XPS](/slides/zh/python-java/convert-powerpoint-to-xps/)、[HTML](/slides/zh/python-java/convert-powerpoint-to-html/) 等）以及相关渲染选项。