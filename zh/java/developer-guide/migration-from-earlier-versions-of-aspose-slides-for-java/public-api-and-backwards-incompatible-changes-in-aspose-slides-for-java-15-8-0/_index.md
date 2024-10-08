---
title: Aspose.Slides for Java 15.8.0 的公共 API 和不兼容的返回变更
type: docs
weight: 160
url: /java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/
---

{{% alert color="primary" %}} 

此页面列出了所有在 Aspose.Slides for Java 15.8.0 API 中[添加](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/)或[移除](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/)的类、方法、属性等以及引入的其他变更。

{{% /alert %}} 
## **公共 API 变更**
#### **已向 IChartSeries 和 ChartSeries 添加方法 getDoughnutHoleSize() 和 setDoughnutHoleSize(byte)**
指定甜甜圈图中洞的大小。

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);

chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);                   

pres.save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

```