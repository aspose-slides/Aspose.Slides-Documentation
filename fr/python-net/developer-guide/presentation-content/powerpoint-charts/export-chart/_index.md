---
title: Exporter des graphiques de présentation avec Python
linktitle: Exporter le graphique
type: docs
weight: 90
url: /fr/python-net/export-chart/
keywords:
- graphique
- graphique en image
- graphique comme image
- extraire image du graphique
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Apprenez à exporter des graphiques de présentation avec Aspose.Slides for Python via .NET, prenant en charge les formats PPT, PPTX et ODP, et optimisez la génération de rapports dans n'importe quel flux de travail."
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