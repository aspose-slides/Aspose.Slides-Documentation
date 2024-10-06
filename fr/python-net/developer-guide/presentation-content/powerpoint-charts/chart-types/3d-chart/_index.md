---
title: Graphique 3D
type: docs
url: /python-net/3d-chart/
keywords: "graphique 3d, rotationX, rotationY, profondeurpourcentage, présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Définir rotationX, rotationY et profondeurpourcentages pour un graphique 3D dans une présentation PowerPoint en Python"
---

## **Définir les propriétés RotationX, RotationY et DepthPercents du graphique 3D**
Aspose.Slides pour Python via .NET fournit une API simple pour définir ces propriétés. Cet article suivant vous aidera à définir différentes propriétés comme la rotation X, Y, **DepthPercents**, etc. Le code d'exemple applique la définition des propriétés susmentionnées.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Accédez à la première diapositive.
1. Ajoutez un graphique avec des données par défaut.
1. Définissez les propriétés Rotation3D.
1. Écrivez la présentation modifiée dans un fichier PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Créer une instance de la classe Presentation
with slides.Presentation() as presentation:
            
    # Accéder à la première diapositive
    slide = presentation.slides[0]

    # Ajouter un graphique avec des données par défaut
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    # Définir l'index de la feuille de données du graphique
    defaultWorksheetIndex = 0

    # Obtenir la feuille de calcul des données du graphique
    fact = chart.chart_data.chart_data_workbook

    # Ajouter des séries
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 1, "Série 1"), chart.type)
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 2, "Série 2"), chart.type)

    # Ajouter des catégories
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 1, 0, "Catégorie 1"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 2, 0, "Catégorie 2"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 3, 0, "Catégorie 3"))

    # Définir les propriétés Rotation3D
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    # Prendre la deuxième série de graphique
    series = chart.chart_data.series[1]

    # Maintenant, peupler les données de la série
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 2, 60))

    # Définir la valeur OverLap
    series.parent_series_group.overlap = 100         

    # Écrire la présentation sur le disque
    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```