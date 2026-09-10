---
title: Optimiser les calculs de graphiques pour les présentations en Python via Java
linktitle: Calculs de graphiques
type: docs
weight: 50
url: /fr/python-java/chart-calculations/
keywords:
- calculs de graphiques
- éléments du graphique
- position de l'élément
- position réelle
- élément enfant
- élément parent
- valeurs du graphique
- valeur réelle
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Comprendre les calculs de graphiques, la mise à jour des données et le contrôle de la précision dans Aspose.Slides pour Python via Java pour PPT et PPTX, avec des exemples de code Python pratiques."
---
## **Aperçu**

Aspose.Slides fournit des API pour travailler avec les calculs de graphiques et les données de mise en page dans les présentations. Cet article montre comment récupérer les valeurs réelles des éléments du graphique, y compris la position et la taille réelles des éléments du graphique ainsi que les valeurs réelles des axes du graphique. Il explique également que ces valeurs sont remplies après la validation de la mise en page du graphique.

En outre, l'article montre comment obtenir la position réelle des éléments parents du graphique et comment masquer des composants du graphique tels que le titre, les axes, la légende et les lignes de grille. Ensemble, ces exemples vous aident à inspecter les informations de mise en page du graphique et à contrôler la visibilité des éléments du graphique dans les présentations PowerPoint de façon programmatique.

## **Calculer les valeurs réelles des éléments du graphique**
Aspose.Slides for Python via Java fournit une API simple pour obtenir ces propriétés. Les méthodes de la classe [Axis](https://reference.aspose.com/slides/fr/python-java/aspose.slides/axis/) fournissent des informations sur les valeurs réelles des axes du graphique ([getActualMaxValue](https://reference.aspose.com/slides/fr/python-java/aspose.slides/axis/#getActualMaxValue), [getActualMinValue](https://reference.aspose.com/slides/fr/python-java/aspose.slides/axis/#getActualMinValue), [getActualMajorUnit](https://reference.aspose.com/slides/fr/python-java/aspose.slides/axis/#getActualMajorUnit), [getActualMinorUnit](https://reference.aspose.com/slides/fr/python-java/aspose.slides/axis/#getActualMinorUnit), [getActualMajorUnitScale](https://reference.aspose.com/slides/fr/python-java/aspose.slides/axis/#getActualMajorUnitScale), [getActualMinorUnitScale](https://reference.aspose.com/slides/fr/python-java/aspose.slides/axis/#getActualMinorUnitScale)). Appelez d'abord la méthode [Chart.validateChartLayout](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chart/#validateChartLayout) pour remplir ces propriétés avec les valeurs réelles.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getHorizontalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getHorizontalAxis().getActualMinorUnit()
finally:
    presentation.dispose()
```

## **Calculer la position réelle des éléments parents du graphique**
Aspose.Slides for Python via Java fournit une API simple pour obtenir ces propriétés. Les méthodes de la classe [ChartPlotArea](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartplotarea/) fournissent des informations sur la position et la taille réelles de la zone de tracé du graphique ([getActualX](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartplotarea/#getActualX), [getActualY](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartplotarea/#getActualY), [getActualWidth](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartplotarea/#getActualWidth), [getActualHeight](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartplotarea/#getActualHeight)). Appelez d'abord la méthode [Chart.validateChartLayout](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chart/#validateChartLayout) pour remplir ces propriétés avec les valeurs réelles.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350)
    chart.validateChartLayout()

    x = chart.getPlotArea().getActualX()
    y = chart.getPlotArea().getActualY()
    width = chart.getPlotArea().getActualWidth()
    height = chart.getPlotArea().getActualHeight()
finally:
    presentation.dispose()
```

## **Masquer les éléments du graphique**
Cette section explique comment masquer des informations d'un graphique. Avec Aspose.Slides for Python via Java, vous pouvez masquer le **Titre, Axe vertical, Axe horizontal** et les **Lignes de grille**. L'exemple de code suivant montre comment utiliser ces propriétés.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LegendDataLabelPosition, LineDashStyle, MarkerStyleType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370)

    # Masquer le titre du graphique.
    chart.setTitle(False)

    # Masquer l'axe de valeur.
    chart.getAxes().getVerticalAxis().setVisible(False)

    # Masquer l'axe des catégories.
    chart.getAxes().getHorizontalAxis().setVisible(False)

    # Masquer la légende.
    chart.setLegend(False)

    # Masquer les lignes de grille principales.
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    # Conserver uniquement la première série. La suppression depuis la fin maintient les index restants valides.
    series_collection = chart.getChartData().getSeries()
    while series_collection.size() > 1:
        series_collection.removeAt(series_collection.size() - 1)

    series = series_collection.get_Item(0)

    series.getMarker().setSymbol(MarkerStyleType.Circle)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.Top)
    series.getMarker().setSize(15)

    # Définir la couleur de la ligne de la série.
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA)
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid)

    presentation.save("HideInformationFromChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Les classeurs Excel externes fonctionnent-ils comme source de données, et comment cela affecte-t-il le recalcul ?**

Oui. Un graphique peut référencer un classeur externe : lorsque vous vous connectez ou actualisez la source externe, les formules et les valeurs sont prises de ce classeur, et le graphique reflète les mises à jour lors des opérations d'ouverture/modification. L'API vous permet de [spécifier le classeur externe](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdata/#setExternalWorkbook) et de gérer les données liées.

**Puis-je calculer et afficher des lignes de tendance sans implémenter moi‑même la régression ?**

Oui. Les [Trendlines](/slides/fr/python-java/trend-line/) (linéaires, exponentielles et autres) sont ajoutées et mises à jour par Aspose.Slides ; leurs paramètres sont recalculés automatiquement à partir des données de séries, vous n’avez donc pas besoin d’implémenter vos propres calculs.

**Si une présentation contient plusieurs graphiques avec des liens externes, puis‑je contrôler quel classeur chaque graphique utilise pour les valeurs calculées ?**

Oui. Chaque graphique peut pointer vers son propre [classeur externe](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdata/#setExternalWorkbook), ou vous pouvez créer/remplacer un classeur externe par graphique indépendamment des autres.