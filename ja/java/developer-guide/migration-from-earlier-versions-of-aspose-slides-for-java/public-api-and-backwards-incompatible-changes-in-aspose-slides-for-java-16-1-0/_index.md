---
title: Aspose.Slides for Java 16.1.0 におけるパブリック API および互換性のない変更
type: docs
weight: 200
url: /ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for Java 16.1.0 API で追加されたすべての [追加された](/slides/ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) または [削除された](/slides/ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) クラス、メソッド、プロパティなど、その他の変更を一覧表示します。

{{% /alert %}} 
## **パブリック API の変更**


#### **IChartTextBlockFormat と ITextFrameFormat インターフェイスに getRotationAngle() と setRotationAngle() メソッドが追加されました**
getRotationAngle() メソッドと setRotationAngle() メソッドが com.aspose.slides.IChartTextBlockFormat および com.aspose.slides.ITextFrameFormat インターフェイスに追加されました。
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