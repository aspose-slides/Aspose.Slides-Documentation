---
title: Personnaliser les graphiques 3D dans les présentations avec Python
linktitle: Graphique 3D
type: docs
url: /fr/python-net/3d-chart/
keywords:
- graphique 3d
- rotation
- profondeur
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Apprenez à créer et personnaliser des graphiques 3D dans Aspose.Slides pour Python via .NET, avec prise en charge des fichiers PPT, PPTX et ODP—boostez vos présentations dès aujourd'hui."
---

## **Définir les propriétés RotationX, RotationY et DepthPercents d'un graphique 3D**
Aspose.Slides for Python via .NET fournit une API simple pour définir ces propriétés. Cet article vous aidera à définir différentes propriétés telles que la rotation X,Y, **DepthPercents**, etc. Le code d'exemple montre comment appliquer ces paramètres.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Accédez à la première diapositive.
1. Ajoutez un graphique avec des données par défaut.
1. Définissez les propriétés Rotation3D.
1. Enregistrez la présentation modifiée dans un fichier PPTX.
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Créer une instance de la classe Presentation
with slides.Presentation() as presentation:
            
    # Accédez à la première diapositive
    slide = presentation.slides[0]

    # Ajoutez un graphique avec des données par défaut
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    # Définition de l'index de la feuille de données du graphique
    defaultWorksheetIndex = 0

    # Obtention de la feuille de calcul des données du graphique
    fact = chart.chart_data.chart_data_workbook

    # Ajouter des séries
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.type)

    # Ajouter des catégories
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"))

    # Définir les propriétés Rotation3D
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    # Prendre la deuxième série du graphique
    series = chart.chart_data.series[1]

    # Maintenant, remplissage des données de la série
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 2, 60))

    # Définir la valeur OverLap
    series.parent_series_group.overlap = 100         

    # Enregistrer la présentation sur le disque
    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Quels types de graphiques prennent en charge le mode 3D dans Aspose.Slides ?**

Aspose.Slides prend en charge les variantes 3D des graphiques en colonnes, notamment Column 3D, Clustered Column 3D, Stacked Column 3D et 100 % Stacked Column 3D, ainsi que les types 3D associés exposés via l'énumération [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/). Pour obtenir une liste précise et à jour, consultez les membres de [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) dans la référence API de la version installée.

**Puis-je obtenir une image raster d'un graphique 3D pour un rapport ou le web ?**

Oui. Vous pouvez exporter un graphique en image via l'[API de graphique](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/get_image/) ou [rendre la diapositive entière](/slides/fr/python-net/convert-powerpoint-to-png/) dans des formats tels que PNG ou JPEG. Cela est utile lorsque vous avez besoin d’un aperçu pixel‑perfect ou que vous souhaitez intégrer le graphique dans des documents, tableaux de bord ou pages web sans nécessiter PowerPoint.

**Quelle est la performance de la création et du rendu de grands graphiques 3D ?**

Les performances dépendent du volume de données et de la complexité visuelle. Pour de meilleurs résultats, limitez les effets 3D, évitez les textures lourdes sur les murs et les zones de tracé, réduisez le nombre de points de données par série lorsque cela est possible, et rendez la sortie à une taille appropriée (résolution et dimensions) pour correspondre à l’affichage ou à l’impression cible.