---
title: Doughnut Chart
type: docs
weight: 30
url: /nodejs-java/doughnut-chart/
---

## **Change Center Gap in Doughnut Chart**
{{% alert color="primary" %}} 

Aspose.Slides for Node.js via Java now supports specifying the size of the hole in a doughnut chart. In this topic, we will see with example how to specify the size of the hole in a doughnut chart.

{{% /alert %}} 

In order to specify the size of the hole in a doughnut chart, please follow the steps below:

1. Instantiate [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) object.
1. Add doughnut chart on the slide.
1. Specify the size of the hole in a doughnut chart.
1. Write presentation to disk.

In the example given below, we have set the size of the hole in a doughnut chart.

```javascript
// Create an instance of Presentation class
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Doughnut, 50, 50, 400, 400);
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize(90);
    // Write presentation to disk
    pres.save("DoughnutHoleSize_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
