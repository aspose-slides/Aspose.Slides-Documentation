---
title: Bubble Chart
type: docs
url: /androidjava/bubble-chart/
---

## **Bubble Chart Size Scaling**
Aspose.Slides for Android via Java provides support for Bubble chart size scaling. In Aspose.Slides for Android via Java [**IChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeries#getBubbleSizeScale--), [**IChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup#getBubbleSizeScale--) and [**IChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-) methods have been added. Below sample example is given. 

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 100, 100, 400, 300);

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150);

    pres.save("Result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Represent Data as Bubble Chart Sizes**
Methods [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) and [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--) have been added to [IChartSeries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeries), [IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup) interfaces, and related classes. **BubbleSizeRepresentation** specifies how the bubble size values are represented in the bubble chart. Possible values are: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BubbleSizeRepresentationType#Area) and [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BubbleSizeRepresentationType#Width). Accordingly, [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BubbleSizeRepresentationType) enum has been added to specify the possible ways to represent data as bubble chart sizes. Sample code is given below.

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(BubbleSizeRepresentationType.Width);

    pres.save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
