---
title: Personnaliser les axes de graphique dans les présentations avec Python
linktitle: Axe du graphique
type: docs
url: /fr/python-java/chart-axis/
keywords:
- axe du graphique
- axe vertical
- axe horizontal
- personnaliser l'axe
- manipuler l'axe
- gérer l'axe
- propriétés de l'axe
- valeur maximale
- valeur minimale
- ligne d'axe
- format de date
- titre de l'axe
- position de l'axe
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Découvrez comment utiliser Aspose.Slides for Python via Java pour personnaliser les axes de graphique dans les présentations PowerPoint pour les rapports et les visualisations."
---
## **Vue d'ensemble**

Cet article explique comment personnaliser les axes de graphique dans Aspose.Slides. Il montre comment obtenir les valeurs réelles des axes, échanger les données entre les axes, masquer l'axe vertical ou horizontal pour les graphiques en courbes, modifier le type d'axe de catégorie, définir le format de date pour les valeurs d'axe de catégorie, faire pivoter le titre d'un axe, définir la position de l'axe et définir l'unité d'affichage de l'axe des valeurs.

## **Obtenir les valeurs maximales sur l'axe vertical d'un graphique**

Aspose.Slides pour Python via Java vous permet d'obtenir les valeurs minimale et maximale sur un axe vertical. Suivez les étapes suivantes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
1. Accédez à la première diapositive.
1. Ajoutez un graphique avec des données par défaut.
1. Obtenez la valeur maximale réelle sur l'axe.
1. Obtenez la valeur minimale réelle sur l'axe.
1. Obtenez l'unité majeure réelle de l'axe.
1. Obtenez l'unité mineure réelle de l'axe.
1. Obtenez l'échelle de l'unité majeure réelle de l'axe.
1. Obtenez l'échelle de l'unité mineure réelle de l'axe.

Ce code d'exemple — une implémentation des étapes ci‑dessus — montre comment obtenir les valeurs requises en Python :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getVerticalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getVerticalAxis().getActualMinorUnit()

    major_unit_scale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale()
    minor_unit_scale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale()

    # Enregistre la présentation
    presentation.save("MaxValuesVerticalAxis_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Échanger les données entre les axes**

Aspose.Slides vous permet d'échanger rapidement les données entre les axes — les données représentées sur l'axe vertical (axe y) sont déplacées vers l'axe horizontal (axe x) et vice‑versa.

Ce code Python montre comment effectuer la tâche d'échange de données entre les axes d'un graphique :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300)

    # Charge les données par défaut du graphique dans le classeur — switchRowColumn transpose le classeur,
    # il doit donc être rempli d'abord
    workbook = chart.getChartData().getChartDataWorkbook()

    # Inverse les lignes et les colonnes
    chart.getChartData().switchRowColumn()

    # Enregistre la présentation
    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Désactiver l'axe vertical pour les graphiques en ligne**

Ce code Python montre comment masquer l'axe vertical d'un graphique en ligne :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getVerticalAxis().setVisible(False)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Désactiver l'axe horizontal pour les graphiques en ligne**

Ce code montre comment masquer l'axe horizontal d'un graphique en ligne :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getHorizontalAxis().setVisible(False)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Modifier un axe de catégorie**

En utilisant la méthode [setCategoryAxisType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/axis/#setCategoryAxisType), vous pouvez spécifier le type d'axe de catégorie souhaité (**date** ou **text**). Ce code en Python montre l'opération :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Chart, SaveFormat, CategoryAxisType, TimeUnitType

presentation = Presentation("ExistingChart.pptx")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getShapes().size() > 0:
        chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        if isinstance(chart, Chart):
            chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
            chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(False)
            chart.getAxes().getHorizontalAxis().setMajorUnit(1)
            chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months)
            presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx)
        else:
            print("The first shape is not a chart.")
    else:
        print("The presentation has no first shape to update.")
finally:
    presentation.dispose()
```

## **Définir le format de date pour les valeurs d'axe de catégorie**

Aspose.Slides pour Python via Java vous permet de définir le format de date pour une valeur d'axe de catégorie. L'opération est démontrée dans ce code Python :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType

from datetime import datetime

def convert_to_oa_date(date):
    base_date = datetime(1899, 12, 30)
    return (date - base_date).total_seconds() / 86400


presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 50, 50, 450, 300)

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()
    category_date = datetime(2015, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A2", category_value)
    chart.getChartData().getCategories().add(category_cell)
    category_date = datetime(2016, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A3", category_value)
    chart.getChartData().getCategories().add(category_cell)
    category_date = datetime(2017, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A4", category_value)
    chart.getChartData().getCategories().add(category_cell)
    category_date = datetime(2018, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A5", category_value)
    chart.getChartData().getCategories().add(category_cell)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    value_cell = workbook.getCell(0, "B2", 1.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, "B3", 2.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, "B4", 3.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, "B5", 4.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Définir un angle de rotation pour le titre d'un axe de graphique**

Aspose.Slides pour Python via Java vous permet de définir l'angle de rotation du titre d'un axe de graphique. Ce code Python montre l'opération :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)

    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Définir la position de l'axe sur un axe de catégorie ou de valeur**

Aspose.Slides pour Python via Java vous permet de définir la position de l'axe sur un axe de catégorie ou de valeur. Ce code Python montre comment réaliser la tâche :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)

    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Définir l'unité d'affichage sur un axe de valeurs d'un graphique**

Aspose.Slides pour Python via Java vous permet de définir l'unité d'affichage d'un axe de valeurs d'un graphique. L'axe met alors à l'échelle ses libellés de repères selon cette unité : avec [DisplayUnitType.Millions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/displayunittype/#Millions), un axe qui va jusqu'à 60,000,000 est libellé de 0 à 60. Ce code Python montre l'opération :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, DisplayUnitType

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)

    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Comment définir la valeur à laquelle un axe croise l'autre (croisement d'axe) ?**

Les axes offrent un [paramètre de croisement](https://reference.aspose.com/slides/fr/python-java/aspose.slides/axis/#setCrossType) : vous pouvez choisir de croiser à zéro, au maximum de la catégorie/valeur, ou à une valeur numérique spécifique. Cela est utile pour déplacer l'axe X vers le haut ou le bas ou pour mettre en évidence une ligne de base.

**Comment positionner les marques de graduation par rapport à l'axe (croisement, extérieur, intérieur) ?**

Définissez la [position des marques de graduation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/axis/#setMajorTickMark) sur "cross", "outside" ou "inside". Cela influence la lisibilité et aide à économiser de l'espace, en particulier sur les petits graphiques.