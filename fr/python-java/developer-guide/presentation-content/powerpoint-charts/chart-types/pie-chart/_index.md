---
title: Personnaliser les graphiques circulaires dans les présentations avec Python via Java
linktitle: Graphique circulaire
type: docs
url: /fr/python-java/pie-chart/
keywords:
- graphique circulaire
- gérer le graphique
- personnaliser le graphique
- options du graphique
- paramètres du graphique
- options de tracé
- couleur de la part
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Apprenez à créer et personnaliser des graphiques circulaires en Python via Java avec Aspose.Slides, exportables vers PowerPoint, pour dynamiser votre storytelling de données en quelques secondes."
---
## **Vue d'ensemble**

Cet article explique comment travailler avec les graphiques circulaires dans Aspose.Slides. Il montre comment configurer les options de tracé secondaire pour les graphiques « Pie of Pie » et « Bar of Pie », ainsi que comment activer la coloration automatique des parts pour un graphique circulaire standard.

Les exemples se concentrent sur des étapes pratiques de personnalisation des graphiques, telles que l'ajout d'un graphique à une diapositive, le réglage des séries et des libellés, le remplacement des données de graphique par défaut par des catégories et valeurs personnalisées, et l'enregistrement de la présentation mise à jour.

## **Options de tracé secondaire pour les graphiques Pie of Pie et Bar of Pie**

Aspose.Slides for Python via Java prend en charge les options de tracé secondaire pour les graphiques Pie of Pie et Bar of Pie. Cette section montre comment spécifier ces options à l'aide d'Aspose.Slides. Suivez les étapes suivantes :

1. Instancier un objet [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
1. Ajouter un graphique à la diapositive.
1. Spécifier les options de tracé secondaire du graphique.
1. Enregistrer la présentation sur le disque.

L'exemple suivant définit différentes propriétés d'un graphique Pie of Pie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

# Créez une instance de la classe Presentation.
presentation = Presentation()
try:
    # Ajoutez un graphique à la diapositive.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400)

    # Définissez différentes propriétés.
    series = chart.getChartData().getSeries().get_Item(0)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setSecondPieSize(149)
    series_group.setPieSplitBy(PieSplitType.ByPercentage)
    series_group.setPieSplitPosition(53)

    # Enregistrez la présentation sur le disque.
    presentation.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Définir les couleurs automatiques des parts du graphique circulaire**

Aspose.Slides for Python via Java fournit une API simple pour définir les couleurs automatiques des parts d'un graphique circulaire. L'exemple suivant montre comment appliquer ces paramètres.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
1. Accéder à la première diapositive.
1. Ajouter un graphique avec des données par défaut.
1. Définir le titre du graphique.
1. Définir l'index de la feuille de calcul des données du graphique.
1. Obtenir le classeur de données du graphique.
1. Supprimer les séries et catégories par défaut.
1. Ajouter de nouvelles catégories.
1. Ajouter une nouvelle série.
1. Configurer la nouvelle série pour afficher les valeurs.

Enregistrer la présentation modifiée dans un fichier PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

# Créez une instance de la classe Presentation.
presentation = Presentation()
try:
    # Ajoutez un graphique avec les données par défaut.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # Définissez le titre du graphique.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # Définissez l'index de la feuille de calcul des données du graphique.
    default_worksheet_index = 0

    # Obtenez le classeur de données du graphique.
    workbook = chart.getChartData().getChartDataWorkbook()

    # Supprimez les séries et catégories par défaut.
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # Ajoutez de nouvelles catégories.
    first_category_cell = workbook.getCell(0, 1, 0, "First Qtr")
    chart.getChartData().getCategories().add(first_category_cell)
    second_category_cell = workbook.getCell(0, 2, 0, "2nd Qtr")
    chart.getChartData().getCategories().add(second_category_cell)
    third_category_cell = workbook.getCell(0, 3, 0, "3rd Qtr")
    chart.getChartData().getCategories().add(third_category_cell)

    # Ajoutez une nouvelle série.
    series_cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_cell, chart.getType())

    # Remplissez les données de la série.
    first_value_cell = workbook.getCell(default_worksheet_index, 1, 1, jpype.JInt(20))
    series.getDataPoints().addDataPointForPieSeries(first_value_cell)
    second_value_cell = workbook.getCell(default_worksheet_index, 2, 1, jpype.JInt(50))
    series.getDataPoints().addDataPointForPieSeries(second_value_cell)
    third_value_cell = workbook.getCell(default_worksheet_index, 3, 1, jpype.JInt(30))
    series.getDataPoints().addDataPointForPieSeries(third_value_cell)

    # Configurez la nouvelle série pour afficher les valeurs.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    series.getParentSeriesGroup().setColorVaried(True)
    presentation.save("Pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Les variantes 'Pie of Pie' et 'Bar of Pie' sont-elles prises en charge ?**

Oui, la bibliothèque [prend en charge](https://reference.aspose.com/slides/fr/python-java/aspose.slides/charttype/) un tracé secondaire pour les graphiques circulaires, y compris les types 'Pie of Pie' et 'Bar of Pie'.

**Puis-je exporter uniquement le graphique sous forme d'image (par exemple, PNG) ?**

Oui, vous pouvez [exporter le graphique lui‑même sous forme d'image](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getImage) (par exemple PNG) sans la totalité de la présentation.