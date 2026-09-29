---
title: Gérer les étiquettes de données de graphique dans les présentations avec Python
linktitle: Étiquette de donnée
type: docs
url: /fr/python-java/chart-data-label/
keywords:
- graphique
- étiquette de donnée
- précision des données
- pourcentage
- distance d'étiquette
- emplacement d'étiquette
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Apprenez à ajouter et formater les étiquettes de données de graphique dans les présentations PowerPoint en utilisant Aspose.Slides pour Python via Java pour des diapositives plus engageantes."
---
## **Introduction**

Les étiquettes de données affichent des informations sur les séries de graphiques et les points de données individuels, aidant les lecteurs à identifier les valeurs et à comprendre le graphique. Cet article explique comment formater les valeurs, afficher les pourcentages, lire le texte des étiquettes, contrôler les étiquettes au‑delà du maximum de l'axe, ajuster l'espacement des étiquettes de l'axe des catégories et positionner les étiquettes d'un graphique circulaire.

## **Définir la précision des données dans les étiquettes de données du graphique**

Utilisez [setNumberFormatOfValues](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartseries/#setNumberFormatOfValues) pour formater les valeurs des séries. Cet exemple crée un graphique en courbes avec des données par défaut, affiche son tableau de données et active les étiquettes de valeurs pour la première série. Le format `#,##0.00` affiche un séparateur de milliers et deux décimales sans modifier les valeurs sous‑jacentes.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300)
    chart.setDataTable(True)

    series = chart.getChartData().getSeries().get_Item(0)
    series.setNumberFormatOfValues("#,##0.00")
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Afficher le pourcentage comme étiquettes**

Pour un graphique à colonnes empilées, calculez chaque valeur comme pourcentage du total de sa catégorie et attribuez le texte au cadre texte renvoyé par [getTextFrameForOverriding](https://reference.aspose.com/slides/fr/python-java/aspose.slides/datalabel/#getTextFrameForOverriding). Cet exemple utilise les données de graphique par défaut et affiche les pourcentages avec deux décimales dans une police de 8 points. Les catégories dont le total est zéro sont ignorées pour éviter une division par zéro. Recalculez le texte d'étiquette personnalisé si les données du graphique changent.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Portion, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 400, 400)

    chart_series = chart.getChartData().getSeries()
    category_totals = [0.0] * chart.getChartData().getCategories().size()
    for category_index in range(len(category_totals)):
        for series_index in range(chart_series.size()):
            data_point = chart_series.get_Item(series_index).getDataPoints().get_Item(category_index)
            category_totals[category_index] += float(data_point.getValue().getData())

    for series_index in range(chart_series.size()):
        series = chart_series.get_Item(series_index)
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(False)

        for point_index in range(series.getDataPoints().size()):
            data_point = series.getDataPoints().get_Item(point_index)
            label = data_point.getLabel()
            if category_totals[point_index] == 0:
                print(f"Cannot calculate a percentage for category {point_index}: the total is zero.")
                continue
            point_percentage = float(data_point.getValue().getData()) / category_totals[point_index] * 100

            portion = Portion()
            portion.setText(f"{point_percentage:.2f} %")
            portion.getPortionFormat().setFontHeight(8)
            label.getTextFrameForOverriding().setText("")
            paragraph = label.getTextFrameForOverriding().getParagraphs().get_Item(0)
            paragraph.getPortions().add(portion)

            label_format = label.getDataLabelFormat()
            label_format.setShowValue(True)
            label_format.setShowSeriesName(False)
            label_format.setShowPercentage(False)
            label_format.setShowLegendKey(False)
            label_format.setShowCategoryName(False)
            label_format.setShowBubbleSize(False)

    presentation.save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Définir le signe de pourcentage avec les étiquettes de données du graphique**

Lorsque les valeurs sont stockées sous forme de fractions, utilisez [setNumberFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/datalabelformat/#setNumberFormat) pour afficher les pourcentages. Passez `False` à [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/fr/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) pour appliquer le format d'étiquette indépendamment des cellules source.

Cet exemple crée un graphique à colonnes empilées à 100 % avec des séries rouge et bleue sur quatre catégories. Chaque paire de valeurs totalise 1. Le format d'étiquette `0.0%` affiche 0.30 comme 30.0 %, tandis que l'axe vertical utilise deux décimales. Les deux séries utilisent un texte d'étiquette blanc de 10 points.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400)

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%")

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    for i in range(4):
        category_cell = workbook.getCell(worksheet_index, i + 1, 0, f"Category {i + 1}")
        chart.getChartData().getCategories().add(category_cell)

    series_names = ["Reds", "Blues"]
    series_colors = [Color.RED, Color.BLUE]
    values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]]

    for i, series_name in enumerate(series_names):
        series_cell = workbook.getCell(worksheet_index, 0, i + 1, series_name)
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())
        for j, value in enumerate(values[i]):
            value_cell = workbook.getCell(worksheet_index, j + 1, i + 1, jpype.JDouble(value))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

        series.getFormat().getFill().setFillType(FillType.Solid)
        series.getFormat().getFill().getSolidFillColor().setColor(series_colors[i])

        label_format = series.getLabels().getDefaultDataLabelFormat()
        label_format.setShowValue(True)
        label_format.setNumberFormatLinkedToSource(False)
        label_format.setNumberFormat("0.0%")
        portion_format = label_format.getTextFormat().getPortionFormat()
        portion_format.setFontHeight(10)
        portion_format.getFillFormat().setFillType(FillType.Solid)
        portion_format.getFillFormat().getSolidFillColor().setColor(Color.WHITE)

    presentation.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Lire le texte réel des étiquettes de données**

Utilisez [getActualLabelText](https://reference.aspose.com/slides/fr/python-java/aspose.slides/datalabel/#getActualLabelText) pour récupérer le texte produit par les paramètres d'une étiquette de données. Cela est utile lors de l'extraction d'étiquettes pour des rapports, la recherche de contenu dans une présentation ou la validation de graphiques générés. Dans l'exemple ci‑dessous, le [format d'étiquette de données](https://reference.aspose.com/slides/fr/python-java/aspose.slides/datalabelformat/) par défaut combine chaque nom de catégorie, nom de série et valeur. Un point formate sa valeur comme pourcentage, et un autre utilise du texte personnalisé provenant de [getTextFrameForOverriding](https://reference.aspose.com/slides/fr/python-java/aspose.slides/datalabel/#getTextFrameForOverriding).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    first_category_cell = workbook.getCell(0, 1, 0, "Q1")
    chart.getChartData().getCategories().add(first_category_cell)
    second_category_cell = workbook.getCell(0, 2, 0, "Q2")
    chart.getChartData().getCategories().add(second_category_cell)

    north_series_cell = workbook.getCell(0, 0, 1, "North")
    north = chart.getChartData().getSeries().add(north_series_cell, chart.getType())
    north_first_value_cell = workbook.getCell(0, 1, 1, jpype.JDouble(0.25))
    north.getDataPoints().addDataPointForBarSeries(north_first_value_cell)
    north_second_value_cell = workbook.getCell(0, 2, 1, jpype.JDouble(0.75))
    north.getDataPoints().addDataPointForBarSeries(north_second_value_cell)

    south_series_cell = workbook.getCell(0, 0, 2, "South")
    south = chart.getChartData().getSeries().add(south_series_cell, chart.getType())
    south_first_value_cell = workbook.getCell(0, 1, 2, jpype.JDouble(0.40))
    south.getDataPoints().addDataPointForBarSeries(south_first_value_cell)
    south_second_value_cell = workbook.getCell(0, 2, 2, jpype.JDouble(0.60))
    south.getDataPoints().addDataPointForBarSeries(south_second_value_cell)

    for series in chart.getChartData().getSeries():
        label_format = series.getLabels().getDefaultDataLabelFormat()
        label_format.setShowCategoryName(True)
        label_format.setShowSeriesName(True)
        label_format.setShowValue(True)

    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormatLinkedToSource(False)
    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormat("0%")
    south.getLabels().get_Item(0).getTextFrameForOverriding().setText("Reviewed")

    for series in chart.getChartData().getSeries():
        for point in series.getDataPoints():
            label = point.getLabel()
            if not label.isVisible():
                continue

            print(f"Value: {point.getValue().getData()}; label: {label.getActualLabelText()}")
finally:
    presentation.dispose()
```

Le nombre stocké dans un point de données reste `0.75`, même lorsque son étiquette montre `75%` ainsi que les noms de catégorie et de série. Le texte personnalisé remplace le texte d'étiquette généré. [getActualLabelText](https://reference.aspose.com/slides/fr/python-java/aspose.slides/datalabel/#getActualLabelText) renvoie la chaîne d'étiquette résultante dans les deux cas. Vérifiez [isVisible](https://reference.aspose.com/slides/fr/python-java/aspose.slides/datalabel/#isVisible) séparément, comme indiqué ci‑dessus, lorsque vous ne souhaitez extraire que les étiquettes visibles.

## **Contrôler les étiquettes de données au‑delà du maximum de l'axe**

Lorsque vous limitez manuellement une plage d'axe, certains points de données peuvent dépasser son maximum. Utilisez [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chart/#setShowDataLabelsOverMaximum) pour contrôler si leurs étiquettes de données sont affichées. Ce paramètre modifie la visibilité des étiquettes ; il ne modifie pas la plage de l'axe ni les valeurs sous‑jacentes.

L'exemple ci‑dessous crée un graphique à colonnes groupées 2D avec des valeurs de 60 et 120. Il passe `False` à [setAutomaticMaxValue](https://reference.aspose.com/slides/fr/python-java/aspose.slides/axis/#setAutomaticMaxValue) et fixe le maximum à 100 avec [setMaxValue](https://reference.aspose.com/slides/fr/python-java/aspose.slides/axis/#setMaxValue) sur l'axe vertical. La première diapositive autorise les étiquettes au‑delà du maximum ; une copie de cette diapositive les désactive. Les deux diapositives sont enregistrées dans `DataLabelsOverMaximum.pptx`.

Activez les étiquettes de valeur avec [setShowValue](https://reference.aspose.com/slides/fr/python-java/aspose.slides/datalabelformat/#setShowValue). Le paramètre au niveau du graphique n'active pas l'affichage des valeurs par lui‑même et ne remplace pas la désactivation de l'affichage des valeurs d'une étiquette individuelle. Cet exemple active les valeurs pour l'ensemble de la série et utilise [setPosition](https://reference.aspose.com/slides/fr/python-java/aspose.slides/datalabelformat/#setPosition) pour placer les étiquettes à l'extrémité extérieure de chaque colonne.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LegendDataLabelPosition, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setLegend(False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()

    first_category = workbook.getCell(0, 1, 0, "Within range")
    second_category = workbook.getCell(0, 2, 0, "Above maximum")

    chart.getChartData().getCategories().add(first_category)
    chart.getChartData().getCategories().add(second_category)

    series_name = workbook.getCell(0, 0, 1, "Values")
    series = chart.getChartData().getSeries().add(series_name, chart.getType())

    first_value = workbook.getCell(0, 1, 1, jpype.JDouble(60))
    second_value = workbook.getCell(0, 2, 1, jpype.JDouble(120))

    series.getDataPoints().addDataPointForBarSeries(first_value)
    series.getDataPoints().addDataPointForBarSeries(second_value)

    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd)

    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setMaxValue(100)
    chart.setShowDataLabelsOverMaximum(True)

    second_slide = presentation.getSlides().addClone(slide)
    second_chart = second_slide.getShapes().get_Item(0)
    second_chart.setShowDataLabelsOverMaximum(False)

    presentation.save("DataLabelsOverMaximum.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Les images suivantes montrent les diapositives enregistrées rendues par Microsoft PowerPoint. Avec `True`, l'étiquette **120** est visible à la limite supérieure ; avec `False`, elle est masquée. L'étiquette **60** reste visible, le maximum de l'axe reste à **100**, et le deuxième point de données reste **120** dans les deux cas.

| setShowDataLabelsOverMaximum(True) | setShowDataLabelsOverMaximum(False) |
| --- | --- |
| ![Graphique PowerPoint affichant l’étiquette de valeur 120 avec un maximum d’axe de 100](data-labels-over-maximum-true.png) | ![Graphique PowerPoint masquant l’étiquette de valeur 120 avec un maximum d’axe de 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Cet exemple utilise un graphique à colonnes 2D avec un axe de valeurs. Les graphiques sans axe de valeurs, tels que les graphiques circulaires et les graphiques en anneau, n'ont pas de maximum d'axe à limiter de cette façon.
{{% /alert %}}

## **Définir la distance de l'étiquette par rapport à un axe**

Utilisez [setLabelOffset](https://reference.aspose.com/slides/fr/python-java/aspose.slides/axis/#setLabelOffset) pour contrôler la distance entre les étiquettes de l'axe des catégories et l'axe. La valeur est un pourcentage de la taille maximale de police des étiquettes d'axe. Cet exemple crée un graphique à colonnes groupées et fixe le décalage d'étiquette de l'axe horizontal à 500. Ce paramètre affecte les étiquettes de l'axe des catégories plutôt que les étiquettes attachées aux points de données individuels.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)
    chart.getAxes().getHorizontalAxis().setLabelOffset(500)

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ajuster la position des étiquettes**

Sur un graphique circulaire, ajustez les positions des étiquettes de données pour améliorer l'espacement et laisser de la place aux lignes de repère.

Cet exemple affiche la valeur du premier point de données, place son étiquette à l'extérieur de la tranche et ajuste ses décalages horizontaux et verticaux en utilisant [setX](https://reference.aspose.com/slides/fr/python-java/aspose.slides/datalabel/#setX) et [setY](https://reference.aspose.com/slides/fr/python-java/aspose.slides/datalabel/#setY). Ces décalages sont relatifs à la largeur et à la hauteur du graphique, respectivement.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LegendDataLabelPosition, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 200, 200)
    series = chart.getChartData().getSeries()
    
    label = series.get_Item(0).getLabels().get_Item(0)
    label.getDataLabelFormat().setShowValue(True)
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd)
    label.setX(0.71)
    label.setY(0.04)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Graphique circulaire avec une position d’étiquette de données ajustée](pie-chart-adjusted-label.png)

## **FAQ**

**Comment puis‑je empêcher les étiquettes de données de se chevaucher sur des graphiques denses ?**

Combinez le placement automatique des étiquettes, les lignes de repère et une taille de police réduite ; si nécessaire, masque‑z certains champs (par exemple, la catégorie) ou n’affichez les étiquettes que pour les valeurs extrêmes ou les points clés.

**Comment puis‑je désactiver les étiquettes uniquement pour les valeurs zéro, négatives ou vides ?**

Filtrez les points de données avant d’activer les étiquettes et désactivez l’affichage pour les valeurs égales à 0, les valeurs négatives ou les valeurs manquantes selon une règle définie.

**Comment puis‑je garantir un style d'étiquette cohérent lors de l'exportation en PDF/images ?**

Définissez explicitement la famille et la taille de police et vérifiez que la police est disponible dans l'environnement de rendu afin d'éviter le recours à une police de secours.