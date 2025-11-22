---
title: 3D Chart
type: docs
url: /nodejs-java/3d-chart/
---

## **Set RotationX, RotationY and DepthPercents properties of 3D Chart**

Aspose.Slides for Node.js via Java provides a simple API for setting these properties. This following article will help you how set different properties like **X,Y Rotation, DepthPercents** etc. The sample code applies setting the above said properties.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) class.
1. Access first slide.
1. Add chart with default data.
1. Set Rotation3D properties.
1. Write the modified presentation to a PPTX file.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Access first slide
    var slide = pres.getSlides().get_Item(0);
    // Add chart with default data
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn3D, 0, 0, 500, 500);
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
    pres.save("Rotation3D_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Which chart types support 3D mode in Aspose.Slides?**

Aspose.Slides supports 3D variants of column charts, including Column 3D, Clustered Column 3D, Stacked Column 3D, and 100% Stacked Column 3D, along with related 3D types exposed through the [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) enumeration. For an exact, up-to-date list, check the [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) members in the API reference of your installed version.

**Can I get a raster image of a 3D chart for a report or the web?**

Yes. You can export a chart to an image via the [chart API](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) or [render the entire slide](/slides/nodejs-java/convert-powerpoint-to-png/) to formats like PNG or JPEG. This is useful when you need a pixel-perfect preview or want to embed the chart into documents, dashboards, or web pages without requiring PowerPoint.

**How performant is building and rendering large 3D charts?**

Performance depends on data volume and visual complexity. For best results, keep 3D effects minimal, avoid heavy textures on walls and plot areas, limit the number of data points per series when possible, and render to an appropriately sized output (resolution and dimensions) to match the target display or print needs.
