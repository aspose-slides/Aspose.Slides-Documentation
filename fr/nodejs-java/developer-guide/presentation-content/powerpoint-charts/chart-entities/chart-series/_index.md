---
title: Gérer les séries de données de graphique dans les présentations avec JavaScript
linktitle: Séries de données
type: docs
url: /fr/nodejs-java/chart-series/
keywords:
- séries de graphiques
- chevauchement des séries
- couleur des séries
- nom de la série
- point de données
- cellule de classeur
- écart de la série
- valeur négative
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Apprenez à gérer les séries de graphiques, les points de données, les cellules de classeur, le formatage, le chevauchement, la largeur d’écart et les valeurs négatives dans les présentations avec JavaScript."
---
## **Vue d'ensemble**

Un graphique peut stocker ses valeurs tracées dans des cellules de classeur ou directement sous forme de littéraux numériques. Un [ChartSeries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/) représente un ensemble de valeurs liées, et chaque [ChartDataPoint](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/) représente un point de cette série. Les objets [ChartCategory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategory/) fournissent les étiquettes ou les valeurs de regroupement partagées par les séries. Dans les graphiques créés avec des données par défaut, les noms de séries, les catégories et les valeurs des points utilisent des objets [ChartDataCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/) du classeur du graphique.

Pour un graphique de catégorie typique, le classeur par défaut utilise la ligne 0 pour les noms de séries, la colonne 0 pour les noms de catégories, et les cellules restantes pour les valeurs des séries. Les index de feuille, de ligne et de colonne transmis à [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getcell/) sont basés sur zéro. Cette disposition est pratique lorsque vous créez un graphique avec des données par défaut, mais ne supposez pas qu’elle s’applique à chaque graphique existant. Pour une présentation chargée, examinez les cellules référencées par les séries, les catégories et les points de données avant de modifier les valeurs du classeur.

Les paramètres du graphique ont trois portées différentes :

- Paramètres au niveau de la série, tels que [ChartSeries.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getformat/), fournissent l’apparence par défaut pour tous les points d’une série.
- Paramètres de point de données, tels que [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getformat/), remplacent l’apparence de la série pour un point.
- Les paramètres de groupe s’appliquent aux séries compatibles appartenant au même [ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/). Accédez au groupe via [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/) lorsque vous devez définir des options comme le chevauchement ou la largeur de l’écart.

Lorsqu’aucun remplissage explicite de point ou de série n’est défini, le style et le thème du graphique déterminent l’apparence automatique. Lorsque les deux formatages série et point sont présents, le formatage du point l’emporte pour ce point.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Définir les valeurs de série à l’aide de littéraux numériques**

Utilisez des littéraux numériques lorsque les valeurs des séries proviennent de données d’application ou de calculs et n’ont pas besoin de références à des cellules de feuille. Appelez [setDataSourceTypeForValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforvalues/) avec [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/) avant d’affecter à chaque point le résultat de [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getvalue/) via [setAsLiteralDouble](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/setasliteraldouble/).

Le paramètre de collection contrôle le type source de toutes les valeurs de points de cette série. La méthode [getDataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/basechartvalue/) de chaque valeur de point indique le type sélectionné ; modifiez‑le via le paramètre de collection. Avec `Worksheet`, utilisez [getAsCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/getascell/) pour accéder à la cellule référencée. Avec `DoubleLiterals`, utilisez [getAsLiteralDouble](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/getasliteraldouble/) ou `setAsLiteralDouble` pour lire ou écrire le nombre directement.

L’exemple suivant crée un graphique à colonnes avec des séries et catégories par défaut, puis affecte les valeurs calculées 10, 20, etc. aux points existants de sa première série. Il enregistre la présentation, la rouvre et affiche les valeurs stockées.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);
    const series = chart.getChartData().getSeries().get_Item(0);

    series.getDataPoints().setDataSourceTypeForValues(aspose.slides.DataSourceType.DoubleLiterals);
    for (let i = 0; i < series.getDataPoints().size(); i++) {
        series.getDataPoints().get_Item(i).getValue().setAsLiteralDouble((i + 1) * 10);
    }

    presentation.save("numeric_literals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation("numeric_literals.pptx");
try {
    const reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    const reopenedChart = reopenedSlide.getShapes().get_Item(0);
    const reopenedSeries = reopenedChart.getChartData().getSeries().get_Item(0);
    for (let i = 0; i < reopenedSeries.getDataPoints().size(); i++) {
        const point = reopenedSeries.getDataPoints().get_Item(i);
        console.log(point.getValue().getAsLiteralDouble());
    }
} finally {
    reopenedPresentation.dispose();
}
```

Le type source de la valeur du point est distinct de [ChartData.getDataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/), qui identifie la configuration interne ou externe du classeur du graphique. L’utilisation de littéraux numériques ne supprime pas, en soi, le classeur intégré. Dans cet exemple, le classeur reste disponible pour les libellés de catégories, les noms de séries et les autres séries. Consultez [Chart Workbook](/slides/fr/nodejs-java/chart-workbook/) pour la gestion du classeur.

Pour les graphiques de dispersion et à bulles, utilisez [setDataSourceTypeForXValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforxvalues/) et [setDataSourceTypeForYValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforyvalues/) afin de choisir les sources pour [getXValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getxvalue/) et [getYValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getyvalue/). Les graphiques à bulles utilisent également [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforbubblesizes/) pour [getBubbleSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getbubblesize/). Définissez chaque source applicable sur `DoubleLiterals` avant d’affecter des nombres via la méthode `setAsLiteralDouble` de cette valeur.

## **Définir le chevauchement des séries du graphique**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getoverlap/) indique de combien de pourcentage les barres ou colonnes se chevauchent dans un graphique 2D, de -100 à 100 %. Il s’agit d’une projection en lecture seule du paramètre du groupe de séries parent. Utilisez [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setoverlap/) pour mettre à jour toutes les séries compatibles de ce groupe. Cette option s’applique aux types de graphiques affichant des barres ou colonnes groupées ; elle n’affecte pas les groupes de séries non liés dans un graphique combiné.

L’exemple suivant définit le chevauchement pour le groupe contenant la première série :

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const overlapPercent = java.newByte(30);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    // Le nouveau graphique contient des séries d'exemple, des catégories et des valeurs.
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![The series overlap](series_overlap.png)

## **Modifier la couleur de remplissage de la série**

Utilisez [ChartSeries.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getformat/) pour définir le remplissage par défaut d’une série entière. Si un point possède déjà un remplissage explicite, son paramètre [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getformat/) remplace le remplissage de la série pour ce point.

L’exemple suivant applique un remplissage bleu uni à la première série :

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(blueColor);

    presentation.save("series_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![The color of the series](series_color.png)

## **Modifier le nom de la série**

Le nom d’une série est stocké dans le classeur de données du graphique et apparaît normalement dans la légende. Dans le classeur par défaut créé pour un graphique à colonnes groupées, la cellule B1 est à la ligne 0, colonne 1 et contient le nom de la première série. Les constantes nommées de l’exemple suivant rendent cette structure explicite :

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const worksheetIndex = 0;
const seriesNameRowIndex = 0;
const firstSeriesColumnIndex = 1;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const workbook = chart.getChartData().getChartDataWorkbook();
    const seriesNameCell = workbook.getCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Vous pouvez également mettre à jour la cellule déjà référence par [ChartSeries.getName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getname/). Cette approche évite de supposer une ligne et une colonne particulières dans un graphique existant :

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const firstNameCellIndex = 0;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const seriesNameCell = series.getName().getAsCells().get_Item(firstNameCellIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![The series name](series_name.png)

### **Créer une série avec un nom provenant de plusieurs cellules**

Un nom de série composite est utile lorsqu’un nom de produit et une période de reporting sont stockés dans des cellules de classeur distinctes. Par exemple, vous pouvez combiner `Product A` en B1 et `2026` en C1 en un seul nom de série tout en conservant les deux parties liées à leurs cellules source.

Utilisez [ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getcellcollection/) pour récupérer la plage de noms, puis transmettez cette collection à [ChartSeriesCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriescollection/add/). Le paramètre `skipHiddenCells` contrôle l’inclusion des cellules masquées : `true` les exclut, `false` les inclut. Cet exemple utilise `false` pour inclure chaque cellule de la plage de noms.

L’exemple suivant crée une présentation avec une série et deux points de données. Les cellules B1:C1 ne contiennent que le nom de la série ; A2:A3 contiennent les libellés de catégorie, et B2:B3 les valeurs numériques.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 620, 180);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(true);

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    // Ces deux cellules fournissent le nom de la série.
    workbook.getCell(0, 0, 1, "Product A");
    workbook.getCell(0, 0, 2, "2026");
    const nameCells = workbook.getCellCollection("Sheet1!$B$1:$C$1", false);
    const series = chart.getChartData().getSeries().add(nameCells, aspose.slides.ChartType.ClusteredColumn);

    // Des cellules séparées fournissent les catégories et les points de données numériques.
    const northCategory = workbook.getCell(0, 1, 0, "North");
    const southCategory = workbook.getCell(0, 2, 0, "South");
    chart.getChartData().getCategories().add(northCategory);
    chart.getChartData().getCategories().add(southCategory);
    const northValue = workbook.getCell(0, 1, 1, 120);
    const southValue = workbook.getCell(0, 2, 1, 150);
    series.getDataPoints().addDataPointForBarSeries(northValue);
    series.getDataPoints().addDataPointForBarSeries(southValue);

    presentation.save("composite_series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le nom de série résultant est `Product A 2026`, avec un espace entre les deux valeurs de cellule. La légende l’affiche comme une seule entrée pour les deux colonnes. L’image ci‑dessous illustre le résultat :

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **Obtenir la couleur de remplissage automatique de la série**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getautomaticseriescolor/) renvoie la couleur calculée à partir de l’indice de la série et du style du graphique. C’est la couleur utilisée lorsque le remplissage de la série n’a pas été défini explicitement. L’appel de la méthode lit la couleur calculée ; il ne définit pas un nouveau remplissage.

L’exemple suivant affiche la couleur automatique de chaque série par défaut :

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const seriesCount = chart.getChartData().getSeries().size();
    for (let seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        const series = chart.getChartData().getSeries().get_Item(seriesIndex);
        const automaticColor = series.getAutomaticSeriesColor();
        const automaticColorText = automaticColor.toString();
        console.log("Series " + seriesIndex + ": " + automaticColorText);
    }
} finally {
    presentation.dispose();
}
```

Exemple de sortie pour le style de graphique par défaut :

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

Les couleurs exactes dépendent du style et du thème du graphique.

## **Définir la couleur de remplissage inversé pour une série de graphique**

Pour les séries à barres, colonnes et bulles, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setinvertifnegative/) peut afficher les valeurs négatives avec un remplissage différent. Définissez le remplissage régulier de la série sur solide, activez l’inversion et attribuez la couleur des valeurs négatives via [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getinvertedsolidfillcolor/). Les nombres négatifs restent inchangés dans le classeur ; seul leur couleur d’affichage change.

L’exemple suivant remplace les données du graphique par défaut par une série. La ligne 0 de la feuille contient le nom de la série, la colonne 0 les noms de catégorie, et la colonne 1 les valeurs :

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const worksheetIndex = 0;
const headerRowIndex = 0;
const categoryColumnIndex = 0;
const firstSeriesColumnIndex = 1;
const firstDataRowIndex = 1;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const redColor = java.getStaticFieldValue("java.awt.Color", "RED");

const categoryNames = ["Category 1", "Category 2", "Category 3"];
const seriesValues = [-20, 50, -30];

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);
    const chartData = chart.getChartData();
    const workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    const seriesNameCell = workbook.getCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
    const chartType = chart.getType();
    const series = chartData.getSeries().add(seriesNameCell, chartType);

    for (let categoryIndex = 0; categoryIndex < categoryNames.length; categoryIndex++) {
        const dataRowIndex = firstDataRowIndex + categoryIndex;
        const categoryName = categoryNames[categoryIndex];
        const seriesValue = seriesValues[categoryIndex];

        const categoryCell = workbook.getCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
        chartData.getCategories().add(categoryCell);

        const valueCell = workbook.getCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    const automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.setInvertIfNegative(true);
    series.getInvertedSolidFillColor().setColor(redColor);

    presentation.save("inverted_solid_fill_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![The inverted solid fill color](inverted_solid_fill_color.png)

Vous pouvez activer l’inversion pour un point via [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/setinvertifnegative/). Dans l’exemple suivant, l’inversion est désactivée pour la série et activée uniquement pour le point sélectionné. Ce point reçoit également une valeur négative afin que l’effet soit visible :

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const targetDataPointIndex = 2;
const negativeValue = -30;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const redColor = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.getInvertedSolidFillColor().setColor(redColor);
    series.setInvertIfNegative(false);

    const dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(negativeValue);
    dataPoint.setInvertIfNegative(true);

    presentation.save("data_point_invert_color_if_negative.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Effacer la valeur d’un point de données spécifique**

Pour rendre un point vide sans supprimer les autres points, définissez sa cellule de classeur sous‑jacent sur `null`. Pour un graphique à colonnes, la valeur tracée est accessible via [ChartDataPoint.getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getvalue/). Le point de données reste à la même position de catégorie, mais le graphique traite sa valeur comme vide selon les paramètres de valeurs vides du graphique.

L’exemple suivant ne vide que le deuxième point de la première série :

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const targetDataPointIndex = 1;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(null);

    presentation.save("clear_data_point_value.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Les graphiques de dispersion utilisent des cellules X et Y distinctes, et les graphiques à bulles utilisent également une cellule de taille. Videz uniquement la cellule qui représente la valeur que vous souhaitez supprimer. N’appeler pas [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/clear/) lorsque vous voulez conserver les autres points, car cette méthode supprime tous les points de la collection.

## **Contrôler l’affichage des cellules vides**

Les cellules masquées contenant des valeurs constituent un cas distinct des cellules vides. Pour inclure ou exclure les données des lignes et colonnes masquées, consultez [Include Data from Hidden Rows and Columns](/slides/fr/nodejs-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Une cellule de classeur vide représente des données manquantes ; une cellule contenant `0` représente une valeur numérique connue. Appelez [ChartDataCell.setValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setvalue/) avec `null` pour rendre une cellule vide. Un zéro numérique reste zéro quel que soit le paramètre de cellule vide.

Utilisez [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/) pour choisir comment le graphique affiche les cellules vides. Ce paramètre s’applique à l’ensemble du graphique. Il modifie la façon dont les blancs sont tracés, sans remplir la cellule vide avec zéro ou une valeur interpolée.

L’exemple autonome suivant crée un graphique en courbes avec une série, vide la valeur du jour 3, et enregistre le même graphique avec chaque mode. Aucun fichier d’entrée n’est requis. Le [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/) utilise la feuille 0, la colonne 0 pour les libellés de catégorie et la colonne 1 pour les valeurs ; la ligne 0 contient le nom de la série. Les données finales sont `10, 20, empty, 30, 40`.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 40, 40, 640, 400);
    const chartData = chart.getChartData();
    const workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    const seriesNameCell = workbook.getCell(0, 0, 1, "Measurements");
    const series = chartData.getSeries().add(seriesNameCell, chart.getType());
    const values = [10, 20, 25, 30, 40];

    for (let i = 0; i < values.length; i++) {
        const categoryCell = workbook.getCell(0, i + 1, 0, "Day " + (i + 1));
        chartData.getCategories().add(categoryCell);
        const valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Laisser le jour 3 réellement vide, tout en conservant sa catégorie et son point de données.
    workbook.getCell(0, 3, 1).setValue(null);

    const modes = [aspose.slides.DisplayBlanksAsType.Gap, aspose.slides.DisplayBlanksAsType.Zero, aspose.slides.DisplayBlanksAsType.Span];
    const modeNames = ["Gap", "Zero", "Span"];
    for (let i = 0; i < modes.length; i++) {
        chart.setDisplayBlanksAs(modes[i]);
        presentation.save("empty_cells_" + modeNames[i] + ".pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Chaque fichier de sortie stocke le mode assigné avant l’enregistrement : `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` et `empty_cells_Span.pptx`. Pour n’enregistrer qu’une version, affectez le mode souhaité et enregistrez la présentation une seule fois au lieu d’itérer sur les modes.

La comparaison ci‑dessous montre les mêmes données dans les trois fichiers. Le jour 3 est vide dans le classeur dans chaque cas :

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

L’effet visible dépend du type de graphique. Un graphique en courbes rend les trois modes faciles à comparer. Les graphiques à barres et à colonnes n’ont pas de ligne à connecter à travers une catégorie manquante, de sorte que `Span` ne peut pas produire le segment de connexion montré ci‑dessus ; une colonne manquante et une colonne de hauteur zéro peuvent aussi se ressembler. De même, un graphique de dispersion avec uniquement des marqueurs n’a pas de ligne de connexion. N’attendez pas trois résultats distincts pour chaque type de graphique ; vérifiez la sortie pour le type que vous utilisez.

## **Définir la largeur de l’écart de la série**

La largeur de l’écart correspond à l’espace entre les groupes de barres ou de colonnes adjacents, exprimé en pourcentage de la largeur de la barre ou de la colonne. Comme le chevauchement, elle appartient au groupe de séries parent plutôt qu’à une série individuelle. Appelez [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) une fois pour le groupe. Une valeur plus grande crée davantage d’espace entre les groupes ; une valeur plus petite les rend plus denses.

L’exemple suivant modifie la largeur de l’écart et n’enregistre que la présentation finale :

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const gapWidthPercent = 30;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setGapWidth(gapWidthPercent);

    presentation.save("gap_width_30.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![The gap width](gap_width.png)

## **FAQ**

**Quels types de graphiques supportent les séries de données ?**

Tous les types de graphiques représentés par l’énumération [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) utilisent des données de graphique, mais leurs séries n’ont pas toutes la même structure de valeurs ou les mêmes paramètres. Par exemple, les graphiques de catégorie utilisent des catégories et des valeurs, les graphiques de dispersion utilisent les valeurs X et Y, et les graphiques à bulles ajoutent des tailles de bulles. Utilisez la méthode de création de point de données qui correspond au type de série. Les options telles que le chevauchement et la largeur de l’écart ne s’appliquent qu’aux groupes de barres ou de colonnes compatibles.

**Qu’est‑ce qu’un groupe de séries de graphique ?**

Un [ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/) regroupe des séries compatibles qui partagent des paramètres de traçage au niveau du groupe. Un graphique combiné peut contenir plusieurs groupes, de sorte que la modification du groupe atteint via une série ne modifie pas forcément toutes les séries du graphique.

**Un graphique nouvellement créé contient‑t‑il des données par défaut ?**

Oui. Par défaut, [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) crée des séries, catégories et valeurs d’exemple. Vous pouvez modifier ces cellules ou effacer les collections de séries et de catégories avant d’ajouter un jeu de données entièrement personnalisé. Une surcharge peut également créer un graphique sans données par défaut.

**Comment les objets du graphique sont‑ils liés aux cellules du classeur ?**

Les noms de séries, les libellés de catégories et les valeurs des points de données référencent des cellules d’un [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/). Modifier une cellule référencée met à jour l’élément de graphique correspondant. Lorsque vous construisez des données personnalisées, maintenez les lignes de catégorie et les lignes de valeurs de série alignées afin que chaque point soit tracé sous la catégorie prévue.

**Comment effacer un seul point au lieu de toute la série ?**

Définissez la cellule de valeur concernée sur `null` pour conserver la position de catégorie du point comme point vide. Utilisez [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/clear/) uniquement lorsque vous avez l’intention de supprimer tous les points de cette série. Si vous supprimez également des catégories, mettez à jour chaque série afin que leurs valeurs restent alignées avec la collection de catégories.

**Comment les points vides sont‑ils affichés ?**

Le résultat dépend du type de graphique et de la valeur configurée via [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/). Les graphiques pris en charge peuvent afficher les blancs comme des espaces, comme des valeurs zéro, ou en connectant les points voisins. Choisissez le paramètre qui correspond à la signification des données manquantes dans votre présentation. Consultez [Contrôler l’affichage des cellules vides](#control-the-display-of-empty-cells) pour un exemple complet et une comparaison visuelle.

**Comment les valeurs négatives sont‑elles formatées ?**

Pour les séries à barres, colonnes et bulles prises en charge, appelez [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setinvertifnegative/) et définissez la couleur retournée par [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getinvertedsolidfillcolor/). Vous pouvez remplacer le comportement pour un point individuel avec [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/setinvertifnegative/). Ces méthodes affectent le formatage, pas les valeurs numériques stockées.

**Quel formatage l’emporte lorsque la série et le point sont tous deux formatés ?**

Le formatage explicite du point de données l’emporte pour ce point. Les autres points continuent d’utiliser le format de série explicite ou, lorsque le format de série n’est pas défini, le style et le thème automatiques du graphique. Les paramètres de groupe tels que le chevauchement et la largeur de l’écart contrôlent la disposition et ne sont pas des remplacements de formatage au niveau du point.

**Existe‑t‑il une limite au nombre de séries qu’un graphique peut contenir ?**

Aspose.Slides n’impose pas de limite fixe distincte pour le nombre de séries. En pratique, les contraintes du fichier de présentation, la mémoire disponible, le temps de rendu et la lisibilité du graphique déterminent une limite pratique.

**Que faut‑il modifier lorsque les colonnes sont trop proches ou trop éloignées ?**

Appelez [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) sur le groupe de séries parent approprié. Augmentez la valeur pour élargir l’espace entre les groupes, ou diminuez‑la pour rapprocher les groupes.