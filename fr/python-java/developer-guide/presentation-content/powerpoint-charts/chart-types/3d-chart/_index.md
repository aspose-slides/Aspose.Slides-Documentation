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
description: "Créez des graphiques 3D dans des présentations PowerPoint avec Aspose.Slides for Python via Java. Ajustez la rotation, les proportions de hauteur, la profondeur du graphique et l'espacement entre les séries avec des exemples Python."
---
## **Vue d'ensemble**

Aspose.Slides for Python via Java vous permet de personnaliser la vue d'un graphique 3D via la méthode [Chart.getRotation3D](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getRotation3D). Cet article montre comment ajuster la rotation, les proportions de hauteur, la profondeur, les axes à angle droit et l'espacement entre les séries, puis enregistrer la présentation au format PPTX.

## **Définir la rotation et la profondeur d'un graphique 3D**

L'exemple ci‑dessous crée une [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) et utilise [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) pour ajouter un graphique à colonnes 3D empilées à sa première diapositive. Il remplace les séries et catégories par défaut par deux séries contenant chacune trois valeurs. L'index de la feuille de calcul `0` identifie la première feuille de données du graphique ; la ligne `0` contient les noms des séries et la colonne `0` les libellés des catégories.

Les méthodes [setRotationX](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationX) et [setRotationY](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationY) définissent respectivement la rotation du graphique à 40 et 270 degrés. [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) fixe la profondeur à 150 % de sa largeur, tandis que [setRightAngleAxes](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRightAngleAxes) active les axes à angle droit au lieu de la perspective. La présentation résultante contient le graphique rempli avec ces réglages de vue 3D.

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

## **Appliquer un remplissage d'image à la surface d'un graphique 3D**

Un graphique 3D possède trois surfaces que vous pouvez remplir indépendamment : le [side wall](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getSideWall), le [back wall](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getBackWall) et le [floor](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getFloor). Définissez le [fill type](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) de la surface sur `Picture` et assignez une image. Réglez à la fois le [picture fill mode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode) et le [picture type](https://reference.aspose.com/slides/python-java/aspose.slides/chartwall/#setPictureType) de la surface sur `Stretch` pour adapter une copie de l'image à toute la surface.

Enregistrez [arrow.png](arrow.png) dans le répertoire de travail. L'exemple fait pivoter le graphique et augmente la valeur maximale sur l'axe vertical afin que le plancher soit visible entre les colonnes. Il clone ensuite la diapositive deux fois et applique la flèche à une surface différente sur chaque diapositive. Les trois graphiques conservent les mêmes données, le même angle de vue et le même arrière‑plan.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, PictureFillMode, PictureType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 20, 30, 680, 480)
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(30)
    
    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.setAutomaticMaxValue(False)
    vertical_axis.setMaxValue(24)

    back_slide = presentation.getSlides().addClone(slide)
    floor_slide = presentation.getSlides().addClone(slide)
    back_chart = back_slide.getShapes().get_Item(0)
    floor_chart = floor_slide.getShapes().get_Item(0)

    image_bytes = Path("arrow.png").read_bytes()
    arrow = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(image_bytes))

    surfaces = (chart.getSideWall(), back_chart.getBackWall(), floor_chart.getFloor())
    for surface in surfaces:
        fill = surface.getFormat().getFill()
        fill.setFillType(FillType.Picture)
        picture_fill = fill.getPictureFillFormat()
        picture_fill.getPicture().setImage(arrow)
        picture_fill.setPictureFillMode(PictureFillMode.Stretch)
        surface.setPictureType(PictureType.Stretch)

    presentation.save("chart-surfaces.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Microsoft PowerPoint affiche les trois diapositives comme suit.

| Paroi latérale | Paroi arrière | Plancher |
| --- | --- | --- |
| ![Flèche pointant dans le graphique le long de la paroi latérale](side-wall.png) | ![Flèche pointant à droite sur la paroi arrière](back-wall.png) | ![Flèche pointant à droite sur le plancher entre les colonnes](floor.png) |

## **Ajuster les proportions de hauteur d'un graphique 3D**

Utilisez [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) pour définir la hauteur d'un graphique 3D en pourcentage de sa largeur. Cela modifie les proportions de la scène 3D sans redimensionner l'objet graphique sur la diapositive.

L'exemple suivant crée un graphique [Column3D](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) avec les données par défaut : trois séries et quatre catégories. Il enregistre trois présentations avec des proportions de hauteur de 50 %, 100 % et 200 %. La position, la largeur et la hauteur du graphique restent fixes. Les données, la rotation, la profondeur, l'espacement des séries et le formatage sont identiques dans les trois fichiers ; seule la proportion de hauteur varie.

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

Les images suivantes illustrent les mêmes réglages de hauteur dans l'exemple .NET équivalent et ont été exportées avec Microsoft PowerPoint. Un pourcentage plus petit produit une scène plus plate, tandis qu'un pourcentage plus grand produit une scène plus haute dans le même objet graphique. PowerPoint peut également ajuster les intervalles des graduations d'axe et le placement des libellés pour adapter la scène.

| Hauteur : 50 % | Hauteur : 100 % | Hauteur : 200 % |
| --- | --- | --- |
| ![Graphique à colonnes 3D avec hauteur réglée à 50 % de sa largeur](height_percent_50.png) | ![Graphique à colonnes 3D avec hauteur réglée à 100 % de sa largeur](height_percent_100.png) | ![Graphique à colonnes 3D avec hauteur réglée à 200 % de sa largeur](height_percent_200.png) |

Ces méthodes contrôlent différents aspects du graphique :

| Méthode | Effet |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) | Hauteur de la scène 3D en pourcentage de sa largeur. |
| [Chart.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHeight) | Hauteur de l'objet graphique sur la diapositive, en points. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | Profondeur de la scène 3D en pourcentage de sa largeur. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | Espacement entre les séries le long de l'axe de profondeur, en pourcentage de la largeur du marqueur. |

Le réglage de hauteur affecte les graphiques à colonnes et à barres 3D, y compris les variantes cylindre, cône et pyramide, ainsi que les graphiques 3D en ligne, surface, secteur et zone. La comparaison ci‑dessus utilise le type vérifié `Column3D`. Ce réglage ne modifie pas l'apparence d'un graphique 2D `ClusteredColumn` ou d'un graphique `BubbleWith3D` ; ces noms sont des membres de la classe [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/). Pour d'autres réglages d'apparence, consultez [Chart Formatting](/slides/fr/python-java/chart-formatting/).

## **Ajuster l'écart entre les séries**

Utilisez [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) pour contrôler la distance entre les séries de données le long de l'axe de profondeur d'un graphique 3D, exprimée en pourcentage de la largeur du marqueur. Utilisez des valeurs comprises entre **0 et 500**, incluses : `0` supprime l'écart, tandis que des valeurs plus élevées augmentent l'espacement. Avec une profondeur de graphique fixe, augmenter l'écart rend les marqueurs plus fins le long de l'axe de profondeur.

Accédez au groupe via [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup). Le réglage s'applique à chaque série du groupe, pas seulement à celle utilisée pour y accéder. [ChartSeries.getGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getGapDepth) renvoie l'écart de profondeur et reflète le réglage du groupe parent.

Ce réglage affecte les graphiques à colonnes et à barres 3D, y compris leurs variantes cylindre, cône et pyramide, ainsi que les graphiques 3D en ligne et en zone. L'apparence dépend de la disposition des séries en profondeur, groupées ou empilées. Pour une comparaison claire des écarts entre séries distinctes, utilisez `ChartType.Column3D` de la classe [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/).

Ces méthodes contrôlent différents aspects du graphique :

| Méthode | Effet |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | Espacement entre les séries le long de l'axe de profondeur, en pourcentage de la largeur du marqueur. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) | Espacement entre les groupes de barres ou de colonnes adjacents, en pourcentage de la largeur de la barre ou de la colonne. |
| [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | Profondeur globale du graphique, en pourcentage de la largeur du graphique. |

L'exemple autonome suivant utilise les données de graphique par défaut, qui contiennent trois séries et quatre catégories. Il enregistre deux présentations avec des données, une rotation, une largeur d'écart et une profondeur de graphique identiques ; seul l'écart de profondeur varie.

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

Les images suivantes illustrent les mêmes réglages d'écart de profondeur dans l'exemple .NET équivalent et ont été exportées avec Microsoft PowerPoint.

| Profondeur d'écart : 0 % | Profondeur d'écart : 500 % |
| --- | --- |
| ![Graphique à colonnes 3D sans aucun écart entre les séries le long de l'axe de profondeur](gap_depth_0.png) | ![Graphique à colonnes 3D avec un écart de 500 % entre les séries le long de l'axe de profondeur](gap_depth_500.png) |

## **Modifier le type de série 3D et la forme de la barre**

Dans un graphique à cylindres groupés, la première série commence avec une forme de barre cylindrique. L'exemple affiche les valeurs entières renvoyées par [ChartSeries.getType](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getType) et [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getBar3DShape) avant et après chaque modification. Le tableau donne les noms de constantes correspondants.

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

Définir la forme sur `Box` change également le type de série en `ClusteredColumn3D`. Si votre code sélectionne une branche en fonction du type de série, appelez `series.getType()` après avoir modifié la forme. Une valeur mise en cache avant l'affectation sélectionnerait toujours la branche `ClusteredCone`.

![Comparaison PowerPoint montrant la première série sous forme de cylindres, cônes et colonnes rectangulaires de gauche à droite](series-shapes.png)

## **FAQ**

**Quels types de graphiques prennent en charge le mode 3D dans Aspose.Slides ?**

Aspose.Slides prend en charge les variantes 3D des graphiques à colonnes, y compris Column 3D, Clustered Column 3D, Stacked Column 3D et 100 % Stacked Column 3D, ainsi que les types 3D associés exposés via la classe [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/). Pour une liste précise et à jour, consultez les membres de [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) dans la référence API de votre version installée.

**Puis‑je obtenir une image raster d'un graphique 3D pour un rapport ou le web ?**

Oui. Vous pouvez exporter un graphique en image avec [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) ou [rendre toute la diapositive](/slides/fr/python-java/convert-powerpoint-to-png/) vers des formats comme PNG ou JPEG. Cela est utile lorsque vous avez besoin d'un aperçu raster ou que vous souhaitez intégrer le graphique dans des documents, tableaux de bord ou pages Web sans nécessiter PowerPoint.

**Quelle est la performance de la création et du rendu de gros graphiques 3D ?**

Les performances dépendent du volume de données et de la complexité visuelle. Pour de meilleurs résultats, limitez les effets 3D, évitez les textures lourdes sur les murs et les zones de tracé, réduisez le nombre de points de données par série si possible, et rendez à une résolution et des dimensions appropriées à l'affichage ou à l'impression cible.