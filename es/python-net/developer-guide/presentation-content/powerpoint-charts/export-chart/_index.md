---
title: Exportar Gráfico
type: docs
weight: 90
url: /python-net/export-chart/
keywords:
- gráfico
- imagen del gráfico
- extraer imagen del gráfico
- PowerPoint
- presentación
- Python
- Aspose.Slides para Python
description: "Obtenga imágenes de gráficos de presentaciones de PowerPoint en Python"
---

## **Obtener Imagen del Gráfico**
Aspose.Slides para Python a través de .NET proporciona soporte para extraer la imagen de un gráfico específico. A continuación se presenta un ejemplo de muestra.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("test.pptx") as presentation:
	slide = presentation.slides[0]
	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
	
	with chart.get_image() as image:
		image.save("image.png", slides.ImageFormat.PNG)
```