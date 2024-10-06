---
title: Graphique en anneau
type: docs
weight: 30
url: /python-net/doughnut-chart/
keywords: "Graphique en anneau, espace central, présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Spécifiez l'espace central dans un graphique en anneau dans une présentation PowerPoint en Python"
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