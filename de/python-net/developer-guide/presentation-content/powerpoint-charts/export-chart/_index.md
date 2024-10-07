---
title: Diagramm exportieren
type: docs
weight: 90
url: /python-net/export-chart/
keywords:
- diagramm
- Diagrammbild
- Diagrammbild extrahieren
- PowerPoint
- Präsentation
- Python
- Aspose.Slides für Python
description: "Diagrammbilder aus PowerPoint-Präsentationen in Python erhalten"
---

## **Diagrammbild erhalten**
Aspose.Slides für Python über .NET bietet Unterstützung zum Extrahieren von Bildern spezifischer Diagramme. Unten steht ein Beispiel.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("test.pptx") as presentation:
	slide = presentation.slides[0]
	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
	
	with chart.get_image() as image:
		image.save("image.png", slides.ImageFormat.PNG)
```