---
title: 使用 Python 导出演示文稿图表
linktitle: 导出图表
type: docs
weight: 90
url: /zh/python-net/export-chart/
keywords:
- 图表
- 图表转为图像
- 将图表作为图像
- 提取图表图像
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 导出演示文稿中的图表，支持 PPT、PPTX 和 ODP 格式，并将报告无缝集成到任何工作流中。"
---

## **获取图表图像**
Aspose.Slides for Python via .NET 提供了提取特定图表图像的支持。以下是示例代码。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("test.pptx") as presentation:
	slide = presentation.slides[0]
	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
	
	with chart.get_image() as image:
		image.save("image.png", slides.ImageFormat.PNG)
```