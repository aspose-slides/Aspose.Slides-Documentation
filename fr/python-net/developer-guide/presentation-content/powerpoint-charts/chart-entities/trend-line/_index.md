---
title: Ligne de Tendance
type: docs
url: /fr/python-net/trend-line/
keywords: "Ligne de tendance, ligne personnalisée présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Ajouter une ligne de tendance et une ligne personnalisée aux présentations PowerPoint en Python"
---

## **Ajouter une Ligne de Tendance**
Aspose.Slides pour Python via .NET fournit une API simple pour gérer différentes Lignes de Tendance de graphique :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son index.
1. Ajouter un graphique avec des données par défaut avec le type souhaité (cet exemple utilise ChartType.CLUSTERED_COLUMN).
1. Ajouter une ligne de tendance exponentielle pour la série de graphique 1.
1. Ajouter une ligne de tendance linéaire pour la série de graphique 1.
1. Ajouter une ligne de tendance logarithmique pour la série de graphique 2.
1. Ajouter une ligne de tendance de moyenne mobile pour la série de graphique 2.
1. Ajouter une ligne de tendance polynomiale pour la série de graphique 3.
1. Ajouter une ligne de tendance puissance pour la série de graphique 3.
1. Écrire la présentation modifiée dans un fichier PPTX.

Le code suivant est utilisé pour créer un graphique avec des Lignes de Tendance.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Création d'une présentation vide
with slides.Presentation() as pres:

    # Création d'un graphique en colonnes groupées
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 400)

    # Ajout d'une ligne de tendance exponentielle pour la série de graphique 1
    tredLinep = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.EXPONENTIAL)
    tredLinep.display_equation = False
    tredLinep.display_r_squared_value = False

    # Ajout d'une ligne de tendance linéaire pour la série de graphique 1
    tredLineLin = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.LINEAR)
    tredLineLin.trendline_type = charts.TrendlineType.LINEAR
    tredLineLin.format.line.fill_format.fill_type = slides.FillType.SOLID
    tredLineLin.format.line.fill_format.solid_fill_color.color = draw.Color.red


    # Ajout d'une ligne de tendance logarithmique pour la série de graphique 2
    tredLineLog = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.LOGARITHMIC)
    tredLineLog.trendline_type = charts.TrendlineType.LOGARITHMIC
    tredLineLog.add_text_frame_for_overriding("Nouvelle ligne de tendance logarithmique")

    # Ajout d'une ligne de tendance de moyenne mobile pour la série de graphique 2
    tredLineMovAvg = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.MOVING_AVERAGE)
    tredLineMovAvg.trendline_type = charts.TrendlineType.MOVING_AVERAGE
    tredLineMovAvg.period = 3
    tredLineMovAvg.trendline_name = "Nouveau nom de ligne de tendance"

    # Ajout d'une ligne de tendance polynomiale pour la série de graphique 3
    tredLinePol = chart.chart_data.series[2].trend_lines.add(charts.TrendlineType.POLYNOMIAL)
    tredLinePol.trendline_type = charts.TrendlineType.POLYNOMIAL
    tredLinePol.forward = 1
    tredLinePol.order = 3

    # Ajout d'une ligne de tendance puissance pour la série de graphique 3
    tredLinePower = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.POWER)
    tredLinePower.trendline_type = charts.TrendlineType.POWER
    tredLinePower.backward = 1

    # Sauvegarde de la présentation
    pres.save("Charttrend_lines_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Ajouter une Ligne Personnalisée**
Aspose.Slides pour Python via .NET fournit une API simple pour ajouter des lignes personnalisées dans un graphique. Pour ajouter une simple ligne droite à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci-dessous :

- Créer une instance de la classe Presentation
- Obtenir la référence d'une diapositive en utilisant son index
- Créer un nouveau graphique en utilisant la méthode AddChart exposée par l'objet Shapes
- Ajouter une AutoShape de type Ligne en utilisant la méthode AddAutoShape exposée par l'objet Shapes
- Définir la couleur des lignes de la forme.
- Écrire la présentation modifiée en tant que fichier PPTX

Le code suivant est utilisé pour créer un graphique avec des Lignes Personnalisées.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    shape = chart.user_shapes.shapes.add_auto_shape(slides.ShapeType.LINE, 0, chart.height / 2, chart.width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
    pres.save("AddCustomLines.pptx", slides.export.SaveFormat.PPTX)
```