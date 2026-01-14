---
title: Customize Bubble Charts in Presentations Using PHP
linktitle: Bubble Chart
type: docs
url: /php-java/bubble-chart/
keywords:
- bubble chart
- bubble size
- size scaling
- size representation
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Create and customize powerful bubble charts in PowerPoint with Aspose.Slides for PHP via Java to enhance your data visualization easily."
---

## **Bubble Chart Size Scaling**
Aspose.Slides for PHP via Java provides support for Bubble chart size scaling. In Aspose.Slides for PHP via Java [**ChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getbubblesizescale/), [**ChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/getbubblesizescale/) and [**ChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setbubblesizescale/) methods have been added. Below sample example is given. 

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 100, 100, 400, 300);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setBubbleSizeScale(150);
    $pres->save("Result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Represent Data as Bubble Chart Sizes**
Methods [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setbubblesizerepresentation/) and [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/getbubblesizerepresentation/) have been added to [ChartSeries](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/), [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) classes, and related classes. **BubbleSizeRepresentation** specifies how the bubble size values are represented in the bubble chart. Possible values are: [**BubbleSizeRepresentationType::Area**](https://reference.aspose.com/slides/php-java/aspose.slides/BubbleSizeRepresentationType#Area) and [**BubbleSizeRepresentationType::Width**](https://reference.aspose.com/slides/php-java/aspose.slides/BubbleSizeRepresentationType#Width). Accordingly, [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/php-java/aspose.slides/BubbleSizeRepresentationType) enum has been added to specify the possible ways to represent data as bubble chart sizes. Sample code is given below.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setBubbleSizeRepresentation(BubbleSizeRepresentationType::Width);
    $pres->save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Is a "bubble chart with 3-D effect" supported, and how does it differ from a regular one?**

Yes. There is a separate chart type, "Bubble with 3-D." It applies 3-D styling to the bubbles but does not add an additional axis; the data remain X-Y-S (size). The type is available in the [chart type](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) class.

**Is there a limit on the number of series and points in a bubble chart?**

There is no hard limit at the API level; constraints are determined by performance and the target PowerPoint version. It is recommended to keep the number of points reasonable for readability and rendering speed.

**How will export affect the appearance of a bubble chart (PDF, images)?**

Export to supported formats preserves the chart’s appearance; rendering is performed by the Aspose.Slides engine. For raster/vector formats, general chart-graphics rendering rules apply (resolution, anti-aliasing), so choose sufficient DPI for printing.
