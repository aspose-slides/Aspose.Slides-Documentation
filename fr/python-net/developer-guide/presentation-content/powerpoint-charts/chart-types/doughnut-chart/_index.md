---
title: Personnaliser les graphiques en anneau dans les présentations avec Python
linktitle: Graphique en anneau
type: docs
weight: 30
url: /fr/python-net/doughnut-chart/
keywords:
- graphique en anneau
- espace central
- taille du trou
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Découvrez comment créer et personnaliser des graphiques en anneau avec Aspose.Slides pour Python via .NET, compatible avec les formats PowerPoint et OpenDocument pour des présentations dynamiques."
---

## **Spécifiez l'Espace Central dans un Graphique en Anneau**
Pour spécifier la taille du trou dans un graphique en anneau, veuillez suivre les étapes ci-dessous :

- Instanciez la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
- Ajoutez un graphique en anneau sur la diapositive.
- Spécifiez la taille du trou dans un graphique en anneau.
- Écrivez la présentation sur le disque.

Dans l'exemple ci-dessous, nous avons défini la taille du trou dans un graphique en anneau.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Créez une instance de la classe Presentation
with slides.Presentation() as presentation:

    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.DOUGHNUT, 50, 50, 400, 400)
    chart.chart_data.series_groups[0].doughnut_hole_size = 90

    # Écrivez la présentation sur le disque
    presentation.save("DoughnutHoleSize_out.pptx", slides.export.SaveFormat.PPTX)
```