---
title: Chart Data Marker
type: docs
url: /java/chart-data-marker/
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
    var pres = new  aspose.slides.Presentation();
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
    } catch (e) {
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```
