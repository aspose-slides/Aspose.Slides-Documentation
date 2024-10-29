---
title: 导出图表
type: docs
weight: 90
url: /zh/python-net/export-chart/
keywords:
- 图表
- 图表图像
- 提取图表图像
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides for Python
description: "在Python中从PowerPoint演示文稿获取图表图像"
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