---
title: 3D Chart
type: docs
url: /java/3d-chart/
---

## **Set RotationX, RotationY and DepthPercents properties of 3D Chart**
Aspose.Slides for Java provides a simple API for setting these properties. This following article will help you how set different properties like **X,Y Rotation, DepthPercents** etc. The sample code applies setting the above said properties.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Access first slide.
1. Add chart with default data.
1. Set Rotation3D properties.
1. Write the modified presentation to a PPTX file.

```javascript
    var pres = new  com.aspose.slides.Presentation();
    try {
        // Access first slide
        var slide = pres.getSlides().get_Item(0);
        // Add chart with default data
        var chart = slide.getShapes().addChart(com.aspose.slides.ChartType.StackedColumn3D, 0, 0, 500, 500);
        // Setting the index of chart data sheet
        var defaultWorksheetIndex = 0;
        // Getting the chart data worksheet
        var fact = chart.getChartData().getChartDataWorkbook();
        // Add series
        chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
        chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
        // Add Catrgories
        chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
        chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
        chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
        // Set Rotation3D properties
        chart.getRotation3D().setRightAngleAxes(true);
        chart.getRotation3D().setRotationX(40);
        chart.getRotation3D().setRotationY(270);
        chart.getRotation3D().setDepthPercents(150);
        // Take second chart series
        var series = chart.getChartData().getSeries().get_Item(1);
        // Now populating series data
        series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
        series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
        series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
        series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
        series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
        series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
        // Set OverLap value
        series.getParentSeriesGroup().setOverlap(100);
        // Write presentation to disk
        pres.save("Rotation3D_out.pptx", com.aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```
