---
title: Export Presentation Charts with Python
linktitle: Export Chart
type: docs
weight: 90
url: /python-net/export-chart/
keywords:
- chart
- chart to image
- chart as image
- extract chart image
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Learn how to export presentation charts with Aspose.Slides for Python via .NET, supporting PPT, PPTX and ODP formats, and streamline reporting into any workflow."
---

## **Get Chart Image**
Aspose.Slides for Python via .NET provides support for extracting image of specific chart. Below sample example is given. 

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("test.pptx") as presentation:
	slide = presentation.slides[0]
	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
	
	with chart.get_image() as image:
		image.save("image.png", slides.ImageFormat.PNG)
```
