---
title: Gérer les étiquettes de données de graphique dans les présentations en Java
linktitle: Étiquette de données
type: docs
url: /fr/java/chart-data-label/
keywords:
- graphique
- étiquette de données
- précision des données
- pourcentage
- distance d’étiquette
- position d’étiquette
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Apprenez à ajouter et formater les étiquettes de données de graphiques dans les présentations PowerPoint en utilisant Aspose.Slides pour Java afin de créer des diapositives plus attrayantes."
---
## **Introduction**

Les étiquettes de données affichent des informations sur les séries de graphiques et les points de données individuels, aidant les lecteurs à identifier les valeurs et à comprendre le graphique. Cet article explique comment formater les valeurs, afficher les pourcentages, lire le texte des étiquettes, contrôler les étiquettes au‑delà du maximum de l’axe, ajuster l’espacement des étiquettes de l’axe des catégories et positionner les étiquettes des graphiques circulaires.

## **Définir la précision des données dans les étiquettes de graphiques**

Utilisez [setNumberFormatOfValues](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ichartseries/#setNumberFormatOfValues-java.lang.String-) pour formater les valeurs des séries. Cet exemple crée un graphique en ligne avec des données par défaut, affiche son tableau de données et active les étiquettes de valeur pour la première série. Le format `#,##0.00` affiche un séparateur de milliers et deux décimales sans modifier les valeurs sous‑jacentes.

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

## **Afficher le pourcentage comme étiquettes**

Pour un graphique à colonnes empilées, calculez chaque valeur en pourcentage du total de sa catégorie et affectez le texte au cadre de texte renvoyé par [getTextFrameForOverriding](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--). Cet exemple utilise les données de graphique par défaut et affiche les pourcentages avec deux décimales dans une police de 8 points. Les catégories dont le total est zéro sont ignorées afin d’éviter une division par zéro. Recalculez le texte personnalisé de l’étiquette si les données du graphique changent.

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

Lorsque les valeurs sont stockées sous forme de fractions, utilisez [setNumberFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) pour afficher les pourcentages. Passez `false` à [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/fr/java/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) pour appliquer le format de l’étiquette indépendamment des cellules source.

Cet exemple crée un graphique à colonnes empilées à 100 % avec des séries rouge et bleue sur quatre catégories. Chaque paire de valeurs totalise 1. Le format d’étiquette `0.0%` affiche 0,30 comme 30,0 %, tandis que l’axe vertical utilise deux décimales. Les deux séries utilisent du texte d’étiquette blanc de 10 points.

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

Utilisez [getActualLabelText](https://reference.aspose.com/slides/fr/java/com.aspose.slides/idatalabel/#getActualLabelText--) pour récupérer le texte généré par les paramètres d’une étiquette de données. Ceci est utile lors de l’extraction d’étiquettes pour des rapports, la recherche de contenu dans une présentation ou la validation de graphiques générés. Dans l’exemple ci‑dessous, le [format d’étiquette de données](https://reference.aspose.com/slides/fr/java/com.aspose.slides/idatalabelformat/) par défaut combine le nom de chaque catégorie, le nom de la série et la valeur. Un point formate sa valeur en pourcentage, et un autre utilise du texte personnalisé provenant de [getTextFrameForOverriding](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--).

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

Le nombre stocké dans un point de données reste `0.75`, même si son étiquette affiche `75 %` avec les noms de catégorie et de série. Le texte personnalisé remplace le texte d’étiquette généré. [getActualLabelText](https://reference.aspose.com/slides/fr/java/com.aspose.slides/idatalabel/#getActualLabelText--) renvoie la chaîne d’étiquette résultante dans les deux cas. Vérifiez [isVisible](https://reference.aspose.com/slides/fr/java/com.aspose.slides/idatalabel/#isVisible--) séparément, comme indiqué ci‑dessus, lorsque vous ne souhaitez extraire que les étiquettes visibles.

## **Contrôler les étiquettes de données au‑delà du maximum de l’axe**

Lorsque vous limitez manuellement la plage d’un axe, certains points de données peuvent dépasser son maximum. Utilisez [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ichart/#setShowDataLabelsOverMaximum-boolean-) pour contrôler si leurs étiquettes de données sont affichées. Ce paramètre modifie la visibilité des étiquettes ; il ne modifie pas la plage de l’axe ni les valeurs sous‑jacentes.

L’exemple ci‑dessous crée un graphique à colonnes groupées 2D avec des valeurs de 60 et 120. Il passe `false` à [setAutomaticMaxValue](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iaxis/#setAutomaticMaxValue-boolean-) et fixe le maximum à 100 avec [setMaxValue](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iaxis/#setMaxValue-double-) sur l’axe vertical. La première diapositive autorise les étiquettes au‑delà du maximum ; une copie de cette diapositive les désactive. Les deux diapositives sont enregistrées dans `DataLabelsOverMaximum.pptx`.

Activez les étiquettes de valeur avec [setShowValue](https://reference.aspose.com/slides/fr/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-). Le paramètre au niveau du graphique n’active pas l’affichage des valeurs par lui‑même et ne remplace pas la désactivation d’une étiquette individuelle. Cet exemple active les valeurs pour l’ensemble de la série et utilise [setPosition](https://reference.aspose.com/slides/fr/java/com.aspose.slides/idatalabelformat/#setPosition-int-) pour placer les étiquettes à l’extrémité extérieure de chaque colonne.

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
Cet exemple utilise un graphique à colonnes 2D avec un axe de valeur. Les graphiques sans axe de valeur, comme les graphiques circulaires et les graphiques en anneau, n’ont pas de maximum d’axe à limiter de cette manière.
{{% /alert %}}

## **Définir la distance de l’étiquette par rapport à un axe**

Utilisez [setLabelOffset](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iaxis/#setLabelOffset-int-) pour contrôler la distance entre les étiquettes de l’axe des catégories et l’axe. La valeur est un pourcentage de la taille maximale de la police des étiquettes d’axe. Cet exemple crée un graphique à colonnes groupées et fixe le décalage des étiquettes de l’axe horizontal à 500. Ce paramètre affecte les étiquettes de l’axe des catégories plutôt que les étiquettes attachées à des points de données individuels.

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

Cet exemple affiche la valeur du premier point de données, place son étiquette à l’extérieur de la tranche et ajuste ses décalages horizontaux et verticaux à l’aide de [setX](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ilayoutable/#setX-float-) et [setY](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ilayoutable/#setY-float-). Ces décalages sont relatifs à la largeur et à la hauteur du graphique, respectivement.

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

## **FAQ**

**Comment puis‑je éviter que les étiquettes de données se chevauchent sur des graphiques denses ?**

Combinez le placement automatique des étiquettes, les lignes de repère et la réduction de la taille de la police ; si nécessaire, masquez certains champs (par exemple, la catégorie) ou n’affichez les étiquettes que pour les valeurs extrêmes ou les points clés.

**Comment désactiver les étiquettes uniquement pour les valeurs zéro, négatives ou vides ?**

Filtrez les points de données avant d’activer les étiquettes et désactivez l’affichage pour les valeurs égales à 0, les valeurs négatives ou les valeurs manquantes selon une règle définie.

**Comment garantir un style d’étiquette cohérent lors de l’exportation vers PDF/images ?**

Définissez explicitement la famille et la taille de la police et vérifiez que la police est disponible dans l’environnement de rendu afin d’éviter les substitutions.