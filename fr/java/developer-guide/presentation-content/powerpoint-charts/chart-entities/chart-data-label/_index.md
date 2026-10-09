---
title: Gérer les étiquettes de données de graphique dans les présentations avec Java
linktitle: Étiquette de données
type: docs
url: /fr/java/chart-data-label/
keywords:
- graphique
- étiquette de données
- précision des données
- pourcentage
- distance de l’étiquette
- position de l’étiquette
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Apprenez à ajouter et à formater les étiquettes de données de graphique dans les présentations PowerPoint à l’aide d’Aspose.Slides pour Java pour des diapositives plus attrayantes."
---
## **Introduction**

Les étiquettes de données affichent des informations sur les séries de graphiques et les points de données individuels, aidant les lecteurs à identifier les valeurs et à comprendre le graphique. Cet article explique comment formater les valeurs, afficher les pourcentages, lire le texte des étiquettes, contrôler les étiquettes au‑delà du maximum de l’axe, ajuster l’espacement des étiquettes de l’axe des catégories et positionner les étiquettes d’un graphique circulaire.

## **Définir la précision des valeurs dans les étiquettes de données du graphique**

Utilisez [setNumberFormatOfValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setNumberFormatOfValues-java.lang.String-) pour formater les valeurs des séries. Cet exemple crée un graphique en ligne avec des données par défaut, affiche son tableau de données et active les étiquettes de valeurs pour la première série. Le format `#,##0.00` affiche un séparateur de milliers et deux décimales sans modifier les valeurs sous‑jacentes.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);
    chart.setDataTable(true);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    series.setNumberFormatOfValues("#,##0.00");
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Afficher le pourcentage sous forme d’étiquettes**

Pour un histogramme empilé, calculez chaque valeur comme pourcentage du total de sa catégorie et affectez le texte au cadre de texte renvoyé par [getTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--). Cet exemple utilise les données de graphique par défaut et affiche les pourcentages avec deux décimales dans une police de 8 points. Les catégories dont le total est zéro sont ignorées afin d’éviter une division par zéro. Recalculez le texte d’étiquette personnalisé si les données du graphique changent.

```java
import com.aspose.slides.*;
import java.util.Locale;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 400, 400);

    double[] categoryTotals = new double[chart.getChartData().getCategories().size()];
    for (int k = 0; k < chart.getChartData().getCategories().size(); k++) {
        for (int i = 0; i < chart.getChartData().getSeries().size(); i++) {
            IChartSeries series = chart.getChartData().getSeries().get_Item(i);
            Number pointValue = (Number) series.getDataPoints().get_Item(k).getValue().getData();
            categoryTotals[k] += pointValue.doubleValue();
        }
    }

    for (int x = 0; x < chart.getChartData().getSeries().size(); x++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);

        for (int j = 0; j < series.getDataPoints().size(); j++) {
            IDataLabel label = series.getDataPoints().get_Item(j).getLabel();
            if (categoryTotals[j] == 0) {
                continue;
            }

            Number pointValue = (Number) series.getDataPoints().get_Item(j).getValue().getData();
            double dataPointPercent = (pointValue.doubleValue() / categoryTotals[j]) * 100;

            IPortion portion = new Portion();
            portion.setText(String.format(Locale.US, "%.2f %%", dataPointPercent));
            portion.getPortionFormat().setFontHeight(8f);

            label.getTextFrameForOverriding().setText("");
            IParagraph paragraph = label.getTextFrameForOverriding().getParagraphs().get_Item(0);
            paragraph.getPortions().add(portion);

            label.getDataLabelFormat().setShowValue(true);
            label.getDataLabelFormat().setShowSeriesName(false);
            label.getDataLabelFormat().setShowPercentage(false);
            label.getDataLabelFormat().setShowLegendKey(false);
            label.getDataLabelFormat().setShowCategoryName(false);
            label.getDataLabelFormat().setShowBubbleSize(false);
        }
    }

    presentation.save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Définir le symbole de pourcentage avec les étiquettes de données du graphique**

Lorsque les valeurs sont stockées sous forme de fractions, utilisez [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) pour afficher les pourcentages. Transmettez `false` à [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) pour appliquer le format d’étiquette indépendamment des cellules sources.

Cet exemple crée un histogramme empilé à 100 % avec des séries rouge et bleue réparties sur quatre catégories. Chaque paire de valeurs totalise 1. Le format d’étiquette `0.0%` affiche 0,30 comme 30,0 %, tandis que l’axe vertical utilise deux décimales. Les deux séries utilisent un texte d’étiquette blanc de 10 points.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;
    for (int i = 0; i < 4; i++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    String[] seriesNames = { "Reds", "Blues" };
    Color[] seriesColors = { Color.RED, Color.BLUE };
    double[][] values = { { 0.30, 0.50, 0.80, 0.65 }, { 0.70, 0.50, 0.20, 0.35 } };

    for (int i = 0; i < seriesNames.length; i++) {
        IChartDataCell seriesCell = workbook.getCell(worksheetIndex, 0, i + 1, seriesNames[i]);
        IChartSeries series = chart.getChartData().getSeries().add(seriesCell, chart.getType());
        for (int j = 0; j < 4; j++) {
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, j + 1, i + 1, values[i][j]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        series.getFormat().getFill().setFillType(FillType.Solid);
        series.getFormat().getFill().getSolidFillColor().setColor(seriesColors[i]);

        IDataLabelFormat labelFormat = series.getLabels().getDefaultDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(false);
        labelFormat.setNumberFormat("0.0%");
        labelFormat.getTextFormat().getPortionFormat().setFontHeight(10);
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.WHITE);
    }

    presentation.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lire le texte réel des étiquettes de données**

Utilisez [getActualLabelText](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#getActualLabelText--) pour récupérer le texte généré par les paramètres d’une étiquette de données. Ceci est utile lors de l’extraction d’étiquettes pour des rapports, la recherche de contenu dans une présentation ou la validation de graphiques générés. Dans l’exemple ci‑dessus, le [format d’étiquette de données](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/) par défaut combine le nom de chaque catégorie, le nom de la série et la valeur. Un point formate sa valeur en pourcentage, et un autre utilise du texte personnalisé provenant de [getTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell firstCategoryCell = workbook.getCell(0, 1, 0, "Q1");
    chart.getChartData().getCategories().add(firstCategoryCell);
    IChartDataCell secondCategoryCell = workbook.getCell(0, 2, 0, "Q2");
    chart.getChartData().getCategories().add(secondCategoryCell);

    IChartDataCell northSeriesCell = workbook.getCell(0, 0, 1, "North");
    IChartSeries north = chart.getChartData().getSeries().add(northSeriesCell, chart.getType());
    IChartDataCell northFirstValueCell = workbook.getCell(0, 1, 1, 0.25);
    north.getDataPoints().addDataPointForBarSeries(northFirstValueCell);
    IChartDataCell northSecondValueCell = workbook.getCell(0, 2, 1, 0.75);
    north.getDataPoints().addDataPointForBarSeries(northSecondValueCell);

    IChartDataCell southSeriesCell = workbook.getCell(0, 0, 2, "South");
    IChartSeries south = chart.getChartData().getSeries().add(southSeriesCell, chart.getType());
    IChartDataCell southFirstValueCell = workbook.getCell(0, 1, 2, 0.40);
    south.getDataPoints().addDataPointForBarSeries(southFirstValueCell);
    IChartDataCell southSecondValueCell = workbook.getCell(0, 2, 2, 0.60);
    south.getDataPoints().addDataPointForBarSeries(southSecondValueCell);

    for (IChartSeries series : chart.getChartData().getSeries()) {
        IDataLabelFormat format = series.getLabels().getDefaultDataLabelFormat();
        format.setShowCategoryName(true);
        format.setShowSeriesName(true);
        format.setShowValue(true);
    }

    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormatLinkedToSource(false);
    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormat("0%");
    south.getLabels().get_Item(0).getTextFrameForOverriding().setText("Reviewed");

    for (IChartSeries series : chart.getChartData().getSeries()) {
        for (IChartDataPoint point : series.getDataPoints()) {
            IDataLabel label = point.getLabel();
            if (!label.isVisible()) {
                continue;
            }

            System.out.println("Value: " + point.getValue().getData() + "; label: " + label.getActualLabelText());
        }
    }
} finally {
    presentation.dispose();
}
```

Le nombre stocké dans un point de données reste `0.75`, même si son étiquette affiche `75 %` avec les noms de catégorie et de série. Le texte personnalisé remplace le texte d’étiquette généré. [getActualLabelText](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#getActualLabelText--) renvoie la chaîne d’étiquette résultante dans les deux cas. Vérifiez [isVisible](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#isVisible--) séparément, comme indiqué ci‑déjà, lorsque vous souhaitez extraire uniquement les étiquettes visibles.

## **Contrôler les étiquettes de données au‑delà du maximum de l’axe**

Lorsque vous limitez manuellement la plage d’un axe, certains points de données peuvent dépasser son maximum. Utilisez [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setShowDataLabelsOverMaximum-boolean-) pour contrôler l’affichage de leurs étiquettes de données. Ce réglage modifie la visibilité des étiquettes ; il ne modifie pas la plage de l’axe ni les valeurs sous‑jacentes.

L’exemple ci‑dessous crée un histogramme à colonnes groupées 2D avec des valeurs de 60 et 120. Il transmet `false` à [setAutomaticMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticMaxValue-boolean-) et fixe le maximum à 100 avec [setMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMaxValue-double-) sur l’axe vertical. La première diapositive autorise les étiquettes au‑delà du maximum ; une copie de cette diapositive les désactive. Les deux diapositives sont enregistrées sous `DataLabelsOverMaximum.pptx`.

Activez les étiquettes de valeurs avec [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-). le réglage au niveau du graphique n’active pas l’affichage des valeurs à lui seul et ne remplace pas la désactivation de l’affichage d’une valeur sur une étiquette individuelle. Cet exemple active les valeurs pour l’ensemble de la série et utilise [setPosition](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setPosition-int-) pour placer les étiquettes à l’extrémité extérieure de chaque colonne.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    IChartDataCell firstCategory = workbook.getCell(0, 1, 0, "Within range");
    IChartDataCell secondCategory = workbook.getCell(0, 2, 0, "Above maximum");

    chart.getChartData().getCategories().add(firstCategory);
    chart.getChartData().getCategories().add(secondCategory);

    IChartDataCell seriesName = workbook.getCell(0, 0, 1, "Values");
    IChartSeries series = chart.getChartData().getSeries().add(seriesName, chart.getType());

    IChartDataCell firstValue = workbook.getCell(0, 1, 1, 60);
    IChartDataCell secondValue = workbook.getCell(0, 2, 1, 120);

    series.getDataPoints().addDataPointForBarSeries(firstValue);
    series.getDataPoints().addDataPointForBarSeries(secondValue);

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd);

    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(100);
    chart.setShowDataLabelsOverMaximum(true);

    ISlide secondSlide = presentation.getSlides().addClone(slide);
    IChart secondChart = (IChart) secondSlide.getShapes().get_Item(0);
    secondChart.setShowDataLabelsOverMaximum(false);

    presentation.save("DataLabelsOverMaximum.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Les images suivantes montrent les diapositives enregistrées rendues par Microsoft PowerPoint. Avec `true`, l’étiquette **120** est visible à la limite supérieure ; avec `false`, elle est masquée. L’étiquette **60** reste visible, le maximum de l’axe reste à **100**, et le deuxième point de données reste **120** dans les deux cas.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![Graphique PowerPoint affichant l’étiquette de valeur 120 avec un maximum d’axe de 100](data-labels-over-maximum-true.png) | ![Graphique PowerPoint masquant l’étiquette de valeur 120 avec un maximum d’axe de 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Cet exemple utilise un histogramme à colonnes 2D avec un axe de valeurs. Les graphiques sans axe de valeurs, comme les graphiques circulaires et les graphiques en anneau, n’ont pas de maximum d’axe à limiter de cette manière.
{{% /alert %}}

## **Définir la distance de l’étiquette par rapport à un axe**

Utilisez [setLabelOffset](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setLabelOffset-int-) pour contrôler la distance entre les étiquettes de l’axe des catégories et l’axe. La valeur est un pourcentage de la taille maximale de police des étiquettes d’axe. Cet exemple crée un histogramme à colonnes groupées et fixe le décalage des étiquettes de l’axe horizontal à 500. Ce réglage affecte les étiquettes de l’axe des catégories plutôt que les étiquettes attachées aux points de données individuels.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    chart.getAxes().getHorizontalAxis().setLabelOffset(500);

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ajuster la position de l’étiquette**

Sur un graphique circulaire, ajustez les positions des étiquettes de données pour améliorer l’espacement et laisser de la place aux lignes de repère.

Cet exemple affiche la valeur du premier point de données, place son étiquette à l’extérieur de la tranche et ajuste ses décalages horizontaux et verticaux à l’aide de [setX](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setX-float-) et [setY](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setY-float-). Ces décalages sont relatifs à la largeur et à la hauteur du graphique, respectivement.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 200, 200);
    IChartSeriesCollection series = chart.getChartData().getSeries();

    IDataLabel label = series.get_Item(0).getLabels().get_Item(0);
    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd);
    label.setX(0.71f);
    label.setY(0.04f);

    presentation.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Graphique circulaire avec une position d’étiquette de données ajustée](pie-chart-adjusted-label.png)

## **Ajouter plusieurs lignes d’étiquettes de données au‑dessus d’un histogramme à colonnes**

Cet exemple crée un histogramme à colonnes avec deux rangées d’étiquettes de données au‑dessus de la zone de tracé. La série A affiche les colonnes visibles, tandis que les séries B et C fournissent les étiquettes supplémentaires. Leurs colonnes sont masquées en supprimant le remplissage et le contour. La méthode [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/chartseriesgroup/) aligne les trois séries sur les mêmes centres de catégorie.

Les paramètres du [ChartPlotArea](https://reference.aspose.com/slides/java/com.aspose.slides/chartplotarea/) réservent de l’espace pour les rangées d’étiquettes. Après que [Chart.validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/) ait calculé les positions par défaut, [DataLabel.setX and DataLabel.setY](https://reference.aspose.com/slides/java/com.aspose.slides/datalabel/) conservent l’alignement horizontal et appliquent des décalages verticaux afin de disposer les étiquettes en deux rangées. Les nombres restent des étiquettes de données liées aux valeurs des séries ; seuls les en‑têtes de rangée sont des formes de texte séparées.

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 40, 40, 640, 200);
    chart.setTitle(false);
    chart.setLegend(false);
    chart.getTextFormat().getPortionFormat().setFontHeight(12);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    String[] categories = {"North", "South", "East", "West"};
    String[] seriesNames = {"Series A", "Series B", "Series C"};
    double[][] seriesValues = {
            {35, 42, 28, 47},
            {22, 31, 19, 26},
            {12, 16, 14, 18}
    };

    for (int categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
        chart.getChartData().getCategories().add(
                workbook.getCell(0, categoryIndex + 1, 0, categories[categoryIndex]));
    }

    for (int seriesIndex = 0; seriesIndex < seriesNames.length; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().add(
                workbook.getCell(0, 0, seriesIndex + 1, seriesNames[seriesIndex]),
                ChartType.ClusteredColumn);

        for (int categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
            series.getDataPoints().addDataPointForBarSeries(workbook.getCell(
                    0, categoryIndex + 1, seriesIndex + 1,
                    seriesValues[seriesIndex][categoryIndex]));
        }

        if (seriesIndex > 0) {
            // Masquer les colonnes de B et C, mais conserver leurs étiquettes de données.
            series.getFormat().getFill().setFillType(FillType.NoFill);
            series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
            series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
            series.getLabels().getDefaultDataLabelFormat()
                    .getTextFormat().getPortionFormat().setFontHeight(12);
            IFillFormat labelFill = series.getLabels().getDefaultDataLabelFormat()
                    .getTextFormat().getPortionFormat().getFillFormat();
            labelFill.setFillType(FillType.Solid);
            labelFill.getSolidFillColor().setColor(java.awt.Color.BLACK);
            series.getLabels().getDefaultDataLabelFormat().setPosition(
                    LegendDataLabelPosition.InsideBase);
        }
    }

    // Aligner les trois séries sur les mêmes centres de catégorie.
    chart.getChartData().getSeries().get_Item(0)
            .getParentSeriesGroup().setOverlap((byte) 100);

    // Utiliser moins de lignes de grille pour cet exemple compact.
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setMajorUnit(10);

    // Réserver de l'espace au-dessus du tracé pour deux rangées d'étiquettes de données.
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner);
    chart.getPlotArea().setX(0.15f);
    chart.getPlotArea().setY(0.32f);
    chart.getPlotArea().setWidth(0.80f);
    chart.getPlotArea().setHeight(0.48f);
    chart.validateChartLayout();

    for (int seriesIndex = 1; seriesIndex < seriesNames.length; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(seriesIndex);
        float rowTop = seriesIndex == 1 ? 0.15f : 0.03f;

        for (int categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
            IDataLabel dataLabel = series.getDataPoints().get_Item(categoryIndex).getLabel();
            // Conserver la position horizontale par défaut. Y est un décalage depuis
            // la position d'étiquette par défaut, exprimé comme une fraction de la hauteur du graphique.
            dataLabel.setX(0);
            dataLabel.setY(rowTop - dataLabel.getActualY() / chart.getHeight());
        }

        // Seul l'en-tête de ligne est une forme de texte distincte.
        IAutoShape rowHeading = slide.getShapes().addAutoShape(
                ShapeType.Rectangle, chart.getX(),
                chart.getY() + rowTop * chart.getHeight(), 85, 18);
        rowHeading.getFillFormat().setFillType(FillType.NoFill);
        rowHeading.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        rowHeading.addTextFrame(seriesNames[seriesIndex]);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginTop(0);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginBottom(0);
        IPortionFormat headingFormat = rowHeading.getTextFrame().getParagraphs()
                .get_Item(0).getPortions().get_Item(0).getPortionFormat();
        headingFormat.setFontHeight(12);
        headingFormat.getFillFormat().setFillType(FillType.Solid);
        headingFormat.getFillFormat().getSolidFillColor().setColor(java.awt.Color.BLACK);
    }

    presentation.save("multiple-rows-of-labels.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Comment puis‑je éviter que les étiquettes de données se chevauchent sur des graphiques denses ?**  
Combinez le placement automatique des étiquettes, les lignes de repère et une taille de police réduite ; si nécessaire, masquez certains champs (par exemple, la catégorie) ou n’affichez les étiquettes que pour les valeurs extrêmes ou les points clés.

**Comment puis‑je désactiver les étiquettes uniquement pour les valeurs zéro, négatives ou vides ?**  
Filtrez les points de données avant d’activer les étiquettes et désactivez l’affichage pour les valeurs égales à 0, les valeurs négatives ou les valeurs manquantes selon une règle définie.

**Comment garantir un style d’étiquette cohérent lors de l’exportation en PDF/images ?**  
Définissez explicitement la famille et la taille de police et vérifiez que la police est disponible dans l’environnement de rendu afin d’éviter le recours à une police de secours.