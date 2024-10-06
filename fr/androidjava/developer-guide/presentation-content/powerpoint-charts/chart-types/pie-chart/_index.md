---
title: Diagramme en secteurs
type: docs
url: /androidjava/pie-chart/
---

## **Options de deuxième tracé pour les diagrammes en secteurs et en barres de secteurs**
Aspose.Slides pour Android via Java prend désormais en charge les options de deuxième tracé pour les diagrammes en secteurs ou en barres de secteurs. Dans ce sujet, nous allons vous montrer comment spécifier ces options en utilisant Aspose.Slides. Pour spécifier les propriétés, procédez comme suit :

1. Instancier un objet de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Ajouter un diagramme sur la diapositive.
1. Spécifier les options de deuxième tracé du diagramme.
1. Écrire la présentation sur le disque.

Dans l'exemple donné ci-dessous, nous avons défini différentes propriétés du diagramme en secteurs.

```java
// Créer une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    // Ajouter un diagramme sur la diapositive
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    
    // Définir différentes propriétés
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    
    // Écrire la présentation sur le disque
    pres.save("OptionsDeDeuxiemeTrac pourDiagrammes_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Définir les couleurs des tranches de diagramme en secteurs automatiquement**
Aspose.Slides pour Android via Java fournit une API simple pour définir automatiquement les couleurs des tranches de diagramme en secteurs. Le code d'exemple applique les propriétés mentionnées ci-dessus.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Accéder à la première diapositive.
1. Ajouter un diagramme avec des données par défaut.
1. Définir le titre du diagramme.
1. Définir la première série pour afficher les valeurs.
1. Définir l'index de la feuille de données du diagramme.
1. Obtenir la feuille de calcul de données du diagramme.
1. Supprimer les séries et catégories générées par défaut.
1. Ajouter de nouvelles catégories.
1. Ajouter de nouvelles séries.

Écrire la présentation modifiée dans un fichier PPTX.

```java
// Créer une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    // Ajouter un diagramme avec des données par défaut
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // Définir le titre du diagramme
    chart.getChartTitle().addTextFrameForOverriding("Titre d'exemple");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Définir la première série pour afficher les valeurs
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    // Définir l'index de la feuille de données du diagramme
    int defaultWorksheetIndex = 0;

    // Obtenir la feuille de calcul de données du diagramme
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Supprimer les séries et catégories générées par défaut
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Ajouter de nouvelles catégories
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "Premier Trimestre"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "Deuxième Trimestre"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "Troisième Trimestre"));

    // Ajouter de nouvelles séries
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Série 1"), chart.getType());

    // Maintenant, peupler les données de la série
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));

    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```