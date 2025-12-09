---
title: Diagramme circulaire
type: docs
url: /fr/nodejs-java/pie-chart/
---

## **Options de deuxième tracé pour les graphiques 'Pie of Pie' et 'Bar of Pie'**
Aspose.Slides pour Node.js via Java prend désormais en charge les options de deuxième tracé pour les graphiques Pie of Pie ou Bar of Pie. Dans cet article, nous vous montrerons comment spécifier ces options à l'aide d'Aspose.Slides. Pour spécifier les propriétés, procédez ainsi :

1. Instancier l'objet de classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Ajouter un graphique sur la diapositive.
1. Spécifier les options de deuxième tracé du graphique.
1. Enregistrer la présentation sur le disque.

```javascript
// Créez une instance de la classe Presentation
var pres = new aspose.slides.Presentation();
try {
    // Ajoutez le graphique sur la diapositive
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 500, 400);
    // Définissez différentes propriétés
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(aspose.slides.PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    // Enregistrez la présentation sur le disque
    pres.save("SecondPlotOptionsforCharts_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Définir les couleurs automatiques des parts du graphique circulaire**
Aspose.Slides pour Node.js via Java fournit une API simple pour définir les couleurs automatiques des parts des graphiques circulaires. Le code d'exemple applique la configuration des propriétés mentionnées ci‑dessus.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Accéder à la première diapositive.
1. Ajouter un graphique avec des données par défaut.
1. Définir le titre du graphique.
1. Définir la première série pour afficher les valeurs.
1. Définir l'index de la feuille de données du graphique.
1. Obtenir la feuille de calcul des données du graphique.
1. Supprimer les séries et catégories générées par défaut.
1. Ajouter de nouvelles catégories.
1. Ajouter de nouvelles séries.

Enregistrer la présentation modifiée dans un fichier PPTX.

```javascript
// Créer une instance de la classe Presentation
var pres = new aspose.slides.Presentation();
try {
    // Ajouter un graphique avec les données par défaut
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // Définition du titre du graphique
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // Définir la première série pour afficher les valeurs
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Définir l'index de la feuille de données du graphique
    var defaultWorksheetIndex = 0;
    // Obtenir la feuille de calcul des données du graphique
    var fact = chart.getChartData().getChartDataWorkbook();
    // Supprimer les séries et catégories générées par défaut
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // Ajout de nouvelles catégories
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // Ajout d'une nouvelle série
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // Remplissage des données de la série
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Les variantes 'Pie of Pie' et 'Bar of Pie' sont‑elles prises en charge ?**

Oui, la bibliothèque [supporte](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) un tracé secondaire pour les graphiques circulaires, y compris les types 'Pie of Pie' et 'Bar of Pie'.

**Puis‑je exporter uniquement le graphique en tant qu'image (par exemple, PNG) ?**

Oui, vous pouvez [exporter le graphique lui‑même en tant qu'image](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) (comme PNG) sans la présentation complète.