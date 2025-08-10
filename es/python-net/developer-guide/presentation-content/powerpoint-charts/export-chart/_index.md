---
title: Exportar gráficos de presentaciones con Python
linktitle: Exportar gráfico
type: docs
weight: 90
url: /es/python-net/export-chart/
keywords:
- gráfico
- gráfico a imagen
- gráfico como imagen
- extraer imagen de gráfico
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Aprenda a exportar gráficos de presentaciones con Aspose.Slides for Python via .NET, compatible con los formatos PPT, PPTX y ODP, y agilice la generación de informes en cualquier flujo de trabajo."
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