---
title: Public API and Backwards Incompatible Changes in Aspose.Slides for Java 15.8.0
type: docs
weight: 160
url: /java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/
---

{{% alert color="primary" %}} 

This page lists all [added](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) or [removed](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) classes, methods, properties and so on, and other changes introduced with the Aspose.Slides for Java 15.8.0 API.

{{% /alert %}} 
## **Public API Changes**
#### **Methods getDoughnutHoleSize(), setDoughnutHoleSize(byte) have been added to IChartSeries and ChartSeries**
Specifies the size of the hole in a doughnut chart.

```javascript
    var pres = new  com.aspose.slides.Presentation();
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(com.aspose.slides.ChartType.Doughnut, 50, 50, 400, 400);
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize(90);
    pres.save("ChartSeries.API.DoughnutHoleSize.pptx", com.aspose.slides.SaveFormat.Pptx);
```
