---
title: Créer ou mettre à jour des graphiques PowerPoint en JavaScript
linktitle: Créer ou mettre à jour des graphiques
type: docs
weight: 10
url: /fr/nodejs-java/create-chart/
keywords:
- ajouter un graphique
- créer un graphique
- modifier un graphique
- changer un graphique
- mettre à jour un graphique
- graphique de dispersion
- graphique circulaire
- graphique en courbes
- graphique en treemap
- graphique boursier
- graphique boîte et moustaches
- graphique en entonnoir
- graphique à rayons
- histogramme
- graphique radar
- graphique multi‑catégories
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Créer et personnaliser des graphiques dans les présentations PowerPoint à l’aide d’Aspose.Slides pour Node.js via Java. Ajouter, formater et modifier des graphiques avec des exemples de code pratiques en JavaScript."
---
## **Vue d'ensemble**

Cet article fournit un guide complet sur la façon de créer et de personnaliser des graphiques à l'aide d'Aspose.Slides pour Node.js via Java. Vous apprendrez comment ajouter programmatiquement un graphique à une diapositive, le remplir de données et appliquer diverses options de mise en forme pour répondre à vos exigences de conception spécifiques. Tout au long de l'article, des exemples de code détaillés illustrent chaque étape, depuis l'initialisation de la présentation et de l'objet graphique jusqu'à la configuration des séries, des axes et des légendes. En suivant ce guide, vous acquerrez une solide compréhension de l'intégration de la génération dynamique de graphiques dans vos applications Node.js, simplifiant le processus de création de présentations basées sur des données.

## **Créer un graphique**

Les graphiques aident les gens à visualiser rapidement les données et à obtenir des insights qui ne sont pas immédiatement évidents à partir d'un tableau ou d'une feuille de calcul.

**Pourquoi créer des graphiques ?**

En utilisant des graphiques, vous pouvez :

* agréger, condenser ou résumer de grandes quantités de données sur une seule diapositive d’une présentation ;
* révéler des motifs et des tendances dans les données ;
* déduire la direction et l’élan des données au fil du temps ou par rapport à une unité de mesure spécifique ;
* repérer des valeurs aberrantes, des anomalies, des écarts, des erreurs et des données non sensées ;
* communiquer ou présenter des données complexes.

Dans PowerPoint, vous pouvez créer des graphiques via la fonction *Insert*, qui propose des modèles pour concevoir de nombreux types de graphiques. Avec Aspose.Slides, vous pouvez créer à la fois des graphiques classiques (basés sur des types de graphiques populaires) et des graphiques personnalisés.

{{% alert color="info" title="Remarque" %}}

Utilisez l'énumération [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) du module [aspose.slides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/). Les valeurs de cette énumération correspondent à différents types de graphiques.

{{% /alert %}}

### **Créer des graphiques à colonnes groupées**

Cet exemple utilise [addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) pour créer un graphique à colonnes groupées qui compare deux séries sur trois catégories. Les séries utilisent des remplissages rouge et vert, et les libellés individuels affichent les noms de catégorie, les noms de série et les valeurs. L’indice de feuille de calcul 0 fait référence à la première feuille du classeur intégré au graphique.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);

    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    let workbook = chart.getChartData().getChartDataWorkbook();
    let worksheetIndex = 0;

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    chart.getChartData().getSeries().add(seriesNameCell, chart.getType());
    seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
    chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    let categoryCell = workbook.getCell(worksheetIndex, 1, 0, "Category 1");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(worksheetIndex, 2, 0, "Category 2");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(worksheetIndex, 3, 0, "Category 3");
    chart.getChartData().getCategories().add(categoryCell);

    let series = chart.getChartData().getSeries().get_Item(0);

    let valueCell = workbook.getCell(worksheetIndex, 1, 1, 20);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 2, 1, 50);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 3, 1, 30);
    series.getDataPoints().addDataPointForBarSeries(valueCell);

    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    series = chart.getChartData().getSeries().get_Item(1);

    valueCell = workbook.getCell(worksheetIndex, 1, 2, 30);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 2, 2, 10);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 3, 2, 60);
    series.getDataPoints().addDataPointForBarSeries(valueCell);

    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 128, 0));

    let label = series.getDataPoints().get_Item(0).getLabel();
    label.getDataLabelFormat().setShowCategoryName(true);

    label = series.getDataPoints().get_Item(1).getLabel();
    label.getDataLabelFormat().setShowSeriesName(true);

    label = series.getDataPoints().get_Item(2).getLabel();
    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setShowSeriesName(true);
    label.getDataLabelFormat().setSeparator("/");

    presentation.save("AsposeChart.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Le résultat :

![The Clustered Column chart](clustered_column_chart.png)

### **Créer des graphiques de dispersion**

Les graphiques de dispersion (également appelés nuages de points ou graphiques x‑y) sont souvent utilisés pour vérifier des motifs ou démontrer des corrélations entre deux variables.

Utilisez un graphique de dispersion lorsque :

* Vous avez des données numériques appariées.
* Vous avez deux variables qui se combinent bien.
* Vous voulez déterminer si les deux variables sont liées.
* Vous avez une variable indépendante qui possède plusieurs valeurs pour une variable dépendante.

Cet exemple trace deux ensembles de valeurs x‑y. La première série utilise des lignes droites avec des marqueurs en forme d’étoile, tandis que la seconde utilise des lignes lisses avec des marqueurs circulaires ; les deux utilisent une taille de marqueur de 10, configurée avec [setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/marker/setsize/). La méthode [setSymbol](https://reference.aspose.com/slides/nodejs-java/aspose.slides/marker/setsymbol/) contrôle la forme du marqueur.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithSmoothLines, 20, 20, 500, 300);

    let workbook = chart.getChartData().getChartDataWorkbook();
    let worksheetIndex = 0;

    chart.getChartData().getSeries().clear();

    let seriesNameCell = workbook.getCell(worksheetIndex, 1, 1, "Series 1");
    chart.getChartData().getSeries().add(seriesNameCell, chart.getType());
    seriesNameCell = workbook.getCell(worksheetIndex, 1, 3, "Series 2");
    chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    let series = chart.getChartData().getSeries().get_Item(0);

    let xValueCell = workbook.getCell(worksheetIndex, 2, 1, 1);
    let yValueCell = workbook.getCell(worksheetIndex, 2, 2, 3);
    series.getDataPoints().addDataPointForScatterSeries(xValueCell, yValueCell);

    xValueCell = workbook.getCell(worksheetIndex, 3, 1, 2);
    yValueCell = workbook.getCell(worksheetIndex, 3, 2, 10);
    series.getDataPoints().addDataPointForScatterSeries(xValueCell, yValueCell);

    series.setType(aspose.slides.ChartType.ScatterWithStraightLinesAndMarkers);

    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Star);

    series = chart.getChartData().getSeries().get_Item(1);

    xValueCell = workbook.getCell(worksheetIndex, 2, 3, 5);
    yValueCell = workbook.getCell(worksheetIndex, 2, 4, 2);
    series.getDataPoints().addDataPointForScatterSeries(xValueCell, yValueCell);

    xValueCell = workbook.getCell(worksheetIndex, 3, 3, 3);
    yValueCell = workbook.getCell(worksheetIndex, 3, 4, 1);
    series.getDataPoints().addDataPointForScatterSeries(xValueCell, yValueCell);

    xValueCell = workbook.getCell(worksheetIndex, 4, 3, 2);
    yValueCell = workbook.getCell(worksheetIndex, 4, 4, 2);
    series.getDataPoints().addDataPointForScatterSeries(xValueCell, yValueCell);

    xValueCell = workbook.getCell(worksheetIndex, 5, 3, 5);
    yValueCell = workbook.getCell(worksheetIndex, 5, 4, 1);
    series.getDataPoints().addDataPointForScatterSeries(xValueCell, yValueCell);

    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);

    presentation.save("AsposeChart.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Le résultat :

![The Scatter chart](scatter_chart.png)

### **Créer des graphiques circulaires**

Les graphiques circulaires sont les mieux adaptés pour montrer la relation partie‑à‑tout dans les données, en particulier lorsque les données contiennent des libellés catégoriels avec des valeurs numériques. Cependant, si vos données comportent de nombreuses parties ou libellés, vous pourriez envisager d’utiliser un graphique à barres à la place.

Cet exemple crée un graphique circulaire avec trois valeurs trimestrielles. Chaque tranche possède un remplissage et une bordure personnalisés, et les libellés affichent différentes combinaisons de valeurs, de pourcentages et d’informations de série. La méthode [setFirstSliceAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setfirstsliceangle/) définit la première tranche à 180 degrés.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 20, 20, 500, 300);

    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    let workbook = chart.getChartData().getChartDataWorkbook();
    let worksheetIndex = 0;

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    let categoryCell = workbook.getCell(0, 1, 0, "1st Qtr");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, 2, 0, "2nd Qtr");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, 3, 0, "3rd Qtr");
    chart.getChartData().getCategories().add(categoryCell);

    let seriesNameCell = workbook.getCell(0, 0, 1, "Series 1");
    let series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    let valueCell = workbook.getCell(worksheetIndex, 1, 1, 20);
    series.getDataPoints().addDataPointForPieSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 2, 1, 50);
    series.getDataPoints().addDataPointForPieSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 3, 1, 30);
    series.getDataPoints().addDataPointForPieSeries(valueCell);

    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);

    let firstSlice = series.getDataPoints().get_Item(0);
    firstSlice.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstSlice.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));

    firstSlice.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstSlice.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    firstSlice.getFormat().getLine().setWidth(3.0);
    firstSlice.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.ThinThick));
    firstSlice.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.LargeDash));

    let secondSlice = series.getDataPoints().get_Item(1);
    secondSlice.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondSlice.getFormat().getFill().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 165, 42, 42));

    secondSlice.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondSlice.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    secondSlice.getFormat().getLine().setWidth(3.0);
    secondSlice.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.Single));
    secondSlice.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.LargeDashDot));

    let thirdSlice = series.getDataPoints().get_Item(2);
    thirdSlice.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdSlice.getFormat().getFill().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 127, 80));

    thirdSlice.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdSlice.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    thirdSlice.getFormat().getLine().setWidth(2.0);
    thirdSlice.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.ThinThin));
    thirdSlice.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.LargeDashDotDot));

    let firstLabel = series.getDataPoints().get_Item(0).getLabel();
    firstLabel.getDataLabelFormat().setShowValue(true);

    let secondLabel = series.getDataPoints().get_Item(1).getLabel();
    secondLabel.getDataLabelFormat().setShowValue(true);
    secondLabel.getDataLabelFormat().setShowLegendKey(true);
    secondLabel.getDataLabelFormat().setShowPercentage(true);

    let thirdLabel = series.getDataPoints().get_Item(2).getLabel();
    thirdLabel.getDataLabelFormat().setShowSeriesName(true);
    thirdLabel.getDataLabelFormat().setShowPercentage(true);

    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);

    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);

    presentation.save("PieChart.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Le résultat :

![The Pie chart](pie_chart.png)

Pour améliorer la lisibilité des libellés situés à l’extérieur du cercle, consultez [Format Leader Lines](/slides/fr/nodejs-java/chart-data-label/#format-leader-lines) pour un exemple montrant comment positionner les libellés et personnaliser la couleur, la largeur, la transparence et le style de tiret des lignes.

### **Créer des graphiques en courbes**

Les graphiques en courbes (également appelés graphiques linéaires) sont les mieux adaptés aux situations où vous souhaitez démontrer des changements de valeur au fil du temps. En utilisant un graphique en courbes, vous pouvez comparer un grand nombre de données d’un coup, suivre les changements et les tendances dans le temps, mettre en évidence des anomalies dans les séries de données, etc.

Cet exemple utilise [addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) pour créer un graphique en courbes avec les séries et catégories par défaut, puis enregistre la présentation au format PPTX.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let lineChart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 20, 20, 500, 300);

    presentation.save("lineChart.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Par défaut, les points d’un graphique en courbes sont reliés par des lignes droites continues. Si vous souhaitez que les points soient reliés par des tirets, appelez [setDashStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/setdashstyle/) avec une valeur tirée de [LineDashStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linedashstyle/) :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let lineChart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 20, 20, 500, 300);

    for (let i = 0; i < lineChart.getChartData().getSeries().size(); i++)
    {
        let series = lineChart.getChartData().getSeries().get_Item(i);
        series.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));
    }
}
finally
{
    presentation.dispose();
}
```

Le résultat :

![The Line chart](line_chart.png)

### **Créer des graphiques en arbre (Tree Map)**

Les graphiques en arbre sont les mieux adaptés aux données de ventes lorsque vous souhaitez montrer la taille relative des catégories de données et attirer rapidement l’attention sur les éléments qui contribuent le plus à chaque catégorie.

Cet exemple crée un arbre avec huit feuilles regroupées en quatre troncs et deux branches. La méthode [setGroupingItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategorylevelsmanager/setgroupingitem/) affecte les troncs au niveau de groupement 1 et les branches au niveau 2. Les valeurs déterminent la taille relative des rectangles, tandis que les libellés de catégorie et les libellés parentaux qui se chevauchent identifient la hiérarchie.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.Treemap, 20, 20, 500, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    let workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    // Branche 1
    let categoryCell = workbook.getCell(0, "C1", "Leaf1");
    let leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    categoryCell = workbook.getCell(0, "C2", "Leaf2");
    chart.getChartData().getCategories().add(categoryCell);

    categoryCell = workbook.getCell(0, "C3", "Leaf3");
    leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    categoryCell = workbook.getCell(0, "C4", "Leaf4");
    chart.getChartData().getCategories().add(categoryCell);

    // Branche 2
    categoryCell = workbook.getCell(0, "C5", "Leaf5");
    leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");

    categoryCell = workbook.getCell(0, "C6", "Leaf6");
    chart.getChartData().getCategories().add(categoryCell);

    categoryCell = workbook.getCell(0, "C7", "Leaf7");
    leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");

    categoryCell = workbook.getCell(0, "C8", "Leaf8");
    chart.getChartData().getCategories().add(categoryCell);

    let series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Treemap);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    let valueCell = workbook.getCell(0, "D1", 4);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);
    valueCell = workbook.getCell(0, "D2", 5);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);
    valueCell = workbook.getCell(0, "D3", 3);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);
    valueCell = workbook.getCell(0, "D4", 6);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);
    valueCell = workbook.getCell(0, "D5", 9);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);
    valueCell = workbook.getCell(0, "D6", 9);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);
    valueCell = workbook.getCell(0, "D7", 4);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);
    valueCell = workbook.getCell(0, "D8", 3);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);

    series.setParentLabelLayout(aspose.slides.ParentLabelLayoutType.Overlapping);

    presentation.save("Treemap.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Le résultat :

![The Treemap chart](treemap_chart.png)

### **Créer des graphiques en cascade (Waterfall)**

Un graphique en cascade montre comment les variations positives et négatives contribuent à une valeur finale. Par exemple, une ventilation du bénéfice peut commencer par le revenu, soustraire les coûts et ajouter d’autres revenus. Les colonnes de variation flottent entre les valeurs précédentes et nouvelles, tandis que les colonnes totales s’étendent de zéro à la valeur accumulée.

L’exemple suivant utilise des montants exprimés en milliers de dollars américains :

| Catégorie | Valeur du classeur | Type de colonne |
| --- | ---: | --- |
| Revenu | 1000 | Augmentation |
| Coût des ventes | -400 | Diminution |
| Bénéfice brut | 600 | Total intermédiaire |
| Charges d’exploitation | -200 | Diminution |
| Autres revenus | 50 | Augmentation |
| Bénéfice net | 450 | Total final |

Pour marquer un point comme total intermédiaire ou final, appelez sa méthode [setSetAsTotal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/setsetastotal/) avec `true`. Fournissez le montant réellement accumulé dans la cellule du classeur correspondante : `600` pour le bénéfice brut (`1000 - 400`) et `450` pour le bénéfice net (`600 - 200 + 50`). La méthode marque la colonne comme total ; elle ne calcule ni ne remplit la valeur de la cellule. N’utilisez pas zéro comme espace réservé ni une autre variation pour un point total. Une colonne totale affiche la valeur accumulée sans l’ajouter de nouveau à la valeur courante.

Cet exemple complet JavaScript crée un graphique en utilisant le membre `Waterfall` de [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/), efface les données par défaut et remplit le classeur intégré. L’indice de feuille `0` sélectionne la première feuille ; la colonne A contient les noms de catégorie et la colonne B les valeurs. Chaque cellule de valeur est ajoutée avec [addDataPointForWaterfallSeries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/adddatapointforwaterfallseries/). Les indices de points basés sur zéro `2` et `5` identifient respectivement le total intermédiaire et le total final. Appeler [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setshowvalue/) avec `true` affiche les montants sur les colonnes. Aucune présentation ou classeur d’entrée n’est requis.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.Waterfall, 20, 20, 680, 200);

    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Profit breakdown (USD thousands)");
    chart.getChartTitle().setOverlay(false);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    let workbook = chart.getChartData().getChartDataWorkbook();
    let worksheetIndex = 0;

    workbook.clear(worksheetIndex);

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Profit");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.Waterfall);
    let categories = [ "Revenue", "Cost of sales", "Gross profit", "Operating expenses", "Other income", "Net profit" ];
    let values = [ 1000, -400, 600, -200, 50, 450 ];

    for (let i = 0; i < categories.length; i++)
    {
        let categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, categories[i]);
        chart.getChartData().getCategories().add(categoryCell);
        let valueCell = workbook.getCell(worksheetIndex, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForWaterfallSeries(valueCell);
    }

    // Les troisième et sixième points représentent des totaux, pas des changements supplémentaires.
    series.getDataPoints().get_Item(2).setSetAsTotal(true);
    series.getDataPoints().get_Item(5).setSetAsTotal(true);
    series.setShowConnectorLines(true);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("WaterfallChart.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Appelez la méthode au niveau de la série [setShowConnectorLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setshowconnectorlines/) avec `true` pour afficher les lignes liant les colonnes consécutives et faciliter le suivi de la valeur courante. Pour masquer ces lignes, remplacez l’appel de méthode dans l’exemple par `series.setShowConnectorLines(false);` avant l’enregistrement. Cela ne modifie que la visibilité des lignes, pas les données ou les totaux.

La présentation enregistrée montre un bénéfice brut de 600 et un bénéfice net de 450, les deux totaux étant partants de zéro :

![Waterfall chart showing revenue, costs, gross profit of 600, and net profit of 450, with value labels and connector lines](waterfall_chart.png)

### **Créer des graphiques boursiers (Stock)**

Les graphiques boursiers sont utilisés pour afficher des données financières telles que les prix d’ouverture, haut, bas et clôture, aidant à analyser les tendances du marché et la volatilité. Ils offrent des informations essentielles sur la performance des actions, aidant investisseurs et analystes à prendre des décisions éclairées.

Cet exemple crée un graphique type OHLC (ouverture‑haut‑bas‑clôture) avec quatre séries dans cet ordre et trois catégories. La méthode [setUpDownBars](https://reference.aspose.com/slides/nodejs-java/aspose.slides/updownbarsmanager/setupdownbars/) active les barres montantes/descendantes, et [getHiLowLinesFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/gethilowlinesformat/) contrôle les lignes haut‑bas qui affichent les fourchettes de prix, tandis que les lignes de série individuelles et les lignes de grille horizontales mineures sont masquées.

Le gestionnaire retourné par [getUpDownBars](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/getupdownbars/) expose des objets de formatage distincts via [getUpBarsFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/updownbarsmanager/getupbarsformat/) et [getDownBarsFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/updownbarsmanager/getdownbarsformat/). Utilisez les méthodes [getFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/format/getfill/) et [getLine](https://reference.aspose.com/slides/nodejs-java/aspose.slides/format/getline/) de chaque objet pour définir indépendamment le remplissage et le contour. Cet exemple utilise des barres vertes avec des contours vert foncé pour les intervalles à la hausse et des barres orange‑rouge avec des contours rouge foncé pour les intervalles à la baisse.

Fournissez des valeurs numériques pour les quatre séries à chaque catégorie, le haut et le bas encadrant ouverture et clôture. Les barres comparent la clôture à l’ouverture **dans la même catégorie**, pas avec la catégorie précédente : A passe de 72 à 25, tandis que B passe de 25 à 38 et C de 38 à 50. Des valeurs d’ouverture et de clôture égales ne produisent aucun intervalle visible. Les barres montantes/descendantes couvrent Ouverture–Clôture ; les lignes haut‑bas couvrent Bas‑Haut. Ces barres appartiennent au groupe de séries et ne sont pas des séries de type graphique à barres ordinaire.

Ce formatage fonctionne également avec les graphiques [Line and LineWithMarkers](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) contenant au moins deux séries dans le même groupe et des valeurs numériques correspondantes pour chaque catégorie. Pour ces graphiques linéaires non empilés, les barres montantes/descendantes comparent la première et la dernière série : une dernière valeur plus élevée génère une barre ascendante, une valeur plus basse génère une barre descendante. Inverser ces séries inverse la classification. L’exemple ci‑dessous utilise [OpenHighLowClose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) ; ne supposez pas que d’autres variantes boursières, empilées ou 3D utilisent la même disposition des données ou la même interprétation d’intervalle.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.OpenHighLowClose, 20, 20, 500, 150, false);

    let workbook = chart.getChartData().getChartDataWorkbook();

    let categoryCell = workbook.getCell(0, 1, 0, "A");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, 2, 0, "B");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, 3, 0, "C");
    chart.getChartData().getCategories().add(categoryCell);

    let seriesNameCell = workbook.getCell(0, 0, 1, "Open");
    chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.OpenHighLowClose);
    seriesNameCell = workbook.getCell(0, 0, 2, "High");
    chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.OpenHighLowClose);
    seriesNameCell = workbook.getCell(0, 0, 3, "Low");
    chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.OpenHighLowClose);
    seriesNameCell = workbook.getCell(0, 0, 4, "Close");
    chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.OpenHighLowClose);

    let series = chart.getChartData().getSeries().get_Item(0);
    let valueCell = workbook.getCell(0, 1, 1, 72);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 2, 1, 25);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 3, 1, 38);
    series.getDataPoints().addDataPointForStockSeries(valueCell);

    series = chart.getChartData().getSeries().get_Item(1);
    valueCell = workbook.getCell(0, 1, 2, 172);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 2, 2, 57);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 3, 2, 57);
    series.getDataPoints().addDataPointForStockSeries(valueCell);

    series = chart.getChartData().getSeries().get_Item(2);
    valueCell = workbook.getCell(0, 1, 3, 12);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 2, 3, 12);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 3, 3, 13);
    series.getDataPoints().addDataPointForStockSeries(valueCell);

    series = chart.getChartData().getSeries().get_Item(3);
    valueCell = workbook.getCell(0, 1, 4, 25);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 2, 4, 38);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 3, 4, 50);
    series.getDataPoints().addDataPointForStockSeries(valueCell);

    let upDownBars = chart.getChartData().getSeriesGroups().get_Item(0).getUpDownBars();
    upDownBars.setUpDownBars(true);

    upDownBars.getUpBarsFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    upDownBars.getUpBarsFormat().getFill().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 50, 205, 50));
    upDownBars.getUpBarsFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    upDownBars.getUpBarsFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 100, 0));
    upDownBars.getUpBarsFormat().getLine().setWidth(2);

    upDownBars.getDownBarsFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    upDownBars.getDownBarsFormat().getFill().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 69, 0));
    upDownBars.getDownBarsFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    upDownBars.getDownBarsFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 139, 0, 0));
    upDownBars.getDownBarsFormat().getLine().setWidth(2);
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));

    for (let i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        let stockSeries = chart.getChartData().getSeries().get_Item(i);
        stockSeries.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    }

    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    presentation.save("Stock-chart.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Le résultat, exporté depuis PowerPoint :

![Stock chart with an orange-red falling interval for A and green rising intervals for B and C](stock_chart.png)

### **Créer des graphiques boîte et moustaches (Box and Whisker)**

Les graphiques boîte et moustaches sont utilisés pour afficher la distribution des données en résumant des mesures statistiques clés, telles que la médiane, les quartiles et les éventuelles valeurs aberrantes. Ils sont particulièrement utiles en analyse exploratoire et en études statistiques pour comprendre rapidement la variabilité des données et identifier d’éventuelles anomalies.

Cet exemple crée un graphique boîte et moustaches à partir de six valeurs. La méthode [setQuartileMethod](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setquartilemethod/) sélectionne le calcul exclusif des quartiles. L’exemple active également les lignes de moyenne, les marqueurs de moyenne, les points internes et les points aberrants.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.BoxAndWhisker, 20, 20, 500, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    let workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    let categoryCell = workbook.getCell(0, "A1", "Category 1");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A2", "Category 2");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A3", "Category 3");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A4", "Category 4");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A5", "Category 5");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A6", "Category 6");
    chart.getChartData().getCategories().add(categoryCell);

    let series = chart.getChartData().getSeries().add(aspose.slides.ChartType.BoxAndWhisker);

    series.setQuartileMethod(aspose.slides.QuartileMethodType.Exclusive);
    series.setShowMeanLine(true);
    series.setShowMeanMarkers(true);
    series.setShowInnerPoints(true);
    series.setShowOutlierPoints(true);

    let valueCell = workbook.getCell(0, "B1", 15);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(valueCell);
    valueCell = workbook.getCell(0, "B2", 41);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(valueCell);
    valueCell = workbook.getCell(0, "B3", 16);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(valueCell);
    valueCell = workbook.getCell(0, "B4", 10);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(valueCell);
    valueCell = workbook.getCell(0, "B5", 23);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(valueCell);
    valueCell = workbook.getCell(0, "B6", 16);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(valueCell);

    presentation.save("BoxAndWhisker.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

### **Créer des graphiques en entonnoir (Funnel)**

Les graphiques en entonnoir sont utilisés pour visualiser des processus comportant des étapes séquentielles, où le volume des données diminue à chaque étape. Ils sont particulièrement utiles pour analyser les taux de conversion, identifier les goulets d’étranglement et suivre l’efficacité des processus de vente ou de marketing.

Cet exemple utilise [addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) pour ajouter un graphique en entonnoir à la première diapositive d’une présentation existante. Il remplace les données par défaut par six catégories et valeurs allant de 50 à 500, puis enregistre la présentation mise à jour. La présentation d’entrée doit contenir au moins une diapositive.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation("test.pptx");
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.Funnel, 50, 50, 500, 400);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    let workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    let categoryCell = workbook.getCell(0, "A1", "Category 1");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A2", "Category 2");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A3", "Category 3");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A4", "Category 4");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A5", "Category 5");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A6", "Category 6");
    chart.getChartData().getCategories().add(categoryCell);

    let series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Funnel);

    let valueCell = workbook.getCell(0, "B1", 50);
    series.getDataPoints().addDataPointForFunnelSeries(valueCell);
    valueCell = workbook.getCell(0, "B2", 100);
    series.getDataPoints().addDataPointForFunnelSeries(valueCell);
    valueCell = workbook.getCell(0, "B3", 200);
    series.getDataPoints().addDataPointForFunnelSeries(valueCell);
    valueCell = workbook.getCell(0, "B4", 300);
    series.getDataPoints().addDataPointForFunnelSeries(valueCell);
    valueCell = workbook.getCell(0, "B5", 400);
    series.getDataPoints().addDataPointForFunnelSeries(valueCell);
    valueCell = workbook.getCell(0, "B6", 500);
    series.getDataPoints().addDataPointForFunnelSeries(valueCell);

    presentation.save("Funnel.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Le résultat :

![The Funnel chart](funnel_chart.png)

### **Créer des graphiques à rayons (Sunburst)**

Les graphiques à rayons sont utilisés pour visualiser des données hiérarchiques, affichant les niveaux sous forme d’anneaux concentriques. Ils aident à illustrer les relations partie‑à‑tout et sont idéaux pour représenter des catégories et sous‑catégories imbriquées de manière claire et compacte.

Cet exemple crée un graphique à rayons avec huit feuilles regroupées en quatre troncs et deux branches. La méthode [setGroupingItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategorylevelsmanager/setgroupingitem/) affecte les troncs au niveau de groupement 1 et les branches au niveau 2. Les libellés de catégorie identifient les segments, et les valeurs déterminent leurs tailles relatives.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.Sunburst, 20, 20, 500, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    let workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    // Branche 1
    let categoryCell = workbook.getCell(0, "C1", "Leaf1");
    let leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    categoryCell = workbook.getCell(0, "C2", "Leaf2");
    chart.getChartData().getCategories().add(categoryCell);

    categoryCell = workbook.getCell(0, "C3", "Leaf3");
    leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    categoryCell = workbook.getCell(0, "C4", "Leaf4");
    chart.getChartData().getCategories().add(categoryCell);

    // Branche 2
    categoryCell = workbook.getCell(0, "C5", "Leaf5");
    leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");

    categoryCell = workbook.getCell(0, "C6", "Leaf6");
    chart.getChartData().getCategories().add(categoryCell);

    categoryCell = workbook.getCell(0, "C7", "Leaf7");
    leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");

    categoryCell = workbook.getCell(0, "C8", "Leaf8");
    chart.getChartData().getCategories().add(categoryCell);

    let series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Sunburst);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    let valueCell = workbook.getCell(0, "D1", 4);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);
    valueCell = workbook.getCell(0, "D2", 5);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);
    valueCell = workbook.getCell(0, "D3", 3);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);
    valueCell = workbook.getCell(0, "D4", 6);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);
    valueCell = workbook.getCell(0, "D5", 9);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);
    valueCell = workbook.getCell(0, "D6", 9);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);
    valueCell = workbook.getCell(0, "D7", 4);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);
    valueCell = workbook.getCell(0, "D8", 3);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);

    presentation.save("Sunburst.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Le résultat :

![The Sunburst chart](sunburst_chart.png)

### **Créer des graphiques d’histogramme**

Les graphiques d’histogramme montrent comment les valeurs numériques sont distribuées sur des intervalles (bins). Pour des rapports mensuels sur les temps de traitement des commandes, utilisez la même largeur de bin et les mêmes seuils afin de garder les intervalles cohérents et de faciliter la comparaison des distributions.

Appelez [setAggregationType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setaggregationtype/) sur l’axe horizontal avec un mode provenant de [AxisAggregationType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axisaggregationtype/). [setBinWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setbinwidth/) ne s’applique qu’à `ByBinWidth` ; [setNumberOfBins](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberofbins/) ne s’applique qu’à `ByNumberOfBins`. Utilisez `Automatic` pour laisser le graphique choisir les bins.

#### **Utiliser une largeur de bin fixe**

Cet exemple regroupe les temps de traitement en intervalles de 10 minutes, avec des bins séparés pour les temps ≤ 10 minutes et > 40 minutes. Activez ces bins avec [setUnderflowBin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setunderflowbin/) et [setOverflowBin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setoverflowbin/). Lors de la fourniture de seuils explicites via [setUnderflowBin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setunderflowbin/) et [setOverflowBin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setoverflowbin/), appelez [setAutomaticUnderflowBin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticunderflowbin/) et [setAutomaticOverflowBin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticoverflowbin/) avec `false`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.Histogram, 20, 20, 680, 200);

    chart.setLegend(false);
    chart.setTitle(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    let workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    let series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Histogram);
    let values = [ 5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50 ];
    for (let i = 0; i < values.length; i++)
    {
        let valueCell = workbook.getCell(0, i, 0, values[i]);
        series.getDataPoints().addDataPointForHistogramSeries(valueCell);
    }

    let axis = chart.getAxes().getHorizontalAxis();
    axis.setAggregationType(aspose.slides.AxisAggregationType.ByBinWidth);
    axis.setBinWidth(10);
    axis.setUnderflowBin(true);
    axis.setAutomaticUnderflowBin(false);
    axis.setUnderflowBin(10);
    axis.setOverflowBin(true);
    axis.setAutomaticOverflowBin(false);
    axis.setOverflowBin(40);

    presentation.save("Histogram-bin-width.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

La présentation affichée dans PowerPoint montre les comptages de bins **3, 4, 4, 4 et 2**. Le bin de sous‑flux comprend `5, 10, 10`, son seuil étant inclusif. Le bin de dépassement ne comprend que `41, 50`, son seuil étant exclusif ; les valeurs égales à `40` restent dans l’intervalle précédent. Les bins intérieurs contiennent des valeurs supérieures à leur limite inférieure et inférieures ou égales à leur limite supérieure.

![Histogram with 10-minute bins and explicit underflow and overflow thresholds](histogram_bin_width.png)

#### **Spécifier le nombre de bins**

Pour un niveau de détail fixe plutôt que des intervalles fixes, demandez cinq bins pour les mêmes données. Cet exemple laisse les bins de sous‑flux et de dépassement désactivés. Le graphique détermine la largeur à partir de la plage de données, de sorte que les limites peuvent changer entre les rapports.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.Histogram, 20, 20, 680, 200);

    chart.setLegend(false);
    chart.setTitle(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    let workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    let series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Histogram);
    let values = [ 5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50 ];
    for (let i = 0; i < values.length; i++)
    {
        let valueCell = workbook.getCell(0, i, 0, values[i]);
        series.getDataPoints().addDataPointForHistogramSeries(valueCell);
    }

    let axis = chart.getAxes().getHorizontalAxis();
    axis.setAggregationType(aspose.slides.AxisAggregationType.ByNumberOfBins);
    axis.setNumberOfBins(5);

    presentation.save("Histogram-bin-count.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Les cinq bins ont des comptages de **4, 4, 4, 4 et 1**. Comparez cette distribution avec le résultat à largeur fixe ci‑dessus : les valeurs d’entrée sont identiques, mais les limites diffèrent.

![Histogram with five bins calculated from the same data](histogram_bin_count.png)

### **Créer des graphiques radar**

Les graphiques radar sont utilisés pour afficher des données multidimensionnelles dans un format bidimensionnel, permettant de comparer facilement plusieurs variables simultanément. Ils sont particulièrement utiles pour identifier des motifs, des forces et des faiblesses à travers plusieurs indicateurs de performance ou attributs.

Cet exemple utilise [addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) pour créer un graphique radar avec les séries et catégories par défaut, puis enregistre la présentation au format PPTX.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addChart(aspose.slides.ChartType.Radar, 20, 20, 500, 300);

    presentation.save("Radar-chart.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Le résultat :

![The Radar chart](radar_chart.png)

### **Créer des graphiques multi‑catégories**

Les graphiques multi‑catégories sont utilisés pour afficher des données impliquant plus d’un groupement catégoriel, vous permettant de comparer des valeurs sur plusieurs dimensions simultanément. Ils sont particulièrement utiles lorsque vous devez analyser les tendances et les relations au sein d’ensembles de données complexes et à plusieurs niveaux.

Cet exemple crée un graphique à colonnes groupées avec huit catégories disposées en quatre paires. La méthode [setGroupingItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategorylevelsmanager/setgroupingitem/) attribue à chaque paire un libellé partagé au niveau de groupement 1, produisant un axe de catégorie avec des libellés individuels et de groupe.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    let workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    let worksheetIndex = 0;

    let categoryCell = workbook.getCell(0, "c2", "A");
    let category = chart.getChartData().getCategories().add(categoryCell);
    category.getGroupingLevels().setGroupingItem(1, "Group1");
    categoryCell = workbook.getCell(0, "c3", "B");
    category = chart.getChartData().getCategories().add(categoryCell);

    categoryCell = workbook.getCell(0, "c4", "C");
    category = chart.getChartData().getCategories().add(categoryCell);
    category.getGroupingLevels().setGroupingItem(1, "Group2");
    categoryCell = workbook.getCell(0, "c5", "D");
    category = chart.getChartData().getCategories().add(categoryCell);

    categoryCell = workbook.getCell(0, "c6", "E");
    category = chart.getChartData().getCategories().add(categoryCell);
    category.getGroupingLevels().setGroupingItem(1, "Group3");
    categoryCell = workbook.getCell(0, "c7", "F");
    category = chart.getChartData().getCategories().add(categoryCell);

    categoryCell = workbook.getCell(0, "c8", "G");
    category = chart.getChartData().getCategories().add(categoryCell);
    category.getGroupingLevels().setGroupingItem(1, "Group4");
    categoryCell = workbook.getCell(0, "c9", "H");
    category = chart.getChartData().getCategories().add(categoryCell);

    let seriesNameCell = workbook.getCell(0, "D1", "Series 1");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.ClusteredColumn);

    let valueCell = workbook.getCell(worksheetIndex, "D2", 10);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, "D3", 20);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, "D4", 30);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, "D5", 40);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, "D6", 50);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, "D7", 60);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, "D8", 70);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, "D9", 80);
    series.getDataPoints().addDataPointForBarSeries(valueCell);

    presentation.save("AsposeChart.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Le résultat :

![The multi category chart](multi_category_chart.png)

#### **Supprimer un libellé de trimestre**

Téléchargez [quarters.pptx](quarters.pptx) et placez‑le dans le répertoire de travail. Son graphique montre neuf mois et une série de ventes avec des valeurs de 10 à 18. Sur l’axe de catégorie, Q1 couvre janvier à mars, Q2 avril à juin, et Q3 juillet à septembre.

Avril est la quatrième catégorie (indice 3) et possède le libellé Q2. Utilisez [getGroupingLevels](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategory/getgroupinglevels/) pour accéder aux niveaux de groupement d’avril, puis appelez [deleteGroupingItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategorylevelsmanager/deletegroupingitem/) avec le niveau 1 pour supprimer son libellé de trimestre. Le niveau 0 représente le mois lui‑-même et ne peut pas être supprimé avec cette méthode.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("quarters.pptx");
try {
    const chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const april = chart.getChartData().getCategories().get_Item(3);
    april.getGroupingLevels().deleteGroupingItem(1);

    presentation.save("quarters-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopened = new aspose.slides.Presentation("quarters-updated.pptx");
try {
    const chart = reopened.getSlides().get_Item(0).getShapes().get_Item(0);
    const data = chart.getChartData();

    const categories = data.getCategories();
    const months = [];
    
    for (let i = 0; i < categories.size(); i++) {
        months.push(categories.get_Item(i).getAsCell().getValue());
    }
    const points = data.getSeries().get_Item(0).getDataPoints();
    const sales = [];
    for (let i = 0; i < points.size(); i++) {
        sales.push(points.get_Item(i).getValue().getData());
    }
    console.log(months.join(", "));
    console.log(sales.join(", "));
} finally {
    reopened.dispose();
}
```

Après avoir rouvert le graphique, l’exemple affiche les mois d’origine (`Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep`) et les valeurs de ventes (`10, 11, 12, 13, 14, 15, 16, 17, 18`) dans le même ordre. Ouvrez `quarters-updated.pptx` dans PowerPoint pour comparer les libellés d’axe. Le libellé Q2 et la frontière de groupe avant avril disparaissent, de sorte que Q1 s’étend de janvier à juin. Q3 commence toujours en juillet.

![Quarter labels before and after removal. On the left, Q2 spans April through June. On the right, Q1 spans January through June.](quarter-label-comparison.png)

### **Créer des graphiques cartographiques (Map)**

Les graphiques cartographiques sont utilisés pour visualiser des données géographiques en associant des informations à des emplacements spécifiques tels que des pays, des États ou des villes. Ils sont particulièrement utiles pour analyser les tendances régionales, les données démographiques et les distributions spatiales de manière claire et visuellement attrayante.

Cet exemple utilise [addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) pour créer un graphique cartographique avec les données géographiques par défaut et l’enregistre pour visualisation dans PowerPoint.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.Map, 20, 20, 500, 300);

    presentation.save("mapChart.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Le résultat :

![The Map chart](map_chart.png)

{{% alert color="info" title="Remarque" %}}

L’image ci‑dessus montre la présentation enregistrée ouverte dans PowerPoint. Aspose.Slides écrit correctement le graphique cartographique et ses données, mais n’affiche pas lui‑même les graphiques cartographiques : lorsqu’une diapositive contenant un tel graphique est rendue en image ou convertie en PDF ou SVG, la zone du graphique apparaît vide. Les autres formes de la même diapositive ne sont pas affectées.

{{% /alert %}}

### **Créer des graphiques combinés**

Un graphique combiné (ou combo) associe deux types de graphiques ou plus dans un même tracé. Ce graphique vous permet de mettre en évidence, comparer ou examiner les différences entre deux ensembles de données ou plus, aidant à identifier les relations entre eux.

![The combination chart](combination_chart.png)

Cet exemple combine deux séries de colonnes groupées avec une série en ligne sur quatre catégories. Les colonnes utilisent l’axe vertical principal, tandis que [setPlotOnSecondAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setplotonsecondaxis/) place la ligne sur un axe vertical secondaire à droite. Les fonctions d’assistance configurent le titre, la légende, les libellés d’axe et les quadrillages.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function createComboChart()
{
    let presentation = new aspose.slides.Presentation();
    try
    {
        let chart = createChartWithFirstSeries(presentation.getSlides().get_Item(0));

        addSecondSeriesToChart(chart);
        addThirdSeriesToChart(chart);

        setPrimaryAxesFormat(chart);
        setSecondaryAxesFormat(chart);

        presentation.save("combo-chart.pptx", aspose.slides.SaveFormat.Pptx);
    }
    finally
    {
        presentation.dispose();
    }
}

function createChartWithFirstSeries(slide)
{
    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    let portionFormat = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    portionFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    portionFormat.setFontHeight(18);

    chart.getLegend().setPosition(aspose.slides.LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    let workbook = chart.getChartData().getChartDataWorkbook();
    let worksheetIndex = 0;

    let categoryCell = workbook.getCell(worksheetIndex, 1, 0, "Category 1");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(worksheetIndex, 2, 0, "Category 2");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(worksheetIndex, 3, 0, "Category 3");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(worksheetIndex, 4, 0, "Category 4");
    chart.getChartData().getCategories().add(categoryCell);

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    let series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    series.getParentSeriesGroup().setOverlap(java.newByte(-25));
    series.getParentSeriesGroup().setGapWidth(220);

    let valueCell = workbook.getCell(worksheetIndex, 1, 1, 4.3);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 2, 1, 2.5);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 3, 1, 3.5);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 4, 1, 4.5);
    series.getDataPoints().addDataPointForBarSeries(valueCell);

    return chart;
}

function addSecondSeriesToChart(chart)
{
    let workbook = chart.getChartData().getChartDataWorkbook();
    let worksheetIndex = 0;

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.ClusteredColumn);

    series.getParentSeriesGroup().setOverlap(java.newByte(-25));
    series.getParentSeriesGroup().setGapWidth(220);

    let valueCell = workbook.getCell(worksheetIndex, 1, 2, 2.4);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 2, 2, 4.4);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 3, 2, 1.8);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 4, 2, 2.8);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
}

function addThirdSeriesToChart(chart)
{
    let workbook = chart.getChartData().getChartDataWorkbook();
    let worksheetIndex = 0;

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.Line);

    let valueCell = workbook.getCell(worksheetIndex, 1, 3, 2.0);
    series.getDataPoints().addDataPointForLineSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 2, 3, 2.0);
    series.getDataPoints().addDataPointForLineSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 3, 3, 3.0);
    series.getDataPoints().addDataPointForLineSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 4, 3, 5.0);
    series.getDataPoints().addDataPointForLineSeries(valueCell);

    series.setPlotOnSecondAxis(true);
}

function setPrimaryAxesFormat(chart)
{
    let horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(horizontalAxis, "X Axis");

    let verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(verticalAxis, "Y Axis 1");

    let majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    majorGridLinesFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat(chart)
{
    let secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(aspose.slides.AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(aspose.slides.CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    let secondaryVerticalAxis = chart.getAxes().getSecondaryVerticalAxis();
    secondaryVerticalAxis.setPosition(aspose.slides.AxisPositionType.Right);
    secondaryVerticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    secondaryVerticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryVerticalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryVerticalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

function setAxisTitle(axis, axisTitle)
{
    axis.setTitle(true);
    axis.getTitle().setOverlay(false);
    let titlePortionFormat = axis.getTitle().addTextFrameForOverriding(axisTitle).getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    titlePortionFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titlePortionFormat.setFontHeight(12);
}

createComboChart();
```

## **Mettre à jour les graphiques**

Aspose.Slides pour Node.js via Java vous permet de mettre à jour les graphiques PowerPoint en modifiant les données, la mise en forme et le style du graphique. Cette fonctionnalité simplifie le processus de mise à jour des présentations avec du contenu dynamique et garantit que les graphiques reflètent précisément les données actuelles et les normes visuelles.

Cet exemple met à jour le graphique nommé "My chart" sur la première diapositive d’une présentation existante. Il nécessite deux séries de colonnes avec trois points de données chacune, les libellés de catégorie se trouvant dans la colonne A et les noms de série dans la première ligne de la première feuille de calcul. L’exemple utilise [getCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getcell/) pour modifier les cellules du classeur, met à jour les valeurs des séries, ajoute une troisième série et change le type du graphique en cylindres groupés via [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/settype/).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let chartName = "My chart";

let presentation = new aspose.slides.Presentation("ExistingChart.pptx");
try
{
    let slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < slide.getShapes().size(); i++)
    {
        let shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IChart") && chartName === shape.getName())
        {
            let chart = shape;
            let worksheetIndex = 0;

            let workbook = chart.getChartData().getChartDataWorkbook();

            workbook.getCell(worksheetIndex, 1, 0, "Modified Category 1");
            workbook.getCell(worksheetIndex, 2, 0, "Modified Category 2");

            let series = chart.getChartData().getSeries().get_Item(0);

            workbook.getCell(worksheetIndex, 0, 1, "New_Series 1");
            series.getDataPoints().get_Item(0).getValue().setData(90);
            series.getDataPoints().get_Item(1).getValue().setData(123);
            series.getDataPoints().get_Item(2).getValue().setData(44);

            series = chart.getChartData().getSeries().get_Item(1);

            workbook.getCell(worksheetIndex, 0, 2, "New_Series 2");
            series.getDataPoints().get_Item(0).getValue().setData(23);
            series.getDataPoints().get_Item(1).getValue().setData(67);
            series.getDataPoints().get_Item(2).getValue().setData(99);

            let seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
            series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

            let valueCell = workbook.getCell(worksheetIndex, 1, 3, 20);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
            valueCell = workbook.getCell(worksheetIndex, 2, 3, 50);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
            valueCell = workbook.getCell(worksheetIndex, 3, 3, 30);
            series.getDataPoints().addDataPointForBarSeries(valueCell);

            chart.setType(aspose.slides.ChartType.ClusteredCylinder);
        }
    }

    presentation.save("AsposeChartModified.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

## **Définir la plage de données d’un graphique**

Pour inspecter la plage déjà utilisée par un graphique existant, consultez [Retrieve a Chart's Data Range](/slides/fr/nodejs-java/chart-workbook/#retrieve-a-charts-data-range).

Aspose.Slides pour Node.js via Java offre la flexibilité de définir une plage de données spécifique d’une feuille de calcul comme source pour les données de votre graphique. Cela signifie que vous pouvez mapper directement une portion de votre feuille de calcul au graphique, vous permettant de contrôler quelles cellules contribuent aux séries et aux catégories du graphique. En conséquence, vous pouvez facilement mettre à jour et synchroniser vos graphiques avec les dernières modifications de données dans votre feuille, assurant que vos présentations PowerPoint reflètent des informations actuelles et précises.

Cet exemple utilise [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) pour définir la source de données du graphique nommé "My chart" sur la première diapositive d’une présentation existante sur `Sheet1!A1:B4`. Le classeur du graphique doit contenir cette feuille et une plage remplie avec un en‑tête de série dans la première ligne, des libellés de catégorie dans la colonne A et trois valeurs dans la colonne B.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let chartName = "My chart";

let presentation = new aspose.slides.Presentation("ExistingChart.pptx");
try
{
    let slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < slide.getShapes().size(); i++)
    {
        let shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IChart") && chartName === shape.getName())
        {
            let chart = shape;
            chart.getChartData().setRange("Sheet1!A1:B4");
        }
    }

    presentation.save("SetDataRange.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

## **Utiliser des marqueurs par défaut dans les graphiques**

Lorsque vous utilisez des marqueurs par défaut dans les graphiques, chaque série de graphique obtient automatiquement un symbole de marqueur par défaut différent.

Cet exemple utilise [addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) pour créer un graphique avec deux séries en ligne et une légende. Les paramètres de marqueur accessibles via [getMarker](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getmarker/) conservent les symboles de marqueur attribués automatiquement. La première série comprend une valeur négative et une valeur manquante, représentée par `null`, tandis que la seconde possède une valeur pour chaque catégorie.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    let workbook = chart.getChartData().getChartDataWorkbook();

    let seriesNameCell = workbook.getCell(0, 0, 1, "Series 1");
    let series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    let categoryCell = workbook.getCell(0, 1, 0, "C1");
    chart.getChartData().getCategories().add(categoryCell);
    let valueCell = workbook.getCell(0, 1, 1, 24);
    series.getDataPoints().addDataPointForLineSeries(valueCell);

    categoryCell = workbook.getCell(0, 2, 0, "C2");
    chart.getChartData().getCategories().add(categoryCell);
    valueCell = workbook.getCell(0, 2, 1, 23);
    series.getDataPoints().addDataPointForLineSeries(valueCell);

    categoryCell = workbook.getCell(0, 3, 0, "C3");
    chart.getChartData().getCategories().add(categoryCell);
    valueCell = workbook.getCell(0, 3, 1, -10);
    series.getDataPoints().addDataPointForLineSeries(valueCell);

    categoryCell = workbook.getCell(0, 4, 0, "C4");
    chart.getChartData().getCategories().add(categoryCell);
    valueCell = workbook.getCell(0, 4, 1, null);
    series.getDataPoints().addDataPointForLineSeries(valueCell);

    seriesNameCell = workbook.getCell(0, 0, 2, "Series 2");
    let secondSeries = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    valueCell = workbook.getCell(0, 1, 2, 30);
    secondSeries.getDataPoints().addDataPointForLineSeries(valueCell);
    valueCell = workbook.getCell(0, 2, 2, 10);
    secondSeries.getDataPoints().addDataPointForLineSeries(valueCell);
    valueCell = workbook.getCell(0, 3, 2, 60);
    secondSeries.getDataPoints().addDataPointForLineSeries(valueCell);
    valueCell = workbook.getCell(0, 4, 2, 40);
    secondSeries.getDataPoints().addDataPointForLineSeries(valueCell);

    chart.setLegend(true);
    chart.getLegend().setOverlay(false);

    presentation.save("DefaultMarkersInChart.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

## **FAQ**

**Quels types de graphiques sont pris en charge par Aspose.Slides pour Node.js via Java ?**

Aspose.Slides pour Node.js via Java prend en charge un large éventail de types de graphiques, notamment les graphiques à barres, en lignes, circulaires, d’aires, de dispersion, d’histogramme, radar et bien d’autres. Cette flexibilité vous permet de choisir le type de graphique le plus approprié à vos besoins de visualisation de données.

**Comment ajouter un nouveau graphique à une diapositive ?**

Pour ajouter un graphique, créez d’abord une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/), récupérez la diapositive souhaitée à l’aide de son indice, puis appelez la méthode d’ajout de graphique en spécifiant le type de graphique et les données initiales. Ce processus intègre le graphique directement dans votre présentation.

**Comment mettre à jour les données affichées dans un graphique ?**

Vous pouvez mettre à jour les données d’un graphique en accédant à son classeur de données ([ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/)), en supprimant les séries et catégories par défaut, puis en ajoutant vos propres données. Cela vous permet de rafraîchir programmatiquement le graphique pour refléter les dernières données.

**Est‑il possible de personnaliser l’apparence du graphique ?**

Oui, Aspose.Slides pour Node.js via Java offre de nombreuses options de personnalisation. Vous pouvez modifier les couleurs, les polices, les libellés, les légendes et d’autres éléments de mise en forme pour adapter l’apparence du graphique à vos exigences de conception spécifiques.