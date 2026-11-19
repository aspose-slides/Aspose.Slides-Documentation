---
title: Personnaliser les graphiques 3D dans les présentations avec Python
linktitle: Graphique 3D
type: docs
url: /fr/python-java/3d-chart/
keywords:
- graphique 3D
- rotation
- profondeur
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Créer des graphiques 3D dans les présentations PowerPoint avec Aspose.Slides for Python via Java. Ajuster la rotation, les proportions de hauteur, la profondeur du graphique et l'espacement entre les séries avec des exemples Python."
---
## **Vue d’ensemble**

Aspose.Slides for Python via Java vous permet de personnaliser la vue d’un graphique 3D via la méthode [Chart.getRotation3D](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getRotation3D). Cet article montre comment ajuster la rotation, les proportions de hauteur, la profondeur, les axes à angle droit et l’espacement entre les séries, puis enregistrer la présentation au format PPTX.

## **Définir la rotation et la profondeur d’un graphique 3D**

L’exemple ci‑dessous crée une [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) et utilise [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) pour ajouter un diagramme à colonnes 3D empilé à sa première diapositive. Il remplace les séries et catégories par défaut par deux séries contenant chacune trois valeurs. L’index de feuille de calcul `0` identifie la première feuille de données du graphique ; la ligne `0` contient les noms des séries, et la colonne `0` contient les libellés des catégories.

Les méthodes [setRotationX](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationX) et [setRotationY](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationY) définissent respectivement la rotation du graphique à 40 et 270 degrés. [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) définit sa profondeur à 150 % de sa largeur, tandis que [setRightAngleAxes](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRightAngleAxes) active les axes à angle droit au lieu de la perspective. La présentation résultante contient le graphique rempli avec ces paramètres de vue 3D.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    values = [[20, 50, 30], [30, 10, 60]]

    for category_index in range(3):
        category_cell = workbook.getCell(worksheet_index, category_index + 1, 0, f"Category {category_index + 1}")
        chart.getChartData().getCategories().add(category_cell)

    for series_index in range(2):
        series_cell = workbook.getCell(worksheet_index, 0, series_index + 1, f"Series {series_index + 1}")
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())

        for category_index in range(3):
            value_cell = workbook.getCell(worksheet_index, category_index + 1, series_index + 1, jpype.JDouble(values[series_index][category_index]))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(270)
    chart.getRotation3D().setDepthPercents(150)

    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ajuster les proportions de hauteur d’un graphique 3D**

Utilisez [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) pour définir la hauteur d’un graphique 3D en pourcentage de sa largeur. Cela modifie les proportions de la scène 3D sans redimensionner l’objet graphique sur la diapositive.

L’exemple suivant crée un graphique [Column3D](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) avec les données par défaut : trois séries et quatre catégories. Il enregistre trois présentations avec des proportions de hauteur de 50 %, 100 % et 200 %. La position, la largeur et la hauteur du graphique restent fixes. Les données, la rotation, la profondeur, l’espacement des séries et le formatage sont identiques dans les trois fichiers ; seule la hauteur en pourcentage change.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 460)
    chart.getRotation3D().setRotationX(jpype.JByte(20))
    chart.getRotation3D().setRotationY(30)
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setDepthPercents(100)
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150)

    for height_percent in [50, 100, 200]:
        chart.getRotation3D().setHeightPercents(height_percent)
        presentation.save(f"chart_height_{height_percent}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Les images suivantes illustrent les mêmes réglages de hauteur dans l’exemple .NET équivalent et ont été exportées avec Microsoft PowerPoint. Un pourcentage plus petit produit une scène plus plate, tandis qu’un pourcentage plus grand produit une scène plus haute dans le même objet graphique. PowerPoint peut également ajuster les intervalles des graduations d’axe et le placement des étiquettes pour s’adapter à la scène.

| Hauteur : 50 % | Hauteur : 100 % | Hauteur : 200 % |
| --- | --- | --- |
| ![Diagramme à colonnes 3D avec hauteur réglée à 50 % de sa largeur](height_percent_50.png) | ![Diagramme à colonnes 3D avec hauteur réglée à 100 % de sa largeur](height_percent_100.png) | ![Diagramme à colonnes 3D avec hauteur réglée à 200 % de sa largeur](height_percent_200.png) |

Ces méthodes contrôlent différents aspects du graphique :

| Méthode | Effet |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) | Hauteur de la scène 3D en pourcentage de sa largeur. |
| [Chart.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHeight) | Hauteur de l’objet graphique sur la diapositive, en points. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | Profondeur de la scène 3D en pourcentage de sa largeur. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | Espacement entre les séries le long de l’axe de profondeur, en pourcentage de la largeur du marqueur. |

La configuration de hauteur affecte les graphiques à colonnes et barres 3D, y compris les variantes cylindre, cône et pyramide, ainsi que les graphiques 3D en lignes, aires, secteurs et surfaces. La comparaison ci‑dessus utilise le type vérifié `Column3D`. La configuration ne modifie pas l’apparence d’un graphique 2D `ClusteredColumn` ou d’un graphique `BubbleWith3D` ; ces noms sont des membres de la classe [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/). Pour d’autres paramètres d’apparence du graphique, consultez le formatage du graphique [Chart Formatting](/slides/fr/python-java/chart-formatting/).

## **Ajuster l’écart entre les séries**

Utilisez [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) pour contrôler la distance entre les séries de données le long de l’axe de profondeur d’un graphique 3D, exprimée en pourcentage de la largeur du marqueur. Utilisez des valeurs allant de **0 à 500**, incluses : `0` supprime l’écart, tandis que des valeurs plus élevées augmentent l’espacement. Avec une profondeur de graphique fixe, augmenter l’écart rend les marqueurs plus fins le long de l’axe de profondeur.

Accédez au groupe via [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup). Le réglage s’applique à chaque série du groupe, pas seulement à la série utilisée pour y accéder. [ChartSeries.getGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getGapDepth) renvoie l’écart de profondeur et reflète le réglage du groupe parent.

Ce réglage affecte les graphiques à colonnes et barres 3D, y compris leurs variantes cylindre, cône et pyramide, ainsi que les graphiques 3D en lignes et aires. L’apparence dépend de la façon dont les séries sont disposées en profondeur, en groupe ou empilées. Pour une comparaison claire des écarts entre séries séparées, utilisez `ChartType.Column3D` de la classe [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/).

Ces méthodes contrôlent différents aspects du graphique :

| Méthode | Effet |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | Espacement entre les séries le long de l’axe de profondeur, en pourcentage de la largeur du marqueur. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) | Espacement entre les groupes adjacents de barres ou de colonnes, en pourcentage de la largeur de la barre ou de la colonne. |
| [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | Profondeur globale du graphique, en pourcentage de la largeur du graphique. |

L’exemple autonome suivant utilise les données de graphique par défaut, qui contiennent trois séries et quatre catégories. Il enregistre deux présentations avec des données, rotations, largeur d’écart et profondeur de graphique identiques ; seul l’écart de profondeur change.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 230)

    chart.getRotation3D().setRotationX(jpype.JByte(20))
    chart.getRotation3D().setRotationY(30)
    chart.getRotation3D().setDepthPercents(100)

    series = chart.getChartData().getSeries().get_Item(0)
    group = series.getParentSeriesGroup()
    group.setGapWidth(150)

    for gap_depth in [0, 500]:
        group.setGapDepth(gap_depth)

        file_name = f"series_gap_depth_{gap_depth}.pptx"
        presentation.save(file_name, SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Les images suivantes illustrent les mêmes réglages d’écart de profondeur dans l’exemple .NET équivalent et ont été exportées avec Microsoft PowerPoint.

| Écart de profondeur : 0 % | Écart de profondeur : 500 % |
| --- | --- |
| ![Diagramme à colonnes 3D sans aucun écart entre les séries le long de l’axe de profondeur](gap_depth_0.png) | ![Diagramme à colonnes 3D avec un écart de 500 % entre les séries le long de l’axe de profondeur](gap_depth_500.png) |

## **Modifier le type de série 3D et la forme des barres**

Dans un graphique à cylindres groupés, la première série commence avec une forme de barre cylindrique. L’exemple affiche les valeurs entières renvoyées par [ChartSeries.getType](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getType) et [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getBar3DShape) avant et après chaque modification. Le tableau donne les noms de constantes correspondants.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartShapeType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredCylinder, 20, 20, 500, 300)
    series = chart.getChartData().getSeries().get_Item(0)
    
    print(f"{series.getType()} | {series.getBar3DShape()}")

    series.setType(ChartType.ClusteredCone)
    print(f"{series.getType()} | {series.getBar3DShape()}")

    series.setBar3DShape(ChartShapeType.Box)
    print(f"{series.getType()} | {series.getBar3DShape()}")

    presentation.save("series_shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| Modification de la première série | Type de série | Forme de la barre |
| --- | --- | --- |
| Créer le graphique | `ClusteredCylinder` | `Cylinder` |
| Définir le type de série sur `ClusteredCone` | `ClusteredCone` | `Cone` |
| Définir la forme de la barre sur `Box` | `ClusteredColumn3D` | `Box` |

Définir la forme sur `Box` change également le type de série en `ClusteredColumn3D`. Si votre code effectue des branches en fonction du type de série, appelez `series.getType()` après avoir changé la forme. Une valeur mise en cache avant l’affectation sélectionnerait toujours la branche `ClusteredCone`.

![Comparaison PowerPoint montrant la première série sous forme de cylindres, cônes et colonnes rectangulaires de gauche à droite](series-shapes.png)

## **FAQ**

**Quels types de graphiques prennent en charge le mode 3D dans Aspose.Slides ?**

Aspose.Slides prend en charge les variantes 3D des graphiques à colonnes, y compris Column 3D, Clustered Column 3D, Stacked Column 3D et 100 % Stacked Column 3D, ainsi que les types 3D associés exposés par la classe [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/). Pour une liste exacte et à jour, consultez les membres de [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) dans la référence API de votre version installée.

**Puis-je obtenir une image raster d’un graphique 3D pour un rapport ou le Web ?**

Oui. Vous pouvez exporter un graphique en image avec [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) ou [rendre la diapositive entière](/slides/fr/python-java/convert-powerpoint-to-png/) vers des formats tels que PNG ou JPEG. Cela est utile lorsque vous avez besoin d’un aperçu raster ou que vous souhaitez intégrer le graphique dans des documents, tableaux de bord ou pages web sans nécessiter PowerPoint.

**Quelle est la performance de la création et du rendu de graphiques 3D volumineux ?**

Les performances dépendent du volume de données et de la complexité visuelle. Pour de meilleurs résultats, limitez les effets 3D, évitez les textures lourdes sur les murs et les zones de tracé, réduisez le nombre de points de données par série lorsque possible, et rendez à une résolution et des dimensions appropriées à l’affichage ou à l’impression cible.