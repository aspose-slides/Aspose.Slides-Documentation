---
title: Manage Chart Data Markers in Presentations Using JavaScript
linktitle: Data Marker
type: docs
url: /nodejs-java/chart-data-marker/
keywords:
- chart
- data point
- marker
- marker options
- marker size
- fill type
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Learn how to customize chart data markers in Aspose.Slides for Node.js, boosting presentation impact across PPT and PPTX formats with clear code examples."
---

## **Set Chart Marker Options**

The markers can be set on chart data points inside particular series. In order to set chart marker options. Please follow the steps below:

- Instantiate [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
- Creating the default chart.
- Set the picture.
- Take first chart series.
- Add new data point.
- Write presentation to disk.

In the example given below, we have set the chart marker options on data points level.

```javascript
// Creating empty presentation
var pres = new aspose.slides.Presentation();
try {
    // Access first slide
    var slide = pres.getSlides().get_Item(0);
    // Creating the default chart
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 0, 0, 400, 400);
    // Getting the default chart data WorkSheet index
    var defaultWorksheetIndex = 0;
    // Getting the chart data WorkSheet
    var fact = chart.getChartData().getChartDataWorkbook();
    // Delete demo series
    chart.getChartData().getSeries().clear();
    // Add new series
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    // Load the picture 1
    var imgx1 = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "Desert.jpg")));
    // Load the picture 2
    var imgx2 = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "Tulips.jpg")));
    // Take first chart series
    var series = chart.getChartData().getSeries().get_Item(0);
    // Add new point (1:3) there.
    var point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 4.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 2.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 3.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 4, 1, 4.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    // Changing the chart series marker
    series.getMarker().setSize(15);
    // Save presentation with chart
    pres.save("ScatterChart.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Which marker shapes are available out of the box?**

Standard shapes are available (circle, square, diamond, triangle, etc.); the list is defined by the [MarkerStyleType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/markerstyletype/) enumeration. If you need a non-standard shape, use a marker with a picture fill to emulate custom visuals.

**Are markers preserved when exporting a chart to an image or SVG?**

Yes. When rendering charts to [raster formats](/slides/nodejs-java/convert-powerpoint-to-png/) or saving [shapes as SVG](/slides/nodejs-java/render-a-slide-as-an-svg-image/), markers retain their appearance and settings, including size, fill, and outline.
