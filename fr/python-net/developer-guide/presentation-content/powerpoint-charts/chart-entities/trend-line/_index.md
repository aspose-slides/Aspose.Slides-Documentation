---
title: Ajouter des lignes de tendance aux graphiques de présentation en Python
linktitle: Ligne de tendance
type: docs
url: /fr/python-net/trend-line/
keywords:
- graphique
- ligne de tendance
- ligne de tendance exponentielle
- ligne de tendance linéaire
- ligne de tendance logarithmique
- ligne de tendance moyenne mobile
- ligne de tendance polynomiale
- ligne de tendance puissance
- ligne de tendance personnalisée
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Ajoutez rapidement et personnalisez des lignes de tendance dans les graphiques PowerPoint et OpenDocument avec Aspose.Slides pour Python via .NET — un guide pratique et des exemples de code pour améliorer la précision des prévisions et capter l’attention de votre audience."
---
## **Ajouter une ligne de tendance**
Aspose.Slides pour Python via .NET propose une API simple pour gérer différentes lignes de tendance de graphiques :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez la référence d’une diapositive par son indice.
3. Ajoutez un graphique avec des données par défaut ainsi que le type souhaité (cet exemple utilise ChartType.CLUSTERED_COLUMN).
4. Ajoutez une ligne de tendance exponentielle pour la série 1 du graphique.
5. Ajoutez une ligne de tendance linéaire pour la série 1 du graphique.
6. Ajoutez une ligne de tendance logarithmique pour la série 2 du graphique.
7. Ajoutez une ligne de tendance moyenne mobile pour la série 2 du graphique.
8. Ajoutez une ligne de tendance polynomiale pour la série 3 du graphique.
9. Ajoutez une ligne de tendance puissance pour la série 3 du graphique.
10. Enregistrez la présentation modifiée dans un fichier PPTX.

Le code suivant crée un graphique avec des lignes de tendance.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Création d'une présentation vide
with slides.Presentation() as pres:

    # Création d'un graphique à colonnes groupées
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 400)

    # Ajout d'une ligne de tendance exponentielle pour la série 1 du graphique
    tredLinep = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.EXPONENTIAL)
    tredLinep.display_equation = False
    tredLinep.display_r_squared_value = False

    # Ajout d'une ligne de tendance linéaire pour la série 1 du graphique
    tredLineLin = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.LINEAR)
    tredLineLin.trendline_type = charts.TrendlineType.LINEAR
    tredLineLin.format.line.fill_format.fill_type = slides.FillType.SOLID
    tredLineLin.format.line.fill_format.solid_fill_color.color = draw.Color.red


    # Ajout d'une ligne de tendance logarithmique pour la série 2 du graphique
    tredLineLog = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.LOGARITHMIC)
    tredLineLog.trendline_type = charts.TrendlineType.LOGARITHMIC
    tredLineLog.add_text_frame_for_overriding("New log trend line")

    # Ajout d'une ligne de tendance moyenne mobile pour la série 2 du graphique
    tredLineMovAvg = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.MOVING_AVERAGE)
    tredLineMovAvg.trendline_type = charts.TrendlineType.MOVING_AVERAGE
    tredLineMovAvg.period = 3
    tredLineMovAvg.trendline_name = "New TrendLine Name"

    # Ajout d'une ligne de tendance polynomiale pour la série 3 du graphique
    tredLinePol = chart.chart_data.series[2].trend_lines.add(charts.TrendlineType.POLYNOMIAL)
    tredLinePol.trendline_type = charts.TrendlineType.POLYNOMIAL
    tredLinePol.forward = 1
    tredLinePol.order = 3

    # Ajout d'une ligne de tendance puissance pour la série 3 du graphique
    tredLinePower = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.POWER)
    tredLinePower.trendline_type = charts.TrendlineType.POWER
    tredLinePower.backward = 1

    # Enregistrement de la présentation
    pres.save("Charttrend_lines_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ajouter une ligne personnalisée**
Aspose.Slides pour Python via .NET propose une API simple pour ajouter des lignes personnalisées dans un graphique. Pour ajouter une ligne simple à une diapositive sélectionnée de la présentation, suivez les étapes ci‑dessous :

- Créez une instance de la classe Presentation
- Obtenez la référence d’une diapositive à l’aide de son indice
- Créez un nouveau graphique à l’aide de la méthode AddChart exposée par l’objet Shapes
- Ajoutez une AutoShape de type Ligne à l’aide de la méthode AddAutoShape exposée par l’objet Shapes
- Définissez la couleur des lignes de la forme.
- Enregistrez la présentation modifiée sous forme de fichier PPTX

Le code suivant crée un graphique avec des lignes personnalisées.

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

## **FAQ**

**Que signifient « forward » et « backward » pour une ligne de tendance ?**

Ce sont les longueurs de la ligne de tendance projetées respectivement vers l’avant et vers l’arrière : pour les graphiques de dispersion (XY) – en unités d’axe ; pour les graphiques non‑dispersion – en nombre de catégories. Seules les valeurs non négatives sont autorisées.

**La ligne de tendance sera‑t‑elle conservée lors de l’exportation de la présentation au format PDF ou SVG, ou lors du rendu d’une diapositive en image ?**

Oui. Aspose.Slides convertit les présentations en [PDF](/slides/fr/python-net/convert-powerpoint-to-pdf/)/[SVG](/slides/fr/python-net/render-a-slide-as-an-svg-image/) et rend les graphiques en images ; les lignes de tendance, en tant que partie du graphique, sont préservées lors de ces opérations. Une méthode permet également d’[exporter une image du graphique](/slides/fr/python-net/create-shape-thumbnails/).