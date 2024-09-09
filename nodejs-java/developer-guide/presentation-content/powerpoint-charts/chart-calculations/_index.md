---
title: Chart Calculations
type: docs
weight: 50
url: /nodejs-java/chart-calculations/
---

## **Calculate Actual Values of Chart Elements**
Aspose.Slides for Java provides a simple API for getting these properties. Properties of [IAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/IAxis) interface provide information about actual position of axis chart element ([IAxis.getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/IAxis#getActualMaxValue--), [IAxis.getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/IAxis#getActualMinValue--), [IAxis.getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/IAxis#getActualMajorUnit--), [IAxis.getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/IAxis#getActualMinorUnit--), [IAxis.getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/IAxis#getActualMajorUnitScale--), [IAxis.getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/IAxis#getActualMinorUnitScale--)). It is necessary to call method [IChart.validateChartLayout()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/IChart#validateChartLayout--) previously to fill properties with actual values.

```javascript
    var pres = new  aspose.slides.Presentation();
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

## **Calculate Actual Position of Parent Chart Elements**
Aspose.Slides for Java provides a simple API for getting these properties. Properties of [IActualLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/IActualLayout) interface provide information about actual position of parent chart element ([IActualLayout.getActualX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/IActualLayout#getActualX--), [IActualLayout.getActualY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/IActualLayout#getActualY--), [IActualLayout.getActualWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/IActualLayout#getActualWidth--), [IActualLayout.getActualHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/IActualLayout#getActualHeight--)). It is necessary to call method [IChart.validateChartLayout()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/IChart#validateChartLayout--) previously to fill properties with actual values.

```javascript
    var pres = new  aspose.slides.Presentation();
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

## **Hide Information from Chart**
This topic helps you to understand how to hide information from chart. Using Aspose.Slides for Java you can hide **Title, Vertical Axis, Horizontal Axis** and **Grid Lines** from chart. Below code example shows how to use these properties.

```javascript
    var pres = new  aspose.slides.Presentation();
    try {
        var slide = pres.getSlides().get_Item(0);
        var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 140, 118, 320, 370);
        // Hiding chart Title
        chart.setTitle(false);
        // /Hiding Values axis
        chart.getAxes().getVerticalAxis().setVisible(false);
        // Category Axis visibility
        chart.getAxes().getHorizontalAxis().setVisible(false);
        // Hiding Legend
        chart.setLegend(false);
        // Hiding MajorGridLines
        chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(aspose.slides.FillType.NoFill);
        for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
            chart.getChartData().getSeries().removeAt(i);
        }
        var series = chart.getChartData().getSeries().get_Item(0);
        series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);
        series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
        series.getLabels().getDefaultDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.Top);
        series.getMarker().setSize(15);
        // Setting series line color
        series.getFormat().getLine().getFillFormat().setFillType(aspose.slides.FillType.Solid);
        series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
        series.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.Solid);
        pres.save("HideInformationFromChart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```
