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
description: "Créer des graphiques 3D dans les présentations PowerPoint avec Aspose.Slides for Python via .NET. Ajustez la rotation, les proportions de hauteur, la profondeur du graphique et l'espacement entre les séries avec des exemples Python."
---
## **Vue d'ensemble**

Aspose.Slides for Python via .NET vous permet de personnaliser la vue d'un graphique 3D via la propriété [Chart.rotation_3d](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/rotation_3d/) . Cet article montre comment ajuster la rotation, les proportions de hauteur, la profondeur, les axes à angle droit et l'espacement entre les séries, puis enregistrer la présentation au format PPTX.

## **Définir la rotation et la profondeur d'un graphique 3D**

L'exemple suivant crée une [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) et utilise [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) pour ajouter un graphique à colonnes 3D empilées à sa première diapositive. Il remplace les séries et catégories par défaut par deux séries contenant chacune trois valeurs. L'index de feuille de calcul `0` identifie la première feuille de données du graphique ; la ligne `0` contient les noms des séries, et la colonne `0` contient les libellés des catégories.

Les propriétés [rotation_x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_x/) et [rotation_y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_y/) définissent la rotation du graphique à 40 et 270 degrés respectivement. [depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) fixe sa profondeur à 150 % de sa largeur, tandis que [right_angle_axes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/right_angle_axes/) active les axes à angle droit au lieu de la perspective. La présentation résultante contient le graphique peuplé avec ces paramètres de vue 3D.

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

## **Appliquer un remplissage d'image à la surface d'un graphique 3D**

Vous pouvez remplir le [side wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/side_wall/), le [back wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/back_wall/) et le [floor](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/floor/) d'un graphique 3D indépendamment. Définissez le [fill type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) de la surface sur `PICTURE` et attribuez une image. Pour ajuster une copie de l'image sur toute la surface, définissez à la fois le [picture fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/) et le [picture type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartwall/picture_type/) de la surface sur `STRETCH`.

Enregistrez [arrow.png](arrow.png) dans le répertoire de travail. L'exemple fait pivoter le graphique et augmente la valeur maximale de l'axe vertical afin que le plancher soit visible entre les colonnes. Il duplique la diapositive deux fois, puis applique la flèche à une surface différente sur chaque diapositive. Les trois graphiques partagent les mêmes données, angle de vue et arrière-plan.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 20, 30, 680, 480)
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 30
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 24

    back_slide = presentation.slides.add_clone(slide)
    floor_slide = presentation.slides.add_clone(slide)
    back_chart = back_slide.shapes[0]
    floor_chart = floor_slide.shapes[0]

    with open("arrow.png", "rb") as image_file:
        image_bytes = image_file.read()
    arrow = presentation.images.add_image(image_bytes)

    for surface in (chart.side_wall, back_chart.back_wall, floor_chart.floor):
        fill = surface.format.fill
        fill.fill_type = slides.FillType.PICTURE
        fill.picture_fill_format.picture.image = arrow
        fill.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
        surface.picture_type = charts.PictureType.STRETCH

    presentation.save("chart-surfaces.pptx", slides.export.SaveFormat.PPTX)
```

Microsoft PowerPoint affiche les trois diapositives comme suit.

| Mur latéral | Mur arrière | Plancher |
| --- | --- | --- |
| ![Flèche pointant vers le graphique le long du mur latéral](side-wall.png) | ![Flèche pointant vers la droite à travers le mur arrière](back-wall.png) | ![Flèche pointant vers la droite à travers le plancher entre les colonnes](floor.png) |

## **Ajuster les proportions de hauteur d'un graphique 3D**

Utilisez [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) pour définir la hauteur d'un graphique 3D en pourcentage de sa largeur. Cela modifie les proportions de la scène 3D sans redimensionner l'objet graphique sur la diapositive.

Exemple suivant crée un graphique [COLUMN_3D](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) avec les données par défaut : trois séries et quatre catégories. Il enregistre trois présentations avec des proportions de hauteur de 50 %, 100 % et 200 %. La position, la largeur et la hauteur du graphique restent fixes. Les données, la rotation, la profondeur, l'espacement des séries et le formatage sont identiques dans les trois fichiers ; seul le pourcentage de hauteur change.

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

Les images suivantes ont été exportées des présentations générées à l'aide de Microsoft PowerPoint. Un pourcentage plus petit produit une scène plus plate, tandis qu'un pourcentage plus grand produit une scène plus haute dans le même objet graphique. PowerPoint peut également ajuster les intervalles des graduations des axes et le placement des libellés pour s'adapter à la scène.

| Hauteur : 50 % | Hauteur : 100 % | Hauteur : 200 % |
| --- | --- | --- |
| ![Graphique à colonnes 3D avec une hauteur égale à 50 % de sa largeur](height_percent_50.png) | ![Graphique à colonnes 3D avec une hauteur égale à 100 % de sa largeur](height_percent_100.png) | ![Graphique à colonnes 3D avec une hauteur égale à 200 % de sa largeur](height_percent_200.png) |

Ces propriétés contrôlent différents aspects du graphique :

| Propriété | Effet |
| --- | --- |
| [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) | Hauteur de la scène 3D en pourcentage de sa largeur. |
| [Chart.height](https://reference.aspose.com/slides/python-net/aspose.slides/shape/height/) | Hauteur de l'objet graphique sur la diapositive, en points. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | Profondeur de la scène 3D en pourcentage de sa largeur. |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | Espacement entre les séries le long de l'axe de profondeur, en pourcentage de la largeur du marqueur. |

Le paramètre de hauteur affecte les graphiques à colonnes et à barres 3D, y compris leurs variantes cylindre, cône et pyramide, ainsi que les graphiques 3D en ligne, en aires, en secteurs et en surfaces. La comparaison ci‑dessus utilise le type vérifié `COLUMN_3D`. Ce réglage ne modifie pas l'apparence d'un graphique 2D `CLUSTERED_COLUMN` ou d'un graphique `BUBBLE_WITH_3D` ; ces noms sont des membres de l'énumération [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/). Pour d'autres réglages d'apparence des graphiques, consultez [Formatage du graphique](/slides/fr/python-net/chart-formatting/).

## **Ajuster l'écart entre les séries**

Utilisez [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) pour contrôler la distance entre les séries de données le long de l'axe de profondeur d'un graphique 3D, exprimée en pourcentage de la largeur du marqueur. Utilisez des valeurs de **0 à 500**, incluses : `0` supprime l'écart, tandis que des valeurs plus grandes augmentent l'espacement. Avec une profondeur de graphique fixe, augmenter l'écart rend les marqueurs plus fins le long de l'axe de profondeur.

Accédez au groupe via [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/). Le paramètre s'applique à chaque série de ce groupe, pas seulement à la série utilisée pour y accéder. [ChartSeries.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/gap_depth/) est en lecture seule et reflète le paramètre du groupe parent.

Ce paramètre affecte les graphiques à colonnes et à barres 3D, y compris leurs variantes cylindre, cône et pyramide, ainsi que les graphiques 3D en ligne et en aires. L'apparence dépend de l'agencement des séries en profondeur, groupées ou empilées. Pour une comparaison claire des écarts entre séries séparées, utilisez `ChartType.COLUMN_3D` de l'énumération [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/).

| Propriété | Effet |
| --- | --- |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | Espacement entre les séries le long de l'axe de profondeur, en pourcentage de la largeur du marqueur. |
| [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) | Espacement entre les clusters de barres ou de colonnes adjacents, en pourcentage de la largeur de la barre ou de la colonne. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | Profondeur globale du graphique, en pourcentage de la largeur du graphique. |

L'exemple autonome suivant utilise les données de graphique par défaut, qui contiennent trois séries et quatre catégories. Il enregistre deux présentations avec des données, une rotation, une largeur d'écart et une profondeur de graphique identiques ; seul l'écart de profondeur varie.

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

Les images suivantes ont été exportées des présentations générées à l'aide de Microsoft PowerPoint.

| Profondeur d'écart : 0 % | Profondeur d'écart : 500 % |
| --- | --- |
| ![Graphique à colonnes 3D sans écart entre les séries le long de l'axe de profondeur](gap_depth_0.png) | ![Graphique à colonnes 3D avec un écart de 500 % entre les séries le long de l'axe de profondeur](gap_depth_500.png) |

## **Modifier le type de série 3D et la forme des barres**

Dans un graphique à cylindres groupés, la première série commence avec des barres cylindriques. L'exemple lit [ChartSeries.type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/type/) et [ChartSeries.bar_3d_shape](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/bar_3d_shape/) avant et après chaque modification.

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
| Créer le graphique | `CLUSTERED_CYLINDER` | `CYLINDER` |
| Définir `type` sur `CLUSTERED_CONE` | `CLUSTERED_CONE` | `CONE` |
| Définir `bar_3d_shape` sur `BOX` | `CLUSTERED_COLUMN_3D` | `BOX` |

Définir la forme sur `BOX` modifie également le type de série en `CLUSTERED_COLUMN_3D`. Si votre code effectue des bifurcations selon le type de série, lisez `series.type` après avoir changé la forme. Une valeur mise en cache avant l'affectation sélectionnerait toujours la branche `CLUSTERED_CONE`.

![Comparaison PowerPoint montrant la première série sous forme de cylindres, cônes et colonnes rectangulaires de gauche à droite](series-shapes.png)

## **FAQ**

**Quels types de graphiques prennent en charge le mode 3D dans Aspose.Slides ?**

Aspose.Slides prend en charge les variantes 3D des graphiques à colonnes, notamment Column 3D, Clustered Column 3D, Stacked Column 3D et 100 % Stacked Column 3D, ainsi que les types 3D associés exposés via l'énumération [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/). Pour obtenir une liste exacte et à jour, consultez les membres [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) dans la référence API de votre version installée.

**Puis-je obtenir une image raster d'un graphique 3D pour un rapport ou le web ?**

Oui. Vous pouvez exporter un graphique sous forme d'image avec [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) ou [render the entire slide](/slides/fr/python-net/convert-powerpoint-to-png/) vers des formats tels que PNG ou JPEG. Cela est utile lorsque vous avez besoin d'un aperçu raster ou que vous souhaitez intégrer le graphique dans des documents, tableaux de bord ou pages web sans nécessiter PowerPoint.

**Quelle est la performance de la création et du rendu de grands graphiques 3D ?**

La performance dépend du volume de données et de la complexité visuelle. Pour de meilleurs résultats, limitez les effets 3D, évitez les textures lourdes sur les murs et les zones de tracé, réduisez le nombre de points de données par série lorsque cela est possible, et rendez la sortie à une taille appropriée (résolution et dimensions) pour correspondre à l'affichage cible ou aux besoins d'impression.