---
title: Export Chart
type: docs
weight: 90
url: /python-net/export-chart/
keywords: "Chart, chart image, extract chart image,s PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "Get chart images in PowerPoint presentation in Python"
---

## **Get Chart Image**
Aspose.Slides for Python via .NET provides support for extracting image of specific chart. Below sample example is given. 

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    with chart.get_image() as img:
        img.save("image.png", slides.ImageFormat.PNG)
```