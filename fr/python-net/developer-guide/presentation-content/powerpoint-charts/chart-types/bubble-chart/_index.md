---
title: Personnaliser les graphiques à bulles dans les présentations avec Python
linktitle: Graphique à bulles
type: docs
url: /fr/python-net/bubble-chart/
keywords:
- graphique à bulles
- taille de bulle
- mise à l'échelle de taille
- représentation de taille
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Créez et personnalisez des graphiques à bulles puissants dans PowerPoint et OpenDocument avec Aspose.Slides pour Python via .NET afin d'améliorer facilement votre visualisation de données."
---

## **Mise à l'échelle de la taille des graphiques à bulles**
Aspose.Slides for Python via .NET prend en charge la mise à l'échelle de la taille des graphiques à bulles. Dans Aspose.Slides for Python via .NET, les propriétés **ChartSeries.bubble_size_scale** et **ChartSeriesGroup.bubble_size_scale** ont été ajoutées. L'exemple de code suivant est présenté.  

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 100, 100, 400, 300)
	chart.chart_data.series_groups[0].bubble_size_scale = 150
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```




## **Représenter les données en tant que tailles de graphiques à bulles**
La propriété **bubble_size_representation** a été ajoutée aux classes ChartSeries et ChartSeriesGroup. **bubble_size_representation** indique comment les valeurs de taille de bulle sont représentées dans le graphique à bulles. Les valeurs possibles sont : **BubbleSizeRepresentationType.AREA** et **BubbleSizeRepresentationType.WIDTH**. En conséquence, l'énumération **BubbleSizeRepresentationType** a été ajoutée pour spécifier les différentes manières de représenter les données en tant que tailles de graphiques à bulles. Le code d’exemple est présenté ci‑dessous.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    chart.chart_data.series_groups[0].bubble_size_representation = charts.BubbleSizeRepresentationType.WIDTH
    pres.save("Presentation_BubbleSizeRepresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Un "graphique à bulles avec effet 3D" est‑il pris en charge, et en quoi diffère‑t‑il d’un graphique standard ?**

Oui. Il existe un type de graphique distinct, « Bubble with 3‑D ». Il applique un style 3‑D aux bulles mais n’ajoute pas d’axe supplémentaire ; les données restent X‑Y‑S (taille). Ce type est disponible dans l'énumération [type de graphique](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/).

**Existe‑t‑il une limite au nombre de séries et de points dans un graphique à bulles ?**

Il n'y a pas de limite stricte au niveau de l'API ; les contraintes dépendent des performances et de la version cible de PowerPoint. Il est recommandé de garder un nombre de points raisonnable pour assurer la lisibilité et la vitesse de rendu.

**Comment l'exportation affecte‑t‑elle l'apparence d'un graphique à bulles (PDF, images) ?**

L'exportation vers les formats pris en charge conserve l'apparence du graphique ; le rendu est effectué par le moteur Aspose.Slides. Pour les formats raster/vecteur, les règles générales de rendu des graphiques s'appliquent (résolution, antialiasing), il convient donc de choisir un DPI suffisant pour l'impression.