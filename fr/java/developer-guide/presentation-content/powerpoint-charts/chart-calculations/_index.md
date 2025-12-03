---
title: Optimiser les calculs de graphiques pour les présentations en Java
linktitle: Calculs de graphiques
type: docs
weight: 50
url: /fr/java/chart-calculations/
keywords:
- calculs de graphiques
- éléments de graphique
- position de l'élément
- position réelle
- élément enfant
- élément parent
- valeurs du graphique
- valeur réelle
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Comprenez les calculs de graphiques, les mises à jour des données et le contrôle de la précision dans Aspose.Slides for Java pour PPT et PPTX, avec des exemples de code Java pratiques."
---

## **Calculer les valeurs réelles des éléments du graphique**
Aspose.Slides for Java fournit une API simple pour obtenir ces propriétés. Les propriétés de l'interface [IAxis](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis) fournissent des informations sur la position réelle de l'élément d'axe du graphique ([IAxis.getActualMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis#getActualMaxValue--), [IAxis.getActualMinValue](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis#getActualMinValue--), [IAxis.getActualMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis#getActualMajorUnit--), [IAxis.getActualMinorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis#getActualMinorUnit--), [IAxis.getActualMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis#getActualMajorUnitScale--), [IAxis.getActualMinorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis#getActualMinorUnitScale--)). Il est nécessaire d'appeler la méthode [IChart.validateChartLayout()](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#validateChartLayout--) au préalable pour remplir les propriétés avec les valeurs réelles.
```java
Presentation pres = new Presentation();
try {
    Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    
    double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    
    double majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    double minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
} finally {
    if (pres != null) pres.dispose();
}
```


## **Calculer la position réelle des éléments parents du graphique**
Aspose.Slides for Java fournit une API simple pour obtenir ces propriétés. Les propriétés de l'interface [IActualLayout](https://reference.aspose.com/slides/java/com.aspose.slides/IActualLayout) fournissent des informations sur la position réelle de l'élément parent du graphique ([IActualLayout.getActualX](https://reference.aspose.com/slides/java/com.aspose.slides/IActualLayout#getActualX--), [IActualLayout.getActualY](https://reference.aspose.com/slides/java/com.aspose.slides/IActualLayout#getActualY--), [IActualLayout.getActualWidth](https://reference.aspose.com/slides/java/com.aspose.slides/IActualLayout#getActualWidth--), [IActualLayout.getActualHeight](https://reference.aspose.com/slides/java/com.aspose.slides/IActualLayout#getActualHeight--)). Il est nécessaire d'appeler la méthode [IChart.validateChartLayout()](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#validateChartLayout--) au préalable pour remplir les propriétés avec les valeurs réelles.
```java
Presentation pres = new Presentation();
try {
    Chart chart = (Chart) pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();

    double x = chart.getPlotArea().getActualX();
    double y = chart.getPlotArea().getActualY();
    double w = chart.getPlotArea().getActualWidth();
    double h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) pres.dispose();
}
```


## **Masquer les informations du graphique**
Ce sujet vous aide à comprendre comment masquer les informations du graphique. Avec Aspose.Slides for Java, vous pouvez masquer le **Titre, l'Axe vertical, l'Axe horizontal** et les **Lignes de grille** du graphique. L'exemple de code ci-dessous montre comment utiliser ces propriétés.
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //Masquage du titre du graphique
    chart.setTitle(false);

    ///Masquage de l'axe des valeurs
    chart.getAxes().getVerticalAxis().setVisible(false);

    //Visibilité de l'axe des catégories
    chart.getAxes().getHorizontalAxis().setVisible(false);

    //Masquage de la légende
    chart.setLegend(false);

    //Masquage des lignes de grille majeures
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    for (int i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        chart.getChartData().getSeries().removeAt(i);
    }

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    series.getMarker().setSymbol(MarkerStyleType.Circle);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.Top);
    series.getMarker().setSize(15);

    //Définition de la couleur de ligne de la série
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid);

    pres.save("HideInformationFromChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Les classeurs Excel externes peuvent-ils être utilisés comme source de données, et comment cela affecte-t-il le recalcul ?**

Oui. Un graphique peut référencer un classeur externe : lorsque vous vous connectez ou actualisez la source externe, les formules et les valeurs sont extraites de ce classeur, et le graphique reflète les mises à jour lors des opérations d'ouverture ou de modification. L'API vous permet de [spécifier le classeur externe](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-) et de gérer les données liées.

**Puis-je calculer et afficher des lignes de tendance sans implémenter moi‑même la régression ?**

Oui. Les [lignes de tendance](/slides/fr/java/trend-line/) (linéaires, exponentielles et autres) sont ajoutées et mises à jour par Aspose.Slides ; leurs paramètres sont recalculés automatiquement à partir des données de la série, vous n'avez donc pas besoin d'implémenter vos propres calculs.

**Si une présentation contient plusieurs graphiques avec des liens externes, puis‑je contrôler quel classeur chaque graphique utilise pour les valeurs calculées ?**

Oui. Chaque graphique peut pointer vers son propre [classeur externe](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-), ou vous pouvez créer/remplacer un classeur externe par graphique indépendamment des autres.