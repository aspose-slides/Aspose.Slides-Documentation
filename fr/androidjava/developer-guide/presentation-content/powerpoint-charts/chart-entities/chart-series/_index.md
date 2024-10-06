---
title: Séries de Graphiques
type: docs
url: /androidjava/chart-series/
keywords: "Séries de graphiques, couleur de série, présentation PowerPoint, Java, Aspose.Slides pour Android via Java"
description: "Séries de graphiques dans des présentations PowerPoint en Java"
---

Une série est une ligne ou une colonne de nombres tracés dans un graphique.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Définir le Chevauchement des Séries de Graphiques**

Avec la propriété [IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap), vous pouvez spécifier dans quelle mesure les barres et les colonnes doivent se chevaucher sur un graphique 2D (plage : -100 à 100). Cette propriété s'applique à toutes les séries du groupe de séries parent : il s'agit d'une projection de la propriété de groupe appropriée. Par conséquent, cette propriété est en lecture seule.

Utilisez la propriété en lecture/écriture `ParentSeriesGroup.Overlap` pour définir votre valeur préférée pour `Overlap`.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Ajoutez un graphique à colonnes groupées sur une diapositive.
1. Accédez à la première série de graphiques.
1. Accédez au `ParentSeriesGroup` de la série de graphiques et définissez votre valeur de chevauchement préférée pour la série.
1. Écrivez la présentation modifiée dans un fichier PPTX.

Ce code Java vous montre comment définir le chevauchement pour une série de graphiques :

```java
Presentation pres = new Presentation();
try {
    // Ajoute un graphique
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0)
    {
        // Définit le chevauchement de la série
        series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);
    }

    // Écrit le fichier de présentation sur le disque
    pres.save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Changer la Couleur de la Série**
Aspose.Slides pour Android via Java vous permet de changer la couleur d'une série de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Ajoutez un graphique sur la diapositive.
1. Accédez à la série dont vous souhaitez changer la couleur.
1. Définissez votre type de remplissage et votre couleur de remplissage préférés.
1. Enregistrez la présentation modifiée.

Ce code Java vous montre comment changer la couleur d'une série :

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

## **Changer la Couleur de la Catégorie de la Série**
Aspose.Slides pour Android via Java vous permet de changer la couleur d'une catégorie de série de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Ajoutez un graphique sur la diapositive.
1. Accédez à la catégorie de la série dont vous souhaitez changer la couleur.
1. Définissez votre type de remplissage et votre couleur de remplissage préférés.
1. Enregistrez la présentation modifiée.

Ce code en Java vous montre comment changer la couleur d'une catégorie de série :

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

## **Changer le Nom de la Série**

Par défaut, les noms de légende pour un graphique sont les contenus des cellules au-dessus de chaque colonne ou ligne de données.

Dans notre exemple (image d'échantillon),

* les colonnes sont *Série 1, Série 2,* et *Série 3* ;
* les lignes sont *Catégorie 1, Catégorie 2, Catégorie 3,* et *Catégorie 4.*

Aspose.Slides pour Android via Java vous permet de mettre à jour ou de changer le nom d'une série dans ses données de graphique et sa légende.

Ce code Java vous montre comment changer le nom d'une série dans ses données de graphique `ChartDataWorkbook` :

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);

    IChartDataCell seriesCell = chart.getChartData().getChartDataWorkbook().getCell(0, 0, 1);
    seriesCell.setValue("Nouveau nom");

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Ce code Java vous montre comment changer le nom d'une série dans sa légende via `Series` :

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    IStringChartValue name = series.getName();
    name.getAsCells().get_Item(0).setValue("Nouveau nom");
} finally {
    if (pres != null) pres.dispose();
}
```

## **Définir la Couleur de Remplissage des Séries de Graphiques**

Aspose.Slides pour Android via Java vous permet de définir la couleur de remplissage automatique pour les séries de graphiques à l'intérieur d'une zone de tracé comme suit :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez un graphique avec des données par défaut basées sur votre type préféré (dans l'exemple ci-dessous, nous avons utilisé `ChartType.ClusteredColumn`).
1. Accédez aux séries de graphiques et définissez la couleur de remplissage sur Automatique.
1. Enregistrez la présentation dans un fichier PPTX.

Ce code Java vous montre comment définir la couleur de remplissage automatique pour une série de graphiques :

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

    // Écrit le fichier de présentation sur le disque
    pres.save("AutoFillSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Définir les Couleurs de Remplissage Inversées des Séries de Graphiques**
Aspose.Slides vous permet de définir la couleur de remplissage inversée pour les séries de graphiques à l'intérieur d'une zone de tracé de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez un graphique avec des données par défaut basées sur votre type préféré (dans l'exemple ci-dessous, nous avons utilisé `ChartType.ClusteredColumn`).
1. Accédez aux séries de graphiques et définissez la couleur de remplissage sur inversée.
1. Enregistrez la présentation dans un fichier PPTX.

Ce code Java démontre l'opération :

```java
Color inverColor = Color.RED;
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    IChartDataWorkbook workBook = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Ajoute de nouvelles séries et catégories
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Série 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Catégorie 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Catégorie 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Catégorie 3"));

    // Prend la première série de graphiques et remplit ses données.
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

## **Définir les Séries pour Inverser Lorsqu'une Valeur est Négative**
Aspose.Slides vous permet de définir les inversions via les propriétés `IChartDataPoint.InvertIfNegative` et `ChartDataPoint.InvertIfNegative`. Lorsqu'une inversion est définie à l'aide des propriétés, le point de données inverse ses couleurs lorsqu'il reçoit une valeur négative.

Ce code Java démontre l'opération :

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

## **Effacer les Données de Points de Données Spécifiques**
Aspose.Slides pour Android via Java vous permet d'effacer les données `DataPoints` pour une série de graphiques spécifique de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtenez la référence d'une diapositive par son index.
3. Obtenez la référence d'un graphique par son index.
4. Parcourez tous les `DataPoints` de graphiques et définissez `XValue` et `YValue` sur null.
5. Effacez tous les `DataPoints` pour une série de graphiques spécifique.
6. Écrivez la présentation modifiée dans un fichier PPTX.

Ce code Java démontre l'opération :

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

## **Définir la Largeur de Gap de la Série**
Aspose.Slides pour Android via Java vous permet de définir la largeur de gap d'une série à travers la propriété **`GapWidth`** de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Accédez à la première diapositive.
1. Ajoutez un graphique avec des données par défaut.
1. Accédez à n'importe quelle série de graphiques.
1. Définissez la propriété `GapWidth`.
1. Écrivez la présentation modifiée dans un fichier PPTX.

Ce code en Java vous montre comment définir la largeur de gap d'une série :

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
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Série 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Série 2"), chart.getType());
    
    // Ajoute des catégories
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Catégorie 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Catégorie 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Catégorie 3"));
    
    // Prend la deuxième série de graphiques
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