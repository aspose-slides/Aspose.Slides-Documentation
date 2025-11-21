---
title: Calculs de graphique
type: docs
weight: 50
url: /fr/nodejs-java/chart-calculations/
---

## **Calculer les valeurs réelles des éléments du graphique**

Aspose.Slides for Node.js via Java fournit une API simple pour obtenir ces propriétés. Les propriétés de la classe [Axis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis) fournissent des informations sur la position réelle de l'élément d'axe du graphique ([Axis.getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMaxValue--), [Axis.getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMinValue--), [Axis.getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMajorUnit--), [Axis.getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMinorUnit--), [Axis.getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMajorUnitScale--), [Axis.getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMinorUnitScale--)). Il est nécessaire d'appeler la méthode [Chart.validateChartLayout()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Chart#validateChartLayout--) au préalable pour remplir les propriétés avec les valeurs réelles.
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    var majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Calculer la position réelle des éléments parents du graphique**

Aspose.Slides for Node.js via Java fournit une API simple pour obtenir ces propriétés. Les propriétés de la classe [ActualLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ActualLayout) fournissent des informations sur la position réelle de l'élément parent du graphique ([ActualLayout.getActualX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ActualLayout#getActualX--), [ActualLayout.getActualY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ActualLayout#getActualY--), [ActualLayout.getActualWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ActualLayout#getActualWidth--), [ActualLayout.getActualHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ActualLayout#getActualHeight--) ). Il est nécessaire d'appeler la méthode [Chart.validateChartLayout()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Chart#validateChartLayout--) au préalable pour remplir les propriétés avec les valeurs réelles.
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();
    var x = chart.getPlotArea().getActualX();
    var y = chart.getPlotArea().getActualY();
    var w = chart.getPlotArea().getActualWidth();
    var h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Masquer les informations du graphique**

Ce sujet vous aide à comprendre comment masquer des informations du graphique. En utilisant Aspose.Slides for Node.js via Java, vous pouvez masquer le **Titre, l'Axe vertical, l'Axe horizontal** et les **Lignes de grille** du graphique. L'exemple de code ci‑dessus montre comment utiliser ces propriétés.
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 140, 118, 320, 370);
    // Masquage du titre du graphique
    chart.setTitle(false);
    // /Masquage de l'axe des valeurs
    chart.getAxes().getVerticalAxis().setVisible(false);
    // Visibilité de l'axe des catégories
    chart.getAxes().getHorizontalAxis().setVisible(false);
    // Masquage de la légende
    chart.setLegend(false);
    // Masquage des lignes de grille principales
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
        chart.getChartData().getSeries().removeAt(i);
    }
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.Top);
    series.getMarker().setSize(15);
    // Définition de la couleur de la ligne de la série
    series.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    series.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.Solid);
    pres.save("HideInformationFromChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Les classeurs Excel externes fonctionnent-ils comme source de données, et comment cela affecte-t-il le recalcul ?**

Oui. Un graphique peut référencer un classeur externe : lorsque vous vous connectez ou actualisez la source externe, les formules et les valeurs sont prises à partir de ce classeur, et le graphique reflète les mises à jour lors des opérations d'ouverture/édition. L'API vous permet de [spécifier le classeur externe](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) chemin et de gérer les données liées.

**Puis-je calculer et afficher des lignes de tendance sans implémenter moi‑même la régression ?**

Oui. Les [Lignes de tendance](/slides/fr/nodejs-java/trend-line/) (linéaires, exponentielles, etc.) sont ajoutées et mises à jour par Aspose.Slides ; leurs paramètres sont recalculés automatiquement à partir des données de la série, vous n’avez donc pas besoin d’implémenter vos propres calculs.

**Si une présentation comporte plusieurs graphiques avec des liens externes, puis‑je contrôler quel classeur chaque graphique utilise pour les valeurs calculées ?**

Oui. Chaque graphique peut pointer vers son propre [classeur externe](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/), ou vous pouvez créer/remplacer un classeur externe par graphique indépendamment des autres.