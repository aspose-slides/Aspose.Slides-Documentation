---
title: Graphique 3D
type: docs
url: /androidjava/3d-chart/
---

## **Définir les propriétés RotationX, RotationY et DepthPercents du graphique 3D**
Aspose.Slides pour Android via Java fournit une API simple pour définir ces propriétés. Cet article suivant vous aidera à définir différentes propriétés telles que **Rotation X, Y, DepthPercents**, etc. Le code d'exemple applique les paramètres des propriétés mentionnées ci-dessus.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Accédez à la première diapositive.
1. Ajoutez un graphique avec des données par défaut.
1. Définissez les propriétés Rotation3D.
1. Écrivez la présentation modifiée dans un fichier PPTX.

```java
Presentation pres = new Presentation();
try {
    // Accédez à la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Ajoutez un graphique avec des données par défaut
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);
    
    // Définir l'index de la feuille de données du graphique
    int defaultWorksheetIndex = 0;
    
    // Obtenez la feuille de calcul de données du graphique
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Ajoutez des séries
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Série 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Série 2"), chart.getType());
    
    // Ajoutez des Catégories
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Catégorie 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Catégorie 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Catégorie 3"));
    
    // Définir les propriétés Rotation3D
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte)40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    
    // Prenez la deuxième série de graphique
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // Maintenant, remplissons les données de la série
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Définir la valeur OverLap
    series.getParentSeriesGroup().setOverlap((byte)100);
    
    // Écrire la présentation sur disque
    pres.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```