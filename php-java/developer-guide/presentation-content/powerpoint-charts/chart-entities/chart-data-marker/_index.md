---
title: Chart Data Marker
type: docs
url: /php-java/chart-data-marker/
---

## **Set Chart Marker Options**
The markers can be set on chart data points inside particular series. In order to set chart marker options. Please follow the steps below:

- Instantiate [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
- Creating the default chart.
- Set the picture.
- Take first chart series.
- Add new data point.
- Write presentation to disk.

In the example given below, we have set the chart marker options on data points level.

```php
  // Creating empty presentation
  $pres = new Presentation();
  try {
    // Access first slide
    $slide = $pres->getSlides()->get_Item(0);
    // Creating the default chart
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 0, 0, 400, 400);
    // Getting the default chart data WorkSheet index
    $defaultWorksheetIndex = 0;
    // Getting the chart data WorkSheet
    $fact = $chart->getChartData()->getChartDataWorkbook();
    // Delete demo series
    $chart->getChartData()->getSeries()->clear();
    // Add new series
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Series 1"), $chart->getType());
    // Load the picture 1
    $imgx1 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Desert.jpg")));
    // Load the picture 2
    $imgx2 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Tulips.jpg")));
    // Take first chart series
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    // Add new point (1:3) there.
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 4.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx1);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 2.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx2);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 3.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx1);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 4, 1, 4.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx2);
    // Changing the chart series marker
    $series->getMarker()->setSize(15);
    // Save presentation with chart
    $pres->save("ScatterChart.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
