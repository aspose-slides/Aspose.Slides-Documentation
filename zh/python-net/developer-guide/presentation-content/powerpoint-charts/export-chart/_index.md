---
title: 使用 Python 导出演示文稿图表
linktitle: 导出图表
type: docs
weight: 90
url: /zh/python-net/export-chart/
keywords:
- 图表
- 图表转图片
- 图表为图片
- 提取图表图片
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 导出演示文稿图表，支持 PPT、PPTX 和 ODP 格式，并将报告流程简化至任何工作流。"
---

## **获取图表图像**
Aspose.Slides for Python via .NET 提供了提取特定图表图像的支持。下面给出示例代码。
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

**我可以将图表导出为矢量（SVG）而不是光栅图像吗？**

是的。图表是形状，其内容可以使用[形状转SVG保存方法](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/write_as_svg/)保存为 SVG。

**如何设置导出图表的准确像素尺寸？**

使用允许指定尺寸或比例的图像渲染重载——库支持按给定的宽高/比例渲染对象。

**导出后标签和图例中的字体显示不正确，我该怎么办？**

通过[FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/)【[加载所需字体](/slides/zh/python-net/custom-font/)】以确保图表渲染时保持度量和文字外观。

**导出是否遵循 PowerPoint 主题、样式和效果？**

是的。Aspose.Slides 的渲染器遵循演示文稿的格式设置（主题、样式、填充、效果），因此图表外观得以保留。

**在哪里可以找到除图表图像之外的渲染/导出功能？**

请参阅[API](https://reference.aspose.com/slides/python-net/aspose.slides.export/)/[文档](/slides/zh/python-net/convert-powerpoint/)的导出章节，了解可用的输出目标（[PDF](/slides/zh/python-net/convert-powerpoint-to-pdf/)、[SVG](/slides/zh/python-net/render-a-slide-as-an-svg-image/)、[XPS](/slides/zh/python-net/convert-powerpoint-to-xps/)、[HTML](/slides/zh/python-net/convert-powerpoint-to-html/)等）以及相关渲染选项。