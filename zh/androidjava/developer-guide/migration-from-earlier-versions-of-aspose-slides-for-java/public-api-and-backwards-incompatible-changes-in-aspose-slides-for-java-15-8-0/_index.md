---
title: Aspose.Slides for Java 15.8.0 的公共 API 和不兼容更改
type: docs
weight: 160
url: /zh/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/
---

{{% alert color="primary" %}} 

此页面列出了所有在 Aspose.Slides for Java 15.8.0 API 中 [添加的](/slides/zh/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) 或 [移除的](/slides/zh/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) 类、方法、属性等，以及其他更改。

{{% /alert %}} 
## **公共 API 更改**
#### **方法 getDoughnutHoleSize()、setDoughnutHoleSize(byte) 已添加到 IChartSeries 和 ChartSeries**
指定环形图中孔的大小。

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);

chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);                   

pres.save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

```