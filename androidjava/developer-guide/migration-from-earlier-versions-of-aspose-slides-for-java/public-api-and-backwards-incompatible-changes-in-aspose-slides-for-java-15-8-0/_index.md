---
title: Public API and Backwards Incompatible Changes in Aspose.Slides for Java 15.8.0
type: docs
weight: 160
url: /androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/
---

{{% alert color="primary" %}} 

This page lists all [added](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) or [removed](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) classes, methods, properties and so on, and other changes introduced with the Aspose.Slides for Java 15.8.0 API.

{{% /alert %}} 
## **Public API Changes**
#### **Methods getDoughnutHoleSize(), setDoughnutHoleSize(byte) have been added to IChartSeries and ChartSeries**
Specifies the size of the hole in a doughnut chart.

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);

chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);                   

pres.save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

```
