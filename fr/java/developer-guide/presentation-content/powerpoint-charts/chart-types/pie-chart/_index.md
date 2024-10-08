---
title: Graphique en secteurs
type: docs
url: /fr/java/pie-chart/
---

## **Options de deuxième graphique pour le graphique en secteurs de secteurs et le graphique en secteurs à barres**
Aspose.Slides pour Java prend désormais en charge les options de deuxième graphique pour le graphique en secteurs de secteurs ou le graphique en secteurs à barres. Dans ce sujet, nous vous montrerons comment spécifier ces options en utilisant Aspose.Slides. Pour spécifier les propriétés, procédez comme suit :

1. Instancier l'objet de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Ajouter le graphique sur la diapositive.
1. Spécifier les options de deuxième graphique du graphique.
1. Écrire la présentation sur le disque.

Dans l'exemple donné ci-dessous, nous avons défini différentes propriétés du graphique en secteurs de secteurs.

```java
// Create an instance of Presentation class
Presentation pres = new Presentation();
try {
    // Add chart on slide
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    
    // Set different properties
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    
    // Write presentation to disk
    pres.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Définir les couleurs de segment de graphique en secteurs automatiques**
Aspose.Slides pour Java fournit une API simple pour définir les couleurs de segment de graphique en secteurs automatiques. Le code d'exemple applique la définition des propriétés mentionnées ci-dessus.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Accéder à la première diapositive.
1. Ajouter un graphique avec des données par défaut.
1. Définir le titre du graphique.
1. Définir la première série pour afficher les valeurs.
1. Définir l'index de la feuille de données du graphique.
1. Obtenir la feuille de calcul des données du graphique.
1. Supprimer les séries et catégories générées par défaut.
1. Ajouter de nouvelles catégories.
1. Ajouter de nouvelles séries.

Écrire la présentation modifiée dans un fichier PPTX.

```java
// Create an instance of Presentation class
Presentation pres = new Presentation();
try {
    // Add chart with default data
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // Setting chart Title
    chart.getChartTitle().addTextFrameForOverriding("Titre d'exemple");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Set first series to Show Values
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    // Setting the index of chart data sheet
    int defaultWorksheetIndex = 0;

    // Getting the chart data worksheet
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Delete default generated series and categories
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Adding new categories
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "Premier trimestre"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "Deuxième trimestre"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "Troisième trimestre"));

    // Adding new series
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Série 1"), chart.getType());

    // Now populating series data
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));

    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```