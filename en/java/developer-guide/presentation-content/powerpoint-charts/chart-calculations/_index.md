---
title: Optimize Chart Calculations for Presentations in Java
linktitle: Chart Calculations
type: docs
weight: 50
url: /java/chart-calculations/
keywords:
- chart calculations
- chart elements
- element position
- actual position
- child element
- parent element
- chart values
- actual value
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Understand chart calculations, data updates, and precision control in Aspose.Slides for Java for PPT and PPTX, with practical Java code examples."
---

## **Calculate Actual Values of Chart Elements**
Aspose.Slides for Java provides a simple API for getting these properties. Properties of [IAxis](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis) interface provide information about actual position of axis chart element ([IAxis.getActualMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis#getActualMaxValue--), [IAxis.getActualMinValue](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis#getActualMinValue--), [IAxis.getActualMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis#getActualMajorUnit--), [IAxis.getActualMinorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis#getActualMinorUnit--), [IAxis.getActualMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis#getActualMajorUnitScale--), [IAxis.getActualMinorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis#getActualMinorUnitScale--)). It is necessary to call method [IChart.validateChartLayout()](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#validateChartLayout--) previously to fill properties with actual values.

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

## **Calculate Actual Position of Parent Chart Elements**
Aspose.Slides for Java provides a simple API for getting these properties. Properties of [IActualLayout](https://reference.aspose.com/slides/java/com.aspose.slides/IActualLayout) interface provide information about actual position of parent chart element ([IActualLayout.getActualX](https://reference.aspose.com/slides/java/com.aspose.slides/IActualLayout#getActualX--), [IActualLayout.getActualY](https://reference.aspose.com/slides/java/com.aspose.slides/IActualLayout#getActualY--), [IActualLayout.getActualWidth](https://reference.aspose.com/slides/java/com.aspose.slides/IActualLayout#getActualWidth--), [IActualLayout.getActualHeight](https://reference.aspose.com/slides/java/com.aspose.slides/IActualLayout#getActualHeight--)). It is necessary to call method [IChart.validateChartLayout()](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#validateChartLayout--) previously to fill properties with actual values.

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

## **Hide Information from Chart**
This topic helps you to understand how to hide information from chart. Using Aspose.Slides for Java you can hide **Title, Vertical Axis, Horizontal Axis** and **Grid Lines** from chart. Below code example shows how to use these properties.

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //Hiding chart Title
    chart.setTitle(false);

    ///Hiding Values axis
    chart.getAxes().getVerticalAxis().setVisible(false);

    //Category Axis visibility
    chart.getAxes().getHorizontalAxis().setVisible(false);

    //Hiding Legend
    chart.setLegend(false);

    //Hiding MajorGridLines
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

    //Setting series line color
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid);

    pres.save("HideInformationFromChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Do external Excel workbooks work as a data source, and how does that affect recalculation?**

Yes. A chart can reference an external workbook: when you connect or refresh the external source, formulas and values are taken from that workbook, and the chart reflects the updates during open/edit operations. The API lets you [specify the external workbook](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-) path and manage the linked data.

**Can I compute and display trendlines without implementing regression myself?**

Yes. [Trendlines](/slides/java/trend-line/) (linear, exponential, and others) are added and updated by Aspose.Slides; their parameters are recalculated from the series data automatically, so you don’t need to implement your own calculations.

**If a presentation has multiple charts with external links, can I control which workbook each chart uses for computed values?**

Yes. Each chart can point to its own [external workbook](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-), or you can create/replace an external workbook per chart independently of the others.
