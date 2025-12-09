---
title: Séries de graphique
type: docs
url: /fr/nodejs-java/chart-series/
keywords: "Séries de graphique, couleur de série, présentation PowerPoint, Java, Aspose.Slides pour Node.js via Java"
description: "Séries de graphique dans les présentations PowerPoint en JavaScript"
---

Une série est une ligne ou une colonne de nombres tracée dans un graphique.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Définir le chevauchement des séries de graphique**

Avec la méthode [ChartSeries.getOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap), vous pouvez spécifier le degré de chevauchement des barres et des colonnes sur un graphique 2D (plage : -100 à 100). Cette propriété s’applique à toutes les séries du groupe de séries parent : il s’agit d’une projection de la propriété de groupe appropriée. Par conséquent, cette propriété est en lecture seule.

Utilisez la propriété en lecture/écriture `ParentSeriesGroup.getOverlap` pour définir la valeur souhaitée pour `Overlap`.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Ajoutez un graphique à colonnes groupées sur une diapositive.
1. Accédez à la première série du graphique.
1. Accédez au `ParentSeriesGroup` de la série et définissez la valeur de chevauchement souhaitée pour la série.
1. Enregistrez la présentation modifiée dans un fichier PPTX.

Ce code JavaScript vous montre comment définir le chevauchement d’une série de graphique :
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Ajoute le graphique
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0) {
        // Définit le chevauchement de la série
        series.get_Item(0).getParentSeriesGroup().setOverlap(-30);
    }
    // Enregistre le fichier de présentation sur le disque
    pres.save("SetChartSeriesOverlap_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Modifier la couleur de la série**

Aspose.Slides for Node.js via Java vous permet de modifier la couleur d’une série de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Ajoutez un graphique sur la diapositive.
1. Accédez à la série dont vous souhaitez changer la couleur.
1. Définissez le type de remplissage et la couleur de remplissage souhaités.
1. Enregistrez la présentation modifiée.

Ce code JavaScript vous montre comment modifier la couleur d’une série :
```javascript
var pres = new aspose.slides.Presentation("test.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 600, 400);
    var point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(1);
    point.setExplosion(30);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Modifier la couleur de la catégorie de série**

Aspose.Slides for Node.js via Java vous permet de modifier la couleur d’une catégorie de série de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Ajoutez un graphique sur la diapositive.
1. Accédez à la catégorie de série dont vous souhaitez changer la couleur.
1. Définissez le type de remplissage et la couleur de remplissage souhaités.
1. Enregistrez la présentation modifiée.

Ce code JavaScript vous montre comment modifier la couleur d’une catégorie de série :
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Modifier le nom de la série** 

Par défaut, les noms de légende d’un graphique sont le contenu des cellules situées au-dessus de chaque colonne ou ligne de données.

Dans notre exemple (image d’illustration),

* les colonnes sont *Series 1, Series 2,* et *Series 3* ;
* les lignes sont *Category 1, Category 2, Category 3,* et *Category 4*.

Aspose.Slides for Node.js via Java vous permet de mettre à jour ou de modifier le nom d’une série dans les données du graphique et la légende.

Ce code JavaScript vous montre comment modifier le nom d’une série dans les données du graphique `ChartDataWorkbook` :
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var seriesCell = chart.getChartData().getChartDataWorkbook().getCell(0, 0, 1);
    seriesCell.setValue("New name");
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Ce code JavaScript vous montre comment modifier le nom d’une série dans la légende via `Series` :
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries().get_Item(0);
    var name = series.getName();
    name.getAsCells().get_Item(0).setValue("New name");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Définir la couleur de remplissage automatique des séries de graphique**

Aspose.Slides for Node.js via Java vous permet de définir la couleur de remplissage automatique des séries de graphique à l’intérieur d’une zone de tracé de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Obtenez une référence à une diapositive par son indice.
1. Ajoutez un graphique avec des données par défaut en fonction du type souhaité (dans l’exemple ci‑dessous, nous avons utilisé `ChartType.ClusteredColumn`).
1. Accédez aux séries du graphique et définissez la couleur de remplissage sur Automatic.
1. Enregistrez la présentation dans un fichier PPTX.

Ce code JavaScript vous montre comment définir la couleur de remplissage automatique d’une série de graphique :
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Crée un graphique à colonnes groupées
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 50, 600, 400);
    // Définit le format de remplissage des séries sur automatique
    for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }
    // Enregistre le fichier de présentation sur le disque
    pres.save("AutoFillSeries_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Définir les couleurs de remplissage inversées des séries de graphique**

Aspose.Slides vous permet de définir les couleurs de remplissage inversées des séries de graphique à l’intérieur d’une zone de tracé de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Obtenez une référence à une diapositive par son indice.
1. Ajoutez un graphique avec des données par défaut en fonction du type souhaité (dans l’exemple ci‑dessous, nous avons utilisé `ChartType.ClusteredColumn`).
1. Accédez aux séries du graphique et définissez la couleur de remplissage sur invert.
1. Enregistrez la présentation dans un fichier PPTX.

Ce code JavaScript montre l’opération :
```javascript
var inverColor = java.getStaticFieldValue("java.awt.Color", "RED");
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    var workBook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // Ajoute de nouvelles séries et catégories
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));
    // Prend la première série du graphique et remplit ses données de série.
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 1, 1, -20));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 3, 1, -30));
    var seriesColor = series.getAutomaticSeriesColor();
    series.setInvertIfNegative(true);
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(seriesColor);
    series.getInvertedSolidFillColor().setColor(inverColor);
    pres.save("SetInvertFillColorChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Inverser la série lorsque la valeur est négative**

Aspose.Slides vous permet de définir les inversions via la méthode `ChartDataPoint.setInvertIfNegative`. Lorsque l’inversion est définie à l’aide de ces propriétés, le point de données inverse ses couleurs lorsqu’il reçoit une valeur négative.

Ce code JavaScript montre l’opération :
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    chart.getChartData().getSeries().clear();
    var chartSeries = series.add(chart.getChartData().getChartDataWorkbook().getCell(0, "B1"), chart.getType());
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B2", -5));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B3", 3));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B4", -2));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B5", 1));
    chartSeries.setInvertIfNegative(false);
    chartSeries.getDataPoints().get_Item(2).setInvertIfNegative(true);
    pres.save("out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Effacer les données de points de données spécifiques**

Aspose.Slides for Node.js via Java vous permet d’effacer les données des `DataPoints` d’une série de graphique spécifique de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Obtenez la référence d’une diapositive par son indice.
3. Obtenez la référence d’un graphique par son indice.
4. Parcourez tous les `DataPoints` du graphique et définissez `XValue` et `YValue` sur null.
5. Effacez tous les `DataPoints` pour la série de graphique spécifique.
6. Enregistrez la présentation modifiée dans un fichier PPTX.

Ce code JavaScript montre l’opération :
```javascript
var pres = new aspose.slides.Presentation("TestChart.pptx");
try {
    var sl = pres.getSlides().get_Item(0);
    var chart = sl.getShapes().get_Item(0);
    for (let i = 0; i < chart.getChartData().getSeries().get_Item(0).getDataPoints().size(); i++) {
        let dataPoint = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(i);
        dataPoint.getXValue().getAsCell().setValue(null);
        dataPoint.getYValue().getAsCell().setValue(null);
    }
    chart.getChartData().getSeries().get_Item(0).getDataPoints().clear();
    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Définir la largeur d’écart de la série**

Aspose.Slides for Node.js via Java vous permet de définir la largeur d’écart d’une série via la propriété **`GapWidth`** de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Accédez à la première diapositive.
1. Ajoutez un graphique avec des données par défaut.
1. Accédez à n’importe quelle série du graphique.
1. Définissez la propriété `GapWidth`.
1. Enregistrez la présentation modifiée dans un fichier PPTX.

Ce code JavaScript vous montre comment définir la largeur d’écart d’une série :
```javascript
// Crée une présentation vide
var pres = new aspose.slides.Presentation();
try {
    // Accède à la première diapositive de la présentation
    var slide = pres.getSlides().get_Item(0);
    // Ajoute un graphique avec des données par défaut
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 0, 0, 500, 500);
    // Définit l'index de la feuille de données du graphique
    var defaultWorksheetIndex = 0;
    // Obtient la feuille de calcul des données du graphique
    var fact = chart.getChartData().getChartDataWorkbook();
    // Ajoute des séries
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // Ajoute des catégories
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // Prend la deuxième série du graphique
    var series = chart.getChartData().getSeries().get_Item(1);
    // Remplit les données de la série
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // Définit la valeur GapWidth
    series.getParentSeriesGroup().setGapWidth(50);
    // Enregistre la présentation sur le disque
    pres.save("GapWidth_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Existe‑t‑il une limite au nombre de séries qu’un graphique unique peut contenir ?**

Aspose.Slides n’impose aucune limite fixe au nombre de séries que vous ajoutez. La contrainte pratique dépend de la lisibilité du graphique et de la mémoire disponible pour votre application.

**Que faire si les colonnes d’un groupe sont trop proches ou trop éloignées ?**

Ajustez le paramètre **Gap Width** pour cette série (ou son groupe de séries parent). Augmenter la valeur élargit l’espace entre les colonnes, tandis que la diminuer les rapproche.