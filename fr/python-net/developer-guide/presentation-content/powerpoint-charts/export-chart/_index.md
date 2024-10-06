---
title: Exporter un Graphique
type: docs
weight: 90
url: /python-net/export-chart/
keywords:
- graphique
- image de graphique
- extraire l'image de graphique
- PowerPoint
- présentation
- Python
- Aspose.Slides pour Python
description: "Obtenez des images de graphiques à partir de présentations PowerPoint en Python"
---

## **Obtenir l'Image du Graphique**
Aspose.Slides pour Python via .NET fournit un support pour l'extraction de l'image d'un graphique spécifique. Un exemple de code est donné ci-dessous.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("test.pptx") as presentation:
	slide = presentation.slides[0]
	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
	
	with chart.get_image() as image:
		image.save("image.png", slides.ImageFormat.PNG)
```