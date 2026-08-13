---
title: Aspose.Slides for Java 16.1.0 のパブリック API と後方互換性のない変更
linktitle: Aspose.Slides for Java 16.1.0
type: docs
weight: 200
url: /ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/
keywords:
- 移行
- レガシーコード
- モダンコード
- レガシーアプローチ
- モダンアプローチ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java のパブリック API の更新と破壊的変更を確認し、PowerPoint の PPT、PPTX、ODP プレゼンテーション ソリューションをスムーズに移行できるようにします。"
---
{{% alert color="info" %}} 
このページでは、Aspose.Slides for Java 16.1.0 APIで導入された、[追加](/slides/ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) または [削除](/slides/ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) クラス、メソッド、プロパティ等、その他の変更をすべて一覧します。
{{% /alert %}} 
## **パブリック API の変更**


#### **IChartTextBlockFormat と ITextFrameFormat インターフェイスに、メソッド getRotationAngle() と setRotationAngle() が追加されました**
メソッド getRotationAngle() と setRotationAngle() が、インターフェイス com.aspose.slides.IChartTextBlockFormat と com.aspose.slides.ITextFrameFormat に追加されました。
これらは、バウンディングボックス内のテキストに適用されるカスタム回転角度へのアクセスを提供します。

``` java
import com.aspose.slides.*;




Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.getChartData().getSeries().get_Item(0);

series.getLabels().getDefaultDataLabelFormat().setShowValue (true);

series.getLabels().getDefaultDataLabelFormat().getTextFormat ().getTextBlockFormat().setRotationAngle(65);

chart.setTitle(true);

chart.getChartTitle().addTextFrameForOverriding("Custom title").getTextFrameFormat().setRotationAngle(-30);

pres.save("out.pptx", SaveFormat.Pptx);


```