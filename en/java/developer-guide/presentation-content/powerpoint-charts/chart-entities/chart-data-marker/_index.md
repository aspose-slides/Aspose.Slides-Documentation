---
title: Manage Chart Data Markers in Presentations Using Java
linktitle: Data Marker
type: docs
url: /java/chart-data-marker/
keywords:
- chart
- data point
- marker
- marker options
- marker size
- fill type
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Learn how to customize chart data markers in Aspose.Slides for Java, boosting presentation impact across PPT and PPTX formats with clear Java code examples."
---

## **Set Chart Marker Options**
The markers can be set on chart data points inside particular series. In order to set chart marker options. Please follow the steps below:

- Instantiate [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- Creating the default chart.
- Set the picture.
- Take first chart series.
- Add new data point.
- Write presentation to disk.

In the example given below, we have set the chart marker options on data points level.

```java
// Creating empty presentation
Presentation pres = new Presentation();
try {
    // Access first slide
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Creating the default chart
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400);
    
    // Getting the default chart data WorkSheet index
    int defaultWorksheetIndex = 0;
    
    // Getting the chart data WorkSheet
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Delete demo series
    chart.getChartData().getSeries().clear();
    
    // Add new series
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());

    // Load the picture 1
    IPPImage imgx1 = pres.getImages().addImage(new FileInputStream(new File("Desert.jpg")));
    
    // Load the picture 2
    IPPImage imgx2 = pres.getImages().addImage(new FileInputStream(new File("Tulips.jpg")));
    
    // Take first chart series
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Add new point (1:3) there.
    IChartDataPoint point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 1, 1, (double) 4.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 2, 1, (double) 2.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 3, 1, (double) 3.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 4, 1, (double) 4.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    
    // Changing the chart series marker
    series.getMarker().setSize(15);
    
    // Save presentation with chart
    pres.save("ScatterChart.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Which marker shapes are available out of the box?**

Standard shapes are available (circle, square, diamond, triangle, etc.); the list is defined by the [MarkerStyleType](https://reference.aspose.com/slides/java/com.aspose.slides/markerstyletype/) class. If you need a non-standard shape, use a marker with a picture fill to emulate custom visuals.

**Are markers preserved when exporting a chart to an image or SVG?**

Yes. When rendering charts to [raster formats](/slides/java/convert-powerpoint-to-png/) or saving [shapes as SVG](/slides/java/render-a-slide-as-an-svg-image/), markers retain their appearance and settings, including size, fill, and outline.
