---
title: Data Points of Treemap and Sunburst Chart
type: docs
url: /java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords: "Sunburst graph in Aspose.Slides for Java"
description: "Sunburst Graph, Sunburst Diagram, Sunburst Chart, Radial Chart, Radial Graph or Multi Level Pie Chart with Aspose.Slides for Java."
---

Among other types of PowerPoint charts, there are two "hierarchical" types - **Treemap** and **Sunburst** chart (also known as Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph or Multi Level Pie Chart). These charts display hierarchical data organized as a tree - from leaves to the top of the branch. Leaves are defined by the series data points, and each subsequent nested grouping level defined by the corresponding category. Aspose.Slides for Java allows to format data points of Sunburst Chart and Treemap in Java.

Here is a Sunburst Chart, where data in Series1 column define the leaf nodes, while other columns define hierarchical datapoints:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Let’s start with adding a new Sunburst chart to the presentation:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    // ...
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" title="See also" %}} 
- [**Creating Sunburst Chart**](/slides/java/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}


If there is a need to format data points of the chart, we should use the following:

[**IChartDataPointLevelsManager**](https://apireference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevelsManager), 
[IChartDataPointLevel](https://apireference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel) classes 
and [**IChartDataPoint.getDataPointLevels**](https://apireference.aspose.com/slides/java/com.aspose.slides/IChartDataPoint#getDataPointLevels--) method 
provide access to format data points of Treemap and Sunburst charts. 
[**IChartDataPointLevelsManager**](https://apireference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevelsManager) 
is used for accessing multi-level categories - it represents the container of 
[**IChartDataPointLevel**](https://apireference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel) objects. 
Basically it is a wrapper for 
[**IChartCategoryLevelsManager**](https://apireference.aspose.com/slides/java/com.aspose.slides/IChartCategoryLevelsManager) with 
the properties added specific for data points. 
[**IChartDataPointLevel**](https://apireference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel) class has 
two methods: [**getFormat**](https://apireference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel#getFormat--) and 
[**getDataLabel**](https://apireference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel#getLabel--) which 
provide access to corresponding settings.
## **Show Data Point Value**
Show value of "Leaf 4" data point:

```java
IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Set Data Point Label and Color**
Set "Branch 1" data label to show series name ("Series1") instead of category name. Then set text color to yellow:

```java
IDataLabel branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);

branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Set Data Point Branch Color**
Change color of "Steam 4" branch:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();

    IChartDataPointLevel stem4branch = dataPoints.get_Item(9).getDataPointLevels().get_Item(1);

    stem4branch.getFormat().getFill().setFillType(FillType.Solid);
    stem4branch.getFormat().getFill().getSolidFillColor().setColor(Color.RED);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)




