---
title: Aspose.Slides for Java 16.1.0のパブリックAPIと後方互換性のない変更
type: docs
weight: 200
url: /androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for Java 16.1.0 APIで追加されたすべての[class](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/)または[removed](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/)クラス、メソッド、プロパティなど、およびその他の変更が一覧表示されています。

{{% /alert %}} 
## **パブリックAPIの変更**


#### **IChartTextBlockFormatおよびITextFrameFormatインターフェイスにgetRotationAngle()およびsetRotationAngle()メソッドが追加されました**
getRotationAngle()およびsetRotationAngle()メソッドがcom.aspose.slides.IChartTextBlockFormatおよびcom.aspose.slides.ITextFrameFormatインターフェイスに追加されました。
これにより、バウンディングボックス内のテキストに適用されるカスタム回転にアクセスできます。

``` java



Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.getChartData().getSeries().get_Item(0);

series.getLabels().getDefaultDataLabelFormat().setShowValue (true);

series.getLabels().getDefaultDataLabelFormat().getTextFormat ().getTextBlockFormat().setRotationAngle(65);

chart.setTitle(true);

chart.getChartTitle().addTextFrameForOverriding("カスタムタイトル").getTextFrameFormat().setRotationAngle(-30);

pres.save("out.pptx", SaveFormat.Pptx);


```