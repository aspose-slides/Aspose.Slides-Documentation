---
title: Export Chart
type: docs
weight: 90
url: /pythonnet/export-chart/
keywords: "Chart, chart image, extract chart image,s PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "Get chart images in PowerPoint presentation in Python"
---

## **Get Chart Image**
Aspose.Slides for Python via .NET provides support for extracting image of specific chart. Below sample example is given. 

```py
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
	Image img = chart.GetThumbnail();
	img.Save("image.png", ImageFormat.Png);
}
```