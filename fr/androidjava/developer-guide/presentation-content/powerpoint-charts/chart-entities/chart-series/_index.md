---
title: Gérer les séries de données de graphiques dans les présentations sur Android
linktitle: Séries de données
type: docs
url: /fr/androidjava/chart-series/
keywords:
- séries de graphiques
- chevauchement des séries
- couleur des séries
- couleur de catégorie
- nom de la série
- point de données
- écart de série
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Apprenez à gérer les séries de graphiques sur Android pour PowerPoint (PPT/PPTX) avec des exemples de code Java pratiques et les meilleures pratiques pour améliorer vos présentations de données."
---

Une série est une ligne ou une colonne de nombres tracée dans un graphique.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Définir le chevauchement de la série du graphique**

Avec la méthode [IChartSeries.getOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getOverlap--), vous pouvez déterminer le degré de chevauchement des barres et des colonnes sur un graphique 2D (plage: -100 à 100). Cette propriété s'applique à toutes les séries du groupe de séries parent: il s'agit d'une projection de la propriete de groupe appropriee. Par consequent, cette propriete est en lecture seule.

Utilisez la methode d'ecriture `getParentSeriesGroup().setOverlap()` pour definir la valeur de chevauchement souhaitee.

1. Creer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Ajouter un graphique a colonnes groupees sur une diapositive.
1. Acceder a la premiere serie du graphique.
1. Acceder au `ParentSeriesGroup` de la serie du graphique et definir la valeur de chevauchement souhaitee pour la serie.
1. Enregistrer la presentation modifiee dans un fichier PPTX.

Ce code Java vous montre comment definir le chevauchement pour une serie de graphique:
```java
Presentation pres = new Presentation();
try {
    // Ajoute le graphique
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0)
    {
        // Définit le chevauchement de la série
        series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);
    }

    // Enregistre le fichier de présentation sur le disque
    pres.save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Modifier la couleur de la serie**

Aspose.Slides for Android via Java vous permet de modifier la couleur d'une serie de cette façon:

1. Creer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Ajouter un graphique sur la diapositive.
1. Acceder a la serie dont vous souhaitez modifier la couleur.
1. Definir le type de remplissage et la couleur de remplissage souhaites.
1. Enregistrer la presentation modifiee.

Ce code Java vous montre comment modifier la couleur d'une serie:
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


## **Modifier la couleur de la categorie de serie**

Aspose.Slides for Android via Java vous permet de modifier la couleur d'une categorie de serie de cette façon:

1. Creer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Ajouter un graphique sur la diapositive.
1. Acceder à la categorie de serie dont vous souhaitez modifier la couleur.
1. Definir le type de remplissage et la couleur de remplissage souhaites.
1. Enregistrer la presentation modifiee.

Ce code en Java vous montre comment modifier la couleur d'une categorie de serie:
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


## **Modifier le nom de la serie**

Par defaut, les noms de legende d'un graphique sont le contenu des cellules situees au-dessus de chaque colonne ou ligne de donnees.

Dans notre exemple (image d'exemple),

* les colonnes sont *Series 1, Series 2,* et *Series 3*;
* les lignes sont *Category 1, Category 2, Category 3,* et *Category 4.* 

Aspose.Slides for Android via Java vous permet de mettre a jour ou de modifier le nom d'une serie dans les donnees du graphique et dans la legende.

Ce code Java vous montre comment modifier le nom d'une serie dans les donnees du graphique `ChartDataWorkbook`:
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


Ce code Java vous montre comment modifier le nom d'une serie dans sa legende via `Series`:
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


## **Definir la couleur de remplissage de la serie du graphique**

Aspose.Slides for Android via Java vous permet de definir la couleur de remplissage automatique pour les series d'un graphique dans une zone de trace de cette façon:

1. Creer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Obtenir la reference d'une diapositive a l'aide de son index.
1. Ajouter un graphique avec des donnees par defaut en fonction du type souhaite (dans l'exemple ci-dessous, nous avons utilise `ChartType.ClusteredColumn`).
1. Acceder a la serie du graphique et definir la couleur de remplissage sur Automatic.
1. Enregistrer la presentation dans un fichier PPTX.

Ce code Java vous montre comment definir la couleur de remplissage automatique pour une serie de graphique:
```java
Presentation pres = new Presentation();
try {
    // Crée un graphique à colonnes groupées
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    // Définit le format de remplissage de la série sur automatique
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


## **Definir la couleur de remplissage inversee pour une serie de graphique**

Aspose.Slides vous permet de definir la couleur de remplissage inversee pour les series d'un graphique dans une zone de trace de cette façon:

1. Creer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Obtenir la reference d'une diapositive a l'aide de son index.
1. Ajouter un graphique avec des donnees par defaut en fonction du type souhaite (dans l'exemple ci-dessous, nous avons utilise `ChartType.ClusteredColumn`).
1. Acceder a la serie du graphique et definir la couleur de remplissage sur invert.
1. Enregistrer la presentation dans un fichier PPTX.

Ce code Java illustre l'operation:
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


## **Faire inverser une serie lorsque la valeur est negative**

Aspose.Slides vous permet de definir les inversions via les proprietes `IChartDataPoint.InvertIfNegative` et `ChartDataPoint.InvertIfNegative`. Lorsqu'une inversion est definie a l'aide de ces proprietes, le point de donnees inverse ses couleurs lorsqu'il reçoit une valeur negative.

Ce code Java illustre l'operation:
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


## **Effacer les donnees d'un point specifique**

Aspose.Slides for Android via Java vous permet d'effacer les donnees `DataPoints` d'une serie de graphique specifique de cette façon:

1. Creer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtenir la reference d'une diapositive via son index.
3. Obtenir la reference d'un graphique via son index.
4. Parcourir tous les `DataPoints` du graphique et definir `XValue` et `YValue` a null.
5. Effacer tous les `DataPoints` pour la serie de graphique specifiee.
6. Enregistrer la presentation modifiee dans un fichier PPTX.

Ce code Java illustre l'operation:
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


## **Definir la largeur de l'ecart de la serie**

Aspose.Slides for Android via Java vous permet de definir la largeur d'ecart d'une serie via la propriete **`GapWidth`** de cette façon:

1. Creer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Acceder a la premiere diapositive.
1. Ajouter un graphique avec des donnees par defaut.
1. Acceder a n'importe quelle serie du graphique.
1. Definir la propriete `GapWidth`.
1. Enregistrer la presentation modifiee dans un fichier PPTX.

Ce code en Java vous montre comment definir la largeur d'ecart d'une serie:
```java
// Crée une présentation vide 
Presentation pres = new Presentation();
try {
    // Accède à la première diapositive de la présentation
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Ajoute un graphique avec des données par défaut
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 0, 0, 500, 500);
    
    // Définit l'index de la feuille de données du graphique
    int defaultWorksheetIndex = 0;
    
    // Obtient la feuille de données du graphique
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Ajoute des séries
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // Ajoute des catégories
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Prend la deuxième série du graphique
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

**Existe-t-il une limite au nombre de series qu'un graphique unique peut contenir?**

Aspose.Slides n'impose aucune limite fixe au nombre de series que vous ajoutez. La contrainte pratique est determinee par la lisibilite du graphique et par la memoire disponible pour votre application.

**Que faire si les colonnes d'un groupe sont trop proches ou trop eloignees?**

Ajustez le parametre `GapWidth` pour cette serie (ou son groupe de series parent). Augmenter la valeur elargit l'espace entre les colonnes, tandis que la diminuer les rapproche.