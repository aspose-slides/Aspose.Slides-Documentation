---
title: Bubble Chart
type: docs
url: /java/bubble-chart/
---

## **Bubble Chart Size Scaling**
Aspose.Slides for Java provides support for Bubble chart size scaling. In Aspose.Slides for Java [**IChartSeries->getBubbleSizeScale**](https://apireference.aspose.com/slides/java/com.aspose.slides/IChartSeries#getBubbleSizeScale--), [**IChartSeriesGroup->getBubbleSizeScale**](https://apireference.aspose.com/slides/java/com.aspose.slides/IChartSeriesGroup#getBubbleSizeScale--) and [**IChartSeriesGroup->setBubbleSizeScale**](https://apireference.aspose.com/slides/java/com.aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-) methods have been added. Below sample example is given. 

```php
$pres = new Java("com.aspose.slides.Presentation");
try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(Java("com.aspose.slides.ChartType")->Bubble, 100, 100, 400, 300);

    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setBubbleSizeScale(150);

    $pres->save("Result.pptx", Java("com.aspose.slides.SaveFormat")->Pptx);
} finally {
    if ($pres != null) $pres->dispose();
}
```

## **Represent Data as Bubble Chart Sizes**
Methods [**setBubbleSizeRepresentation**](https://apireference.aspose.com/slides/java/com.aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) and [**getBubbleSizeRepresentation**](https://apireference.aspose.com/slides/java/com.aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--) have been added to [IChartSeries](https://apireference.aspose.com/slides/java/com.aspose.slides/IChartSeries), [IChartSeriesGroup](https://apireference.aspose.com/slides/java/com.aspose.slides/IChartSeriesGroup) interfaces, and related classes. **BubbleSizeRepresentation** specifies how the bubble size values are represented in the bubble $chart-> Possible values are: [**Java("com.aspose.slides.BubbleSizeRepresentationType")->Area**](https://apireference.aspose.com/slides/java/com.aspose.slides/BubbleSizeRepresentationType#Area) and [**Java("com.aspose.slides.BubbleSizeRepresentationType")->Width**](https://apireference.aspose.com/slides/java/com.aspose.slides/BubbleSizeRepresentationType#Width). Accordingly, [**BubbleSizeRepresentationType**](https://apireference.aspose.com/slides/java/com.aspose.slides/BubbleSizeRepresentationType) enum has been added to specify the possible ways to represent data as bubble chart sizes. Sample code is given below.

```php
$pres = new Java("com.aspose.slides.Presentation");
try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(Java("com.aspose.slides.ChartType")->Bubble, 50, 50, 600, 400, true);

    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setBubbleSizeRepresentation(Java("com.aspose.slides.BubbleSizeRepresentationType")->Width);

    $pres->save("Presentation_BubbleSizeRepresentation.pptx", Java("com.aspose.slides.SaveFormat")->Pptx);
} finally {
    if ($pres != null) $pres->dispose();
}
```