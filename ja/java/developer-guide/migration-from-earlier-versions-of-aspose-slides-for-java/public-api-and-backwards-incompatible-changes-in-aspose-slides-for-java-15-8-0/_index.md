---
title: Aspose.Slides for Java 15.8.0における公開APIおよび後方互換性のない変更
type: docs
weight: 160
url: /java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for Java 15.8.0 APIで追加されたすべての[追加された](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/)または[削除された](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/)クラス、メソッド、プロパティなど、ならびにその他の変更をリストしています。

{{% /alert %}} 
## **公開APIの変更**
#### **メソッドgetDoughnutHoleSize()、setDoughnutHoleSize(byte)がIChartSeriesおよびChartSeriesに追加されました**
ドーナツチャートの穴のサイズを指定します。

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);

chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);                   

pres.save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

```