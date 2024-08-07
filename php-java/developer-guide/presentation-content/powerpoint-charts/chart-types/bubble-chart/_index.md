---
title: Bubble Chart
type: docs
url: /php-java/bubble-chart/
---

## **Bubble Chart Size Scaling**
Aspose.Slides for PHP via Java provides support for Bubble chart size scaling. In Aspose.Slides for PHP via Java [**IChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeries#getBubbleSizeScale--), [**IChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesGroup#getBubbleSizeScale--) and [**IChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-) methods have been added. Below sample example is given. 

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
Methods [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) and [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--) have been added to [IChartSeries](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeries), [IChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesGroup) interfaces, and related classes. **BubbleSizeRepresentation** specifies how the bubble size values are represented in the bubble chart. Possible values are: [**BubbleSizeRepresentationType::Area**](https://reference.aspose.com/slides/php-java/aspose.slides/BubbleSizeRepresentationType#Area) and [**BubbleSizeRepresentationType::Width**](https://reference.aspose.com/slides/php-java/aspose.slides/BubbleSizeRepresentationType#Width). Accordingly, [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/php-java/aspose.slides/BubbleSizeRepresentationType) enum has been added to specify the possible ways to represent data as bubble chart sizes. Sample code is given below.

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
