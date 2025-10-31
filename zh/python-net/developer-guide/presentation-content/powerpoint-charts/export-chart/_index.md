---
title: 使用 Python 导出演示文稿图表
linktitle: 导出图表
type: docs
weight: 90
url: /zh/python-net/export-chart/
keywords:
- 图表
- 图表转图像
- 图表为图像
- 提取图表图像
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 将演示文稿图表导出为图像，支持 PPT、PPTX 和 ODP 格式，并将报告流畅集成到任何工作流中。"
---

## **获取图表图像**
Aspose.Slides for Python via .NET 提供了提取特定图表图像的支持。以下示例演示了如何操作。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("test.pptx") as presentation:
	slide = presentation.slides[0]
	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
	
	with chart.get_image() as image:
		image.save("image.png", slides.ImageFormat.PNG)
```

## **常见问题**

**我可以将图表导出为矢量图（SVG）而不是光栅图像吗？**

是的。图表是一个形状，其内容可以使用[shape-to-SVG 保存方法](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/write_as_svg/)保存为 SVG。

**如何以像素为单位设置导出图表的精确大小？**

使用图像渲染的重载方法，您可以指定尺寸或比例——库支持按给定的尺寸/比例渲染对象。

**导出后如果标签和图例中的字体显示不正确，我该怎么办？**

[加载所需的字体](/slides/zh/python-net/custom-font/) 通过[FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/)确保图表渲染保留度量和文本外观。

**导出是否遵循 PowerPoint 主题、样式和效果？**

是的。Aspose.Slides 的渲染器遵循演示文稿的格式设置（主题、样式、填充、效果），因此图表的外观得以保持。

**在哪里可以找到除图表图像之外的可用渲染/导出功能？**

请参阅[API](https://reference.aspose.com/slides/python-net/aspose.slides.export/)/[文档](/slides/zh/python-net/convert-powerpoint/)的导出部分，以获取输出目标（[PDF](/slides/zh/python-net/convert-powerpoint-to-pdf/)、[SVG](/slides/zh/python-net/render-a-slide-as-an-svg-image/)、[XPS](/slides/zh/python-net/convert-powerpoint-to-xps/)、[HTML](/slides/zh/python-net/convert-powerpoint-to-html/)等）和相关渲染选项。