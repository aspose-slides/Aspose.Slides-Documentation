---
title: Customize Doughnut Charts in Presentations on Android
linktitle: Doughnut Chart
type: docs
weight: 30
url: /androidjava/doughnut-chart/
keywords:
- doughnut chart
- center gap
- hole size
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Discover how to create and customize doughnut charts in Aspose.Slides for Android via Java, supporting PowerPoint formats for dynamic presentations."
---

## **Specify the Center Gap in a Doughnut Chart**
{{% alert color="primary" %}} 

Aspose.Slides for Android via Java now supports specifying the size of the hole in a doughnut chart. In this topic, we will see with example how to specify the size of the hole in a doughnut chart.

{{% /alert %}} 

In order to specify the size of the hole in a doughnut chart, please follow the steps below:

1. Instantiate [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) object.
1. Add doughnut chart on the slide.
1. Specify the size of the hole in a doughnut chart.
1. Write presentation to disk.

In the example given below, we have set the size of the hole in a doughnut chart.

```java
// Create an instance of Presentation class
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // Write presentation to disk
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Can I create a multi-level doughnut with multiple rings?**

Yes. Add multiple series to a single doughnut chart—each series becomes a separate ring. The ring order is determined by the order of the series in the collection.

**Is an "exploded" doughnut (separated slices) supported?**

Yes. There is an Exploded Doughnut [chart type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) and an explosion property on data points; you can separate individual slices.

**How can I get an image of a doughnut chart (PNG/SVG) for a report?**

A chart is a shape; you can render it to a [raster image](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) or export the chart to an [SVG image](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).
