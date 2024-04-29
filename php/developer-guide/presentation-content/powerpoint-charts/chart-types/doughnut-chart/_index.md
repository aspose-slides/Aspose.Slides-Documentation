---
title: Doughnut Chart
type: docs
weight: 30
url: /php-java/doughnut-chart/
---

## **Change Center Gap in Doughnut Chart**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java now supports specifying the size of the hole in a doughnut chart. In this topic, we will see with example how to specify the size of the hole in a doughnut chart.

{{% /alert %}} 

In order to specify the size of the hole in a doughnut chart, please follow the steps below:

1. Instantiate [Presentation](https://reference.aspose.com/slides/php-java/com.aspose.slides/presentation) object.
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
