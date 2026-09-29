---
title: Gérer les libellés de données des graphiques dans les présentations avec JavaScript
linktitle: Libellé de données
type: docs
url: /fr/nodejs-java/chart-data-label/
keywords:
- graphique
- libellé de données
- précision des données
- pourcentage
- distance du libellé
- emplacement du libellé
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Apprenez à ajouter et formater les libellés de données des graphiques dans les présentations PowerPoint en utilisant JavaScript et Aspose.Slides pour Node.js via Java pour des diapositives plus engageantes."
---
## **Introduction**

Les libellés de données affichent des informations sur les séries de graphiques et les points de données individuels, aidant les lecteurs à identifier les valeurs et à comprendre le graphique. Cet article explique comment formater les valeurs, afficher les pourcentages, lire le texte des libellés, contrôler les libellés au‑delà du maximum de l’axe, ajuster l’espacement des libellés de l’axe des catégories et positionner les libellés des graphiques circulaires.

## **Définir la précision des valeurs dans les libellés de données du graphique**

Utilisez [setNumberFormatOfValues](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chartseries/setnumberformatofvalues/) pour formater les valeurs des séries. Cet exemple crée un graphique en courbes avec des données par défaut, affiche son tableau de données et active les libellés de valeur pour la première série. Le format `#,##0.00` affiche un séparateur de milliers et deux décimales sans modifier les valeurs sous‑jacentes.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 50, 50, 450, 300);
    chart.setDataTable(true);

    const series = chart.getChartData().getSeries().get_Item(0);
    series.setNumberFormatOfValues("#,##0.00");
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("PrecisionOfDatalabels_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Afficher le pourcentage en tant que libellés**

Pour un graphique à colonnes empilées, calculez chaque valeur comme un pourcentage du total de sa catégorie et affectez le texte au cadre de texte renvoyé par [getTextFrameForOverriding](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/). Cet exemple utilise les données de graphique par défaut et affiche les pourcentages avec deux décimales dans une police de 8 points. Les catégories dont le total est zéro sont ignorées afin d’éviter une division par zéro. Recalculez le texte de libellé personnalisé si les données du graphique changent.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 20, 20, 400, 400);

    const categoryTotals = new Array(chart.getChartData().getCategories().size()).fill(0);
    for (let k = 0; k < chart.getChartData().getCategories().size(); k++) {
        for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
            const series = chart.getChartData().getSeries().get_Item(i);
            const pointValue = series.getDataPoints().get_Item(k).getValue().getData();
            categoryTotals[k] += Number(pointValue);
        }
    }

    for (let x = 0; x < chart.getChartData().getSeries().size(); x++) {
        const series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);

        for (let j = 0; j < series.getDataPoints().size(); j++) {
            const label = series.getDataPoints().get_Item(j).getLabel();
            if (categoryTotals[j] == 0) {
                continue;
            }

            const pointValue = series.getDataPoints().get_Item(j).getValue().getData();
            const dataPointPercent = (Number(pointValue) / categoryTotals[j]) * 100;

            const portion = new aspose.slides.Portion();
            portion.setText(dataPointPercent.toFixed(2) + " %");
            portion.getPortionFormat().setFontHeight(8);

            label.getTextFrameForOverriding().setText("");
            const paragraph = label.getTextFrameForOverriding().getParagraphs().get_Item(0);
            paragraph.getPortions().add(portion);

            label.getDataLabelFormat().setShowValue(true);
            label.getDataLabelFormat().setShowSeriesName(false);
            label.getDataLabelFormat().setShowPercentage(false);
            label.getDataLabelFormat().setShowLegendKey(false);
            label.getDataLabelFormat().setShowCategoryName(false);
            label.getDataLabelFormat().setShowBubbleSize(false);
        }
    }

    presentation.save("DisplayPercentageAsLabels_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Définir le signe de pourcentage avec les libellés de données du graphique**

Lorsque les valeurs sont stockées sous forme de fractions, utilisez [setNumberFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/datalabelformat/setnumberformat/) pour afficher les pourcentages. Passez `false` à [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) pour appliquer le format du libellé indépendamment des cellules sources.  
Cet exemple crée un graphique à colonnes empilées à 100 % avec des séries rouge et bleu sur quatre catégories. Chaque paire de valeurs totalise 1. Le format de libellé `0.0%` affiche 0.30 comme 30,0 %, tandis que l’axe vertical utilise deux décimales. Les deux séries utilisent un texte de libellé blanc de 10 points.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PercentsStackedColumn, 20, 20, 500, 400);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;
    for (let i = 0; i < 4; i++) {
        const categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    const seriesNames = ["Reds", "Blues"];
    const white = java.getStaticFieldValue("java.awt.Color", "WHITE");
    const seriesColors = [java.getStaticFieldValue("java.awt.Color", "RED"), java.getStaticFieldValue("java.awt.Color", "BLUE")];
    const values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]];

    for (let i = 0; i < seriesNames.length; i++) {
        const seriesCell = workbook.getCell(worksheetIndex, 0, i + 1, seriesNames[i]);
        const series = chart.getChartData().getSeries().add(seriesCell, chart.getType());
        for (let j = 0; j < 4; j++) {
            const valueCell = workbook.getCell(worksheetIndex, j + 1, i + 1, values[i][j]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
        series.getFormat().getFill().getSolidFillColor().setColor(seriesColors[i]);

        const labelFormat = series.getLabels().getDefaultDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(false);
        labelFormat.setNumberFormat("0.0%");
        labelFormat.getTextFormat().getPortionFormat().setFontHeight(10);
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(white);
    }

    presentation.save("SetDataLabelsPercentageSign_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lire le texte réel des libellés de données**

Utilisez [getActualLabelText](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/datalabel/getactuallabeltext/) pour récupérer le texte généré par les paramètres d’un libellé de données. Cela est utile lors de l’extraction de libellés pour des rapports, de la recherche de contenu de présentation ou de la validation de graphiques générés. Dans l’exemple ci‑dessous, le [format de libellé de données](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/datalabelformat/) par défaut combine le nom de chaque catégorie, le nom de la série et la valeur. Un point formate sa valeur en pourcentage, et un autre utilise du texte personnalisé provenant de [getTextFrameForOverriding](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const firstCategoryCell = workbook.getCell(0, 1, 0, "Q1");
    chart.getChartData().getCategories().add(firstCategoryCell);
    const secondCategoryCell = workbook.getCell(0, 2, 0, "Q2");
    chart.getChartData().getCategories().add(secondCategoryCell);

    const northSeriesCell = workbook.getCell(0, 0, 1, "North");
    const north = chart.getChartData().getSeries().add(northSeriesCell, chart.getType());
    const northFirstValueCell = workbook.getCell(0, 1, 1, 0.25);
    north.getDataPoints().addDataPointForBarSeries(northFirstValueCell);
    const northSecondValueCell = workbook.getCell(0, 2, 1, 0.75);
    north.getDataPoints().addDataPointForBarSeries(northSecondValueCell);

    const southSeriesCell = workbook.getCell(0, 0, 2, "South");
    const south = chart.getChartData().getSeries().add(southSeriesCell, chart.getType());
    const southFirstValueCell = workbook.getCell(0, 1, 2, 0.40);
    south.getDataPoints().addDataPointForBarSeries(southFirstValueCell);
    const southSecondValueCell = workbook.getCell(0, 2, 2, 0.60);
    south.getDataPoints().addDataPointForBarSeries(southSecondValueCell);

    for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
        const series = chart.getChartData().getSeries().get_Item(i);
        const format = series.getLabels().getDefaultDataLabelFormat();
        format.setShowCategoryName(true);
        format.setShowSeriesName(true);
        format.setShowValue(true);
    }

    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormatLinkedToSource(false);
    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormat("0%");
    south.getLabels().get_Item(0).getTextFrameForOverriding().setText("Reviewed");

    for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
        const series = chart.getChartData().getSeries().get_Item(i);
        for (let j = 0; j < series.getDataPoints().size(); j++) {
            const point = series.getDataPoints().get_Item(j);
            const label = point.getLabel();
            if (!label.isVisible()) {
                continue;
            }

            console.log("Value: " + point.getValue().getData() + "; label: " + label.getActualLabelText());
        }
    }
} finally {
    presentation.dispose();
}
```

Le nombre stocké dans un point de données reste `0.75`, même lorsque son libellé affiche `75 %` avec les noms de catégorie et de série. Le texte personnalisé remplace le texte de libellé généré. [getActualLabelText](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/datalabel/getactuallabeltext/) renvoie la chaîne de libellé résultante dans les deux cas. Vérifiez [isVisible](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/datalabel/isvisible/) séparément, comme illustré ci‑dessus, lorsque vous ne souhaitez extraire que les libellés visibles.

## **Contrôler les libellés de données au‑delà du maximum de l’axe**

Lorsque vous limitez manuellement la plage d’un axe, certains points de données peuvent dépasser son maximum. Utilisez [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chart/setshowdatalabelsovermaximum/) pour contrôler si leurs libellés de données sont affichés. Ce paramètre modifie la visibilité des libellés ; il ne modifie pas la plage de l’axe ni les valeurs sous‑jacentes.  
L’exemple ci‑dessous crée un graphique à colonnes groupées 2D avec des valeurs de 60 et 120. Il transmet `false` à [setAutomaticMaxValue](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/axis/setautomaticmaxvalue/) et fixe le maximum à 100 avec [setMaxValue](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/axis/setmaxvalue/) sur l’axe vertical. La première diapositive autorise les libellés au‑delà du maximum ; une copie de cette diapositive les désactive. Les deux diapositives sont enregistrées dans `DataLabelsOverMaximum.pptx`.  
Activez les libellés de valeur avec [setShowValue](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/datalabelformat/setshowvalue/). Le paramètre au niveau du graphique n’active pas l’affichage des valeurs par lui‑même et ne remplace pas la désactivation de l’affichage de la valeur d’un libellé individuel. Cet exemple active les valeurs pour l’ensemble de la série et utilise [setPosition](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/datalabelformat/setposition/) pour placer les libellés à l’extrémité extérieure de chaque colonne.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();

    const firstCategory = workbook.getCell(0, 1, 0, "Within range");
    const secondCategory = workbook.getCell(0, 2, 0, "Above maximum");

    chart.getChartData().getCategories().add(firstCategory);
    chart.getChartData().getCategories().add(secondCategory);

    const seriesName = workbook.getCell(0, 0, 1, "Values");
    const series = chart.getChartData().getSeries().add(seriesName, chart.getType());

    const firstValue = workbook.getCell(0, 1, 1, 60);
    const secondValue = workbook.getCell(0, 2, 1, 120);

    series.getDataPoints().addDataPointForBarSeries(firstValue);
    series.getDataPoints().addDataPointForBarSeries(secondValue);

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.OutsideEnd);

    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(100);
    chart.setShowDataLabelsOverMaximum(true);

    const secondSlide = presentation.getSlides().addClone(slide);
    const secondChart = secondSlide.getShapes().get_Item(0);
    secondChart.setShowDataLabelsOverMaximum(false);

    presentation.save("DataLabelsOverMaximum.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Les images suivantes montrent les diapositives enregistrées rendues par Microsoft PowerPoint. Avec `true`, le libellé **120** est visible à la limite supérieure ; avec `false`, il est masqué. Le libellé **60** reste visible, le maximum de l’axe reste à **100**, et le deuxième point de données reste **120** dans les deux cas.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![Graphique PowerPoint affichant le libellé de valeur 120 avec un maximum d’axe de 100](data-labels-over-maximum-true.png) | ![Graphique PowerPoint masquant le libellé de valeur 120 avec un maximum d’axe de 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Cet exemple utilise un graphique à colonnes 2D avec un axe des valeurs. Les graphiques sans axe des valeurs, tels que les graphiques circulaires et les graphiques en anneau, n’ont pas de maximum d’axe à limiter de cette manière.
{{% /alert %}}

## **Définir la distance du libellé par rapport à un axe**

Utilisez [setLabelOffset](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/axis/setlabeloffset/) pour contrôler la distance entre les libellés de l’axe des catégories et l’axe. La valeur est un pourcentage de la taille maximale de police des libellés de l’axe. Cet exemple crée un graphique à colonnes groupées et définit le décalage des libellés de l’axe horizontal à 500. Ce paramètre affecte les libellés de l’axe des catégories plutôt que les libellés attachés aux points de données individuels.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);
    chart.getAxes().getHorizontalAxis().setLabelOffset(500);

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ajuster la position du libellé**

Sur un graphique circulaire, ajustez la position des libellés de données pour améliorer l’espacement et laisser de la place aux lignes de connexion.  
Cet exemple affiche la valeur du premier point de données, place son libellé à l’extérieur de la tranche et ajuste ses décalages horizontal et vertical à l’aide de [setX](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/datalabel/setx/) et [setY](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/datalabel/sety/). Ces décalages sont relatifs à la largeur et à la hauteur du graphique, respectivement.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 200, 200);
    const series = chart.getChartData().getSeries();

    const label = series.get_Item(0).getLabels().get_Item(0);
    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.OutsideEnd);
    label.setX(java.newFloat(0.71));
    label.setY(java.newFloat(0.04));

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Graphique circulaire avec une position de libellé de données ajustée](pie-chart-adjusted-label.png)

## **FAQ**

**Comment puis‑je empêcher les libellés de données de se chevaucher sur des graphiques denses ?**  
Combinez le placement automatique des libellés, les lignes de connexion et une taille de police réduite ; si nécessaire, masquez certains champs (par exemple, la catégorie) ou n’affichez les libellés que pour les valeurs extrêmes ou les points clés.

**Comment désactiver les libellés uniquement pour les valeurs nulles, négatives ou vides ?**  
Filtrez les points de données avant d’activer les libellés et désactivez l’affichage pour les valeurs égales à 0, les valeurs négatives ou les valeurs manquantes selon une règle définie.

**Comment garantir un style de libellé cohérent lors de l’exportation en PDF/images ?**  
Spécifiez explicitement la famille et la taille de police et vérifiez que la police est disponible dans l’environnement de rendu afin d’éviter le recours à une police de secours.