---
title: Gérer les séries de données de graphique dans les présentations avec Java
linktitle: Séries de données
type: docs
url: /fr/java/chart-series/
keywords:
- séries de graphique
- chevauchement de séries
- couleur de série
- couleur de catégorie
- nom de série
- point de données
- écart de série
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Apprenez à gérer les séries de graphiques en Java pour PowerPoint (PPT/PPTX) grâce à des exemples de code pratiques et aux meilleures pratiques pour améliorer vos présentations de données."
---

Une série est une ligne ou une colonne de nombres tracée dans un graphique.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Définir le chevauchement des séries du graphique**

Avec la propriété [IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap) vous pouvez spécifier le degré de chevauchement des barres et des colonnes sur un graphique 2D (plage : -100 à 100). Cette propriété s’applique à toutes les séries du groupe de séries parent : il s’agit d’une projection de la propriété du groupe correspondant. Par conséquent, cette propriété est en lecture seule.

Utilisez la propriété en lecture/écriture `ParentSeriesGroup.Overlap` pour définir la valeur souhaitée pour `Overlap`.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Ajoutez un graphique à colonnes groupées sur une diapositive.
1. Accédez à la première série du graphique.
1. Accédez à `ParentSeriesGroup` de la série et définissez la valeur de chevauchement souhaitée pour la série. 
1. Enregistrez la présentation modifiée dans un fichier PPTX.

Ce code Java montre comment définir le chevauchement d'une série de graphique :
```java
Presentation pres = new Presentation();
try {
    // Ajoute le graphique
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0)
    {
        // Définit le chevauchement des séries
        series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);
    }

    // Enregistre le fichier de présentation sur le disque
    pres.save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Modifier la couleur de la série**

Aspose.Slides for Java vous permet de modifier la couleur d’une série de la façon suivante :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Ajoutez un graphique sur la diapositive.
1. Accédez à la série dont vous souhaitez changer la couleur. 
1. Définissez le type de remplissage et la couleur de remplissage souhaités.
1. Enregistrez la présentation modifiée.

Ce code Java montre comment changer la couleur d’une série :
```java
Presentation pres = new Presentation("test.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 600, 400);
    IChartDataPoint point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(1);

    point.setExplosion(30);
    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Modifier la couleur de la catégorie de série**

Aspose.Slides for Java vous permet de modifier la couleur d’une catégorie de série de la façon suivante :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Ajoutez un graphique sur la diapositive.
1. Accédez à la catégorie de série dont vous souhaitez changer la couleur.
1. Définissez le type de remplissage et la couleur de remplissage souhaités.
1. Enregistrez la présentation modifiée.

Ce code Java montre comment modifier la couleur d’une catégorie de série :
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    IChartDataPoint point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(0);

    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Modifier le nom de la série** 

Par défaut, les noms de légende d’un graphique proviennent du contenu des cellules situées au-dessus de chaque colonne ou ligne de données. 

Dans notre exemple (image d’illustration),

* les colonnes sont *Series 1, Series 2,* et *Series 3* ;
* les lignes sont *Category 1, Category 2, Category 3,* et *Category 4.* 

Aspose.Slides for Java vous permet de mettre à jour ou de changer le nom d’une série dans les données du graphique et dans la légende. 

Ce code Java montre comment changer le nom d’une série dans ses données de graphique `ChartDataWorkbook` :
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);

    IChartDataCell seriesCell = chart.getChartData().getChartDataWorkbook().getCell(0, 0, 1);
    seriesCell.setValue("New name");

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


Ce code Java montre comment changer le nom d’une série dans sa légende via`Series` :
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    IStringChartValue name = series.getName();
    name.getAsCells().get_Item(0).setValue("New name");
} finally {
    if (pres != null) pres.dispose();
}
```


## **Définir la couleur de remplissage de la série du graphique**

Aspose.Slides for Java vous permet de définir la couleur de remplissage automatique des séries de graphique à l’intérieur d’une zone de tracé de la façon suivante :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Obtenez la référence d’une diapositive par son indice.
1. Ajoutez un graphique avec des données par défaut selon le type souhaité (dans l’exemple ci‑dessous, nous avons utilisé `ChartType.ClusteredColumn`).
1. Accédez aux séries du graphique et définissez la couleur de remplissage sur Automatic.
1. Enregistrez la présentation dans un fichier PPTX.

Ce code Java montre comment définir la couleur de remplissage automatique d’une série de graphique :
```java
Presentation pres = new Presentation();
try {
    // Crée un graphique à colonnes groupées
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    // Définit le format de remplissage des séries sur automatique
    for (int i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }

    // Enregistre le fichier de présentation sur le disque
    pres.save("AutoFillSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Définir la couleur de remplissage inversée pour une série de graphique**

Aspose.Slides vous permet de définir la couleur de remplissage inversée des séries de graphique à l’intérieur d’une zone de tracé de la façon suivante :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Obtenez la référence d’une diapositive par son indice.
1. Ajoutez un graphique avec des données par défaut selon le type souhaité (dans l’exemple ci‑dessous, nous avons utilisé `ChartType.ClusteredColumn`).
1. Accédez aux séries du graphique et définissez la couleur de remplissage sur invert.
1. Enregistrez la présentation dans un fichier PPTX.

Ce code Java démontre l’opération :
```java
Color inverColor = Color.RED;
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    IChartDataWorkbook workBook = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Ajoute de nouvelles séries et catégories
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));

    // Prend la première série du graphique et remplit ses données
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 1, 1, -20));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 3, 1, -30));
    Color seriesColor = series.getAutomaticSeriesColor();
    series.setInvertIfNegative(true);
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(seriesColor);
    series.getInvertedSolidFillColor().setColor(inverColor);
    
    pres.save("SetInvertFillColorChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Définir une série pour inverser lorsque la valeur est négative**

Aspose.Slides vous permet de définir l’inversion via les propriétés `IChartDataPoint.InvertIfNegative` et `ChartDataPoint.InvertIfNegative`. Lorsque l’inversion est définie à l’aide de ces propriétés, le point de données inverse ses couleurs lorsqu’il reçoit une valeur négative. 

Ce code Java démontre l’opération :
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    chart.getChartData().getSeries().clear();

    IChartSeries chartSeries = series.add(chart.getChartData().getChartDataWorkbook().getCell(0, "B1"), chart.getType());
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B2", -5));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B3", 3));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B4", -2));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B5", 1));

    chartSeries.setInvertIfNegative(false);

    chartSeries.getDataPoints().get_Item(2).setInvertIfNegative(true);

    pres.save("out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Effacer les données de points spécifiques**

Aspose.Slides for Java vous permet d’effacer les données `DataPoints` d’une série de graphique spécifique de la façon suivante :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtenez la référence d’une diapositive par son indice.
3. Obtenez la référence d’un graphique par son indice.
4. Parcourez tous les `DataPoints` du graphique et définissez `XValue` et `YValue` sur null.
5. Effacez tous les `DataPoints` de la série de graphique spécifiée.
6. Enregistrez la présentation modifiée dans un fichier PPTX.

Ce code Java démontre l’opération :
```java
Presentation pres = new Presentation("TestChart.pptx");
try {
    ISlide sl = pres.getSlides().get_Item(0);

    IChart chart = (IChart)sl.getShapes().get_Item(0);

    for (IChartDataPoint dataPoint : chart.getChartData().getSeries().get_Item(0).getDataPoints())
    {
        dataPoint.getXValue().getAsCell().setValue(null);
        dataPoint.getYValue().getAsCell().setValue(null);
    }

    chart.getChartData().getSeries().get_Item(0).getDataPoints().clear();

    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Définir la largeur d’écartement de la série**

Aspose.Slides for Java vous permet de définir la largeur d’écartement d’une série via la propriété **`GapWidth`** de la façon suivante :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Accédez à la première diapositive.
1. Ajoutez un graphique avec des données par défaut.
1. Accédez à n’importe quelle série du graphique.
1. Définissez la propriété `GapWidth`.
1. Enregistrez la présentation modifiée dans un fichier PPTX.

Ce code Java montre comment définir la largeur d’écartement d’une série :
```java
// Crée une présentation vide 
Presentation pres = new Presentation();
try {
    // Accède à la première diapositive de la présentation
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Ajoute un graphique avec des données par défaut
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 0, 0, 500, 500);
    
    // Définit l'indice de la feuille de données du graphique
    int defaultWorksheetIndex = 0;
    
    // Obtient la feuille de calcul des données du graphique
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Ajoute des séries
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // Ajoute des catégories
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Prenez la deuxième série du graphique
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // Remplit les données de la série
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Définit la valeur de GapWidth
    series.getParentSeriesGroup().setGapWidth(50);
    
    // Enregistre la présentation sur le disque
    pres.save("GapWidth_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Existe-t-il une limite au nombre de séries qu'un seul graphique peut contenir ?**

Aspose.Slides n’impose aucune limite fixe au nombre de séries que vous ajoutez. La contrainte pratique dépend de la lisibilité du graphique et de la mémoire disponible pour votre application.

**Que faire si les colonnes d'un groupe sont trop proches ou trop éloignées ?**

Ajustez le paramètre `GapWidth` pour cette série (ou son groupe de séries parent). Augmenter la valeur élargit l’espace entre les colonnes, tandis que la diminuer les rapproche.