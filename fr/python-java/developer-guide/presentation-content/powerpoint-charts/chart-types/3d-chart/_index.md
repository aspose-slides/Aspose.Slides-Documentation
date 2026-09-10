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
description: "Apprenez à créer et personnaliser des graphiques 3D dans Aspose.Slides pour Python via Java, avec la prise en charge des fichiers PPT et PPTX — améliorez vos présentations dès aujourd’hui."
---
## **Vue d'ensemble**

Cet article explique comment personnaliser un graphique 3D dans Aspose.Slides en configurant les paramètres [Rotation3D](https://reference.aspose.com/slides/fr/python-java/aspose.slides/rotation3d/) tels que [setRotationX](https://reference.aspose.com/slides/fr/python-java/aspose.slides/rotation3d/#setRotationX), [setRotationY](https://reference.aspose.com/slides/fr/python-java/aspose.slides/rotation3d/#setRotationY), [setDepthPercents](https://reference.aspose.com/slides/fr/python-java/aspose.slides/rotation3d/#setDepthPercents) et [setRightAngleAxes](https://reference.aspose.com/slides/fr/python-java/aspose.slides/rotation3d/#setRightAngleAxes). Il décrit la création d’une présentation, l’ajout d’un graphique 3D avec des données par défaut, l’application des paramètres de vue 3D requis et l’enregistrement de la présentation modifiée au format PPTX.

## **Définir la rotation X, la rotation Y et la profondeur d’un graphique 3D**
Aspose.Slides for Python via Java fournit une API simple pour définir ces propriétés. L’exemple suivant montre comment définir la rotation X, la rotation Y et la profondeur d’un graphique 3D.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
2. Accéder à la première diapositive.
3. Ajouter un graphique avec des données par défaut.
4. Définir les propriétés de rotation 3D.
5. Enregistrer la présentation modifiée dans un fichier PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    # Accéder à la première diapositive.
    slide = presentation.getSlides().get_Item(0)

    # Ajouter un graphique avec des données par défaut.
    chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500)

    # Définir l'index de la feuille de calcul des données du graphique.
    default_worksheet_index = 0

    # Obtenir le classeur de données du graphique.
    workbook = chart.getChartData().getChartDataWorkbook()

    # Ajouter des séries.
    series_cell = workbook.getCell(default_worksheet_index, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(series_cell, chart.getType())
    series_cell = workbook.getCell(default_worksheet_index, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(series_cell, chart.getType())

    # Ajouter des catégories.
    category_cell = workbook.getCell(default_worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(default_worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(default_worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(category_cell)

    # Définir les propriétés de rotation 3D.
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(270)
    chart.getRotation3D().setDepthPercents(150)

    # Accéder à la deuxième série du graphique.
    series = chart.getChartData().getSeries().get_Item(1)

    # Remplir les données de la série.
    data_cell = workbook.getCell(default_worksheet_index, 1, 1, jpype.JInt(20))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 2, 1, jpype.JInt(50))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 3, 1, jpype.JInt(30))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 1, 2, jpype.JInt(30))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 2, 2, jpype.JInt(10))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 3, 2, jpype.JInt(60))
    series.getDataPoints().addDataPointForBarSeries(data_cell)

    # Enregistrer la présentation.
    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Quels types de graphiques prennent en charge le mode 3D dans Aspose.Slides ?**

Aspose.Slides prend en charge les variantes 3D des graphiques à colonnes, notamment Column 3D, Clustered Column 3D, Stacked Column 3D et 100 % Stacked Column 3D, ainsi que les types 3D associés exposés via la classe [ChartType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/charttype/). Pour obtenir une liste exacte et à jour, consultez les membres de [ChartType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/charttype/) dans la référence API de la version que vous avez installée.

**Puis-je obtenir une image raster d’un graphique 3D pour un rapport ou le web ?**

Oui. Vous pouvez exporter un graphique sous forme d’image via l’[API du graphique](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getImage) ou [rendre la diapositive entière](/slides/fr/python-java/convert-powerpoint-to-png/) vers des formats tels que PNG ou JPEG. Cela est utile lorsque vous avez besoin d’un aperçu pixel‑parfait ou que vous souhaitez intégrer le graphique dans des documents, des tableaux de bord ou des pages Web sans nécessiter PowerPoint.

**Quelle est la performance de la création et du rendu de grands graphiques 3D ?**

Les performances dépendent du volume de données et de la complexité visuelle. Pour de meilleurs résultats, limitez les effets 3D, évitez les textures lourdes sur les murs et les surfaces de tracé, réduisez le nombre de points de données par série lorsque cela est possible et rendez la sortie à une taille adaptée (résolution et dimensions) pour correspondre à l’affichage ou aux besoins d’impression ciblés.