---
title: Personnaliser les graphiques 3D dans les présentations avec Python
linktitle: Graphique 3D
type: docs
url: /fr/python-net/3d-chart/
keywords:
- graphique 3D
- rotation
- profondeur
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Créer des graphiques 3D dans des présentations PowerPoint avec Aspose.Slides pour Python via .NET. Ajuster la rotation, les proportions de hauteur, la profondeur du graphique et l'espacement entre les séries avec des exemples Python."
---
## **Vue d'ensemble**

Aspose.Slides for Python via .NET vous permet de personnaliser la vue d’un diagramme 3D via la propriété [Chart.rotation_3d](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/rotation_3d/). Cet article montre comment ajuster la rotation, les proportions de hauteur, la profondeur, les axes à angle droit et l’espacement entre les séries, puis enregistrer la présentation au format PPTX.

## **Définir la rotation et la profondeur d’un diagramme 3D**

L’exemple ci‑dessous crée une [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) et utilise [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) pour ajouter un diagramme à colonnes empilées 3D à sa première diapositive. Il remplace les séries et catégories par défaut par deux séries contenant trois valeurs chacune. L’index de feuille de calcul `0` identifie la première feuille de données du diagramme ; la ligne `0` contient les noms des séries, et la colonne `0` contient les libellés des catégories.

Les propriétés [rotation_x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_x/) et [rotation_y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_y/) définissent la rotation du diagramme à 40 et 270 degrés respectivement. [depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) définit sa profondeur à 150 % de sa largeur, tandis que [right_angle_axes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/right_angle_axes/) active des axes à angle droit au lieu d’une perspective. La présentation résultante contient le diagramme renseigné avec ces paramètres de vue 3D.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    
    values = [[20, 50, 30], [30, 10, 60]]

    for category_index in range(3):
        category_cell = workbook.get_cell(worksheet_index, category_index + 1, 0, f"Category {category_index + 1}")
        chart.chart_data.categories.add(category_cell)

    for series_index in range(2):
        series_cell = workbook.get_cell(worksheet_index, 0, series_index + 1, f"Series {series_index + 1}")
        series = chart.chart_data.series.add(series_cell, chart.type)

        for category_index in range(3):
            value_cell = workbook.get_cell(worksheet_index, category_index + 1, series_index + 1, values[series_index][category_index])
            series.data_points.add_data_point_for_bar_series(value_cell)

    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ajuster les proportions de hauteur d’un diagramme 3D**

Utilisez [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) pour définir la hauteur d’un diagramme 3D en pourcentage de sa largeur. Cela modifie les proportions de la scène 3D sans redimensionner l’objet diagramme sur la diapositive.

L’exemple suivant crée un diagramme [COLUMN_3D](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) avec les données par défaut : trois séries et quatre catégories. Il enregistre trois présentations avec des proportions de hauteur de 50 %, 100 % et 200 %. La position, la largeur et la hauteur du diagramme restent fixes. Les données, la rotation, la profondeur, l’espacement des séries et le formatage sont identiques dans les trois fichiers ; seule la hauteur en pourcentage varie.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 40, 30, 620, 460)
    chart.rotation_3d.rotation_x = 20
    chart.rotation_3d.rotation_y = 30
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.depth_percents = 100
    chart.chart_data.series[0].parent_series_group.gap_depth = 150

    for height_percent in (50, 100, 200):
        chart.rotation_3d.height_percents = height_percent
        presentation.save(f"chart_height_{height_percent}.pptx", slides.export.SaveFormat.PPTX)
```

Les images suivantes ont été exportées à partir des présentations générées avec Microsoft PowerPoint. Un pourcentage plus petit produit une scène plus plate, tandis qu’un pourcentage plus grand produit une scène plus haute dans le même objet diagramme. PowerPoint peut également ajuster les intervalles des repères d’axe et le positionnement des libellés pour adapter la scène.

| Hauteur : 50 % | Hauteur : 100 % | Hauteur : 200 % |
| --- | --- | --- |
| ![3D column chart with height set to 50 percent of its width](height_percent_50.png) | ![3D column chart with height set to 100 percent of its width](height_percent_100.png) | ![3D column chart with height set to 200 percent of its width](height_percent_200.png) |

Ces propriétés contrôlent différents aspects du diagramme :

| Propriété | Effet |
| --- | --- |
| [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) | Hauteur de la scène 3D en pourcentage de sa largeur. |
| [Chart.height](https://reference.aspose.com/slides/python-net/aspose.slides/shape/height/) | Hauteur de l’objet diagramme sur la diapositive, en points. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | Profondeur de la scène 3D en pourcentage de sa largeur. |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | Espacement entre les séries le long de l’axe de profondeur, en pourcentage de la largeur du marqueur. |

Le réglage de hauteur affecte les diagrammes à colonnes et à barres 3D, y compris les variantes cylindre, cône et pyramide, ainsi que les diagrammes 3D de lignes, de surfaces, de secteurs et de surfaces. La comparaison ci‑dessus utilise le type `COLUMN_3D` vérifié. Ce réglage ne modifie pas l’apparence d’un diagramme 2D `CLUSTERED_COLUMN` ou d’un diagramme `BUBBLE_WITH_3D` ; ces noms sont des membres de l’énumération [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/). Pour d’autres paramètres d’apparence de diagramme, voir [Chart Formatting](/slides/fr/python-net/chart-formatting/).

## **Ajuster l’écart entre les séries**

Utilisez [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) pour contrôler la distance entre les séries de données le long de l’axe de profondeur d’un diagramme 3D, exprimée en pourcentage de la largeur du marqueur. Utilisez des valeurs de **0 à 500**, inclusivement : `0` supprime l’écart, tandis que des valeurs plus élevées augmentent l’espacement. Avec une profondeur de diagramme fixe, augmenter l’écart rend les marqueurs plus fins le long de l’axe de profondeur.

Accédez au groupe via [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/). Le réglage s’applique à chaque série du groupe, pas seulement à la série utilisée pour y accéder. [ChartSeries.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/gap_depth/) est en lecture seule et reflète le réglage du groupe parent.

Ce réglage affecte les diagrammes à colonnes et à barres 3D, y compris leurs variantes cylindre, cône et pyramide, ainsi que les diagrammes 3D de lignes et de surfaces. L’apparence dépend de la façon dont les séries sont disposées en profondeur, groupées ou empilées. Pour une comparaison claire des écarts entre séries distinctes, utilisez `ChartType.COLUMN_3D` de l’énumération [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/).

Ces propriétés contrôlent différents aspects du diagramme :

| Propriété | Effet |
| --- | --- |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | Espacement entre les séries le long de l’axe de profondeur, en pourcentage de la largeur du marqueur. |
| [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) | Espacement entre les groupes de barres ou de colonnes adjacents, en pourcentage de la largeur de la barre ou de la colonne. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | Profondeur globale du diagramme, en pourcentage de la largeur du diagramme. |

L’exemple autonome suivant utilise les données de diagramme par défaut, qui contiennent trois séries et quatre catégories. Il enregistre deux présentations avec des données, une rotation, une largeur d’écart et une profondeur de diagramme identiques ; seul l’écart en profondeur varie.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 40, 30, 620, 230)

    chart.rotation_3d.rotation_x = 20
    chart.rotation_3d.rotation_y = 30
    chart.rotation_3d.depth_percents = 100

    series = chart.chart_data.series[0]
    group = series.parent_series_group
    group.gap_width = 150

    for gap_depth in (0, 500):
        group.gap_depth = gap_depth
        file_name = f"series_gap_depth_{gap_depth}.pptx"
        presentation.save(file_name, slides.export.SaveFormat.PPTX)
```

Les images suivantes ont été exportées à partir des présentations générées avec Microsoft PowerPoint.

| Écart en profondeur : 0 % | Écart en profondeur : 500 % |
| --- | --- |
| ![3D column chart with no gap between series along the depth axis](gap_depth_0.png) | ![3D column chart with a 500 percent gap between series along the depth axis](gap_depth_500.png) |

## **Modifier le type de série 3D et la forme des barres**

Dans un diagramme à cylindres groupés, la première série commence avec des barres cylindriques. L’exemple lit [ChartSeries.type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/type/) et [ChartSeries.bar_3d_shape](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/bar_3d_shape/) avant et après chaque changement.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_CYLINDER, 20, 20, 500, 300)
    series = chart.chart_data.series[0]
    
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    series.type = charts.ChartType.CLUSTERED_CONE
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    series.bar_3d_shape = charts.ChartShapeType.BOX
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    presentation.save("series_shape.pptx", slides.export.SaveFormat.PPTX)
```

| Modification de la première série | `type` | `bar_3d_shape` |
| --- | --- | --- |
| Création du diagramme | `CLUSTERED_CYLINDER` | `CYLINDER` |
| Définir `type` sur `CLUSTERED_CONE` | `CLUSTERED_CONE` | `CONE` |
| Définir `bar_3d_shape` sur `BOX` | `CLUSTERED_COLUMN_3D` | `BOX` |

Définir la forme sur `BOX` change également le type de série en `CLUSTERED_COLUMN_3D`. Si votre code comporte une branche conditionnelle basée sur le type de série, lisez `series.type` après avoir changé la forme. Une valeur mise en cache avant l’affectation sélectionnerait toujours la branche `CLUSTERED_CONE`.

![PowerPoint comparison showing the first series as cylinders, cones, and rectangular columns from left to right](series-shapes.png)

## **FAQ**

**Quels types de diagrammes prennent en charge le mode 3D dans Aspose.Slides ?**

Aspose.Slides prend en charge les variantes 3D des diagrammes à colonnes, notamment Column 3D, Clustered Column 3D, Stacked Column 3D et 100 % Stacked Column 3D, ainsi que les types 3D associés exposés via l’énumération [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/). Pour obtenir une liste exacte et à jour, consultez les membres de [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) dans la référence API de votre version installée.

**Puis‑je obtenir une image raster d’un diagramme 3D pour un rapport ou le web ?**

Oui. Vous pouvez exporter un diagramme vers une image avec [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) ou [render the entire slide](/slides/fr/python-net/convert-powerpoint-to-png/) vers des formats comme PNG ou JPEG. Cela est utile lorsque vous avez besoin d’un aperçu raster ou que vous voulez intégrer le diagramme dans des documents, tableaux de bord ou pages web sans nécessiter PowerPoint.

**Quelle est la performance de la création et du rendu de gros diagrammes 3D ?**

Les performances dépendent du volume de données et de la complexité visuelle. Pour de meilleurs résultats, limitez les effets 3D, évitez les textures lourdes sur les murs et les zones de tracé, réduisez le nombre de points de données par série lorsque possible, et rendez vers une sortie de taille appropriée (résolution et dimensions) correspondant à l’affichage ou à l’impression ciblés.