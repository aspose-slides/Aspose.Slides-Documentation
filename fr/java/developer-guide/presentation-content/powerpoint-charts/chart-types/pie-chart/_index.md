---
title: Personnaliser les graphiques circulaires dans les présentations avec Java
linktitle: Graphique circulaire
type: docs
url: /fr/java/pie-chart/
keywords:
- graphique circulaire
- gérer le graphique
- personnaliser le graphique
- options du graphique
- paramètres du graphique
- options de tracé
- couleur de tranche
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Apprenez à créer et personnaliser des graphiques circulaires en Java avec Aspose.Slides, exportables vers PowerPoint, boostant votre narration de données en quelques secondes."
---

## **Options du deuxième tracé pour les graphiques Pie of Pie et Bar of Pie**
Aspose.Slides for Java prend désormais en charge les options de deuxième tracé pour les graphiques Pie of Pie ou Bar of Pie. Dans ce sujet, nous vous montrerons comment spécifier ces options à l'aide d'Aspose.Slides. Pour spécifier les propriétés, procédez ainsi :

1. Instanciez l'objet de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Ajoutez un graphique sur la diapositive.
1. Spécifiez les options du deuxième tracé du graphique.
1. Enregistrez la présentation sur le disque.

Dans l'exemple ci‑dessous, nous avons défini différentes propriétés du graphique Pie of Pie.
```java
// Créez une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    // Ajoutez un graphique sur la diapositive
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    
    // Définissez différentes propriétés
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    
    // Enregistrez la présentation sur le disque
    pres.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Définir les couleurs automatiques des tranches du graphique circulaire**
Aspose.Slides for Java fournit une API simple pour définir les couleurs automatiques des tranches d'un graphique circulaire. Le code d'exemple applique la configuration des propriétés susmentionnées.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Accédez à la première diapositive.
1. Ajoutez un graphique avec les données par défaut.
1. Définissez le titre du graphique.
1. Configurez la première série pour afficher les valeurs.
1. Définissez l'index de la feuille de données du graphique.
1. Obtenez la feuille de calcul des données du graphique.
1. Supprimez les séries et catégories générées par défaut.
1. Ajoutez de nouvelles catégories.
1. Ajoutez de nouvelles séries.

Enregistrez la présentation modifiée dans un fichier PPTX.
```java
// Créez une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    // Ajoutez un graphique avec les données par défaut
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // Définir le titre du graphique
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Définir la première série pour afficher les valeurs
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    // Définir l'index de la feuille de données du graphique
    int defaultWorksheetIndex = 0;

    // Obtenir la feuille de calcul des données du graphique
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Supprimer les séries et catégories générées par défaut
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Ajouter de nouvelles catégories
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));

    // Ajouter une nouvelle série
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());

    // Remplissage des données de la série
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));

    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Les variantes 'Pie of Pie' et 'Bar of Pie' sont‑elles prises en charge ?**

Oui, la bibliothèque [prend en charge](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) un tracé secondaire pour les graphiques circulaires, y compris les types 'Pie of Pie' et 'Bar of Pie'.

**Puis‑je exporter uniquement le graphique sous forme d'image (par exemple, PNG) ?**

Oui, vous pouvez [exporter le graphique lui‑même sous forme d'image](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage-int-float-float-) (tel que PNG) sans toute la présentation.