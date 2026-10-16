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
- ligne de tendance à moyenne mobile
- ligne de tendance polynomiale
- ligne de tendance puissance
- ligne de tendance personnalisée
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Ajoutez rapidement et personnalisez des lignes de tendance dans les graphiques PowerPoint avec Aspose.Slides pour Python via .NET — un guide pratique pour captiver votre audience."
---
## **Vue d'ensemble**

Cet article explique comment ajouter des lignes de tendance aux graphiques de présentation en utilisant Aspose.Slides. Il montre comment créer un graphique, ajouter des lignes de tendance aux séries du graphique et travailler avec plusieurs types de lignes de tendance, notamment exponentielle, linéaire, logarithmique, moyenne mobile, polynomiale et puissance.

Il décrit également comment ajouter une ligne personnalisée à un graphique en insérant une forme de ligne, et comprend une courte FAQ sur les valeurs de projection en avant et en arrière des lignes de tendance ainsi que sur la préservation des lignes de tendance lors de l'exportation en PDF ou SVG et lors du rendu de graphiques en images.

## **Ajouter une ligne de tendance**

Utilisez [TrendlineCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendlinecollection/add/) pour ajouter une ligne de tendance à une série de graphique, en sélectionnant son type avec [TrendlineType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendlinetype/). L'exemple crée un graphique à colonnes groupées avec des données par défaut et ajoute deux lignes de tendance à chacune de ses trois séries.

La ligne de tendance exponentielle masque son équation et sa valeur R² via [display_equation](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/display_equation/) et [display_r_squared_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/display_r_squared_value/), tandis que la ligne de tendance linéaire est rouge. La ligne de tendance logarithmique utilise [add_text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/add_text_frame_for_overriding/) pour une étiquette personnalisée. La moyenne mobile utilise une [period](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/period/) de trois points de données et un [trendline_name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/trendline_name/) personnalisé.

La ligne de tendance polynomiale possède un [order](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/order/) de trois et s'étend d'une catégorie vers l'avant via [forward](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/forward/). La ligne de tendance puissance s'étend d'une catégorie vers l'arrière via [backward](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/backward/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 400)

    first_series = chart.chart_data.series[0]

    exponential_trendline = first_series.trend_lines.add(charts.TrendlineType.EXPONENTIAL)
    exponential_trendline.display_equation = False
    exponential_trendline.display_r_squared_value = False

    linear_trendline = first_series.trend_lines.add(charts.TrendlineType.LINEAR)
    linear_trendline.format.line.fill_format.fill_type = slides.FillType.SOLID
    linear_trendline.format.line.fill_format.solid_fill_color.r = 255
    linear_trendline.format.line.fill_format.solid_fill_color.g = 0
    linear_trendline.format.line.fill_format.solid_fill_color.b = 0

    second_series = chart.chart_data.series[1]

    logarithmic_trendline = second_series.trend_lines.add(charts.TrendlineType.LOGARITHMIC)
    logarithmic_trendline.add_text_frame_for_overriding("New log trend line")

    moving_average_trendline = second_series.trend_lines.add(charts.TrendlineType.MOVING_AVERAGE)
    moving_average_trendline.period = 3
    moving_average_trendline.trendline_name = "New TrendLine Name"

    third_series = chart.chart_data.series[2]

    polynomial_trendline = third_series.trend_lines.add(charts.TrendlineType.POLYNOMIAL)
    polynomial_trendline.forward = 1
    polynomial_trendline.order = 3

    power_trendline = third_series.trend_lines.add(charts.TrendlineType.POWER)
    power_trendline.backward = 1

    presentation.save("ChartTrendLines.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir l'ordonnée à l'origine d'une ligne de tendance**

Utilisez [intercept](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/intercept/) pour fixer la valeur Y d'une ligne de tendance à X = 0. Ce paramètre est pris en charge pour les lignes de tendance linaires, exponentielles et polynomiales.

Par exemple, un modèle de coût de production peut devoir démarrer à des coûts fixes connus de 100, même lorsque des mesures à des volumes de production différents de zéro suggèrent une base différente. Pour une ligne de tendance linéaire, fixer l'ordonnée à l'origine contraint l'équation `y = ax + b` à `b = 100` ; la pente est ajustée aux données sous cette contrainte. Cela ne déplace pas simplement une ligne déjà ajustée. Les paramètres de croisement des axes contrôlent où les axes du graphique se rencontrent, pas les coefficients de la ligne de tendance ajustée.

L'exemple suivant crée un graphique en nuage de points (XY) avec des volumes de production de 1 à 4 et des coûts de 170, 200, 230 et 260. Il enregistre le graphique avec l'ordonnée à l'origine automatique par défaut, fixe l'ordonnée à 100 et enregistre un second PPTX. Les deux fichiers ne diffèrent que par le réglage de l'ordonnée à l'origine. La ligne de tendance affiche son équation et s'étend jusqu'à X = 0.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.SCATTER_WITH_MARKERS, 20, 20, 480, 210)
    chart.has_legend = False

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    name_cell = workbook.get_cell(0, 0, 1, "Production cost")
    series = chart.chart_data.series.add(name_cell, charts.ChartType.SCATTER_WITH_MARKERS)
    costs = [170, 200, 230, 260]

    for i, cost in enumerate(costs):
        x_cell = workbook.get_cell(0, i + 1, 0, i + 1)
        y_cell = workbook.get_cell(0, i + 1, 1, cost)
        series.data_points.add_data_point_for_scatter_series(x_cell, y_cell)

    trendline = series.trend_lines.add(charts.TrendlineType.LINEAR)
    trendline.display_equation = True
    trendline.backward = 1

    presentation.save("AutomaticIntercept.pptx", slides.export.SaveFormat.PPTX)

    trendline.intercept = 100
    presentation.save("FixedIntercept.pptx", slides.export.SaveFormat.PPTX)
```

Avec le calcul automatique, ces données génèrent `y = 30x + 140`. Fixer l'ordonnée à 100 produit plutôt approximativement `y = 43.33x + 100` : la valeur ajustée à zéro correspond à la base connue, tandis que la ligne ne passe plus par chaque point de donnée.

| Ordonnée à l'origine automatique | Ordonnée à l'origine fixe de 100 |
| --- | --- |
| ![Ligne de tendance linéaire avec une ordonnée à l'origine calculée automatiquement de 140](intercept-automatic.png) | ![Ligne de tendance linéaire avec une ordonnée à l'origine fixe de 100](intercept-fixed.png) |

Les deux images utilisent les mêmes données et les mêmes échelles d'axes. Les lignes de tendance sont prolongées jusqu'à X = 0 pour afficher leurs ordonnées à l'origine.

Par défaut, la propriété contient `float("nan")`, ce qui représente une ordonnée à l'origine non spécifiée plutôt que zéro. L'ordonnée à l'origine est alors calculée automatiquement à partir des données.

## **Ajouter une ligne personnalisée**

Une ligne personnalisée est une forme dessinée au-dessus du graphique plutôt qu'une ligne de tendance calculée à partir des données de la série. Cet exemple utilise [ShapeCollection.add_auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_auto_shape/) pour ajouter une ligne horizontale à la diapositive au-dessus du graphique. La position de la ligne est spécifiée en coordonnées de diapositive, mesurées en points, ainsi elle commence au bord gauche du graphique et se situe à mi-hauteur du graphique. Sa largeur correspond à celle du graphique. Le [line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) donne à la ligne une couleur rouge unie.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)

    line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, chart.x, chart.y + chart.height / 2, chart.width, 0)
    line.line_format.fill_format.fill_type = slides.FillType.SOLID
    line.line_format.fill_format.solid_fill_color.r = 255
    line.line_format.fill_format.solid_fill_color.g = 0
    line.line_format.fill_format.solid_fill_color.b = 0

    presentation.save("AddCustomLines.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Que signifient 'forward' et 'backward' pour une ligne de tendance ?**

Il s'agit des longueurs de la ligne de tendance projetées en avant/en arrière : pour les graphiques en nuage de points (XY) — en unités d'axes ; pour les graphiques non nuage de points — en nombre de catégories. Seules les valeurs non négatives sont autorisées.

**La ligne de tendance sera-t-elle conservée lors de l'exportation de la présentation en PDF ou SVG, ou lors du rendu d'une diapositive en image ?**

Oui. Aspose.Slides convertit les présentations en [PDF](/slides/fr/python-net/convert-powerpoint-to-pdf/) ou en [SVG](/slides/fr/python-net/render-a-slide-as-an-svg-image/) et rend les graphiques en images ; les lignes de tendance, en tant que partie du graphique, sont conservées pendant ces opérations. Une méthode est également disponible pour [exporter une image du graphique](/slides/fr/python-net/create-shape-thumbnails/) elle‑même.