---
title: Personnaliser les graphiques en anneau dans les présentations avec Python
linktitle: Graphique en anneau
type: docs
weight: 30
url: /fr/python-net/doughnut-chart/
keywords:
- graphique en anneau
- écart central
- taille du trou
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Découvrez comment créer et personnaliser des graphiques en anneau dans Aspose.Slides pour Python via .NET, prenant en charge les formats PowerPoint et OpenDocument pour des présentations dynamiques."
---

## **Spécifier l'écart central dans le graphique en anneau**
Afin de spécifier la taille du trou dans un graphique en anneau, veuillez suivre les étapes ci-dessous :

- Instancier la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
- Ajouter un graphique en anneau sur la diapositive.
- Spécifier la taille du trou dans le graphique en anneau.
- Enregistrer la présentation sur le disque.

Dans l'exemple ci-dessous, nous avons défini la taille du trou dans le graphique en anneau.
```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Créez une instance de la classe Presentation
with slides.Presentation() as presentation:

    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.DOUGHNUT, 50, 50, 400, 400)
    chart.chart_data.series_groups[0].doughnut_hole_size = 90

    # Enregistrez la présentation sur le disque
    presentation.save("DoughnutHoleSize_out.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Puis-je créer un anneau à plusieurs niveaux avec plusieurs cercles ?**

Oui. Ajoutez plusieurs séries à un même graphique en anneau — chaque série devient un anneau distinct. L'ordre des anneaux est déterminé par l'ordre des séries dans la collection.

**Un anneau « explosé » (parts séparées) est‑il supporté ?**

Oui. Il existe un type de graphique Exploded Doughnut [chart type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) et une propriété d'explosion sur les points de données ; vous pouvez séparer les parts individuelles.

**Comment obtenir une image d'un graphique en anneau (PNG/SVG) pour un rapport ?**

Un graphique est une forme ; vous pouvez le rendre sous forme d'[image raster](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) ou exporter le graphique vers une [image SVG](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/).