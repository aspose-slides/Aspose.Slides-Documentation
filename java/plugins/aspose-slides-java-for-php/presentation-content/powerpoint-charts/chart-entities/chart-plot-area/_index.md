---
title: Chart Plot Area
type: docs
url: /java/chart-plot-area/
---


## **Get Width, Height of Chart Plot Area**
Aspose.Slides for Java provides a simple API for . 

1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
1. Access first slide.
1. Add chart with default data.
1. Call method [IChart.validateChartLayout()](https://apireference.aspose.com/slides/java/com.aspose.slides/IChart#validateChartLayout--) before to get actual values.
1. Gets actual X location (left) of the chart element relative to the left top corner of the $chart->
1. Gets actual top of the chart element relative to the left top corner of the $chart->
1. Gets actual width of the chart element.
1. Gets actual height of the chart element.

```php
// Create an instance of Presentation class
$pres = new Java("com.aspose.slides.Presentation");
try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(Java("com.aspose.slides.ChartType")->ClusteredColumn, 100, 100, 500, 350);
    $chart->validateChartLayout();

    $x = $chart->getPlotArea()->getActualX();
    $y = $chart->getPlotArea()->getActualY();
    $w = $chart->getPlotArea()->getActualWidth();
    $h = $chart->getPlotArea()->getActualHeight();
} finally {
    if ($pres != null) $pres->dispose();
}
```

## **Set Layout Mode of Chart Plot Area**
Aspose.Slides for Java provides a simple API to set the layout mode of the chart plot area. Methods [**setLayoutTargetType**](https://apireference.aspose.com/slides/java/com.aspose.slides/ChartPlotArea#setLayoutTargetType-int-) and [**getLayoutTargetType**](https://apireference.aspose.com/slides/java/com.aspose.slides/ChartPlotArea#getLayoutTargetType--) have been added to [**ChartPlotArea**](https://apireference.aspose.com/slides//java/com.aspose.slides/ChartPlotArea) class and [**IChartPlotArea**](https://apireference.aspose.com/slides/java/com.aspose.slides/IChartPlotArea) interface. If the layout of the plot area defined manually this property specifies whether to layout the plot area by its inside (not including axis and axis labels) or outside (including axis and axis labels). There are two possible values which are defined in [**LayoutTargetType**](https://apireference.aspose.com/slides/java/com.aspose.slides/LayoutTargetType) enum.

- [**LayoutTargetType.Inner**](https://apireference.aspose.com/slides/java/com.aspose.slides/LayoutTargetType#Inner) - specifies that the plot area size shall determine the size of the plot area, not including the tick marks and axis labels.
- [**LayoutTargetType.Outer**](https://apireference.aspose.com/slides/java/com.aspose.slides/LayoutTargetType#Outer) - specifies that the plot area size shall determine the size of the plot area, the tick marks, and the axis labels.

Sample code is given below.

```php
// Create an instance of Presentation class
$pres = new Java("com.aspose.slides.Presentation");
try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(Java("com.aspose.slides.ChartType")->ClusteredColumn, 20, 100, 600, 400);
    $chart->getPlotArea()->setX(0.2);
    $chart->getPlotArea()->setY(0.2);
    $chart->getPlotArea()->setWidth(0.7);
    $chart->getPlotArea()->setHeight(0.7);
    $chart->getPlotArea()->setLayoutTargetType(Java("com.aspose.slides.LayoutTargetType")->Inner);

    $pres->save("SetLayoutMode_outer.pptx", Java("com.aspose.slides.SaveFormat")->Pptx);
} finally {
    if ($pres != null) $pres->dispose();
}
```