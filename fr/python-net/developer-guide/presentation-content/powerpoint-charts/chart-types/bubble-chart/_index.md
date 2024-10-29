---
title: Graphique en bulles
type: docs
url: /fr/python-net/bubble-chart/
keywords: "Graphique en bulles, taille du graphique, présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Taille des graphiques en bulles dans les présentations PowerPoint en Python"
---

## **Mise à l'échelle de la taille des graphiques en bulles**
Aspose.Slides pour Python via .NET prend en charge la mise à l'échelle de la taille des graphiques en bulles. Dans Aspose.Slides pour Python via .NET, les propriétés **ChartSeries.bubble_size_scale** et **ChartSeriesGroup.bubble_size_scale** ont été ajoutées. Un exemple d'échantillon est donné ci-dessous.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 100, 100, 400, 300)
	chart.chart_data.series_groups[0].bubble_size_scale = 150
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```




## **Représenter des données sous forme de tailles de graphique en bulles**
La propriété **bubble_size_representation** a été ajoutée aux classes ChartSeries et ChartSeriesGroup. **bubble_size_representation** spécifie comment les valeurs de taille des bulles sont représentées dans le graphique en bulles. Les valeurs possibles sont : **BubbleSizeRepresentationType.AREA** et **BubbleSizeRepresentationType.WIDTH**. En conséquence, l'énumération **BubbleSizeRepresentationType** a été ajoutée pour spécifier les méthodes possibles pour représenter des données sous forme de tailles de graphique en bulles. Un code d'exemple est donné ci-dessous.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    chart.chart_data.series_groups[0].bubble_size_representation = charts.BubbleSizeRepresentationType.WIDTH
    pres.save("Presentation_BubbleSizeRepresentation.pptx", slides.export.SaveFormat.PPTX)
```