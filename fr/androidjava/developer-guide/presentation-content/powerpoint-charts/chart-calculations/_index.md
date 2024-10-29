---
title: Calculs de Diagrammes
type: docs
weight: 50
url: /fr/androidjava/chart-calculations/
---

## **Calculer les Valeurs Réelles des Éléments de Diagramme**
Aspose.Slides pour Android via Java fournit une API simple pour obtenir ces propriétés. Les propriétés de l'interface [IAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis) fournissent des informations sur la position réelle de l'élément de diagramme d'axe ([IAxis.getActualMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis#getActualMaxValue--), [IAxis.getActualMinValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis#getActualMinValue--), [IAxis.getActualMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis#getActualMajorUnit--), [IAxis.getActualMinorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis#getActualMinorUnit--), [IAxis.getActualMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis#getActualMajorUnitScale--), [IAxis.getActualMinorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis#getActualMinorUnitScale--)). Il est nécessaire d'appeler la méthode [IChart.validateChartLayout()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart#validateChartLayout--) au préalable pour remplir les propriétés avec des valeurs réelles.

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

## **Calculer la Position Réelle des Éléments de Diagramme Parent**
Aspose.Slides pour Android via Java fournit une API simple pour obtenir ces propriétés. Les propriétés de l'interface [IActualLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IActualLayout) fournissent des informations sur la position réelle de l'élément de diagramme parent ([IActualLayout.getActualX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IActualLayout#getActualX--), [IActualLayout.getActualY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IActualLayout#getActualY--), [IActualLayout.getActualWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IActualLayout#getActualWidth--), [IActualLayout.getActualHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IActualLayout#getActualHeight--)). Il est nécessaire d'appeler la méthode [IChart.validateChartLayout()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart#validateChartLayout--) au préalable pour remplir les propriétés avec des valeurs réelles.

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

## **Masquer des Informations du Diagramme**
Ce sujet vous aide à comprendre comment masquer des informations du diagramme. À l'aide d'Aspose.Slides pour Android via Java, vous pouvez masquer **Titre, Axe Vertical, Axe Horizontal** et **Lignes de Grille** du diagramme. L'exemple de code ci-dessous montre comment utiliser ces propriétés.

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //Masquer le Titre du diagramme
    chart.setTitle(false);

    //Masquer les valeurs de l'axe
    chart.getAxes().getVerticalAxis().setVisible(false);

    //Visibilité de l'Axe des Catégories
    chart.getAxes().getHorizontalAxis().setVisible(false);

    //Masquer la Légende
    chart.setLegend(false);

    //Masquer les Lignes de Grille Majeures
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

    //Définir la couleur de la ligne de la série
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid);

    pres.save("HideInformationFromChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```