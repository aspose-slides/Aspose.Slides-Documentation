---
title: Gérer les étiquettes de données de graphique dans les présentations avec Python
linktitle: Étiquette de données
type: docs
url: /fr/python-java/chart-data-label/
keywords:
- graphique
- étiquette de données
- précision des données
- pourcentage
- distance de l'étiquette
- emplacement de l'étiquette
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Apprenez à ajouter et formater les étiquettes de données de graphique dans les présentations PowerPoint en utilisant Aspose.Slides pour Python via Java afin de créer des diapositives plus attrayantes."
---
## **Introduction**

Les étiquettes de données affichent des informations sur les séries du graphique et les points de données individuels, aidant les lecteurs à identifier les valeurs et à comprendre le graphique. Cet article explique comment formater les valeurs, afficher les pourcentages, lire le texte de l’étiquette, contrôler les étiquettes au‑delà du maximum de l’axe, ajuster l’espacement des étiquettes de l’axe des catégories et positionner les étiquettes d’un graphique circulaire.

## **Compter les étiquettes de données visibles**

Utilisez [obtenir le nombre d’étiquettes de données visibles](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelcollection/#getCountOfVisibleDataLabels) pour vérifier combien d’étiquettes sont activées avant de publier une présentation. Contrairement à [obtenir le nombre total](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelcollection/#getCount), qui renvoie le nombre total d’étiquettes dans la collection, cela prend en compte les paramètres par défaut de la série et les réglages individuels des étiquettes.

Cet exemple crée un graphique en colonnes avec une série et trois points de données. Il accède à la collection d’étiquettes de la série via [obtenir les étiquettes](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getLabels) et affiche le nombre visible au fur et à mesure que les paramètres changent : **0, 3, 2, 3**. Le nombre total reste **3**.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    series_cell = workbook.getCell(0, 0, 1, "Values")
    series = chart.getChartData().getSeries().add(series_cell, chart.getType())

    for i in range(3):
        category_cell = workbook.getCell(0, i + 1, 0, f"Category {i + 1}")
        chart.getChartData().getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, jpype.JDouble((i + 1) * 10))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    labels = series.getLabels()
    print(f"Total: {labels.getCount()}; visible: {labels.getCountOfVisibleDataLabels()}")  # Total: 3; visible: 0

    labels.getDefaultDataLabelFormat().setShowValue(True)
    print(f"Visible: {labels.getCountOfVisibleDataLabels()}")  # Visible: 3

    labels.get_Item(1).getDataLabelFormat().setShowValue(False)
    print(f"Visible: {labels.getCountOfVisibleDataLabels()}")  # Visible: 2

    labels.get_Item(1).getDataLabelFormat().setShowLegendKey(True)
    print(f"Visible: {labels.getCountOfVisibleDataLabels()}")  # Visible: 3
finally:
    presentation.dispose()
```

La méthode [obtenir le format d’étiquette de données par défaut](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelcollection/#getDefaultDataLabelFormat) de la série fournit les paramètres par défaut. Passer `True` à [définir l’affichage de la valeur](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) y affiche les valeurs pour les trois étiquettes. Passer `False` via le [obtenir le format d’étiquette de données](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getDataLabelFormat) d’une étiquette remplace ce paramètre pour l’étiquette sélectionnée. Passer `True` à [définir l’affichage de la clé de légende](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowLegendKey) fait que cette étiquette soit à nouveau comptée comme visible, même si sa valeur reste cachée.

Le compte visible reflète les paramètres de visibilité. Il ne mesure pas si les étiquettes se chevauchent, sont coupées ou sont lisibles dans le rendu du graphique.

## **Définir la précision des valeurs dans les étiquettes de données du graphique**

Utilisez [définir le format numérique des valeurs](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setNumberFormatOfValues) pour formater les valeurs de la série. Cet exemple crée un graphique en courbes avec des données par défaut, affiche son tableau de données et active les étiquettes de valeur pour la première série. Le format `#,##0.00` affiche un séparateur de milliers et deux décimales sans modifier les valeurs sous‑jacentes.

```python
import jpime
import asposeslides

if not jpime.isJVMStarted():
    jpime.startJVM()

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

Pour formater les cellules numériques d’un classeur intégré au graphique, consultez [Définir des formats numériques personnalisés pour les cellules du classeur](/slides/fr/python-java/chart-workbook/#set-custom-number-formats-for-workbook-cells). Cet exemple montre également les étiquettes de valeur suivant le format des cellules source tout en conservant les valeurs numériques stockées.

## **Afficher le pourcentage comme étiquette**

Pour un graphique en colonnes empilées, calculez chaque valeur comme pourcentage du total de sa catégorie et assignez le texte au cadre de texte renvoyé par [obtenir le cadre de texte pour la surcharge](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getTextFrameForOverriding). Cet exemple utilise les données du graphique par défaut et affiche les pourcentages avec deux décimales dans une police de 8 pt. Les catégories dont le total est nul sont ignorées pour éviter la division par zéro. Recalculez le texte de l’étiquette personnalisée si les données du graphique changent.

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

Lorsque les valeurs sont stockées sous forme de fractions, utilisez [définir le format numérique](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormat) pour afficher les pourcentages. Passez `False` à [définir le lien du format numérique à la source](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) pour appliquer le format de l’étiquette indépendamment des cellules source.

Cet exemple crée un graphique en colonnes empilées à 100 % avec des séries rouge et bleue réparties sur quatre catégories. Chaque paire de valeurs s’additionne à 1. Le format d’étiquette `0.0%` affiche 0,30 comme 30,0 %, tandis que l’axe vertical utilise deux décimales. Les deux séries utilisent un texte d’étiquette blanc de 10 pt.

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

Utilisez [obtenir le texte réel de l’étiquette](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getActualLabelText) pour récupérer le texte produit par les paramètres d’une étiquette. Ceci est utile lors de l’extraction d’étiquettes pour des rapports, la recherche de contenu dans une présentation ou la validation de graphiques générés. Dans l’exemple ci‑dessous, le [format d’étiquette de données](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/) par défaut combine chaque nom de catégorie, nom de série et valeur. Un point formate sa valeur en pourcentage, et un autre utilise un texte personnalisé provenant de [obtenir le cadre de texte pour la surcharge](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getTextFrameForOverriding).

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

Le nombre stocké dans un point de données reste `0.75`, même lorsque son étiquette affiche `75 %` avec les noms de catégorie et de série. Le texte personnalisé remplace le texte d’étiquette généré. [obtenir le texte réel de l’étiquette](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getActualLabelText) renvoie la chaîne d’étiquette résultante dans les deux cas. Vérifiez [est visible](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#isVisible) séparément, comme indiqué ci‑dessus, lorsque vous ne voulez extraire que les étiquettes visibles.

## **Contrôler les étiquettes de données au‑delà du maximum de l’axe**

Lorsque vous limitez manuellement la plage d’un axe, certains points de données peuvent dépasser son maximum. Utilisez [définir l’affichage des étiquettes de données au‑delà du maximum](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setShowDataLabelsOverMaximum) pour contrôler si leurs étiquettes sont affichées. Ce réglage modifie la visibilité des étiquettes ; il ne modifie pas la plage de l’axe ni les valeurs sous‑jacentes.

L’exemple ci‑dessous crée un graphique en colonnes groupées 2D avec des valeurs de 60 et 120. Il passe `False` à [définir la valeur maximale automatique](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMaxValue) et fixe le maximum à 100 avec [définir la valeur maximale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMaxValue) sur l’axe vertical. La première diapositive autorise les étiquettes au‑delà du maximum ; une copie de cette diapositive les désactive. Les deux diapositives sont enregistrées dans `DataLabelsOverMaximum.pptx`.

Activez les étiquettes de valeur avec [définir l’affichage de la valeur](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue). Le réglage au niveau du graphique n’active pas l’affichage des valeurs en soi et ne surpasse pas la désactivation de l’affichage de la valeur d’une étiquette individuelle. Cet exemple active les valeurs pour toute la série et utilise [définir la position](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setPosition) pour placer les étiquettes à l’extrémité extérieure de chaque colonne.

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

Les images suivantes montrent les diapositives enregistrées rendues par Microsoft PowerPoint. Avec `True`, l’étiquette **120** est visible à la limite supérieure ; avec `False`, elle est masquée. L’étiquette **60** reste visible, le maximum de l’axe reste à **100** et le deuxième point de données reste **120** dans les deux cas.

| setShowDataLabelsOverMaximum(True) | setShowDataLabelsOverMaximum(False) |
| --- | --- |
| ![Graphique PowerPoint affichant l’étiquette de valeur 120 avec un maximum d’axe de 100](data-labels-over-maximum-true.png) | ![Graphique PowerPoint masquant l’étiquette de valeur 120 avec un maximum d’axe de 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}

Cet exemple utilise un graphique en colonnes 2D avec un axe de valeurs. Les graphiques sans axe de valeurs, tels que les graphiques circulaires et les graphiques en anneau, n’ont pas de maximum d’axe à limiter de cette façon.

{{% /alert %}}

## **Définir la distance de l’étiquette par rapport à un axe**

Utilisez [définir le décalage de l’étiquette](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLabelOffset) pour contrôler la distance entre les étiquettes de l’axe des catégories et l’axe lui‑même. La valeur est un pourcentage de la taille maximale de police des étiquettes de l’axe. Cet exemple crée un graphique en colonnes groupées et définit le décalage de l’étiquette de l’axe horizontal à 500. Ce réglage affecte les étiquettes de l’axe des catégories plutôt que les étiquettes attachées aux points de données individuels.

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

Sur un graphique circulaire, ajustez les positions des étiquettes de données pour améliorer l’espacement et laisser de la place aux lignes de repère.

Cet exemple affiche la valeur du premier point de données, place son étiquette à l’extérieur de la part et ajuste ses décalages horizontaux et verticaux à l’aide de [définir X](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) et [définir Y](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY). Ces décalages sont relatifs à la largeur et à la hauteur du graphique, respectivement.

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

## **Formater les lignes de repère**

Lorsque les étiquettes d’un graphique circulaire sont placées à l’extérieur de leurs parts, les lignes de repère aident les lecteurs à associer chaque valeur à la bonne part. Une couleur contrastée et une ligne légèrement plus épaisse facilitent la lecture, tandis que la transparence et un style pointillé maintiennent les lignes discrètes.

Utilisez [obtenir le format des lignes de repère](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelcollection/#getLeaderLinesFormat) pour formater les lignes de repère au niveau de la collection d’étiquettes de données de la série. Les paramètres dans `series.getLabels().getLeaderLinesFormat().getLine()` s’appliquent à la collection, et non à une étiquette individuelle.

Cet exemple crée un graphique circulaire avec des données par défaut, affiche les valeurs à l’extérieur des parts et active [définir l’affichage des lignes de repère](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowLeaderLines). Il déplace deux étiquettes plus loin de leurs parts à l’aide des décalages [définir X](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) et [définir Y](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY), exprimés comme fractions de la largeur et de la hauteur du graphique. Aucune présentation d’entrée n’est requise.

Le [obtenir le format de remplissage](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getFillFormat) de la ligne définit une couleur bleue solide avec une valeur alpha de 191 sur 255, soit environ 25 % de transparence. [définir la largeur](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth) fixe l’épaisseur à 2 pt, et [définir le style de tiret](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle) rend la ligne pointillée.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LegendDataLabelPosition, LineDashStyle, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 80, 50, 560, 400)
    chart.setLegend(False)

    series = chart.getChartData().getSeries().get_Item(0)

    label_format = series.getLabels().getDefaultDataLabelFormat()
    label_format.setShowValue(True)
    label_format.setPosition(LegendDataLabelPosition.OutsideEnd)
    label_format.setShowLeaderLines(True)

    # Déplacer deux étiquettes plus loin de leurs parts.
    series.getLabels().get_Item(0).setX(0.10)
    series.getLabels().get_Item(0).setY(-0.05)
    series.getLabels().get_Item(1).setX(-0.10)
    series.getLabels().get_Item(1).setY(0.05)

    line = series.getLabels().getLeaderLinesFormat().getLine()
    line.getFillFormat().setFillType(FillType.Solid)
    color = Color(30, 90, 160, 191)
    line.getFillFormat().getSolidFillColor().setColor(color)
    line.setWidth(2)
    line.setDashStyle(LineDashStyle.Dash)

    presentation.save("FormattedLeaderLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Activer les lignes de repère ne garantit pas qu’une ligne apparaisse pour chaque étiquette. La visibilité dépend du placement des étiquettes et du comportement de mise en page du graphique. Dans cet exemple, les deux étiquettes déplacées ont des lignes de repère visibles ; les étiquettes restant proches de leurs parts n’en ont pas besoin.

L’image suivante montre le fichier `FormattedLeaderLines.pptx` enregistré et rendu avec Aspose.Slides :

![Graphique circulaire avec des lignes de repère bleues, semi‑transparentes et pointillées reliant deux étiquettes extérieures à leurs parts](formatted-leader-lines.png)

## **Ajouter plusieurs rangées d’étiquettes de données au‑dessus d’un graphique en colonnes**

Cet exemple crée un graphique en colonnes avec deux rangées d’étiquettes au‑dessus de la zone de tracé. La Série A affiche les colonnes visibles, tandis que les Séries B et C fournissent les étiquettes supplémentaires. Leurs colonnes sont cachées en supprimant le remplissage et le contour. La méthode [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap) aligne les trois séries sur les mêmes centres de catégories.

Les paramètres du [ChartPlotArea](https://reference.aspose.com/slides/python-java/aspose.slides/chartplotarea/) réservent de l’espace pour les rangées d’étiquettes. Après que [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) calcule les positions par défaut, [DataLabel.setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) et [DataLabel.setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY) conservent l’alignement horizontal et appliquent des décalages verticaux pour disposer les étiquettes en deux rangées. Les nombres restent des étiquettes liées aux valeurs des séries ; seules les en‑têtes de rangée sont des formes de texte distinctes.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LayoutTargetType, LegendDataLabelPosition, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 40, 40, 640, 200)
    chart.setTitle(False)
    chart.setLegend(False)
    chart.getTextFormat().getPortionFormat().setFontHeight(12)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    categories = ["North", "South", "East", "West"]
    series_names = ["Series A", "Series B", "Series C"]
    series_values = [[35, 42, 28, 47], [22, 31, 19, 26], [12, 16, 14, 18]]

    for category_index, category in enumerate(categories):
        category_cell = workbook.getCell(0, category_index + 1, 0, category)
        chart.getChartData().getCategories().add(category_cell)

    for series_index, series_name in enumerate(series_names):
        series_cell = workbook.getCell(0, 0, series_index + 1, series_name)
        series = chart.getChartData().getSeries().add(series_cell, ChartType.ClusteredColumn)

        for category_index, value in enumerate(series_values[series_index]):
            value_cell = workbook.getCell(0, category_index + 1, series_index + 1, jpype.JDouble(value))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

        if series_index > 0:
            # Masquer les colonnes de B et C, mais conserver leurs étiquettes de données.
            series.getFormat().getFill().setFillType(FillType.NoFill)
            series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
            label_format = series.getLabels().getDefaultDataLabelFormat()
            label_format.setShowValue(True)
            label_format.getTextFormat().getPortionFormat().setFontHeight(12)
            label_fill = label_format.getTextFormat().getPortionFormat().getFillFormat()
            label_fill.setFillType(FillType.Solid)
            label_fill.getSolidFillColor().setColor(Color.BLACK)
            label_format.setPosition(LegendDataLabelPosition.InsideBase)

    # Aligner les trois séries sur les mêmes centres de catégorie.
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setOverlap(jpype.JByte(100))

    # Utiliser moins de lignes de grille pour cet exemple compact.
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setMajorUnit(10)

    # Réserver de l'espace au-dessus du tracé pour deux rangées d'étiquettes de données.
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner)
    chart.getPlotArea().setX(0.15)
    chart.getPlotArea().setY(0.32)
    chart.getPlotArea().setWidth(0.80)
    chart.getPlotArea().setHeight(0.48)
    chart.validateChartLayout()

    for series_index in range(1, len(series_names)):
        series = chart.getChartData().getSeries().get_Item(series_index)
        row_top = 0.15 if series_index == 1 else 0.03

        for category_index in range(len(categories)):
            data_label = series.getDataPoints().get_Item(category_index).getLabel()
            # Conserver la position horizontale par défaut. Y est un décalage depuis
            # la position d'étiquette par défaut, exprimé en fraction de la hauteur du graphique.
            data_label.setX(0)
            data_label.setY(row_top - data_label.getActualY() / chart.getHeight())

        # Seul l'en-tête de rangée est une forme de texte distincte.
        heading_y = chart.getY() + row_top * chart.getHeight()
        row_heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, chart.getX(), heading_y, 85, 18)
        row_heading.getFillFormat().setFillType(FillType.NoFill)
        row_heading.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        row_heading.addTextFrame(series_names[series_index])
        row_heading.getTextFrame().getTextFrameFormat().setMarginTop(0)
        row_heading.getTextFrame().getTextFrameFormat().setMarginBottom(0)
        heading_format = row_heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
        heading_format.setFontHeight(12)
        heading_format.getFillFormat().setFillType(FillType.Solid)
        heading_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    presentation.save("multiple-rows-of-labels.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Graphique en colonnes avec deux rangées d’étiquettes au‑dessus de la zone de tracé](multiple-rows-of-labels.png)

## **FAQ**

**Comment éviter que les étiquettes de données se chevauchent sur des graphiques denses ?**

Combinez le placement automatique des étiquettes, les lignes de repère et une taille de police réduite ; si nécessaire, masquez certains champs (par exemple, la catégorie) ou n’affichez les étiquettes que pour les valeurs extrêmes ou les points clés.

**Comment désactiver les étiquettes uniquement pour les valeurs nulles, négatives ou vides ?**

Filtrez les points de données avant d’activer les étiquettes et désactivez l’affichage pour les valeurs égales à 0, les valeurs négatives ou les valeurs manquantes selon une règle définie.

**Comment garantir un style d’étiquette cohérent lors de l’exportation en PDF ou images ?**

Définissez explicitement la famille et la taille de la police et vérifiez que la police est disponible dans l’environnement de rendu afin d’éviter le recours à une police de repli.