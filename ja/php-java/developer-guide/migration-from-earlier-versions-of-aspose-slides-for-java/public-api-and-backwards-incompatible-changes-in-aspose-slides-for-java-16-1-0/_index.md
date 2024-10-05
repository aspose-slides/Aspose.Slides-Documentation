---
title: Aspose.Slides for PHP via Java 16.1.0のパブリックAPIと後方互換性のない変更
type: docs
weight: 200
url: /php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for PHP via Java 16.1.0 APIで追加されたすべての[追加された](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/)または[削除された](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/)クラス、メソッド、プロパティなど、およびその他の変更を一覧表示しています。

{{% /alert %}} 
## **パブリックAPIの変更**


#### **IChartTextBlockFormatおよびITextFrameFormatインターフェイスにgetRotationAngle()およびsetRotationAngle()メソッドが追加されました**
メソッドgetRotationAngle()とsetRotationAngle()がインターフェイスcom.aspose.slides.IChartTextBlockFormatおよびcom.aspose.slides.ITextFrameFormatに追加されました。
これにより、境界ボックス内のテキストに適用されるカスタム回転を取得できます。

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
  $series = $chart->getChartData()->getSeries()->get_Item(0);
  $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
  $series->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getTextBlockFormat()->setRotationAngle(65);
  $chart->setTitle(true);
  $chart->getChartTitle()->addTextFrameForOverriding("カスタムタイトル")->getTextFrameFormat()->setRotationAngle(-30);
  $pres->save("out.pptx", SaveFormat::Pptx);

```