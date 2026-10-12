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
- position de l'étiquette
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Apprenez à ajouter et formater les étiquettes de données de graphique dans les présentations PowerPoint en utilisant Aspose.Slides pour Python via Java pour des diapositives plus attrayantes."
---
## **Introduction**

Les etiquettes de donnees affichent des informations sur les series de graphiques et les points de donnees individuels, aidant les lecteurs a identifier les valeurs et a comprendre le graphique. Cet article explique comment formater les valeurs, afficher les pourcentages, lire le texte des etiquettes, contrôler les etiquettes au-dela du maximum de l'axe, ajuster l'espacement des etiquettes de l'axe des categories et positionner les etiquettes des graphiques circulaires.

## **Definir la precision des donnees dans les etiquettes de graphique**

Utilisez [setNumberFormatOfValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setNumberFormatOfValues) pour formater les valeurs des series. Cet exemple cree un graphique en courbes avec des donnees par defaut, affiche son tableau de donnees et active les etiquettes de valeur pour la premiere serie. Le format `#,##0.00` affiche un separateur de milliers et deux decimals sans modifier les valeurs sous-jacent.

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

## **Afficher le pourcentage comme etiquettes**

Pour un histogramme empile, calculez chaque valeur en pourcentage du total de sa categorie et affectez le texte au cadre de texte renvoye par [getTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getTextFrameForOverriding). Cet exemple utilise les donnees de graphique par defaut et affiche les pourcentages avec deux decimals dans une police de 8 points. Les categories dont le total est nul sont ignorees afin d'eviter une division par zero. Recalculez le texte d'etiquette personnalise si les donnees du graphique changent.

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

## **Definir le signe de pourcentage avec les etiquettes de donnees du graphique**

Lorsque les valeurs sont stockees sous forme de fractions, utilisez [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormat) pour afficher les pourcentages. Passez `False` a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) pour appliquer le format d'etiquette independamment des cellules sources.

Cet exemple cree un graphique a colonnes empilees a 100% avec des series rouge et bleue sur quatre categories. Chaque paire de valeurs s'additionne a 1. Le format d'etiquette `0.0%` affiche 0.30 comme 30.0%, tandis que l'axe vertical utilise deux decimals. Les deux series utilisent du texte d'etiquette blanc de 10 points.

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

## **Lire le texte reel des etiquettes de donnees**

Utilisez [getActualLabelText](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getActualLabelText) pour recuperer le texte genere par les parametres d'une etiquette de donnee. Ceci est utile lors de l'extraction d'etiquettes pour des rapports, de la recherche de contenu de presentation ou de la validation de graphiques generes. Dans l'exemple ci-dessous, le [format d'etiquette de donnees](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/) par defaut combine le nom de chaque categorie, le nom de la serie et la valeur. Un point formate sa valeur en pourcentage, et un autre utilise du texte personnalise provenant de [getTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getTextFrameForOverriding).

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

Le nombre stocke dans un point de donnee reste `0.75`, meme si son etiquette affiche `75%` avec les noms de categorie et de serie. Le texte personnalise remplace le texte d'etiquette genere. [getActualLabelText](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getActualLabelText) renvoie la chaine d'etiquette resultante dans les deux cas. Verifiez [isVisible](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#isVisible) separement, comme indique ci-dessus, lorsque vous souhaitez extraire uniquement les etiquettes visibles.

## **Controler les etiquettes de donnees au-dela du maximum de l'axe**

Lorsque vous limitez manuellement la plage d'un axe, certains points de donnee peuvent depasser son maximum. Utilisez [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setShowDataLabelsOverMaximum) pour controle si leurs etiquettes de donnees sont affichees. Ce parametre modifie la visibilite des etiquettes; il ne modifie pas la plage de l'axe ni les valeurs sous-jacent.

L'exemple ci-dessous cree un histogramme groupe 2D avec des valeurs de 60 et 120. Il transmet `False` a [setAutomaticMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMaxValue) et fixe le maximum a 100 avec [setMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMaxValue) sur l'axe vertical. La premiere diapositive autorise les etiquettes au-dela du maximum; une copie de cette diapositive les desactive. Les deux diapositives sont enregistrees dans `DataLabelsOverMaximum.pptx`.

Activez les etiquettes de valeur avec [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue). Le parametre au niveau du graphique n'active pas l'affichage des valeurs en lui-meme et ne remplace pas l'affichage desactive d'une etiquette individuelle. Cet exemple active les valeurs pour toute la serie et utilise [setPosition](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setPosition) pour placer les etiquettes a l'extermité externe de chaque colonne.

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

Les images suivantes montrent les diapositives enregistrees rendues par Microsoft PowerPoint. Avec `True`, l'etiquette **120** est visible a la limite superieure; avec `False`, elle est masquee. L'etiquette **60** reste visible, le maximum de l'axe reste a **100**, et le deuxieme point de donnee reste **120** dans les deux cas.

| setShowDataLabelsOverMaximum(True) | setShowDataLabelsOverMaximum(False) |
| --- | --- |
| ![Graphique PowerPoint affichant l'etiquette de valeur 120 avec un maximum d'axe de 100](data-labels-over-maximum-true.png) | ![Graphique PowerPoint masquant l'etiquette de valeur 120 avec un maximum d'axe de 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Type de graphique" %}}
Cet exemple utilise un histogramme a colonnes 2D avec un axe de valeur. Les graphiques sans axe de valeur, comme les graphiques circulaires et les graphiques en anneau, n'ont pas de maximum d'axe a limiter de cette maniere.
{{% /alert %}}

## **Definir la distance de l'etiquette par rapport a un axe**

Utilisez [setLabelOffset](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLabelOffset) pour controller la distance entre les etiquettes de l'axe des categories et l'axe. La valeur est un pourcentage de la taille maximale de police des etiquettes d'axe. Cet exemple cree un histogramme groupe et definit le decalage des etiquettes de l'axe horizontal a 500. Ce parametre affecte les etiquettes de l'axe des categories pluto que les etiquettes attachees aux points de donnee individuels.

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

## **Ajuster la position de l'etiquette**

Sur un graphique circulaire, ajustez les positions des etiquettes de donnees pour ameliorer l'espacement et laisser de la place aux lignes de repere.

Cet exemple affiche la valeur du premier point de donnee, place son etiquette a l'exterieur de la tranche et ajuste ses decalages horizontal et vertical a l'aide de [setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) et [setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY). Ces decalages sont relatifs a la largeur et a la hauteur du graphique, respectivement.

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

![Graphique circulaire avec une position d'etiquette de donnee ajustee](pie-chart-adjusted-label.png)

## **Ajouter plusieurs lignes d'etiquettes de donnees au-dessus d'un histogramme a colonnes**

Cet exemple cree un histogramme a colonnes avec deux lignes d'etiquettes de donnees au-dessus de la zone de trace. La serie A affiche les colonnes visibles, tandis que les series B et C fournissent les etiquettes supplementaires. Leurs colonnes sont masquees en supprimant le remplissage et le contour. La methode [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap) aligne les trois series sur les memes centres de categorie.

Les parametres du [ChartPlotArea](https://reference.aspose.com/slides/python-java/aspose.slides/chartplotarea/) reservent de l'espace pour les lignes d'etiquettes. Apres que [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) calcule les positions par defaut, [DataLabel.setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) et [DataLabel.setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY) conservent l'alignement horizontal et appliquent des decalages verticaux pour organiser les etiquettes en deux lignes. Les nombres restent des etiquettes de donnees liees aux valeurs de serie; seuls les titres de ligne sont des formes de texte separees.

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

    # Réserver de l'espace au-dessus du tracé pour deux lignes d'étiquettes de données.
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
            # la position d'étiquette par défaut, exprimée comme une fraction de la hauteur du graphique.
            data_label.setX(0)
            data_label.setY(row_top - data_label.getActualY() / chart.getHeight())

        # Seul le titre de la ligne est une forme de texte distincte.
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

![Histogramme a colonnes avec deux lignes d'etiquettes de donnees au-dessus de la zone de trace](multiple-rows-of-labels.png)

## **FAQ**

**Comment puis-je empecher les etiquettes de donnees de se chevaucher sur des graphiques denses?**

Combinez le placement automatique des etiquettes, les lignes de repere et une taille de police reduite; si necessaire, masquez certains champs (par exemple la categorie) ou affichez les etiquettes uniquement pour les valeurs extremes ou les points cles.

**Comment desactiver les etiquettes uniquement pour les valeurs nulles, negatives ou vides?**

Filtrez les points de donnee avant d'activer les etiquettes et desactivez l'affichage pour les valeurs egales a 0, les valeurs negatives ou les valeurs manquantes selon une regle definie.

**Comment garantir un style d'etiquette coherent lors de l'exportation en PDF/images?**

Definissez explicitement la famille et la taille de police et verifiez que la police est disponible dans l'environnement de rendu pour eviter le recours a une police de substitution.