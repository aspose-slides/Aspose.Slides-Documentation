---
title: Chart Axis
type: docs
url: /nodejs-java/chart-axis/
keywords: "PowerPoint Chart Axis, Presentation Charts, Java, Manipulate Chart Axis, Chart data"
description: "How to edit PowerPoint chart axis in Java"
---


## **Getting the Max Values on the Vertical Axis on Charts**
Aspose.Slides for Node.js via Java allows you to obtain the minimum and maximum values on a vertical axis. Go through these steps:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
1. Access the first slide.
1. Add a chart with default data.
1. Get the actual maximum value on the axis.
1. Get the actual minimum value on the axis.
1. Get the actual major unit of the axis.
1. Get the actual minor unit of the axis.
1. Get the actual major unit scale of the axis.
1. Get the actual minor unit scale of the axis.

This sample code—an implementation of the steps above—shows you how to get the required values in Java:

```javascript
    var pres = new  aspose.slides.Presentation();
    try {
        var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
        chart.validateChartLayout();
        var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
        var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
        var majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
        var minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
        // Saves the presentation
        pres.save("MaxValuesVerticalAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Swapping the Data between Axes**
Aspose.Slides allows you to quickly swap the data between axes—the data represented on the vertical axis (y-axis) moves to the horizontal axis (x-axis) and vice versa. 

This Java code shows you how to perform the data swap task between axes on a chart:

```javascript
    var pres = new  aspose.slides.Presentation();
    try {
        var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
        // Switches rows and columns
        chart.getChartData().switchRowColumn();
        // Saves presentation
        pres.save("SwitchChartRowColumns_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Disabling the Vertical Axis for Line Charts**

This Java code shows you how to hide the vertical axis for a line chart:

```javascript
    var pres = new  aspose.slides.Presentation();
    try {
        var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
        chart.getAxes().getVerticalAxis().setVisible(false);
        pres.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Disabling the Horizontal Axis for Line Charts**

This code shows you how to hide the horizontal axis for a line chart:

```javascript
    var pres = new  aspose.slides.Presentation();
    try {
        var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
        chart.getAxes().getHorizontalAxis().setVisible(false);
        pres.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Changing Category Axis**

Using the **CategoryAxisType** property, you can specify your preferred category axis type (**date** or **text**). This code in Java demonstrates the operation: 

```javascript
    var presentation = new  aspose.slides.Presentation("ExistingChart.pptx");
    try {
        var chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
        chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
        chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
        chart.getAxes().getHorizontalAxis().setMajorUnit(1);
        chart.getAxes().getHorizontalAxis().setMajorUnitScale(aspose.slides.TimeUnitType.Months);
        presentation.save("ChangeChartCategoryAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (presentation != null) {
            presentation.dispose();
        }
    }
```

## **Setting the Date Format for Category Axis Value**
Aspose.Slides for Node.js via Java allows you to set the date format for a category axis value. The operation is demonstrated in this Java code:

```javascript
    var pres = new  aspose.slides.Presentation();
    try {
        var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 50, 50, 450, 300);
        var wb = chart.getChartData().getChartDataWorkbook();
        wb.clear(0);
        chart.getChartData().getCategories().clear();
        chart.getChartData().getSeries().clear();
        chart.getChartData().getCategories().add(wb.getCell(0, "A2", convertToOADate(java.newInstanceSync("GregorianCalendar", 2015, 1, 1))));
        chart.getChartData().getCategories().add(wb.getCell(0, "A3", convertToOADate(java.newInstanceSync("GregorianCalendar", 2016, 1, 1))));
        chart.getChartData().getCategories().add(wb.getCell(0, "A4", convertToOADate(java.newInstanceSync("GregorianCalendar", 2017, 1, 1))));
        chart.getChartData().getCategories().add(wb.getCell(0, "A5", convertToOADate(java.newInstanceSync("GregorianCalendar", 2018, 1, 1))));
        var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
        series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B2", 1));
        series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B3", 2));
        series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B4", 3));
        series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B5", 4));
        chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
        chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
        chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");
        pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```
```javascript
```

## **Setting the Rotation Angle for Chart Axis Title**
Aspose.Slides for Node.js via Java allows you to set the rotation angle for a chart axis title. This Java code demonstrates the operation:

```javascript
    var pres = new  aspose.slides.Presentation();
    try {
        var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
        chart.getAxes().getVerticalAxis().setTitle(true);
        chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);
        pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Setting the Position Axis in a Category or Value Axis**
Aspose.Slides for Node.js via Java allows you to set the position axis in a category or value axis. This Java code shows how to perform the task:

```javascript
    var pres = new  aspose.slides.Presentation();
    try {
        var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
        chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);
        pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Enabling the Display Unit label on Chart Value Axis**
Aspose.Slides for Node.js via Java allows you to configure a chart to show a unit label on its chart value axis. This Java code demonstrates the operation:

```javascript
    var pres = new  aspose.slides.Presentation();
    try {
        var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
        chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Millions);
        pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```
