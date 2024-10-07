---
title: Diagramm-Berechnungen
type: docs
weight: 50
url: /java/chart-calculations/
---

## **Berechnung der tatsächlichen Werte von Diagrammelementen**
Aspose.Slides für Java bietet eine einfache API zum Abrufen dieser Eigenschaften. Die Eigenschaften des [IAxis](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis) Interfaces liefern Informationen über die tatsächliche Position des Achsenelementes im Diagramm ([IAxis.getActualMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis#getActualMaxValue--), [IAxis.getActualMinValue](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis#getActualMinValue--), [IAxis.getActualMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis#getActualMajorUnit--), [IAxis.getActualMinorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis#getActualMinorUnit--), [IAxis.getActualMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis#getActualMajorUnitScale--), [IAxis.getActualMinorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis#getActualMinorUnitScale--)). Es ist notwendig, die Methode [IChart.validateChartLayout()](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#validateChartLayout--) vorher aufzurufen, um die Eigenschaften mit den tatsächlichen Werten zu füllen.

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

## **Berechnung der tatsächlichen Position von übergeordneten Diagrammelementen**
Aspose.Slides für Java bietet eine einfache API zum Abrufen dieser Eigenschaften. Die Eigenschaften des [IActualLayout](https://reference.aspose.com/slides/java/com.aspose.slides/IActualLayout) Interfaces liefern Informationen über die tatsächliche Position des übergeordneten Diagrammelements ([IActualLayout.getActualX](https://reference.aspose.com/slides/java/com.aspose.slides/IActualLayout#getActualX--), [IActualLayout.getActualY](https://reference.aspose.com/slides/java/com.aspose.slides/IActualLayout#getActualY--), [IActualLayout.getActualWidth](https://reference.aspose.com/slides/java/com.aspose.slides/IActualLayout#getActualWidth--), [IActualLayout.getActualHeight](https://reference.aspose.com/slides/java/com.aspose.slides/IActualLayout#getActualHeight--)). Es ist notwendig, die Methode [IChart.validateChartLayout()](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#validateChartLayout--) vorher aufzurufen, um die Eigenschaften mit den tatsächlichen Werten zu füllen.

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

## **Informationen aus dem Diagramm ausblenden**
Dieses Thema hilft Ihnen zu verstehen, wie Sie Informationen aus dem Diagramm ausblenden können. Mit Aspose.Slides für Java können Sie **Titel, Vertikale Achse, Horizontale Achse** und **Gitterlinien** aus dem Diagramm ausblenden. Das folgende Codebeispiel zeigt, wie Sie diese Eigenschaften verwenden können.

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //Titel des Diagramms ausblenden
    chart.setTitle(false);

    ///Werteachse ausblenden
    chart.getAxes().getVerticalAxis().setVisible(false);

    //Sichtbarkeit der Kategorieachse
    chart.getAxes().getHorizontalAxis().setVisible(false);

    //Legende ausblenden
    chart.setLegend(false);

    //Hauptgitterlinien ausblenden
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

    //Linienfarbe der Serie festlegen
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid);

    pres.save("HideInformationFromChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```